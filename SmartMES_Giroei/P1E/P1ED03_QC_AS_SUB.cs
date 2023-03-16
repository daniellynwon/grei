﻿using SmartFactory;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1ED03_QC_AS_SUB : Form
    {
        public P1ED03_QC_AS parentWin;
        private int rowIndex = 0;

        public P1ED03_QC_AS_SUB()
        {
            InitializeComponent();
        }
        private void P1ED03_QC_AS_SUB_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            string sql = @"SELECT user_id, user_name FROM SYS_user WHERE authority IN ('B','C') AND useYN = 'Y' ORDER BY user_name";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            DataTable table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbCharge.DataSource = table;
                cbCharge.ValueMember = "user_id";
                cbCharge.DisplayMember = "user_name";
            }


            if (lblTitle.Text.Substring(lblTitle.Text.Length - 4, 4) == "[추가]")
            {
                cbState.SelectedIndex = 1; //처리중
                cbCharge.SelectedValue = G.UserID;
                this.ActiveControl = lblDeliID;
            }
            else
            {
                try
                {
                    rowIndex = parentWin.dataGridView1.CurrentCell.RowIndex;

                    tbNo.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                    cbState.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[13].Value.ToString();
                    tbDeli.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                    tbQty.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
                    dtpClaimDate.Value = DateTime.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[6].Value.ToString());
                    tbClaimContents.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
                    dtpActionDate.Value = DateTime.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[8].Value.ToString());
                    tbActionContents.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[9].Value.ToString();
                    tbMoney.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[10].Value.ToString();
                    cbCharge.SelectedValue = parentWin.dataGridView1.Rows[rowIndex].Cells[11].Value.ToString();

                    this.ActiveControl = btnSave;
                }
                catch (FormatException)
                {
                    return;
                }
            }
        }
        private void Save()
        {
            lblMsg.Text = "";

            if (string.IsNullOrEmpty(tbDeli.Text))
            {
                lblMsg.Text = "수주번호를 입력해 주세요.";
                lblDeliID.Focus();
                return;
            }

            if (cbCharge.SelectedValue == null
                || string.IsNullOrEmpty(cbCharge.SelectedValue.ToString()))
            {
                lblMsg.Text = "책임자를 선택해 주세요.";
                cbCharge.Focus();
                return;
            }

            string sCode = tbNo.Text;
            string sDeliID = tbDeli.Text;
            string sQty = tbQty.Text.Replace(",", "").Trim();
            if (string.IsNullOrEmpty(sQty)) sQty = "NULL";
            string sClaimDate = dtpClaimDate.Value.ToString("yyyy-MM-dd");
            string sClaimContents = tbClaimContents.Text.Trim();
            string sActionDate = dtpActionDate.Value.ToString("yyyy-MM-dd");
            string sActionContents = tbActionContents.Text.Trim();
            string sMoney = tbMoney.Text.Replace(",", "").Trim();
            if (string.IsNullOrEmpty(sMoney)) sMoney = "0";
            string sCharge = cbCharge.SelectedValue.ToString();
            string sState = cbState.Text.Substring(0, 1);

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            if (lblTitle.Text.Substring(lblTitle.Text.Length - 4, 4) == "[추가]")
            {
                sCode = getCode();

                sql = "insert into SRV_claims (claim_id, order_id, claim_qty, claim_date, claim_contents, action_date, action_contents, claim_money, charge, state_flag, enter_man) " +
                    "values('" + sCode + "','" + sDeliID + "'," + sQty + ",'" + sClaimDate + "','" + sClaimContents + "', IF('" + sActionContents + "' = '',null,'" + sActionDate + "'),'" + sActionContents + "'," + sMoney + ",'" + sCharge + "'," + sState + ",'" + G.UserID + "')";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }

                var data = sql;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);

                lblMsg.Text = "저장되었습니다.";

                parentWin.ListSearch();

                for (int i = 0; i < parentWin.dataGridView1.Rows.Count; i++)
                {
                    if (parentWin.dataGridView1.Rows[i].Cells[0].Value != null)
                    {
                        if (parentWin.dataGridView1.Rows[i].Cells[0].Value.ToString() == sCode)
                        {
                            parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[0, i];
                            parentWin.dataGridView1.CurrentCell.Selected = true;
                            break;
                        }
                    }
                }

                tbDeli.Text = string.Empty;
                tbQty.Text = string.Empty;
                tbClaimContents.Text = string.Empty;
                tbActionContents.Text = string.Empty;
                tbMoney.Text = string.Empty;
            }
            else
            {
                sql = "update SRV_claims " +
                    "set order_id = '" + sDeliID + "', claim_qty = " + sQty + ", claim_date = '" + sClaimDate + "', claim_contents = '" + sClaimContents + "', action_date = IF('" + sActionContents + "' = '',null,'" + sActionDate + "'), action_contents = '" + sActionContents + "', claim_money = " + sMoney + ", charge = '" + sCharge + "', state_flag = " + sState +
                    " where claim_id = '" + sCode + "'";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }

                m.TransLogCreate(G.Authority, G.UserID, "M", this.Name, lblTitle.Text, sCode + " - " + sDeliID);

                var data = sql;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);

                parentWin.ListSearch();
                parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[0, rowIndex];
                parentWin.dataGridView1.Rows[rowIndex].Selected = true;
                this.DialogResult = DialogResult.OK;
            }
        }

        //private void Save()
        //{
        //    lblMsg.Text = "";

        //    if (string.IsNullOrEmpty(tbDeli.Text))
        //    {
        //        lblMsg.Text = "출하(전표)번호를 입력해 주세요.";
        //        lblDeliID.Focus();
        //        return;
        //    }

        //    if (cbCharge.SelectedValue == null
        //        || string.IsNullOrEmpty(cbCharge.SelectedValue.ToString()))
        //    {
        //        lblMsg.Text = "책임자를 선택해 주세요.";
        //        cbCharge.Focus();
        //        return;
        //    }

        //    string sCode = tbNo.Text;
        //    string sDeliID = tbDeli.Text;
        //    string sQty = tbQty.Text.Replace(",", "").Trim();
        //    if (string.IsNullOrEmpty(sQty)) sQty = "NULL";
        //    string sClaimDate = dtpClaimDate.Value.ToString("yyyy-MM-dd");
        //    string sClaimContents = tbClaimContents.Text.Trim();
        //    string sActionDate = dtpActionDate.Value.ToString("yyyy-MM-dd");
        //    string sActionContents = tbActionContents.Text.Trim();
        //    string sMoney = tbMoney.Text.Replace(",", "").Trim();
        //    if (string.IsNullOrEmpty(sMoney)) sMoney = "0";
        //    string sCharge = cbCharge.SelectedValue.ToString();
        //    string sState = cbState.Text.Substring(0, 1);

        //    string sql = string.Empty;
        //    string msg = string.Empty;
        //    MariaCRUD m = new MariaCRUD();

        //    if (lblTitle.Text.Substring(lblTitle.Text.Length - 4, 4) == "[추가]")
        //    {
        //        sCode = getCode();

        //        sql = "insert into tb_qc_claim (claim_id, deli_id, claim_qty, claim_date, claim_contents, action_date, action_contents, claim_money, charge, state_flag, enter_man) " +
        //            "values('" + sCode + "','" + sDeliID + "'," + sQty + ",'" + sClaimDate + "','" + sClaimContents + "', IF('" + sActionContents + "' = '',null,'" + sActionDate + "'),'" + sActionContents + "'," + sMoney + ",'" + sCharge + "'," + sState + ",'" + G.UserID + "')";

        //        m.dbCUD(sql, ref msg);

        //        if (msg != "OK")
        //        {
        //            lblMsg.Text = msg;
        //            return;
        //        }

        //        var data = sql;
        //        Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);

        //        lblMsg.Text = "저장되었습니다.";

        //        parentWin.ListSearch();

        //        for (int i = 0; i < parentWin.dataGridView1.Rows.Count; i++)
        //        {
        //            if (parentWin.dataGridView1.Rows[i].Cells[0].Value.ToString() == sCode)
        //            {
        //                parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[0, i];
        //                parentWin.dataGridView1.CurrentCell.Selected = true;
        //                break;
        //            }
        //        }

        //        tbDeli.Text = string.Empty;
        //        tbQty.Text = string.Empty;
        //        tbClaimContents.Text = string.Empty;
        //        tbActionContents.Text = string.Empty;
        //        tbMoney.Text = string.Empty;
        //    }
        //    else
        //    {
        //        sql = "update tb_qc_claim " +
        //            "set deli_id = '" + sDeliID + "', claim_qty = " + sQty + ", claim_date = '" + sClaimDate + "', claim_contents = '" + sClaimContents + "', action_date = IF('" + sActionContents + "' = '',null,'" + sActionDate + "'), action_contents = '" + sActionContents + "', claim_money = " + sMoney + ", charge = '" + sCharge + "', state_flag = " + sState +
        //            " where claim_id = '" + sCode + "'";

        //        m.dbCUD(sql, ref msg);

        //        if (msg != "OK")
        //        {
        //            lblMsg.Text = msg;
        //            return;
        //        }

        //        m.TransLogCreate(G.Authority, G.UserID, "M", this.Name, lblTitle.Text, sCode + " - " + sDeliID);

        //        var data = sql;
        //        Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);

        //        parentWin.ListSearch();
        //        parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[0, rowIndex];
        //        parentWin.dataGridView1.Rows[rowIndex].Selected = true;
        //        this.DialogResult = DialogResult.OK;
        //    }
        //}

        #region 사후관리 접수번호 생성
        private string getCode()
        {
            string sql = @"select UF_ClaimNoGenerator()";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
        #endregion

        #region 출하번호
        private void lblDeliID_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            P1ED03_QC_AS_DELI pop = new P1ED03_QC_AS_DELI();
            pop.FormSendEvent += new P1ED03_QC_AS_DELI.FormSendDataHandler(DeliEventMethod);

            pop.ShowDialog();
        }  
        private void DeliEventMethod(object sender)
        {
            string sNo = sender.ToString();

            if (string.IsNullOrEmpty(sNo)) return;

            tbDeli.Text = sNo;
            tbQty.Focus();
        }
        #endregion

        #region 텍스트 박스 숫자 처리
        private void tbQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string lgsText;

                lgsText = tbQty.Text.Replace(",", ""); //** 숫자변환시 콤마로 발생하는 에러방지...
                tbQty.Text = String.Format("{0:#,##0}", Convert.ToDouble(lgsText));

                tbQty.SelectionStart = tbQty.TextLength; //** 캐럿을 맨 뒤로 보낸다...
                tbQty.SelectionLength = 0;
            }
            catch (FormatException)
            {
                return;
            }
        }
        private void tbMoney_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string lgsText;

                lgsText = tbMoney.Text.Replace(",", ""); //** 숫자변환시 콤마로 발생하는 에러방지...
                tbMoney.Text = String.Format("{0:#,##0}", Convert.ToDouble(lgsText));

                tbMoney.SelectionStart = tbMoney.TextLength; //** 캐럿을 맨 뒤로 보낸다...
                tbMoney.SelectionLength = 0;
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

        #region 버튼
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion
    }
}
