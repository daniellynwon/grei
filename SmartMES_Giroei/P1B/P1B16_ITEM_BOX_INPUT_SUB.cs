using Microsoft.Reporting.WinForms;
using SmartFactory;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B16_ITEM_BOX_INPUT_SUB : Form
    {
        public P1B16_ITEM_BOX_INPUT parentWin;
        public string sGubun, sIsComplete, sSujuNo, sSujuSeq, sProdID, sProdName, sBoxID;

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
            //lblMsg.Text = "";
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
            if (G.Authority == "D") return;
            if (e.RowIndex < 0) return;
            if (e.RowIndex == dataGridView1.RowCount - 1) return;

            if (e.ColumnIndex == 9)     // 버튼 
            {
                P1B16_ITEM_BOX_INPUT_LOT sub = new P1B16_ITEM_BOX_INPUT_LOT();
                sub.lblProd.Text += dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                sub.lblProdNm.Text += dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                sub.lblDate.Text += DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString()).ToString("yyyy-MM-dd");
                sub.lblBarcode.Text = dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString();
                sub.parentWin = this;
                sub.ShowDialog();
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
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
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
        private void btnMaterial_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sBoxID))
            {
                MessageBox.Show("현품박스가 구성되지 않았습니다.");
                return;
            }
            if (dataGridView1.Rows.Count == 0) return;

            string sCount, sSubID;

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sCount = dataGridView1.Rows[i].Cells[13].Value.ToString().Replace(",", ""); // 투입량
                sSubID = dataGridView1.Rows[i].Cells[6].Value.ToString();   // 자재코드
                string sDate = DateTime.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString()).ToString("yyyy-MM-dd");
                string sContents = dataGridView1.Rows[i].Cells[17].Value.ToString();

                sql = $@"UPDATE Item_box_sub SET item_count = " + sCount + ", input_date = '" + sDate + "', contents = '" + sContents + "'  WHERE box_id = '" + sBoxID + "' AND prod_id_sub = '" + sSubID + "'";
                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    MessageBox.Show(msg);
                    return;
                }

                sql = "insert into INV_material_out (id, prod_id, plant, output_date, qty, box_id, enter_man) " +
                    "values(null,'" + sSubID + "','" + G.Pos + "','" + sDate + "'," + sCount + ",'" + sBoxID + "','" + G.UserID + "')" +
                    " on duplicate key update" +
                    " prod_id = '" + sSubID + "', qty = " + sCount + ", enter_man = '" + G.UserID + "'";
                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    MessageBox.Show(msg);
                    return;
                }
            }
            MessageBox.Show($@"{@sBoxID}번 현품박스의 내용이 저장되었습니다.");

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

    }
}
