using Microsoft.Reporting.WinForms;
using SmartFactory;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1C09_PROD_NG : SmartMES_Giroei.FormBasic
    {
        public P1C09_PROD_NG()
        {
            InitializeComponent();
        }
        private void P1C09_PROD_NG_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            dtpFromDate.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-01"));

            ListSearch1();
        }

        #region ListSearch
        public void ListSearch1()
        {
            lblMsg.Text = "";

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DateTime dtFromDate = DateTime.Parse(dtpFromDate.Value.ToString("yyyy-MM-dd"));
                DateTime dtToDate = DateTime.Parse(dtpToDate.Value.ToString("yyyy-MM-dd"));

                sP_Prod_Defect_MainTableAdapter.Fill(dataSetP1C.SP_Prod_Defect_Main, dtFromDate, dtToDate);

                var data = dataSetP1C.SP_Prod_Defect_Main;
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
        public void ListSearch2(string _jobno)
        {
            lblMsg.Text = "";

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                sP_Prod_Defect_SubTableAdapter.Fill(dataSetP1C.SP_Prod_Defect_Sub, _jobno);

                var data = dataSetP1C.SP_Prod_Defect_Sub;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

                dataGridView2.CurrentCell = null;
                dataGridView2.ClearSelection();
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
        #endregion

        #region Button Events
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch1();
            ListSearch2("");
        }
        private void pbAdd_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;
            if (dataGridView1.RowCount == 0)
            {
                lblMsg.Text = "진행중인 공정이 없습니다.";

                return;
            }
            
            P1C09_PROD_NG_SUB sub = new P1C09_PROD_NG_SUB();
            sub.lblTitle.Text = sub.lblTitle.Text + "[추가]";
            sub.parentWin = this;

            if (dataGridView1.SelectedRows == null)
            {
                lblMsg.Text = "선택된 수주정보가 없습니다.";

                return;
            }
            else
                sub.job_no = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            sub.ShowDialog();
        }
        private void pbDel_Click(object sender, EventArgs e)
        {
            int index = 0;

            string sID = string.Empty;
            string sJobNo = string.Empty;

            if (dataGridView2.CurrentRow == null)
            {
                lblMsg.Text = "삭제 정보가 선택되지 않았습니다.";

                return;
            }
            else
            {
                index = dataGridView2.CurrentRow.Index;

                sID = dataGridView2.Rows[index].Cells[0].Value.ToString();
                sJobNo = dataGridView2.Rows[index].Cells[1].Value.ToString();
            }

            DialogResult dr = MessageBox.Show("해당 불량정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.No) return;

            MariaCRUD m = new MariaCRUD();

            string sql = "UPDATE PRD_defect SET delYN = 'Y' WHERE id = " + sID + " AND job_no = '" + sJobNo + "'";
            string msg = string.Empty;

            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                MessageBox.Show(msg);
                return;
            }

            var data = sql;
            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);

            string sJobSeq = dataGridView2.Rows[index].Cells[2].Value.ToString();
            string sDefectQty = dataGridView2.Rows[index].Cells[5].Value.ToString();

            m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, G.UserID + " " + sJobNo + " " + sJobSeq + " " + sDefectQty);

            ListSearch1();
            ListSearch2(sJobNo);

            lblMsg.Text = "";

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (sJobNo == dataGridView1.Rows[i].Cells[0].Value.ToString())
                {
                    dataGridView1.Rows[i].Selected = true;
                    return;
                }
                
            }
        }
        private void pbSave_Click(object sender, EventArgs e)
        {
            //
        }
        private void pbPrint_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.RowCount <= 1) return;

            //string reportFileName = "SmartMES_Giroei.Reports.P1C09_PROD_NG.rdlc";

            //string reportParm1 = "생산기간 : ";
            //string reportParm2 = "자재창고 : ";
            //string reportParm3 = "자재분류 : ";

            //reportParm1 = reportParm1 + dtpFromDate.Value.ToString("yyyy-MM-dd") + " ~ " + dtpToDate.Value.ToString("yyyy-MM-dd");
            //reportParm2 = reportParm2 + cbDepot.Text;
            //reportParm3 = reportParm3 + cbKind.Text;

            //ViewReport_V viewReport = new ViewReport_V();
            //viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
            //viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            //ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
            //ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
            //ReportParameter rp3 = new ReportParameter("ReportParameter3", reportParm3);
            //viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });

            //ReportDataSource rds = new ReportDataSource("DataSet1", sPMaterialUseQueryBindingSource);
            //viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            //viewReport.reportViewer1.LocalReport.Refresh();

            //viewReport.ShowDialog();
        }
        #endregion

        #region Condition Bar Events
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            ListSearch1();
            ListSearch2("");
        }
        #endregion

        #region GridView Events
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (G.Authority == "D") return;
            //if (e.RowIndex < 0) return;
            //if (e.ColumnIndex != 0) return;
            ////if (dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible) == e.RowIndex) return;

            //P1C09_PROD_NG_SUB sub = new P1C09_PROD_NG_SUB();
            //sub.lblTitle.Text = sub.lblTitle.Text + "[추가]";
            //sub.parentWin = this;
            //sub.job_no = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //sub.ShowDialog();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ListSearch2(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (G.Authority == "D") return;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 1) return;
            //if (dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible) == e.RowIndex) return;

            P1C09_PROD_NG_SUB sub = new P1C09_PROD_NG_SUB();
            sub.lblTitle.Text = sub.lblTitle.Text + "[수정]";
            sub.parentWin = this;
            sub.job_no = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            sub.ShowDialog();
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblMsg.Text = "";
        }
        #endregion
    }
}
