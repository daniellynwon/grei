using System;
using System.Data;
using System.IO.Ports;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ZPLPrinterProject;

namespace SmartMES_Giroei
{
    public partial class P1B15_PURCHASE_MAT_OUT_BOM : Form
    {
        public P1B15_PURCHASE_MAT_OUT_SUB parentWin;

        public string sJobNo = string.Empty;
        public string sSujuNo = string.Empty;
        public string sSujuSeq = string.Empty;
        public string sCustID = string.Empty;
        public string sCustName = string.Empty;
        public string sProd = string.Empty;
        public string sProdName = string.Empty;

        public P1B15_PURCHASE_MAT_OUT_BOM()
        {
            InitializeComponent();
        }
        private void P1B15_PURCHASE_MAT_OUT_BOM_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            lbSujuNo.Text = "수주번호 : " + sSujuNo;
            lbProdName.Text = "품목명 : " + sProdName;

            //lblMsg.Text = $@"sSujuNo = {@sSujuNo} / sProd = {@sProd}";
            //Debug.Print("sProd : " + sProd);

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

                sP_PurchaseRawMat_OUT_BOMTableAdapter.Fill(dataSetP1B.SP_PurchaseRawMat_OUT_BOM, sSujuNo, sSearch);

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

        #region GridView Events
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 0) return;

            lblMsg.Text = "";

            dataGridView1.Rows[e.RowIndex].Cells[13].Value = string.Empty;

            //if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
            //{
            //    if (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() == "1")
            //    {
            //        dataGridView1.Rows[e.RowIndex].Cells[13].Value = string.Empty;
            //    }
            //}
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblMsg.Text = "";
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int CurrentCol = dataGridView1.CurrentCell.ColumnIndex;

            if (CurrentCol == 13)
                return;
            else
                dataGridView1.ClearSelection();
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //if (dataGridView1.RowCount < 2) return;
        }
        #endregion

        #region 저장
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void Save()
        {
            lblMsg.Text = "";

            int CheckCount = 0;

            if (dataGridView1.Rows.Count == 0)
            {
                lblMsg.Text = "출고할 자재가 없습니다.";
                return;
            }

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
            //string sPlant = "A";
            //string sProdOrderID = sJobNo;
            string sQty = string.Empty;

            MariaCRUD m = new MariaCRUD();
            string sql = string.Empty;
            string msg = string.Empty;

            DataTable table;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[0].Value.ToString() == "1")
                {
                    if (dataGridView1.Rows[i].Cells[13].Value == null || dataGridView1.Rows[i].Cells[13].Value.ToString() == string.Empty)
                    {
                        lblMsg.Text = "출고수량을 정확히 입력해 주세요.";
                        return;
                    }
                    else
                    {
                        if (Convert.ToInt64(dataGridView1.Rows[i].Cells[12].Value.ToString()) < Convert.ToInt64(dataGridView1.Rows[i].Cells[13].Value.ToString()))
                        {
                            lblMsg.Text = "출고수량을 정확히 입력해 주세요.";
                            return;
                        }

                        sSubProd = dataGridView1.Rows[i].Cells[7].Value.ToString();
                        sQty = dataGridView1.Rows[i].Cells[13].Value.ToString();

                        sql = $@"INSERT INTO INV_material_out (prod_id, plant, prodorder_id, output_date, qty, enter_man) 
                            VALUES ('{@sSubProd}', 'A', '{@sJobNo}', '{@DateTime.Now.ToString("yyyy-MM-dd")}', {@sQty}, '{@G.UserID}');";

                        m.dbCUD(sql, ref msg);

                        if (msg != "OK")
                        {
                            lblMsg.Text = "출고 처리에 실패했습니다.";
                            Debug.Print(msg);
                            Debug.Print(sql);
                            return;
                        }

                        sql = $@"SELECT basestock_qty, partin_total, partout_total, current_qty FROM INV_real_stock WHERE prod_id = '{@sSubProd}' ORDER BY id DESC LIMIT 1";

                        table = m.dbDataTable(sql, ref msg);

                        string sNewPartOutQTY = string.Empty;
                        string sNewQTY = string.Empty;

                        if (table.Rows.Count == 0)
                        {
                            sql = $@"INSERT INTO INV_real_stock(prod_id, basestock_qty, partin_total, partout_total, current_qty, update_man) 
                                VALUES('{@sSubProd}', 0, 0, 0, 0, '{@G.UserID}')";

                            m.dbCUD(sql, ref msg);

                            sql = $@"SELECT basestock_qty, partin_total, partout_total, current_qty FROM INV_real_stock WHERE prod_id = '{@sSubProd}' ORDER BY id DESC LIMIT 1";

                            table = m.dbDataTable(sql, ref msg);

                            sNewPartOutQTY = sQty;
                            sNewQTY = (-1 * Convert.ToInt64(sQty)).ToString();

                            sql = $@"UPDATE INV_real_stock SET partout_total = {@sQty}, current_qty = {@sNewQTY}, update_man = '{@G.UserID}', update_dt = '{@DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE prod_id = '{@sSubProd}'";
                            //sql = $@"INSERT INTO INV_real_stock(prod_id, basestock_qty, partin_total, partout_total, current_qty, update_man) 
                            //    VALUES('{@sSubProd}', 0, {@sQty}, 0, {@sQty}, '{@G.UserID}')";

                            m.dbCUD(sql, ref msg);

                            if (msg != "OK")
                            {
                                lblMsg.Text = "재고 조정에 실패했습니다.";
                                Debug.Print(msg);
                                Debug.Print(sql);
                                return;
                            }
                        }
                        else
                        {
                            sNewPartOutQTY = (Convert.ToInt64(table.Rows[0][2].ToString()) + Convert.ToInt64(sQty)).ToString();
                            sNewQTY = (Convert.ToInt64(table.Rows[0][3].ToString()) - Convert.ToInt64(sQty)).ToString();

                            sql = $@"UPDATE INV_real_stock SET partout_total = {@sNewPartOutQTY}, current_qty = {@sNewQTY}, update_man = '{@G.UserID}', update_dt = '{@DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE prod_id = '{@sSubProd}'";
                            //sql = $@"INSERT INTO INV_real_stock(prod_id, basestock_qty, partin_total, partout_total, current_qty, update_man) 
                            //    VALUES('{@sSubProd}', {@table.Rows[0][0].ToString()}, {@sQty}, 0, {@sNewQTY}, '{@G.UserID}')";

                            m.dbCUD(sql, ref msg);

                            if (msg != "OK")
                            {
                                lblMsg.Text = "재고 조정에 실패했습니다.";
                                Debug.Print(msg);
                                Debug.Print(sql);
                                return;
                            }
                        }

                    }
                }
            }

            parentWin.lblMsg.Text = "출고처리 되었습니다.";

            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    dataGridView1.Rows[i].Cells[0].Value = "0";
            //    dataGridView1.Rows[i].Cells[13].Value = "";
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
        #endregion

        private void btTagPrint_Click(object sender, EventArgs e)
        {
            string sSujuNo = this.sSujuNo;
            string sProdName = this.sProdName;

            printLabel(sSujuNo, sCustName, sProdName);
        }

        private void printLabel(string _sSujuNo, string _sCustName, string _sProdName)
        {
            var BarCode = $@"^XA
                        ^SEE:UHANGUL.DAT^FS
                        ^CWJ,E:KFONT3.FNT^CI26^FS
                        ^LH1,1
                        ^FX Third section with bar code. with-x-hight
                        ^BY3,2,40
                        ^FX bar code date
                        ^FO100,80^BC^FD{_sSujuNo}^FS
                        ^FX Box
                        ^FO50,240^GB700,180,3^FS
                        ^FX Line(H-Sero)
                        ^FO250,240^GB3,180,3^FS
                        ^FX Line(V-Garo)
                        ^FO50,240^GB700,3,3^FS
                        ^FO50,300^GB700,3,3^FS
                        ^FO50,360^GB700,3,3^FS
                        ^FX - CFA : Font Size
                        ^CFA,30
                        ^FO050,180 ^AJN,40,25 ^FR ^FD 공 정 현 품 표^FS
                        ^FO070,250 ^AJN,40,25 ^FR ^FD 수주번호        {_sSujuNo}^FS
                        ^FO070,310 ^AJN,40,25 ^FR ^FD 거 래 처        {_sCustName}^FS
                        ^FO070,370 ^AJN,40,25 ^FR ^FD 품 목 명        {_sProdName }^FS
                        ^XZ";

            //string BarCode = string.Empty;

            //BarCode = "^XA";
            //BarCode = BarCode + "^SEE:UHANGUL.DAT^FS";
            ////한글사용 설정 : CWJ.....
            //BarCode = BarCode + "^CWJ,E:KFONT3.FNT^CI26^FS";
            ////------------------------------------------------------------------
            //BarCode = BarCode + "\r\n^LH1,1";
            //// 바코드
            //BarCode = BarCode + "\r\n^FX Third section with bar code. with-x-hight";
            //BarCode = BarCode + "\r\n^BY3,2,40";
            //BarCode = BarCode + "\r\n^FX bar code date";
            //BarCode = BarCode + "\r\n^FO100,40^BC^FD" + _sSujuNo + "^FS";
            //// BOX-LINE
            //BarCode = BarCode + "\r\n^FX Box";
            //BarCode = BarCode + "\r\n^FO50,240^GB700,180,3^FS"; // 시작위치 
            //BarCode = BarCode + "\r\n^FX Line(H-Sero)";
            //BarCode = BarCode + "\r\n^FO250,240^GB3,180,3^FS";
            //BarCode = BarCode + "\r\n^FX Line(V-Garo)";
            //BarCode = BarCode + "\r\n^FO50,240^GB700,3,3^FS";
            //BarCode = BarCode + "\r\n^FO50,300^GB700,3,3^FS";
            //BarCode = BarCode + "\r\n^FO50,360^GB700,3,3^FS";
            //// 자료표시
            //BarCode = BarCode + "\r\n^FX - CFA : Font Size";
            //BarCode = BarCode + "\r\n^CFA,30";
            //BarCode = BarCode + "\r\n^FO070,250 ^AJN,40,25 ^FR ^FD" + " 수주번호        " + _sSujuNo + "^FS";
            //BarCode = BarCode + "\r\n^FO070,310 ^AJN,40,25 ^FR ^FD" + " 업    체        " + _sCustName + "^FS";
            //BarCode = BarCode + "\r\n^FO070,370 ^AJN,40,25 ^FR ^FD" + " 품 목 명        " + _sProdName + "^FS";
            //BarCode = BarCode + "\r\n^XZ";

            //str += "^XA^BY2,2.0^FS";
            //str += "^SEE:UHANGUL.DAT^FS";
            //str += "^CWJ,E:KFONT3.FNT^FS^CI26^FS";
            //str += "^FO30,30^FR^GB750,4,4^FS";
            //str += "^FO30,780^FR^GB750,4,4^FS";
            //str += "^FO30,30^FR^GB4,750,4^FS";
            //str += "^FO780,30^FR^GB4,750,4^FS";
            //str += "^FO350,100^FR^GB2,140,2^FS";

            //str += "^FO30,100^FR^GB750,2,2^FS";
            //str += "^FO30,170^FR^GB750,2,2^FS";
            //str += "^FO30,240^FR^GB750,2,2^FS";
            //str += "^FO200,600^BAN,100,Y,N,N ^FD " + _sSujuNo + " ^FS";

            //str += "^FO130,130 ^AJN,30,20  ^FD 수주번호: ^FS";
            //str += "^FO400,130 ^AJN,30,20  ^FD " + _sSujuNo + " ^FS";
            //str += "^FO130,190 ^AJN,30,20   ^FD 품목명^FS";
            //str += "^FO400,190 ^AJN,30,20  ^FD " + _sProdName + " ^FS";
            //str += "^XZ";

            // 임시 4*6
            //str += "^XA^BY2,2.0^FS";
            //str += "^SEE:UHANGUL.DAT^FS";
            //str += "^CWJ,E:KFONT3.FNT^FS^CI26^FS";
            //str += "^FO70,60^FR^GB750,4,4^FS";
            //str += "^FO70,500^FR^GB750,4,4^FS";
            //str += "^FO70,60^FR^GB4,470,4^FS";
            //str += "^FO780,60^FR^GB4,470,4^FS";

            //str += "^FO200,260^BAN,100,Y,N,N ^FD " + _sSujuNo + " ^FS";

            //str += "^FO210,130 ^AJN,30,20 ^FD 수주번호: ^FS";
            //str += "^FO480,130 ^AJN,30,20 ^FD " + _sSujuNo + " ^FS";

            //str += "^FO210,190 ^AJN,30,20 ^FD 품목명: ^FS";
            //str += "^FO480,190 ^AJN,30,20 ^FD " + _sProdName + " ^FS";

            //str += "^XZ";

            // 10 * 10.
            //str = "^XA^BY2,2.0^FS";
            //str += "^SEE:UHANGUL.DAT^FS";
            //str += "^CWJ,E:KFONT3.FNT^FS^CI26^FS";
            //str += "^FO30,30^FR^GB750,4,4^FS";
            //str += "^FO30,780^FR^GB750,4,4^FS";
            //str += "^FO30,30^FR^GB4,750,4^FS";
            //str += "^FO780,30^FR^GB4,750,4^FS";
            //str += "^FO350,30^FR^GB2,520,2^FS";

            //str += "^FO30,100^FR^GB750,2,2^FS";
            //str += "^FO30,170^FR^GB750,2,2^FS";
            //str += "^FO30,240^FR^GB750,2,2^FS";
            //str += "^FO30,310^FR^GB750,2,2^FS";
            //str += "^FO30,370^FR^GB750,2,2^FS";
            //str += "^FO30,550^FR^GB750,2,2^FS";
            //str += "^FO200,600^BAN,100,Y,N,N ^FD " + inid + " ^FS";

            //str += "^FO130,60 ^AJN,30,20  ^FD 품목명: ^FS";
            //str += "^FO400,60 ^AJN,30,20  ^FD " + prod + "^FS";
            //str += "^FO130,120 ^AJN,30,20  ^FD 입고일자: ^FS"; // 유효기간.
            //str += "^FO400,120 ^AJN,30,20  ^FD " + indate + " ^FS";
            //str += "^FO130,190 ^AJN,30,20  ^FD  입고량: ^FS";
            //str += "^FO400,190 ^AJN,30,20  ^FD  ^FS";
            //str += "^FO130,260 ^AJN,30,20  ^FD 입고담당: ^FS";
            //str += "^FO400,260 ^AJN,30,20  ^FD  ^FS";
            //str += "^FO130,330 ^AJN,30,20  ^FD 입고시간: ^FS";
            //str += "^FO400,330 ^AJN,30,20  ^FD  ^FS";
            //str += "^FO130,400 ^AJN,30,20  ^FD 비고:  ^FS";

            //str += "^FO800,1090 ^AJN,70,60   ^FD " + tbInTime.Text + " ^FS"; 
            //str += "^FO150,1280 ^AJN,70,60   ^FD 비고:  ^FS";     // 비고
            //str += "^FO800,1280 ^AJN,70,60   ^FD 비고: " + " ^FS";     // 
            // 이부분은 원래 주석. 

            //str += "^PQ" + nud_COUNT.Value + " ,1,1,Y^FS";      // 바코드 장수
            //str += "^XZ";

            //try
            //{
            //    Serial_Open();
            //    for (int i = 1; i <= nud_COUNT.Value; i++)
            //    {
            //        m_SP.Write(str);
            //    }
            //    Serial_Close();
            //}
            //catch (Exception ex)
            //{
            //    //
            //}

            var bytes = Encoding.Default.GetBytes(BarCode);  // 이거는 한글이 깨짐을 해결
            //var bytes = Encoding.ASCII.GetBytes(str);  // 이거는 한글이 깨짐
            // Send a printer-specific to the printer.

            try
            {

                //   RawPrinterHelper.SendBytesToPrinter(pd.PrinterSettings.PrinterName, bytes, bytes.Length);

                RawPrinterHelper.SendBytesToPrinter("ZDesigner ZT230-200dpi ZPL", bytes, bytes.Length);
                //RawPrinterHelper.SendBytesToPrinter("ZDesigner ZT230-200dpi ZPL (1 복사)", bytes, bytes.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
