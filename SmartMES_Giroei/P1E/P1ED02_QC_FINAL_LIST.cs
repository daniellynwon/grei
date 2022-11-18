﻿using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1ED02_QC_FINAL_LIST : SmartMES_Giroei.FormBasic
    {
        public P1ED02_QC_FINAL_LIST()
        {
            InitializeComponent();
        }
        private void P1ED02_QC_FINAL_LIST_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-01"));
            this.ActiveControl = tbSearch;
        }
        public void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DateTime dtFromDate = DateTime.Parse(dtpFromDate.Value.ToString("yyyy-MM-dd"));
                DateTime dtToDate = DateTime.Parse(dtpToDate.Value.ToString("yyyy-MM-dd"));

                if (dtFromDate > dtToDate)
                    MessageBox.Show("기간 설정이 정확하지 않습니다.\r\r다시 확인해 주세요.");

                string sSearch = tbSearch.Text.Trim();

                sP_QcFinalList_QueryTableAdapter.Fill(dataSetP1E.SP_QcFinalList_Query, dtFromDate, dtToDate, sSearch);

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
        private void dtpDate_ValueChanged(object sender, EventArgs e)
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
        #endregion

        #region GridView Events
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (G.Authority == "D") return;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 2) return;

            string sNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            P1ED01_QC_FINAL form = new P1ED01_QC_FINAL();

            if (formIsExist(form.GetType()))
            {
                form.Dispose();
            }
            else
            {
                MDIForm parent = (MDIForm)this.MdiParent;
                form.MdiParent = parent;
                form.Dock = DockStyle.Fill;
                form.Show();

                form.dtpFromDate.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                form.dtpToDate.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                form.tbSearch1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.tbSearch2.Text = "";   // 두 건 이상일 때, 다 나오게 하려고 빈칸.
                form.ListSearch1();

                for (int i = 0; i < form.dataGridViewList.Rows.Count; i++)
                {
                    if (form.dataGridViewList.Rows[i].Cells[0].Value.ToString() == sNo)
                    {
                        form.dataGridViewList.CurrentCell = form.dataGridViewList[1, i];
                        form.dataGridViewList.CurrentCell.Selected = true;

                        form.ListSearch2(sNo);
                        break;
                    }
                }
            }
        }
        // 자식 폼 중복 여부
        private bool formIsExist(Type tp)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == tp)
                {
                    form.Activate();
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Button Events
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void pbAdd_Click(object sender, EventArgs e)
        {
            //
        }
        private void pbDel_Click(object sender, EventArgs e)
        {
            //
        }
        private void pbSave_Click(object sender, EventArgs e)
        {
            //
        }
        private void pbPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount <= 0) return;

            string reportFileName = "SmartMES_Giroei.Reports.P1ED02_QC_FINAL_LIST.rdlc";

            string reportParm1 = "검사기간 : ";
            string reportParm2 = "거래처명/현장정보 : ";
            string reportParm3 = "";

            reportParm1 = reportParm1 + dtpFromDate.Value.ToString("yyyy-MM-dd") + " ~ " + dtpToDate.Value.ToString("yyyy-MM-dd");
            if (string.IsNullOrEmpty(tbSearch.Text.Trim())) reportParm2 = reportParm2 + "전체";
            else reportParm2 = reportParm2 + tbSearch.Text.Trim();

            ViewReport_H viewReport = new ViewReport_H();
            viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
            viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
            ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
            ReportParameter rp3 = new ReportParameter("ReportParameter3", reportParm3);
            viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });

            ReportDataSource rds = new ReportDataSource("DataSet1", sPQcFinalListQueryBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }
        #endregion
    }
}
