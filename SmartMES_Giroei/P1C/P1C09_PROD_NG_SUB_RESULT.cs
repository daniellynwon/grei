using SmartFactory;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1C09_PROD_NG_SUB_RESULT : Form
    {
        public P1C02_PROD_RESULT parentWin;
        public string job_no;

        private int rowIndex = 0;
        private string useID;

        public P1C09_PROD_NG_SUB_RESULT()
        {
            InitializeComponent();
        }

        private void P1C09_PROD_NG_SUB_RESULT_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            tbJobNo.Text = job_no;
            tbJobSeq.Text = (int.Parse(job_no.Split('-')[1])).ToString();

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            string sql = string.Empty;

            DataTable table;

            sql = @"SELECT co_code, co_item FROM BAS_common WHERE co_kind = 'L' ORDER BY co_code";

            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbInsCode.DataSource = table;
                cbInsCode.ValueMember = "co_code";
                cbInsCode.DisplayMember = "co_item";
            }

            sql = @"SELECT co_code, co_item FROM BAS_common WHERE co_kind = 'G' ORDER BY co_code";

            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbDefectPart.DataSource = table;
                cbDefectPart.ValueMember = "co_code";
                cbDefectPart.DisplayMember = "co_item";
            }

            if (parentWin.dataGridView1.Rows[rowIndex].Cells[37].Value.ToString() == "")
            {
                this.ActiveControl = tbDefectQty;
            }
            else
            {
                rowIndex = parentWin.dataGridView1.CurrentCell.RowIndex;

                tbJobNo.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                tbJobNo.Tag = parentWin.dataGridView1.Rows[rowIndex].Cells[37].Value.ToString(); //불량ID
                cbInsCode.SelectedValue = parentWin.dataGridView1.Rows[rowIndex].Cells[38].Value.ToString();
                dtpInsDate.Value = DateTime.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[40].Value.ToString());
                tbDefectQty.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[41].Value.ToString();
                cbDefectPart.SelectedValue = parentWin.dataGridView1.Rows[rowIndex].Cells[42].Value.ToString();
                tbBigo.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[44].Value.ToString();

                this.ActiveControl = tbDefectQty;
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

        #region 텍스트 박스 숫자 처리
        private void tbDefectQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string lgsText;

                lgsText = tbDefectQty.Text.Replace(",", ""); //** 숫자변환시 콤마로 발생하는 에러방지...
                tbDefectQty.Text = String.Format("{0:#,##0}", Convert.ToDouble(lgsText));

                tbDefectQty.SelectionStart = tbDefectQty.TextLength; //** 캐럿을 맨 뒤로 보낸다...
                tbDefectQty.SelectionLength = 0;
            }
            catch (FormatException)
            {
                return;
            }
        }
        private void tbDefectQty_KeyPress(object sender, KeyPressEventArgs e)
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

            //if (tbInsCode.Text == null)
            //{
            //    lblMsg.Text = "검사코드를 선택해 주세요.";

            //    tbInsCode.Focus();

            //    return;
            //}

            string sJobNo = tbJobNo.Text;
            string sJobSeq = tbJobSeq.Text;

            string sInsCode = cbInsCode.SelectedValue.ToString();
            string sInsDate = dtpInsDate.Value.ToString("yyyy-MM-dd");

            string sDefectQty = tbDefectQty.Text.Replace(",", "").Trim();
            string sDefectPart = cbDefectPart.SelectedValue.ToString();

            string sBigo = tbBigo.Text;

            MariaCRUD m = new MariaCRUD();

            string sql = string.Empty;
            string msg = string.Empty;

            sql = "INSERT INTO PRD_defect (job_no, job_seq, ins_code, ins_date, defect_qty, defect_part, bigo, reg_man) " +
                    "VALUES('" + sJobNo + "', '" + sJobSeq + "', '" + sInsCode + "', '" + sInsDate + "', " + sDefectQty + ", '" + sDefectPart + "', '" + sBigo + "', '" + G.UserID + "')";

            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            var data = sql;
            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);

            lblMsg.Text = "저장되었습니다.";

            //parentWin.ListSearch2(sJobNo);

            tbJobSeq.Text = string.Empty;

            cbInsCode.SelectedIndex = 0;
            dtpInsDate.Value = DateTime.Today;

            tbDefectQty.Text = "0";
            cbDefectPart.SelectedIndex = 0;
            tbBigo.Text = string.Empty;

            lblMsg.Focus();
        }
        #endregion
    }
}