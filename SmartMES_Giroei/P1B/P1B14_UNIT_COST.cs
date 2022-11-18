using Microsoft.Reporting.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B14_UNIT_COST : SmartMES_Giroei.FormBasic
    {
        public P1B14_UNIT_COST()
        {
            InitializeComponent();
        }
        private void P1B14_UNIT_COST_Load(object sender, EventArgs e)
        {
            tbYear.Text = DateTime.Today.Year.ToString();
            cbMonth.SelectedIndex = DateTime.Today.Month - 1;

            ListSearch();
            this.ActiveControl = tbSearch;
        }
        public void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                String FromDateTime = cbMonth.SelectedItem == null ? String.Empty : tbYear.Text.Trim() + "-" + cbMonth.SelectedItem.ToString() + "-01";

                if (!string.IsNullOrEmpty(FromDateTime))
                {
                    lblMsg.Text = "";

                    sP_Danga_QueryTableAdapter.Fill(dataSetP1B.SP_Danga_Query, Convert.ToDateTime(FromDateTime));

                    if(dataGridView1.RowCount == 0)
                        lblMsg.Text = tbYear.Text + "년 " + cbMonth.SelectedItem + "월의 데이터가 없습니다!";

                    dataGridView1.Columns[5].ReadOnly = false;
                }

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
        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListSearch();
            }
        }
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
        #endregion

        #region GridView Events
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //if (dataGridView1.RowCount < 2) return;

            //try
            //{                
            //    string sGubun = "-";
            //    string sProd = "-";
                
            //    foreach (DataGridViewRow row in dataGridView1.Rows)
            //    {
            //        if (sGubun == row.Cells[0].Value.ToString() && sProd == row.Cells[1].Value.ToString())
            //        {
            //            sGubun = row.Cells[0].Value.ToString();
            //            sProd = row.Cells[1].Value.ToString();

            //            row.Cells[0].Value = null;
            //            row.Cells[2].Value = null;
            //            row.Cells[3].Value = null;
            //            row.Cells[4].Value = null;
            //        }
            //        else
            //        {
            //            sGubun = row.Cells[0].Value.ToString();
            //            sProd = row.Cells[1].Value.ToString();
            //        }
            //    }                
            //}
            //catch (NullReferenceException)
            //{
            //    return;
            //}
        }
        #endregion

        #region Button Events
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void pbAdd_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            //ListSearch1();
            //ListInit();

            P1B14_UNIT_COST_SUB sub = new P1B14_UNIT_COST_SUB();
            sub.lblTitle.Text = sub.lblTitle.Text + "[추가]";
            sub.parentWin = this;
            sub.ShowDialog();
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

            string reportFileName = "SmartMES_Giroei.Reports.P1B14_UNIT_COST.rdlc";

            string reportParm1 = "자재";
            string reportParm2 = "품목명/규격/입고처 : ";
            string reportParm3 = "";

            if (string.IsNullOrEmpty(tbSearch.Text.Trim())) reportParm2 = reportParm2 + "전체";
            else reportParm2 = reportParm2 + tbSearch.Text.Trim();

            reportParm3 = reportParm3 + "";

            ViewReport_V viewReport = new ViewReport_V();
            viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
            viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
            ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
            ReportParameter rp3 = new ReportParameter("ReportParameter3", reportParm3);
            viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });

            ReportDataSource rds = new ReportDataSource("DataSet1", sPDangaQueryBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }

        #endregion

        private void P1B14_UNIT_COST_Activated(object sender, EventArgs e)
        {
            ListSearch();
        }

        #region GridView Events
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int columnIndex = dataGridView1.CurrentCell.ColumnIndex;

                if (columnIndex == 5)
                {
                    if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '.'))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
        }
        #endregion

        //private void tbYear_TextChanged(object sender, EventArgs e)
        //{
        //    ListSearch();
        //}

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListSearch();
        }

        private void tbYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void tbYear_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(tbYear.Text.Trim()) || tbYear.Text.Trim().Length != 4)
                {
                    lblMsg.Text = "검색년도가 잘못 입력되었습니다.";

                    tbYear.Text = DateTime.Today.Year.ToString();

                    return;
                }
                else
                {
                    ListSearch();
                }
            }
        }
    }
}
