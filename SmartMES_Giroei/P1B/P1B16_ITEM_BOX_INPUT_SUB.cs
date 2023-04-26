using Microsoft.Reporting.WinForms;
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
    public partial class P1B16_ITEM_BOX_INPUT_SUB : Form
    {
        static Excel.Application excelApp = null;
        static Excel.Workbook workBook = null;
        static Excel.Worksheet workSheet = null;
        static Excel.Range range = null;

        public P1B16_ITEM_BOX_INPUT parentWin;
        public string sGubun, sIsComplete, sSujuNo, sSujuSeq, sProdID, sProdName, sBoxID, sMiSap;
        private string sCount, sSubID;

        public P1B16_ITEM_BOX_INPUT_SUB()
        {
            InitializeComponent();
        }
        private void P1B16_ITEM_BOX_INPUT_SUB_Load(object sender, EventArgs e)
        {
            if (sGubun == "구성완료")
            {
                //btnItemBox.Visible = true;
                //btnMaterial.Visible = false;

                if (sIsComplete == "완료") btnItemBox.Visible = false;
                else if (sIsComplete == "진행중") btnItemBox.Visible = true;
            }

            ListSearch();
        }
        public void ListSearch()
        {
            lblMsg.Text = "";
            lbSujuInfo.Text = $@"수주번호 : {@sSujuNo} / 수주순번 : {@sSujuSeq} / 품목명 : {@sProdName}";
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                sP_Item_Box_SubTableAdapter.Fill(dataSetP1B.SP_Item_Box_Sub, sSujuNo, Convert.ToInt32(sSujuSeq));
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            sCount = "";
            sSubID = "";

            if (G.Authority == "D") return;
            if (e.RowIndex < 0) return;
            //if (e.RowIndex == dataGridView1.RowCount - 1) return;
            string surfixA, surfixB, surfixC;
            if (e.ColumnIndex != 9 && e.ColumnIndex != 14 && e.ColumnIndex != 15 && e.ColumnIndex != 16) return;

            if (e.ColumnIndex == 9)     // 버튼 - 미삽이 "O" 이면 
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString() == "O")
                {
                    lblMsg.Text = "미삽이면 자재를 투입할 수 없습니다.";
                    return;
                }
                P1B16_ITEM_BOX_INPUT_LOT sub = new P1B16_ITEM_BOX_INPUT_LOT();
                sub.rowIndex = e.RowIndex;
                sub.lblProd.Text += dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                sub.lblProdNm.Text += dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells[8].Value == null || dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString() == "")
                    sub.lblDate.Text += "";
                else
                    sub.lblDate.Text += DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString()).ToString("yyyy-MM-dd");
                sub.lblBarcode.Text = dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString();

                if (string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString()))
                {
                    lblMsg.Text = "바코드가 없습니다.";
                    return;
                }

                string barcode = dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString();
                surfixA = barcode.Split('-')[0]; surfixB = barcode.Split('-')[1]; surfixC = barcode.Split('-')[2];

                if (dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString() == "O")   // 사급
                {
                    sub.sBarcode = surfixA + "-" + surfixB;
                }
                else if (dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString() == "X")  // 도급
                {
                    sub.sBarcode = surfixB;
                }
                //sub.sBarcode = dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString();
                sub.sProd = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                sub.parentWin = this;
                sub.ShowDialog();
            }
            else                  // 사급 14, 수삽 15, 미삽 16
            {
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "O") ? "X" : "O";
                    string sMiSap = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString(); //미삽
                    if (sMiSap == "O")
                    {
                        sMiSap = "Y";
                    }
                    else
                    {
                        sMiSap = "N";
                    }
                    sql = "update BOM_bomlist set IsMiSap = '" + sMiSap + "' where parent_id = '" + dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString() + "'"; //미삽 상태 변경 시 BOMLIST 즉시 업데이트
                    lblMsg.Text = "미삽의 상태가 변경되었습니다."; //미삽 상태 변경 시 좌측 상단 출력문구
                    m.dbCUD(sql, ref msg);
                    if (msg != "OK")
                    {
                        MessageBox.Show(msg);
                        return;
                    }
                }
            }
        }

        private void btnMaterialSave_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            sCount = "";
            sSubID = "";

            if (string.IsNullOrEmpty(sBoxID))
            {
                MessageBox.Show("현품박스가 구성되지 않았습니다.");
                return;
            }
            if (dataGridView1.Rows.Count == 0) return;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if ((dataGridView1.Rows[i].Cells[8].Value.ToString() == "" || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[8].Value.ToString())) && dataGridView1.Rows[i].Cells[16].Value.ToString() == "X")
                {
                    MessageBox.Show("LOT가 선택되지 않았습니다.");
                    return;
                }
            }  

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                try
                {
                    if (dataGridView1.Rows[i].Cells[13].Value.ToString().Replace(",", "") == "0" && dataGridView1.Rows[i].Cells[16].Value.ToString() == "X") 
                    {
                        MessageBox.Show("투입량을 확인하세요.");
                        return;
                    }
                    //else if (dataGridView1.Rows[i].Cells[16].Value.ToString() == "O")           // 미삽은 제외
                    //    continue;

                    sCount = dataGridView1.Rows[i].Cells[13].Value.ToString().Replace(",", ""); // 투입량
                    string sTotalRequireQty = dataGridView1.Rows[i].Cells[12].Value.ToString().Replace(",", ""); // 총필요수량
                    if (int.Parse(sCount) < int.Parse(sTotalRequireQty))
                    {
                        if (MessageBox.Show("총 요구수량 보다 투입량이 작습니다. 확인하세요. 그래도 투입하겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.No)
                            return;
                    }
                    sSubID = dataGridView1.Rows[i].Cells[6].Value.ToString();   // 자재코드
                    string sDate = DateTime.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString()).ToString("yyyy-MM-dd");  // 입고일(LOTNO)
                    string sContents = dataGridView1.Rows[i].Cells[17].Value.ToString();
                    string mBarcode = dataGridView1.Rows[i].Cells[18].Value.ToString();
                    string sBarcode = dataGridView1.Rows[i].Cells[19].Value.ToString();
                    string sQtys = dataGridView1.Rows[i].Cells[20].Value.ToString(); //투입량리스트
                    string[] tempSurfix = sBarcode.Split(',');
                    string[] sItemCount = sQtys.Split(',');
                    string sCust = dataGridView1.Rows[i].Cells[2].Value.ToString();

                    int index = tempSurfix.Length;

                    for (int j = 0; j < index; j++)
                    {
                        //sql = $@"UPDATE Item_box_sub SET item_count = " + sCount + ", input_date = '" + sDate + "', contents = '" + sContents + "'  WHERE box_id = '" + sBoxID + "' AND prod_id_sub = '" + sSubID + "'";
                        sql = $@"insert into Item_box_sub (box_id, prod_id, prod_id_sub, input_date, total_count, barcode_surfix, item_count, return_qty, contents) " +
                            "values(" + sBoxID + ",'" + sProdID + "','" + sSubID + "','" + sDate + "'," + sTotalRequireQty + ",'" + tempSurfix[j] + "'," + sItemCount[j] + "," + "0" + "," + "'')"
                            + " on duplicate key update" +
                            " input_date = '" + sDate + "', item_count = " + sItemCount[j] + ";";
                        m.dbCUD(sql, ref msg);

                        if (msg != "OK")
                        {
                            MessageBox.Show(msg);
                            return;
                        }
                        sql = "insert into INV_material_out (mbarcode, barcode_surfix, prod_id, cust_id, input_date, plant, prodorder_id, output_date, qty, box_id, enter_man) " +
                            "values('" + mBarcode + "','" + tempSurfix[j] + "','" + sSubID + "','" + sCust + "','" + sDate + "','" + G.Pos + "','" + sSujuNo + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + sItemCount[j] + ",'" + sBoxID + "','" + G.UserID + "')"
                            + " on duplicate key update" +
                            " input_date = '" + sDate + "', qty = " + sCount + ", enter_man = '" + G.UserID + "'";
                        m.dbCUD(sql, ref msg);

                        if (msg != "OK")
                        {
                            MessageBox.Show(msg);
                            return;
                        }
                    }
                    sql = "update INV_real_stock set current_qty = current_qty - " + sCount + ", partout_total = partout_total + " + sCount +
                            " where prod_id = '" + sSubID + "' and cust_id = '" + sCust + "'";
                    m.dbCUD(sql, ref msg);

                    if (msg != "OK")
                    {
                        MessageBox.Show(msg);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show($@"{@sBoxID}번 현품박스의 내용이 저장되었습니다.");

            this.DialogResult = DialogResult.OK;
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
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
        }
        void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }
        #endregion

        #region Button Controls
        private void btnItemBox_Click(object sender, EventArgs e)
        {
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

            sql = $@"UPDATE SAL_order_sub SET prod_status = 2 WHERE order_id = '{@sSujuNo}' AND order_seq = '{@sSujuSeq}'";

            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            lblMsg.Text = "해당 수주건의 현품박스 구성상태 변경에 성공했습니다.";

            sql = $@"UPDATE Item_box_main SET completeYN = 'Y', complete_dt = '{@DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE order_id = '{@sSujuNo}' AND order_seq = '{@sSujuSeq}'";

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
         private void btTagPrint_Click(object sender, EventArgs e)
        {
            string reportFileName = "SmartMES_Giroei.Reports.P1B11_PURCHASE_RAW_MAT_SUB.rdlc";

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

            string reportParm1 = table.Rows[0][0].ToString(); //수주번호
            string reportParm2 = table.Rows[0][3].ToString(); //업체명
            string reportParm3 = table.Rows[0][4].ToString(); //모델명
            string reportParm4 = table.Rows[0][5].ToString(); //SMT여부
            string reportParm5 = table.Rows[0][6].ToString(); //수삽여부
            string reportParm6 = table.Rows[0][7].ToString() + " PCS"; //수량
            string reportParm7 = Convert.ToDateTime(table.Rows[0][8].ToString()).ToString("yyyy-MM-dd"); //납기일자
            string reportParm8 = "*" + table.Rows[0][0].ToString() + "*"; //바코드

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
        private void btnExcel_Click(object sender, EventArgs e) //현품박스관리(투입)의 엑셀 불러오기 단순 투입양만 업데이트하는 수단으로 사용예정
        {
            MariaCRUD m = new MariaCRUD();

            DataTable table;

            string sql = string.Empty;
            string msg = string.Empty;
            string sProdIDSub = string.Empty;
            string sOrderNo = string.Empty;
            string _sProdName = sProdName;
            string _sProdID = sProdID;
            string sProdNameSub = string.Empty;
            string sItem_Count = string.Empty; // 투입수량

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
                    sItem_Count = (range.Cells[row, 9] as Excel.Range).Value2.ToString().Trim(); //투입수량

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

                        sql = $@"UPDATE BOM_bomlist SET item_count = '{@sItem_Count}' WHERE prod_id = '{@_sProdID}' AND parent_id = '{@sProdIDSub}'";
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
