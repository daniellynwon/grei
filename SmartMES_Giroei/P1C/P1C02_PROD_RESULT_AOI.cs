﻿using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using SmartFactory;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1C02_PROD_RESULT_AOI : Form
    {
        public P1C02_PROD_RESULT parentWin;
        private int rowIndex = 0;
        public string rorderID, rorderSeq;
        public string job_no;
        public string job_num;
        private bool isNew;
        private bool changedFname1 = false;
        private bool changedFname2 = false;

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

            sql = @"select co_code, co_item from BAS_common where co_kind = 'M' order by co_code";
            m = new MariaCRUD();
            msg = string.Empty;
            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbWorkLine.DataSource = table;
                cbWorkLine.ValueMember = "co_code";
                cbWorkLine.DisplayMember = "co_item";
            }

            rowIndex = parentWin.dataGridView1.CurrentCell.RowIndex;


            string sFile1 = parentWin.dataGridView1.Rows[rowIndex].Cells[47].Value.ToString();
            string sFile2 = parentWin.dataGridView1.Rows[rowIndex].Cells[48].Value.ToString();

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

            this.ActiveControl = btnSave;
        }

        private void Save()
        {
            string sql = string.Empty;

            string fname1 = string.Empty;
            string fname2 = string.Empty;
            byte[] rawdata1 = new byte[0];
            byte[] rawdata2 = new byte[0];

            //if (!string.IsNullOrEmpty(lbFname1.Text))
            //{
            //    if (changedFname1) {
            //        string[] fnames = sFname1.Split('\\');
            //        fname1 = fnames[fnames.Length - 1];
            //        FileStream fs1 = new FileStream(sFname1, FileMode.Open);
            //        BinaryReader br1 = new BinaryReader(fs1);
            //        fs1.Position = 0;
            //        UInt32 FileSize1 = (UInt32)fs1.Length;
            //        rawdata1 = br1.ReadBytes((int)fs1.Length);

            //        br1.Close();
            //    } else {
            //        fname1 = lbFname1.Text;
            //        rawdata1 = get_file_data(lbFname1.Text, job_no);
            //    }
            //}
            //if (!string.IsNullOrEmpty(lbFname2.Text))
            //{
            //    if (changedFname2) {
            //        string[] fnames = sFname2.Split('\\');
            //        fname2 = fnames[fnames.Length - 1];
            //        FileStream fs2 = new FileStream(sFname2, FileMode.Open);
            //        BinaryReader br2 = new BinaryReader(fs2);
            //        fs2.Position = 0;
            //        UInt32 FileSize2 = (UInt32)fs2.Length;
            //        rawdata2 = br2.ReadBytes((int)fs2.Length);

            //        br2.Close();
            //    } else {
            //        fname2 = lbFname2.Text;
            //        rawdata2 = get_file_data(lbFname2.Text, job_no);
            //    }
            //}

            MySqlConnection con = new MySqlConnection(G.conStr);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            con.Close();

            lblMsg.Text = "저장되었습니다.";
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

        public void userButtonA1_Click(object sender, EventArgs e)
        {

        }
        public void userButtonA2_Click(object sender, EventArgs e)
        {

        }

        private void P1C02_PROD_RESULT_AOI_Shown(object sender, EventArgs e)
        {
            string sql = @"select co_code, co_item from BAS_common where co_kind = 'M' order by co_code";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            DataTable table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbWorkLine.DataSource = table;
                cbWorkLine.ValueMember = "co_code";
                cbWorkLine.DisplayMember = "co_item";
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
            //if (!string.IsNullOrEmpty(dTFromTime.Text))
            //{
            //    lblMsg.Text = "이미 시작된 검사입니다.";
            //    return;
            //}
            //if (!string.IsNullOrEmpty(dTToTime.Text))
            //{
            //    lblMsg.Text = "이미 종료된 검사입니다.";
            //    return;
            //}

        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(dTFromTime.Text))
            //{
            //    lblMsg.Text = "검사가 시작되지 않았습니다.";
            //    return;
            //}
            //if (!string.IsNullOrEmpty(dTToTime.Text))
            //{
            //    lblMsg.Text = "이미 종료된 검사입니다.";
            //    return;
            //}

        }
        #endregion
    }
}
