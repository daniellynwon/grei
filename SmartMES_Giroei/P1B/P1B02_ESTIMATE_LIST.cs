﻿using Microsoft.Reporting.WinForms;
using SmartFactory;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B02_ESTIMATE_LIST : SmartMES_Giroei.FormBasic
    {
        public P1B02_ESTIMATE_LIST()
        {
            InitializeComponent();
        }
        private void P1B02_ESTIMATE_LIST_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-01"));
            cbROrder.SelectedIndex = 0;
            ListSearch();
            this.ActiveControl = tbSearch;
        }
        public async void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DateTime dtFromDate = DateTime.Parse(dtpFromDate.Value.ToString("yyyy-MM-dd"));
                DateTime dtToDate = DateTime.Parse(dtpToDate.Value.ToString("yyyy-MM-dd"));

                if (dtFromDate > dtToDate)
                    MessageBox.Show("기간 설정이 정확하지 않습니다.\r\r다시 확인해 주세요.");

                string sSearch = tbSearch.Text.Trim();
                string sFlag = "%";
                if (cbROrder.SelectedIndex == 1) sFlag = "N";
                else if (cbROrder.SelectedIndex == 2) sFlag = "Y";

                sP_EstimateList_QueryTableAdapter.Fill(dataSetP1B.SP_EstimateList_Query, dtFromDate, dtToDate, sSearch, sFlag);

                var data = dataSetP1B.SP_EstimateList_Query;
                var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

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
        private void cbROrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
        #endregion

        #region GridView Events
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                int rowIndex = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible);
                if (rowIndex <= 0) return;

                dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(93, 123, 157);
                dataGridView1.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(93, 123, 157);
                dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.White;

                dataGridView1[1, rowIndex].Value = rowIndex.ToString() + "건";

                long iSum1 = 0, iSum2 = 0;

                for (int i = 0; i < rowIndex; i++)
                {
                    iSum1 += long.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString());
                    iSum2 += long.Parse(dataGridView1.Rows[i].Cells[11].Value.ToString());;
                }

                dataGridView1[9, rowIndex].Value = iSum1;
                dataGridView1[11, rowIndex].Value = iSum2;
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (G.Authority == "D") return;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 5) return;

            string sNo = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            P1B01_ESTIMATE form = new P1B01_ESTIMATE();

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

                form.tbSearch.Text = "";
                form.ListSearch1();

                for (int i = 0; i < form.dataGridViewList.Rows.Count; i++)
                {
                    if (form.dataGridViewList.Rows[i].Cells[0].Value.ToString() == sNo)
                    {
                        form.dataGridViewList.CurrentCell = form.dataGridViewList[2, i];
                        form.dataGridViewList.CurrentCell.Selected = true;

                        form.ListSearch2(i);
                        form.ListSearch3();
                        form.ListSearch4();
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
            if (dataGridView1.RowCount <= 1) return;

            string reportFileName = "SmartMES_Giroei.Reports.P1B02_ESTIMATE_LIST.rdlc";

            string reportParm1 = "견적기간 : ";
            string reportParm2 = "거래처/프로젝트/소재지 : ";
            string reportParm3 = "수주여부 : ";

            reportParm1 = reportParm1 + dtpFromDate.Value.ToString("yyyy-MM-dd") + " ~ " + dtpToDate.Value.ToString("yyyy-MM-dd");

            if (string.IsNullOrEmpty(tbSearch.Text.Trim())) reportParm2 = reportParm2 + "전체";
            else reportParm2 = reportParm2 + tbSearch.Text.Trim();

            reportParm3 = reportParm3 + cbROrder.Text;

            ViewReport_H viewReport = new ViewReport_H();
            viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
            viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
            ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
            ReportParameter rp3 = new ReportParameter("ReportParameter3", reportParm3);
            viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });

            ReportDataSource rds = new ReportDataSource("DataSet1", sPEstimateListQueryBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }
        #endregion
    }
}
