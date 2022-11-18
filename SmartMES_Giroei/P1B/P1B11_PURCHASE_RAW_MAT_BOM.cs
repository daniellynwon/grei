using Microsoft.Reporting.WinForms;
using SmartFactory;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using ZPLPrinterProject;

namespace SmartMES_Giroei
{
    public partial class P1B11_PURCHASE_RAW_MAT_BOM : Form
    {
        public P1B11_PURCHASE_RAW_MAT_SUB parentWin;

        public string sSujuNo = string.Empty;
        public string sSujuSeq = string.Empty;
        public string sCustID = string.Empty;
        public string sProd = string.Empty;
        public string sProdName = string.Empty;
        public static int rowIndex = 0;

        public P1B11_PURCHASE_RAW_MAT_BOM()
        {
            InitializeComponent();
        }
        private void P1B11_PURCHASE_RAW_MAT_BOM_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            lbSujuNo.Text = "수주번호 : " + sSujuNo;
            lbProdName.Text = "품목명 : " + sProdName;

            //lblMsg.Text = $@"sSujuNo = {@sSujuNo} / sProd = {@sProd}";
            //Debug.Print("sProd : " + sProd);

            rowIndex = parentWin.dataGridView1.CurrentCell.RowIndex;
            sCustID = parentWin.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();     // 거래처ID
            sProd = parentWin.dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();       // 제품품목ID

            ListSearch();
            this.ActiveControl = tbSearch;
        }
        public void ListSearch()
        {
            lblMsg.Text = "";

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sSearch = tbSearch.Text.Trim();

                sP_PurchaseRawMat_BOMTableAdapter.Fill(dataSetP1B.SP_PurchaseRawMat_BOM, sProd, sSearch);

                var data = dataSetP1B.SP_PurchaseRawMat_BOM;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

                dataGridView1.CurrentCell = null;
                dataGridView1.ClearSelection();
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

        #region tbSearch
        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListSearch();
            }
        }
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void pbSearch_MouseDown(object sender, MouseEventArgs e)
        {
            pbSearch.Location = new Point(pbSearch.Location.X + 1, pbSearch.Location.Y + 1);
        }
        private void pbSearch_MouseUp(object sender, MouseEventArgs e)
        {
            pbSearch.Location = new Point(pbSearch.Location.X - 1, pbSearch.Location.Y - 1);
        }
        #endregion

        #region dataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblMsg.Text = "";
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            //if (e.ColumnIndex != 0) return;

            lblMsg.Text = "";

            if (e.ColumnIndex == 1)
            {

                dataGridView1.Rows[e.RowIndex].Cells[8].Value = string.Empty;
                dataGridView1.Rows[e.RowIndex].Cells[9].Value = string.Empty;

                //if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
                //{
                //    if (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() == "1")
                //    {
                //        dataGridView1.Rows[e.RowIndex].Cells[8].Value = string.Empty;
                //        dataGridView1.Rows[e.RowIndex].Cells[9].Value = string.Empty;
                //    }
                //}
            }
            else if (e.ColumnIndex == 10)         // 바코드 인쇄
            {
                string sMatCode = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();             // 자재코드

                string barcodePrefix = sCustID + "-" + sMatCode + "-" + DateTime.Now.ToString("yyMMdd"); ;

                string sQtyInPackage = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString().Replace(",", "");          // 수량/포장
                string sQty = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString().Replace(",", "");                 // 수량

                if (string.IsNullOrEmpty(sQtyInPackage))
                {
                    lblMsg.Text = "팩키지 수량을  입력해 주세요.";
                    return;
                }
                if (string.IsNullOrEmpty(sQty))
                {
                    lblMsg.Text = "총 입고수량을  입력해 주세요.";
                    return;
                }

                int iQtyInPackage = int.Parse(sQtyInPackage);
                int iQty = int.Parse(sQty);

                int iQtyPack = iQty / iQtyInPackage;
                int remain = iQty % iQtyInPackage;

                int index = (remain == 0) ? iQtyPack : iQtyPack + 1;            // Package 수

                string str = string.Empty;

                PrintDialog pd = new PrintDialog();
                pd.PrinterSettings = new PrinterSettings();

                if (DialogResult.OK == pd.ShowDialog(this))
                {
                    for (int i = 0; i < index; i++)
                    {
                        string Barcode = barcodePrefix + "-" + (i + 1).ToString("D3") + "-" + int.Parse(sQtyInPackage).ToString("D4");

                        str = "^XA^BY2,2.0^FS";
                        str += "^FO30,80 ^B3N,N,80,Y,N ^FD" + Barcode.Trim() + " ^FS";
                        str += "^XZ";
                        var bytes = Encoding.Default.GetBytes(str);

                        try
                        {
                            RawPrinterHelper.SendBytesToPrinter(pd.PrinterSettings.PrinterName, bytes, bytes.Length);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ////if (dataGridView1.RowCount < 2) return;

            //dataGridView1.Columns[1].ReadOnly = true;
            //dataGridView1.Columns[4].ReadOnly = true;
            //dataGridView1.Columns[5].ReadOnly = true;
            //dataGridView1.Columns[6].ReadOnly = true;
            //dataGridView1.Columns[7].ReadOnly = true;

            ////dataGridView1.ReadOnly = true;
            ////dataGridView1.Columns[8].ReadOnly = false;
            ////dataGridView1.Columns[9].ReadOnly = false;
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int CurrentCol = dataGridView1.CurrentCell.ColumnIndex;

            if (CurrentCol == 8 || CurrentCol == 9)
                return;
            else
                dataGridView1.ClearSelection();
        }
        #endregion

        #region Button Events
        private void btAllCheck_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value == null || dataGridView1.Rows[i].Cells[0].Value == "0") dataGridView1.Rows[i].Cells[0].Value = "1";
                else dataGridView1.Rows[i].Cells[0].Value = "0";
            }
        }
        private void btTagPrint_Click(object sender, EventArgs e)
        {
            string reportFileName = "SmartMES_Giroei.Reports.P1B11_PURCHASE_RAW_MAT_SUB.rdlc";

            string reportParm1 = string.Empty; //수주번호
            string reportParm2 = string.Empty; //업체명
            string reportParm3 = string.Empty; //모델명
            string reportParm4 = string.Empty; //SMT여부
            string reportParm5 = string.Empty; //수삽여부
            string reportParm6 = string.Empty; //수량
            string reportParm7 = string.Empty; //납기일자
            string reportParm8 = string.Empty; //바코드

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

            //ReportDataSource rds = new ReportDataSource("DataSet1", sPPurchaseRawMatINBindingSource);
            //viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            //viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            lblMsg.Text = "";

            int CheckCount = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[0].Value.ToString() == "1")
                {
                    CheckCount++;
                }
            }

            if (CheckCount == 0)
            {
                lblMsg.Text = "선택된 자재가 하나도 없습니다.";
                return;
            }

            string sSubProd = string.Empty;

            string sPackType = string.Empty;
            string sPackQty = string.Empty;
            string sQty = string.Empty;

            MariaCRUD m = new MariaCRUD();
            string sql = string.Empty;
            string msg = string.Empty;
            int iPackQty = 0, iQty = 0;
            bool ret = false;

            DataTable table;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[0].Value.ToString() == "1")
                {
                    if (dataGridView1.Rows[i].Cells[8].Value == null || dataGridView1.Rows[i].Cells[9].Value == null)
                    {
                        lblMsg.Text = "포장갯수와 수량을 정확히 입력해 주세요.";
                        return;
                    }
                    else
                    {
                        sSubProd = dataGridView1.Rows[i].Cells[5].Value.ToString();

                        sPackType = dataGridView1.Rows[i].Cells[7].Value.ToString();
                        ret = int.TryParse(dataGridView1.Rows[i].Cells[8].Value.ToString(), out iPackQty);
                        ret = int.TryParse(dataGridView1.Rows[i].Cells[9].Value.ToString(), out iQty);

                        if (ret)
                        {
                            sPackQty = iPackQty.ToString();
                            sQty = iQty.ToString();
                        }
                        else
                        {
                            lblMsg.Text = "포장갯수와 수량을 정확히 입력해 주세요.";
                            return;
                        }

                        sql = $@"INSERT INTO INV_material_in (cust_id, prod_id, plant, input_date, order_id, order_seq, qty, pack_type, pack_qty, enter_man) 
                            VALUES ('{@sCustID}', '{@sSubProd}', 'A', '{@DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{@sSujuNo}', {@sSujuSeq}, {@sQty}, '{@sPackType}', {@sPackQty}, '{@G.UserID}');";

                        m.dbCUD(sql, ref msg);

                        if (msg != "OK")
                        {
                            lblMsg.Text = msg;
                            MessageBox.Show(msg);
                            return;
                        }

                        var data = sql;
                        Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);

                        sql = $@"SELECT basestock_qty, partin_total, partout_total, current_qty FROM INV_real_stock WHERE prod_id = '{@sSubProd}' ORDER BY id DESC LIMIT 1";

                        table = m.dbDataTable(sql, ref msg);

                        string sNewPartInQTY = string.Empty;
                        string sNewQTY = string.Empty;

                        if (table.Rows.Count == 0)
                        {
                            sql = $@"INSERT INTO INV_real_stock(prod_id, basestock_qty, partin_total, partout_total, current_qty, update_man) 
                                VALUES('{@sSubProd}', 0, 0, 0, 0, '{@G.UserID}')";

                            m.dbCUD(sql, ref msg);

                            data = sql;
                            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);

                            sql = $@"SELECT basestock_qty, partin_total, partout_total, current_qty FROM INV_real_stock WHERE prod_id = '{@sSubProd}' ORDER BY id DESC LIMIT 1";

                            table = m.dbDataTable(sql, ref msg);

                            sNewPartInQTY = sQty;
                            sNewQTY = sQty;

                            sql = $@"UPDATE INV_real_stock SET partin_total = {@sQty}, current_qty = {@sQty}, update_man = '{@G.UserID}', update_dt = '{@DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE prod_id = '{@sSubProd}'";
                            //sql = $@"INSERT INTO INV_real_stock(prod_id, basestock_qty, partin_total, partout_total, current_qty, update_man) 
                            //    VALUES('{@sSubProd}', 0, {@sQty}, 0, {@sQty}, '{@G.UserID}')";

                            m.dbCUD(sql, ref msg);

                            if (msg != "OK")
                            {
                                lblMsg.Text = msg;
                                MessageBox.Show(msg);
                                return;
                            }

                            data = sql;
                            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);
                        }
                        else
                        {
                            sNewPartInQTY = (Convert.ToInt64(table.Rows[0][1].ToString()) + Convert.ToInt64(sQty)).ToString();
                            sNewQTY = (Convert.ToInt64(table.Rows[0][3].ToString()) + Convert.ToInt64(sQty)).ToString();

                            sql = $@"UPDATE INV_real_stock SET partin_total = {@sNewPartInQTY}, current_qty = {@sNewQTY}, update_man = '{@G.UserID}', update_dt = '{@DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE prod_id = '{@sSubProd}'";
                            //sql = $@"INSERT INTO INV_real_stock(prod_id, basestock_qty, partin_total, partout_total, current_qty, update_man) 
                            //    VALUES('{@sSubProd}', {@table.Rows[0][0].ToString()}, {@sQty}, 0, {@sNewQTY}, '{@G.UserID}')";

                            m.dbCUD(sql, ref msg);

                            if (msg != "OK")
                            {
                                lblMsg.Text = msg;
                                MessageBox.Show(msg);
                                return;
                            }

                            data = sql;
                            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);
                        }

                    }
                }
            }

            parentWin.lblMsg.Text = "입고처리 되었습니다.";

            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    dataGridView1.Rows[i].Cells[0].Value = "0";
            //    dataGridView1.Rows[i].Cells[8].Value = "";
            //    dataGridView1.Rows[i].Cells[9].Value = "";
            //}

            parentWin.parentWin.ListSearch();

            this.DialogResult = DialogResult.Cancel;

            //string sDate = dtpDate.Value.ToString("yyyy-MM-dd");
            //string sProd = tbProd.Tag.ToString();
            //string sProdLine = cbWorkLine.SelectedValue.ToString();
            //string sMan = cbMan.SelectedValue.ToString();
            //string sJobNo = getCode();
            //string sRework = "A";
            //if (rbB.Checked) sRework = "B";
            //string sSolder = tbSolder.Text.Trim();
            //string sMask = tbMask.Text.Trim();
            //string sNum = tbNum.Text.Trim();
            //if (string.IsNullOrEmpty(tbNum.Text.Trim())) sNum = "0";
            //string sConts = tbContents.Text.Trim();
            //string sJobTimeA = ""; string sJobTimeB = "";

            //if (string.IsNullOrEmpty(rorderSeq)) rorderSeq = "null";
            //else
            //{
            //    //string sqlQty = "select qty from vw_rorder where rorder_id = '" + rorderID + "' and rorder_seq = " + rorderSeq;
            //    //MariaCRUD mQty = new MariaCRUD();
            //    //string msgQty = string.Empty;
            //    //string com = mQty.dbRonlyOne(sqlQty, ref msgQty).ToString();

            //    //if (msgQty == "OK") sSujuQty = com;
            //}
            //string sql = "insert into PRD_prod_order (job_no, prod_id, order_id, order_seq, job_type, plant, work_line, lot_date, order_qty, solder_type, mmask_id, " +
            //                                    "job_start_time, job_end_time, num_workers, job_comment, work_man_id, enter_man) " +
            //    "values('" + sJobNo + "','" + sProd + "','" + rorderID + "'," + rorderSeq + ",'" + sRework + "','" + G.Pos + "','" + sProdLine + "','" + sDate + "'," + sQty + ",'"
            //    + sSolder + "','" + sMask + "','" + sJobTimeA + "','" + sJobTimeB + "'," + sNum + ",'" + sConts + "','" + sMan + "','" + G.UserID + "')";

            //MariaCRUD m = new MariaCRUD();
            //string msg = string.Empty;
            //m.dbCUD(sql, ref msg);

            //if (msg != "OK")
            //{
            //    lblMsg.Text = msg;
            //    return;
            //}

            //sql = "update SAL_order_sub set prod_status = 3 where order_id ='" + rorderID + "' and order_seq =" + rorderSeq;
            //m.dbCUD(sql, ref msg);
            //if (msg != "OK")
            //{
            //    lblMsg.Text = msg;
            //    return;
            //}

            ////QRCodeCreate(rorderID, rorderSeq);
            ////QRImageSave(rorderID + rorderSeq);

            //lblMsg.Text = "저장되었습니다.";

            //parentWin.ListSearch();

            //for (int i = 0; i < parentWin.dataGridView1.Rows.Count; i++)
            //{
            //    if (parentWin.dataGridView1.Rows[i].Cells[1].Value.ToString() == sJobNo)
            //    {
            //        parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[0, i];
            //        parentWin.dataGridView1.CurrentCell.Selected = true;
            //        break;
            //    }
            //}

            //tbJobNo.Text = getCode();
            //dtpStartTime.Text = string.Empty;
            //dtpDoneTime.Text = string.Empty;
            //tbProd.Tag = null;
            //tbProd.Text = string.Empty;
            //tbCust.Text = string.Empty;
            //tbSolder.Text = string.Empty;
            //tbMask.Text = string.Empty;
            //tbNum.Text = string.Empty;
            //tbQty.Text = string.Empty;
            //tbContents.Text = string.Empty;
            //tbQty.Text = string.Empty;
            //cbWorkLine.SelectedIndex = 0;
            //cbMan.SelectedIndex = 0;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion
    }
}
