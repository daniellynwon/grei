﻿using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using SmartFactory;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1D01_MACHINECARD : SmartMES_Giroei.FormBasic
    {
        public P1D01_MACHINECARD()
        {
            InitializeComponent();
        }
        private void P1D01_MACHINECARD_Load(object sender, EventArgs e)
        {
            txtPath.Text = string.Empty;
            ListSearch();
            this.ActiveControl = tbHo;

            string sql = @"SELECT co_code, co_item FROM BAS_common WHERE co_kind = 'Z' order by co_code";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            DataTable table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbGroup.DataSource = table;
                cbGroup.ValueMember = "co_code";
                cbGroup.DisplayMember = "co_item";
            }

            sql = @"( SELECT '' AS co_code, '<설비그룹>' AS co_item ) UNION ( SELECT co_code, co_item FROM BAS_common WHERE co_kind = 'Z' ORDER BY co_code )";
            m = new MariaCRUD();
            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbGroupSearch.DataSource = table;
                cbGroupSearch.ValueMember = "co_code";
                cbGroupSearch.DisplayMember = "co_item";
            }

            sql = @"SELECT user_name FROM SYS_user WHERE authority <> 'A' AND user_flag = 1 ORDER BY user_name";
            m = new MariaCRUD();
            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                foreach (DataRow row in table.Rows)
                {
                    cbCharge.Items.Add(row[0].ToString());
                }
            }
        }

        public void ListSearch()
        {
            lblMsg.Text = "";

            string sSearch = cbGroupSearch.Text == "<설비그룹>" ? ("" + tbNameSearch.Text) : (cbGroupSearch.Text + " " + tbNameSearch.Text);
            //Debug.Print("sSearch : " + sSearch);
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //sP_MachineCard_QueryTableAdapter.Fill(dataSetP1D.SP_MachineCard_Query, G.Pos, "");
                sP_MachineCard_QueryTableAdapter.Fill(dataSetP1D.SP_MachineCard_Query, G.Pos, sSearch);

                var data = dataSetP1D.SP_MachineCard_Query;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

                dataGridView1.CurrentCell = null;
                dataGridView1.ClearSelection();
            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        public void MachineInit()
        {
            lblMsg.Text = "";

            lblID.Text = "관리No. 0";
            pbFacilityImage.Image = null;
            txtPath.Text = string.Empty;
            tbHo.Text = string.Empty;
            tbName.Text = string.Empty;
            tbMadeCom.Text = string.Empty;
            tbMadeDate.Text = string.Empty;
            tbBuyCom.Text = string.Empty;
            tbBuyDate.Text = string.Empty;
            tbMoney.Text = string.Empty;
            tbLocation.Text = string.Empty;
            cbCharge.Text = string.Empty;
            tbAsCom.Text = string.Empty;
            tbSpec.Text = string.Empty;
            tbIP.Text = string.Empty;

            tbHo.Focus();
        }

        #region 동일데이터 확인
        private bool isExist(string _pos, string _ho, string _name, string _group)
        {
            string sql = @"SELECT equipment_id FROM BAS_equipment WHERE plant = '" + _pos + "' AND machine_no = '" + _ho + "' AND machine_name = '" + _name + "' AND model_no = '" + _group + "'";

            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            object id = m.dbRonlyOne(sql, ref msg);

            if (msg == "OK" && id != null)
                return true;
            else
                return false;
        }
        #endregion

        #region GridView Events
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int rowIndex = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible);
            if (rowIndex <= 0) return;

            dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(93, 123, 157);
            dataGridView1.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(93, 123, 157);
            dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.White;

            dataGridView1[4, rowIndex].Value = rowIndex.ToString() + "기";
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblMsg.Text = "";

            if (e.RowIndex < 0) return;
            if (dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible) == e.RowIndex) return;

            try
            {
                int index = dataGridView1.CurrentRow.Index;

                string fid = dataGridView1.Rows[index].Cells[0].Value.ToString();
                lblID.Text = "관리No. " + fid;
                txtPath.Text = "";

                tbHo.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                tbName.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
                //tbModel.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                cbGroup.SelectedValue = dataGridView1.Rows[index].Cells[1].Value.ToString();
                tbMadeCom.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
                tbMadeDate.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
                tbBuyCom.Text = dataGridView1.Rows[index].Cells[7].Value.ToString();
                tbBuyDate.Text = dataGridView1.Rows[index].Cells[8].Value.ToString();
                tbMoney.Text = dataGridView1.Rows[index].Cells[9].Value.ToString();
                tbLocation.Text = dataGridView1.Rows[index].Cells[10].Value.ToString();
                cbCharge.Text = dataGridView1.Rows[index].Cells[11].Value.ToString();
                tbAsCom.Text = dataGridView1.Rows[index].Cells[12].Value.ToString();
                tbSpec.Text = dataGridView1.Rows[index].Cells[13].Value.ToString();
                tbIP.Text = dataGridView1.Rows[index].Cells[18].Value.ToString();

                lblID.Visible = true;

                FacilityImageLoad(fid);
            }
            catch (NullReferenceException)
            {
                return;
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

        #region 설비이미지...
        private void btnImageLoad_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (G.Authority == "D") return;

            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "JPEG 파일(*.jpg)|*.jpg|PNG 파일(*.png)|*.png";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.txtPath.Text = openFileDialog1.FileName;
                    pbFacilityImage.Image = Image.FromFile(openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }
        private void btnImageDelete_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (G.Authority == "D") return;

            txtPath.Text = "";
            pbFacilityImage.Image = null;
        }
        private void FacilityImageSave(string _fid)
        {
            MariaCRUD m = new MariaCRUD();
            string sql1 = string.Empty;
            string sql2 = string.Empty;
            string msg = string.Empty;

            if (!string.IsNullOrEmpty(txtPath.Text) && pbFacilityImage.Image != null)
            {
                UInt32 FileSize;
                byte[] rawData;
                FileStream fs;

                MySqlConnection con = new MySqlConnection(G.conStr);
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    fs = new FileStream(@txtPath.Text, FileMode.Open, FileAccess.Read);
                    FileSize = (UInt32)fs.Length;

                    rawData = new byte[FileSize];
                    fs.Read(rawData, 0, (int)FileSize);
                    fs.Close();

                    con.Open();
                    sql1 = "UPDATE BAS_equipment SET machine_image = @File, image_size = @FileSize WHERE equipment_id = '" + _fid + "'";
                    //sql2 = "UPDATE FMM_facility_info SET machine_image = @File, DOC_SIZE = @FileSize WHERE machine_no = '" + _fid + "'";

                    cmd.Connection = con;
                    cmd.CommandText = sql1;
                    cmd.Parameters.AddWithValue("@File", rawData);
                    cmd.Parameters.AddWithValue("@FileSize", FileSize);
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
            else if (string.IsNullOrEmpty(txtPath.Text) && pbFacilityImage.Image == null)
            {
                sql1 = "UPDATE BAS_equipment SET machine_image = NULL, image_size = 0 WHERE equipment_id = '" + _fid + "'";

                m.dbCUD(sql1, ref msg);

                if (msg != "OK")
                {
                    MessageBox.Show(msg);
                    return;
                }
            }
        }
        private void FacilityImageLoad(string _fid)
        {
            pbFacilityImage.Image = null;

            string FileName;
            UInt32 FileSize;
            byte[] rawData;
            FileStream fs;

            MySqlConnection con = new MySqlConnection(G.conStr);
            MySqlCommand cmd = new MySqlCommand();

            string sql = "SELECT machine_image, image_size FROM BAS_equipment WHERE equipment_id = '" + _fid + "'";

            try
            {
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = sql;

                MySqlDataReader myData = cmd.ExecuteReader();

                if (!myData.HasRows)
                {
                    myData.Close();
                    return;
                }

                myData.Read();

                FileSize = myData.GetUInt32(myData.GetOrdinal("image_size"));

                if (FileSize <= 0)
                {
                    myData.Close();
                    return;
                }

                rawData = new byte[FileSize];

                myData.GetBytes(myData.GetOrdinal("machine_image"), 0, rawData, 0, (int)FileSize);

                FileName = @System.IO.Directory.GetCurrentDirectory();
                FileName = FileName + "\\" + _fid.ToString() + ".png";

                GC.Collect();
                GC.WaitForPendingFinalizers();
                FileInfo file = new FileInfo(FileName);
                file.Delete();

                fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
                fs.Write(rawData, 0, (int)FileSize);
                fs.Close();

                pbFacilityImage.Image = Image.FromFile(FileName);

                myData.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Button Events
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch();
            MachineInit();
        }
        private void pbAdd_Click(object sender, EventArgs e)
        {
            lblID.Visible = false;

            ListSearch();
            MachineInit();
            this.ActiveControl = tbHo;
        }
        private void pbDel_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            int index = 0;
            string sID = string.Empty;
            string sName = string.Empty;
            string sModel = string.Empty;

            try
            {
                index = dataGridView1.CurrentRow.Index;
                sID = dataGridView1.Rows[index].Cells[0].Value.ToString();
                sName = dataGridView1.Rows[index].Cells[2].Value.ToString();
                sModel = dataGridView1.Rows[index].Cells[3].Value.ToString();

                if (dataGridView1.Rows[index].Selected != true)
                {
                    MessageBox.Show("삭제 정보가 선택되지 않았습니다.", this.lblTitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("삭제 정보가 선택되지 않았습니다.", this.lblTitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DialogResult dr = MessageBox.Show(sName + "\r" + sModel + "\r\r해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.No) return;

            MariaCRUD m = new MariaCRUD();
            string sql = "DELETE FROM BAS_equipment WHERE equipment_id = '" + sID + "'";
            string msg = string.Empty;
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                MessageBox.Show(msg);
                return;
            }

            m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sName + " " + sModel);

            var data = sql;
            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.삭제, data);

            ListSearch();
            MachineInit();
        }
        private void pbSave_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            string sHo = tbHo.Text.Trim();
            string sName = tbName.Text.Trim();


            if (String.IsNullOrEmpty(sHo))
            {
                lblMsg.Text = "호기를 입력해 주세요.";
                tbHo.Focus();
                return;
            }
            if (String.IsNullOrEmpty(sName))
            {
                lblMsg.Text = "설비명을 입력해 주세요.";
                tbName.Focus();
                return;
            }

            string sID = lblID.Text.Substring(6, lblID.Text.Length - 6);
            string sModel = cbGroup.SelectedValue.ToString();
            string sMadeCom = tbMadeCom.Text.Trim();
            string sMadeDate = tbMadeDate.Text.Trim();
            string sBuyCom = tbBuyCom.Text.Trim();
            string sBuyDate = tbBuyDate.Text.Trim();
            string sMoney = tbMoney.Text.Replace(",", "").Trim();
            if (string.IsNullOrEmpty(sMoney)) sMoney = "NULL";
            string sLocation = tbLocation.Text.Trim();
            string sCharge = cbCharge.Text.Trim();
            string sAsCom = tbAsCom.Text.Trim();
            string sSpec = tbSpec.Text.Trim();
            string sIP = tbIP.Text.Trim();

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            if (sID == "0") //추가
            {
                if (isExist(G.Pos, sHo, sName, sModel))
                {
                    lblMsg.Text = "이미 존재하는 설비정보입니다.";
                    lblID.Focus();
                    return;
                }

                sID = getEquipmentID("E");

                sql = "INSERT INTO BAS_equipment " +
                    "(equipment_id, plant, model_no, machine_name, machine_no, made_com, made_date, buy_com, buy_date, buy_money, location, charge, as_com, machine_spec, ip, enter_man) " +
                    "VALUES('" + sID + "','" + G.Pos + "','" + sModel + "','" + sName + "','" + sHo + "','" + sMadeCom + "','" + sMadeDate + "','" + sBuyCom + "','" + sBuyDate + "'," + sMoney + ",'" + sLocation + "','" + sCharge + "','" + sAsCom + "','" + sSpec + "','" + sIP + "','" + G.UserID + "')";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    MessageBox.Show(msg);
                    return;
                }

                var data = sql;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);

                //sql = "INSERT INTO FMM_facility_info " +
                //    "(plant, machine_group, machine_no, machine_name, made_company, made_date, supplier, buy_date, buy_money, manager, as_company, machine_spec, DOC_SIZE, DOC_ORIGINNAME, DOC_NAME, DOC_FILEPATH, machine_ip, enter_man) " +
                //    "VALUES('" + G.Pos + "','" + sModel + "','" + sID + "','" + sName + "','" + sMadeCom + "','" + sMadeDate + "','" + sBuyCom + "','" + sBuyDate + "'," + sMoney + ",'" + sCharge + "','" + sAsCom + "','" + sSpec + "','" + 0 + "', '', '', '', '" + sIP + "','" + G.UserID + "')";

                //m.dbCUD(sql, ref msg);

                //if (msg != "OK")
                //{
                //    MessageBox.Show(msg);
                //    return;
                //}

                ListSearch();
                lblMsg.Text = "저장되었습니다.";

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[2].Value.ToString() == sHo &&
                        dataGridView1.Rows[i].Cells[3].Value.ToString() == sModel &&
                        dataGridView1.Rows[i].Cells[4].Value.ToString() == sName)
                    {
                        dataGridView1.CurrentCell = dataGridView1[1, i];
                        dataGridView1.CurrentCell.Selected = true;
                        sID = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        lblID.Text = "관리No. " + sID;
                        break;
                    }
                }
            }
            else //수정
            {
                sql = "UPDATE BAS_equipment " +
                    "SET model_no = '" + sModel + "', machine_name = '" + sName + "', machine_no = '" + sHo + "', made_com = '" + sMadeCom + "', made_date = '" + sMadeDate + "', buy_com = '" + sBuyCom + "', buy_date = '" + sBuyDate + "', buy_money = " + sMoney + ", location = '" + sLocation + "', charge = '" + sCharge + "', as_com = '" + sAsCom + "', machine_spec = '" + sSpec + "', ip = '" + sIP + "'" +
                    " WHERE equipment_id = '" + sID + "'";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    MessageBox.Show(msg);
                    return;
                }

                m.TransLogCreate(G.Authority, G.UserID, "M", this.Name, lblTitle.Text, sID + " " + sHo + " " + sName + " " + sModel);

                var data = sql;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);

                //sql = $@"UPDATE FMM_facility_info SET 
                //            machine_group = {@sModel}, machine_no = {@sID}, machine_name = {@sName}, made_company = {@sMadeCom}, made_date = {@sMadeDate}, supplier = {@sBuyCom}, 
                //            buy_date = {@sBuyDate}, buy_money = {@sMoney}, manager = {@sCharge}, as_company = {@sAsCom}, machine_spec = {@sSpec}, DOC_SIZE = 0, 
                //            DOC_ORIGINNAME = '', DOC_NAME = '', DOC_FILEPATH = '', machine_ip = {@sIP}, enter_man = {@G.UserID} WHERE machine_no IS {@sID}; ";

                //m.dbCUD(sql, ref msg);

                //if (msg != "OK")
                //{
                //    MessageBox.Show(msg);
                //    return;
                //}

                //m.TransLogCreate(G.Authority, G.UserID, "M", this.Name, lblTitle.Text, sID + " " + sName + " " + sModel + " " + "(FMM_facility_info)");

                ListSearch();
                lblMsg.Text = "저장되었습니다.";

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == sID)
                    {
                        dataGridView1.CurrentCell = dataGridView1[4, i];
                        dataGridView1.CurrentCell.Selected = true;
                        break;
                    }
                }
            }

            FacilityImageSave(sID);
            txtPath.Text = "";
        }
        private void pbPrint_Click(object sender, EventArgs e)
        {
            //int id = Int32.Parse(lblID.Text.Substring(6, lblID.Text.Length - 6));
            string sID = lblID.Text.Substring(6, lblID.Text.Length - 6);

            if (sID == "0")
            {
                lblMsg.Text = "출력할 설비 카드를 먼저 선택해 주세요.";
                return;
            }

            sP_MachineCard_SelectTableAdapter.Fill(dataSetP1D.SP_MachineCard_Select, sID);


            string reportFileName = "SmartMES_Giroei.Reports.P1D01_MACHINECARD.rdlc";

            ViewReport_V viewReport = new ViewReport_V();
            viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
            viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            ReportDataSource rds = new ReportDataSource("DataSet1", sPMachineCardSelectBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }
        #endregion

        private void cbGroupSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListSearch();
        }

        private void tbNameSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListSearch();
            }
        }

        private string getEquipmentID(string _gubun)
        {
            string sql = @"select UF_EquipmentIDGenerator('" + _gubun + "')";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
    }
}
