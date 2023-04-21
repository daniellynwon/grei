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
        private DateTime SDT5 = DateTime.Now;
        private DateTime SDT7 = DateTime.Now;
        private DateTime SDT9 = DateTime.Now;
        private DateTime SDT11 = DateTime.Now;
        private bool isTimeStarted = false;
        private bool isTimeStarted2 = false;
        private bool isTimeStarted3 = false;

        public P1C02_PROD_RESULT()
        {
            InitializeComponent();
        }
        private void P1C02_PROD_RESULT_Shown(object sender, EventArgs e)
        {
            string sql = @"select co_code, co_item from BAS_common where co_kind = 'M' order by co_code";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            DataTable table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbPause.DataSource = table;
                cbPause.ValueMember = "co_code";
                cbPause.DisplayMember = "co_item";
            }

            sql = @"select co_code, co_item from BAS_common where co_kind = 'O' order by co_code";
            m = new MariaCRUD();
            msg = string.Empty;
            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbWorkline1.DataSource = table;
                cbWorkline1.ValueMember = "co_code";
                cbWorkline1.DisplayMember = "co_item";
            }

            sql = "select user_id, user_name from SYS_user where authority in ('A','B','C') and useYN = 'Y'";
            m = new MariaCRUD();
            msg = string.Empty;
            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbMan.DataSource = table;
                cbMan.ValueMember = "user_id";
                cbMan.DisplayMember = "user_name";
            }

            sql = @"select co_code, co_item from BAS_common where co_kind = 'M' order by co_code";
            m = new MariaCRUD();
            msg = string.Empty;
            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbPause2.DataSource = table;
                cbPause2.ValueMember = "co_code";
                cbPause2.DisplayMember = "co_item";
            }

            sql = @"select co_code, co_item from BAS_common where co_kind = 'O' order by co_code";
            m = new MariaCRUD();
            msg = string.Empty;
            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbWorkline2.DataSource = table;
                cbWorkline2.ValueMember = "co_code";
                cbWorkline2.DisplayMember = "co_item";
            }

            sql = "select user_id, user_name from SYS_user where authority in ('A','B','C') and useYN = 'Y'";
            m = new MariaCRUD();
            msg = string.Empty;
            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbMan2.DataSource = table;
                cbMan2.ValueMember = "user_id";
                cbMan2.DisplayMember = "user_name";
            }

            sql = @"select co_code, co_item from BAS_common where co_kind = 'M' order by co_code";
            m = new MariaCRUD();
            msg = string.Empty;
            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbPause3.DataSource = table;
                cbPause3.ValueMember = "co_code";
                cbPause3.DisplayMember = "co_item";
            }

            sql = @"select co_code, co_item from BAS_common where co_kind = 'O' order by co_code";
            m = new MariaCRUD();
            msg = string.Empty;
            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbWorkline3.DataSource = table;
                cbWorkline3.ValueMember = "co_code";
                cbWorkline3.DisplayMember = "co_item";
            }

            sql = "select user_id, user_name from SYS_user where authority in ('A','B','C') and useYN = 'Y'";
            m = new MariaCRUD();
            msg = string.Empty;
            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbMan3.DataSource = table;
                cbMan3.ValueMember = "user_id";
                cbMan3.DisplayMember = "user_name";
            }
        }
        private void P1C02_PROD_RESULT_Load(object sender, EventArgs e)
        {
            ListSearch();
            InitControls();

            //this.ActiveControl = btnSave;
        }
        public void ListSearch()
        {

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
        public void ListSearch2()
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string _no = tbJobNo.Text;

                //if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[17].Value.ToString() == "1라인")
                //{
                //    dataGridView2.Visible = true;
                //    dataGridView3.Visible = false;
                //    dataGridView4.Visible = false;
                //}
                //else if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[17].Value.ToString() == "2라인")
                //{
                //    dataGridView2.Visible = false;
                //    dataGridView3.Visible = true;
                //    dataGridView4.Visible = false;
                //}
                //else if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[17].Value.ToString() == "육안검사")
                //{
                //    dataGridView2.Visible = false;
                //    dataGridView3.Visible = false;
                //    dataGridView4.Visible = true;
                //}
                //else
                //{
                //    dataGridView2.Visible = true;
                //    dataGridView3.Visible = true;
                //    dataGridView4.Visible = true;
                //}

                sP_AOI_LossTableAdapter.Fill(dataSetP1C.SP_AOI_Loss, _no);

                var data = dataSetP1C.SP_AOI_Loss;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

                dataGridView2.CurrentCell = null;
                dataGridView2.ClearSelection();

                sP_AOI_Loss2TableAdapter.Fill(dataSetP1C.SP_AOI_Loss2, _no);

                dataGridView3.CurrentCell = null;
                dataGridView3.ClearSelection();

                sP_AOI_Loss3TableAdapter.Fill(dataSetP1C.SP_AOI_Loss3, _no);

                dataGridView4.CurrentCell = null;
                dataGridView4.ClearSelection();

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
            tbContents.Text = string.Empty;

            bMoltD = false;
            bPunch1D = false;
            bPunch2D = false;
        }
        public void SettingValues(DataGridView dataGridView, int rowIndex)
        {
            try
            {
                //필수
                tbProd.Text = dataGridView.Rows[rowIndex].Cells[8].Value.ToString();
                tbJobNo.Text = dataGridView.Rows[rowIndex].Cells[0].Value.ToString();
                tbCust.Text = dataGridView.Rows[rowIndex].Cells[6].Value.ToString(); //업체명
                tbMakeQty.Text = dataGridView.Rows[rowIndex].Cells[12].Value.ToString();
                //저장된 후 
                if (dataGridView.Rows[rowIndex].Cells[17].Value.ToString() == "1라인" || dataGridView.Rows[rowIndex].Cells[17].Value.ToString() == "2라인" || dataGridView.Rows[rowIndex].Cells[17].Value.ToString() == "육안검사")
                {
                    mstbStarttime.Text = dataGridView.Rows[rowIndex].Cells[14].Value.ToString();
                    mstbEndtime.Text = dataGridView.Rows[rowIndex].Cells[15].Value.ToString(); //검사종료시간 insp_end_time
                    mstbIngtime.Text = dataGridView.Rows[rowIndex].Cells[16].Value.ToString(); //경과시간 insp_ing_time
                    cbWorkline1.Text = dataGridView.Rows[rowIndex].Cells[17].Value.ToString();
                    tbDefectCount.Text = dataGridView.Rows[rowIndex].Cells[18].Value.ToString();
                    tbSonap.Text = dataGridView.Rows[rowIndex].Cells[19].Value.ToString();
                    tbnengttem.Text = dataGridView.Rows[rowIndex].Cells[20].Value.ToString();
                    tbMiSap.Text = dataGridView.Rows[rowIndex].Cells[21].Value.ToString();
                    tbOverTurned.Text = dataGridView.Rows[rowIndex].Cells[22].Value.ToString();
                    tbLeadOpen.Text = dataGridView.Rows[rowIndex].Cells[23].Value.ToString();
                    tbMiNap.Text = dataGridView.Rows[rowIndex].Cells[24].Value.ToString();
                    tbShort.Text = dataGridView.Rows[rowIndex].Cells[25].Value.ToString();
                    tbReverse.Text = dataGridView.Rows[rowIndex].Cells[26].Value.ToString();
                    tbManhattan.Text = dataGridView.Rows[rowIndex].Cells[27].Value.ToString();
                    tbTwisted.Text = dataGridView.Rows[rowIndex].Cells[28].Value.ToString();
                    tbEtcError.Text = dataGridView.Rows[rowIndex].Cells[29].Value.ToString(); //기타
                    tbContents.Text = dataGridView.Rows[rowIndex].Cells[30].Value.ToString();
                    cbMan.SelectedValue = dataGridView.Rows[rowIndex].Cells[31].Value.ToString();
                    gpAOI.Visible = true;
                    gpResult.Visible = true;
                    BtPrint.Visible = true;
                    lblPrint.Visible = true;
                }
            }
            catch (System.NullReferenceException)
            {
                return;
            }
        }
        public void SettingValues2(DataGridView dataGridView, int rowIndex)
        {
            try
            {
                //필수
                tbProd2.Text = dataGridView.Rows[rowIndex].Cells[8].Value.ToString();
                tbJobNo2.Text = dataGridView.Rows[rowIndex].Cells[0].Value.ToString();
                tbCust2.Text = dataGridView.Rows[rowIndex].Cells[6].Value.ToString(); //업체명
                tbMakeQty2.Text = dataGridView.Rows[rowIndex].Cells[12].Value.ToString();
                //저장된 후 
                if (dataGridView.Rows[rowIndex].Cells[17].Value.ToString() == "1라인" || dataGridView.Rows[rowIndex].Cells[17].Value.ToString() == "2라인" || dataGridView.Rows[rowIndex].Cells[17].Value.ToString() == "육안검사")
                {
                    mstbStarttime2.Text = dataGridView.Rows[rowIndex].Cells[14].Value.ToString();
                    mstbEndtime2.Text = dataGridView.Rows[rowIndex].Cells[15].Value.ToString(); //검사종료시간 insp_end_time
                    mstbIngtime_2.Text = dataGridView.Rows[rowIndex].Cells[16].Value.ToString(); //경과시간 insp_ing_time
                    cbWorkline2.Text = dataGridView.Rows[rowIndex].Cells[17].Value.ToString();
                    tbDefectCount2.Text = dataGridView.Rows[rowIndex].Cells[18].Value.ToString();
                    tbSonap2.Text = dataGridView.Rows[rowIndex].Cells[19].Value.ToString();
                    tbnengttem2.Text = dataGridView.Rows[rowIndex].Cells[20].Value.ToString();
                    tbMiSap2.Text = dataGridView.Rows[rowIndex].Cells[21].Value.ToString();
                    tbOverTurned2.Text = dataGridView.Rows[rowIndex].Cells[22].Value.ToString();
                    tbLeadOpen2.Text = dataGridView.Rows[rowIndex].Cells[23].Value.ToString();
                    tbMiNap2.Text = dataGridView.Rows[rowIndex].Cells[24].Value.ToString();
                    tbShort2.Text = dataGridView.Rows[rowIndex].Cells[25].Value.ToString();
                    tbReverse2.Text = dataGridView.Rows[rowIndex].Cells[26].Value.ToString();
                    tbManhattan2.Text = dataGridView.Rows[rowIndex].Cells[27].Value.ToString();
                    tbTwisted2.Text = dataGridView.Rows[rowIndex].Cells[28].Value.ToString();
                    tbEtcError2.Text = dataGridView.Rows[rowIndex].Cells[29].Value.ToString(); //기타
                    tbContents2.Text = dataGridView.Rows[rowIndex].Cells[30].Value.ToString();
                    cbMan2.SelectedValue = dataGridView.Rows[rowIndex].Cells[31].Value.ToString();
                    gpAOI2.Visible = true;
                    gpResult2.Visible = true;
                    BtPrint2.Visible = true;
                    lblPrint2.Visible = true;
                }
            }
            catch (System.NullReferenceException)
            {
                return;
            }
        }
        public void SettingValues3(DataGridView dataGridView, int rowIndex)
        {
            try
            {
                //필수
                tbProd3.Text = dataGridView.Rows[rowIndex].Cells[8].Value.ToString();
                tbJobNo3.Text = dataGridView.Rows[rowIndex].Cells[0].Value.ToString();
                tbCust3.Text = dataGridView.Rows[rowIndex].Cells[6].Value.ToString(); //업체명
                tbMakeQty3.Text = dataGridView.Rows[rowIndex].Cells[12].Value.ToString();
                //저장된 후 
                if (dataGridView.Rows[rowIndex].Cells[17].Value.ToString() == "1라인" || dataGridView.Rows[rowIndex].Cells[17].Value.ToString() == "2라인" || dataGridView.Rows[rowIndex].Cells[17].Value.ToString() == "육안검사")
                {
                    mstbStarttime3.Text = dataGridView.Rows[rowIndex].Cells[14].Value.ToString();
                    mstbEndtime3.Text = dataGridView.Rows[rowIndex].Cells[15].Value.ToString(); //검사종료시간 insp_end_time
                    mstbIngtime_3.Text = dataGridView.Rows[rowIndex].Cells[16].Value.ToString(); //경과시간 insp_ing_time
                    cbWorkline3.Text = dataGridView.Rows[rowIndex].Cells[17].Value.ToString();
                    tbDefectCount3.Text = dataGridView.Rows[rowIndex].Cells[18].Value.ToString();
                    tbSonap3.Text = dataGridView.Rows[rowIndex].Cells[19].Value.ToString();
                    tbnengttem3.Text = dataGridView.Rows[rowIndex].Cells[20].Value.ToString();
                    tbMiSap3.Text = dataGridView.Rows[rowIndex].Cells[21].Value.ToString();
                    tbOverTurned3.Text = dataGridView.Rows[rowIndex].Cells[22].Value.ToString();
                    tbLeadOpen3.Text = dataGridView.Rows[rowIndex].Cells[23].Value.ToString();
                    tbMiNap3.Text = dataGridView.Rows[rowIndex].Cells[24].Value.ToString();
                    tbShort3.Text = dataGridView.Rows[rowIndex].Cells[25].Value.ToString();
                    tbReverse3.Text = dataGridView.Rows[rowIndex].Cells[26].Value.ToString();
                    tbManhattan3.Text = dataGridView.Rows[rowIndex].Cells[27].Value.ToString();
                    tbTwisted3.Text = dataGridView.Rows[rowIndex].Cells[28].Value.ToString();
                    tbEtcError3.Text = dataGridView.Rows[rowIndex].Cells[29].Value.ToString(); //기타
                    tbContents3.Text = dataGridView.Rows[rowIndex].Cells[30].Value.ToString();
                    cbMan3.SelectedValue = dataGridView.Rows[rowIndex].Cells[31].Value.ToString();
                    gpAOI3.Visible = true;
                    gpResult3.Visible = true;
                    BtPrint3.Visible = true;
                    lblPrint3.Visible = true;
                }
            }
            catch (System.NullReferenceException)
            {
                return;
            }
        }

        #region Condition Bar Events1 
        private void userButtonA1_Click(object sender, EventArgs e) // 날짜변경
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

            string sFile1 = dataGridView1.Rows[e.RowIndex].Cells[32].Value.ToString();
            string sFile2 = dataGridView1.Rows[e.RowIndex].Cells[33].Value.ToString();

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

            SettingValues(dgv, rowIndex);
            lbMsg.Text = "";
            cbWorkline1.Enabled = true;
            cbMan.Enabled = true;
            lblSeq.Visible = false;
            tbSeq.Visible = false;
            TabControl1.Visible = true;
            TabControl1.Enabled = true;
            SettingValues2(dgv, rowIndex);
            lbMsg2.Text = "";
            cbWorkline2.Enabled = true;
            cbMan2.Enabled = true;
            lblSeq2.Visible = false;
            tbSeq2.Visible = false;
            SettingValues3(dgv, rowIndex);
            lbMsg3.Text = "";
            cbWorkline3.Enabled = true;
            cbMan3.Enabled = true;
            lblSeq3.Visible = false;
            tbSeq3.Visible = false;

            if (dataGridView1.Rows[rowIndex].Cells[17].Value.ToString() == "1라인" || dataGridView1.Rows[rowIndex].Cells[17].Value.ToString() == "2라인" || dataGridView1.Rows[rowIndex].Cells[17].Value.ToString() == "육안검사")
            {

            }
            else 
            {
                gpResult.Visible = false;
                gpAOI.Visible = false;
                lblPrint.Visible = false;
                BtPrint.Visible = false;
                gpResult2.Visible = false;
                gpAOI2.Visible = false;
                lblPrint2.Visible = false;
                BtPrint2.Visible = false;
                gpResult3.Visible = false;
                gpAOI3.Visible = false;
                lblPrint3.Visible = false;
                BtPrint3.Visible = false;

                //탭페이지 초기화
                tbDefectCount.Text = "0";
                tbContents.Text = "";
                tbSonap.Text = "0";
                tbnengttem.Text = "0";
                tbMiSap.Text = "0";
                tbOverTurned.Text = "0";
                tbLeadOpen.Text = "0";
                tbMiNap.Text = "0";
                tbShort.Text = "0";
                tbReverse.Text = "0";
                tbManhattan.Text = "0";
                tbTwisted.Text = "0";
                tbEtcError.Text = "0";
                mstbStarttime.ResetText();
                mstbEndtime.ResetText();
                mstbIngtime.ResetText();
                mstbPausetime.ResetText();
                mstbContinuetime.ResetText();
                mstbIngtime2.ResetText();
                tbSeq.Text = "0";
            }
            ListSearch2();
            //set_production_result();
        }
        //public byte[] get_file_data(string fname, string job_no)
        //{
        //    byte[] rawdata = new byte[0];
        //    string sql = "select file1 from QLT_inspection_AOI where job_no = '" + job_no + "' and file1_name = '" + fname + "'";
        //    MySqlConnection con = new MySqlConnection(G.conStr);
        //    MySqlCommand cmd = new MySqlCommand(sql, con);
        //    con.Open();
        //    MySqlDataReader rdr = cmd.ExecuteReader();
        //    while (rdr.Read())
        //    {
        //        rawdata = (byte[])rdr[0];
        //    }
        //    con.Close();
        //    return rawdata;
        //}
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (G.Authority == "D") return;
            //if (e.RowIndex < 0) return;
            //if (e.ColumnIndex != 24) return;    // 사양점검

            //P1C02_PROD_RESULT_SUB sub = new P1C02_PROD_RESULT_SUB();
            //sub.lblLotNo.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //sub.lblChkID.Text = dataGridView1.Rows[e.RowIndex].Cells[35].Value.ToString();
            //sub.rorderID = dataGridView1.Rows[e.RowIndex].Cells[45].Value.ToString();       // 11/9 추가 수주번호,순번
            //sub.rorderSeq = dataGridView1.Rows[e.RowIndex].Cells[46].Value.ToString();
            //if (dataGridView1.Rows[e.RowIndex].Cells[25].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[25].Value.ToString())) sub.tbJobTimeStart.Text = "";
            //else
            //    sub.tbJobTimeStart.Text = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[25].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            //if (dataGridView1.Rows[e.RowIndex].Cells[26].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[26].Value.ToString())) sub.tbJobTimeFinish.Text = "";
            //else
            //    sub.tbJobTimeFinish.Text = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[26].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            //sub.cbMan.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[34].Value.ToString();

            //if (dataGridView1.Rows[e.RowIndex].Cells[27].Value.ToString() == "0") sub.rbNg1.Checked = true;
            //if (dataGridView1.Rows[e.RowIndex].Cells[28].Value.ToString() == "0") sub.rbNg2.Checked = true;
            //if (dataGridView1.Rows[e.RowIndex].Cells[29].Value.ToString() == "0") sub.rbNg3.Checked = true;
            //if (dataGridView1.Rows[e.RowIndex].Cells[30].Value.ToString() == "0") sub.rbNg4.Checked = true;
            //if (dataGridView1.Rows[e.RowIndex].Cells[31].Value.ToString() == "0") sub.rbNg5.Checked = true;
            //if (dataGridView1.Rows[e.RowIndex].Cells[32].Value.ToString() == "0") sub.rbNg6.Checked = true;
            //if (dataGridView1.Rows[e.RowIndex].Cells[33].Value.ToString() == "0") sub.rbNg7.Checked = true;

            //sub.parentWin = this;
            //sub.ShowDialog();
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
            lbMsg.Text = "";

            if (string.IsNullOrEmpty(tbJobNo.Text)) // tbJobNo.Text
            {
                lbMsg.Text = "검사리스트가 선택되지 않았습니다.";
                return;
            }
            if (string.IsNullOrEmpty(mstbEndtime.Text))
            {
                lbMsg.Text = "작업이 종료되어야 저장할 수 있습니다.";
                return;
            }

            string sJob = tbJobNo.Text; // 작지번호
            string sInspCount = tbMakeQty.Text; //검사수량
            string sTotalDefect = tbDefectCount.Text; //총불량수
            string sContents = tbContents.Text; //상세결과
            string sMan = cbMan.SelectedValue.ToString(); //검사자
            string sWorklineName = cbWorkline1.Text.ToString(); //작업라인이름
            string sWorkline = cbWorkline1.SelectedValue.ToString();//작업라인코드
            string sSonap = tbSonap.Text;
            string sNengttem = tbnengttem.Text;
            string sMisap = tbMiSap.Text;
            string sOverturned = tbOverTurned.Text;
            string sLeadopen = tbLeadOpen.Text;
            string sMinap = tbMiNap.Text;
            string sShort = tbShort.Text;
            string sReverse = tbReverse.Text;
            string sManhattan = tbManhattan.Text;
            string sTwisted = tbTwisted.Text;
            string sEtcerror = tbEtcError.Text;

            //string sFname1 = lbFname1.Text;
            //string sFname2 = lbFname2.Text;

            string sInspFromTime = DateTime.Parse(mstbStarttime.Text).ToString("yyyy-MM-dd HH:mm:ss"); //검사시작시간 insp_start_time 
            string sInspToTime = DateTime.Parse(mstbEndtime.Text).ToString("yyyy-MM-dd HH:mm:ss"); //검사종료시간 insp_end_time
            string sInspIngTime = DateTime.Parse(mstbIngtime.Text).ToString("HH:mm:ss"); //경과시간 insp_ing_time

            string sql = string.Empty;

            string fname1 = string.Empty;
            string fname2 = string.Empty;
            byte[] rawdata1 = new byte[0];
            byte[] rawdata2 = new byte[0];

            MySqlConnection con = new MySqlConnection(G.conStr);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();

            sql = "insert into QLT_inspection_AOI (job_no, insp_start_time, insp_end_time, insp_ing_time, insp_qty, defect_count, sonap, nengttem, misap, overturned, leadopen, minap, short, reverse, manhattan, twisted, etc_error, contents, worklinename, workline, enter_man)" +
                    " values('" + sJob + "','" + sInspFromTime + "','" + sInspToTime + "','" + sInspIngTime + "'," + sInspCount + "," + sTotalDefect + "," + sSonap + "," + sNengttem + "," + sMisap + "," + sOverturned + "," + sLeadopen + "," + sMinap + "," + sShort + "," + sReverse + "," +
                        sManhattan + "," + sTwisted + "," + sEtcerror + ",'" + sContents + "','" + sWorklineName + "','" + sWorkline + "','" + sMan + "')"
                        + " on duplicate key update" + " insp_start_time = '" + sInspFromTime + "', insp_end_time = '" + sInspToTime + "', insp_ing_time = '" + sInspIngTime + "',"
                        + " insp_qty = " + sInspCount + ", defect_count = " + sTotalDefect + ", sonap = " + sSonap + ", nengttem = " + sNengttem
                        + ", misap = " + sMisap + ", overturned = " + sOverturned + ", leadopen = " + sLeadopen + ", minap = " + sMinap + ", short = " + sShort + ", reverse = " + sReverse
                        + ", manhattan = " + sManhattan + ", twisted = " + sTwisted + ", etc_error = " + sEtcerror
                        + ", contents = '" + sContents + "', worklinename ='" + sWorklineName + "', workline ='" + sWorkline + "', enter_man = '" + sMan + "'";

            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            con.Close();
                        
            //탭페이지 초기화
            tbJobNo.Text = "";
            tbMakeQty.Text = "";
            tbDefectCount.Text = "0";
            tbContents.Text = "";
            tbSonap.Text = "0";
            tbnengttem.Text = "0";
            tbMiSap.Text = "0";
            tbOverTurned.Text = "0";
            tbLeadOpen.Text = "0";
            tbMiNap.Text = "0";
            tbShort.Text = "0";
            tbReverse.Text = "0";
            tbManhattan.Text = "0";
            tbTwisted.Text = "0";
            tbEtcError.Text = "0";
            mstbStarttime.Text = "";
            mstbEndtime.Text = "";
            mstbIngtime.Text = "";
            mstbPausetime.Text = "";
            mstbContinuetime.Text = "";
            mstbIngtime2.Text = "";
            tbSeq.Text = "0";
            lbMsg.Text = "저장되었습니다.";
            ListSearch();
        }

        private void pbSave2_Click(object sender, EventArgs e)
        {
            lbMsg2.Text = "";

            if (string.IsNullOrEmpty(tbJobNo2.Text)) // tbJobNo.Text
            {
                lbMsg2.Text = "검사리스트가 선택되지 않았습니다.";
                return;
            }
            if (string.IsNullOrEmpty(mstbEndtime2.Text))
            {
                lbMsg2.Text = "작업이 종료되어야 저장할 수 있습니다.";
                return;
            }

            string sJob2 = tbJobNo2.Text; // 작지번호
            string sInspCount2 = tbMakeQty2.Text; //검사수량
            string sTotalDefect2 = tbDefectCount2.Text; //총불량수
            string sContents2 = tbContents2.Text; //상세결과
            string sMan2 = cbMan2.SelectedValue.ToString(); //검사자
            string sWorklineName2 = cbWorkline2.Text.ToString(); //작업라인이름
            string sWorkline2 = cbWorkline2.SelectedValue.ToString();//작업라인코드
            string sSonap2 = tbSonap2.Text;
            string sNengttem2 = tbnengttem2.Text;
            string sMisap2 = tbMiSap2.Text;
            string sOverturned2 = tbOverTurned2.Text;
            string sLeadopen2 = tbLeadOpen2.Text;
            string sMinap2 = tbMiNap2.Text;
            string sShort2 = tbShort2.Text;
            string sReverse2 = tbReverse2.Text;
            string sManhattan2 = tbManhattan2.Text;
            string sTwisted2 = tbTwisted2.Text;
            string sEtcerror2 = tbEtcError2.Text;

            //string sFname1 = lbFname1.Text;
            //string sFname2 = lbFname2.Text;

            string sInspFromTime2 = DateTime.Parse(mstbStarttime2.Text).ToString("yyyy-MM-dd HH:mm:ss"); //검사시작시간 insp_start_time 
            string sInspToTime2 = DateTime.Parse(mstbEndtime2.Text).ToString("yyyy-MM-dd HH:mm:ss"); //검사종료시간 insp_end_time
            string sInspIngTime2 = DateTime.Parse(mstbIngtime_2.Text).ToString("HH:mm:ss"); //경과시간 insp_ing_time

            string sql = string.Empty;

            string fname1 = string.Empty;
            string fname2 = string.Empty;
            byte[] rawdata1 = new byte[0];
            byte[] rawdata2 = new byte[0];

            MySqlConnection con = new MySqlConnection(G.conStr);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();

            sql = "insert into QLT_inspection_AOI (job_no, insp_start_time, insp_end_time, insp_ing_time, insp_qty, defect_count, sonap, nengttem, misap, overturned, leadopen, minap, short, reverse, manhattan, twisted, etc_error, contents, worklinename, workline, enter_man)" +
                    " values('" + sJob2 + "','" + sInspFromTime2 + "','" + sInspToTime2 + "','" + sInspIngTime2 + "'," + sInspCount2 + "," + sTotalDefect2 + "," + sSonap2 + "," + sNengttem2 + "," + sMisap2 + "," + sOverturned2 + "," + sLeadopen2 + "," + sMinap2 + "," + sShort2 + "," + sReverse2 + "," +
                        sManhattan2 + "," + sTwisted2 + "," + sEtcerror2 + ",'" + sContents2 + "','" + sWorklineName2 + "','" + sWorkline2 + "','" + sMan2 + "')"
                        + " on duplicate key update" + " insp_start_time = '" + sInspFromTime2 + "', insp_end_time = '" + sInspToTime2 + "', insp_ing_time = '" + sInspIngTime2 + "',"
                        + " insp_qty = " + sInspCount2 + ", defect_count = " + sTotalDefect2 + ", sonap = " + sSonap2 + ", nengttem = " + sNengttem2
                        + ", misap = " + sMisap2 + ", overturned = " + sOverturned2 + ", leadopen = " + sLeadopen2 + ", minap = " + sMinap2 + ", short = " + sShort2 + ", reverse = " + sReverse2
                        + ", manhattan = " + sManhattan2 + ", twisted = " + sTwisted2 + ", etc_error = " + sEtcerror2
                        + ", contents = '" + sContents2 + "', worklinename ='" + sWorklineName2 + "', workline ='" + sWorkline2 + "', enter_man = '" + sMan2 + "'";

            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            con.Close();

            //탭페이지 초기화
            tbJobNo2.Text = "";
            tbMakeQty2.Text = "";
            tbDefectCount2.Text = "0";
            tbContents2.Text = "";
            tbSonap2.Text = "0";
            tbnengttem2.Text = "0";
            tbMiSap2.Text = "0";
            tbOverTurned2.Text = "0";
            tbLeadOpen2.Text = "0";
            tbMiNap2.Text = "0";
            tbShort2.Text = "0";
            tbReverse2.Text = "0";
            tbManhattan2.Text = "0";
            tbTwisted2.Text = "0";
            tbEtcError2.Text = "0";
            mstbStarttime2.Text = "";
            mstbEndtime2.Text = "";
            mstbIngtime_2.Text = "";
            mstbPausetime2.Text = "";
            mstbContinuetime2.Text = "";
            mstbIngtime2_2.Text = "";
            tbSeq2.Text = "0";
            lbMsg2.Text = "저장되었습니다.";
            ListSearch();
        }

        private void pbSave3_Click(object sender, EventArgs e)
        {
            lbMsg3.Text = "";

            if (string.IsNullOrEmpty(tbJobNo3.Text)) // tbJobNo.Text
            {
                lbMsg3.Text = "검사리스트가 선택되지 않았습니다.";
                return;
            }
            if (string.IsNullOrEmpty(mstbEndtime3.Text))
            {
                lbMsg3.Text = "작업이 종료되어야 저장할 수 있습니다.";
                return;
            }

            string sJob3 = tbJobNo3.Text; // 작지번호
            string sInspCount3 = tbMakeQty3.Text; //검사수량
            string sTotalDefect3 = tbDefectCount3.Text; //총불량수
            string sContents3 = tbContents3.Text; //상세결과
            string sMan3 = cbMan3.SelectedValue.ToString(); //검사자
            string sWorklineName3 = cbWorkline3.Text.ToString(); //작업라인이름
            string sWorkline3 = cbWorkline3.SelectedValue.ToString();//작업라인코드
            string sSonap3 = tbSonap3.Text;
            string sNengttem3 = tbnengttem3.Text;
            string sMisap3 = tbMiSap3.Text;
            string sOverturned3 = tbOverTurned3.Text;
            string sLeadopen3 = tbLeadOpen3.Text;
            string sMinap3 = tbMiNap3.Text;
            string sShort3 = tbShort3.Text;
            string sReverse3 = tbReverse3.Text;
            string sManhattan3 = tbManhattan3.Text;
            string sTwisted3 = tbTwisted3.Text;
            string sEtcerror3 = tbEtcError3.Text;

            //string sFname1 = lbFname1.Text;
            //string sFname2 = lbFname2.Text;

            string sInspFromTime3 = DateTime.Parse(mstbStarttime3.Text).ToString("yyyy-MM-dd HH:mm:ss"); //검사시작시간 insp_start_time 
            string sInspToTime3 = DateTime.Parse(mstbEndtime3.Text).ToString("yyyy-MM-dd HH:mm:ss"); //검사종료시간 insp_end_time
            string sInspIngTime3 = DateTime.Parse(mstbIngtime_3.Text).ToString("HH:mm:ss"); //경과시간 insp_ing_time

            string sql = string.Empty;

            string fname1 = string.Empty;
            string fname2 = string.Empty;
            byte[] rawdata1 = new byte[0];
            byte[] rawdata2 = new byte[0];

            MySqlConnection con = new MySqlConnection(G.conStr);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();

            sql = "insert into QLT_inspection_AOI (job_no, insp_start_time, insp_end_time, insp_ing_time, insp_qty, defect_count, sonap, nengttem, misap, overturned, leadopen, minap, short, reverse, manhattan, twisted, etc_error, contents, worklinename, workline, enter_man)" +
                    " values('" + sJob3 + "','" + sInspFromTime3 + "','" + sInspToTime3 + "','" + sInspIngTime3 + "'," + sInspCount3 + "," + sTotalDefect3 + "," + sSonap3 + "," + sNengttem3 + "," + sMisap3 + "," + sOverturned3 + "," + sLeadopen3 + "," + sMinap3 + "," + sShort3 + "," + sReverse3 + "," +
                        sManhattan3 + "," + sTwisted3 + "," + sEtcerror3 + ",'" + sContents3 + "','" + sWorklineName3 + "','" + sWorkline3 + "','" + sMan3 + "')"
                        + " on duplicate key update" + " insp_start_time = '" + sInspFromTime3 + "', insp_end_time = '" + sInspToTime3 + "', insp_ing_time = '" + sInspIngTime3 + "',"
                        + " insp_qty = " + sInspCount3 + ", defect_count = " + sTotalDefect3 + ", sonap = " + sSonap3 + ", nengttem = " + sNengttem3
                        + ", misap = " + sMisap3 + ", overturned = " + sOverturned3 + ", leadopen = " + sLeadopen3 + ", minap = " + sMinap3 + ", short = " + sShort3 + ", reverse = " + sReverse3
                        + ", manhattan = " + sManhattan3 + ", twisted = " + sTwisted3 + ", etc_error = " + sEtcerror3
                        + ", contents = '" + sContents3 + "', worklinename ='" + sWorklineName3 + "', workline ='" + sWorkline3 + "', enter_man = '" + sMan3 + "'";

            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            con.Close();

            //탭페이지 초기화
            tbJobNo3.Text = "";
            tbMakeQty3.Text = "";
            tbDefectCount3.Text = "0";
            tbContents3.Text = "";
            tbSonap3.Text = "0";
            tbnengttem3.Text = "0";
            tbMiSap3.Text = "0";
            tbOverTurned3.Text = "0";
            tbLeadOpen3.Text = "0";
            tbMiNap3.Text = "0";
            tbShort3.Text = "0";
            tbReverse3.Text = "0";
            tbManhattan3.Text = "0";
            tbTwisted3.Text = "0";
            tbEtcError3.Text = "0";
            mstbStarttime3.Text = "";
            mstbEndtime3.Text = "";
            mstbIngtime_3.Text = "";
            mstbPausetime3.Text = "";
            mstbContinuetime3.Text = "";
            mstbIngtime2_3.Text = "";
            tbSeq3.Text = "0";
            lbMsg3.Text = "저장되었습니다.";
            ListSearch();
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
            string reportParm7 = "";
            string reportParm8 = "";
            string reportParm9 = " ";
            string reportParm10 = "";
            string reportParm11 = "";
            string reportParm12 = "";
            string reportParm13 = "";
            string reportParm14 = "";
            string reportParm15 = "";
            string reportParm16 = "";
            string reportParm17 = "";
            string reportParm18 = "";
            string reportParm19 = "";
            string reportParm20 = "";

            reportParm1 = reportParm1 + tbJobNo.Text; // 수주번호
            reportParm2 = reportParm2 + tbCust.Text; //업체명
            reportParm3 = reportParm3 + tbProd.Text; //모델명
            reportParm4 = reportParm4 + cbWorkline1.Text; // 작업라인
            reportParm5 = reportParm5 + tbMakeQty.Text + " pcs"; //생산수
            reportParm6 = reportParm6 + mstbEndtime.Text; //검사일
            reportParm7 = reportParm7 + cbMan.Text; //검사자
            reportParm8 = reportParm8 + tbDefectCount.Text; //총불량수
            reportParm9 = reportParm9 + tbContents.Text; // 검사 특이사항 (코멘트) 
            reportParm10 = reportParm10 + tbMiSap.Text; //미삽
            reportParm11 = reportParm11 + tbReverse.Text; //역삽
            reportParm12 = reportParm12 + tbMiNap.Text; //미납
            reportParm13 = reportParm13 + tbSonap.Text;//소납
            reportParm14 = reportParm14 + tbnengttem.Text; //냉땜
            reportParm15 = reportParm15 + tbTwisted.Text; //틀어짐
            reportParm16 = reportParm16 + tbLeadOpen.Text; //리드뜸
            reportParm17 = reportParm17 + tbManhattan.Text; // 맨하탄
            reportParm18 = reportParm18 + tbOverTurned.Text; //뒤집힘
            reportParm19 = reportParm19 + tbShort.Text; //쇼트
            reportParm20 = reportParm20 + tbEtcError.Text; // 기타

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
            ReportParameter rp9 = new ReportParameter("ReportParameter9", reportParm9);
            ReportParameter rp10 = new ReportParameter("ReportParameter10", reportParm10);
            ReportParameter rp11 = new ReportParameter("ReportParameter11", reportParm11);
            ReportParameter rp12 = new ReportParameter("ReportParameter12", reportParm12);
            ReportParameter rp13 = new ReportParameter("ReportParameter13", reportParm13);
            ReportParameter rp14 = new ReportParameter("ReportParameter14", reportParm14);
            ReportParameter rp15 = new ReportParameter("ReportParameter15", reportParm15);
            ReportParameter rp16 = new ReportParameter("ReportParameter16", reportParm16);
            ReportParameter rp17 = new ReportParameter("ReportParameter17", reportParm17);
            ReportParameter rp18 = new ReportParameter("ReportParameter18", reportParm18);
            ReportParameter rp19 = new ReportParameter("ReportParameter19", reportParm19);
            ReportParameter rp20 = new ReportParameter("ReportParameter20", reportParm20);

            viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12, rp13, rp14, rp15, rp16, rp17, rp18, rp19, rp20 });

            ReportDataSource rds = new ReportDataSource("DataSet1", sPProdResultQueryBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }

        private void pbPrint2_Click(object sender, EventArgs e)
        {
            string reportFileName = "SmartMES_Giroei.Reports.P1C02_PROD_RESULT_AOI.rdlc";

            string reportParm1 = "";
            string reportParm2 = "";
            string reportParm3 = "";
            string reportParm4 = "";
            string reportParm5 = "";
            string reportParm6 = "";
            string reportParm7 = "";
            string reportParm8 = "";
            string reportParm9 = " ";
            string reportParm10 = "";
            string reportParm11 = "";
            string reportParm12 = "";
            string reportParm13 = "";
            string reportParm14 = "";
            string reportParm15 = "";
            string reportParm16 = "";
            string reportParm17 = "";
            string reportParm18 = "";
            string reportParm19 = "";
            string reportParm20 = "";

            reportParm1 = reportParm1 + tbJobNo2.Text; // 수주번호
            reportParm2 = reportParm2 + tbCust2.Text; //업체명
            reportParm3 = reportParm3 + tbProd2.Text; //모델명
            reportParm4 = reportParm4 + cbWorkline2.Text; // 작업라인
            reportParm5 = reportParm5 + tbMakeQty2.Text + " pcs"; //생산수
            reportParm6 = reportParm6 + mstbEndtime2.Text; //검사일
            reportParm7 = reportParm7 + cbMan2.Text; //검사자
            reportParm8 = reportParm8 + tbDefectCount2.Text; //총불량수
            reportParm9 = reportParm9 + tbContents2.Text; // 검사 특이사항 (코멘트) 
            reportParm10 = reportParm10 + tbMiSap2.Text; //미삽
            reportParm11 = reportParm11 + tbReverse2.Text; //역삽
            reportParm12 = reportParm12 + tbMiNap2.Text; //미납
            reportParm13 = reportParm13 + tbSonap2.Text;//소납
            reportParm14 = reportParm14 + tbnengttem2.Text; //냉땜
            reportParm15 = reportParm15 + tbTwisted2.Text; //틀어짐
            reportParm16 = reportParm16 + tbLeadOpen2.Text; //리드뜸
            reportParm17 = reportParm17 + tbManhattan2.Text; // 맨하탄
            reportParm18 = reportParm18 + tbOverTurned2.Text; //뒤집힘
            reportParm19 = reportParm19 + tbShort2.Text; //쇼트
            reportParm20 = reportParm20 + tbEtcError2.Text; // 기타

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
            ReportParameter rp9 = new ReportParameter("ReportParameter9", reportParm9);
            ReportParameter rp10 = new ReportParameter("ReportParameter10", reportParm10);
            ReportParameter rp11 = new ReportParameter("ReportParameter11", reportParm11);
            ReportParameter rp12 = new ReportParameter("ReportParameter12", reportParm12);
            ReportParameter rp13 = new ReportParameter("ReportParameter13", reportParm13);
            ReportParameter rp14 = new ReportParameter("ReportParameter14", reportParm14);
            ReportParameter rp15 = new ReportParameter("ReportParameter15", reportParm15);
            ReportParameter rp16 = new ReportParameter("ReportParameter16", reportParm16);
            ReportParameter rp17 = new ReportParameter("ReportParameter17", reportParm17);
            ReportParameter rp18 = new ReportParameter("ReportParameter18", reportParm18);
            ReportParameter rp19 = new ReportParameter("ReportParameter19", reportParm19);
            ReportParameter rp20 = new ReportParameter("ReportParameter20", reportParm20);

            viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12, rp13, rp14, rp15, rp16, rp17, rp18, rp19, rp20 });

            ReportDataSource rds = new ReportDataSource("DataSet1", sPProdResultQueryBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }

        private void pbPrint3_Click(object sender, EventArgs e)
        {
            string reportFileName = "SmartMES_Giroei.Reports.P1C02_PROD_RESULT_AOI.rdlc";

            string reportParm1 = "";
            string reportParm2 = "";
            string reportParm3 = "";
            string reportParm4 = "";
            string reportParm5 = "";
            string reportParm6 = "";
            string reportParm7 = "";
            string reportParm8 = "";
            string reportParm9 = " ";
            string reportParm10 = "";
            string reportParm11 = "";
            string reportParm12 = "";
            string reportParm13 = "";
            string reportParm14 = "";
            string reportParm15 = "";
            string reportParm16 = "";
            string reportParm17 = "";
            string reportParm18 = "";
            string reportParm19 = "";
            string reportParm20 = "";

            reportParm1 = reportParm1 + tbJobNo3.Text; // 수주번호
            reportParm2 = reportParm2 + tbCust3.Text; //업체명
            reportParm3 = reportParm3 + tbProd3.Text; //모델명
            reportParm4 = reportParm4 + cbWorkline3.Text; // 작업라인
            reportParm5 = reportParm5 + tbMakeQty3.Text + " pcs"; //생산수
            reportParm6 = reportParm6 + mstbEndtime3.Text; //검사일
            reportParm7 = reportParm7 + cbMan3.Text; //검사자
            reportParm8 = reportParm8 + tbDefectCount3.Text; //총불량수
            reportParm9 = reportParm9 + tbContents3.Text; // 검사 특이사항 (코멘트) 
            reportParm10 = reportParm10 + tbMiSap3.Text; //미삽
            reportParm11 = reportParm11 + tbReverse3.Text; //역삽
            reportParm12 = reportParm12 + tbMiNap3.Text; //미납
            reportParm13 = reportParm13 + tbSonap3.Text;//소납
            reportParm14 = reportParm14 + tbnengttem3.Text; //냉땜
            reportParm15 = reportParm15 + tbTwisted3.Text; //틀어짐
            reportParm16 = reportParm16 + tbLeadOpen3.Text; //리드뜸
            reportParm17 = reportParm17 + tbManhattan3.Text; // 맨하탄
            reportParm18 = reportParm18 + tbOverTurned3.Text; //뒤집힘
            reportParm19 = reportParm19 + tbShort3.Text; //쇼트
            reportParm20 = reportParm20 + tbEtcError3.Text; // 기타

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
            ReportParameter rp9 = new ReportParameter("ReportParameter9", reportParm9);
            ReportParameter rp10 = new ReportParameter("ReportParameter10", reportParm10);
            ReportParameter rp11 = new ReportParameter("ReportParameter11", reportParm11);
            ReportParameter rp12 = new ReportParameter("ReportParameter12", reportParm12);
            ReportParameter rp13 = new ReportParameter("ReportParameter13", reportParm13);
            ReportParameter rp14 = new ReportParameter("ReportParameter14", reportParm14);
            ReportParameter rp15 = new ReportParameter("ReportParameter15", reportParm15);
            ReportParameter rp16 = new ReportParameter("ReportParameter16", reportParm16);
            ReportParameter rp17 = new ReportParameter("ReportParameter17", reportParm17);
            ReportParameter rp18 = new ReportParameter("ReportParameter18", reportParm18);
            ReportParameter rp19 = new ReportParameter("ReportParameter19", reportParm19);
            ReportParameter rp20 = new ReportParameter("ReportParameter20", reportParm20);

            viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12, rp13, rp14, rp15, rp16, rp17, rp18, rp19, rp20 });

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
            if (mstbEndtime.Text.Length > 0)
            {
                if (MessageBox.Show("다른 검사를 진행하시겠습니까?", "라인검사", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    gpResult.Visible = false;
                    gpAOI.Visible = false;
                    lblPrint.Visible = false;
                    BtPrint.Visible = false;

                    //탭페이지 초기화
                    tbDefectCount.Text = "0";
                    tbContents.Text = "";
                    tbSonap.Text = "0";
                    tbnengttem.Text = "0";
                    tbMiSap.Text = "0";
                    tbOverTurned.Text = "0";
                    tbLeadOpen.Text = "0";
                    tbMiNap.Text = "0";
                    tbShort.Text = "0";
                    tbReverse.Text = "0";
                    tbManhattan.Text = "0";
                    tbTwisted.Text = "0";
                    tbEtcError.Text = "0";
                    mstbStarttime.ResetText();
                    mstbEndtime.ResetText();
                    mstbIngtime.ResetText();
                    mstbPausetime.ResetText();
                    mstbContinuetime.ResetText();
                    mstbIngtime2.ResetText();
                    tbSeq.Text = "0";
                    return;
                }
                else
                {
                    return;
                }
            }
                if (MessageBox.Show("작업하실 라인과 검사자는 " + cbWorkline1.Text + "," + cbMan.Text + "님이 맞습니까?", "검사시작", MessageBoxButtons.YesNo) == DialogResult.Yes) //작업라인 및 검사자 고정
                {
                    tbProd.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString();
                    tbJobNo.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    tbCust.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString(); //업체명
                    tbMakeQty.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[12].Value.ToString();
                    cbWorkline1.Enabled = false;
                    cbMan.Enabled = false;

                    tbDefectCount.Text = "0";
                    tbContents.Text = "";
                    tbSonap.Text = "0";
                    tbnengttem.Text = "0";
                    tbMiSap.Text = "0";
                    tbOverTurned.Text = "0";
                    tbLeadOpen.Text = "0";
                    tbMiNap.Text = "0";
                    tbShort.Text = "0";
                    tbReverse.Text = "0";
                    tbManhattan.Text = "0";
                    tbTwisted.Text = "0";
                    tbEtcError.Text = "0";
                    mstbEndtime.ResetText();
                    mstbIngtime.ResetText();
                    mstbPausetime.ResetText();
                    mstbContinuetime.ResetText();
                    mstbIngtime2.ResetText();
                    tbSeq.Text = "0";
                }
                else
                {
                    return;
                }

                timer3.Enabled = true;
                timer3.Tick += new EventHandler(timer3_Tick);
                mstbIngtime.Visible = true;
                lblmstbIngtime.Visible = true;
                gpResult.Visible = false;
                gpAOI.Visible = false;
        }

        private void btEnd_Click(object sender, EventArgs e)
        {
            if (mstbStarttime.Text.Length < 0) //시작시간이 없으면
            {
                MessageBox.Show("시작되지 않은 검사는 종료 할 수 없습니다.");
                return;
            }
            //if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[17].Value.ToString() == "1라인" || dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[17].Value.ToString() == "2라인" || dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[17].Value.ToString() == "육안검사")
            //{
            //    if (mstbEndtime.Text.Length > 0)
            //    {
            //        MessageBox.Show("종료된 검사는 다시 종료 할 수 없습니다.");
            //        return;
            //    }
            //}
                if (timer4.Enabled == true)
                {
                    MessageBox.Show("다시 시작을 누른 후 종료해주세요.");
                }
                else
                {
                    // 멈춤 버튼
                    isTimeStarted = false;
                    timer3.Enabled = false;
                    gpResult.Visible = true;
                    gpAOI.Visible = true;
                    BtPrint.Visible = true;
                    lblPrint.Visible = true;
                }
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
            if (mstbPausetime.Text.Length > 0) //중지시간이 있으면
            {
                MessageBox.Show("새로운 중지가 필요하시면, 다시 시작을 눌러주세요.");
                return;
            }
            if (timer3.Enabled == false)
            {
                MessageBox.Show("검사가 끝난 제품은 중지 할 수 없습니다.");
            }
            else 
            {
                lbPause.Visible = true;
                cbPause.Visible = true;
                isTimeStarted = false;

                mstbPausetime.ResetText();
                timer4.Enabled = true;
                timer4.Tick += new EventHandler(timer4_Tick);
                mstbIngtime2.Visible = true;
                lblmstbIngtime2.Visible = true;
            }
        }

        private void btContinue_Click(object sender, EventArgs e)
        {
            if (timer4.Enabled == false)
            {
                MessageBox.Show("중지상태가 아니면 다시시작을 할 수 없습니다..");
            }
            else
            {
                int sSeq = 0;
                string sJob = tbJobNo.Text; // 작지번호
                string sPause = cbPause.SelectedValue.ToString();
                string sWorklineName = cbWorkline1.Text.ToString(); //작업라인이름
                string sWorkline = cbWorkline1.SelectedValue.ToString();//작업라인코드
                string sPausetime = DateTime.Parse(mstbPausetime.Text).ToString("yyyy-MM-dd HH:mm:ss"); //검사시작시간 insp_start_time 
                string sContinuetime = DateTime.Parse(mstbContinuetime.Text).ToString("yyyy-MM-dd HH:mm:ss"); //검사종료시간 insp_end_time
                string sInspIngTime2 = DateTime.Parse(mstbIngtime2.Text).ToString("HH:mm:ss"); //경과시간 insp_ing_time
                string sInspCount = tbMakeQty.Text; //검사수량
                string sTotalDefect = tbDefectCount.Text; //총불량수
                string sContents = tbContents.Text; //상세결과
                string sMan = cbMan.SelectedValue.ToString(); //검사자
                string sSonap = tbSonap.Text;
                string sNengttem = tbnengttem.Text;
                string sMisap = tbMiSap.Text;
                string sOverturned = tbOverTurned.Text;
                string sLeadopen = tbLeadOpen.Text;
                string sMinap = tbMiNap.Text;
                string sShort = tbShort.Text;
                string sReverse = tbReverse.Text;
                string sManhattan = tbManhattan.Text;
                string sTwisted = tbTwisted.Text;
                string sEtcerror = tbEtcError.Text;

                //string sFname1 = lbFname1.Text;
                //string sFname2 = lbFname2.Text;

                string sInspFromTime = DateTime.Parse(mstbStarttime.Text).ToString("yyyy-MM-dd HH:mm:ss"); //검사시작시간 insp_start_time 
                string sInspToTime = DateTime.Parse(mstbEndtime.Text).ToString("yyyy-MM-dd HH:mm:ss"); //검사종료시간 insp_end_time
                string sInspIngTime = DateTime.Parse(mstbIngtime.Text).ToString("HH:mm:ss"); //경과시간 insp_ing_time

                string sql = string.Empty;

                string fname1 = string.Empty;
                string fname2 = string.Empty;
                byte[] rawdata1 = new byte[0];
                byte[] rawdata2 = new byte[0];

                if (sWorklineName == "1라인")
                {
                    if (dataGridView2.RowCount > 0) //로스 테이블에 카운트가 있을 경우 카운트+1로 Seq를 증가시킴.
                    {
                        int SeqCount = dataGridView2.RowCount;
                        sSeq = SeqCount + 1;
                    }
                    else
                    {
                        sSeq = 0;
                        sSeq = sSeq + 1;
                    }
                }
                if (sWorklineName == "2라인")
                {
                    if (dataGridView3.RowCount > 0) //로스 테이블에 카운트가 있을 경우 카운트+1로 Seq를 증가시킴.
                    {
                        int SeqCount = dataGridView3.RowCount;
                        sSeq = SeqCount + 1;
                    }
                    else
                    {
                        sSeq = 0;
                        sSeq = sSeq + 1;
                    }
                }
                if (sWorklineName == "육안검사")
                {
                    if (dataGridView4.RowCount > 0) //로스 테이블에 카운트가 있을 경우 카운트+1로 Seq를 증가시킴.
                    {
                        int SeqCount = dataGridView4.RowCount;
                        sSeq = SeqCount + 1;
                    }
                    else
                    {
                        sSeq = 0;
                        sSeq = sSeq + 1;
                    }
                }
                tbSeq.Text = sSeq.ToString();
                sql = string.Empty;

                MySqlConnection con = new MySqlConnection(G.conStr);
                MySqlCommand cmd = new MySqlCommand();
                con.Open();

                if (MessageBox.Show("선택하신 중지사유는 " + cbPause.Text + " 입니다.", "중지사유", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lbMsg.Text = "";

                    if (string.IsNullOrEmpty(tbJobNo.Text)) // tbJobNo.Text
                    {
                        lbMsg.Text = "검사리스트가 선택되지 않았습니다.";
                        return;
                    }
                    if (string.IsNullOrEmpty(mstbEndtime.Text))
                    {
                        lbMsg.Text = "작업이 종료되어야 저장할 수 있습니다.";
                        return;
                    }

                    con = new MySqlConnection(G.conStr);
                    cmd = new MySqlCommand();
                    con.Open();

                    sql = "insert into QLT_inspection_AOI (job_no, insp_start_time, insp_end_time, insp_ing_time, insp_qty, defect_count, sonap, nengttem, misap, overturned, leadopen, minap, short, reverse, manhattan, twisted, etc_error, contents, worklinename, workline, enter_man)" +
                            " values('" + sJob + "','" + sInspFromTime + "','" + sInspToTime + "','" + sInspIngTime + "'," + sInspCount + "," + sTotalDefect + "," + sSonap + "," + sNengttem + "," + sMisap + "," + sOverturned + "," + sLeadopen + "," + sMinap + "," + sShort + "," + sReverse + "," +
                                sManhattan + "," + sTwisted + "," + sEtcerror + ",'" + sContents + "','" + sWorklineName + "','" + sWorkline + "','" + sMan + "')"
                                + " on duplicate key update" + " insp_start_time = '" + sInspFromTime + "', insp_end_time = '" + sInspToTime + "', insp_ing_time = '" + sInspIngTime + "',"
                                + " insp_qty = " + sInspCount + ", defect_count = " + sTotalDefect + ", sonap = " + sSonap + ", nengttem = " + sNengttem
                                + ", misap = " + sMisap + ", overturned = " + sOverturned + ", leadopen = " + sLeadopen + ", minap = " + sMinap + ", short = " + sShort + ", reverse = " + sReverse
                                + ", manhattan = " + sManhattan + ", twisted = " + sTwisted + ", etc_error = " + sEtcerror
                                + ", contents = '" + sContents + "', worklinename ='" + sWorklineName + "', workline ='" + sWorkline + "', enter_man = '" + sMan + "'";

                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    con.Close();

                    con.Open();

                    sql = "insert into QLT_inspection_AOI_Loss (job_no, seq, workline, worklinename, start_time, end_time, ing_time, reason_code, enter_dt)" +
                        " values('" + sJob + "','" + sSeq + "','" + sWorkline + "','" + sWorklineName + "','" + sPausetime + "','" + sContinuetime + "','" + sInspIngTime2 + "','" + sPause + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";

                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    con.Close();

                    lbMsg.Text = "저장되었습니다.";
                    timer4.Enabled = false;
                    lbPause.Visible = false;
                    cbPause.Visible = false;
                    lblmstbIngtime2.Visible = false;
                    mstbIngtime2.Visible = false;
                    lblSeq.Visible = true;
                    tbSeq.Visible = true;
                    ListSearch2();
                }
            }
        }
        public void timer5_Tick(object sender, EventArgs e) // SDT...5,6,7,8
        {
            //lbIngtime.Text = DateTime.Now.ToString("hh:MM:dd mm:ss");

            // 현재시간 -- Load 시점에 설정으로 변경
            //DateTime SDT1 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (isTimeStarted2 == false)
            {
                isTimeStarted2 = true;
                SDT5 = DateTime.Now;
            }
            //비가동 시작시간
            DateTime SDT6 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // DateTime.Parse(dtpDate.Value.ToString("yyyy-MM-dd HH:mm:ss")); 

            //시간 차이 구함
            TimeSpan gapTime = SDT5 - SDT6;

            mstbStarttime2.Text = SDT5.ToString();
            mstbEndtime2.Text = SDT6.ToString();
            mstbIngtime_2.Text = gapTime.ToString();
        }

        private void btStart2_Click(object sender, EventArgs e)
        {
            // 시작 버튼
            if (mstbEndtime2.Text.Length > 0)
            {
                if (MessageBox.Show("다른 검사를 진행하시겠습니까?", "라인검사", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    gpResult2.Visible = false;
                    gpAOI2.Visible = false;
                    lblPrint2.Visible = false;
                    BtPrint2.Visible = false;

                    //탭페이지 초기화
                    tbDefectCount2.Text = "0";
                    tbContents2.Text = "";
                    tbSonap2.Text = "0";
                    tbnengttem2.Text = "0";
                    tbMiSap2.Text = "0";
                    tbOverTurned2.Text = "0";
                    tbLeadOpen2.Text = "0";
                    tbMiNap2.Text = "0";
                    tbShort2.Text = "0";
                    tbReverse2.Text = "0";
                    tbManhattan2.Text = "0";
                    tbTwisted2.Text = "0";
                    tbEtcError2.Text = "0";
                    mstbStarttime2.ResetText();
                    mstbEndtime2.ResetText();
                    mstbIngtime2.ResetText();
                    mstbPausetime2.ResetText();
                    mstbContinuetime2.ResetText();
                    mstbIngtime2_2.ResetText();
                    tbSeq2.Text = "0";
                    return;
                }
                else
                {
                    return;
                }
            }
            if (MessageBox.Show("작업하실 라인과 검사자는 " + cbWorkline2.Text + "," + cbMan2.Text + "님이 맞습니까?", "검사시작", MessageBoxButtons.YesNo) == DialogResult.Yes) //작업라인 및 검사자 고정
            {
                tbProd2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString();
                tbJobNo2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                tbCust2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString(); //업체명
                tbMakeQty2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[12].Value.ToString();
                cbWorkline2.Enabled = false;
                cbMan2.Enabled = false;

                tbDefectCount2.Text = "0";
                tbContents2.Text = "";
                tbSonap2.Text = "0";
                tbnengttem2.Text = "0";
                tbMiSap2.Text = "0";
                tbOverTurned2.Text = "0";
                tbLeadOpen2.Text = "0";
                tbMiNap2.Text = "0";
                tbShort2.Text = "0";
                tbReverse2.Text = "0";
                tbManhattan2.Text = "0";
                tbTwisted2.Text = "0";
                tbEtcError2.Text = "0";
                mstbEndtime2.ResetText();
                mstbIngtime2.ResetText();
                mstbPausetime2.ResetText();
                mstbContinuetime2.ResetText();
                mstbIngtime2_2.ResetText();
                tbSeq2.Text = "0";
            }
            else
            {
                return;
            }

            timer5.Enabled = true;
            timer5.Tick += new EventHandler(timer5_Tick);
            mstbIngtime_2.Visible = true;
            lblmstbIngtime_2.Visible = true;
            gpResult2.Visible = false;
            gpAOI2.Visible = false;
        }

        private void btEnd2_Click(object sender, EventArgs e)
        {
            if (mstbStarttime2.Text.Length < 0) //시작시간이 없으면
            {
                MessageBox.Show("시작되지 않은 검사는 종료 할 수 없습니다.");
                return;
            }
            //if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[17].Value.ToString() == "1라인" || dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[17].Value.ToString() == "2라인" || dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[17].Value.ToString() == "육안검사")
            //{
            //    if (mstbEndtime.Text.Length > 0)
            //    {
            //        MessageBox.Show("종료된 검사는 다시 종료 할 수 없습니다.");
            //        return;
            //    }
            //}
            if (timer6.Enabled == true)
            {
                MessageBox.Show("다시 시작을 누른 후 종료해주세요.");
            }
            else
            {
                // 멈춤 버튼
                isTimeStarted2 = false;
                timer5.Enabled = false;
                gpResult2.Visible = true;
                gpAOI2.Visible = true;
                BtPrint2.Visible = true;
                lblPrint2.Visible = true;
            }
        }
        public void timer6_Tick(object sender, EventArgs e) // SDT...5,6,7,8
        {
            //lbIngtime.Text = DateTime.Now.ToString("hh:MM:dd mm:ss");

            // 현재시간 -- Load 시점에 설정으로 변경
            //DateTime SDT1 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (isTimeStarted2 == false)
            {
                isTimeStarted2 = true;
                SDT7 = DateTime.Now;
            }
            //비가동 시작시간
            DateTime SDT8 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // DateTime.Parse(dtpDate.Value.ToString("yyyy-MM-dd HH:mm:ss")); 

            //시간 차이 구함
            TimeSpan gapTime = SDT7 - SDT8;

            mstbPausetime.Text = SDT7.ToString();
            mstbContinuetime.Text = SDT8.ToString();
            mstbIngtime2.Text = gapTime.ToString();
        }

        private void btPause2_Click(object sender, EventArgs e)
        {
            if (mstbPausetime2.Text.Length > 0) //중지시간이 있으면
            {
                MessageBox.Show("새로운 중지가 필요하시면, 다시 시작을 눌러주세요.");
                return;
            }
            if (timer5.Enabled == false)
            {
                MessageBox.Show("검사가 끝난 제품은 중지 할 수 없습니다.");
            }
            else
            {
                lbPause2.Visible = true;
                cbPause2.Visible = true;
                isTimeStarted2 = false;

                mstbPausetime2.ResetText();
                timer6.Enabled = true;
                timer6.Tick += new EventHandler(timer6_Tick);
                mstbIngtime2_2.Visible = true;
                lblmstbIngtime2_2.Visible = true;
            }
        }

        private void btContinue2_Click(object sender, EventArgs e)
        {
            if (timer6.Enabled == false)
            {
                MessageBox.Show("중지상태가 아니면 다시시작을 할 수 없습니다..");
            }
            else
            {
                int sSeq2 = 0;
                string sJob2 = tbJobNo2.Text; // 작지번호
                string sPause2 = cbPause2.SelectedValue.ToString();
                string sWorklineName2 = cbWorkline2.Text.ToString(); //작업라인이름
                string sWorkline2 = cbWorkline2.SelectedValue.ToString();//작업라인코드
                string sPausetime2 = DateTime.Parse(mstbPausetime2.Text).ToString("yyyy-MM-dd HH:mm:ss"); //검사시작시간 insp_start_time 
                string sContinuetime2 = DateTime.Parse(mstbContinuetime2.Text).ToString("yyyy-MM-dd HH:mm:ss"); //검사종료시간 insp_end_time
                string sInspIngTime2_2 = DateTime.Parse(mstbIngtime2_2.Text).ToString("HH:mm:ss"); //경과시간 insp_ing_time
                string sInspCount2 = tbMakeQty2.Text; //검사수량
                string sTotalDefect2 = tbDefectCount2.Text; //총불량수
                string sContents2 = tbContents2.Text; //상세결과
                string sMan2 = cbMan2.SelectedValue.ToString(); //검사자
                string sSonap2 = tbSonap2.Text;
                string sNengttem2 = tbnengttem2.Text;
                string sMisap2 = tbMiSap2.Text;
                string sOverturned2 = tbOverTurned2.Text;
                string sLeadopen2 = tbLeadOpen2.Text;
                string sMinap2 = tbMiNap2.Text;
                string sShort2 = tbShort2.Text;
                string sReverse2 = tbReverse2.Text;
                string sManhattan2 = tbManhattan2.Text;
                string sTwisted2 = tbTwisted2.Text;
                string sEtcerror2 = tbEtcError2.Text;

                //string sFname1 = lbFname1.Text;
                //string sFname2 = lbFname2.Text;

                string sInspFromTime2 = DateTime.Parse(mstbStarttime2.Text).ToString("yyyy-MM-dd HH:mm:ss"); //검사시작시간 insp_start_time 
                string sInspToTime2 = DateTime.Parse(mstbEndtime2.Text).ToString("yyyy-MM-dd HH:mm:ss"); //검사종료시간 insp_end_time
                string sInspIngTime2 = DateTime.Parse(mstbIngtime2.Text).ToString("HH:mm:ss"); //경과시간 insp_ing_time

                string sql = string.Empty;

                string fname1 = string.Empty;
                string fname2 = string.Empty;
                byte[] rawdata1 = new byte[0];
                byte[] rawdata2 = new byte[0];

                if (sWorklineName2 == "1라인")
                {
                    if (dataGridView2.RowCount > 0) //로스 테이블에 카운트가 있을 경우 카운트+1로 Seq를 증가시킴.
                    {
                        int SeqCount = dataGridView2.RowCount;
                        sSeq2 = SeqCount + 1;
                    }
                    else
                    {
                        sSeq2 = 0;
                        sSeq2 = sSeq2 + 1;
                    }
                }
                if (sWorklineName2 == "2라인")
                {
                    if (dataGridView3.RowCount > 0) //로스 테이블에 카운트가 있을 경우 카운트+1로 Seq를 증가시킴.
                    {
                        int SeqCount = dataGridView3.RowCount;
                        sSeq2 = SeqCount + 1;
                    }
                    else
                    {
                        sSeq2 = 0;
                        sSeq2 = sSeq2 + 1;
                    }
                }
                if (sWorklineName2 == "육안검사")
                {
                    if (dataGridView4.RowCount > 0) //로스 테이블에 카운트가 있을 경우 카운트+1로 Seq를 증가시킴.
                    {
                        int SeqCount = dataGridView4.RowCount;
                        sSeq2 = SeqCount + 1;
                    }
                    else
                    {
                        sSeq2 = 0;
                        sSeq2 = sSeq2 + 1;
                    }
                }
                tbSeq2.Text = sSeq2.ToString();
                sql = string.Empty;

                MySqlConnection con = new MySqlConnection(G.conStr);
                MySqlCommand cmd = new MySqlCommand();
                con.Open();

                if (MessageBox.Show("선택하신 중지사유는 " + cbPause2.Text + " 입니다.", "중지사유", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lbMsg.Text = "";

                    if (string.IsNullOrEmpty(tbJobNo.Text)) // tbJobNo.Text
                    {
                        lbMsg2.Text = "검사리스트가 선택되지 않았습니다.";
                        return;
                    }
                    if (string.IsNullOrEmpty(mstbEndtime.Text))
                    {
                        lbMsg2.Text = "작업이 종료되어야 저장할 수 있습니다.";
                        return;
                    }

                    con = new MySqlConnection(G.conStr);
                    cmd = new MySqlCommand();
                    con.Open();

                    sql = "insert into QLT_inspection_AOI (job_no, insp_start_time, insp_end_time, insp_ing_time, insp_qty, defect_count, sonap, nengttem, misap, overturned, leadopen, minap, short, reverse, manhattan, twisted, etc_error, contents, worklinename, workline, enter_man)" +
                            " values('" + sJob2 + "','" + sInspFromTime2 + "','" + sInspToTime2 + "','" + sInspIngTime2 + "'," + sInspCount2 + "," + sTotalDefect2 + "," + sSonap2 + "," + sNengttem2 + "," + sMisap2 + "," + sOverturned2 + "," + sLeadopen2 + "," + sMinap2 + "," + sShort2 + "," + sReverse2 + "," +
                                sManhattan2 + "," + sTwisted2 + "," + sEtcerror2 + ",'" + sContents2 + "','" + sWorklineName2 + "','" + sWorkline2 + "','" + sMan2 + "')"
                                + " on duplicate key update" + " insp_start_time = '" + sInspFromTime2 + "', insp_end_time = '" + sInspToTime2 + "', insp_ing_time = '" + sInspIngTime2 + "',"
                                + " insp_qty = " + sInspCount2 + ", defect_count = " + sTotalDefect2 + ", sonap = " + sSonap2 + ", nengttem = " + sNengttem2
                                + ", misap = " + sMisap2 + ", overturned = " + sOverturned2 + ", leadopen = " + sLeadopen2 + ", minap = " + sMinap2 + ", short = " + sShort2 + ", reverse = " + sReverse2
                                + ", manhattan = " + sManhattan2 + ", twisted = " + sTwisted2 + ", etc_error = " + sEtcerror2
                                + ", contents = '" + sContents2 + "', worklinename ='" + sWorklineName2 + "', workline ='" + sWorkline2 + "', enter_man = '" + sMan2 + "'";

                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    con.Close();

                    con.Open();

                    sql = "insert into QLT_inspection_AOI_Loss (job_no, seq, workline, worklinename, start_time, end_time, ing_time, reason_code, enter_dt)" +
                        " values('" + sJob2 + "','" + sSeq2 + "','" + sWorkline2 + "','" + sWorklineName2 + "','" + sPausetime2 + "','" + sContinuetime2 + "','" + sInspIngTime2_2 + "','" + sPause2 + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";

                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    con.Close();

                    lbMsg2.Text = "저장되었습니다.";
                    timer6.Enabled = false;
                    lbPause2.Visible = false;
                    cbPause2.Visible = false;
                    lblmstbIngtime2_2.Visible = false;
                    mstbIngtime2_2.Visible = false;
                    lblSeq2.Visible = true;
                    tbSeq2.Visible = true;
                    ListSearch2();
                }
            }
        }

        public void timer7_Tick(object sender, EventArgs e) //SDT...9,10,11,12
        {
            //lbIngtime.Text = DateTime.Now.ToString("hh:MM:dd mm:ss");

            // 현재시간 -- Load 시점에 설정으로 변경
            //DateTime SDT1 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (isTimeStarted3 == false)
            {
                isTimeStarted3 = true;
                SDT9 = DateTime.Now;
            }
            //비가동 시작시간
            DateTime SDT10 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // DateTime.Parse(dtpDate.Value.ToString("yyyy-MM-dd HH:mm:ss")); 

            //시간 차이 구함
            TimeSpan gapTime = SDT9 - SDT10;

            mstbStarttime3.Text = SDT9.ToString();
            mstbEndtime3.Text = SDT10.ToString();
            mstbIngtime_3.Text = gapTime.ToString();
        }

        private void btStart3_Click(object sender, EventArgs e)
        {
            // 시작 버튼
            if (mstbEndtime3.Text.Length > 0)
            {
                if (MessageBox.Show("다른 검사를 진행하시겠습니까?", "라인검사", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    gpResult3.Visible = false;
                    gpAOI3.Visible = false;
                    lblPrint3.Visible = false;
                    BtPrint3.Visible = false;

                    //탭페이지 초기화
                    tbDefectCount3.Text = "0";
                    tbContents3.Text = "";
                    tbSonap3.Text = "0";
                    tbnengttem3.Text = "0";
                    tbMiSap3.Text = "0";
                    tbOverTurned3.Text = "0";
                    tbLeadOpen3.Text = "0";
                    tbMiNap3.Text = "0";
                    tbShort3.Text = "0";
                    tbReverse3.Text = "0";
                    tbManhattan3.Text = "0";
                    tbTwisted3.Text = "0";
                    tbEtcError3.Text = "0";
                    mstbStarttime3.ResetText();
                    mstbEndtime3.ResetText();
                    mstbIngtime_3.ResetText();
                    mstbPausetime3.ResetText();
                    mstbContinuetime3.ResetText();
                    mstbIngtime_3.ResetText();
                    tbSeq3.Text = "0";
                    return;
                }
                else
                {
                    return;
                }
            }
            if (MessageBox.Show("작업하실 라인과 검사자는 " + cbWorkline3.Text + "," + cbMan3.Text + "님이 맞습니까?", "검사시작", MessageBoxButtons.YesNo) == DialogResult.Yes) //작업라인 및 검사자 고정
            {
                tbProd3.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString();
                tbJobNo3.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                tbCust3.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString(); //업체명
                tbMakeQty3.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[12].Value.ToString();
                cbWorkline3.Enabled = false;
                cbMan3.Enabled = false;

                tbDefectCount3.Text = "0";
                tbContents3.Text = "";
                tbSonap3.Text = "0";
                tbnengttem3.Text = "0";
                tbMiSap3.Text = "0";
                tbOverTurned3.Text = "0";
                tbLeadOpen3.Text = "0";
                tbMiNap3.Text = "0";
                tbShort3.Text = "0";
                tbReverse3.Text = "0";
                tbManhattan3.Text = "0";
                tbTwisted3.Text = "0";
                tbEtcError3.Text = "0";
                mstbEndtime3.ResetText();
                mstbIngtime_3.ResetText();
                mstbPausetime3.ResetText();
                mstbContinuetime3.ResetText();
                mstbIngtime2_3.ResetText();
                tbSeq3.Text = "0";
            }
            else
            {
                return;
            }

            timer7.Enabled = true;
            timer7.Tick += new EventHandler(timer7_Tick);
            mstbIngtime_3.Visible = true;
            lblmstbIngtime_3.Visible = true;
            gpResult3.Visible = false;
            gpAOI3.Visible = false;
        }

        private void btEnd3_Click(object sender, EventArgs e)
        {
            if (mstbStarttime3.Text.Length < 0) //시작시간이 없으면
            {
                MessageBox.Show("시작되지 않은 검사는 종료 할 수 없습니다.");
                return;
            }
            //if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[17].Value.ToString() == "1라인" || dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[17].Value.ToString() == "2라인" || dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[17].Value.ToString() == "육안검사")
            //{
            //    if (mstbEndtime.Text.Length > 0)
            //    {
            //        MessageBox.Show("종료된 검사는 다시 종료 할 수 없습니다.");
            //        return;
            //    }
            //}
            if (timer8.Enabled == true)
            {
                MessageBox.Show("다시 시작을 누른 후 종료해주세요.");
            }
            else
            {
                // 멈춤 버튼
                isTimeStarted3 = false;
                timer7.Enabled = false;
                gpResult3.Visible = true;
                gpAOI3.Visible = true;
                BtPrint3.Visible = true;
                lblPrint3.Visible = true;
            }
        }
        public void timer8_Tick(object sender, EventArgs e)
        {
            //lbIngtime.Text = DateTime.Now.ToString("hh:MM:dd mm:ss");

            // 현재시간 -- Load 시점에 설정으로 변경
            //DateTime SDT1 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (isTimeStarted3 == false)
            {
                isTimeStarted3 = true;
                SDT11 = DateTime.Now;
            }
            //비가동 시작시간
            DateTime SDT12 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // DateTime.Parse(dtpDate.Value.ToString("yyyy-MM-dd HH:mm:ss")); 

            //시간 차이 구함
            TimeSpan gapTime = SDT11 - SDT12;

            mstbPausetime3.Text = SDT11.ToString();
            mstbContinuetime3.Text = SDT12.ToString();
            mstbIngtime2_3.Text = gapTime.ToString();
        }

        private void btPause3_Click(object sender, EventArgs e)
        {
            if (mstbPausetime3.Text.Length > 0) //중지시간이 있으면
            {
                MessageBox.Show("새로운 중지가 필요하시면, 다시 시작을 눌러주세요.");
                return;
            }
            if (timer7.Enabled == false)
            {
                MessageBox.Show("검사가 끝난 제품은 중지 할 수 없습니다.");
            }
            else
            {
                lbPause3.Visible = true;
                cbPause3.Visible = true;
                isTimeStarted3 = false;

                mstbPausetime3.ResetText();
                timer8.Enabled = true;
                timer8.Tick += new EventHandler(timer8_Tick);
                mstbIngtime2_3.Visible = true;
                lblmstbIngtime2_3.Visible = true;
            }
        }

        private void btContinue3_Click(object sender, EventArgs e)
        {
            if (timer8.Enabled == false)
            {
                MessageBox.Show("중지상태가 아니면 다시시작을 할 수 없습니다..");
            }
            else
            {
                int sSeq3 = 0;
                string sJob3 = tbJobNo3.Text; // 작지번호
                string sPause3 = cbPause3.SelectedValue.ToString();
                string sWorklineName3 = cbWorkline3.Text.ToString(); //작업라인이름
                string sWorkline3 = cbWorkline3.SelectedValue.ToString();//작업라인코드
                string sPausetime3 = DateTime.Parse(mstbPausetime3.Text).ToString("yyyy-MM-dd HH:mm:ss"); //검사시작시간 insp_start_time 
                string sContinuetime3 = DateTime.Parse(mstbContinuetime3.Text).ToString("yyyy-MM-dd HH:mm:ss"); //검사종료시간 insp_end_time
                string sInspIngTime2_3 = DateTime.Parse(mstbIngtime2_3.Text).ToString("HH:mm:ss"); //경과시간 insp_ing_time
                string sInspCount3 = tbMakeQty3.Text; //검사수량
                string sTotalDefect3 = tbDefectCount3.Text; //총불량수
                string sContents3 = tbContents3.Text; //상세결과
                string sMan3 = cbMan3.SelectedValue.ToString(); //검사자
                string sSonap3 = tbSonap3.Text;
                string sNengttem3 = tbnengttem3.Text;
                string sMisap3 = tbMiSap3.Text;
                string sOverturned3 = tbOverTurned3.Text;
                string sLeadopen3 = tbLeadOpen3.Text;
                string sMinap3 = tbMiNap3.Text;
                string sShort3 = tbShort3.Text;
                string sReverse3 = tbReverse3.Text;
                string sManhattan3 = tbManhattan3.Text;
                string sTwisted3 = tbTwisted3.Text;
                string sEtcerror3 = tbEtcError3.Text;

                //string sFname1 = lbFname1.Text;
                //string sFname2 = lbFname2.Text;

                string sInspFromTime3 = DateTime.Parse(mstbStarttime3.Text).ToString("yyyy-MM-dd HH:mm:ss"); //검사시작시간 insp_start_time 
                string sInspToTime3 = DateTime.Parse(mstbEndtime3.Text).ToString("yyyy-MM-dd HH:mm:ss"); //검사종료시간 insp_end_time
                string sInspIngTime3 = DateTime.Parse(mstbIngtime_3.Text).ToString("HH:mm:ss"); //경과시간 insp_ing_time

                string sql = string.Empty;

                string fname1 = string.Empty;
                string fname2 = string.Empty;
                byte[] rawdata1 = new byte[0];
                byte[] rawdata2 = new byte[0];

                if (sWorklineName3 == "1라인")
                {
                    if (dataGridView2.RowCount > 0) //로스 테이블에 카운트가 있을 경우 카운트+1로 Seq를 증가시킴.
                    {
                        int SeqCount = dataGridView2.RowCount;
                        sSeq3 = SeqCount + 1;
                    }
                    else
                    {
                        sSeq3 = 0;
                        sSeq3 = sSeq3 + 1;
                    }
                }
                if (sWorklineName3 == "2라인")
                {
                    if (dataGridView3.RowCount > 0) //로스 테이블에 카운트가 있을 경우 카운트+1로 Seq를 증가시킴.
                    {
                        int SeqCount = dataGridView3.RowCount;
                        sSeq3 = SeqCount + 1;
                    }
                    else
                    {
                        sSeq3 = 0;
                        sSeq3 = sSeq3 + 1;
                    }
                }
                if (sWorklineName3 == "육안검사")
                {
                    if (dataGridView4.RowCount > 0) //로스 테이블에 카운트가 있을 경우 카운트+1로 Seq를 증가시킴.
                    {
                        int SeqCount = dataGridView4.RowCount;
                        sSeq3 = SeqCount + 1;
                    }
                    else
                    {
                        sSeq3 = 0;
                        sSeq3 = sSeq3 + 1;
                    }
                }
                tbSeq3.Text = sSeq3.ToString();
                sql = string.Empty;

                MySqlConnection con = new MySqlConnection(G.conStr);
                MySqlCommand cmd = new MySqlCommand();
                con.Open();

                if (MessageBox.Show("선택하신 중지사유는 " + cbPause3.Text + " 입니다.", "중지사유", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lbMsg3.Text = "";

                    if (string.IsNullOrEmpty(tbJobNo3.Text)) // tbJobNo.Text
                    {
                        lbMsg3.Text = "검사리스트가 선택되지 않았습니다.";
                        return;
                    }
                    if (string.IsNullOrEmpty(mstbEndtime3.Text))
                    {
                        lbMsg3.Text = "작업이 종료되어야 저장할 수 있습니다.";
                        return;
                    }

                    con = new MySqlConnection(G.conStr);
                    cmd = new MySqlCommand();
                    con.Open();

                    sql = "insert into QLT_inspection_AOI (job_no, insp_start_time, insp_end_time, insp_ing_time, insp_qty, defect_count, sonap, nengttem, misap, overturned, leadopen, minap, short, reverse, manhattan, twisted, etc_error, contents, worklinename, workline, enter_man)" +
                            " values('" + sJob3 + "','" + sInspFromTime3 + "','" + sInspToTime3 + "','" + sInspIngTime3 + "'," + sInspCount3 + "," + sTotalDefect3 + "," + sSonap3 + "," + sNengttem3 + "," + sMisap3 + "," + sOverturned3 + "," + sLeadopen3 + "," + sMinap3 + "," + sShort3 + "," + sReverse3 + "," +
                                sManhattan3 + "," + sTwisted3 + "," + sEtcerror3 + ",'" + sContents3 + "','" + sWorklineName3 + "','" + sWorkline3 + "','" + sMan3 + "')"
                                + " on duplicate key update" + " insp_start_time = '" + sInspFromTime3 + "', insp_end_time = '" + sInspToTime3 + "', insp_ing_time = '" + sInspIngTime3 + "',"
                                + " insp_qty = " + sInspCount3 + ", defect_count = " + sTotalDefect3 + ", sonap = " + sSonap3 + ", nengttem = " + sNengttem3
                                + ", misap = " + sMisap3 + ", overturned = " + sOverturned3 + ", leadopen = " + sLeadopen3 + ", minap = " + sMinap3 + ", short = " + sShort3 + ", reverse = " + sReverse3
                                + ", manhattan = " + sManhattan3 + ", twisted = " + sTwisted3 + ", etc_error = " + sEtcerror3
                                + ", contents = '" + sContents3 + "', worklinename ='" + sWorklineName3 + "', workline ='" + sWorkline3 + "', enter_man = '" + sMan3 + "'";

                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    con.Close();

                    con.Open();

                    sql = "insert into QLT_inspection_AOI_Loss (job_no, seq, workline, worklinename, start_time, end_time, ing_time, reason_code, enter_dt)" +
                        " values('" + sJob3 + "','" + sSeq3 + "','" + sWorkline3 + "','" + sWorklineName3 + "','" + sPausetime3 + "','" + sContinuetime3 + "','" + sInspIngTime2_3 + "','" + sPause3 + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";

                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    con.Close();

                    lbMsg3.Text = "저장되었습니다.";
                    timer8.Enabled = false;
                    lbPause3.Visible = false;
                    cbPause3.Visible = false;
                    lblmstbIngtime2_3.Visible = false;
                    mstbIngtime2_3.Visible = false;
                    lblSeq3.Visible = true;
                    tbSeq3.Visible = true;
                    ListSearch2();
                }
            }
        }
        #region 검사내역 +-버튼
        private void Pbt1_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbTwisted.Text);
            i = i + 1;
            tbTwisted.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            l = l + 1;
            tbDefectCount.Text = l.ToString();
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
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount.Text = l.ToString();
            }
        }

        private void Pbt2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbLeadOpen.Text);
            i = i + 1;
            tbLeadOpen.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            l = l + 1;
            tbDefectCount.Text = l.ToString();
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
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount.Text = l.ToString();
            }
        }

        private void Pbt3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbManhattan.Text);
            i = i + 1;
            tbManhattan.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            l = l + 1;
            tbDefectCount.Text = l.ToString();
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
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount.Text = l.ToString();
            }
        }
        
        private void Pbt4_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbOverTurned.Text);
            i = i + 1;
            tbOverTurned.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            l = l + 1;
            tbDefectCount.Text = l.ToString();
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
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount.Text = l.ToString();
            }
        }
        
        private void Pbt5_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbShort.Text);
            i = i + 1;
            tbShort.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            l = l + 1;
            tbDefectCount.Text = l.ToString();
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
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount.Text = l.ToString();
            }
        }

        private void Pbt6_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbEtcError.Text);
            i = i + 1;
            tbEtcError.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            l = l + 1;
            tbDefectCount.Text = l.ToString();
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
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount.Text = l.ToString();
            }
        }
        
        private void Pbt7_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbMiSap.Text);
            i = i + 1;
            tbMiSap.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            l = l + 1;
            tbDefectCount.Text = l.ToString();
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
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount.Text = l.ToString();
            }
        }
        
        private void Pbt8_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbReverse.Text);
            i = i + 1;
            tbReverse.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            l = l + 1;
            tbDefectCount.Text = l.ToString();
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
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount.Text = l.ToString();
            }
        }
        
        private void Pbt9_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbMiNap.Text);
            i = i + 1;
            tbMiNap.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            l = l + 1;
            tbDefectCount.Text = l.ToString();
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
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount.Text = l.ToString();
            }
        }
        
        private void Pbt10_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbSonap.Text);
            i = i + 1;
            tbSonap.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            l = l + 1;
            tbDefectCount.Text = l.ToString();
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
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount.Text = l.ToString();
            }
        }
        
        private void Pbt11_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbnengttem.Text);
            i = i + 1;
            tbnengttem.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            l = l + 1;
            tbDefectCount.Text = l.ToString();
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
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount.Text = l.ToString();
            }
        }
        #endregion
        #region 검사내역 +-버튼2
        private void Pbt1_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbTwisted2.Text);
            i = i + 1;
            tbTwisted2.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            l = l + 1;
            tbDefectCount2.Text = l.ToString();
        }

        private void Mbt1_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbTwisted2.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbTwisted2.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount2.Text = l.ToString();
            }
        }

        private void Pbt2_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbLeadOpen2.Text);
            i = i + 1;
            tbLeadOpen2.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            l = l + 1;
            tbDefectCount2.Text = l.ToString();
        }

        private void Mbt2_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbLeadOpen2.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbLeadOpen2.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount2.Text = l.ToString();
            }
        }

        private void Pbt3_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbManhattan2.Text);
            i = i + 1;
            tbManhattan2.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            l = l + 1;
            tbDefectCount2.Text = l.ToString();
        }

        private void Mbt3_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbManhattan2.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbManhattan2.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount2.Text = l.ToString();
            }
        }

        private void Pbt4_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbOverTurned2.Text);
            i = i + 1;
            tbOverTurned2.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            l = l + 1;
            tbDefectCount2.Text = l.ToString();
        }

        private void Mbt4_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbOverTurned2.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbOverTurned2.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount2.Text = l.ToString();
            }
        }

        private void Pbt5_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbShort2.Text);
            i = i + 1;
            tbShort2.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            l = l + 1;
            tbDefectCount2.Text = l.ToString();
        }

        private void Mbt5_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbShort2.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbShort2.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount2.Text = l.ToString();
            }
        }

        private void Pbt6_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbEtcError2.Text);
            i = i + 1;
            tbEtcError2.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            l = l + 1;
            tbDefectCount2.Text = l.ToString();
        }

        private void Mbt6_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbEtcError2.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbEtcError2.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount2.Text = l.ToString();
            }
        }

        private void Pbt7_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbMiSap2.Text);
            i = i + 1;
            tbMiSap2.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            l = l + 1;
            tbDefectCount2.Text = l.ToString();
        }

        private void Mbt7_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbMiSap2.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbMiSap2.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount2.Text = l.ToString();
            }
        }

        private void Pbt8_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbReverse2.Text);
            i = i + 1;
            tbReverse2.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            l = l + 1;
            tbDefectCount2.Text = l.ToString();
        }

        private void Mbt8_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbReverse2.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbReverse2.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount2.Text = l.ToString();
            }
        }

        private void Pbt9_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbMiNap2.Text);
            i = i + 1;
            tbMiNap2.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            l = l + 1;
            tbDefectCount2.Text = l.ToString();
        }

        private void Mbt9_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbMiNap2.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbMiNap2.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount2.Text = l.ToString();
            }
        }

        private void Pbt10_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbSonap2.Text);
            i = i + 1;
            tbSonap2.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            l = l + 1;
            tbDefectCount2.Text = l.ToString();
        }

        private void Mbt10_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbSonap2.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbSonap2.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount2.Text = l.ToString();
            }
        }

        private void Pbt11_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbnengttem2.Text);
            i = i + 1;
            tbnengttem2.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            l = l + 1;
            tbDefectCount2.Text = l.ToString();
        }

        private void Mbt11_2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbnengttem2.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbnengttem2.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount2.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount2.Text = l.ToString();
            }
        }
        #endregion
        #region 검사내역 +-버튼3
        private void Pbt1_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbTwisted3.Text);
            i = i + 1;
            tbTwisted3.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            l = l + 1;
            tbDefectCount3.Text = l.ToString();
        }

        private void Mbt1_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbTwisted3.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbTwisted3.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount3.Text = l.ToString();
            }
        }

        private void Pbt2_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbLeadOpen3.Text);
            i = i + 1;
            tbLeadOpen3.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            l = l + 1;
            tbDefectCount3.Text = l.ToString();
        }

        private void Mbt2_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbLeadOpen3.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbLeadOpen3.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount3.Text = l.ToString();
            }
        }

        private void Pbt3_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbManhattan3.Text);
            i = i + 1;
            tbManhattan3.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            l = l + 1;
            tbDefectCount3.Text = l.ToString();
        }

        private void Mbt3_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbManhattan3.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbManhattan3.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount3.Text = l.ToString();
            }
        }

        private void Pbt4_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbOverTurned3.Text);
            i = i + 1;
            tbOverTurned3.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            l = l + 1;
            tbDefectCount3.Text = l.ToString();
        }

        private void Mbt4_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbOverTurned3.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbOverTurned3.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount3.Text = l.ToString();
            }
        }

        private void Pbt5_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbShort3.Text);
            i = i + 1;
            tbShort3.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            l = l + 1;
            tbDefectCount3.Text = l.ToString();
        }

        private void Mbt5_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbShort3.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbShort3.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount3.Text = l.ToString();
            }
        }

        private void Pbt6_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbEtcError3.Text);
            i = i + 1;
            tbEtcError3.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            l = l + 1;
            tbDefectCount3.Text = l.ToString();
        }

        private void Mbt6_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbEtcError3.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbEtcError3.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount3.Text = l.ToString();
            }
        }

        private void Pbt7_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbMiSap3.Text);
            i = i + 1;
            tbMiSap3.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            l = l + 1;
            tbDefectCount3.Text = l.ToString();
        }

        private void Mbt7_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbMiSap3.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbMiSap3.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount3.Text = l.ToString();
            }
        }

        private void Pbt8_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbReverse3.Text);
            i = i + 1;
            tbReverse3.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            l = l + 1;
            tbDefectCount3.Text = l.ToString();
        }

        private void Mbt8_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbReverse3.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbReverse3.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount3.Text = l.ToString();
            }
        }

        private void Pbt9_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbMiNap3.Text);
            i = i + 1;
            tbMiNap3.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            l = l + 1;
            tbDefectCount3.Text = l.ToString();
        }

        private void Mbt9_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbMiNap3.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbMiNap3.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount3.Text = l.ToString();
            }
        }

        private void Pbt10_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbSonap3.Text);
            i = i + 1;
            tbSonap3.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            l = l + 1;
            tbDefectCount3.Text = l.ToString();
        }

        private void Mbt10_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbSonap3.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbSonap3.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount3.Text = l.ToString();
            }
        }

        private void Pbt11_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbnengttem3.Text);
            i = i + 1;
            tbnengttem3.Text = i.ToString();

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            l = l + 1;
            tbDefectCount3.Text = l.ToString();
        }

        private void Mbt11_3_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(tbnengttem3.Text);
            if (i >= 1)
            {
                i = i - 1;
                tbnengttem3.Text = i.ToString();
            }
            else return;

            int l = 0;
            l = Convert.ToInt32(tbDefectCount3.Text);
            if (l >= 1)
            {
                l = l - 1;
                tbDefectCount3.Text = l.ToString();
            }
        }
        #endregion

        private void doc1_Click(object sender, EventArgs e)
        {
            P1C02_PROD_RESULT_AOI_DOC2 sub = new P1C02_PROD_RESULT_AOI_DOC2();
            sub.parentWin = this;
            sub.sNo = "0";
            sub.sParentCode = tbJobNo.Text;
            sub.sFileName = doc1.Tag.ToString();
            sub.ShowDialog();
        }

        private void doc2_Click(object sender, EventArgs e)
        {
            P1C02_PROD_RESULT_AOI_DOC2 sub = new P1C02_PROD_RESULT_AOI_DOC2();
            sub.parentWin = this;
            sub.sNo = "5";
            sub.sParentCode = tbJobNo.Text;
            sub.sFileName = doc2.Tag.ToString();
            sub.ShowDialog();
        }
    }
}

