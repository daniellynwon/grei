using MySql.Data.MySqlClient;
using SmartFactory;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1C01_PROD_ORDER_SUB : Form
    {
        MySqlConnection con;
        public P1C01_PROD_ORDER parentWin;
        private int rowIndex;
        private string rorderID;
        private string rorderSeq;

        private string SellectedProcess = string.Empty;
        private int[] ProcessFlag = new int[4];

        public class POrderProcess
        {
            public string order_id;
            public string order_seq;
            public string prod_id;
            public string prod_name;
            public string cust_id;
            public string cust_name;
            public string deli_date;
            public string smtYN;
            public string pcbYN;
            public string AssemYN;
            public string SusapYN;
            public string smtOX;
            public string pcbOX;
            public string AssemOX;
            public string SusapOX;
            public string qty;
            public string Solder;
            public string orderNum;
            public string jig;
        }

        public P1C01_PROD_ORDER_SUB()
        {
            InitializeComponent();
        }
        private void P1C01_PROD_ORDER_SUB_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            //tbJobNo.Text = getCode();

            ProcessFlag[0] = 0; ProcessFlag[1] = 0; ProcessFlag[2] = 0; ProcessFlag[3] = 0;

            string sql = @"select co_code, co_item from BAS_common where co_kind = 'D' order by co_code";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            DataTable table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbWorkLine.DataSource = table;
                cbWorkLine.ValueMember = "co_code";
                cbWorkLine.DisplayMember = "co_item";
            }

            sql = "select user_id, user_name from SYS_user where authority in ('A','B','C') and useYN = 'Y'";
            //sql = "select user_id, user_name from SYS_user where authority = 'A' and useYN = 'Y'";
            m = new MariaCRUD();
            msg = string.Empty;
            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbMan.DataSource = table;
                cbMan.ValueMember = "user_id";
                cbMan.DisplayMember = "user_name";
            }

            ListSearch();
            if (lblTitle.Text.Substring(lblTitle.Text.Length - 4, 4) == "[추가]")
            {
            this.ActiveControl = lblProd;
            }
            else
            {
                rowIndex = parentWin.dataGridView1.CurrentCell.RowIndex;
                label1.Visible = false; tbSearch.Visible = false;           // 그리드뷰 안보이게 (수정이니까)
                //dataGridView2.Visible = false; 
                dataGridView3.Visible = false;

                dtpDate.Value = (DateTime)parentWin.dataGridView1.Rows[rowIndex].Cells[0].Value;    // 생산계획일
                tbJobNo.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();    // JobNo
                tbCust.Tag = parentWin.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();      // 거래처코드
                tbCust.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();      // 거래처명
                tbProd.Tag = parentWin.dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();   // 품목코드
                tbProd.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();   // 품목명
                string rework = parentWin.dataGridView1.Rows[rowIndex].Cells[9].Value.ToString();   // 재작업여부
                if (rework == "재작업") rbB.Checked = true;
                tbQty.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[10].Value.ToString();      // 지시수량
                tbSolder.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[15].Value.ToString();      // 솔더
                tbMask.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[16].Value.ToString();      // 마스크
                cbMan.SelectedValue = parentWin.dataGridView1.Rows[rowIndex].Cells[21].Value;      // 책임자ID
                //tbJobTimeStart.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[25].Value.ToString();      // 작업시작
                tbJobTimeFinish.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[26].Value.ToString();      // 작업종료
                tbGdQty.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[27].Value.ToString();      // 양품수량
                tbNgQty.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[28].Value.ToString();      // 불량수량
                cbWorkLine.SelectedValue = parentWin.dataGridView1.Rows[rowIndex].Cells[29].Value;      // 생산라인
                tbRorderNo.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[13].Value.ToString();    // 수주번호
                tbRorderNo.Tag = parentWin.dataGridView1.Rows[rowIndex].Cells[14].Value.ToString();    // 수주순번
                tbContents.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[19].Value.ToString();    // 지시사항
                tbJig.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[30].Value.ToString();    // 지그

                if (string.IsNullOrEmpty(tbJobTimeStart.Text) == false)
                    btnStart.Enabled = false;
                this.ActiveControl = btnSave;
            }


            using (MySqlConnection conn = new MySqlConnection(G.conStr))
            {
                MySqlCommand cmd = new MySqlCommand();
                DataSet ds = new DataSet();
                string sFromDate = DateTime.Today.ToString("yyyy-MM-01");
                string sToDate = DateTime.Today.ToString("yyyy-MM-dd");

                string sSearch = (tbSearch.Text.Trim() == "") ? "%" : tbSearch.Text.Trim();
                try
                {
                    conn.Open();
                    cmd.Connection = conn;

                    cmd.CommandText = "SP_ProdOrder_Process";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new MySqlParameter("_fromDate", MySqlDbType.Date));
                    cmd.Parameters.Add(new MySqlParameter("_toDate", MySqlDbType.Date));
                    cmd.Parameters.Add(new MySqlParameter("_search", MySqlDbType.VarChar));
                    cmd.Parameters["_fromDate"].Value = DateTime.Parse(sFromDate);
                    cmd.Parameters["_toDate"].Value = DateTime.Parse(sToDate);
                    cmd.Parameters["_search"].Value = sSearch;

                    cmd.ExecuteNonQuery();

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    // Fill the DataSet using default values for DataTable names, etc
                    da.Fill(ds);

                    POrderProcess od = new POrderProcess();
                    int dataGridView3RowCount = 0;

                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        od.order_id = r["수주번호"].ToString();
                        od.order_seq = r["수주순번"].ToString();
                        od.prod_id = r["품목코드"].ToString();
                        od.prod_name = r["품목명"].ToString();
                        od.cust_id = r["거래처코드"].ToString();
                        od.cust_name = r["거래처명"].ToString();
                        od.deli_date = r["납기요청일"].ToString();
                        od.smtYN = r["SMT여부"].ToString();
                        od.pcbYN = r["PCB여부"].ToString();
                        od.AssemYN = r["조립여부"].ToString();
                        od.SusapYN = r["수삽여부"].ToString();
                        od.smtOX = r["SMT진행여부"].ToString();
                        od.pcbOX = r["PCB진행여부"].ToString();
                        od.AssemOX = r["조립진행여부"].ToString();
                        od.SusapOX = r["수삽진행여부"].ToString();
                        od.qty = r["수주수량"].ToString();
                        od.Solder = r["솔더"].ToString();
                        od.orderNum = r["발주번호"].ToString();
                        od.jig = r["ZIG"].ToString();

                        if (od.smtYN == "Y" && od.smtOX == "X")
                            dataGridView3.Rows.Add(od.order_id, od.order_seq, od.prod_id, od.prod_name, od.cust_id, od.cust_name, od.deli_date, "SMT", od.qty, od.Solder, od.orderNum, od.jig);
                        if (od.pcbYN == "Y" && od.pcbOX == "X")
                            dataGridView3.Rows.Add(od.order_id, od.order_seq, od.prod_id, od.prod_name, od.cust_id, od.cust_name, od.deli_date, "PCB", od.qty, od.Solder, od.orderNum, od.jig);
                        if (od.AssemYN == "Y" && od.AssemOX == "X")
                            dataGridView3.Rows.Add(od.order_id, od.order_seq, od.prod_id, od.prod_name, od.cust_id, od.cust_name, od.deli_date, "조립", od.qty, od.Solder, od.orderNum, od.jig);
                        if (od.SusapYN == "Y" && od.SusapOX == "X")
                            dataGridView3.Rows.Add(od.order_id, od.order_seq, od.prod_id, od.prod_name, od.cust_id, od.cust_name, od.deli_date, "수삽", od.qty, od.Solder, od.orderNum, od.jig);

                        dataGridView3RowCount++;
                    }
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
        public void ListSearch()
        {
            string sFromDate = DateTime.Today.ToString("yyyy-MM-01");
            string sToDate = DateTime.Today.ToString("yyyy-MM-dd");

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sSearch = tbSearch.Text.Trim();

                sP_ProdOrder_ROderTableAdapter.Fill(dataSetP1C.SP_ProdOrder_ROder, sSearch);

                var data1 = dataSetP1C.SP_ProdOrder_ROder;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data1);

                sP_ProdOrder_ProcessTableAdapter.Fill(dataSetP1C.SP_ProdOrder_Process, DateTime.Parse(sFromDate), DateTime.Parse(sToDate), sSearch);

                var data2 = dataSetP1C.SP_ProdOrder_Process;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data2);

                //dataGridView1.CurrentCell = null;
                //dataGridView1.ClearSelection();
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

        #region 품목명
        private void lblProd_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            //ProdFinder pop = new ProdFinder();
            //pop.cbGubun.Text = "<전체>";
            //pop._kind = "%";
            //pop._stockFlag = "%";
            //pop.FormSendEvent += new ProdFinder.FormSendDataHandler(ProdEventMethod);
            //pop.ShowDialog();
        }
        private void ProdEventMethod(object sender)
        {
            string sProd = sender.ToString();

            if (string.IsNullOrEmpty(sProd)) return;

            tbProd.Tag = sProd.Substring(0, sProd.IndexOf("#1/"));
            tbProd.Text = sProd.Substring(sProd.IndexOf("#1/") + 3, sProd.IndexOf("#2/") - (sProd.IndexOf("#1/") + 3));
            tbQty.Focus();
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
        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListSearch();
            }
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
        private void tbQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        #endregion

        #region gridView Events
        //private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    if (dataGridView2.RowCount < 1) return;

        //    string sSujuNo = string.Empty;
        //    string sSujuSeq = string.Empty;
        //    string sProdID = string.Empty;
        //    string sProdName = string.Empty;
        //    string sCustID = string.Empty;
        //    string sCustName = string.Empty;
        //    string sDeliDate = string.Empty;
        //    string sQty = string.Empty;

        //    string sProcess = string.Empty;

        //    int dataGridView3RowCount = 0;

        //    if (dataGridView3.Rows.Count > 0)
        //    {
        //        int RowCount = dataGridView3.Rows.Count;

        //        for (int i = 0; i < RowCount; i++)
        //        {
        //            dataGridView3.Rows.Remove(dataGridView3.Rows[0]);
        //        }
        //    }

        //    for (int i = 0; i < dataGridView2.Rows.Count; i++)
        //    {
        //        if (dataGridView2.Rows[i].Cells[7].Value.ToString() == "Y" && dataGridView2.Rows[i].Cells[11].Value.ToString() == "X") // SMT
        //        {
        //            sSujuNo = dataGridView2.Rows[i].Cells[0].Value.ToString();
        //            sSujuSeq = dataGridView2.Rows[i].Cells[1].Value.ToString();
        //            sProdID = dataGridView2.Rows[i].Cells[2].Value.ToString();
        //            sProdName = dataGridView2.Rows[i].Cells[3].Value.ToString();
        //            sCustID = dataGridView2.Rows[i].Cells[4].Value.ToString();
        //            sCustName = dataGridView2.Rows[i].Cells[5].Value.ToString();
        //            sDeliDate = Convert.ToDateTime(dataGridView2.Rows[i].Cells[6].Value.ToString()).ToString("yyyy-MM-dd");

        //            sQty = dataGridView2.Rows[i].Cells[15].Value.ToString();

        //            dataGridView3.Rows.Add(sSujuNo, sSujuSeq, sProdID, sProdName, sCustID, sCustName, sDeliDate, "SMT", sQty);
        //            dataGridView3RowCount++;
        //        }
        //        if (dataGridView2.Rows[i].Cells[8].Value.ToString() == "Y" && dataGridView2.Rows[i].Cells[12].Value.ToString() == "X") // PCB
        //        {
        //            sSujuNo = dataGridView2.Rows[i].Cells[0].Value.ToString();
        //            sSujuSeq = dataGridView2.Rows[i].Cells[1].Value.ToString();
        //            sProdID = dataGridView2.Rows[i].Cells[2].Value.ToString();
        //            sProdName = dataGridView2.Rows[i].Cells[3].Value.ToString();
        //            sCustID = dataGridView2.Rows[i].Cells[4].Value.ToString();
        //            sCustName = dataGridView2.Rows[i].Cells[5].Value.ToString();
        //            sDeliDate = Convert.ToDateTime(dataGridView2.Rows[i].Cells[6].Value.ToString()).ToString("yyyy-MM-dd");

        //            sQty = dataGridView2.Rows[i].Cells[15].Value.ToString();

        //            dataGridView3.Rows.Add(sSujuNo, sSujuSeq, sProdID, sProdName, sCustID, sCustName, sDeliDate, "PCB", sQty);
        //            dataGridView3RowCount++;
        //        }
        //        if (dataGridView2.Rows[i].Cells[9].Value.ToString() == "Y" && dataGridView2.Rows[i].Cells[13].Value.ToString() == "X") // Assem
        //        {
        //            sSujuNo = dataGridView2.Rows[i].Cells[0].Value.ToString();
        //            sSujuSeq = dataGridView2.Rows[i].Cells[1].Value.ToString();
        //            sProdID = dataGridView2.Rows[i].Cells[2].Value.ToString();
        //            sProdName = dataGridView2.Rows[i].Cells[3].Value.ToString();
        //            sCustID = dataGridView2.Rows[i].Cells[4].Value.ToString();
        //            sCustName = dataGridView2.Rows[i].Cells[5].Value.ToString();
        //            sDeliDate = Convert.ToDateTime(dataGridView2.Rows[i].Cells[6].Value.ToString()).ToString("yyyy-MM-dd");

        //            sQty = dataGridView2.Rows[i].Cells[15].Value.ToString();

        //            dataGridView3.Rows.Add(sSujuNo, sSujuSeq, sProdID, sProdName, sCustID, sCustName, sDeliDate, "조립", sQty);
        //            dataGridView3RowCount++;
        //        }
        //        if (dataGridView2.Rows[i].Cells[10].Value.ToString() == "Y" && dataGridView2.Rows[i].Cells[14].Value.ToString() == "X") // Susap
        //        {
        //            sSujuNo = dataGridView2.Rows[i].Cells[0].Value.ToString();
        //            sSujuSeq = dataGridView2.Rows[i].Cells[1].Value.ToString();
        //            sProdID = dataGridView2.Rows[i].Cells[2].Value.ToString();
        //            sProdName = dataGridView2.Rows[i].Cells[3].Value.ToString();
        //            sCustID = dataGridView2.Rows[i].Cells[4].Value.ToString();
        //            sCustName = dataGridView2.Rows[i].Cells[5].Value.ToString();
        //            sDeliDate = Convert.ToDateTime(dataGridView2.Rows[i].Cells[6].Value.ToString()).ToString("yyyy-MM-dd");

        //            sQty = dataGridView2.Rows[i].Cells[15].Value.ToString();

        //            dataGridView3.Rows.Add(sSujuNo, sSujuSeq, sProdID, sProdName, sCustID, sCustName, sDeliDate, "수삽", sQty);
        //            dataGridView3RowCount++;
        //        }
        //    }
        //}
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)    // 품목명
            {
                rorderID = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                rorderSeq = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
                tbProd.Tag = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
                tbProd.Text = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
                tbCust.Tag = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
                tbCust.Text = dataGridView3.Rows[e.RowIndex].Cells[5].Value.ToString();
                dtpDeli.Value = DateTime.Parse(dataGridView3.Rows[e.RowIndex].Cells[6].Value.ToString());
                SellectedProcess = dataGridView3.Rows[e.RowIndex].Cells[7].Value.ToString();
                tbQty.Text = dataGridView3.Rows[e.RowIndex].Cells[8].Value.ToString();
                tbSolder.Text = dataGridView3.Rows[e.RowIndex].Cells[9].Value.ToString();
                tbMask.Text = dataGridView3.Rows[e.RowIndex].Cells[10].Value.ToString();
                tbJig.Text = dataGridView3.Rows[e.RowIndex].Cells[11].Value.ToString();

                //for (int i = 0; i < dataGridView3.RowCount; i++)
                //{
                //    dataGridView3.Rows[i].Cells[4].Value = 0;
                //}
                //dataGridView3.Rows[e.RowIndex].Cells[4].Value = 1;

                if (string.IsNullOrEmpty(tbJobNo.Text))
                    tbJobNo.Text = getCode();
            }
        }
        #endregion

        #region Button Events
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

            if (tbProd.Tag == null)
            {
                lblMsg.Text = "품목명을 선택해 주세요.";
                lblProd.Focus();
                return;
            }

            string sQty = tbQty.Text.Replace(",", "").Trim();
            if (string.IsNullOrEmpty(sQty))
            {
                lblMsg.Text = "지시수량을 입력해 주세요.";
                tbQty.Focus();
                return;
            }

            string sDate = dtpDate.Value.ToString("yyyy-MM-dd");
            string sProd = tbProd.Tag.ToString();
            string sProdName = tbProd.Text;
            string sProdLine = cbWorkLine.SelectedValue.ToString();
            string sMan = cbMan.SelectedValue.ToString();
            string sJobNo = getCode();
            string sRework = "A";
            if (rbB.Checked) sRework = "B";
            string sSolder = tbSolder.Text.Trim();
            string sMask = tbMask.Text.Trim();
            //string sNum = tbJig.Text.Trim();
            //if (string.IsNullOrEmpty(tbJig.Text.Trim())) sNum = "0";
            string sNum = "0";
            string sConts = tbContents.Text.Trim();
            string sJobTimeA = ""; string sJobTimeB = "";

            //if (tbJobTimeStart.Text.Length == 19) sJobTimeA = tbJobTimeStart.Text;
            //else
            //{
            //    lblMsg.Text = "작업시작시간을 확인하세요"; return;
            //}
            //if (tbJobTimeFinish.Text.Length == 19) sJobTimeB = tbJobTimeFinish.Text;
            //else
            //{
            //    lblMsg.Text = "작업종료시간을 확인하세요"; return;
            //}

            if (string.IsNullOrEmpty(rorderSeq)) rorderSeq = "null";
            else
            {
                //string sqlQty = "select qty from vw_rorder where rorder_id = '" + rorderID + "' and rorder_seq = " + rorderSeq;
                //MariaCRUD mQty = new MariaCRUD();
                //string msgQty = string.Empty;
                //string com = mQty.dbRonlyOne(sqlQty, ref msgQty).ToString();

                //if (msgQty == "OK") sSujuQty = com;
            }
            string sql = "insert into PRD_prod_order (job_no, prod_id, prod_name, order_id, order_seq, job_type, plant, work_line, lot_date, order_qty, solder_type, mmask_id, " +
                                                "job_start_time, job_end_time, num_workers, job_comment, work_man_id, enter_man) " +
                "values('" + sJobNo + "','" + sProd + "','" + sProdName + "','" + rorderID + "'," + rorderSeq + ",'" + sRework + "','" + G.Pos + "','" + sProdLine + "','" + sDate + "'," + sQty + ",'"
                + sSolder + "','" + sMask + "',now(),now()," + sNum + ",'" + sConts + "','" + sMan + "','" + G.UserID + "')";

            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                MessageBox.Show("작업지시에 문제가 있습니다.");
                return;
            }

            var data = sql;
            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);

            //for (int i = 0; i < dataGridView2.Rows.Count; i++)
            //{
            //    if (dataGridView2.Rows[i].Cells[0].Value.ToString() == rorderID
            //        && dataGridView2.Rows[i].Cells[1].Value.ToString() == rorderSeq)
            //    {
            //        if (SellectedProcess == "SMT")
            //            dataGridView2.Rows[i].Cells[11].Value = Convert.ToByte(dataGridView2.Rows[i].Cells[11].Value.ToString()) & 0b0111;
            //        if (SellectedProcess == "PCB")
            //            dataGridView2.Rows[i].Cells[11].Value = Convert.ToByte(dataGridView2.Rows[i].Cells[11].Value.ToString()) & 0b1011;
            //        if (SellectedProcess == "조립")
            //            dataGridView2.Rows[i].Cells[11].Value = Convert.ToByte(dataGridView2.Rows[i].Cells[11].Value.ToString()) & 0b1101;
            //        if (SellectedProcess == "수삽")
            //            dataGridView2.Rows[i].Cells[11].Value = Convert.ToByte(dataGridView2.Rows[i].Cells[11].Value.ToString()) & 0b1110;
            //    }
            //}
            if (SellectedProcess == "SMT")
            {
                sql = $@"UPDATE SAL_order_sub SET SMTProcessOX = 'O' WHERE order_id = '{@rorderID}' AND order_seq = {@rorderSeq}";
                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }

                data = sql;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);
            }
            if (SellectedProcess == "PCB")
            {
                sql = $@"UPDATE SAL_order_sub SET PCBProcessOX = 'O' WHERE order_id = '{@rorderID}' AND order_seq = {@rorderSeq}";
                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }

                data = sql;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);
            }
            if (SellectedProcess == "조립")
            {
                sql = $@"UPDATE SAL_order_sub SET AssembleProcessOX = 'O' WHERE order_id = '{@rorderID}' AND order_seq = {@rorderSeq}";
                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }

                data = sql;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);
            }
            if (SellectedProcess == "수삽")
            {
                sql = $@"UPDATE SAL_order_sub SET SusapProcessOX = 'O' WHERE order_id = '{@rorderID}' AND order_seq = {@rorderSeq}";
                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }

                data = sql;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);
            }

            sql = $@"SELECT SMTProcessYN, SMTProcessOX, PCBProcessYN, PCBProcessOX, AssembleProcessYN, AssembleProcessOX, SusapProcessYN, SusapProcessOX
                    FROM SAL_order_sub WHERE order_id = '{@rorderID}' AND order_seq = {@rorderSeq}";

            DataTable table = m.dbDataTable(sql, ref msg);

            if (table.Rows[0][0].ToString() == "N") ProcessFlag[0] = 1;
            else if (table.Rows[0][0].ToString() == "Y") ProcessFlag[0] = table.Rows[0][1].ToString() == "O" ? 1 : 0;

            if (table.Rows[0][2].ToString() == "N") ProcessFlag[1] = 1;
            else if (table.Rows[0][2].ToString() == "Y") ProcessFlag[1] = table.Rows[0][3].ToString() == "O" ? 1 : 0;

            if (table.Rows[0][4].ToString() == "N") ProcessFlag[2] = 1;
            else if (table.Rows[0][4].ToString() == "Y") ProcessFlag[2] = table.Rows[0][5].ToString() == "O" ? 1 : 0;

            if (table.Rows[0][6].ToString() == "N") ProcessFlag[3] = 1;
            else if (table.Rows[0][6].ToString() == "Y") ProcessFlag[3] = table.Rows[0][7].ToString() == "O" ? 1 : 0;

            if (ProcessFlag[0] * ProcessFlag[1] * ProcessFlag[2] * ProcessFlag[3] > 0)
            {
                sql = $@"UPDATE SAL_order_sub SET prod_status = 3 WHERE order_id = '{@rorderID}' AND order_seq = {@rorderSeq}";
                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }

                data = sql;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);
            }

            // 생산실적등록 update if 작업시작이 not null이면
            //sql = "insert into PRD_prod_result (job_no, plant, work_line, prod_date, good_qty, bad_qty, job_start_time, job_part, num_workers, contents, enter_man) " +
            //        "values('" + tbJobNo.Text + "','" + G.Pos + "','" + sProdLine + "','" + sDate + "'," + sGdQty + "," + sNgQty + ",now(),'A'," + sUserCnt + ",'" + sContents + "','" + G.UserID + "') " +
            //        "on duplicate key update " +
            //        " plant = '" + G.Pos + "', work_line = '" + sProdLine + "', prod_date = '" + sDate + ", good_qty = " + sGdQty + ", bad_qty = " + sNgQty + ", job_start_time  = '" + sJobTimeA + "', "
            //        ;

            //QRCodeCreate(rorderID, rorderSeq);
            //QRImageSave(rorderID + rorderSeq);

            lblMsg.Text = "저장되었습니다.";

            parentWin.ListSearch();

            ListSearch();

            for (int i = 0; i < parentWin.dataGridView1.Rows.Count; i++)
            {
                if (parentWin.dataGridView1.Rows[i].Cells[1].Value.ToString() == sJobNo)
                {
                    parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[0, i];
                    parentWin.dataGridView1.CurrentCell.Selected = true;
                    break;
                }
            }

            //tbJobNo.Text = getCode();
            //tbJobTimeStart.Text = DateTime.Today.ToString("yyyy-MM-dd") + " 09:00:00";
            //tbJobTimeFinish.Text = DateTime.Today.ToString("yyyy-MM-dd") + " 18:00:00";
            //tbProd.Tag = null;
            //tbProd.Text = string.Empty;
            //tbCust.Text = string.Empty;
            //tbSolder.Text = string.Empty;
            //tbMask.Text = string.Empty;
            //tbNum.Text = string.Empty;
            //tbQty.Text = string.Empty;
            //tbContents.Text = string.Empty;
            //tbQty.Text = string.Empty;
            //cbWorkLine.SelectedIndex = 0;
            //cbMan.SelectedIndex = 0;
        }
        #endregion

        #region JobNo.(LotNo.) 생성
        private string getCode()
        {
            string sql = @"select UF_JobNoGenerator()";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
        #endregion

        #region 작업지시일괄등록
        private void btnComment_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if(tbRorderNo.Text == "" || string.IsNullOrEmpty(tbRorderNo.Text))
            {
                lblMsg.Text = "선택된 수주(작업)이 없습니다.";
                return;
            }

            rorderID = tbRorderNo.Text.Trim();
            rorderSeq = tbRorderNo.Tag.ToString();
            string sBigo = "";

            P1C01_PROD_ORDER_SUB2 sub = new P1C01_PROD_ORDER_SUB2(rorderID, rorderSeq, sBigo);
            sub.parentWin = this;
            sub.ShowDialog();
        }
        #endregion

        #region QR
        private void QRCodeCreate(string s1, string s2) // s1 수주번호, s2 수주순번
        {
            ZXing.BarcodeWriter barcodeWriter = new ZXing.BarcodeWriter();
            barcodeWriter.Format = ZXing.BarcodeFormat.QR_CODE;

            barcodeWriter.Options.Width = 128;
            barcodeWriter.Options.Height = 128;

            string str = s1 + s2;

            barcodeWriter.Write(str).Save(s1 + s2 + ".png", ImageFormat.Png);
        }
        private void QRImageSave(string _id)
        {
            string sql = string.Empty;
            UInt32 FileSize;
            byte[] rawData;
            FileStream fs;

            con = new MySqlConnection(G.conStr);
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                fs = new FileStream(_id + ".png", FileMode.Open, FileAccess.Read);
                FileSize = (UInt32)fs.Length;

                rawData = new byte[FileSize];
                fs.Read(rawData, 0, (int)FileSize);
                fs.Close();

                string sRorder = _id.Substring(0, 10);
                string sSeq = _id.Substring(10,Int32.Parse((_id.Length-10).ToString()));    // ERP 연동으로 인한 수주순번 자릿수 변경으로 로직 변경. 6/23

                con.Open();
                sql = "update tb_prod_order set qrcode = @QRCODE where rorder_id = @CODE_NOA and rorder_seq = @CODE_NOB";

                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@CODE_NOA", sRorder);
                cmd.Parameters.AddWithValue("@CODE_NOB", sSeq);
                cmd.Parameters.AddWithValue("@QRCODE", rawData);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region 작업시작/작업종료/update기능 (작업실적등록 update할 때)
        private void btnOrder_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (string.IsNullOrEmpty(tbJobNo.Text)) // tbJobNo.Text
            {
                lblMsg.Text = "해당 Lot를 추가해 주세요.";
                return;
            }
            if (string.IsNullOrEmpty(tbJobTimeStart.Text))
                Save();
            if (!string.IsNullOrEmpty(tbJobTimeStart.Text))
            {
                lblMsg.Text = "이미 지시된 Lot입니다. 다시 확인해주세요.";
                return;
                DialogResult dr = MessageBox.Show("이미 지시된 Lot입니다.\r" + "해당 정보를 수정하시겠습니까?", this.lblTitle.Text + "[수정]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                    return;
                else
                    Update();
                return;
            }
            if (!string.IsNullOrEmpty(tbJobTimeFinish.Text))
            {
                //lblMsg.Text = "이미 종료된 Lot입니다.";
                //return;
                DialogResult dr = MessageBox.Show("이미 종료된 Lot입니다.\r" + "해당 정보를 수정하시겠습니까?", this.lblTitle.Text + "[수정]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                    return;
                else
                    Update();
                return;
            }

            string sDate = dtpDate.Value.ToString("yyyy-MM-dd");
            string sProd = tbProd.Tag.ToString();
            //string sProdName = tbProd.Text;
            string sProdLine = cbWorkLine.SelectedValue.ToString();
            string sMan = cbMan.SelectedValue.ToString();
            string sJobNo = tbJobNo.Text;
            string sRework = "A";
            if (rbB.Checked)sRework = "B";
            string sSolder = tbSolder.Text.Trim();
            string sMask = tbMask.Text.Trim();
            //string sUserCnt = tbJig.Text.Trim();
            //if (string.IsNullOrEmpty(tbJig.Text.Trim()))
            string sUserCnt = "0";
            string sContents = tbContents.Text.Trim();
            string sJobTimeA = "";
            string sJobTimeB = "";
            string sGdQty = tbGdQty.Text.Replace(",", "").Trim();
            string sNgQty = tbNgQty.Text.Replace(",", "").Trim();
            if (string.IsNullOrEmpty(sGdQty))
                sGdQty = "0";
            if (string.IsNullOrEmpty(sNgQty))
                sNgQty = "0";

            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();
            string sql = string.Empty;

            sql = "insert into PRD_prod_result (job_no, plant, work_line, prod_date, good_qty, bad_qty, job_part, num_workers, contents, enter_man) " +
                    "values('" + tbJobNo.Text + "','" + G.Pos + "','" + sProdLine + "','" + sDate + "'," + sGdQty + "," + sNgQty + ",'A'," + sUserCnt + ",'" + sContents + "','" + G.UserID + "') ";
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = "작업시작에 문제가 있습니다.";
                //MessageBox.Show(msg);
                return;
            }
            parentWin.ListSearch();         // reflash
            this.Close();
            parentWin.ListSearch();
            parentWin.lblMsg.Text = "작업지시가 되었습니다.";
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (string.IsNullOrEmpty(tbJobNo.Text)) // tbJobNo.Text
            {
                lblMsg.Text = "해당 Lot를 추가해 주세요.";
                return;
            }
            if (string.IsNullOrEmpty(tbJobTimeStart.Text))
                Update();
            if (!string.IsNullOrEmpty(tbJobTimeStart.Text))
            {
                lblMsg.Text = "이미 시작된 Lot입니다.";
                return;
                DialogResult dr = MessageBox.Show("이미 시작된 Lot입니다.\r" + "해당 정보를 수정하시겠습니까?", this.lblTitle.Text + "[수정]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No) return;
                else Update();
                return;
            }
            if (!string.IsNullOrEmpty(tbJobTimeFinish.Text))
            {
                //lblMsg.Text = "이미 종료된 Lot입니다.";
                //return;
                DialogResult dr = MessageBox.Show("이미 종료된 Lot입니다.\r" + "해당 정보를 수정하시겠습니까?", this.lblTitle.Text + "[수정]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No) return;
                else Update();
                return;
            }

            string sDate = dtpDate.Value.ToString("yyyy-MM-dd");
            string sProd = tbProd.Tag.ToString();
            //string sProdName = tbProd.Text;
            string sProdLine = cbWorkLine.SelectedValue.ToString();
            string sMan = cbMan.SelectedValue.ToString();
            string sJobNo = tbJobNo.Text;
            string sRework = "A";
            if (rbB.Checked) sRework = "B";
            string sSolder = tbSolder.Text.Trim();
            string sMask = tbMask.Text.Trim();
            string sUserCnt = tbJig.Text.Trim();
            if (string.IsNullOrEmpty(tbJig.Text.Trim())) sUserCnt = "0";
            string sContents = tbContents.Text.Trim();
            string sJobTimeA = ""; string sJobTimeB = "";
            string sGdQty = tbGdQty.Text.Replace(",", "").Trim(); string sNgQty = tbNgQty.Text.Replace(",", "").Trim();
            if (string.IsNullOrEmpty(sGdQty)) sGdQty = "0"; if (string.IsNullOrEmpty(sNgQty)) sNgQty = "0";

            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();
            string sql = string.Empty;

            //sql = "insert into PRD_prod_result (job_start_time) " +
            //        "values(' + now()  + ') ";
            //m.dbCUD(sql, ref msg); //삭제예정

            sql = "UPDATE PRD_prod_result set job_start_time = NOW() where job_no = '" + tbJobNo.Text + "'";   // 지시수량 update
            m.dbCUD(sql, ref msg);

            //sql = "update PRD_prod_result set  = job_start_time = 'GETDATE()' where job_start_time IS NULL";  // 지시수량 update
            //sql = "UPDATE PRD_prod_result set job_start_time = NOW() where job_start_time IS NULL";
            //m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = "작업시작에 문제가 있습니다.";
                MessageBox.Show(msg);
                return;
            }
            parentWin.ListSearch();         // reflash
            this.Close();
            parentWin.ListSearch();
            parentWin.lblMsg.Text = "작업시작 되었습니다.";
        }
        //private void btnStart_Click(object sender, EventArgs e)
        //{
        //    lblMsg.Text = "";
        //    if (string.IsNullOrEmpty(tbJobNo.Text)) // tbJobNo.Text
        //    {
        //        lblMsg.Text = "해당 Lot를 추가해 주세요.";
        //        return;
        //    }
        //    if (string.IsNullOrEmpty(tbJobTimeStart.Text))
        //        Save();
        //    if (!string.IsNullOrEmpty(tbJobTimeStart.Text))
        //    {
        //        //lblMsg.Text = "이미 시작된 Lot입니다.";
        //        //return;
        //        DialogResult dr = MessageBox.Show("이미 시작된 Lot입니다.\r" + "해당 정보를 수정하시겠습니까?", this.lblTitle.Text + "[수정]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //        if (dr == DialogResult.No)
        //            return;
        //        else
        //            Update();
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(tbJobTimeFinish.Text))
        //    {
        //        //lblMsg.Text = "이미 종료된 Lot입니다.";
        //        //return;
        //        DialogResult dr = MessageBox.Show("이미 종료된 Lot입니다.\r" + "해당 정보를 수정하시겠습니까?", this.lblTitle.Text + "[수정]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //        if (dr == DialogResult.No)
        //            return;
        //        else
        //            Update();
        //        return;
        //    }

        //    string sDate = dtpDate.Value.ToString("yyyy-MM-dd");
        //    string sProd = tbProd.Tag.ToString();
        //    //string sProdName = tbProd.Text;
        //    string sProdLine = cbWorkLine.SelectedValue.ToString();
        //    string sMan = cbMan.SelectedValue.ToString();
        //    string sJobNo = tbJobNo.Text;
        //    string sRework = "A";
        //    if (rbB.Checked)
        //        sRework = "B";
        //    string sSolder = tbSolder.Text.Trim();
        //    string sMask = tbMask.Text.Trim();
        //    string sUserCnt = tbNum.Text.Trim();
        //    if (string.IsNullOrEmpty(tbNum.Text.Trim()))
        //        sUserCnt = "0";
        //    string sContents = tbContents.Text.Trim();
        //    string sJobTimeA = "";
        //    string sJobTimeB = "";
        //    string sGdQty = tbGdQty.Text.Replace(",", "").Trim();
        //    string sNgQty = tbNgQty.Text.Replace(",", "").Trim();
        //    if (string.IsNullOrEmpty(sGdQty))
        //        sGdQty = "0";
        //    if (string.IsNullOrEmpty(sNgQty))
        //        sNgQty = "0";

        //    string msg = string.Empty;
        //    MariaCRUD m = new MariaCRUD();
        //    string sql = string.Empty;

        //    sql = "insert into PRD_prod_result (job_no, plant, work_line, prod_date, good_qty, bad_qty, job_start_time, job_part, num_workers, contents, enter_man) " +
        //            "values('" + tbJobNo.Text + "','" + G.Pos + "','" + sProdLine + "','" + sDate + "'," + sGdQty + "," + sNgQty + ",now(),'A'," + sUserCnt + ",'" + sContents + "','" + G.UserID + "') ";

        //    m.dbCUD(sql, ref msg);

        //    if (msg != "OK")
        //    {
        //        lblMsg.Text = "작업시작에 문제가 있습니다.";
        //        //MessageBox.Show(msg);
        //        return;
        //    }
        //    parentWin.ListSearch();         // reflash
        //    this.Close();
        //    parentWin.ListSearch();
        //    parentWin.lblMsg.Text = "작업시작되었습니다.";
        //}
        private void btnFinish_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            if (string.IsNullOrEmpty(tbJobNo.Text)) // tbJobNo.Text
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
                //lblMsg.Text = "이미 종료된 Lot입니다. 보고사항을 이용해주세요.";
                //return;
                DialogResult dr = MessageBox.Show("이미 종료된 Lot입니다.\r" + "우측하단 보고사항을 이용해주세요.", this.lblTitle.Text + "[수정]", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //if (dr == DialogResult.No) return;
                //else Update();
                return;
            }
            if (string.IsNullOrEmpty(tbGdQty.Text) || tbGdQty.Text == "0")
            {
                lblMsg.Text = "양품수량이 입력되지 않았습니다.";
                return;
            }

            string sDate = dtpDate.Value.ToString("yyyy-MM-dd");
            //string sUserCnt = tbJig.Text;
            //if (string.IsNullOrEmpty(sUserCnt)) sUserCnt = "0";
            string sUserCnt = "0";
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();
            string sql = string.Empty;

            string sWork = cbWorkLine.SelectedValue.ToString();
            string sQty = tbQty.Text.Replace(",", "").Trim();
            string sGdQty = tbGdQty.Text.Replace(",", "").Trim(); string sNgQty = tbNgQty.Text.Replace(",", "").Trim();
            if (string.IsNullOrEmpty(sGdQty)) sGdQty = "0"; if (string.IsNullOrEmpty(sNgQty)) sNgQty = "0";

            sql = "update PRD_prod_order set order_qty = " + sQty + " where job_no = '" + tbJobNo.Text + "'";   // 지시수량 update
            m.dbCUD(sql, ref msg);

            sql = "update PRD_prod_result set work_line = '" + sWork + "', good_qty = " + sGdQty + ", bad_qty = " + sNgQty + ", job_end_time = now(), num_workers = " + sUserCnt + ", contents = '" + tbContents.Text.Trim() + "', jobendYN = 'Y'" +
                    " where job_no = '" + tbJobNo.Text + "'";
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            sql = "update PRD_prod_order set prodYN = 'Y' where job_no = '" + tbJobNo.Text + "'";   // tbJobNo.Text
            m.dbCUD(sql, ref msg);

            sql = "update SAL_order_sub set prod_status = 4 where order_id = '" + tbRorderNo.Text + "' and order_seq = " + tbRorderNo.Tag.ToString();   // SAL_order_sub prod_status 4로 변경
            m.dbCUD(sql, ref msg);
            parentWin.ListSearch();
            lblMsg.Text = "작업종료되었습니다.";
            this.Close();
        }
        private void Update()
        {
            string sDate = dtpDate.Value.ToString("yyyy-MM-dd");
            string sProd = tbProd.Tag.ToString();
            string sProdLine = cbWorkLine.SelectedValue.ToString();
            string sMan = cbMan.SelectedValue.ToString();
            string sJobNo = tbJobNo.Text;
            string sRework = "A";
            if (rbB.Checked) sRework = "B";
            string sSolder = tbSolder.Text.Trim();
            string sMask = tbMask.Text.Trim();
            //string sUserCnt = tbJig.Text.Trim();
            //if (string.IsNullOrEmpty(tbJig.Text.Trim())) sUserCnt = "0";
            string sUserCnt = "0";
            string sContents = tbContents.Text.Trim();
            string sJobTimeA = ""; string sJobTimeB = "";
            string sQty = tbQty.Text.Replace(",", "").Trim();
            string sGdQty = tbGdQty.Text.Replace(",", "").Trim(); string sNgQty = tbNgQty.Text.Replace(",", "").Trim();
            if (string.IsNullOrEmpty(sGdQty)) sGdQty = "0"; if (string.IsNullOrEmpty(sNgQty)) sNgQty = "0";
            if (string.IsNullOrEmpty(rorderSeq)) rorderSeq = "null";


            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();
            string sql = string.Empty;

            sql = "update PRD_prod_order set order_qty = " + sQty + " where job_no = '" + tbJobNo.Text + "'";   // 지시수량 update
            m.dbCUD(sql, ref msg);

            // update로 변경..
            sql = "update PRD_prod_result set work_line = '" + sProdLine + "', prod_date = '" + sDate + "', good_qty = " + sGdQty + ", bad_qty = " + sNgQty + ", job_part = 'A', num_workers = " + sUserCnt + ", contents = '" + sContents + "', enter_man = '" + G.UserID + "'" +
                " where job_no = '" + sJobNo + "'";

            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = "작업시작에 문제가 있습니다.";
                MessageBox.Show(msg);
                return;
            }
            lblMsg.Text = "수정되었습니다.";
            this.Close();
        }
        #endregion
    }
}