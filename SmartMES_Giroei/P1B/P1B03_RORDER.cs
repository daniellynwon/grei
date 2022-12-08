using Microsoft.Reporting.WinForms;
using SmartFactory;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B03_RORDER : SmartMES_Giroei.FormBasic
    {
        int columnIndex = 0;
        int rowIndex = 0;
        bool endEdit = false;

        public P1B03_RORDER()
        {
            InitializeComponent();
        }
        private async void P1B03_RORDER_Load(object sender, EventArgs e)
        {
            sP_Z_Common_IDTableAdapter.Fill(dataSetP1B.SP_Z_Common_ID, "P");

            var data = dataSetP1B.SP_Z_Common_ID;
            var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

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

                sP_ROrderMain_QueryTableAdapter.Fill(dataSetP1B.SP_ROrderMain_Query, sSearch);

                var data = dataSetP1B.SP_ROrderMain_Query;
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
            try
            {
                cbNo.Checked = false;
                tbNo.Text = dataGridViewList.Rows[rowIndex].Cells[2].Value.ToString();
                dtpDate.Value = DateTime.Parse(dataGridViewList.Rows[rowIndex].Cells[1].Value.ToString());
                tbCust.Tag = dataGridViewList.Rows[rowIndex].Cells[3].Value.ToString();
                tbCust.Text = dataGridViewList.Rows[rowIndex].Cells[4].Value.ToString();
                dtpDeliDate.Value = DateTime.Parse(dataGridViewList.Rows[rowIndex].Cells[6].Value.ToString());
                tbContents.Text = dataGridViewList.Rows[rowIndex].Cells[9].Value.ToString();
                tbEstiNo.Text = dataGridViewList.Rows[rowIndex].Cells[10].Value.ToString();
                if (string.IsNullOrEmpty(tbEstiNo.Text)) cbIsEstimate.Checked = false;
                else cbIsEstimate.Checked = true;
                tbProject.Text = dataGridViewList.Rows[rowIndex].Cells[5].Value.ToString();
                //첨부물1,2,3,4 추가
                string sFile1 = dataGridViewList[13, rowIndex].Value.ToString();
                string sFile2 = dataGridViewList[14, rowIndex].Value.ToString();
                string sFile3 = dataGridViewList[15, rowIndex].Value.ToString();
                string sFile4 = dataGridViewList[16, rowIndex].Value.ToString();

                // clip icon 처리 - 파일 있으면 파란색, 없으면 회색 클립
                if (string.IsNullOrEmpty(sFile1))
                {
                    doc1.buttonImage = Properties.Resources.clipB;
                    doc1.Tag = "";
                }
                else
                {
                    doc1.buttonImage = Properties.Resources.clipA;
                    doc1.Tag = sFile1;
                }
                if (string.IsNullOrEmpty(sFile2))
                {
                    doc2.buttonImage = Properties.Resources.clipB;
                    doc2.Tag = "";
                }
                else
                {
                    doc2.buttonImage = Properties.Resources.clipA;
                    doc2.Tag = sFile2;
                }
                if (string.IsNullOrEmpty(sFile3))
                {
                    doc3.buttonImage = Properties.Resources.clipB;
                    doc3.Tag = "";
                }
                else
                {
                    doc3.buttonImage = Properties.Resources.clipA;
                    doc3.Tag = sFile3;
                }
                if (string.IsNullOrEmpty(sFile4))
                {
                    doc4.buttonImage = Properties.Resources.clipB;
                    doc4.Tag = "";
                }
                else
                {
                    doc4.buttonImage = Properties.Resources.clipA;
                    doc4.Tag = sFile4;
                }
            }
            catch (NullReferenceException)
            {
                return;
            }

            Cursor.Current = Cursors.Default;
        }
        public async void ListSearch3()
        {
            lblMsg.Text = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sNo = tbNo.Text;

                sP_ROrderSub_QueryTableAdapter.Fill(dataSetP1B.SP_ROrderSub_Query, sNo);

                var data = dataSetP1B.SP_ROrderSub_Query;
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
                    if (dataGridView1.Rows[i].Cells[3].Value != null) iCnt++;

                    if (dataGridView1.Rows[i].Cells[15].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[15].Value.ToString()))
                        sMoney = "0";
                    else
                        sMoney = dataGridView1.Rows[i].Cells[15].Value.ToString();

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
            tbCust.Tag = string.Empty;
            tbCust.Text = string.Empty;
            tbProject.Text = string.Empty;
            dtpDeliDate.Value = DateTime.Today;
            tbContents.Text = string.Empty;

            sP_ROrderSub_QueryTableAdapter.Fill(dataSetP1B.SP_ROrderSub_Query, "");

            var data = dataSetP1B.SP_ROrderSub_Query;
            var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

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
                lblMsg.Text = "복사할 수주번호를 체크해 주세요.";
                return;
            }

            string sNo = tbNo.Text;

            if (string.IsNullOrEmpty(sNo))
            {
                lblMsg.Text = "저장된 수주번호만 복사할 수 있습니다.";
                return;
            }

            DialogResult dr = MessageBox.Show("수주번호 : " + sNo + "\r\r해당 수주정보를 새로운 수주번호로 복사하시겠습니까?", this.lblTitle.Text + "[수주복사]", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();
            string sNewNo = getROrderNo();

            sql = "insert into SAL_order_main (order_id, plant, order_date, cust_id, project, deli_date, cust_man, cust_contact, warehouse, estimate_id, enter_man) " +
                  "select '" + sNewNo + "','" + G.Pos + "', CURDATE(), cust_id, project, CURDATE(), '" + G.UserID + "' " +
                  "from SAL_order_main " +
                  "where order_id = '" + sNo + "'";

            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            sql = "insert into SAL_order_sub (order_id, order_seq, prod_id, add_name, add_size, qty, danga,  amount, vat, bigo, proc_std) " +
                  "select '" + sNewNo + "', order_seq, prod_id, add_name, add_size, qty, danga, amount, vat, bigo, proc_std " +
                  "from SAL_order_sub " +
                  "where order_id = '" + sNo + "' " +
                  "order by order_seq";

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
                if (dataGridViewList.Rows[i].Cells[2].Value.ToString() == sNewNo)
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
            sub.FormSendEvent += new CustFinder.FormSendDataHandler(planttEventMethod);
            sub._gubun = "103";
            sub.ShowDialog();
        }
        private void planttEventMethod(object sender)
        {
            string sCust = sender.ToString();

            if (string.IsNullOrEmpty(sCust)) return;

            tbCust.Tag = sCust.Substring(0, sCust.IndexOf("#1/"));
            tbCust.Text = sCust.Substring(sCust.IndexOf("#1/") + 3, sCust.IndexOf("#2/") - (sCust.IndexOf("#1/") + 3));
            tbProject.Focus();
        }

        private void cbIsEstimate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsEstimate.Checked == false)
            {
                tbEstiNo.Text = string.Empty;
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
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        e.SuppressKeyPress = true;
                    
            //        int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
            //        int rowIndex = dataGridView1.CurrentCell.RowIndex;

            //        //if (columnIndex == dataGridView1.Columns.Count - 1)
            //        if (columnIndex == 15)
            //            dataGridView1.CurrentCell = dataGridView1[4, rowIndex + 1];
            //        else
            //            dataGridView1.CurrentCell = dataGridView1[columnIndex + 1, rowIndex];
            //    }
            //    if (e.KeyCode == Keys.Tab)
            //    {
            //        e.Handled = true;
            //    }
            //}
            //catch (Exception)
            //{
            //    return;
            //}
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                columnIndex = dataGridView1.CurrentCell.ColumnIndex;
                rowIndex = dataGridView1.CurrentCell.RowIndex;
                //rowIndex = e.RowIndex;
                endEdit = true;

                float money1 = 0;
                float money2 = 0;
                long moneyA = 0; 
                long moneyB = 0;

                if (columnIndex == 13 || columnIndex == 14)
                {
                    if (dataGridView1.Rows[rowIndex].Cells[13].Value != null && dataGridView1.Rows[rowIndex].Cells[13].Value.ToString().Length != 0)
                        money1 = float.Parse(dataGridView1.Rows[rowIndex].Cells[13].Value.ToString());

                    if (dataGridView1.Rows[rowIndex].Cells[14].Value != null && dataGridView1.Rows[rowIndex].Cells[14].Value.ToString().Length != 0)
                        money2 = float.Parse(dataGridView1.Rows[rowIndex].Cells[14].Value.ToString());

                    moneyA = (long)(money1 * money2);
                    dataGridView1.Rows[rowIndex].Cells[15].Value = moneyA;
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
                    }
                    else
                    {
                        //
                    }
                }
            }
            catch(Exception)
            {
                return;
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //columnIndex = dataGridView1.CurrentCell.ColumnIndex;
            //Debug.Print("columnIndex : " + columnIndex);
            //rowIndex = dataGridView1.CurrentCell.RowIndex;
            try
            {
                if (dataGridView1.CurrentCell != null && endEdit)
                //if (columnIndex != 6 && columnIndex != 9
                //    && columnIndex != 24 && columnIndex != 25 && columnIndex != 26 && columnIndex != 27)
                {
                    //if (columnIndex == dataGridView1.Columns.Count - 1)
                    if (columnIndex == 15)
                        dataGridView1.CurrentCell = dataGridView1[4, rowIndex + 1];
                    else
                        dataGridView1.CurrentCell = dataGridView1[columnIndex + 1, rowIndex];

                    endEdit = false;
                }
            }
            catch(Exception)
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

            if (e.ColumnIndex == 2) //"품목"
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
            //else if (e.ColumnIndex == 6)
            //{
            //    string sVal = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            //    if (sVal == "신규")
            //    {
            //        dataGridView1.Rows[e.RowIndex].Cells[6].Value = "반복";
            //    }
            //    else dataGridView1.Rows[e.RowIndex].Cells[6].Value = "신규";
            //}
            //else if (e.ColumnIndex == 9)
            //{
            //    string sVal = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            //    if (sVal == "양면")
            //    {
            //        dataGridView1.Rows[e.RowIndex].Cells[9].Value = "단면";
            //    }
            //    else if (sVal == "단면") dataGridView1.Rows[e.RowIndex].Cells[9].Value = "";
            //    else dataGridView1.Rows[e.RowIndex].Cells[9].Value = "양면";
            //}
            else if (e.ColumnIndex == 28) // X
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

                    if (dataGridView1.RowCount <= 2)
                    {
                        lblMsg.Text = "수주건 전체를 삭제해주세요";
                        return;
                    }

                    string sSeq = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                    DialogResult dr = MessageBox.Show("해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.No) return;

                    MariaCRUD m = new MariaCRUD();
                    string sql = "delete from SAL_order_sub where order_id = '" + sNo + "' and order_seq = " + sSeq;
                    string msg = string.Empty;
                    m.dbCUD(sql, ref msg);

                    if (msg != "OK")
                    {
                        MessageBox.Show(msg);
                        return;
                    }

                    //string sEstimateNo = dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();
                    //string sEstimateSeq = dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString();
                    //if (!string.IsNullOrEmpty(sEstimateNo))
                    //{
                    //    sql = "update tb_estimate_sub set rorder_flag = 0 where estimate_id = '" + sEstimateNo + "' and estimate_seq = " + sEstimateSeq;
                    //    m.dbCUD(sql, ref msg);
                    //}

                    dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                    m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sNo + " " + sSeq);
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
            //if (dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
            //{
            //    dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //}
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
                //dataGridView1.Rows[rowIndex].Cells[6].Value = sProd.Substring(sProd.IndexOf("#2/") + 3, sProd.IndexOf("#3/") - (sProd.IndexOf("#2/") + 3));
                dataGridView1.Rows[rowIndex].Cells[8].Value = sProd.Substring(sProd.IndexOf("#5/") + 3, sProd.IndexOf("#6/") - (sProd.IndexOf("#5/") + 3)); //점수
                dataGridView1.Rows[rowIndex].Cells[14].Value = sProd.Substring(sProd.IndexOf("#7/") + 3, sProd.Length - (sProd.IndexOf("#7/") + 3)); //기준단가
                dataGridView1.CurrentCell = dataGridView1[7, rowIndex];

                //if (rowIndex < 1)
                //    dataGridView1.Rows[rowIndex].Cells[21].Value = "0001";
                //else
                //    dataGridView1.Rows[rowIndex].Cells[21].Value = dataGridView1.Rows[rowIndex - 1].Cells[21].Value;
            }
            catch(Exception)
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
                row = table.Select("prod_name='" + prodName + "'");
                if (row.Length.Equals(0)) return false;
                // if (!row[0][0].Equals(1)) return false;
                dataGridView1.Rows[rowIndex].Cells[3].Value = row[0][1].ToString();
                dataGridView1.Rows[rowIndex].Cells[4].Value = row[0][2].ToString();     //품목명
                dataGridView1.Rows[rowIndex].Cells[8].Value = row[0][6].ToString();     //점수
                //dataGridView1.Rows[rowIndex].Cells[8].Value = row[0][5].ToString();     //층수
                dataGridView1.Rows[rowIndex].Cells[11].Value = row[0][7].ToString();    //MM
                dataGridView1.Rows[rowIndex].Cells[14].Value = row[0][8].ToString();    //기준단가
                //dataGridView1.Rows[rowIndex].Cells[5].Value = row[0][9].ToString();     //공정코드
                //dataGridView1.Rows[rowIndex].Cells[6].Value = row[0][10].ToString();    //공정명
                return true;
            }
            else
            {
                return false;
            }

        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridView1.RowCount < 2) return;

        }
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
                if (columnIndex == 13 || columnIndex == 14 || columnIndex == 15)    // 수량,단가,금액. 부품수는 제외함(7/26)
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
                    if (dataGridViewList.Rows[i].Cells[2].Value.ToString() == sNo)
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

            if (!cbIsEstimate.Checked)
            {
                lblMsg.Text = "견적정보 없이 수주정보를 등록합니다.";
                return;
            }

            P1B03_RORDER_SUB sub = new P1B03_RORDER_SUB();
            sub.parentWin = this;
            sub.ShowDialog();
        }
        private async void pbDel_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            if (!cbNo.Checked)
            {
                lblMsg.Text = "삭제할 수주번호를 체크해 주세요.";
                return;
            }

            string sNo = tbNo.Text; string sEstiNo = tbEstiNo.Text;

            if (string.IsNullOrEmpty(sNo))
            {
                lblMsg.Text = "저장된 수주번호만 삭제할 수 있습니다.";
                return;
            }

            DialogResult dr = MessageBox.Show("수주번호 : " + sNo + "\r\r해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No) return;

            MariaCRUD m = new MariaCRUD();
            string sql = "delete from SAL_order_main where order_id = '" + sNo + "'";
            string msg = string.Empty;
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                MessageBox.Show(msg);
                return;
            }

            var data = sql;
            var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.삭제, data);

            sql = "delete from SAL_order_sub where order_id = '" + sNo + "'";
            msg = string.Empty;
            m.dbCUD(sql, ref msg);

            data = sql;
            result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.삭제, data);

            // rorder_flag update 취소
            sql = "update SAL_estimate_main set rorder_flag = 'N' where estimate_id = '" + sEstiNo + "'";
            m.dbCUD(sql, ref msg);

            data = sql;
            result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);

            m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sNo + " " + tbCust.Text);

            ListSearch1();
            ListInit();
        }
        private async void pbSave_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            dataGridView1.CurrentCell = dataGridView1[4, 0];
            lblMsg.Text = "";

            if (tbCust.Tag == null || string.IsNullOrEmpty(tbCust.Tag.ToString()))
            {
                lblMsg.Text = "거래처명을 선택해 주세요.";
                lblCust.Focus();
                return;
            }
            if (tbProject.Text == null || string.IsNullOrEmpty(tbProject.Text.ToString()))
            {
                lblMsg.Text = "모델명을 선택해 주세요.";
                tbProject.Focus();
                return;
            }

            int iCnt = 0;

            //for (int i = 0; i < dataGridView1.RowCount; i++)
            //{
            //    if (!(dataGridView1.Rows[i].Cells[3].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[3].Value.ToString()))) iCnt++;   // 품목코드

            //    if ((dataGridView1.Rows[i].Cells[24].Value == "Y" || dataGridView1.Rows[i].Cells[25].Value == "Y" || dataGridView1.Rows[i].Cells[26].Value == "Y" || dataGridView1.Rows[i].Cells[27].Value == "Y") == false)
            //    {
            //        lblMsg.Text = "공정을 최소 1개 이상 선택하셔야 합니다.";
            //        dataGridView1.Focus();
            //        return;
            //    }
            //}

            //if (iCnt == 0)
            //{
            //    lblMsg.Text = "품목정보를 확인해 주세요.";
            //    dataGridView1.Focus();
            //    return;
            //}

            int pCnt = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (!(dataGridView1.Rows[i].Cells[24].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[24].Value.ToString()))) pCnt++;
                else if (!(dataGridView1.Rows[i].Cells[25].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[25].Value.ToString()))) pCnt++;
                else if (!(dataGridView1.Rows[i].Cells[26].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[26].Value.ToString()))) pCnt++;
                else if (!(dataGridView1.Rows[i].Cells[27].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[27].Value.ToString()))) pCnt++;
            }
            if (pCnt == 0)
            {
                lblMsg.Text = "공정을 확인해 주세요.";
                dataGridView1.Focus();
                return;
            }

            string sNo = tbNo.Text;
            string sDate = dtpDate.Value.ToString("yyyy-MM-dd");
            string sCust = tbCust.Tag.ToString();
            string sProject = tbProject.Text;
            string sEstiNo = (cbIsEstimate.Checked == true) ? tbEstiNo.Text : "";
            //string sEstiNo = tbEstiNo.Text;
            string sDeliDate = dtpDeliDate.Value.ToString("yyyy-MM-dd");
            string sContents = tbContents.Text.Trim();

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            string sSeq = string.Empty;
            string sProdID = string.Empty;
            //string sProc = string.Empty;
            string sProdType = string.Empty; string sMangeNo = string.Empty;
            string sWorkP = string.Empty; string sManMth = string.Empty; string sMatCnt = string.Empty;
            string sQty = string.Empty; string sDanga = string.Empty;
            string sAmount = string.Empty; string face = string.Empty;

            string sSMT = string.Empty;
            string sPCB = string.Empty;
            string sAssemble = string.Empty;
            string sSusap = string.Empty;

            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                if (dataGridView1.Rows[i].Cells[13].Value == null)
                {
                    lblMsg.Text = "수량이 제대로 입력되지 않은 부분이 있습니다.";
                    dataGridView1.CurrentCell = dataGridView1[13, i];
                    //dataGridView1.ClearSelection();
                    return;
                }
            }

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                //공정 미선택시 처리과정 추가할 것
            }

            if (string.IsNullOrEmpty(sNo)) //추가
            {
                //if (dataGridView1.Rows.Count > 1)
                //{
                //    for (int i = 0; i < dataGridView1.RowCount-1; i++)
                //    {
                //        if (dataGridView1.Rows[i].Cells[9].Value.ToString() == "양면") face = "D";
                //        else if (dataGridView1.Rows[i].Cells[9].Value.ToString() == "단면") face = "S";
                //        else
                //        {
                //            lblMsg.Text = "면수를 확인하세요";
                //            return;
                //        }
                //    }
                //}

                sNo = getROrderNo();
                sql = "insert into SAL_order_main (order_id, plant, order_date, cust_id, project, deli_date, contents, estimate_id, enter_man) " +
                    "values('" + sNo + "','" + G.Pos + "','" + sDate + "','" + sCust + "','" + sProject + "','" + sDeliDate + "','" + sContents + "','" + sEstiNo + "','" + G.UserID + "')";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    MessageBox.Show(msg);
                    return;
                }

                var data = sql;
                var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);

                int seq = 0;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[3].Value == null ||string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[3].Value.ToString())) continue;

                    seq = seq + 1;
                    sSeq = seq.ToString();
                    sProdID = dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();
                    //sProc = dataGridView1.Rows[i].Cells[5].Value.ToString().Trim();
                    //sProdType = dataGridView1.Rows[i].Cells[6].Value.ToString().Trim();
                    sMangeNo = dataGridView1.Rows[i].Cells[7].Value.ToString().Trim();
                    //sWorkP = dataGridView1.Rows[i].Cells[8].Value.ToString().Trim();
                    //sManMth = dataGridView1.Rows[i].Cells[9].Value.ToString().Trim();
                    //sMatCnt = dataGridView1.Rows[i].Cells[10].Value.ToString().Trim(); +2

                    //생산형태, 면수
                    if (dataGridView1.Rows[i].Cells[6].Value != null)
                        sProdType = (dataGridView1.Rows[i].Cells[6].Value.ToString() == "반복") ? "반복" : "신규";
                    if (dataGridView1.Rows[i].Cells[9].Value != null)
                        face = (dataGridView1.Rows[i].Cells[9].Value.ToString() == "D") ? "D" : "S";

                    //공정
                    if (dataGridView1.Rows[i].Cells[24].Value != null)
                        sSMT = (dataGridView1.Rows[i].Cells[24].Value.ToString() == "Y") ? "Y" : "N";
                    if (dataGridView1.Rows[i].Cells[25].Value != null)
                        sPCB = (dataGridView1.Rows[i].Cells[25].Value.ToString() == "Y") ? "Y" : "N";
                    if (dataGridView1.Rows[i].Cells[26].Value != null)
                        sAssemble = (dataGridView1.Rows[i].Cells[26].Value.ToString() == "Y") ? "Y" : "N";
                    if (dataGridView1.Rows[i].Cells[27].Value != null)
                        sSusap = (dataGridView1.Rows[i].Cells[27].Value.ToString() == "Y") ? "Y" : "N";

                    //if (dataGridView1.Rows[i].Cells[9].Value.ToString() == "양면") face = "D";
                    //else if (dataGridView1.Rows[i].Cells[9].Value.ToString() == "단면") face = "S";
                    //else
                    //{
                    //    lblMsg.Text = "면수를 확인하세요";
                    //    return;
                    //}
                    sQty = dataGridView1.Rows[i].Cells[13].Value.ToString().Trim();
                    sDanga = dataGridView1.Rows[i].Cells[14].Value.ToString().Trim();
                    sAmount = dataGridView1.Rows[i].Cells[15].Value.ToString().Trim();

                    if (string.IsNullOrEmpty(sWorkP)) sWorkP = "0";
                    if (string.IsNullOrEmpty(sManMth)) sManMth = "0";
                    if (string.IsNullOrEmpty(sMatCnt)) sMatCnt = "0";
                    if (string.IsNullOrEmpty(sQty)) sQty = "0";
                    if (string.IsNullOrEmpty(sDanga)) sDanga = "0";
                    if (string.IsNullOrEmpty(sAmount)) sAmount = "0";

                    //sql = "insert into SAL_order_sub (order_id, order_seq, prod_id, process_code, prod_type, reprod_id, work_period, manmonth, mat_count, qty, danga, amount) " +
                    //"values('" + sNo + "'," + sSeq + ",'" + sProdID + "','" + sProc + "','" + sProdType + "','" + sMangeNo + "'," + sWorkP + "," + sManMth + "," + sMatCnt + "," + sQty + "," + sDanga + "," + sAmount + ")";
                    //sql = "insert into SAL_order_sub (order_id, order_seq, prod_id, process_code, prod_type, reprod_id, face, qty, danga, amount) " +
                    //      "values('" + sNo + "'," + sSeq + ",'" + sProdID + "','" + sProc + "','" + sProdType + "','" + sMangeNo + "','" + face + "'," + sQty + "," + sDanga + "," + sAmount + ")";
                    sql = $@"INSERT INTO SAL_order_sub (order_id, order_seq, prod_id, prod_type, reprod_id, face, qty, danga, amount, SMTProcessYN, PCBProcessYN, AssembleProcessYN, SusapProcessYN) 
                                VALUES('{@sNo}', {@sSeq}, '{@sProdID}', '{@sProdType}', '{@sMangeNo}', '{@face}', {@sQty}, {@sDanga}, {@sAmount}, '{@sSMT}', '{@sPCB}', '{@sAssemble}', '{@sSusap}')";
                    m.dbCUD(sql, ref msg);

                    data = sql;
                    result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);
                }
                sql = "update SAL_estimate_main set rorder_flag = 'Y' where estimate_id = '" + sEstiNo + "'";
                m.dbCUD(sql, ref msg);

                data = sql;
                result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);
            }
            else //수정
            {
                sql = "update SAL_order_main " +
                    "set order_date = '" + sDate + "', cust_id = '" + sCust + "', project = '" + sProject + "', deli_date = '" + sDeliDate + "', contents = '" + sContents + "', estimate_id = '" + sEstiNo + "'"+
                    " where order_id = '" + sNo + "'";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    MessageBox.Show(msg);
                    return;
                }

                var data = sql;
                var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[3].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[3].Value.ToString())) continue;

                    sProdID = dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();
                    //sProc = dataGridView1.Rows[i].Cells[5].Value.ToString().Trim();
                    //sProdType = dataGridView1.Rows[i].Cells[6].Value.ToString().Trim();
                    sMangeNo = dataGridView1.Rows[i].Cells[7].Value.ToString().Trim();
                    //sWorkP = dataGridView1.Rows[i].Cells[8].Value.ToString().Trim();
                    //sManMth = dataGridView1.Rows[i].Cells[9].Value.ToString().Trim();
                    //sMatCnt = dataGridView1.Rows[i].Cells[10].Value.ToString().Trim(); +2
                    //if (dataGridView1.Rows[i].Cells[9].Value.ToString() == "양면") face = "D";
                    //else if (dataGridView1.Rows[i].Cells[9].Value.ToString() == "단면") face = "S";
                    //else
                    //{
                    //    lblMsg.Text = "면수를 확인하세요";
                    //    return;
                    //}
                    sQty = dataGridView1.Rows[i].Cells[13].Value.ToString().Trim();
                    sDanga = dataGridView1.Rows[i].Cells[14].Value.ToString().Trim();
                    sAmount = dataGridView1.Rows[i].Cells[15].Value.ToString().Trim();

                    if (dataGridView1.Rows[i].Cells[1].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[1].Value.ToString()))
                        sSeq = getROrderSeq(sNo);
                    else
                        sSeq = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (string.IsNullOrEmpty(sWorkP)) sWorkP = "0";
                    if (string.IsNullOrEmpty(sManMth)) sManMth = "0";
                    if (string.IsNullOrEmpty(sMatCnt)) sMatCnt = "0";
                    if (string.IsNullOrEmpty(sQty)) sQty = "0";
                    if (string.IsNullOrEmpty(sDanga)) sDanga = "0";
                    if (string.IsNullOrEmpty(sAmount)) sAmount = "0";

                    //생산형태, 면수
                    if (dataGridView1.Rows[i].Cells[6].Value != null)
                        sProdType = (dataGridView1.Rows[i].Cells[6].Value.ToString() == "반복") ? "반복" : "신규";
                    if (dataGridView1.Rows[i].Cells[9].Value != null)
                        face = (dataGridView1.Rows[i].Cells[9].Value.ToString() == "D") ? "D" : "S";

                    //공정
                    if (dataGridView1.Rows[i].Cells[24].Value != null)
                        sSMT = (dataGridView1.Rows[i].Cells[24].Value.ToString() == "Y") ? "Y" : "N";
                    if (dataGridView1.Rows[i].Cells[25].Value != null)
                        sPCB = (dataGridView1.Rows[i].Cells[25].Value.ToString() == "Y") ? "Y" : "N";
                    if (dataGridView1.Rows[i].Cells[26].Value != null)
                        sAssemble = (dataGridView1.Rows[i].Cells[26].Value.ToString() == "Y") ? "Y" : "N";
                    if (dataGridView1.Rows[i].Cells[27].Value != null)
                        sSusap = (dataGridView1.Rows[i].Cells[27].Value.ToString() == "Y") ? "Y" : "N";

                    //sql = "insert into SAL_order_sub (order_id, order_seq, prod_id, process_code, prod_type, reprod_id, work_period, manmonth, mat_count, qty, danga, amount)" +
                    //    " values('" + sNo + "'," + sSeq + ",'" + sProdID + "','" + sProc + "','" + sProdType + "','" + sMangeNo + "'," + sWorkP + "," + sManMth + "," + sMatCnt + "," + sQty + "," + sDanga + "," + sAmount + ")" +
                    //    " on duplicate key update" +
                    //    " prod_id = '" + sProdID + "', process_code = '" + sProc + "', prod_type = '" + sProdType + "', reprod_id = '" + sMangeNo + "', work_period = " + sWorkP + ", manmonth = " + sManMth + ", mat_count = " + sMatCnt + ", qty = " + sQty + ", danga = " + sDanga + ", amount = " + sAmount;
                    //sql = "insert into SAL_order_sub (order_id, order_seq, prod_id, process_code, prod_type, reprod_id, face, qty, danga, amount)" +
                    //    " values('" + sNo + "'," + sSeq + ",'" + sProdID + "','" + sProc + "','" + sProdType + "','" + sMangeNo + "','" + face + "'," + sQty + "," + sDanga + "," + sAmount + ")" +
                    sql = $@"INSERT INTO SAL_order_sub (order_id, order_seq, prod_id, prod_type, reprod_id, face, qty, danga, amount, SMTProcessYN, PCBProcessYN, AssembleProcessYN, SusapProcessYN) 
                                VALUES('{@sNo}', {@sSeq}, '{@sProdID}', '{@sProdType}', '{@sMangeNo}', '{@face}', {@sQty}, {@sDanga}, {@sAmount}, '{@sSMT}', '{@sPCB}', '{@sAssemble}', '{@sSusap}')
                            ON DUPLICATE KEY UPDATE 
                                prod_id = '{@sProdID}', prod_type = '{@sProdType}', reprod_id = '{@sMangeNo}', face = '{@face}', qty = {@sQty}, danga = {@sDanga}, amount = {@sAmount}, SMTProcessYN = '{@sSMT}', PCBProcessYN = '{@sPCB}', AssembleProcessYN = '{@sAssemble}', SusapProcessYN = '{@sSusap}'";

                    m.dbCUD(sql, ref msg);

                    data = sql;
                    result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);
                }
            }

            tbSearch.Text = "";
            ListSearch1();

            for (int i = 0; i < dataGridViewList.Rows.Count; i++)
            {
                if (dataGridViewList.Rows[i].Cells[2].Value.ToString() == sNo)
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
            lblMsg.Text = "저장되었습니다.";
        }
        private void pbPrint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNo.Text))
            {
                lblMsg.Text = "저장된 수주정보만 출력 가능합니다.";
                return;
            }

            if (dataGridView1.RowCount <= 1) return;

            string reportFileName = "SmartMES_Giroei.Reports.P1B03_RORDER.rdlc";

            string reportParm1 = "납기일자 : ";
            string reportParm2 = "접수일자 : ";
            string reportParm3 = "";

            reportParm1 = reportParm1 + dtpDate.Value.ToString("yyyy-MM-dd");

            reportParm2 = reportParm2 + dtpDeliDate.Value.ToString("yyyy-MM-dd");

            reportParm3 = reportParm3 + "";

            ViewReport_H viewReport = new ViewReport_H();
            viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
            viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
            ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
            ReportParameter rp3 = new ReportParameter("ReportParameter3", reportParm3);
            viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });

            ReportDataSource rds = new ReportDataSource("DataSet1", sPROrderSubQueryBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }
        #endregion

        #region 수주번호 생성
        private string getROrderNo()
        {
            string sql = @"select UF_ROrderNoGenerator()";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
        private string getROrderSeq(string sNo)
        {
            string sql = @"select UF_ROrderSeqGenerator('" + sNo + "')";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
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
        #endregion

        #region 파일 첨부
        public void userButtonA1_Click(object sender, EventArgs e)
        {
            if (dataGridViewList.CurrentRow == null || dataGridViewList.CurrentRow.Index < 0) return;

            P1B03_RORDER_DOC sub = new P1B03_RORDER_DOC();
            sub.parentWin = this;
            sub.sNo = "1";
            sub.sParentCode = tbNo.Text;
            sub.sFileName = doc1.Tag.ToString();
            sub.ShowDialog();
        }
        public void userButtonA2_Click(object sender, EventArgs e)
        {
            if (dataGridViewList.CurrentRow == null || dataGridViewList.CurrentRow.Index < 0) return;

            P1B03_RORDER_DOC sub = new P1B03_RORDER_DOC();
            sub.parentWin = this;
            sub.sNo = "2";
            sub.sParentCode = tbNo.Text;
            sub.sFileName = doc2.Tag.ToString();
            sub.ShowDialog();
        }
        public void userButtonA3_Click(object sender, EventArgs e)
        {
            if (dataGridViewList.CurrentRow == null || dataGridViewList.CurrentRow.Index < 0) return;

            P1B03_RORDER_DOC sub = new P1B03_RORDER_DOC();
            sub.parentWin = this;
            sub.sNo = "3";
            sub.sParentCode = tbNo.Text;
            sub.sFileName = doc3.Tag.ToString();
            sub.ShowDialog();
        }
        public void userButtonA4_Click(object sender, EventArgs e)
        {
            if (dataGridViewList.CurrentRow == null || dataGridViewList.CurrentRow.Index < 0) return;

            P1B03_RORDER_DOC sub = new P1B03_RORDER_DOC();
            sub.parentWin = this;
            sub.sNo = "4";
            sub.sParentCode = tbNo.Text;
            sub.sFileName = doc4.Tag.ToString();
            sub.ShowDialog();
        }
        #endregion

    }
}
