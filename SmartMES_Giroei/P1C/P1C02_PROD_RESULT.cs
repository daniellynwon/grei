using SmartFactory;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SmartMES_Giroei
{
    public partial class P1C02_PROD_RESULT : SmartMES_Giroei.FormBasic
    {
        public bool bMoltD = true;
        public bool bPunch1D = true;
        public bool bPunch2D = true;
        private DateTime SDT1 = DateTime.Now;
        private DateTime SDT3 = DateTime.Now;
        private bool isTimeStarted = false;


        public P1C02_PROD_RESULT()
        {
            InitializeComponent();
        }
        private void P1C02_PROD_RESULT_Shown(object sender, EventArgs e)
        {
            string sql = @"select co_code, co_item from BAS_common where co_kind = 'O' order by co_code";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            DataTable table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbWorkLine.DataSource = table;
                cbWorkLine.ValueMember = "co_code";
                cbWorkLine.DisplayMember = "co_item";
            }

            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();
        }
        private void P1C02_PROD_RESULT_Load(object sender, EventArgs e)
        {
            ListSearch();
            InitControls();
        }
        public void ListSearch()
        {
            lblMsg.Text = "";

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DateTime dtDate = DateTime.Parse(dtpDate.Value.ToString("yyyy-MM-dd"));
                sP_ProdResult_QueryTableAdapter.Fill(dataSetP1C.SP_ProdResult_Query, dtDate);

                var data = dataSetP1C.SP_ProdResult_Query;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

                dataGridView1.CurrentCell = null;
                dataGridView1.ClearSelection();

                InitControls();
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
        public void InitControls()
        {
            tbJobNo.Text = string.Empty; tbProd.Text = string.Empty; 
            tbQty.Tag = null; tbProd.Tag = null;
            tbQty.Text = string.Empty;
            tbGdQty.Text = string.Empty;
            tbNgQty.Text = string.Empty;
            tbUserCnt.Text = string.Empty;
            tbJobTimeStart.Text = string.Empty;
            tbJobTimeFinish.Text = string.Empty;
            //cbWorkLine.SelectedIndex = 0;
            tbMan.Text = string.Empty;
            tbContents.Text = string.Empty;

            bMoltD = false;
            bPunch1D = false;
            bPunch2D = false;
        }
        public void SettingValues(DataGridView dataGridView, int rowIndex)
        {
            try
            {
                lblMsg.Text = "";
                lblLotNo.Text = dataGridView.Rows[rowIndex].Cells[0].Value.ToString();   // tbJobNo.Text
                //cbWorkLine.SelectedValue = dataGridView.Rows[rowIndex].Cells[2].Value;
                tbProd.Tag = dataGridView.Rows[rowIndex].Cells[4].Value.ToString();
                tbProd.Text = dataGridView.Rows[rowIndex].Cells[5].Value.ToString();
                tbQty.Text = dataGridView.Rows[rowIndex].Cells[6].Value.ToString();
                tbGdQty.Text = dataGridView.Rows[rowIndex].Cells[7].Value.ToString();
                tbNgQty.Text = dataGridView.Rows[rowIndex].Cells[8].Value.ToString();
                tbMatnotop.Text = dataGridView.Rows[rowIndex].Cells[9].Value.ToString();
                tbMatnobot.Text = dataGridView.Rows[rowIndex].Cells[10].Value.ToString();
                tbMatpttop.Text = dataGridView.Rows[rowIndex].Cells[11].Value.ToString();
                tbMatptbot.Text = dataGridView.Rows[rowIndex].Cells[12].Value.ToString();
                tbInstTop.Text = dataGridView.Rows[rowIndex].Cells[13].Value.ToString();
                tbInstBot.Text = dataGridView.Rows[rowIndex].Cells[14].Value.ToString();
                tbJobNo.Text = dataGridView.Rows[rowIndex].Cells[45].Value.ToString();
                tbMakeQty.Text = dataGridView.Rows[rowIndex].Cells[49].Value.ToString();
                tbShowQty.Text = dataGridView.Rows[rowIndex].Cells[50].Value.ToString(); //검사수
                tbCust.Text = dataGridView.Rows[rowIndex].Cells[52].Value.ToString(); //업체명
                if (dataGridView.Rows[rowIndex].Cells[51].Value == null || string.IsNullOrEmpty(dataGridView.Rows[rowIndex].Cells[51].Value.ToString())) //AOI완료시간
                    tbAOITimeFinish.Text = "";
                else
                    tbAOITimeFinish.Text = DateTime.Parse(dataGridView.Rows[rowIndex].Cells[51].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");

                if (dataGridView.Rows[rowIndex].Cells[15].Value == null || string.IsNullOrEmpty(dataGridView.Rows[rowIndex].Cells[15].Value.ToString()))
                    tbJobTimeStart.Text = "";
                else
                    tbJobTimeStart.Text = DateTime.Parse(dataGridView.Rows[rowIndex].Cells[15].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");

                if (dataGridView.Rows[rowIndex].Cells[16].Value == null || string.IsNullOrEmpty(dataGridView.Rows[rowIndex].Cells[16].Value.ToString()))
                    tbJobTimeFinish.Text = "";
                else
                    tbJobTimeFinish.Text = DateTime.Parse(dataGridView.Rows[rowIndex].Cells[16].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");

                tbUserCnt.Text = dataGridView.Rows[rowIndex].Cells[17].Value.ToString();
                tbContents.Text = dataGridView.Rows[rowIndex].Cells[18].Value.ToString();

                if (dataGridView.Rows[rowIndex].Cells[22].Value == null || string.IsNullOrEmpty(dataGridView.Rows[rowIndex].Cells[22].Value.ToString()))
                    tbStartTime.Text = "";
                else
                    tbStartTime.Text = DateTime.Parse(dataGridView.Rows[rowIndex].Cells[22].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");

                if (dataGridView.Rows[rowIndex].Cells[23].Value == null || string.IsNullOrEmpty(dataGridView.Rows[rowIndex].Cells[23].Value.ToString()))
                    tbFinishTime.Text = "";
                else
                    tbFinishTime.Text = DateTime.Parse(dataGridView.Rows[rowIndex].Cells[23].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (System.NullReferenceException)
            {
                return;
            }
        }

        #region Condition Bar Events1
        private void userButtonA1_Click(object sender, EventArgs e)
        {
            dtpDate.Value = dtpDate.Value.AddDays(-1);
            ListSearch();
        }
        private void userButtonA2_Click(object sender, EventArgs e)
        {
            dtpDate.Value = dtpDate.Value.AddDays(1);
            ListSearch();
        }
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
        #endregion

        #region GridView Events
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridView dgv = (DataGridView)sender;
            int rowIndex = dgv.CurrentCell.RowIndex;

            SettingValues(dgv, rowIndex);
            //set_production_result();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (G.Authority == "D") return;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 24) return;    // 사양점검

            P1C02_PROD_RESULT_SUB sub = new P1C02_PROD_RESULT_SUB();
            sub.lblLotNo.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            sub.lblChkID.Text = dataGridView1.Rows[e.RowIndex].Cells[35].Value.ToString();
            sub.rorderID = dataGridView1.Rows[e.RowIndex].Cells[45].Value.ToString();       // 11/9 추가 수주번호,순번
            sub.rorderSeq = dataGridView1.Rows[e.RowIndex].Cells[46].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[25].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[25].Value.ToString())) sub.tbJobTimeStart.Text = "";
            else
                sub.tbJobTimeStart.Text = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[25].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            if (dataGridView1.Rows[e.RowIndex].Cells[26].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[26].Value.ToString())) sub.tbJobTimeFinish.Text = "";
            else
                sub.tbJobTimeFinish.Text = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[26].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            sub.cbMan.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[34].Value.ToString();

            if (dataGridView1.Rows[e.RowIndex].Cells[27].Value.ToString() == "0") sub.rbNg1.Checked = true;
            if (dataGridView1.Rows[e.RowIndex].Cells[28].Value.ToString() == "0") sub.rbNg2.Checked = true;
            if (dataGridView1.Rows[e.RowIndex].Cells[29].Value.ToString() == "0") sub.rbNg3.Checked = true;
            if (dataGridView1.Rows[e.RowIndex].Cells[30].Value.ToString() == "0") sub.rbNg4.Checked = true;
            if (dataGridView1.Rows[e.RowIndex].Cells[31].Value.ToString() == "0") sub.rbNg5.Checked = true;
            if (dataGridView1.Rows[e.RowIndex].Cells[32].Value.ToString() == "0") sub.rbNg6.Checked = true;
            if (dataGridView1.Rows[e.RowIndex].Cells[33].Value.ToString() == "0") sub.rbNg7.Checked = true;
            sub.parentWin = this;
            sub.ShowDialog();

        }
        #endregion

        #region 작업시작/작업종료/불량보고
        private void btnStart_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            if (string.IsNullOrEmpty(lblLotNo.Text)) // tbJobNo.Text
            {
                lblMsg.Text = "해당 Lot를 추가해 주세요.";
                return;
            }
            if (!string.IsNullOrEmpty(tbJobTimeStart.Text))
            {
                lblMsg.Text = "이미 작업시작된 Lot입니다.";
                return;
            }
            if (!string.IsNullOrEmpty(tbJobTimeFinish.Text))
            {
                lblMsg.Text = "이미 종료된 Lot입니다.";
                return;
            }

            string sDate = dtpDate.Value.ToString("yyyy-MM-dd");
            string sUserCnt = tbUserCnt.Text;
            if (string.IsNullOrEmpty(sUserCnt)) sUserCnt = "0";

            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();
            string sql = string.Empty;

            string sWork = cbWorkLine.SelectedValue.ToString();
            string sGdQty = tbGdQty.Text.Replace(",", "").Trim(); string sNgQty = tbNgQty.Text.Replace(",", "").Trim();
            string sContents = tbContents.Text.Trim();
            string sNumt = tbMatnotop.Text.Replace(",", "").Trim(); string sNumb = tbMatnobot.Text.Replace(",", "").Trim();
            string sPtt = tbMatpttop.Text.Replace(",", "").Trim(); string sPtb = tbMatptbot.Text.Replace(",", "").Trim();
            string sInstt = tbInstTop.Text.Replace(",", "").Trim(); string sInstb = tbInstBot.Text.Replace(",", "").Trim();

            if (string.IsNullOrEmpty(sGdQty)) sGdQty = "0"; if (string.IsNullOrEmpty(sNgQty)) sNgQty = "0";
            if (string.IsNullOrEmpty(sNumt)) sNumt = "0"; if (string.IsNullOrEmpty(sNumb)) sNumb = "0";
            if (string.IsNullOrEmpty(sPtt)) sPtt = "0"; if (string.IsNullOrEmpty(sPtb)) sPtb = "0";
            if (string.IsNullOrEmpty(sInstt)) sInstt = "0"; if (string.IsNullOrEmpty(sInstb)) sInstb = "0";

            sql = "insert into PRD_prod_result (job_no, plant, work_line, prod_date, good_qty, bad_qty, mat_num_top, mat_num_bot, mat_point_top, mat_point_bot, manual_insert_top, manual_insert_bot, job_start_time, job_part, num_workers, contents, enter_man) " +
                    "values('" + lblLotNo.Text + "','" + G.Pos + "','" + sWork + "','" + sDate + "'," + sGdQty + "," + sNgQty + "," + sNumt + "," + sNumb + "," + sPtt + "," + sPtb + "," + sInstt + "," + sInstb + ",now(),'A'," + sUserCnt + ",'" + sContents + "','" + G.UserID + "')";

            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = "작업시작에 문제가 있습니다.";
                return;
            }

            sP_ProdResult_QueryTableAdapter.Fill(dataSetP1C.SP_ProdResult_Query, DateTime.Parse(sDate));
            int rowIndex = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == lblLotNo.Text) // if (dataGridView1.Rows[i].Cells[0].Value.ToString() == tbJobNo.Text)
                {
                    dataGridView1.CurrentCell = dataGridView1[0, i];
                    dataGridView1.CurrentCell.Selected = true;
                    rowIndex = i;
                    break;
                }
            }
            SettingValues(dataGridView1, rowIndex);
            lblMsg.Text = "작업시작되었습니다.";
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            if (string.IsNullOrEmpty(lblLotNo.Text)) // tbJobNo.Text
            {
                lblMsg.Text = "해당 Lot를 추가해 주세요.";
                return;
            }
            if (string.IsNullOrEmpty(tbJobTimeStart.Text))
            {
                lblMsg.Text = "작업시작되지 않은 Lot입니다.";
                return;
            }
            if (!string.IsNullOrEmpty(tbJobTimeFinish.Text))
            {
                lblMsg.Text = "이미 종료된 Lot입니다.";
                return;
            }
            if (string.IsNullOrEmpty(tbGdQty.Text) || tbGdQty.Text == "0")
            {
                lblMsg.Text = "양품수량이 입력되지 않았습니다.";
                return;
            }

            string sDate = dtpDate.Value.ToString("yyyy-MM-dd");
            string sUserCnt = tbUserCnt.Text;
            if (string.IsNullOrEmpty(sUserCnt)) sUserCnt = "0";

            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();
            string sql = string.Empty;

            string sWork = cbWorkLine.SelectedValue.ToString();
            string sGdQty = tbGdQty.Text.Replace(",", "").Trim(); string sNgQty = tbNgQty.Text.Replace(",", "").Trim();
            string sNumt = tbMatnotop.Text.Replace(",", "").Trim(); string sNumb = tbMatnobot.Text.Replace(",", "").Trim();
            string sPtt = tbMatpttop.Text.Replace(",", "").Trim(); string sPtb = tbMatptbot.Text.Replace(",", "").Trim();
            string sInstt = tbInstTop.Text.Replace(",", "").Trim(); string sInstb = tbInstBot.Text.Replace(",", "").Trim();

            if (string.IsNullOrEmpty(sGdQty)) sGdQty = "0"; if (string.IsNullOrEmpty(sNgQty)) sNgQty = "0";
            if (string.IsNullOrEmpty(sNumt)) sNumt = "0"; if (string.IsNullOrEmpty(sNumb)) sNumb = "0";
            if (string.IsNullOrEmpty(sPtt)) sPtt = "0"; if (string.IsNullOrEmpty(sPtb)) sPtb = "0";
            if (string.IsNullOrEmpty(sInstt)) sInstt = "0"; if (string.IsNullOrEmpty(sInstb)) sInstb = "0";

            sql = "update PRD_prod_result set work_line = '" + sWork + "', good_qty = " + sGdQty + ", bad_qty = " + sNgQty + ", mat_num_top = " + sNumt + ", mat_num_bot = " + sNumb + ", mat_point_top = " + sPtt + 
                ", mat_point_bot = " + sPtb + ", manual_insert_top = " + sInstt + ", manual_insert_bot = " + sInstb + ", job_end_time = now(), num_workers = " + sUserCnt + ", contents = '" + tbContents.Text.Trim() + "', jobendYN = 'Y'" +
                    " where job_no = '" + lblLotNo.Text + "'";
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            sql = "update PRD_prod_order set prodYN = 'Y' where job_no = '" + lblLotNo.Text + "'";   // tbJobNo.Text
            m.dbCUD(sql, ref msg);

            sP_ProdResult_QueryTableAdapter.Fill(dataSetP1C.SP_ProdResult_Query, DateTime.Parse(sDate));

            int rowIndex = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == lblLotNo.Text) // tbJobNo.Text
                {
                    dataGridView1.CurrentCell = dataGridView1[0, i];
                    dataGridView1.CurrentCell.Selected = true;
                    rowIndex = i;
                    break;
                }
            }

            SettingValues(dataGridView1, rowIndex);
            lblMsg.Text = "작업종료되었습니다.";
        }
        private void btnNg_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            if (string.IsNullOrEmpty(lblLotNo.Text))
            {
                lblMsg.Text = "LotNo.가 선택되지 않았습니다.";
                return;
            }
            //if (btnStart.Tag == null)
            //{
            //    lblMsg.Text = "작업시작되지 않은 LotNo.입니다.";
            //    return;
            //}

            P1C09_PROD_NG_SUB_RESULT sub = new P1C09_PROD_NG_SUB_RESULT();
            sub.parentWin = this;
            sub.job_no = lblLotNo.Text;
            sub.ShowDialog();
        }
        #endregion

        #region Button Events
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void pbAdd_Click(object sender, EventArgs e)
        {
            P1C02_PROD_RESULT_ORDER sub = new P1C02_PROD_RESULT_ORDER();
            sub.parentWin = this;
            sub.dtDate = DateTime.Parse(dtpDate.Value.ToString("yyyy-MM-dd"));
            sub.ShowDialog();
        }
        private void pbDel_Click(object sender, EventArgs e)
        {
            //
        }
        private void pbSave_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            if (string.IsNullOrEmpty(lblLotNo.Text)) // tbJobNo.Text
            {
                lblMsg.Text = "대상 Lot가 존재하지 않습니다.";
                return;
            }
            if (string.IsNullOrEmpty(tbJobTimeStart.Text))
            {
                lblMsg.Text = "작업시작된 Lot만 저장할 수 있습니다.";
                return;
            }

            string sDate = dtpDate.Value.ToString("yyyy-MM-dd");
            string sUserCnt = tbUserCnt.Text;
            if (string.IsNullOrEmpty(sUserCnt)) sUserCnt = "0";

            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();
            string sql = string.Empty;

            string sWork = cbWorkLine.SelectedValue.ToString();
            string sGdQty = tbGdQty.Text.Replace(",", "").Trim(); string sNgQty = tbNgQty.Text.Replace(",", "").Trim();
            string sNumt = tbMatnotop.Text.Replace(",", "").Trim(); string sNumb = tbMatnobot.Text.Replace(",", "").Trim();
            string sPtt = tbMatpttop.Text.Replace(",", "").Trim(); string sPtb = tbMatptbot.Text.Replace(",", "").Trim();
            string sInstt = tbInstTop.Text.Replace(",", "").Trim(); string sInstb = tbInstBot.Text.Replace(",", "").Trim();

            if (string.IsNullOrEmpty(sGdQty)) sGdQty = "0"; if (string.IsNullOrEmpty(sNgQty)) sNgQty = "0";
            if (string.IsNullOrEmpty(sNumt)) sNumt = "0"; if (string.IsNullOrEmpty(sNumb)) sNumb = "0";
            if (string.IsNullOrEmpty(sPtt)) sPtt = "0"; if (string.IsNullOrEmpty(sPtb)) sPtb = "0";
            if (string.IsNullOrEmpty(sInstt)) sInstt = "0"; if (string.IsNullOrEmpty(sInstb)) sInstb = "0";

            sql = "update PRD_prod_result set work_line = '" + sWork + "', good_qty = " + sGdQty + ", bad_qty = " + sNgQty + ", mat_num_top = " + sNumt + ", mat_num_bot = " + sNumb + ", mat_point_top = " + sPtt +
                ", mat_point_bot = " + sPtb + ", manual_insert_top = " + sInstt + ", manual_insert_bot = " + sInstb + ", num_workers = " + sUserCnt + ", contents = '" + tbContents.Text.Trim() + "'" +
                    " where job_no = '" + tbJobNo.Text + "'";

            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            var data1 = sql;
            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data1);

            sP_ProdResult_QueryTableAdapter.Fill(dataSetP1C.SP_ProdResult_Query, DateTime.Parse(sDate));

            var data2 = dataSetP1C.SP_ProdResult_Query;
            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data2);

            int rowIndex = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == lblLotNo.Text) // tbJobNo.Text
                {
                    dataGridView1.CurrentCell = dataGridView1[0, i];
                    dataGridView1.CurrentCell.Selected = true;
                    rowIndex = i;
                    break;
                }
            }

            SettingValues(dataGridView1, rowIndex);
            lblMsg.Text = "저장 되었습니다.";
        }
        private void pbPrint_Click(object sender, EventArgs e)
        {
                string reportFileName = "SmartMES_Giroei.Reports.P1C02_PROD_RESULT_AOI.rdlc";

            string reportParm1 = "";
            string reportParm2 = "";
            string reportParm3 = "";
            string reportParm4 = "";
            string reportParm5 = "";
            string reportParm6 = "";
            string reportParm7 = "임시조치";
            string reportParm8 = "";

            reportParm1 = reportParm1 + lblLotNo.Text; // 수주번호
            reportParm2 = reportParm2 + tbCust.Text; //업체명
            reportParm3 = reportParm3 + tbProd.Text; //모델명
            reportParm4 = reportParm4 + tbJobNo.Text; // LOT No
            reportParm5 = reportParm5 + tbMakeQty.Text + " pcs"; //생산수
            reportParm6 = reportParm6 + tbAOITimeFinish.Text; //검사일
            reportParm7 = reportParm7 + ""; //검사자
            reportParm8 = reportParm8 + tbShowQty.Text; //검사수

            ViewReport_V viewReport = new ViewReport_V();
                viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
                viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
            ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
            ReportParameter rp3 = new ReportParameter("ReportParameter3", reportParm3);
            ReportParameter rp4 = new ReportParameter("ReportParameter4", reportParm4);
            ReportParameter rp5 = new ReportParameter("ReportParameter5", reportParm5);
            ReportParameter rp6 = new ReportParameter("ReportParameter6", reportParm6);
            ReportParameter rp7 = new ReportParameter("ReportParameter7", reportParm7);
            ReportParameter rp8 = new ReportParameter("ReportParameter8", reportParm8);

            viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8 });

            ReportDataSource rds = new ReportDataSource("DataSet1", sPProdResultQueryBindingSource);
                viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
                viewReport.reportViewer1.LocalReport.Refresh();

                viewReport.ShowDialog();
        }
        #endregion

        #region 텍스트 박스 숫자 처리
        private void tbDigit_TextChanged(object sender, EventArgs e)
        {
            TextBox tbDigit = (TextBox)sender;
            try
            {
                string lgsText = tbDigit.Text.Replace(",", ""); //** 숫자변환시 콤마로 발생하는 에러방지...
                tbDigit.Text = String.Format("{0:#,##0}", Convert.ToDouble(lgsText));

                tbDigit.SelectionStart = tbDigit.TextLength; //** 캐럿을 맨 뒤로 보낸다...
                tbDigit.SelectionLength = 0;
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

        #region 생산량 불러오기
        private void set_production_result()
        {
            MySqlCommand cmd = new MySqlCommand();
            DataSet ds = new DataSet();
            //ProResult[] proResult = new ProResult[10];
            int seq = 10;
            int i = 0;

            DateTime fromDate = DateTime.Parse(tbJobTimeStart.Text);
            DateTime toDate;
            if (tbJobTimeFinish.Text == "")
                toDate = DateTime.Now;
            else
                toDate = DateTime.Parse(tbJobTimeFinish.Text);
            using (MySqlConnection conn = new MySqlConnection(G.conStr))
            {
                try
                {
                    conn.Open();
                    cmd.Connection = conn;

                    cmd.CommandText = "SP_ProductionResult_Query";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new MySqlParameter("_fromDate", MySqlDbType.DateTime));
                    cmd.Parameters.Add(new MySqlParameter("_toDate", MySqlDbType.DateTime));
                    cmd.Parameters["_fromDate"].Value = fromDate;
                    cmd.Parameters["_toDate"].Value = toDate;

                    cmd.ExecuteNonQuery();

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    // Fill the DataSet using default values for DataTable names, etc
                    da.Fill(ds);

                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        tbGdQty.Text = r["생산량"].ToString();
                        seq += 1;
                        i += 1;
                    }
                    if (string.IsNullOrEmpty(tbGdQty.Text)) tbGdQty.Text = "0";
                    //lblMsg.Text = "생산실적이 반영되었습니다.";   주석처리 -> 삭제할때도 뜸.
                }
                catch (Exception ex)
                {
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                conn.Close();
                conn.Dispose();
            }
        }
        #endregion

        private void btnAOI_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            if (string.IsNullOrEmpty(lblLotNo.Text))
            {
                lblMsg.Text = "LotNo.가 선택되지 않았습니다.";
                return;
            }

            P1C02_PROD_RESULT_AOI sub = new P1C02_PROD_RESULT_AOI();
            sub.parentWin = this;
            sub.job_no = lblLotNo.Text;
            sub.ShowDialog();
        }
        //private void timer3_Tick(object sender, EventArgs e)
        //{
        //    //// 현재시간 -- Load 시점에 설정으로 변경
        //    //DateTime SDT1 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        //    // 비가동 시작시간
        //    DateTime SDT2 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // DateTime.Parse(dtpDate.Value.ToString("yyyy-MM-dd HH:mm:ss")); 

        //    // 시간 차이 구함
        //    TimeSpan gapTime = SDT1 - SDT2;

        //    mtProcessDt.Text = gapTime.ToString();
        //}
        public void timer3_Tick(object sender, EventArgs e)
        {
            //lbIngtime.Text = DateTime.Now.ToString("hh:MM:dd mm:ss");

            // 현재시간 -- Load 시점에 설정으로 변경
            //DateTime SDT1 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (isTimeStarted == false)
            {
                isTimeStarted = true;
                SDT1 = DateTime.Now;
            }
            //비가동 시작시간
            DateTime SDT2 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // DateTime.Parse(dtpDate.Value.ToString("yyyy-MM-dd HH:mm:ss")); 

            //시간 차이 구함
            TimeSpan gapTime = SDT1 - SDT2;

            mstbStarttime.Text = SDT1.ToString();
            mstbEndtime.Text = SDT2.ToString();
            mstbIngtime.Text = gapTime.ToString();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            // 시작 버튼
            timer3.Enabled = true;
            timer3.Tick += new EventHandler(timer3_Tick);
            mstbIngtime.Visible = true;
        }

        private void btEnd_Click(object sender, EventArgs e)
        {
            // 멈춤 버튼
            isTimeStarted = false;
            timer3.Enabled = false;
            gpResult.Visible = true;
        }
        public void timer4_Tick(object sender, EventArgs e)
        {
            //lbIngtime.Text = DateTime.Now.ToString("hh:MM:dd mm:ss");

            // 현재시간 -- Load 시점에 설정으로 변경
            //DateTime SDT1 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (isTimeStarted == false)
            {
                isTimeStarted = true;
                SDT3 = DateTime.Now;
            }
            //비가동 시작시간
            DateTime SDT4 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // DateTime.Parse(dtpDate.Value.ToString("yyyy-MM-dd HH:mm:ss")); 

            //시간 차이 구함
            TimeSpan gapTime = SDT3 - SDT4;

            mstbPausetime.Text = SDT3.ToString();
            mstbContinuetime.Text = SDT4.ToString();
            mstbIngtime2.Text = gapTime.ToString();
        }

        private void btPause_Click(object sender, EventArgs e)
        {
            isTimeStarted = false;

            timer4.Enabled = true;
            timer4.Tick += new EventHandler(timer4_Tick);
            mstbIngtime2.Visible = true;
        }

        private void btContinue_Click(object sender, EventArgs e)
        {
            timer4.Enabled = false;

            ////lblMsg.Text = "";

            ////if (string.IsNullOrEmpty(lblLotNo.Text))
            ////{
            ////    lblMsg.Text = "LotNo.가 선택되지 않았습니다.";
            ////    return;
            ////}

            //P1C02_PROD_RESULT_AOI sub = new P1C02_PROD_RESULT_AOI();
            //sub.parentWin = this;
            //sub.job_no = lblLotNo.Text;
            //sub.ShowDialog();
        }
        #region 검사내역 +-버튼
        private void Pbt1_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbTwisted.Text);
            i = i + 1;
            tbTwisted.Text = i.ToString();
        }

        private void Mbt1_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbTwisted.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbTwisted.Text = i.ToString();
            }
        }

        private void Pbt2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbLeadOpen.Text);
            i = i + 1;
            tbLeadOpen.Text = i.ToString();
        }

        private void Mbt2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbLeadOpen.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbLeadOpen.Text = i.ToString();
            }
        }

        private void Pbt3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbManhattan.Text);
            i = i + 1;
            tbManhattan.Text = i.ToString();
        }

        private void Mbt3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbManhattan.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbManhattan.Text = i.ToString();
            }
        }
        
        private void Pbt4_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbOverTurned.Text);
            i = i + 1;
            tbOverTurned.Text = i.ToString();
        }

        private void Mbt4_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbOverTurned.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbOverTurned.Text = i.ToString();
            }
        }
        
        private void Pbt5_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbShort.Text);
            i = i + 1;
            tbShort.Text = i.ToString();
        }

        private void Mbt5_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbShort.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbShort.Text = i.ToString();
            }
        }

        private void Pbt6_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbEtcError.Text);
            i = i + 1;
            tbEtcError.Text = i.ToString();
        }

        private void Mbt6_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbEtcError.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbEtcError.Text = i.ToString();
            }
        }
        
        private void Pbt7_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbMiSap.Text);
            i = i + 1;
            tbMiSap.Text = i.ToString();
        }

        private void Mbt7_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbMiSap.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbMiSap.Text = i.ToString();
            }
        }
        
        private void Pbt8_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbReverse.Text);
            i = i + 1;
            tbReverse.Text = i.ToString();
        }

        private void Mbt8_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbReverse.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbReverse.Text = i.ToString();
            }
        }
        
        private void Pbt9_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbMiNap.Text);
            i = i + 1;
            tbMiNap.Text = i.ToString();
        }

        private void Mbt9_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbMiNap.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbMiNap.Text = i.ToString();
            }
        }
        
        private void Pbt10_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbSonap.Text);
            i = i + 1;
            tbSonap.Text = i.ToString();
        }

        private void Mbt10_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbSonap.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbSonap.Text = i.ToString();
            }
        }
        
        private void Pbt11_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbnengttem.Text);
            i = i + 1;
            tbnengttem.Text = i.ToString();
        }

        private void Mbt11_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbnengttem.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbnengttem.Text = i.ToString();
            }
        }
        #endregion
    }
}

