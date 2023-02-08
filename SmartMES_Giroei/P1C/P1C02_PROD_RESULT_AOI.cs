using SmartFactory;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1C02_PROD_RESULT_AOI : Form
    {
        public P1C02_PROD_RESULT parentWin;
        private int rowIndex = 0;
        public string rorderID, rorderSeq;
        public string job_no;

        public P1C02_PROD_RESULT_AOI()
        {
            InitializeComponent();
        }
        private void P1C02_PROD_RESULT_AOI_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            string sql = "select user_id, user_name from SYS_user where authority in ('A','B','C') and useYN = 'Y'";
            //string sql = "select user_id, user_name from SYS_user where authority = 'A' and useYN = 'Y'";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            DataTable table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbMan.DataSource = table;
                cbMan.ValueMember = "user_id";
                cbMan.DisplayMember = "user_name";
            }
            
            rowIndex = parentWin.dataGridView1.CurrentCell.RowIndex;

            tbProdName.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[5].Value.ToString(); // 품목명
            tbProdName.Tag = parentWin.dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();  // 품목코드
            string sJobNo = parentWin.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString(); // JobNo

            sql = "select * from QLT_inspection_AOI where job_no = '" + sJobNo + "' limit 1";
            table = m.dbDataTable(sql, ref msg);

            if (table.Rows.Count < 1) {
                lblMsg.Text = "저장된 Detail정보가 없습니다.";
            } else
            {
                DataRow[] row = table.Select();
                if (row.Length > 0) 
                {
                    tbJobTimeStart.Text = row[0][2].ToString();
                    tbJobTimeFinish.Text = row[0][3].ToString();
                    tbInspCount.Text = row[0][4].ToString();
                    tbTotalDefect.Text = row[0][5].ToString();
                    tbSonap.Text = row[0][6].ToString();
                    tbnengttaem.Text = row[0][7].ToString();
                    tbMiSap.Text = row[0][8].ToString();
                    tbOverTurned.Text = row[0][9].ToString();
                    tbLeadOpen.Text = row[0][10].ToString();
                    tbMiNap.Text = row[0][11].ToString();
                    tbShort.Text = row[0][12].ToString();
                    tbReverse.Text = row[0][13].ToString();
                    tbManhattan.Text = row[0][14].ToString();
                    tbTwisted.Text = row[0][15].ToString();
                    tbEtcError.Text = row[0][16].ToString();
                    rtbContents.Text = row[0][17].ToString();
                    cbMan.Text = row[0][18].ToString();
                }

            }

            this.ActiveControl = btnSave;
        }

        private void Save()
        {
            //lblMsg.Text = "";

            //string sJobTimeA = ""; string sJobTimeB = "";
            //if (tbJobTimeStart.Text.Length == 19) sJobTimeA = tbJobTimeStart.Text;
            //else
            //{
            //    lblMsg.Text = "체크시작시간을 확인하세요."; return;
            //}

            //if (tbJobTimeFinish.Text.Length == 19) sJobTimeB = tbJobTimeFinish.Text;
            //else
            //{
            //    lblMsg.Text = "체크완료시간을 확인하세요."; return;
            //}

            //string sNo = lblLotNo.Text;
            //string baking = "1"; string spi = "1"; string polarity = "1"; string matLoss = "1"; string feedback = "1"; string noinst = "1"; string solder = "1";

            //if (rbNg1.Checked) baking = "0";
            //if (rbNg2.Checked) spi = "0";
            //if (rbNg3.Checked) polarity = "0";
            //if (rbNg4.Checked) matLoss = "0";
            //if (rbNg5.Checked) feedback = "0";
            //if (rbNg6.Checked) noinst = "0";
            //if (rbNg7.Checked) solder = "0";
            //string sMan = cbMan.SelectedValue.ToString();

            //string msg = string.Empty;
            //MariaCRUD m = new MariaCRUD();
            //string sql = string.Empty;

            //if(lblChkID.Text == "")
            //{
            //    sql = "insert into PRD_check_spec (id, job_no, start_time, end_time, baking, spi, polarity, mat_loss, feedback, noinsert, solder_status, check_man)" +
            //            " values(null, '" + sNo + "','" + sJobTimeA + "','" + sJobTimeB + "'," + baking + "," + spi + "," + polarity + "," + matLoss + "," + feedback + "," + noinst + "," + solder + ",'" + sMan + "')";
            //            //+
            //            //" on duplicate key update" +
            //            //" job_no = '" + sNo + "',start_time = '" + sJobTimeA + "', end_time = '" + sJobTimeB + "', baking = " + baking + ", spi = " + spi + ", polarity = " + polarity + ", mat_loss = " + matLoss + ", feedback = " + feedback + ", noinsert = " + noinst + ", solder_status = " + solder + ", check_man = '" + sMan + "'";
            //    m.dbCUD(sql, ref msg);

            //    if (msg != "OK")
            //    {
            //        lblMsg.Text = msg;
            //        return;
            //    }

            //    sql = "update SAL_order_sub set prod_status = 5 where order_id = '" + rorderID + "' and order_seq = " + rorderSeq;   // SAL_order_sub prod_status 4로 변경
            //    m.dbCUD(sql, ref msg);

            //    if (msg != "OK")
            //    {
            //        lblMsg.Text = msg;
            //        return;
            //    }
            //}
            //else
            //{
            //    sql = "update PRD_check_spec set job_no = '" + sNo + "', start_time = '" + sJobTimeA + "', end_time = '" + sJobTimeB + "', baking = " + baking + ", spi = " + spi + ", polarity = " + polarity + ", mat_loss = " + matLoss +
            //        ", feedback = " + feedback + ", noinsert = " + noinst + ", solder_status = " + solder + ", check_man = '" + sMan + "' "
            //        + "where id = " + lblChkID.Text;
            //    m.dbCUD(sql, ref msg);

            //    if (msg != "OK")
            //    {
            //        lblMsg.Text = msg;
            //        return;
            //    }
            //}
            //var data = sql;
            //Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);

            //lblMsg.Text = "저장되었습니다.";
            //this.Dispose();
            //parentWin.ListSearch();
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

        #region 버튼 이벤트
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                Save();
            }
        }
        #endregion

        #region 텍스트 박스 숫자 처리
        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        #endregion

        #region 검사시작/검사종료
        private void btnStart_Click(object sender, EventArgs e)
        {
            //lblMsg.Text = "";
            //if (string.IsNullOrEmpty(lblLotNo.Text)) // tbJobNo.Text
            //{
            //    lblMsg.Text = "해당 Lot를 추가해 주세요.";
            //    return;
            //}
            //if (!string.IsNullOrEmpty(tbJobTimeStart.Text))
            //{
            //    lblMsg.Text = "이미 시작된 검사입니다.";
            //    return;
            //}
            //if (!string.IsNullOrEmpty(tbJobTimeFinish.Text))
            //{
            //    lblMsg.Text = "이미 종료된 검사입니다.";
            //    return;
            //}

            //tbJobTimeStart.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        }

        private void btnFile1_Click(object sender, EventArgs e)
        {
            P1C02_PROD_RESULT_AOI_DOC newdoc = new P1C02_PROD_RESULT_AOI_DOC();
            newdoc.ShowDialog();
        }

        private void btnFile2_Click(object sender, EventArgs e)
        {

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //lblMsg.Text = "";
            //if (string.IsNullOrEmpty(lblLotNo.Text)) // tbJobNo.Text
            //{
            //    lblMsg.Text = "해당 Lot를 추가해 주세요.";
            //    return;
            //}
            //if (string.IsNullOrEmpty(tbJobTimeStart.Text))
            //{
            //    lblMsg.Text = "검사가 시작되지 않았습니다.";
            //    return;
            //}
            //if (!string.IsNullOrEmpty(tbJobTimeFinish.Text))
            //{
            //    lblMsg.Text = "이미 종료된 검사입니다.";
            //    return;
            //}

            //tbJobTimeFinish.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion
    }
}
