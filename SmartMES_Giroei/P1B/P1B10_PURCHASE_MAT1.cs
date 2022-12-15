using Microsoft.Reporting.WinForms;
using SmartFactory;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B10_PURCHASE_MAT1 : SmartMES_Giroei.FormBasic
    {
        int columnIndex = 0;
        int rowIndex = 0;
        bool endEdit = false;

        public P1B10_PURCHASE_MAT1()
        {
            InitializeComponent();
        }
        private void P1B10_PURCHASE_MAT1_Load(object sender, EventArgs e)
        {
            ListSearch1();
            if (G.Authority == "A" || G.Authority == "B") ;
        }

        #region ListSearch
        public void ListSearch1()
        {
            lblMsg.Text = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sSearch = tbSearch.Text.Trim();

                sP_PurchaseMatMain_QueryTableAdapter.Fill(dataSetP1B.SP_PurchaseMatMain_Query, sSearch);

                var data = dataSetP1B.SP_PurchaseMatMain_Query;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

                dataGridViewList.CurrentCell = null;
                dataGridViewList.ClearSelection();
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
        public void ListSearch2(int rowIndex)
        {
            Cursor.Current = Cursors.WaitCursor;
            lblMsg.Text = "";

            cbNo.Checked = false;
            tbNo.Text = dataGridViewList.Rows[rowIndex].Cells[0].Value.ToString();
            dtpDate.Value = DateTime.Parse(dataGridViewList.Rows[rowIndex].Cells[1].Value.ToString());
            tbCust.Tag = dataGridViewList.Rows[rowIndex].Cells[2].Value.ToString();
            tbCust.Text = dataGridViewList.Rows[rowIndex].Cells[3].Value.ToString();
            dtpDeliDate.Value = DateTime.Parse(dataGridViewList.Rows[rowIndex].Cells[4].Value.ToString());
            tbContents.Text = dataGridViewList.Rows[rowIndex].Cells[6].Value.ToString();
            //tbStaff.Tag = dataGridViewList.Rows[rowIndex].Cells[9].Value.ToString();
            tbStaff.Text = dataGridViewList.Rows[rowIndex].Cells[14].Value.ToString();
            
            string sPayment = dataGridViewList.Rows[rowIndex].Cells[11].Value.ToString();
            if (sPayment == "1") cbPayment.Text = "1.현금";
            else if(sPayment == "2") cbPayment.Text = "2.어음";
            else if(sPayment == "3") cbPayment.Text = "3.상계";
            else cbPayment.Text = "4.기타";

            tbCredit.Text = dataGridViewList.Rows[rowIndex].Cells[11].Value.ToString();
            tbCredit.Text = dataGridViewList.Rows[rowIndex].Cells[11].Value.ToString();

            string qc = dataGridViewList.Rows[rowIndex].Cells[12].Value.ToString();
            if (qc == "1") cbQC.Text = "1.전수검사";
            else if (qc == "2") cbQC.Text = "2.샘플검사";
            else if (qc == "3") cbQC.Text = "3.육안검사";
            else cbQC.Text = "0.무검사";

            tbROrderNo.Text = dataGridViewList.Rows[rowIndex].Cells[13].Value.ToString();
            tbModelName.Text = dataGridViewList.Rows[rowIndex].Cells[15].Value.ToString();

            Cursor.Current = Cursors.Default;
        }
        public void ListSearch3()
        {
            lblMsg.Text = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string sNo = tbNo.Text;

                sP_PurchaseMatSub_QueryTableAdapter.Fill(dataSetP1B.SP_PurchaseMatSub_Query, sNo);

                var data = dataSetP1B.SP_PurchaseMatSub_Query;
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
        public void ListSearch4()
        {
            lblMsg.Text = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int iCnt = 0;
                long lSum = 0;
                string sMoneySum;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[3].Value != null) iCnt++;   // 품목코드가 null이 아니면,

                    if (dataGridView1.Rows[i].Cells[8].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[8].Value.ToString())) // 단가 null이면,
                        sMoneySum = "0";
                    else
                        sMoneySum = dataGridView1.Rows[i].Cells[9].Value.ToString();

                    lSum += long.Parse(sMoneySum);
                }

                lblSumMoney.Text = "합계금액 : " + lSum.ToString("#,##0") + "원";
                lblCnt.Text = iCnt.ToString() + "건";
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
        #endregion

        public void ListInit()
        {
            lblMsg.Text = "";

            cbNo.Checked = false;
            tbNo.Text = string.Empty;
            dtpDate.Value = DateTime.Today;
            tbCust.Tag = string.Empty;
            tbCust.Text = string.Empty;
            tbStaff.Text = string.Empty;
            dtpDeliDate.Value = DateTime.Today;
            tbContents.Text = string.Empty;
            tbCredit.Text = string.Empty;
            tbROrderNo.Text = string.Empty;
            tbModelName.Text = string.Empty;

            sP_PurchaseMatSub_QueryTableAdapter.Fill(dataSetP1B.SP_PurchaseMatSub_Query, "");

            var data = dataSetP1B.SP_PurchaseMatSub_Query;
            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

            lblSumMoney.Text = "합계금액 : 0원";
            lblCnt.Text = "0건";
        }

        #region Controls Event
        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListSearch1();
            }
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            if (!cbNo.Checked)
            {
                lblMsg.Text = "복사할 발주번호를 체크해 주세요.";
                return;
            }

            string sNo = tbNo.Text;

            if (string.IsNullOrEmpty(sNo))
            {
                lblMsg.Text = "저장된 발주번호만 복사할 수 있습니다.";
                return;
            }

            DialogResult dr = MessageBox.Show("발주번호 : " + sNo + "\r\r해당 발주정보를 새로운 발주번호로 복사하시겠습니까?", this.lblTitle.Text + "[발주복사]", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();
            string sNewNo = getPurchNo("GPM");

            sql = "insert into PUR_order_main (purchase_id, plant, putch_date, cust_id, request_date, contents, enter_man) " +
                  "select '" + sNewNo + "','" + G.Pos + "', CURDATE(), cust_id, CURDATE(), contents, '" + G.UserID + "' " +
                  "from PUR_order_main " +
                  "where purchase_id = '" + sNo + "'";

            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            sql = "insert into PUR_order_sub (purchase_id, purchase_seq, prod_id, add_size, putch_qty, danga, amount, vat, asap) " +
                  "select '" + sNewNo + "',  purchase_seq, prod_id, add_size, putch_qty, danga, amount, vat, asap " +
                  "from PUR_order_sub " +
                  "where purchase_id = '" + sNo + "' " +
                  "order by purchase_seq";

            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            tbSearch.Text = "";
            ListSearch1();

            for (int i = 0; i < dataGridViewList.Rows.Count; i++)
            {
                if (dataGridViewList.Rows[i].Cells[0].Value.ToString() == sNewNo)
                {
                    dataGridViewList.CurrentCell = dataGridViewList[1, i];
                    dataGridViewList.CurrentCell.Selected = true;

                    ListSearch2(i);
                    ListSearch3();
                    ListSearch4();
                    break;
                }
            }

            lblMsg.Text = "복사되었습니다.";
        }
        private void lblCust_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            CustFinder sub = new CustFinder();
            sub.FormSendEvent += new CustFinder.FormSendDataHandler(PostEventMethod);
            sub._gubun = "203"; //매출처1, 매입처2
            sub.ShowDialog();
        }
        private void PostEventMethod(object sender)
        {
            string sCust = sender.ToString();

            if (string.IsNullOrEmpty(sCust)) return;

            tbCust.Tag = sCust.Substring(0, sCust.IndexOf("#1/"));
            tbCust.Text = sCust.Substring(sCust.IndexOf("#1/") + 3, sCust.IndexOf("#2/") - (sCust.IndexOf("#1/") + 3));
            tbStaff.Text = sCust.Substring(sCust.IndexOf("#5/") + 3, sCust.IndexOf("#6/") - (sCust.IndexOf("#5/") + 3));
            tbContents.Focus();
        }
        private void btnBOM_Click(object sender, EventArgs e)
        {
            if (G.Authority == "C" || G.Authority == "D") return;
            try
            {
                if (cbProduct.Text == "" || string.IsNullOrEmpty(cbProduct.Text)) return;

                P1B10_PURCHASE_MAT1_BOM sub = new P1B10_PURCHASE_MAT1_BOM();
                sub.parentWin = this;
                sub.sProd = cbProduct.SelectedValue.ToString();
                sub.ShowDialog();
            }
            catch (Exception)
            {
                return;
            }
        }
        #endregion

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

        #region GridView Events
        private void dataGridViewList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int index = dataGridViewList.CurrentRow.Index;

            ListSearch2(index);
            ListSearch3();
            ListSearch4();
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;

                    //if (columnIndex == dataGridView1.Columns.Count - 1)
                    if (columnIndex == 9)  // 마지막 Column이면 밑으로 내려가게
                        dataGridView1.CurrentCell = dataGridView1[4, rowIndex + 1];
                    else
                        dataGridView1.CurrentCell = dataGridView1[columnIndex + 1, rowIndex];
                }
                if (e.KeyCode == Keys.Tab)
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                columnIndex = dataGridView1.CurrentCell.ColumnIndex;
                rowIndex = dataGridView1.CurrentCell.RowIndex;
                endEdit = true;

                float money1 = 0;
                float money2 = 0;
                long moneyA = 0;
                long moneyB = 0;

                if (columnIndex == 7 || columnIndex == 8 || columnIndex == 9)
                {
                    Regex regexnumber = new Regex(@"[0-9]");
                    Boolean chk = regexnumber.IsMatch(dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString());

                    if (!chk)
                    {
                        dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = 0;
                    }
                }

                if (columnIndex == 7 || columnIndex == 8)       // 발주량, 단가
                {
                    if (dataGridView1.Rows[rowIndex].Cells[7].Value != null && dataGridView1.Rows[rowIndex].Cells[7].Value.ToString().Length != 0)
                        money1 = float.Parse(dataGridView1.Rows[rowIndex].Cells[7].Value.ToString());

                    if (dataGridView1.Rows[rowIndex].Cells[8].Value != null && dataGridView1.Rows[rowIndex].Cells[8].Value.ToString().Length != 0)
                        money2 = float.Parse(dataGridView1.Rows[rowIndex].Cells[8].Value.ToString());

                    moneyA = (long)(money1 * money2);
                    dataGridView1.Rows[rowIndex].Cells[9].Value = moneyA;  // 발주액
                    //dataGridView1.Rows[rowIndex].Cells[15].Value = Math.Round(moneyA * 0.1);  // 부가세
                    //dataGridView1.Rows[rowIndex].Cells[19].Value = moneyA + Math.Round(moneyA * 0.1);  // 합계
                    ListSearch4();
                }
            }
            catch(Exception)
            {
                return;
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell != null && endEdit)
                {
                    //if (columnIndex == dataGridView1.Columns.Count - 1)
                    if (columnIndex == 9)
                        dataGridView1.CurrentCell = dataGridView1[4, rowIndex + 1];
                    else
                        dataGridView1.CurrentCell = dataGridView1[columnIndex + 1, rowIndex];

                    endEdit = false;
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblMsg.Text = "";
            if (G.Authority == "D") return;
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 0) //품목
            {
                ProdFinder pop = new ProdFinder();
                pop.cbGubun.SelectedIndex = 2;
                pop._kind = "%";
                pop._stockFlag = "%";
                pop.btnAdd.Visible = true;
                pop.FormSendEvent += new ProdFinder.FormSendDataHandler(ProdEventMethod);
                //pop.cbGubun.Enabled = false;
                pop.ShowDialog();
            }
            else if (e.ColumnIndex == 14) //"X"
            {
                try
                {
                    string sNo = tbNo.Text;

                    if (string.IsNullOrEmpty(sNo))
                    {
                        dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                        return;
                    }

                    if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()))
                    {
                        dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                        return;
                    }

                    string sSeq = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    //string sProd = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string sName = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    
                    if (dataGridView1.RowCount <= 2)
                    {
                        DialogResult dr = MessageBox.Show("품목명: " + sName + "\r해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.No) return;

                        MariaCRUD m = new MariaCRUD();
                        string sql = "delete from PUR_order_main where purchase_id = '" + sNo + "'";
                        string msg = string.Empty;
                        m.dbCUD(sql, ref msg);

                        if (msg != "OK")
                        {
                            MessageBox.Show(msg);
                            return;
                        }

                        dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                        m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sNo + " " + sName);

                        ListSearch1();
                        tbCust.Text = "";
                        tbCust.Tag = "";
                        tbStaff.Text = "";
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("품목명: " + sName + "\r해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.No) return;

                        MariaCRUD m = new MariaCRUD();
                        string sql = "delete from PUR_order_sub where purchase_id = '" + sNo + "' purchase_seq = " + sSeq;
                        string msg = string.Empty;
                        m.dbCUD(sql, ref msg);

                        if (msg != "OK")
                        {
                            MessageBox.Show(msg);
                            return;
                        }

                        dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                        m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sNo + " " + sName);
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }

            ListSearch4();
        }
        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void ProdEventMethod(object sender)
        {
            try
            {
                string sProd = sender.ToString();
                if (string.IsNullOrEmpty(sProd)) return;

                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                if (rowIndex < 0) return;

                dataGridView1.Rows[rowIndex].Cells[3].Value = sProd.Substring(0, sProd.IndexOf("#1/"));
                dataGridView1.Rows[rowIndex].Cells[4].Value = sProd.Substring(sProd.IndexOf("#1/") + 3, sProd.IndexOf("#2/") - (sProd.IndexOf("#1/") + 3));
                dataGridView1.Rows[rowIndex].Cells[5].Value = sProd.Substring(sProd.IndexOf("#3/") + 3, sProd.IndexOf("#4/") - (sProd.IndexOf("#3/") + 3)); // 규격
                dataGridView1.Rows[rowIndex].Cells[6].Value = sProd.Substring(sProd.IndexOf("#2/") + 3, sProd.IndexOf("#3/") - (sProd.IndexOf("#2/") + 3)); // 단위
                dataGridView1.CurrentCell = dataGridView1[5, rowIndex];
            }
            catch (Exception)
            {
                return;
            }
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridView1.RowCount < 2) return;

            long lCost1 = 0;
            long lCost2 = 0;
            long lAmount = 0;

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    lCost1 = Convert.ToInt64(row.Cells[7].Value);
                    lCost2 = Convert.ToInt64(row.Cells[8].Value);
                    lAmount = Convert.ToInt64(row.Cells[9].Value);

                    if ((lCost1 * lCost2) == lAmount)
                        row.Cells[9].Style.ForeColor = Color.Empty;
                    else
                        row.Cells[9].Style.ForeColor = Color.Red;
                }
                ListSearch4();
            }
            catch (Exception)
            {
                return;
            }
        }
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
                if (columnIndex == 7 || columnIndex == 8 || columnIndex == 9)
                {
                    if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '.'))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
        }
        #endregion

        #region Button Events
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch1();

            string sNo = tbNo.Text;
            if (string.IsNullOrEmpty(sNo))
            {
                ListInit();
            }
            else
            {
                for (int i = 0; i < dataGridViewList.Rows.Count; i++)
                {
                    if (dataGridViewList.Rows[i].Cells[0].Value.ToString() == sNo)
                    {
                        dataGridViewList.CurrentCell = dataGridViewList[1, i];
                        dataGridViewList.CurrentCell.Selected = true;

                        ListSearch2(i);
                        ListSearch3();
                        ListSearch4();
                        break;
                    }
                }
            }
        }
        private void pbAdd_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            ListSearch1();
            ListInit();

            P1B10_PURCHASE_MAT1_SUB sub = new P1B10_PURCHASE_MAT1_SUB();
            sub.parentWin = this;
            sub.ShowDialog();
        }
        private void pbDel_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            if (!cbNo.Checked)
            {
                lblMsg.Text = "삭제할 발주번호를 체크해 주세요.";
                return;
            }

            string sNo = tbNo.Text;
            if (string.IsNullOrEmpty(sNo))
            {
                lblMsg.Text = "저장된 발주번호만 삭제할 수 있습니다.";
                return;
            }

            DialogResult dr = MessageBox.Show("발주번호 : " + sNo + "\r\r해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No) return;

            MariaCRUD m = new MariaCRUD();
            string sql = "delete from PUR_order_main where purchase_id = '" + sNo + "'";
            string msg = string.Empty;
            m.dbCUD(sql, ref msg);

            var data = sql;
            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.삭제, data);

            // 입고테이블. 
            sql = "delete from INV_material_in where purchase_id = '" + sNo + "'";
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                MessageBox.Show(msg);
                return;
            }

            m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sNo + " " + tbCust.Text);

            data = sql;
            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.삭제, data);

            ListSearch1();
            ListInit();
            lblMsg.Text = "삭제되었습니다.";
        }
        private void pbSave_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            dataGridView1.CurrentCell = dataGridView1[4, 0];
            dataGridView1.EndEdit();
            lblMsg.Text = "";

            if (tbCust.Tag == null || string.IsNullOrEmpty(tbCust.Tag.ToString()))
            {
                lblMsg.Text = "거래처명을 선택해 주세요.";
                lblCust.Focus();
                return;
            }

            int iCnt = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {       // 품목코드
                if (!(dataGridView1.Rows[i].Cells[3].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[3].Value.ToString()))) iCnt++;
            }

            if (iCnt == 0)
            {
                lblMsg.Text = "품목정보를 확인해 주세요.";
                dataGridView1.Focus();
                return;
            }

            if(tbCredit.Text == "" || string.IsNullOrEmpty(tbCredit.Text))
            {
                lblMsg.Text = "여신기일을 입력하세요";
                return;
            }

            string sNo = tbNo.Text;
            string sPutchDate = dtpDate.Value.ToString("yyyy-MM-dd");
            string sCust = tbCust.Tag.ToString();
            string sRequestDate = dtpDeliDate.Value.ToString("yyyy-MM-dd");    // 입고요청일
            string sCont = tbContents.Text.Trim();
            string sStaff = tbStaff.Text.Trim();
            string sPayment = cbPayment.Text.Substring(0, 1);
            //sPayment = sPayment.Substring(0, 1);
            string sCredit = tbCredit.Text.Trim();
            string sQc = cbQC.Text.Substring(0, 1);
            string sROrderId = tbROrderNo.Text;

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            string sSeq = string.Empty;
            string sProdID = string.Empty;
            string sUnit = string.Empty;
            string sQty = string.Empty;
            string sDanga = string.Empty;
            string sAmount = string.Empty;
            
            if (string.IsNullOrEmpty(sNo))  //추가
            {
                sNo = getPurchNo("GPM");
                sql = "insert into PUR_order_main (purchase_id, plant, po_date, cust_id, request_date, payment_type, credit_date, qc_type, cust_man, contents, SAL_order_id, enter_man) " +
                    "values('" + sNo + "','" + G.Pos + "','" + sPutchDate + "','" + sCust + "','" + sRequestDate + "','" + sPayment + "','" + sCredit + "','" +  sQc + "','" + sStaff + "','" + sCont + "','" + sROrderId + "','" + G.UserID + "')";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    MessageBox.Show(msg);
                    return;
                }

                var data = sql;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);

                tbNo.Text = sNo;

                int seq = 0;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[3].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[3].Value.ToString())) continue;

                    seq = seq + 1;
                    sSeq = seq.ToString();
                    sProdID = dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();
                    sUnit = dataGridView1.Rows[i].Cells[26].Value.ToString().Trim();
                    sQty = dataGridView1.Rows[i].Cells[7].Value.ToString().Trim();
                    sDanga = dataGridView1.Rows[i].Cells[8].Value.ToString().Trim();
                    sAmount = dataGridView1.Rows[i].Cells[9].Value.ToString().Trim();

                    if (string.IsNullOrEmpty(sQty)) sQty = "0";
                    if (string.IsNullOrEmpty(sDanga)) sDanga = "0";
                    if (string.IsNullOrEmpty(sAmount)) sAmount = "0";

                    sql = "insert into PUR_order_sub (purchase_id, purchase_seq, prod_id, qty, unit, danga, amount) " +
                          "values('" + sNo + "'," + sSeq + ",'" + sProdID + "'," + sQty + ",'" + sUnit + "'," + sDanga + "," + sAmount + ")";
                    m.dbCUD(sql, ref msg);

                    data = sql;
                    Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);
                }
            }
            else //수정
            {
                sql = "update PUR_order_main " +
                    "set po_date = '" + sPutchDate + "', cust_id = '" + sCust + "', request_date ='" + sRequestDate + "', cust_man = '" + sStaff + "', contents = '" + sCont + "', enter_man = '" + G.UserID + "'" +
                    " where purchase_id = '" + sNo + "'";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    MessageBox.Show(msg);
                    return;
                }

                var data = sql;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[3].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[3].Value.ToString())) continue;

                    sProdID = dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();
                    sUnit = dataGridView1.Rows[i].Cells[26].Value.ToString().Trim();        // 단위 공통코드로 가져가야 됨 6-> 26(포장단위) 변경
                    sQty = dataGridView1.Rows[i].Cells[7].Value.ToString().Trim();
                    sDanga = dataGridView1.Rows[i].Cells[8].Value.ToString().Trim();
                    sAmount = dataGridView1.Rows[i].Cells[9].Value.ToString().Trim();

                    if (dataGridView1.Rows[i].Cells[2].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[2].Value.ToString()))
                        sSeq = getPurchSeq(sNo);
                    else
                        sSeq = dataGridView1.Rows[i].Cells[2].Value.ToString();

                    if (string.IsNullOrEmpty(sQty)) sQty = "0";
                    if (string.IsNullOrEmpty(sDanga)) sDanga = "0";
                    if (string.IsNullOrEmpty(sAmount)) sAmount = "0";

                    sql = "insert into PUR_order_sub (purchase_id, purchase_seq, prod_id, qty, unit, danga, amount)" +
                        " values('" + sNo + "'," + sSeq + ",'" + sProdID + "'," + sQty + ",'" + sUnit + "'," + sDanga + "," + sAmount + ")" +
                        " on duplicate key update" +
                        " prod_id = '" + sProdID + "', qty = " + sQty + ", unit = '" + sUnit + "', danga = " + sDanga + ", amount = " + sAmount;

                    m.dbCUD(sql, ref msg);

                    data = sql;
                    Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);
                }
            }
            
            tbSearch.Text = "";
            ListSearch1();

            for (int i = 0; i < dataGridViewList.Rows.Count; i++)
            {
                if (dataGridViewList.Rows[i].Cells[0].Value.ToString() == sNo)
                {
                    dataGridViewList.CurrentCell = dataGridViewList[1, i];
                    dataGridViewList.CurrentCell.Selected = true;

                    ListSearch2(i);
                    ListSearch3();
                    ListSearch4();
                    break;
                }
            }

            m.TransLogCreate(G.Authority, G.UserID, "M", this.Name, lblTitle.Text, sNo + "-" + tbCust.Text);
            ListSearch3();
            lblMsg.Text = "저장되었습니다.";
        }
        private void pbPrint_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            string sNo = tbNo.Text;

            if (string.IsNullOrEmpty(sNo))
            {
                lblMsg.Text = "저장된 발주정보만 자재발주서 출력이 가능합니다.";
                return;
            }

            String reportFileName = "SmartMES_Giroei.Reports.P1B10_PURCHASE_MAT1.rdlc";

            string sCustID = tbCust.Tag.ToString();

            sP_PurchaseMat1_QueryTableAdapter.Fill(dataSetP1B.SP_PurchaseMat1_Query, sCustID);
            sP_PurchaseMat2_QueryTableAdapter.Fill(dataSetP1B.SP_PurchaseMat2_Query, sNo);

            string reportParm1 = "발신 : ";
            string reportParm2 = "";
            string reportParm3 = "";

            reportParm1 = reportParm1 + G.UserName.ToString() + "  비고 : " + tbContents.Text.Trim();

            ViewReport_V viewReport = new ViewReport_V();
            viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
            viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
            ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
            ReportParameter rp3 = new ReportParameter("ReportParameter3", reportParm3);
            viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });

            //MariaCRUD m = new MariaCRUD();
            //string sql = $@"SELECT purchase_id FROM PUR_order_main WHERE purchase_id = '{@sNo}'";
            //string msg = string.Empty;
            //DataTable table = m.dbDataTable(sql, ref msg);

            ReportDataSource rds1 = new ReportDataSource("DataSet1",sPPurchaseMat1QueryBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds1);
            ReportDataSource rds2 = new ReportDataSource("DataSet2", sPPurchaseMatSubQueryBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds2);
            ReportDataSource rds3 = new ReportDataSource("DataSet3", sPPurchaseMat2QueryBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds3);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }
        #endregion

        #region 발주번호 생성
        private string getPurchNo(string _kind)
        {
            string sql = @"select UF_PurchaseNoGenerator('" + _kind + "')";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
        private string getPurchSeq(string sNo)
        {
            string sql = @"select UF_PurchSeqGenerator('" + sNo + "')";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
        #endregion

        #region 텍스트 박스 숫자 처리
        private void tbQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string lgsText;

                lgsText = tbCredit.Text.Replace(",", ""); //** 숫자변환시 콤마로 발생하는 에러방지...
                tbCredit.Text = String.Format("{0:#,##0}", Convert.ToDouble(lgsText));

                tbCredit.SelectionStart = tbCredit.TextLength; //** 캐럿을 맨 뒤로 보낸다...
                tbCredit.SelectionLength = 0;
            }
            catch (FormatException)
            {
                return;
            }
        }
        private void tbQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '-'))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        #endregion

        private void tbROrderNo_TextChanged(object sender, EventArgs e)
        {
            DataTable table;

            string sql = string.Empty;
            string msg = string.Empty;

            MariaCRUD m = new MariaCRUD();

            sql = $@"SELECT DISTINCT
                        os.prod_id AS 품목코드,
                        p.prod_name AS 품목명
                    FROM
                        SAL_order_sub os JOIN BAS_product p ON os.prod_id = p.prod_id
                    WHERE
                        os.order_id = '{@tbROrderNo.Text}'
                    ORDER BY os.order_seq";

            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbProduct.DataSource = table;
                cbProduct.ValueMember = "품목코드";
                cbProduct.DisplayMember = "품목명";
            }
        }
    }
}
