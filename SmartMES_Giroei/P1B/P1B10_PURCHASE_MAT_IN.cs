using SmartFactory;
using System;
using System.Data;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using ZPLPrinterProject;

namespace SmartMES_Giroei
{
    public partial class P1B10_PURCHASE_MAT_IN : Form
    {
        public P1B10_PURCHASE_MAT parentWin;

        private int rowIndex = 0;

        public P1B10_PURCHASE_MAT_IN()
        {
            InitializeComponent();
        }
        private void P1B10_PURCHASE_MAT_IN_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            string sql = @"select co_code, co_item from BAS_common where co_kind = 'B' order by co_code";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            DataTable table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbDepot.DataSource = table;
                cbDepot.ValueMember = "co_code";
                cbDepot.DisplayMember = "co_item";
            }

            rowIndex = parentWin.dataGridView1.CurrentCell.RowIndex;

            tbNo.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            tbNo.Tag = parentWin.dataGridView1.Rows[rowIndex].Cells[18].Value;
            tbCust.Tag = parentWin.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            tbCust.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            dtpPutchDate.Value = DateTime.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString());
            dtpRequestDate.Value = DateTime.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[9].Value.ToString());
            tbProd.Tag = parentWin.dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            tbProd.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            tbUnit.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[19].Value.ToString();        // 포장단위
            tbPreInQty.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[13].Value.ToString();    // 기 입고량
            tbQty.Text = long.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[6].Value.ToString()).ToString("#,##0");
            tbDanga.Text = long.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[7].Value.ToString()).ToString("#,##0");
            lblTitle.Tag = parentWin.dataGridView1.Rows[rowIndex].Cells[11].Value.ToString();   // 입고여부

            
            lbSALOrderID.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[21].Value.ToString();      // 수주ID

            if (lblTitle.Tag.ToString() == "N")     // 신규분
            {
                tbMbarcode.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[20].Value.ToString() + "-" + parentWin.dataGridView1.Rows[rowIndex].Cells[4].Value.ToString() + "-" + DateTime.Now.ToString("yyMMdd");
                long lQty = long.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[6].Value.ToString());   // 발주량
                long lpreQty = long.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[13].Value.ToString());   // 발주량
                long lDanga = long.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[7].Value.ToString()); // 단가

                // tbInQty.Text = lQty.ToString();
                tbInQty.Text = (lQty - lpreQty).ToString("#,##0");
                tbAmount.Text = (lQty * lDanga).ToString();
                tbVat.Text = (lQty * lDanga * 0.1).ToString();
                tbMoney.Text = ((lQty * lDanga) + (lQty * lDanga * 0.1)).ToString("#,##0");

                lblDel.Visible = false;
            }
            else
            {
                try
                {
                    checkClosed.Checked = true;

                    tbInID.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[20].Value.ToString();    // 고객번호
                    dtpInDate.Value = DateTime.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[12].Value.ToString());    // 입고일
                    tbInQty.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[13].Value.ToString();   // 입고량
                    //tbAmount.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[14].Value.ToString();  // 매입액
                    cbDepot.SelectedValue = parentWin.dataGridView1.Rows[rowIndex].Cells[15].Value;
                    string LotNo = parentWin.dataGridView1.Rows[rowIndex].Cells[12].Value.ToString().Replace("-", "").Substring(2,6);
                    tbMbarcode.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[20].Value.ToString() + "-" + parentWin.dataGridView1.Rows[rowIndex].Cells[4].Value.ToString() + "-" + LotNo;
                    tbBigo.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[20].Value.ToString().Replace("'", "`");

                    //long lAmount = long.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[14].Value.ToString());
                    //tbVat.Text = (lAmount * 0.1).ToString();
                    //long lVat = long.Parse((lAmount * 0.1).ToString());
                    ////long lVat = long.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[17].Value.ToString());
                    //tbMoney.Text = (lAmount + lVat).ToString("#,##0");

                    // barcode
                    sql = "select count(barcode_surfix) as count, ifnull(sum(qty),0) as qty from INV_material_in where mbarcode = '" + tbMbarcode.Text + "'";
                    m = new MariaCRUD();
                    msg = string.Empty;
                    table = m.dbDataTable(sql, ref msg);

                    int ipackQty = 0;
                    int iQty = 0;

                    if (msg == "OK")
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            ipackQty = int.Parse(row["count"].ToString());
                            iQty = int.Parse(row["qty"].ToString());
                        }
                    }
                    tbQtyInPacking.Text = iQty.ToString();
                    btnBarcodePrint.Text = "재발행";
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "입고할 수 없습니다. ID = " + tbInID.Text;
                }
            }

            // this.ActiveControl = btnSave;
            this.ActiveControl = dtpInDate;
        }

        #region 엔터키로 포커스 이동
        public bool NextFocus(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                return true;
            }
            return false;
        }
        private void nextFocus_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = NextFocus(sender, e);
        }
        #endregion

        #region 텍스트 박스 숫자 처리
        private void tbInQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string lgsText = tbInQty.Text.Replace(",", ""); //** 숫자변환시 콤마로 발생하는 에러방지...
                tbInQty.Text = String.Format("{0:#,##0}", Convert.ToDouble(lgsText));

                tbInQty.SelectionStart = tbInQty.TextLength; //** 캐럿을 맨 뒤로 보낸다...
                tbInQty.SelectionLength = 0;

                long lQty = long.Parse(tbInQty.Text.Replace(",", "").Trim());
                long lDanga = long.Parse(tbDanga.Text.Replace(",", "").Trim());
                tbAmount.Text = (lQty * lDanga).ToString("#,##0");
                tbVat.Text = (lQty * lDanga * 0.1).ToString("#,##0");
                tbMoney.Text = ((lQty * lDanga) + (lQty * lDanga * 0.1)).ToString("#,##0");

                if (long.Parse(tbQty.Text.Replace(",","").Trim()) <= (lQty - long.Parse(tbPreInQty.Text.Replace(",", "").Trim())))                   // 발주수량 - 기존입고량  이상 입고하면
                {
                    checkClosed.Checked = true;
                }
            }
            catch (FormatException)
            {
                return;
            }
        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string lgsText = tbAmount.Text.Replace(",", ""); //** 숫자변환시 콤마로 발생하는 에러방지...
                tbAmount.Text = String.Format("{0:#,##0}", Convert.ToDouble(lgsText));

                tbAmount.SelectionStart = tbAmount.TextLength; //** 캐럿을 맨 뒤로 보낸다...
                tbAmount.SelectionLength = 0;

                long lAmount = long.Parse(tbAmount.Text.Replace(",", "").Trim());
                tbVat.Text = (lAmount * 0.1).ToString("#,##0");
                tbMoney.Text = (lAmount + (lAmount * 0.1)).ToString("#,##0");
            }
            catch (FormatException)
            {
                return;
            }
        }

        private void tbVat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string lgsText = tbVat.Text.Replace(",", ""); //** 숫자변환시 콤마로 발생하는 에러방지...
                tbVat.Text = String.Format("{0:#,##0}", Convert.ToDouble(lgsText));

                tbVat.SelectionStart = tbVat.TextLength; //** 캐럿을 맨 뒤로 보낸다...
                tbVat.SelectionLength = 0;

                long lAmount = long.Parse(tbAmount.Text.Replace(",", "").Trim());
                long lVat = long.Parse(tbVat.Text.Replace(",", "").Trim());
                tbMoney.Text = (lAmount + lVat).ToString("#,##0");
            }
            catch (FormatException)
            {
                return;
            }
        }
        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
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

            string sInQty = tbInQty.Text.Replace(",", "").Trim();
            string sAmount = tbAmount.Text.Replace(",", "").Trim();

            if (string.IsNullOrEmpty(sInQty))
            {
                lblMsg.Text = "입고수량을 입력해 주세요.";
                tbInQty.Focus();
                return;
            }
            if (string.IsNullOrEmpty(sAmount))
            {
                lblMsg.Text = "매입액을 입력해 주세요.";
                tbAmount.Focus();
                return;
            }

            string sNo = tbNo.Text; string sSeq = tbNo.Tag.ToString();
            string sCust = tbCust.Tag.ToString(); string sProd = tbProd.Tag.ToString();
            string sInDate = dtpInDate.Value.ToString("yyyy-MM-dd");
            string sDanga = tbDanga.Text.Replace(",", "").Trim();
            string mBarcode = tbMbarcode.Text.Trim();
            string packQty = tbPackQty.Text.Replace(",", "").Trim();
            //string sDepot = "0001";
            //if (string.IsNullOrEmpty(cbDepot.SelectedValue.ToString())) sDepot = "0001";
            //else sDepot = cbDepot.SelectedValue.ToString();
            string sDepot = cbDepot.SelectedValue.ToString();

            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            string sql = string.Empty;


            if (checkClosed.Checked == true)
            {
                sql = "update PUR_order_sub set closingYN = 'Y' where purchase_id = '" + sNo + "' and purchase_seq = " + sSeq;     // 입고flag update
                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }
            }
            if (lblTitle.Tag.ToString() == "N")         // 신규분만 재고 반영
            {
                //
                // Update 재고 테이블 INV_real_stock
                //
                sql = "insert into INV_real_stock (prod_id, cust_id, input_date, partin_total, partout_total, current_qty, update_man) " +
                  "values ('" + sProd + "','" + sCust + "','" + sInDate + "'," + sInQty + "," + "0" + "," + sInQty + ",'" + G.UserID + "')" +
                  " ON DUPLICATE KEY UPDATE" +
                  " partin_total = partin_total + " + sInQty +
                  ", current_qty = current_qty + " + sInQty +
                  ", update_man = '" + G.UserID + "';";
                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }
            }

            var data = sql;
            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);

            if (lblDel.Visible)
                m.TransLogCreate(G.Authority, G.UserID, "M", this.Name, lblTitle.Text, sNo + " " + sInDate);

            parentWin.ListSearch();

            for (int i = 0; i < parentWin.dataGridView1.Rows.Count - 1; i++)
            {
                if (parentWin.dataGridView1.Rows[i].Cells[0].Value.ToString() == sNo)
                {
                    parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[1, i];
                    parentWin.dataGridView1.CurrentCell.Selected = true;
                    break;
                }
            }
            this.DialogResult = DialogResult.OK;
        }
        #endregion

        private void lblDel_Click(object sender, EventArgs e)
        {
            try
            {
                string sNo = tbInID.Text;
                string mBarcode = tbMbarcode.Text.Trim();

                if (string.IsNullOrEmpty(mBarcode)) return;

                string sPurchNo = tbNo.Text; string sPurchSeq = tbNo.Tag.ToString();

                DialogResult dr = MessageBox.Show("입고번호 : " + sNo + "\r\r해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No) return;

                MariaCRUD m = new MariaCRUD();
                string sql = "DELETE FROM INV_barcode WHERE mbarcode = '" + mBarcode + "' AND (SELECT COUNT(mbarcode) FROM INV_material_out WHERE mbarcode = '" + mBarcode + "') = 0;";
                string msg = string.Empty;
                m.dbCUD(sql, ref msg);

                sql = "DELETE FROM INV_material_in WHERE mbarcode = '" + mBarcode + "' AND (SELECT COUNT(mbarcode) FROM INV_barcode WHERE mbarcode = '" + mBarcode + "') = 0;";
                m.dbCUD(sql, ref msg);

                var data = sql;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.삭제, data);

                sql = "update PUR_order_main set closingYN = 'N' where purchase_id = '" + sPurchNo + "' and purchase_seq = " + sPurchSeq;
                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    MessageBox.Show(msg);
                    return;
                }

                data = sql;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);

                m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sNo + " 입고정보");

                parentWin.ListSearch();

                for (int i = 0; i < parentWin.dataGridView1.Rows.Count - 1; i++)
                {
                    if (parentWin.dataGridView1.Rows[i].Cells[0].Value.ToString() == sNo)
                    {
                        parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[1, i];
                        parentWin.dataGridView1.CurrentCell.Selected = true;
                        break;
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (InvalidOperationException)
            {
                return;
            }
        }

        private void btnBarcodePrint_Click(object sender, EventArgs e)
        {
            printBarcode();
        }
        private void printBarcode()
        {
            string barcodePrefix = tbMbarcode.Text.Trim();

            string sQtyInPacking = tbQtyInPacking.Text.Replace(",", "").Trim();     // 포장내 수량
            string sPackQty = tbPackQty.Text.Replace(",", "").Trim();               // 포장수량
            string sQty = tbInQty.Text.Replace(",", "").Trim();                     // 입고수량
            string sCustName = tbCust.Text.Substring(0, (tbCust.Text.Length > 12) ? 12 : tbCust.Text.Length).Trim();                        // 업체명 12자리
            string sProdName = tbProd.Text.Substring(0, (tbProd.Text.Length > 12) ? 12 : tbProd.Text.Length).Trim();                        // 자재명 12자리

            if (string.IsNullOrEmpty(sQtyInPacking))
            {
                lblMsg.Text = "팩키지당 수량을  입력해 주세요.";
                tbQtyInPacking.Focus();
                return;
            }
            if (string.IsNullOrEmpty(sPackQty))
            {
                lblMsg.Text = "팩키지 수량(발행 바코드 수)을  입력해 주세요.";
                tbPackQty.Focus();
                return;
            }

            int index = int.Parse(sPackQty);

            int iQtyInPacking = int.Parse(sQtyInPacking);
            int iQty = int.Parse(sQty);

            int remain = (index * iQtyInPacking) - iQty;         // 마지막 팩키지안의 수량 

            string str = string.Empty;

            // 분할 입고 처리
            // barcode
            string sql = "select count(barcode_surfix) as count from INV_material_in where mbarcode = '" + barcodePrefix + "'";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            DataTable table = m.dbDataTable(sql, ref msg);

            int iunitQty = 0;
            if (msg == "OK")
            {
                foreach (DataRow row in table.Rows)
                {
                    iunitQty = int.Parse(row["count"].ToString());
                }
            }

            if (iunitQty > 0)
            {
                if (MessageBox.Show("해당 자재의 LotNo가 존재합니다. 추가 입고하시겠습니까?", "예/아니오", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }

            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();

            if (DialogResult.OK == pd.ShowDialog(this))
            {
                for (int i = 0; i < index; i++)
                {
                    if (remain > 0 && i == (index - 1))
                        iQtyInPacking = remain;
                    string Barcode = barcodePrefix + "-" + ((i+iunitQty) + 1).ToString("D3") + "-" + iQtyInPacking.ToString("D4");
                    string[] aBarcode = Barcode.Split('-');
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
                    str += "^FO150,50^A0,22,22^FD" + sProdName + " ^FS";
                    str += "^FO150,80^A0,22,22^FD" + aBarcode[2] + " ^FS";
                    str += "^FO150,110^A0,22,22^FD" + aBarcode[3] + "-" + aBarcode[4] + " ^FS";
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
                    save2InvMaterialIn(Barcode, barcodePrefix, iQtyInPacking, sQtyInPacking);
                }
            }
        }

        private void save2InvMaterialIn(string barcode, string barcodePrefix, int iQtyInPacking, string sQtyInPacking)
        {
            //
            // 재발행일 경우 입고처리 안함
            //
            if (btnBarcodePrint.Text == "재발행") return;

            string sCust = barcode.Split('-')[0].Trim();
            string sProd = barcode.Split('-')[1].Trim();
            string surfix = barcode.Split('-')[3] + "-" + barcode.Split('-')[4];
            string sInDate = DateTime.Now.ToString("yyyy-MM-dd");
            string sOrderId = lbSALOrderID.Text.Trim();
            string sPackType = tbUnit.Text.Trim();
            string pId = tbNo.Text;
            string pSeq = tbNo.Tag.ToString();
            string sBigo = tbBigo.Text.Trim();
            string sDepot = cbDepot.SelectedValue.ToString();

            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            string sql = "insert into INV_barcode (mbarcode, barcode_surfix, cust_id, prod_id, input_date, in_qty, rm_qty, enter_man) " +
                    "values('" + barcodePrefix + "','" + surfix + "','" + sCust + "','" + sProd + "','" + sInDate + "'," + iQtyInPacking + "," + iQtyInPacking + ",'" + G.UserID + "')";
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }
            var data = sql;
            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);


            sql = $@"INSERT INTO INV_material_in (mbarcode, barcode_surfix, cust_id, prod_id, plant, input_date, order_id, order_seq, purchase_id, purchase_seq, qty, pack_type, pack_qty, reason_code, contents,  warehouse_id, enter_man) 
                            VALUES ('{barcodePrefix}', '{surfix}', '{@sCust}', '{@sProd}', 'A', '{sInDate}', '{sOrderId}', 1, '{pId}', {pSeq}, {iQtyInPacking}, '{@sPackType}', {sQtyInPacking}, '0010','{sBigo}', '{sDepot}', '{@G.UserID}');";

            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                MessageBox.Show(msg);
                return;
            }
            data = sql;
            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);
        }

        private void tbQtyInPacking_TextChanged(object sender, EventArgs e)
        {
            int iQtyInPacking = 0;

            if (int.TryParse(tbQtyInPacking.Text.Replace(",", ""), out iQtyInPacking))
            {
                int iPackQty = int.Parse(tbInQty.Text.Replace(",", "")) / iQtyInPacking;

                int remain = int.Parse(tbInQty.Text.Replace(",", "")) % iQtyInPacking;

                if (remain != 0)
                {
                    tbPackQty.Text = (iPackQty+1).ToString();
                    lbLastQty.Text = tbPackQty.Text + "매 바코드 프린트합니다. 마지막 장은 Qty가 " + remain.ToString() + "입니다.";
                } else
                {
                    tbPackQty.Text = iPackQty.ToString();
                    lbLastQty.Text = tbPackQty.Text + "매 바코드 프린트합니다.";
                }

            }
        }

        private void checkClosed_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            if (cb.Checked == false && btnBarcodePrint.Text == "재발행")
                btnBarcodePrint.Text = "발행";
        }
    }
}
