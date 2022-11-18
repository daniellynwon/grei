using Microsoft.Reporting.WinForms;
using SmartFactory;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B01_ESTIMATE : SmartMES_Giroei.FormBasic
    {
        int columnIndex = 0;
        int rowIndex = 0;
        bool endEdit = false;
        string estTerm = "견적 유효일자 5일";

        public P1B01_ESTIMATE()
        {
            InitializeComponent();
        }
        private async void P1B01_ESTIMATE_Load(object sender, EventArgs e)
        {
            sP_Z_Common_IDTableAdapter.Fill(dataSetP1B.SP_Z_Common_ID, "P");

            var data = dataSetP1B.SP_Z_Common_ID;
            var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

            tbEstiContents.Text = estTerm;
            ListSearch1();
        }

        #region ListSearch
        public async void ListSearch1()
        {
            lblMsg.Text = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sSearch = tbSearch.Text.Trim();

                sP_EstimateMain_QueryTableAdapter.Fill(dataSetP1B.SP_EstimateMain_Query, sSearch);

                var data = dataSetP1B.SP_EstimateMain_Query;
                var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

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
            dtpDate.Value = DateTime.Parse(dataGridViewList.Rows[rowIndex].Cells[2].Value.ToString());
            tbCustName.Tag = dataGridViewList.Rows[rowIndex].Cells[3].Value;
            tbCustName.Text = dataGridViewList.Rows[rowIndex].Cells[4].Value.ToString();
            tbProject.Text = dataGridViewList.Rows[rowIndex].Cells[5].Value.ToString();
            tbCustMan.Text = dataGridViewList.Rows[rowIndex].Cells[6].Value.ToString();
            tbManHp.Text = dataGridViewList.Rows[rowIndex].Cells[7].Value.ToString();
            tbAddress.Text = dataGridViewList.Rows[rowIndex].Cells[8].Value.ToString();
            cbCurrency.Text = dataGridViewList.Rows[rowIndex].Cells[10].Value.ToString();
            tbEstiContents.Text = dataGridViewList.Rows[rowIndex].Cells[13].Value.ToString();
            tbEmail.Text = dataGridViewList.Rows[rowIndex].Cells[16].Value.ToString();
            //cbRorderFlag.Checked = false;
            //if (dataGridViewList.Rows[rowIndex].Cells[14].Value.ToString() == "Y") cbRorderFlag.Checked = true;
            tbRorder.Text = dataGridViewList.Rows[rowIndex].Cells[17].Value.ToString();

            Cursor.Current = Cursors.Default;
        }
        public async void ListSearch3()
        {
            lblMsg.Text = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                dataGridView1.DataSource = sPEstimateSubQueryBindingSource;

                string sNo = tbNo.Text;

                sP_EstimateSub_QueryTableAdapter.Fill(dataSetP1B.SP_EstimateSub_Query, sNo);

                var data = dataSetP1B.SP_EstimateSub_Query;
                var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

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
                string sMoney;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[2].Value != null) iCnt++;

                    if (dataGridView1.Rows[i].Cells[14].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[14].Value.ToString()))
                        sMoney = "0";
                    else
                        sMoney = dataGridView1.Rows[i].Cells[14].Value.ToString();

                    lSum += long.Parse(sMoney);
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

        public async void ListInit()
        {
            lblMsg.Text = "";

            cbNo.Checked = false;
            tbNo.Text = string.Empty;
            dtpDate.Value = DateTime.Today;
            tbCustName.Text = string.Empty;
            tbProject.Text = string.Empty;
            tbAddress.Text = string.Empty;
            tbCustMan.Text = string.Empty;
            tbManHp.Text = string.Empty;
            cbCurrency.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbEstiContents.Text = estTerm;
            //cbRorderFlag.Checked = false;
            tbRorder.Text = string.Empty;

            sP_EstimateSub_QueryTableAdapter.Fill(dataSetP1B.SP_EstimateSub_Query, "");

            var data = dataSetP1B.SP_EstimateSub_Query;
            var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

            lblSumMoney.Text = "합계금액 : 0원";
            lblCnt.Text = "0건";
        }
        private void CustEventMethod(object sender)
        {
            string sCust = sender.ToString();

            if (string.IsNullOrEmpty(sCust)) return;

            tbCustName.Tag = sCust.Substring(0, sCust.IndexOf("#1/"));
            tbCustName.Text = sCust.Substring(sCust.IndexOf("#1/") + 3, sCust.IndexOf("#2/") - (sCust.IndexOf("#1/") + 3));
            tbAddress.Text = sCust.Substring(sCust.IndexOf("#3/") + 3, sCust.IndexOf("#4/") - (sCust.IndexOf("#3/") + 3));
            tbEmail.Text = sCust.Substring(sCust.IndexOf("#4/") + 3, sCust.IndexOf("#5/") - (sCust.IndexOf("#4/") + 3));
            tbCustMan.Text = sCust.Substring(sCust.IndexOf("#5/") + 3, sCust.IndexOf("#6/") - (sCust.IndexOf("#5/") + 3));
            tbManHp.Text = sCust.Substring(sCust.IndexOf("#6/") + 3, sCust.Length - (sCust.IndexOf("#6/") + 3));
            tbAddress.Focus();
        }

        #region Controls Event
        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListSearch1();
            }
        }
        private void btnCopy_Click(object sender, EventArgs e)  // 추후 수정 7/8
        {
            if (G.Authority == "D") return;

            if (!cbNo.Checked)
            {
                lblMsg.Text = "복사할 견적번호를 체크해 주세요.";
                return;
            }

            string sNo = tbNo.Text;

            if (string.IsNullOrEmpty(sNo))
            {
                lblMsg.Text = "저장된 견적번호만 복사할 수 있습니다.";
                return;
            }

            DialogResult dr = MessageBox.Show("견적번호 : " + sNo + "\r\r해당 견적정보를 새로운 견적번호로 복사하시겠습니까?", this.lblTitle.Text + "[견적복사]", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();
            string sNewNo = getEstimateNo();

            sql = "insert into SAL_estimate_main (estimate_id, plant, esti_date, cust_id, project, cust_man, cust_contact, warehouse, currency, enter_man) " +
                  "select '" + sNewNo + "','" + G.Pos + "', CURDATE(), cust_id, project, cust_man, cust_contact, warehouse, currency, '" + G.UserID + "' " +
                  "from SAL_estimate_main " +
                  "where estimate_id = '" + sNo + "'";

            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            sql = "insert into SAL_estimate_sub (estimate_id, estimate_seq, prod_id, process_code, work_period, manmonth, mat_count, qty, danga_std, danga_proposal, amount, vat, bigo) " +
                  "select '" + sNewNo + "', estimate_seq, prod_id, process_code, work_period, manmonth, mat_count, qty, danga_std, danga_proposal, amount, vat, bigo " +
                  "from SAL_estimate_sub " +
                  "where estimate_id = '" + sNo + "' " +
                  "order by estimate_seq";

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
                    dataGridViewList.CurrentCell = dataGridViewList[2, i];
                    dataGridViewList.CurrentCell.Selected = true;

                    ListSearch2(i);
                    ListSearch3();
                    ListSearch4();
                    break;
                }
            }

            lblMsg.Text = "복사되었습니다.";
        }
        private void lblROrder_Click(object sender, EventArgs e)
        {
            ListSearch1();
            ListInit();

            P1B01_ESTIMATE_SUB sub = new P1B01_ESTIMATE_SUB();
            sub.parentWin = this;
            sub.ShowDialog();
        }
        private void tbRorder_TextChanged(object sender, EventArgs e)
        {

        }
        private void lblCust_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            CustFinder sub = new CustFinder();
            sub.FormSendEvent += new CustFinder.FormSendDataHandler(CustEventMethod);
            sub._gubun = "103";
            sub.ShowDialog();
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

        #region 주소
        private void lblAddress_Click(object sender, EventArgs e)
        {
            //if (G.Authority == "D") return;

            //PostAddr post = new PostAddr();
            //post.FormSendEvent += new PostAddr.FormSendDataHandler(PostEventMethod);
            //post.ShowDialog();
        }
        private void PostEventMethod(object sender)
        {
            string sAddr = sender.ToString();

            if (string.IsNullOrEmpty(sAddr)) return;

            tbAddress.Text = sAddr;
            tbAddress.Focus();
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
                    if (columnIndex == 15)
                        dataGridView1.CurrentCell = dataGridView1[4, rowIndex + 1];
                    else
                        dataGridView1.CurrentCell = dataGridView1[columnIndex + 1, rowIndex];
                }
                if (e.KeyCode == Keys.Tab)
                {
                    e.Handled = true;
                }
            }
            //catch (ArgumentOutOfRangeException)
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

                int money1 = 0;
                int money2 = 0;
                int money3 = 0;

                if (columnIndex == 11 || columnIndex == 13) // 수량, 제안단가
                {
                    if (dataGridView1.Rows[rowIndex].Cells[11].Value != null && dataGridView1.Rows[rowIndex].Cells[11].Value.ToString().Length != 0)
                        money1 = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[11].Value.ToString());

                    if (dataGridView1.Rows[rowIndex].Cells[13].Value != null && dataGridView1.Rows[rowIndex].Cells[13].Value.ToString().Length != 0)
                        money2 = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[13].Value.ToString());

                    dataGridView1.Rows[rowIndex].Cells[14].Value = money1 * money2;
                    ListSearch4();
                }

                if (columnIndex == 4)       // 품목명
                {
                    if (!checkProdName(dataGridView1.Rows[rowIndex].Cells[4].Value.ToString()))
                    {
                        ProdFinder pop = new ProdFinder();
                        pop.cbGubun.SelectedIndex = 1;
                        pop._kind = "%";
                        pop._stockFlag = "%";
                        pop.btnAdd.Visible = true;
                        pop._prodName = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
                        pop.FormSendEvent += new ProdFinder.FormSendDataHandler(ProdEventMethod);
                        pop.cbGubun.Enabled = false;
                        pop.ShowDialog();
                    } else
                    {

                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private bool checkProdName(string prodName)
        {
            DataTable table;

            string sql = string.Empty;
            string msg = string.Empty;

            MariaCRUD m = new MariaCRUD();

            sql = @"select count(prod_id), prod_id, prod_name, prod_type, prod_size, layers, mount_pins, metalmasks, stock_money, proc_std, (SELECT c.co_item FROM BAS_common c WHERE c.co_kind = IF(p.gubun = 'M', 'C', 'P') AND c.co_code = p.prod_kind) AS proc_name from BAS_product p where prod_name like '"
                        + prodName + "' and useYN = 'Y'";

            table = m.dbDataTable(sql, ref msg);
            DataRow[] row; 

            if (msg == "OK")
            {
                row = table.Select("prod_name='" + prodName +"'");
                if (row.Length.Equals(0)) return false;
                // if (!row[0][0].Equals(1)) return false;
                dataGridView1.Rows[rowIndex].Cells[2].Value = row[0][1].ToString();
                dataGridView1.Rows[rowIndex].Cells[4].Value = row[0][2].ToString();     //품목명
                dataGridView1.Rows[rowIndex].Cells[7].Value = row[0][6].ToString();     //점수
                dataGridView1.Rows[rowIndex].Cells[8].Value = row[0][5].ToString();     //층수
                dataGridView1.Rows[rowIndex].Cells[9].Value = row[0][7].ToString();    //MM
                dataGridView1.Rows[rowIndex].Cells[12].Value = row[0][8].ToString();    //기준단가
                dataGridView1.Rows[rowIndex].Cells[5].Value = row[0][9].ToString();     //공정코드
                //dataGridView1.Rows[rowIndex].Cells[6].Value = row[0][10].ToString();    //공정명
                return true;
            } else
            {
                return false;
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell != null && endEdit)
                {
                    //if (columnIndex == dataGridView1.Columns.Count - 1)
                    if (columnIndex == 15)
                        dataGridView1.CurrentCell = dataGridView1[4, rowIndex + 1];
                    else
                        dataGridView1.CurrentCell = dataGridView1[columnIndex + 1, rowIndex];

                    endEdit = false;
                }
            }
            //catch (ArgumentOutOfRangeException)
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

            if (e.ColumnIndex == 3)
            {
                ProdFinder pop = new ProdFinder();
                pop.cbGubun.SelectedIndex = 1;
                pop._kind = "%";
                pop._stockFlag = "%";
                pop.btnAdd.Visible = true;
                pop.FormSendEvent += new ProdFinder.FormSendDataHandler(ProdEventMethod);
                pop.cbGubun.Enabled = false;
                pop.ShowDialog();

            }
            else if (e.ColumnIndex == 17) // X
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

                    string sSeq = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                    DialogResult dr = MessageBox.Show("해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.No) return;

                    MariaCRUD m = new MariaCRUD();
                    string sql = "delete from SAL_estimate_sub where estimate_id = '" + sNo + "' and estimate_seq = " + sSeq;
                    string msg = string.Empty;
                    m.dbCUD(sql, ref msg);

                    if (msg != "OK")
                    {
                        MessageBox.Show(msg);
                        return;
                    }

                    dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                    m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sNo + " " + sSeq);
                }
                //catch (InvalidOperationException)
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
                else Debug.Print("sProd : " + sProd);

                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                if (rowIndex < 0) return;

                dataGridView1.Rows[rowIndex].Cells[2].Value = sProd.Substring(0, sProd.IndexOf("#1/"));
                dataGridView1.Rows[rowIndex].Cells[4].Value = sProd.Substring(sProd.IndexOf("#1/") + 3, sProd.IndexOf("#2/") - (sProd.IndexOf("#1/") + 3));     //품목명
                //dataGridView1.Rows[rowIndex].Cells[7].Value = sProd.Substring(sProd.IndexOf("#5/") + 3, sProd.IndexOf("#6/") - (sProd.IndexOf("#5/") + 3));     //점수
                //dataGridView1.Rows[rowIndex].Cells[8].Value = sProd.Substring(sProd.IndexOf("#4/") + 3, sProd.IndexOf("#5/") - (sProd.IndexOf("#4/") + 3));     //층수
                //dataGridView1.Rows[rowIndex].Cells[9].Value = sProd.Substring(sProd.IndexOf("#6/") + 3, sProd.IndexOf("#7/") - (sProd.IndexOf("#6/") + 3));    //MM
                dataGridView1.Rows[rowIndex].Cells[12].Value = sProd.Substring(sProd.IndexOf("#7/") + 3, sProd.Length - (sProd.IndexOf("#7/") + 3));    //기준단가
                //dataGridView1.Rows[rowIndex].Cells[12].Value = sProd.Substring(sProd.IndexOf("#7/") + 3, sProd.IndexOf("#8/") - (sProd.IndexOf("#7/") + 3));    //기준단가
                //dataGridView1.Rows[rowIndex].Cells[5].Value = sProd.Substring(sProd.IndexOf("#8/") + 3, sProd.IndexOf("#9/") - (sProd.IndexOf("#8/") + 3));    //공정코드
                //dataGridView1.Rows[rowIndex].Cells[6].Value = sProd.Substring(sProd.IndexOf("#9/") + 3, sProd.Length - (sProd.IndexOf("#9/") + 3));            //공정명
                //dataGridView1.Rows[rowIndex].Cells[13].Value = sProd.Substring(sProd.IndexOf("#7/") + 3, sProd.Length - (sProd.IndexOf("#7/") + 3));    //기준단가
                //dataGridView1.CurrentCell = dataGridView1[5, rowIndex]; // 공정명
            }
            catch (Exception)
            {
                return;
            }
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridView1.RowCount < 2) return;

            long lQty = 0;
            long lDanga = 0;
            long lAmount = 0;

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    lQty = Convert.ToInt64(row.Cells[11].Value);
                    lDanga = Convert.ToInt64(row.Cells[13].Value);
                    lAmount = Convert.ToInt64(row.Cells[14].Value);

                    if ((lQty * lDanga) == lAmount)
                        row.Cells[13].Style.ForeColor = Color.Empty;
                    else
                        row.Cells[13].Style.ForeColor = Color.Red;
                }
                ListSearch4();
            }
            //catch (InvalidCastException)
            catch (Exception)
            {
                return;
            }
        }
        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            //lblMsg.Text = "";
            //if (G.Authority == "D") return;
            //if (string.IsNullOrEmpty(tbNo.Text)) return;

            //if (e.Button == MouseButtons.Right)
            //{
            //    DataGridView.HitTestInfo info = dataGridView1.HitTest(e.X, e.Y);
            //    if (info.Type == DataGridViewHitTestType.Cell &&
            //        info.RowIndex != dataGridView1.Rows.Count - 1)
            //    {
            //        ContextMenu mnu = new ContextMenu();
            //        mnu.MenuItems.Add(new MenuItem("추가", Gridclickevents1));

            //        dataGridView1.ContextMenu = mnu;
            //        dataGridView1.CurrentCell = dataGridView1.Rows[info.RowIndex].Cells[info.ColumnIndex];
            //        dataGridView1.ContextMenu.Show(dataGridView1, e.Location);
            //    }
            //}
        }
        private void Gridclickevents1(object sender, EventArgs e)
        {
            P1B01_ESTIMATE_ADD sub = new P1B01_ESTIMATE_ADD();
            sub.parentWin = this;
            sub.parentRow = dataGridView1.CurrentCell.RowIndex;
            sub.ShowDialog();
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
                        dataGridViewList.CurrentCell = dataGridViewList[2, i];
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
        }
        private async void pbDel_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            if (!cbNo.Checked)
            {
                lblMsg.Text = "삭제할 견적번호를 체크해 주세요.";
                return;
            }

            string sNo = tbNo.Text;

            if (string.IsNullOrEmpty(sNo))
            {
                lblMsg.Text = "저장된 견적번호만 삭제할 수 있습니다.";
                return;
            }

            DialogResult dr = MessageBox.Show("견적번호 : " + sNo + "\r\r해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No) return;

            MariaCRUD m = new MariaCRUD();
            string sql = "delete from SAL_estimate_main where estimate_id = '" + sNo + "'";
            string msg = string.Empty;
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                MessageBox.Show(msg);
                return;
            }

            m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sNo + " " + tbProject.Text);

            var data = sql;
            var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.삭제, data);

            ListSearch1();
            ListInit();
        }
        private async void pbSave_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            Cursor.Current = Cursors.WaitCursor;
            dataGridView1.CurrentCell = dataGridView1[4, 0];
            lblMsg.Text = "";

            string sCust = tbCustName.Tag.ToString();

            if (string.IsNullOrEmpty(sCust))
            {
                lblMsg.Text = "거래처명을 입력해 주세요.";
                tbCustName.Focus();
                return;
            }

            //int iCnt = 0;

            //for (int i = 0; i < dataGridView1.RowCount; i++)
            //{
            //    if (!(dataGridView1.Rows[i].Cells[2].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[2].Value.ToString()))) iCnt++;
            //}

            //if (iCnt == 0)
            //{
            //    lblMsg.Text = "품목정보를 확인해 주세요.";
            //    dataGridView1.Focus();
            //    return;
            //}
            
            string sNo = tbNo.Text;
            string sDate = dtpDate.Value.ToString("yyyy-MM-dd");
            string sProject = tbProject.Text.Trim();
            //if (string.IsNullOrEmpty(sProject)) sProject = tbCustName.Text.Trim() + "의 건";

            string sAddress = tbAddress.Text.Trim();
            string sCustMan = tbCustMan.Text.Trim();
            string sManHp = tbManHp.Text.Trim();
            string sCurrency = cbCurrency.Text.Trim();
            string sEstiContents = tbEstiContents.Text.Trim();
            string sRorderFlag = "N";
            //if (cbRorderFlag.Checked) sRorderFlag = "Y";
            string sRorder = tbRorder.Text;

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            string sSeq = string.Empty; string sPeriod = string.Empty; string sManMonth = string.Empty; string sMatCnt = string.Empty;
            string sProdID = string.Empty; string sProc = string.Empty;
            string sQty = string.Empty; string sDanga = string.Empty; string sDanga_prop = string.Empty;
            string sAmount = string.Empty; string face = string.Empty;
            string sRFlag = string.Empty;

            // 견적총액
            int iCnt = 0; long lSum = 0; string sMoney, sVat;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (!(dataGridView1.Rows[i].Cells[2].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[2].Value.ToString()))) iCnt++;
                    iCnt++;

                if (dataGridView1.Rows[i].Cells[14].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[14].Value.ToString()))
                    sMoney = "0";
                else
                    sMoney = dataGridView1.Rows[i].Cells[14].Value.ToString();

                lSum += long.Parse(sMoney);
            }
            
            if (iCnt == 0)
            {
                lblMsg.Text = "품목정보를 확인해 주세요.";
                dataGridView1.Focus();
                return;
            }

            sMoney = lSum.ToString();

            if (string.IsNullOrEmpty(sNo)) //추가
            {
                sNo = getEstimateNo();

                sRorderFlag = string.IsNullOrEmpty(tbRorder.Text) ? "N" : "Y";

                sql = "INSERT INTO SAL_estimate_main (estimate_id, plant, esti_date, cust_id, project, cust_man, cust_contact, warehouse, currency, total_amount, esti_contents, rorder_flag, enter_man) " +
                    "VALUES('" + sNo + "','" + G.Pos + "','" + sDate + "','" + sCust + "','" + sProject + "','" + sCustMan + "','" + sManHp + "','" + sAddress + "','" + sCurrency + "'," + sMoney + ",'" + sEstiContents + "','" + sRorderFlag + "','" + G.UserID + "')";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    MessageBox.Show(msg);
                    return;
                }

                var data = sql;
                var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);

                tbNo.Text = sNo;

                int seq = 0;
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    seq = seq + 1;
                    sSeq = seq.ToString();
                    sProdID = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    //sProc = dataGridView1.Rows[i].Cells[5].Value.ToString().Trim();
                    sPeriod = dataGridView1.Rows[i].Cells[6].Value.ToString().Trim();
                    sManMonth = dataGridView1.Rows[i].Cells[9].Value.ToString().Trim();
                    sMatCnt = dataGridView1.Rows[i].Cells[10].Value.ToString().Trim();
                    sQty = dataGridView1.Rows[i].Cells[11].Value.ToString().Trim();
                    sDanga = dataGridView1.Rows[i].Cells[12].Value.ToString().Trim();
                    sDanga_prop = dataGridView1.Rows[i].Cells[13].Value.ToString().Trim();
                    sAmount = dataGridView1.Rows[i].Cells[14].Value.ToString().Trim();

                    if (string.IsNullOrEmpty(sPeriod)) sPeriod = "0";
                    if (string.IsNullOrEmpty(sManMonth)) sManMonth = "0";
                    if (string.IsNullOrEmpty(sMatCnt)) sMatCnt = "0";
                    if (string.IsNullOrEmpty(sQty)) sQty = "0";
                    if (string.IsNullOrEmpty(sDanga)) sDanga = "0";
                    if (string.IsNullOrEmpty(sDanga_prop)) sDanga_prop = "0";
                    if (string.IsNullOrEmpty(sAmount)) sAmount = "0";

                    sql = $@"INSERT INTO SAL_estimate_sub (estimate_id, estimate_seq, prod_id, work_period, manmonth, mat_count, qty, danga_std, danga_proposal, amount)
                            VALUES('{@sNo}', {@sSeq}, '{@sProdID}', {@sPeriod}, {@sManMonth}, {@sMatCnt}, {@sQty}, {@sDanga}, {@sDanga_prop}, {@sAmount})";

                    m.dbCUD(sql, ref msg);

                    data = sql;
                    result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);
                }

                sql = $@"UPDATE SAL_order_main SET estimate_id = '{@sNo}' WHERE order_id = '{@sRorder}'";
                m.dbCUD(sql, ref msg);

                data = sql;
                result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);
            }
            else //수정
            {
                //sRorderFlag = string.IsNullOrEmpty(tbRorder.Text) ? "N" : "Y";

                sql = $@"UPDATE SAL_estimate_main
                        SET esti_date = '{@sDate}', cust_id = '{@sCust}', project = '{@sProject} ', cust_man = '{@sCustMan}', cust_contact = '{@sManHp}',
                        warehouse = '{@sAddress}', currency = '{@sCurrency}', total_amount = {@sMoney}, esti_contents = '{@sEstiContents}' WHERE estimate_id = '{@sNo}'";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    MessageBox.Show(msg);
                    return;
                }

                var data = sql;
                var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);

                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[2].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[2].Value.ToString()))
                    {
                        lblMsg.Text = "품목명을 선택하세요"; return;
                    }
                    else
                        sProdID = dataGridView1.Rows[i].Cells[2].Value.ToString();

                    sProc = dataGridView1.Rows[i].Cells[5].Value.ToString().Trim();
                    sPeriod = dataGridView1.Rows[i].Cells[6].Value.ToString().Trim();
                    sManMonth = dataGridView1.Rows[i].Cells[9].Value.ToString().Trim();
                    sMatCnt = dataGridView1.Rows[i].Cells[10].Value.ToString().Trim();
                    sQty = dataGridView1.Rows[i].Cells[11].Value.ToString().Trim();
                    sDanga = dataGridView1.Rows[i].Cells[12].Value.ToString().Trim();
                    sDanga_prop = dataGridView1.Rows[i].Cells[13].Value.ToString().Trim();
                    sAmount = dataGridView1.Rows[i].Cells[14].Value.ToString().Trim();

                    if (dataGridView1.Rows[i].Cells[1].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[1].Value.ToString()))
                        sSeq = getEstimateSeq(sNo);
                    else
                        sSeq = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (string.IsNullOrEmpty(sPeriod)) sPeriod = "0";
                    if (string.IsNullOrEmpty(sManMonth)) sManMonth = "0";
                    if (string.IsNullOrEmpty(sMatCnt)) sMatCnt = "0";
                    if (string.IsNullOrEmpty(sQty)) sQty = "0";
                    if (string.IsNullOrEmpty(sDanga)) sDanga = "0";
                    if (string.IsNullOrEmpty(sDanga_prop)) sDanga_prop = "0";
                    if (string.IsNullOrEmpty(sAmount)) sAmount = "0";

                    sql = $@"INSERT INTO SAL_estimate_sub (estimate_id, estimate_seq, prod_id, work_period, manmonth, mat_count, qty, danga_std, danga_proposal, amount)
                            VALUES('{@sNo}', {@sSeq}, '{@sProdID}', {@sPeriod}, {@sManMonth}, {@sMatCnt}, {@sQty}, {@sDanga}, {@sDanga_prop}, {@sAmount})
                            ON DUPLICATE KEY UPDATE
                            prod_id = '{@sProdID}', work_period = {@sPeriod}, manmonth = {@sManMonth}, mat_count = {@sMatCnt}, qty = {@sQty}, danga_std = {@sDanga}, danga_proposal = {@sDanga_prop}, amount = {@sAmount}";

                    m.dbCUD(sql, ref msg);

                    data = sql;
                    result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);
                }
            }

            tbSearch.Text = "";
            ListSearch1();

            for (int i = 0; i < dataGridViewList.Rows.Count; i++)
            {
                if (dataGridViewList.Rows[i].Cells[0].Value.ToString() == sNo)
                {
                    dataGridViewList.CurrentCell = dataGridViewList[2, i];
                    dataGridViewList.CurrentCell.Selected = true;

                    ListSearch2(i);
                    ListSearch3();
                    ListSearch4();
                    break;
                }
            }

            m.TransLogCreate(G.Authority, G.UserID, "M", this.Name, lblTitle.Text, sNo + "-" + sProject);
            lblMsg.Text = "저장되었습니다.";
            Cursor.Current = Cursors.Default;
        }
        private void pbPrint_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            string sNo = tbNo.Text;

            if (string.IsNullOrEmpty(sNo))
            {
                lblMsg.Text = "저장된 견적만 견적서 출력이 가능합니다.";
                return;
            }

            //sP_EstimateMain_PrintTableAdapter.Fill(dataSetP1B.SP_EstimateMain_Print, sNo);

            //string sql = @"select sum(amount) from SAL_estimate_sub where estimate_id = '" + sNo + "'";
            //MariaCRUD m = new MariaCRUD();
            //string msg = string.Empty;
            //long lTotAmount = long.Parse(m.dbRonlyOne(sql, ref msg).ToString());

            //string reportFileName = "SmartMES_Giroei.Reports.P1B01_ESTIMATE.rdlc";

            //string reportParm1 = "";
            //string reportParm2 = "일금 ";

            //reportParm1 = reportParm1 + "발주 후 " + tbValidDay.Text.Trim() + " 일";
            //reportParm2 = reportParm2 + new MyClass().Number2Hangle(lTotAmount) + " 원정";


            //ViewReport_V viewReport = new ViewReport_V();
            //viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
            //viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            //ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
            //ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
            //viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2 });

            //ReportDataSource rds = new ReportDataSource("DataSet1", sPEstimateMainPrintBindingSource);
            //viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            //viewReport.reportViewer1.LocalReport.Refresh();

            //viewReport.ShowDialog();
        }
        #endregion

        #region 견적번호 생성
        private string getEstimateNo()
        {
            string sql = @"select UF_EstimateNoGenerator()";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
        private string getEstimateSeq(string sNo)
        {
            string sql = @"select UF_EstimateSeqGenerator('" + sNo + "')";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
        #endregion

        #region 엑셀파일 업로드
        private void btnExcel_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            lblMsg.Text = "";

            if (dataGridView1.Rows.Count != 1 || dataGridView1.Rows[0].Cells[0].Value != null)
            {
                lblMsg.Text = "추가 상태에서만 엑셀파일 업로드가 가능합니다.";
                return;
            }

            FileDialog fileDig = new OpenFileDialog();
            fileDig.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileDig.Filter = "엑셀파일|*.xlsx;*.xls";
            fileDig.RestoreDirectory = true;

            if (fileDig.ShowDialog() != DialogResult.OK) return;

            DataTable excelTable = new MyClass().GetExcelSheet(fileDig.FileName);
            dataGridView1.DataSource = excelTable;

            Cursor.Current = Cursors.Default;
        }

        #endregion

        
    }
}
