using SmartFactory;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1D03_MAINTENANCE_SUB : Form
    {
        public P1D03_MAINTENANCE parentWin;

        private int rowIndex = 0;
        private string machineID = string.Empty;
        private string seq = string.Empty;
        private string id = string.Empty;

        public P1D03_MAINTENANCE_SUB()
        {
            InitializeComponent();
        }

        private void P1D03_MAINTENANCE_SUB_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            if (lblTitle.Text.Substring(lblTitle.Text.Length - 4, 4) == "[추가]")
            {
                cbKind.SelectedIndex = 0;
                this.ActiveControl = tbGoal;
            }
            else
            {
                lblSelect.Enabled = false;
                lblSelect.ForeColor = lbHo.ForeColor;
                lblSelect.Font = new Font(lblSelect.Font, FontStyle.Regular);

                rowIndex = parentWin.dataGridView1.CurrentCell.RowIndex;

                id = parentWin.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                machineID = parentWin.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                
                tbHo.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                tbName.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                tbModel.Tag = parentWin.dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
                tbModel.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
                dtpRepairDate.Value = DateTime.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[6].Value.ToString());
                cbKind.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();

                if (parentWin.dataGridView1.Rows[rowIndex].Cells[8].Value != DBNull.Value)
                    dtpStartDate.Text = DateTime.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[8].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                else
                    dtpStartDate.Text = "";

                if (parentWin.dataGridView1.Rows[rowIndex].Cells[9].Value != DBNull.Value)
                    dtpEndDate.Text = DateTime.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[9].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                else
                    dtpEndDate.Text = "";
                
                tbGoal.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[10].Value.ToString();
                tbResult.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[11].Value.ToString();
                tbMan.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[12].Value.ToString();
                tbMoney.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[13].Value.ToString();
                tbContents.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[14].Value.ToString();

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

        #region 설비별 seq 생성
        private string getSeq(string _mid)
        {
            string sql = @"SELECT id FROM FMM_facility_repair WHERE machine_id = '" + _mid + "' ORDER BY id DESC LIMIT 1";

            MariaCRUD m = new MariaCRUD();

            try
            {
                string msg = string.Empty;
                string seq = m.dbRonlyOne(sql, ref msg).ToString();

                seq = (Int32.Parse(seq) + 1).ToString();

                return seq;
            }
            catch (NullReferenceException)
            {
                return "1";
            }

        }
        #endregion

        #region 텍스트 박스 숫자 처리
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
        private void tbMoney_KeyPress(object sender, KeyPressEventArgs e)
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

            if (string.IsNullOrEmpty(machineID))
            {
                lblMsg.Text = "설비정보를 확인해주세요.";
                lblSelect.Focus();
                return;
            }

            //if (string.IsNullOrEmpty(dtpStartDate.Text) || dtpStartDate.Text.Length != 19)
            //{
            //    lblMsg.Text = "고장일시를 확인해주세요";
            //    dtpStartDate.Focus();
            //    return;
            //}
            //if (string.IsNullOrEmpty(dtpStartDate.Text) && !(string.IsNullOrEmpty(dtpEndDate.Text)))
            //{
            //    lblMsg.Text = "고장일시를 입력하세요";
            //    dtpRepairDate.Focus();
            //    return;
            //}
            //if (string.IsNullOrEmpty(dtpDateB.Text))
            //{
            //    lblMsg.Text = "수리일시를 확인해주세요";
            //    dtpDateA.Focus();
            //    return;
            //}

            if (string.IsNullOrEmpty(dtpStartDate.Text) && !(string.IsNullOrEmpty(dtpEndDate.Text)))
            {
                lblMsg.Text = "수리시간을 확인해 주세요";
                dtpRepairDate.Focus();
                return;
            }

            string sDate = DateTime.Parse(dtpRepairDate.Value.ToString()).ToString("yyyy-MM-dd");
            //string sStartDate = dtpStartDate.Text;
            //string sEndDate = dtpEndDate.Text;
            string sStartDate = String.Empty;
            string sEndDate = String.Empty;

            if (dtpStartDate.Text.Length == 19) sStartDate = dtpStartDate.Text;
            else sStartDate = "";
            if (dtpEndDate.Text.Length == 19) sEndDate = dtpEndDate.Text;
            else sEndDate = "";

            string sKind = cbKind.Text.Substring(0, 1);
            string sGoal = tbGoal.Text.Trim();
            string sResult = tbResult.Text.Trim();
            string sMan = tbMan.Text.Trim();
            string sMoeny = tbMoney.Text.Replace(",", "").Trim();
            if (string.IsNullOrEmpty(sMoeny)) sMoeny = "NULL";
            string sContents = tbContents.Text.Trim();

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            if (lblTitle.Text.Substring(lblTitle.Text.Length - 4, 4) == "[추가]")
            {
                //seq = getSeq(machineID);

                //sql = "INSERT INTO FMM_facility_repair (machine_id, repair_date, repair_type, repair_gole, repair_result, repair_man, repair_money, contents, repair_start, repair_end, enter_man, enter_dt) " +
                //    "VALUES(" + machineID + "," + seq + ",'" + sDate + "','" + sDate1 + "',if('" + sDate2 + "' = '',null,'" + sDate2 + "')," + sKind + ",'" + sGoal + "','" + sResult + "','" + sMan + "'," + sMoeny + ",'" + sContents + "','" + G.UserID + "')";

                if (string.IsNullOrEmpty(sStartDate) && string.IsNullOrEmpty(sEndDate))
                {
                    sql = $@"INSERT INTO FMM_facility_repair (machine_id, repair_date, repair_type, repair_gole, repair_result, repair_man, repair_money, `contents`, repair_start, repair_end, enter_man, enter_dt)
                        VALUES('{@machineID}', '{@sDate}', {@sKind}, '{@sGoal}', '{@sResult}', '{@sMan}', {@sMoeny}, '{@sContents}', null, null, '{@G.UserID}', '{@DateTime.Now.ToString("yyyy-MM-dd")}')";
                }
                else if (string.IsNullOrEmpty(sEndDate))
                {
                    sql = $@"INSERT INTO FMM_facility_repair (machine_id, repair_date, repair_type, repair_gole, repair_result, repair_man, repair_money, `contents`, repair_start, repair_end, enter_man, enter_dt)
                        VALUES('{@machineID}', '{@sDate}', {@sKind}, '{@sGoal}', '{@sResult}', '{@sMan}', {@sMoeny}, '{@sContents}', '{@sStartDate}', null, '{@G.UserID}', '{@DateTime.Now.ToString("yyyy-MM-dd")}')";
                }
                else
                {
                    sql = $@"INSERT INTO FMM_facility_repair (machine_id, repair_date, repair_type, repair_gole, repair_result, repair_man, repair_money, `contents`, repair_start, repair_end, enter_man, enter_dt)
                        VALUES('{@machineID}', '{@sDate}', {@sKind}, '{@sGoal}', '{@sResult}', '{@sMan}', {@sMoeny}, '{@sContents}', '{@sStartDate}', '{@sEndDate}', '{@G.UserID}', '{@DateTime.Now.ToString("yyyy-MM-dd")}')";
                }

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

                for (int i = 0; i < parentWin.dataGridView1.Rows.Count - 1; i++)
                {
                    if (parentWin.dataGridView1.Rows[i].Cells[0].Value.ToString() == machineID
                        && DateTime.Parse(parentWin.dataGridView1.Rows[i].Cells[5].Value.ToString()).ToString("yyyy-MM-dd") == sDate
                        && parentWin.dataGridView1.Rows[i].Cells[6].Value.ToString().Substring(0, 1) == sKind)
                    {
                        parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[1, i];
                        parentWin.dataGridView1.CurrentCell.Selected = true;
                        break;
                    }
                }

                machineID = string.Empty;
                seq = string.Empty;
                tbHo.Text = string.Empty;
                dtpStartDate.Text = string.Empty;
                dtpEndDate.Text = string.Empty;
                tbName.Text = string.Empty;
                tbModel.Text = string.Empty;
                tbModel.Tag = string.Empty;
                tbGoal.Text = string.Empty;
                tbResult.Text = string.Empty;
                tbMan.Text = string.Empty;
                tbMoney.Text = string.Empty;
                tbContents.Text = string.Empty;
                tbGoal.Focus();
            }
            else // 수정 및 update
            {
                //sql = "update tb_machine_repair " +
                //    "set repair_date = '" + sDate + "', repairtime_a = '" + sDate1 + "', repairtime_b = if('" + sDate2 + "' = '',null,'" + sDate2 + "'), repair_kind = " + sKind + ", repair_goal = '" + sGoal + "', repair_result = '" + sResult + "', repair_man = '" + sMan + "', repair_money = " + sMoeny + ", contents = '" + sContents + "'" +
                //    " where machine_id = " + machineID + " and seq = " + seq;

                if (string.IsNullOrEmpty(sStartDate) && string.IsNullOrEmpty(sEndDate))
                {
                    sql = $@"UPDATE FMM_facility_repair
                            SET repair_date = '{@sDate}', repair_type = {@sKind}, repair_gole = '{@sGoal}', repair_result = '{@sResult}', repair_man = '{@sMan}', repair_money = {@sMoeny}, contents = '{@sContents}', repair_start = null, repair_end = null, enter_man = '{@G.UserID}', enter_dt = '{@DateTime.Now.ToString("yyyy-MM-dd")}' WHERE id = {@id}";
                }
                else if (string.IsNullOrEmpty(sEndDate))
                {
                    sql = $@"UPDATE FMM_facility_repair
                            SET repair_date = '{@sDate}', repair_type = {@sKind}, repair_gole = '{@sGoal}', repair_result = '{@sResult}', repair_man = '{@sMan}', repair_money = {@sMoeny}, contents = '{@sContents}', repair_start = '{@sStartDate}', repair_end = null, enter_man = '{@G.UserID}', enter_dt = '{@DateTime.Now.ToString("yyyy-MM-dd")}' WHERE id = {@id}";
                }
                else
                {
                    sql = $@"UPDATE FMM_facility_repair
                            SET repair_date = '{@sDate}', repair_type = {@sKind}, repair_gole = '{@sGoal}', repair_result = '{@sResult}', repair_man = '{@sMan}', repair_money = {@sMoeny}, contents = '{@sContents}', repair_start = '{@sStartDate}', repair_end = '{@sEndDate}', enter_man = '{@G.UserID}', enter_dt = '{@DateTime.Now.ToString("yyyy-MM-dd")}' WHERE id = {@id}";
                }

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }

                m.TransLogCreate(G.Authority, G.UserID, "M", this.Name, lblTitle.Text, machineID + "-" + seq + " " + tbName.Text + " " + tbModel.Text);

                var data = sql;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);

                parentWin.ListSearch();
                parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[3, rowIndex];
                parentWin.dataGridView1.Rows[rowIndex].Selected = true;
                this.DialogResult = DialogResult.OK;
            }
        }
        #endregion

        #region 설비선택
        private void lblSelect_Click(object sender, EventArgs e)
        {
            MachineFinder sub = new MachineFinder();
            sub.FormSendEvent += new MachineFinder.FormSendDataHandler(PostEventMethod);
            sub.ShowDialog();
        }
        private void PostEventMethod(object sender)
        {
            string sAddr = sender.ToString();

            if (string.IsNullOrEmpty(sAddr)) return;

            machineID = sAddr.Substring(0, sAddr.IndexOf("#1/"));
            tbHo.Text = sAddr.Substring(sAddr.IndexOf("#1/") + 3, sAddr.IndexOf("#2/") - (sAddr.IndexOf("#1/") + 3));
            tbName.Text = sAddr.Substring(sAddr.IndexOf("#2/") + 3, sAddr.IndexOf("#3/") - (sAddr.IndexOf("#2/") + 3));
            tbModel.Tag = sAddr.Substring(sAddr.IndexOf("#3/") + 3, sAddr.IndexOf("#4/") - (sAddr.IndexOf("#3/") + 3));
            tbModel.Text = sAddr.Substring(sAddr.IndexOf("#4/") + 3, sAddr.Length - (sAddr.IndexOf("#4/") + 3));
            tbGoal.Focus();
        }
        #endregion
    }
}