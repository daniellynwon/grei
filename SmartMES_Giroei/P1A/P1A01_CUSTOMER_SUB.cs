// using SmartFactory;
using SmartFactory;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1A01_CUSTOMER_SUB : Form
    {
        public P1A01_CUSTOMER parentWin;
        private int rowIndex = 0;
        private string custCode = string.Empty;

        public P1A01_CUSTOMER_SUB()
        {
            InitializeComponent();
        }

        private void P1A01_CUSTOMER_SUB_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            string sql = @"SELECT saleman FROM BAS_customer WHERE useYN = 'Y' GROUP BY saleman ORDER BY saleman";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            DataTable table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbSaleMan.DataSource = table;
                cbSaleMan.ValueMember = "saleman";
                cbSaleMan.DisplayMember = "saleman";
            }

            if (lblTitle.Text.Substring(lblTitle.Text.Length - 4, 4) == "[추가]")
            {
                this.ActiveControl = tbCustName;
                cbGubun.SelectedIndex = 0;
            }
            else
            {
                rowIndex = parentWin.dataGridView1.CurrentCell.RowIndex;

                custCode = parentWin.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                tbCustName.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                tbCeo.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
                cbGubun.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
                tbBusiNo.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
                cbSaleMan.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[21].Value.ToString();
                tbPostNo.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[11].Value.ToString();
                tbAddr1.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[12].Value.ToString();
                tbAddr2.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[13].Value.ToString();
                tbTel.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[15].Value.ToString();
                tbFax.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[16].Value.ToString();
                tbCustMan.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[17].Value.ToString();
                tbHp.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[18].Value.ToString();
                tbAdjust.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[19].Value.ToString();
                tbEmail.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[22].Value.ToString();
                //tbContents.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[22].Value.ToString();

                tbUptae.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[9].Value.ToString();
                tbJongmok.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[10].Value.ToString();


                if (parentWin.dataGridView1.Rows[rowIndex].Cells[23].Value.ToString() == "X")
                    cbFlag.Checked = true;

                this.ActiveControl = btnSave;
            }
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

        #region 주소
        private void lblPost_Click(object sender, EventArgs e)
        {
            PostAddr post = new PostAddr();
            post.FormSendEvent += new PostAddr.FormSendDataHandler(PostEventMethod);
            post.ShowDialog();
        }
        private void PostEventMethod(object sender)
        {
            string sAddr = sender.ToString();

            if (string.IsNullOrEmpty(sAddr)) return;

            tbPostNo.Text = sAddr.Substring(1, 5);
            tbAddr1.Text = sAddr.Substring(7, sAddr.Length - 7);
            tbAddr2.Focus();
        }
        #endregion

        #region 텍스트 박스 숫자 처리
        private void tbQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string lgsText;

                lgsText = tbAdjust.Text.Replace(",", ""); //** 숫자변환시 콤마로 발생하는 에러방지...
                tbAdjust.Text = String.Format("{0:#,##0}", Convert.ToDouble(lgsText));

                tbAdjust.SelectionStart = tbAdjust.TextLength; //** 캐럿을 맨 뒤로 보낸다...
                tbAdjust.SelectionLength = 0;
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

        #region 거래처코드 생성 / 거래처명 확인
        private string getCustCode()
        {
            string sql = @"select UF_CustCodeGenerator('A')";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
        private bool isCustName(string _custName)
        {
            string sql = @"SELECT cust_id FROM BAS_customer WHERE fullname = '" + _custName + "' or abbname = '" + _custName + "'";

            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            object id = m.dbRonlyOne(sql, ref msg);

            if (msg == "OK" && id != null)
                return true;
            else
                return false;
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
        private async void Save()
        {
            lblMsg.Text = "";

            string sCustName = tbCustName.Text.Trim();

            if (String.IsNullOrEmpty(sCustName))
            {
                lblMsg.Text = "거래처명을 입력해 주세요.";
                tbCustName.Focus();
                return;
            }

            string sCeo = tbCeo.Text.Trim();
            string sGubun = cbGubun.Text.Substring(0, 1);
            string sBusiNo = tbBusiNo.Text.Trim();
            string sSaleMan = cbSaleMan.Text.Trim();
            string sPostNo = tbPostNo.Text.Trim();
            string sAddr1 = tbAddr1.Text.Trim();
            string sAddr2 = tbAddr2.Text.Trim();
            string sTel = tbTel.Text.Trim();
            string sFax = tbFax.Text.Trim();
            string sCustMan = tbCustMan.Text.Trim();
            string sManHp = tbHp.Text.Trim();
            string sContents = tbContents.Text.Trim();
            string sAdjust = tbAdjust.Text.Trim();
            if (string.IsNullOrEmpty(sAdjust)) sAdjust = "0";

            string sUptae = tbUptae.Text.Trim();
            string sJongmok = tbJongmok.Text.Trim();

            string sFlag = "Y";
            if (cbFlag.Checked) sFlag = "N";

            string sEmail = tbEmail.Text.Trim();

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            if (Convert.ToInt32(sAdjust) > 31)
            {
                lblMsg.Text = "정산마감일은 날짜만(1 ~ 31) 입력 가능합니다. 미입력시 0으로 초기화됩니다.";
                tbAdjust.Focus();
                return;
            }

            if (lblTitle.Text.Substring(lblTitle.Text.Length - 4, 4) == "[추가]")
            {
                //입력한 거래처명이 중복인지 확인..
                if (isCustName(sCustName))
                {
                    lblMsg.Text = "이미 존재하는 거래처명입니다.";
                    tbCustName.Focus();
                    return;
                }

                custCode = getCustCode();

                sql = "INSERT INTO BAS_customer (cust_id, fullname, abbname, gubun, busi_no, ceo, uptae, jongmog ,post_no, address1, address2, tel, fax, cust_man, man_hp, adjust_date, saleman, email, contents, useYN, enter_man) " +
                    "VALUES('" + custCode + "','" + sCustName + "','" + sCustName + "'," + sGubun + ",'" + sBusiNo + "','" + sCeo + "','" + sUptae + "','" + sJongmok + "','" + sPostNo + "','" + sAddr1 + "','" + sAddr2 + "','" + sTel + "','" + sFax + "','" + sCustMan + "','" + sManHp + "'," + sAdjust + ",'" + sSaleMan + "','" + sEmail + "','" + sContents + "','" + sFlag + "','" + G.UserID + "')";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = "데이터 처리에 실패했습니다.";
                    return;
                }

                lblMsg.Text = "저장되었습니다.";

                var data = sql;
                var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);

                //var data = custCode + "','" + sCustName + "','" + sCustName + "'," + sGubun + ",'" + sBusiNo + "','" + sCeo + "','" + sUptae + "','" + sJongmok + "','" + sPostNo + "','" + sAddr1 + "','" + sAddr2 + "','" + sTel + "','" + sFax + "','" + sCustMan + "','" + sManHp + "','" + sSaleMan + "','" + sContents + "','" + sFlag + "','" + G.UserID;
                //var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);

                parentWin.ListSearch();

                for (int i = 0; i < parentWin.dataGridView1.Rows.Count; i++)
                {
                    if (parentWin.dataGridView1.Rows[i].Cells[1].Value.ToString() == custCode)
                    {
                        parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[0, i];
                        parentWin.dataGridView1.CurrentCell.Selected = true;
                        break;
                    }
                }

                tbCustName.Text = string.Empty;
                tbCeo.Text = string.Empty;
                tbBusiNo.Text = string.Empty;
                tbPostNo.Text = string.Empty;
                tbAddr1.Text = string.Empty;
                tbAddr2.Text = string.Empty;
                tbTel.Text = string.Empty;
                tbFax.Text = string.Empty;
                tbCustMan.Text = string.Empty;
                tbHp.Text = string.Empty;
                tbContents.Text = string.Empty;
                tbUptae.Text = string.Empty;
                tbJongmok.Text = string.Empty;
                tbCustName.Focus();
            }
            else
            {
                sql = "UPDATE BAS_customer " +
                    "SET fullname = '" + sCustName + "', abbname = '" + sCustName + "', gubun = " + sGubun + ", busi_no = '" + sBusiNo + "', ceo = '" + sCeo + "', uptae = '" + sUptae + "', jongmog = '" + sJongmok + "', post_no = '" + sPostNo + "', address1 = '" + sAddr1 + "', address2 = '" + sAddr2 + "', tel = '" + sTel + "', fax = '" + sFax + "', cust_man = '" + sCustMan + "', man_hp = '" + sManHp + "', adjust_date = " + sAdjust + ", saleman = '" + sSaleMan + "', email = '" + sEmail + "', contents = '" + sContents + "', useYN = '" + sFlag + "' " +
                    " WHERE cust_id = '" + custCode + "'";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }

                m.TransLogCreate(G.Authority, G.UserID, "M", this.Name, lblTitle.Text, custCode + " " + sCustName);

                var data = sql;
                var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);

                parentWin.ListSearch();
                parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[0, rowIndex];
                parentWin.dataGridView1.Rows[rowIndex].Selected = true;
                this.DialogResult = DialogResult.OK;
            }
        }
        #endregion
    }
}
