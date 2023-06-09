﻿using Microsoft.Reporting.WinForms;
using Excel = Microsoft.Office.Interop.Excel;
using SmartFactory;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SmartMES_Giroei
{
    public partial class P1B16_ITEM_BOX_RETURN_SUB : Form
    {
        public P1B16_ITEM_BOX_RETURN parentWin;
        public string sGubun, sIsComplete, sSujuNo, sSujuSeq, sProdID, sProdName, sBoxID;

        static Excel.Application excelApp = null;
        static Excel.Workbook workBook = null;
        static Excel.Worksheet workSheet = null;
        static Excel.Range range = null;
        public P1B16_ITEM_BOX_RETURN_SUB()
        {
            InitializeComponent();
        }
        private void P1B16_ITEM_BOX_RETURN_SUB_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (sGubun == "구성완료")
            {
                if (sIsComplete == "완료") btnItemBox.Visible = false;
                else if (sIsComplete == "진행중") btnItemBox.Visible = true;
            }

            ListSearch();
        }
        public void ListSearch()
        {
            //lblMsg.Text = "";
            lbSujuInfo.Text = $@"수주번호 : {@sSujuNo} / 수주순번 : {@sSujuSeq} / 품목명 : {@sProdName}";
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                sP_Item_Box_Sub_ReturnTableAdapter.Fill(dataSetP1B.SP_Item_Box_Sub_Return, sSujuNo, Convert.ToInt32(sSujuSeq));
                var data = dataSetP1B.SP_Item_Box_Sub;
                Logger.ApiLog(G.UserID, "BOM 정보(현품박스)", ActionType.조회, data);

                dataGridView1.CurrentCell = null;
                dataGridView1.ClearSelection();

                if (sGubun == "자재입고")
                {
                    //dataGridView1.Columns[10].ReadOnly = false;
                }
                else if (sGubun == "구성완료")
                {
                    //dataGridView1.Enabled = false;
                }
            }
            catch (NullReferenceException)
            {
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        #region GridView Events
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int rowIndex = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible);
            if (rowIndex <= 0) return;

            try
            {
                string pre_mbarcode = string.Empty;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    string mbarcode = dataGridView1.Rows[i].Cells[21].Value.ToString();
                    if (string.Equals(pre_mbarcode, mbarcode))
                    {
                        //dataGridView1.Rows[i].Cells[13].Style.ForeColor = Color.Transparent;
                        //dataGridView1.Rows[i].Cells[16].Style.ForeColor = Color.Transparent;
                    }
                    pre_mbarcode = mbarcode;
                }
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int columnIndex = dataGridView1.CurrentCell.ColumnIndex;

            if (columnIndex == 8 || columnIndex == 13)  // LOTNO/투입량
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '.'))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
                {
                    e.Handled = true;
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (G.Authority == "D") return;
            if (e.RowIndex < 0) return;
            if (e.RowIndex == dataGridView1.RowCount - 1) return;

            if (e.ColumnIndex == 9)     // 버튼 
            {
                P1B16_ITEM_BOX_RETURN_LOT sub = new P1B16_ITEM_BOX_RETURN_LOT();
                sub.lblProd.Text += dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                sub.lblProdNm.Text += dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells[8].Value == null || dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString() == "")
                    sub.lblDate.Text += "";
                else
                    sub.lblDate.Text += DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString()).ToString("yyyy-MM-dd");
                sub.lblBarcode.Text = dataGridView1.Rows[e.RowIndex].Cells[19].Value.ToString();
                sub.sBarcode = dataGridView1.Rows[e.RowIndex].Cells[19].Value.ToString();
                sub.sProd = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                sub.parentWin = this;
                sub.ShowDialog();
            }
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
        }
        #endregion
        
        #region Button Controls
        private void btnItemBox_Click(object sender, EventArgs e)   //회수수량등록
        {
            lblMsg.Text = "";
            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            sql = $@"SELECT COUNT(box_id) FROM Item_box_main WHERE order_id = '{@sSujuNo}' AND order_seq = '{@sSujuSeq}'";
            DataTable table = m.dbDataTable(sql, ref msg);

            if (Convert.ToInt64(table.Rows[0][0]) == 0)
            {
                MessageBox.Show("해당 현품박스 정보가 없습니다.");
                return;
            }

            DialogResult dr = MessageBox.Show("\r회수수량 등록 후에 \r 수정이 불가능합니다. \r 등록하시겠습니까?", "회수수량 등록", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No) return;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string sQty = dataGridView1.Rows[i].Cells[15].Value.ToString(); // 회수량

                if (string.IsNullOrEmpty(sQty)) continue;

                string sSubID = dataGridView1.Rows[i].Cells[6].Value.ToString().Replace(",", "");    // 자재코드
                string sDate = DateTime.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString()).ToString("yyyy-MM-dd");  // 입고일(LOTNO)
                string sContents = dataGridView1.Rows[i].Cells[20].Value.ToString();
                string mBarcode = dataGridView1.Rows[i].Cells[21].Value.ToString();
                string sBarcode = dataGridView1.Rows[i].Cells[9].Value.ToString();
                string sCust = dataGridView1.Rows[i].Cells[2].Value.ToString();
                sql = "UPDATE Item_box_sub SET return_Qty = " + sQty + "  WHERE box_id = " + sBoxID + " AND prod_id_sub = '" + sSubID + "' and barcode_surfix = '" + sBarcode + "'";
                m.dbCUD(sql, ref msg);
                
                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }

                if (int.Parse(sQty) == 0) continue;

                //   INV_material_in 테이블에 다시 입력. -> 이후에 변경해야 할 듯 하다.
                sql = "insert ignore into INV_material_in (mbarcode, barcode_surfix, cust_id, prod_id, input_date, plant, order_id, order_seq, qty, reason_code, enter_man) " +
                    "values ('" + mBarcode + "','" + sBarcode + "','" + sCust + "','" + sSubID + "','" + sDate + "','" + G.Pos + "','" + sSujuNo + "','" + sSujuSeq + "'," + sQty + ",'0008','" + G.UserID + "')";
                    //+ " on duplicate key update" +
                    //" prod_id = '" + sSubID + "', cust_id = '" + sCust + "', input_date = '" + sDate + "', plant = '" + G.Pos + "', prodorder_id = '" + sSujuNo + "', output_date = " + DateTime.Now.ToString("yyyy-MM-dd") + "', qty = " + sCount + ", enter_man = '" + G.UserID + "'";
                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }
                
                sql = "update INV_real_stock set current_qty = current_qty + " + sQty + ", partin_total = partin_total + " + sQty + "" +        // real_stock 테이블에 회수량 더하기.
                        " where prod_id = '" + sSubID + "' and cust_id = '" + sCust + "'";
                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    MessageBox.Show(msg);
                    return;
                }
            }
            lblMsg.Text = "해당 수주건의 현품박스 구성상태 변경에 성공했습니다.";
            
            sql = $@"UPDATE SAL_order_sub SET prod_status = 8 WHERE order_id = '{@sSujuNo}' AND order_seq = '{@sSujuSeq}'"; // 상태 8현품박스회수완료로 변경.
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            sql = $@"UPDATE Item_box_main SET returnYN = 'Y', return_dt = '{@DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE order_id = '{@sSujuNo}' AND order_seq = '{@sSujuSeq}'";
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            parentWin.ListSearch();

            for (int i = 0; i < parentWin.dataGridView1.Rows.Count; i++)
            {
                if (parentWin.dataGridView1.Rows[i].Cells[1].Value.ToString() == sSujuNo && parentWin.dataGridView1.Rows[i].Cells[2].Value.ToString() == sSujuSeq)
                {
                    parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[0, i];
                    parentWin.dataGridView1.CurrentCell.Selected = true;
                    break;
                }
            }

            this.DialogResult = DialogResult.OK;
        }
        private void btnMaterial_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(sBoxID))
            //{
            //    MessageBox.Show("현품박스가 구성되지 않았습니다.");
            //    return;
            //}
            //if (dataGridView1.Rows.Count == 0) return;

            //int ItemCount = 0;
            //string sSubID = string.Empty;

            //string sql = string.Empty;
            //string msg = string.Empty;
            //MariaCRUD m = new MariaCRUD();

            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    ItemCount = Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value); // 투입량
            //    sSubID = dataGridView1.Rows[i].Cells[6].Value.ToString().Replace(",","");   // 자재코드
            //    string sDate = DateTime.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString()).ToString("yyyy-MM-dd");  // 입고일 (LOTNO)

            //    sql = $@"UPDATE Item_box_sub SET item_count = '" + ItemCount + "', input_date = '" + sDate + "'  WHERE box_id = '" + sBoxID + "' AND prod_id_sub = '" + sSubID + "'";

            //    m.dbCUD(sql, ref msg);

            //    if (msg != "OK")
            //    {
            //        MessageBox.Show(msg);
            //        return;
            //    }
            //}
            //MessageBox.Show($@"{@sBoxID}번 현품박스의 입고처리가 완료되었습니다.");

            //this.DialogResult = DialogResult.OK;
        }
        private void btTagPrint_Click(object sender, EventArgs e)
        {
            string reportFileName = "SmartMES_Giroei.Reports.P1B11_PURCHASE_RAW_MAT_SUB.rdlc";

            string reportParm1, reportParm2, reportParm3, reportParm4, reportParm5, reportParm6, reportParm7, reportParm8;

            DataTable table;
            string sql = string.Empty;
            string msg = string.Empty;

            MariaCRUD m = new MariaCRUD();

            sql = $@"SELECT os.order_id, os.order_seq, cust.cust_id, cust.abbname, om.project, IF(os.SMTProcessYN = 'Y','O','X'), IF(os.SusapProcessYN = 'Y','O','X'), os.qty, om.deli_date
                    FROM SAL_order_sub os JOIN SAL_order_main om ON os.order_id = om.order_id JOIN BAS_customer cust ON om.cust_id = cust.cust_id
                    WHERE os.order_id = '{@sSujuNo}' AND os.order_seq = {@sSujuSeq}";

            table = m.dbDataTable(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                MessageBox.Show(msg);
            }

            reportParm1 = table.Rows[0][0].ToString(); //수주번호
            reportParm2 = table.Rows[0][3].ToString(); //업체명
            reportParm3 = table.Rows[0][4].ToString(); //모델명
            reportParm4 = table.Rows[0][5].ToString(); //SMT여부
            reportParm5 = table.Rows[0][6].ToString(); //수삽여부
            reportParm6 = table.Rows[0][7].ToString() + " PCS"; //수량
            reportParm7 = Convert.ToDateTime(table.Rows[0][8].ToString()).ToString("yyyy-MM-dd"); //납기일자
            reportParm8 = "*" + table.Rows[0][0].ToString() + "*"; //바코드

            ViewReport_H viewReport = new ViewReport_H();
            viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
            viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
            ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
            ReportParameter rp3 = new ReportParameter("ReportParameter3", reportParm3);
            ReportParameter rp4 = new ReportParameter("ReportParameter4", reportParm4);
            ReportParameter rp5 = new ReportParameter("ReportParameter5", reportParm5);
            ReportParameter rp6 = new ReportParameter("ReportParameter6", reportParm6);
            ReportParameter rp7 = new ReportParameter("ReportParameter7", reportParm7);
            ReportParameter rp8 = new ReportParameter("ReportParameter8", reportParm8);
            viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8 });

            viewReport.ShowDialog();
        }
        #endregion

        #region Other Functions
        //
        #endregion
        #region Excel
        private void btnExcel_Click(object sender, EventArgs e) //현품박스(회수)에서 엑셀 불러오기 단순 회수량만 업데이트하는 수단으로 사용예정 회수량
        {
            MariaCRUD m = new MariaCRUD();

            DataTable table;

            string sql = string.Empty;
            string msg = string.Empty;
            string sProdIDSub = string.Empty;
            string sOrderNo = string.Empty;
            string _sProdName = sProdName;
            string _sProdID = sProdID;       // 제품품목ID
            string sProdNameSub = string.Empty;
            string sReturn_qty = string.Empty; // 반납수량

            string sFileName = string.Empty;
            OpenFileDialog ofg = new OpenFileDialog();

            //ofg.Filter = "Excel File 97~2013(*.xls)| *.xls| *.xlsx|*.xlsx| All Files(*.*)|*.*";
            ofg.Filter = "Excel File *.xls| *.xlsx| 97~2013(*.xls)|*.xlsx| All Files(*.*)|*.*"; //양식 액셀이 바로 나오게 수정

            if (ofg.ShowDialog() == DialogResult.OK)
            {
                sFileName = ofg.FileName;
                //MessageBox.Show("sFileName : " + sFileName);
            }
            else       // 1/3/23 취소 경우 
            {
                return;
            }

            try
            {

                excelApp = new Excel.Application(); // 엑셀 어플리케이션 생성 

                workBook = excelApp.Workbooks.Open(ofg.FileName); // 워크북 열기 

                workSheet = workBook.Worksheets.get_Item(1) as Excel.Worksheet; // 엑셀 첫번째 워크시트 가져오기 
                range = workSheet.UsedRange; // 사용중인 셀 범위를 가져오기

                if ((range.Cells[4, 4] as Excel.Range).Value2.ToString().Trim() != sProdName)
                {
                    if (DialogResult.OK == MessageBox.Show("해당 품목의 BOM 엑셀 파일이 아니거나,\r품목명이 일치하지 않습니다.", "엑셀 파일 확인이 필요합니다", MessageBoxButtons.OK, MessageBoxIcon.Warning))
                    {
                        return;
                    }
                    workBook.Close();
                    excelApp.Quit();
                    return;
                }

                progressBar1.Visible = true;

                int count = 0;

                for (int row = 8; row <= range.Rows.Count; row++) // 가져온 행 만큼 반복
                {
                    if ((range.Cells[row, 5] as Excel.Range).Value2 == null || string.IsNullOrEmpty((range.Cells[row, 5] as Excel.Range).Value2.ToString().Trim())) break;

                    sProdNameSub = (range.Cells[row, 5] as Excel.Range).Value2.ToString().Trim();   // 자재명
                    sReturn_qty = (range.Cells[row, 10] as Excel.Range).Value2.ToString().Trim(); //소요수량

                    sql = $@"SELECT prod_name FROM BAS_product WHERE gubun = 'M' AND prod_name = '{@sProdNameSub}' ORDER BY prod_id DESC LIMIT 1";

                    if (m.dbDataTable(sql, ref msg).Rows.Count == 0)
                    {

                    }
                    else
                    {
                        _sProdName = m.dbDataTable(sql, ref msg).Rows[0][0].ToString();

                        sql = $@"SELECT prod_id FROM BAS_product WHERE gubun = 'M' AND prod_name = '{@_sProdName}' ORDER BY prod_id DESC LIMIT 1";
                        sProdIDSub = m.dbDataTable(sql, ref msg).Rows[0][0].ToString();
                    }

                    sql = $@"SELECT prod_id, parent_id FROM BOM_bomlist WHERE prod_id = '{@_sProdID}' AND parent_id = '{@sProdIDSub}' ORDER BY prod_id";

                    sql = $@"UPDATE BOM_bomlist SET return_qty = '{@sReturn_qty}' WHERE prod_id = '{@_sProdID}' AND parent_id = '{@sProdIDSub}'";
                    m.dbCUD(sql, ref msg);

                    int ratio = (int)Math.Round((count * 100) / ((double)range.Rows.Count - 8.0));
                    progressBar1.Value = (ratio > 100) ? 100 : ratio;
                    count = count + 1;

                    sql = "update BAS_product set bomYN = 'Y', bom_dt = now() where prod_id = '" + _sProdID + "'";
                    m.dbCUD(sql, ref msg);

                }
                progressBar1.Value = 0;
                progressBar1.Visible = false;
                ListSearch();
            }
            catch (Exception e2)
            {
                return;
            }
            finally
            {
                workBook.Close(true);
                excelApp.Quit();

                ReleaseObject(workSheet);
                ReleaseObject(workBook);
                ReleaseObject(excelApp);
            }
        }
        static void ReleaseObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj); // 액셀 객체 해제 
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect(); // 가비지 수집

            }
        }
        private string getProdCode(string _gubun)
        {
            string sql = @"select UF_ProdCodeGenerator('" + _gubun + "')";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
        #endregion

    }
}
