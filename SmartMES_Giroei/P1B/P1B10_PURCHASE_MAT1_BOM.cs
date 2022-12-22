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
    public partial class P1B10_PURCHASE_MAT1_BOM : Form
    {
        public P1B10_PURCHASE_MAT1 parentWin;

        public string sSujuNo = string.Empty;
        public string sSujuSeq = string.Empty;
        public string sCustID = string.Empty;
        public string sProd = string.Empty;
        public string sProdName = string.Empty;
        public static int rowIndex = 0;

        public P1B10_PURCHASE_MAT1_BOM()
        {
            InitializeComponent();
        }
        private void P1B10_PURCHASE_MAT1_BOM_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            lblProd.Text = sProd;
            ListSearch();
        }
        public void ListSearch()
        {
            lblMsg.Text = "";

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                sP_PurchaseMat_BOMTableAdapter.Fill(dataSetP1B.SP_PurchaseMat_BOM, sProd, "");

                var data = dataSetP1B.SP_PurchaseRawMat_BOM;
                Logger.ApiLog(G.UserID, "P1B10_PURCHASE_MAT1_BOM", ActionType.조회, data);

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
            //else if (e.ColumnIndex == 10)         // 바코드 인쇄
            //{
            //    if (printBarcode(e.RowIndex) == false)
            //    {

            //    }
            //}
        }
        private void btnPurch_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount < 1) return;

            int iCnt = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[0].Value.ToString() == "1")
                {
                    iCnt++;
                }
            }
            if (iCnt < 1)
            {
                MessageBox.Show("발주대상이 선택되지 않았습니다.");
                return;
            }
            purchDelivery();
        }
        private void purchDelivery()
        {
            long lMoney = 0;
            int iSeq = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[0].Value.ToString() == "1")
                {
                    parentWin.sPPurchaseMatSubQueryBindingSource.AddNew();
                    parentWin.dataGridView1.Rows[iSeq].Cells[3].Value = dataGridView1.Rows[i].Cells[5].Value; //자재코드
                    parentWin.dataGridView1.Rows[iSeq].Cells[4].Value = dataGridView1.Rows[i].Cells[6].Value; //자재명
                    iSeq++;
                }
            }
            this.Dispose();
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
                lblMsg.Text = "선택된 자재가 하나도 없습니다. 바코드를 꼭 인쇄하세요.";
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

                        if (iPackQty < 1 || iQty < 1)
                        {
                            lblMsg.Text = "포장갯수와 수량을 정확히 입력해 주세요.";
                            return;
                        }
                        string barcodePrefix = sCustID + "-" + sSubProd + "-" + DateTime.Now.ToString("yyMMdd");

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

                        //sql = $@"INSERT INTO INV_material_in (mbarcode, cust_id, prod_id, plant, input_date, order_id, order_seq, qty, pack_type, pack_qty, reason_code,  enter_man) 
                        //    VALUES ('{barcodePrefix}', '{@sCustID}', '{@sSubProd}', 'A', '{@DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{@sSujuNo}', {@sSujuSeq}, {@sQty}, '{@sPackType}', {@sPackQty}, '0010', '{@G.UserID}');";

                        //m.dbCUD(sql, ref msg);

                        //if (msg != "OK")
                        //{
                        //    lblMsg.Text = msg;
                        //    MessageBox.Show(msg);
                        //    return;
                        //}

                        //var data = sql;
                        //Logger.ApiLog(G.UserID, "P1B10_PURCHASE_MAT1_BOM", ActionType.등록, data);

                        sql = $@"SELECT basestock_qty, partin_total, partout_total, current_qty FROM INV_real_stock WHERE prod_id = '{@sSubProd}' ORDER BY input_date DESC LIMIT 1";

                        table = m.dbDataTable(sql, ref msg);

                        string sNewPartInQTY = string.Empty;
                        string sNewQTY = string.Empty;

                        if (table.Rows.Count == 0)
                        {
                            sql = $@"INSERT INTO INV_real_stock(prod_id, basestock_qty, partin_total, partout_total, current_qty, update_man) 
                                VALUES('{@sSubProd}', 0, 0, 0, 0, '{@G.UserID}')";

                            m.dbCUD(sql, ref msg);

                            string data = sql;
                            Logger.ApiLog(G.UserID, "P1B10_PURCHASE_MAT1_BOM", ActionType.등록, data);

                            sql = $@"SELECT basestock_qty, partin_total, partout_total, current_qty FROM INV_real_stock WHERE prod_id = '{@sSubProd}' ORDER BY input_date DESC LIMIT 1";

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
                            Logger.ApiLog(G.UserID, "P1B10_PURCHASE_MAT1_BOM", ActionType.수정, data);
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

                            string data = sql;
                            Logger.ApiLog(G.UserID, "P1B10_PURCHASE_MAT1_BOM", ActionType.수정, data);
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

            parentWin.ListSearch1();

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

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex == -1)
            {
                e.PaintBackground(e.ClipBounds, false);

                Point pt = e.CellBounds.Location;  // where you want the bitmap in the cell

                int nChkBoxWidth = 15;
                int nChkBoxHeight = 15;
                int offsetx = (e.CellBounds.Width - nChkBoxWidth) / 2;
                int offsety = (e.CellBounds.Height - nChkBoxHeight) / 2;

                pt.X += offsetx;
                pt.Y += offsety;

                CheckBox cb = new CheckBox();
                cb.Size = new Size(nChkBoxWidth, nChkBoxHeight);
                cb.Location = pt;
                cb.CheckedChanged += new EventHandler(gvSheetListCheckBox_CheckedChanged);

                ((DataGridView)sender).Controls.Add(cb);

                e.Handled = true;
            }
        }
        private void gvSheetListCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow r in dataGridView1.Rows)
            //{
            //    r.Cells["ColumnCheckBox"].Value = ((CheckBox)sender).Checked;
            //}

            lblMsg.Text = "";

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value == null || dataGridView1.Rows[i].Cells[0].Value == "0") dataGridView1.Rows[i].Cells[0].Value = "1";
                else dataGridView1.Rows[i].Cells[0].Value = "0";
            }
        }
    }
}
