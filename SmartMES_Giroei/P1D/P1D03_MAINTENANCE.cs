using Microsoft.Reporting.WinForms;
using SmartFactory;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1D03_MAINTENANCE : SmartMES_Giroei.FormBasic
    {
        public P1D03_MAINTENANCE()
        {
            InitializeComponent();
        }
        private void P1D03_MAINTENANCE_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-01-01"));
            ListSearch();
            this.ActiveControl = tbSearch;
        }

        public void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sSearch = tbSearch.Text.Trim();
                DateTime dtFromDate = DateTime.Parse(dtpFromDate.Value.ToString("yyyy-MM-dd"));
                DateTime dtToDate = DateTime.Parse(dtpToDate.Value.ToString("yyyy-MM-dd"));

                if (dtFromDate > dtToDate)
                    MessageBox.Show("기간 설정이 정확하지 않습니다.\r\r다시 확인해 주세요.");

                sP_MachineRepair_QueryTableAdapter.Fill(dataSetP1D.SP_MachineRepair_Query, sSearch, dtFromDate, dtToDate);

                var data = dataSetP1D.SP_MachineRepair_Query;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

                dataGridView1.CurrentCell = null;
                dataGridView1.ClearSelection();
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

        #region Condition Bar Events
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListSearch();
            }
        }
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            ListSearch();
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

            dataGridView1[2, rowIndex].Value = rowIndex.ToString() + "건";

            long iSum = 0;
            string sMoney = string.Empty;

            for (int i = 0; i < rowIndex; i++)
            {
                sMoney = dataGridView1.Rows[i].Cells[13].Value.ToString();
                if (string.IsNullOrEmpty(sMoney)) sMoney = "0";
                iSum += long.Parse(sMoney);
            }

            dataGridView1[13, rowIndex].Value = iSum;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (G.Authority == "D") return;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 3) return;

            P1D03_MAINTENANCE_SUB sub = new P1D03_MAINTENANCE_SUB();
            sub.lblTitle.Text = sub.lblTitle.Text + "[수정]";
            sub.parentWin = this;
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
            P1D03_MAINTENANCE_SUB sub = new P1D03_MAINTENANCE_SUB();
            sub.lblTitle.Text = sub.lblTitle.Text + "[추가]";
            sub.parentWin = this;
            sub.ShowDialog();
        }
        private void pbDel_Click(object sender, EventArgs e)
        {
            int index = 0;
            //string sNo = string.Empty;
            //string sSeq = string.Empty;
            string sID = string.Empty;
            string sMachineID = string.Empty;
            string sName = string.Empty;
            string sGroup = string.Empty;
            string sDate = string.Empty;
            string sKind = string.Empty;

            try
            {
                index = dataGridView1.CurrentRow.Index;
                //sNo = dataGridView1.Rows[index].Cells[0].Value.ToString();
                //sSeq = dataGridView1.Rows[index].Cells[4].Value.ToString();
                sID = dataGridView1.Rows[index].Cells[0].Value.ToString();
                sMachineID = dataGridView1.Rows[index].Cells[1].Value.ToString();
                sName = dataGridView1.Rows[index].Cells[3].Value.ToString();
                sGroup = dataGridView1.Rows[index].Cells[5].Value.ToString();
                sDate = Convert.ToDateTime(dataGridView1.Rows[index].Cells[6].Value.ToString()).ToString("yyyy-MM-dd");
                //sDate = dataGridView1.Rows[index].Cells[6].Value.ToString();
                sKind = dataGridView1.Rows[index].Cells[7].Value.ToString();

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


            DialogResult dr = MessageBox.Show(sName + "(" + sGroup + ")\r" + sDate + " " + sKind + "\r\r해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.No) return;

            MariaCRUD m = new MariaCRUD();

            string sql = "DELETE FROM FMM_facility_repair WHERE machine_id = '" + sMachineID + "' and id = " + sID;
            string msg = string.Empty;

            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                MessageBox.Show(msg);
                return;
            }

            m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sName + "(" + sGroup + ") " + sDate + " " + sKind);

            var data = sql;
            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.삭제, data);

            ListSearch();
        }
        private void pbSave_Click(object sender, EventArgs e)
        {
            //
        }
        private void pbPrint_Click(object sender, EventArgs e)
        {
            string reportFileName = "SmartMES_Giroei.Reports.P1D03_MAINTENANCE.rdlc";

            string reportParm1 = "점검기간 : ";
            string reportParm2 = "설비그룹/설비명 :";
            string reportParm3 = "";

            reportParm1 = reportParm1 + dtpFromDate.Value.ToString("yyyy-MM-dd") + " ~ " + dtpToDate.Value.ToString("yyyy-MM-dd");

            if (string.IsNullOrEmpty(tbSearch.Text.Trim())) reportParm2 = reportParm2 + "전체";
            else reportParm2 = reportParm2 + tbSearch.Text.Trim();

            reportParm3 = reportParm3 + "";

            ViewReport_H viewReport = new ViewReport_H();
            viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
            viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
            ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
            ReportParameter rp3 = new ReportParameter("ReportParameter3", reportParm3);
            viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });

            ReportDataSource rds = new ReportDataSource("DataSet1", sPMachineRepairQueryBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }
        #endregion
    }
}
