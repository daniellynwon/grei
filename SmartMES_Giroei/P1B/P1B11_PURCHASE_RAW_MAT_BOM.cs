using Microsoft.Reporting.WinForms;
using Excel = Microsoft.Office.Interop.Excel;
using SmartFactory;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using ZPLPrinterProject;
using System.Runtime.InteropServices;

namespace SmartMES_Giroei
{
    public partial class P1B11_PURCHASE_RAW_MAT_BOM : Form
    {
        public P1B11_PURCHASE_RAW_MAT_SUB parentWin;

        static Excel.Application excelApp = null;
        static Excel.Workbook workBook = null;
        static Excel.Worksheet workSheet = null;
        static Excel.Range range = null;

        public string sProdID;
        public string sSujuNo = string.Empty;
        public string sSujuSeq = string.Empty;
        public string sCustID = string.Empty;
        public string sCustName = string.Empty;
        public string sProd = string.Empty;
        public string sProdName = string.Empty;
        public string sOrder = string.Empty;
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

            rowIndex = parentWin.dataGridView1.CurrentCell.RowIndex;
            sOrder = parentWin.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString(); //수주번호
            sCustID = parentWin.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();     // 거래처ID
            sProd = parentWin.dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();       // 제품품목ID
            sCustName = parentWin.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();     // 거래처명

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

                sP_PurchaseRawMat_BOMTableAdapter.Fill(dataSetP1B.SP_PurchaseRawMat_BOM, sProd, sSearch, sOrder);

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
        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex < 0) return;
        //    //if (e.ColumnIndex != 0) return;

        //    lblMsg.Text = "";

        //    if (e.ColumnIndex == 1)
        //    {

        //        dataGridView1.Rows[e.RowIndex].Cells[8].Value = string.Empty;
        //        dataGridView1.Rows[e.RowIndex].Cells[9].Value = string.Empty;

        //        //if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
        //        //{
        //        //    if (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() == "1")
        //        //    {
        //        //        dataGridView1.Rows[e.RowIndex].Cells[8].Value = string.Empty;
        //        //        dataGridView1.Rows[e.RowIndex].Cells[9].Value = string.Empty;
        //        //    }
        //        //}
        //    }
        //    else if (e.ColumnIndex == 11)         // 바코드 인쇄
        //    {
        //        if (printBarcode(e.RowIndex) == false)
        //        {

        //        }
        //    }
        //}

        private bool printBarcode(int rowindex)
        {
            string sGuCode = dataGridView1.Rows[rowindex].Cells[4].Value.ToString();             // 자재구분
            string sMatCode = dataGridView1.Rows[rowindex].Cells[5].Value.ToString();             // 자재코드
            string sGuName = dataGridView1.Rows[rowindex].Cells[6].Value.ToString();             // 자재명

            string barcodePrefix = sCustID + "-" + sMatCode + "-" + DateTime.Now.ToString("yyMMdd");

            string sPackageCount = dataGridView1.Rows[rowindex].Cells[8].Value.ToString().Replace(",", "");          // 포장수량
            string sQty = dataGridView1.Rows[rowindex].Cells[9].Value.ToString().Replace(",", "");                 // 총수량

            if (string.IsNullOrEmpty(sPackageCount))
            {
                lblMsg.Text = "포장(BOX) 개수을  입력해 주세요.";
                return false;
            }
            if (string.IsNullOrEmpty(sQty))
            {
                lblMsg.Text = "총 입고수량을  입력해 주세요.";
                return false;
            }
            bool rePrint = false;
            //if (rePrint = CheckRePrint(barcodePrefix))
            //{
            //    if (MessageBox.Show("바코드를 발행하겠습니까?", "YesOrNO", MessageBoxButtons.YesNo) == DialogResult.No)
            //        return false;
            //}
            //if (rePrint = CheckRePrint(barcodePrefix))
            //{
            //    if (MessageBox.Show("이미 발행된 바코드입니다. 재 발행하겠습니까?", "YesOrNO", MessageBoxButtons.YesNo) == DialogResult.No)
            //        return false;
            //}

            int iPackageCount = int.Parse(sPackageCount);
            int iQty = int.Parse(sQty);

            int iQtyInPackage = iQty / iPackageCount;
            int remain = iQty % iPackageCount;

            int index = iPackageCount;            // Package 수

            string str = string.Empty;

            //PrintDialog pd = new PrintDialog();
            //pd.PrinterSettings = new PrinterSettings();

            //if (DialogResult.OK /*== pd.ShowDialog(this)*/)

            if (rowindex >= 0)
            {
                for (int i = 0; i < index; i++)
                {
                    if (remain > 0 && i == (index - 1))
                        iQtyInPackage = remain;
                    string Barcode = barcodePrefix + "-" + (i + 1).ToString("D3") + "-" + iQtyInPackage.ToString("D4");
                    string[] aBarcode = Barcode.Split('-');
                    save2InvBarcode(Barcode, barcodePrefix, iQtyInPackage, rowindex);
                    // 한글문제

                    str = "^XA^BY2,2.5^FS";
                    str += "^SEE:UHANGUL.DAT^FS";
                    str += "^CW1,E:KFONT3.FNT^FS^CI26^FS";
                    //str += "^FO443,70 ";

                    // str += "^FO30,80 ^B3N,N,80,Y,N ^FD" + Barcode.Trim() + " ^FS";
                    str += "^FO50,30 ^BQN,2,3^FDMA," + Barcode.Trim() + " ^FS";
                    //str += "^FO150,20^A0,22,22^FD" + aBarcode[0] + " ^FS";
                    //str += "^FO150,50^A0,22,22^FD" + aBarcode[1] + " ^FS";
                    str += "^FO150,20^A1N,22,22^FD" + sCustName + " ^FS";
                    str += "^FO150,50^A0,22,22^FD" + sGuName + " ^FS"; //자재명
                    str += "^FO150,80^A0,22,22^FD" + sGuCode + "/" + aBarcode[2] + " ^FS"; //자재구분코드/발행일자
                    str += "^FO150,110^A0,22,22^FD" + aBarcode[3] + "-" + aBarcode[4] + " ^FS";
                    str += "^XZ";

                    var bytes = Encoding.Default.GetBytes(str);

                    try {
                        //RawPrinterHelper.SendBytesToPrinter(pd.PrinterSettings.PrinterName, bytes, bytes.Length);
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                    //if (rePrint == false)
                    //    save2InvBarcode(Barcode, barcodePrefix, iQtyInPackage, rowindex);
                }
                dataGridView1.Rows[rowindex].Cells[0].Value = "1";
                return true;
            }
            else
                return false;
        }

        private bool CheckRePrint(string barcodePrefix)
        {
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            string sql = "select count(mbarcode) from INV_barcode where mbarcode = '" + barcodePrefix + "'";
            if (m.dbDataTable(sql, ref msg).Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void save2InvBarcode(string barcode, string mBarcode, int iQtyInPackage, int rowindex)
        {
            string sCust = barcode.Split('-')[0].Trim();
            string sMatCode = barcode.Split('-')[1].Trim();
            string surfix = barcode.Split('-')[3] + "-" + barcode.Split('-')[4];
            string sInDate = DateTime.Now.ToString("yyyy-MM-dd");

            int iPackQty = 0;
            int iQty = 0;

            string sSubProd = dataGridView1.Rows[rowindex].Cells[5].Value.ToString();

            string sPackType = dataGridView1.Rows[rowindex].Cells[7].Value.ToString();          // 포장단위
            string sPackQty = string.Empty;
            string sQty = string.Empty;

            bool ret = false;

            ret = int.TryParse(dataGridView1.Rows[rowindex].Cells[8].Value.ToString(), out iPackQty);
            ret = int.TryParse(dataGridView1.Rows[rowindex].Cells[9].Value.ToString(), out iQty);
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

            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            string sql = "insert into INV_barcode (mbarcode, barcode_surfix, cust_id, prod_id, input_date, in_qty, rm_qty, enter_man) " +
                    "values('" + mBarcode + "','" + surfix + "','" + sCust + "','" + sMatCode + "','" + sInDate + "'," + iQtyInPackage + "," + iQtyInPackage + ",'" + G.UserID + "')";
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                MessageBox.Show(msg);
                return;
            }

            //sql = $@"INSERT INTO INV_material_in (mbarcode, barcode_surfix, cust_id, prod_id, plant, input_date, order_id, order_seq, qty, pack_type, pack_qty, reason_code,  enter_man) 
            //                VALUES ('{mBarcode}', '{surfix}', '{@sCustID}', '{sMatCode}', 'A', '{@DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{@sSujuNo}', {@sSujuSeq}, {@sQty}, '{@sPackType}', {@sPackQty}, '0010', '{@G.UserID}');";

            //m.dbCUD(sql, ref msg);

            //if (msg != "OK")
            //{
            //    lblMsg.Text = msg;
            //    MessageBox.Show(msg);
            //    return;
            //}
            //var data = sql;
            //Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);
        }
        //private void btTagPrint_Click(object sender, EventArgs e)
        //{
        //    int rowcnt = dataGridView1.Rows.Count;

        //    for (int rowindex = 0; rowindex < rowcnt; rowindex++)
        //    {
        //        if (dataGridView1.Rows[rowindex].Cells[0].Value == null || dataGridView1.Rows[rowindex].Cells[0].Value.ToString() == "0")
        //        {
        //            printBarcode(rowindex);
        //        }
        //    }
        //}

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
                    printBarcode(i);
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

                        sql = $@"SELECT basestock_qty, partin_total, partout_total, current_qty FROM INV_real_stock WHERE prod_id = '{@sSubProd}' AND cust_id = '{@sCustID}' AND input_date = '{@DateTime.Now.ToString("yyyy-MM-dd")}' ORDER BY input_date DESC LIMIT 1";

                        table = m.dbDataTable(sql, ref msg);

                        string sNewPartInQTY = string.Empty;
                        string sNewQTY = string.Empty;

                        if (table.Rows.Count == 0)
                        {
                            sql = $@"INSERT INTO INV_real_stock(prod_id, basestock_qty, partin_total, partout_total, current_qty, update_man, cust_id, input_date) 
                                VALUES('{@sSubProd}', 0, 0, 0, 0, '{@G.UserID}' ,'{@sCustID}' , '{@DateTime.Now.ToString("yyyy-MM-dd")}')";

                            m.dbCUD(sql, ref msg);

                            string data = sql;
                            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);

                            string sBar_surfix = (i + 1).ToString("D3") + "-" + iQty.ToString("D4");

                            sql = $@"INSERT INTO INV_material_in (mbarcode, barcode_surfix, cust_id, prod_id, plant, input_date, order_id, order_seq, qty, pack_type, pack_qty, reason_code,  enter_man) 
                                VALUES ('{barcodePrefix}', '{sBar_surfix}','{@sCustID}', '{@sSubProd}', 'A', '{@DateTime.Now.ToString("yyyy-MM-dd")}', '{@sSujuNo}', {@sSujuSeq}, {@sQty}, '{@sPackType}', {@sPackQty}, '0010', '{@G.UserID}');";

                            m.dbCUD(sql, ref msg);

                            if (msg != "OK")
                            {
                                lblMsg.Text = msg;
                                MessageBox.Show(msg);
                                return;
                            }

                            sql = $@"SELECT basestock_qty, partin_total, partout_total, current_qty FROM INV_real_stock WHERE prod_id = '{@sSubProd}' ORDER BY input_date DESC LIMIT 1";

                            table = m.dbDataTable(sql, ref msg);

                            sNewPartInQTY = sQty;
                            sNewQTY = sQty;

                            sql = $@"UPDATE INV_real_stock SET partin_total = {@sQty}, current_qty = {@sQty}, update_man = '{@G.UserID}', update_dt = '{@DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE prod_id = '{@sSubProd}' AND  cust_id = '{@sCustID}'AND input_date = '{@DateTime.Now.ToString("yyyy-MM-dd")}'";
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

                            string sBar_surfix =  (i + 1).ToString("D3") + "-" + iQty.ToString("D4");

                            sql = $@"INSERT INTO INV_material_in (mbarcode, barcode_surfix, cust_id, prod_id, plant, input_date, order_id, order_seq, qty, pack_type, pack_qty, reason_code,  enter_man) 
                                VALUES ('{barcodePrefix}', '{sBar_surfix}','{@sCustID}', '{@sSubProd}', 'A', '{@DateTime.Now.ToString("yyyy-MM-dd")}', '{@sSujuNo}', {@sSujuSeq}, {@sQty}, '{@sPackType}', {@sPackQty}, '0010', '{@G.UserID}');";

                            m.dbCUD(sql, ref msg);

                            if (msg != "OK")
                            {
                                lblMsg.Text = msg;
                                MessageBox.Show(msg);
                                return;
                            }

                            sNewPartInQTY = (Convert.ToInt64(table.Rows[0][1].ToString()) + Convert.ToInt64(sQty)).ToString();
                            sNewQTY = (Convert.ToInt64(table.Rows[0][3].ToString()) + Convert.ToInt64(sQty)).ToString();

                            sql = $@"UPDATE INV_real_stock SET partin_total = {@sNewPartInQTY}, current_qty = {@sNewQTY}, update_man = '{@G.UserID}', update_dt = '{@DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE prod_id = '{@sSubProd}' AND  cust_id = '{@sCustID}'AND input_date = '{@DateTime.Now.ToString("yyyy-MM-dd")}'";
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
        #region Excel
        private void btnExcel_Click(object sender, EventArgs e) //사급자재입고등록의 팝업창에서 엑셀 불러오기 단순 소요수량만 업데이트하는 수단으로 사용예정 소요수량 * 
        {
            MariaCRUD m = new MariaCRUD();

            DataTable table;

            string sql = string.Empty;
            string msg = string.Empty;
            string sProdIDSub = string.Empty;
            string sOrderNo = string.Empty;
            string _sProdName = sProdName;
            string _sProdID = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();       // 제품품목ID
            string sProdNameSub = string.Empty;
            string sEnter_qty = string.Empty; // 소요수량

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
                    sEnter_qty = (range.Cells[row, 8] as Excel.Range).Value2.ToString().Trim(); //소요수량

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

                    sql = $@"UPDATE BOM_bomlist SET enter_qty = '{@sEnter_qty}' WHERE prod_id = '{@_sProdID}' AND parent_id = '{@sProdIDSub}'";
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
