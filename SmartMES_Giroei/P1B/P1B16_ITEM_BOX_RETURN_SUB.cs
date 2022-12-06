using Microsoft.Reporting.WinForms;
using SmartFactory;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B16_ITEM_BOX_RETURN_SUB : Form
    {
        public P1B16_ITEM_BOX_RETURN parentWin;
        public string sGubun, sIsComplete, sSujuNo, sSujuSeq, sProdID, sProdName, sBoxID;

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
                if (sQty == "0") continue;
                string sSubID = dataGridView1.Rows[i].Cells[6].Value.ToString().Replace(",", "");    // 자재코드
                string sDate = DateTime.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString()).ToString("yyyy-MM-dd");  // 입고일(LOTNO)
                string sContents = dataGridView1.Rows[i].Cells[20].Value.ToString();
                string mBarcode = dataGridView1.Rows[i].Cells[21].Value.ToString();
                string sBarcode = dataGridView1.Rows[i].Cells[9].Value.ToString();
                string sCust = dataGridView1.Rows[i].Cells[2].Value.ToString();
                sql = "UPDATE Item_box_sub SET return_Qty = " + sQty + "  WHERE box_id = '" + sBoxID + "' AND prod_id_sub = '" + sSubID + "'";
                m.dbCUD(sql, ref msg);
                
                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }
                //   INV_material_in 테이블에 다시 입력. -> 이후에 변경해야 할 듯 하다.
                sql = "insert into INV_material_in (mbarcode, barcode_surfix, cust_id, prod_id, input_date, plant, order_id, order_seq, qty, reason_code, enter_man) " +
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

    }
}
