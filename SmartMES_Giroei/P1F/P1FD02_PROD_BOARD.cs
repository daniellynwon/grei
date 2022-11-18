using Microsoft.Reporting.WinForms;
using SmartFactory;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1FD02_PROD_BOARD : SmartMES_Giroei.FormBasic
    {
        public P1FD02_PROD_BOARD()
        {
            InitializeComponent();
        }
        private void P1FD02_PROD_BOARD_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-01"));

            ListSearch();
        }
        public void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DateTime dtFromDate = Convert.ToDateTime(dtpFromDate.Value.ToString("yyyy-MM-dd"));
                DateTime dtToDate = Convert.ToDateTime(dtpToDate.Value.ToString("yyyy-MM-dd"));

                if (dtFromDate > dtToDate)
                    MessageBox.Show("기간 설정이 정확하지 않습니다.\r\r다시 확인해 주세요.");

                sP_Prod_Board_Query1TableAdapter.Fill(dataSetP1F.SP_Prod_Board_Query1, dtFromDate, dtToDate);

                var data1 = dataSetP1F.SP_Prod_Board_Query1;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data1);

                dataGridView1.CurrentCell = null;
                dataGridView1.ClearSelection();

                sP_Prod_Board_Query2TableAdapter.Fill(dataSetP1F.SP_Prod_Board_Query2, dtFromDate, dtToDate);

                var data2 = dataSetP1F.SP_Prod_Board_Query2;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data2);

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

        #region Condition Bar Events
        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
        #endregion

        #region GridView Events
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            void prod_status_setting(int index)
            {
                if (dataGridView2.Rows[index].Cells[2].Value.ToString() == "0")
                {
                    dataGridView2.Rows[index].Cells[3].Style.BackColor = Color.PaleGreen;
                }
                else if (dataGridView2.Rows[index].Cells[2].Value.ToString() == "1")
                {
                    dataGridView2.Rows[index].Cells[3].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[4].Style.BackColor = Color.PaleGreen;
                }
                else if (dataGridView2.Rows[index].Cells[2].Value.ToString() == "2")
                {
                    dataGridView2.Rows[index].Cells[3].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[4].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[5].Style.BackColor = Color.PaleGreen;
                }
                else if (dataGridView2.Rows[index].Cells[2].Value.ToString() == "3")
                {
                    dataGridView2.Rows[index].Cells[3].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[4].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[5].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[6].Style.BackColor = Color.PaleGreen;
                }
                else if (dataGridView2.Rows[index].Cells[2].Value.ToString() == "4")
                {
                    dataGridView2.Rows[index].Cells[3].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[4].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[5].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[6].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[7].Style.BackColor = Color.PaleGreen;
                }
                else if (dataGridView2.Rows[index].Cells[2].Value.ToString() == "5")
                {
                    dataGridView2.Rows[index].Cells[3].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[4].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[5].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[6].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[7].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[8].Style.BackColor = Color.PaleGreen;
                }
                else if (dataGridView2.Rows[index].Cells[2].Value.ToString() == "6")
                {
                    dataGridView2.Rows[index].Cells[3].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[4].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[5].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[6].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[7].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[8].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[9].Style.BackColor = Color.PaleGreen;
                }
                else if (dataGridView2.Rows[index].Cells[2].Value.ToString() == "7")
                {
                    dataGridView2.Rows[index].Cells[3].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[4].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[5].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[6].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[7].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[8].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[9].Style.BackColor = Color.PaleGreen;
                    dataGridView2.Rows[index].Cells[10].Style.BackColor = Color.PaleGreen;
                }
            }

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                prod_status_setting(i);
            }
        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView2.ClearSelection();
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
            //if (dataGridView1.RowCount <= 1) return;

            //string reportFileName = "SmartMES_Giroei.Reports.P1FD02_PROD_BOARD.rdlc";

            //string reportParm1 = "조회년도 : ";
            //string reportParm2 = "";
            //string reportParm3 = "";

            //reportParm1 = reportParm1 + cbYYYY.Text + "년도";


            //ViewReport_H viewReport = new ViewReport_H();
            //viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
            //viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            //ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
            //ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
            //ReportParameter rp3 = new ReportParameter("ReportParameter3", reportParm3);
            //viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });

            //ReportDataSource rds = new ReportDataSource("DataSet1", sPKPIBindingSource);
            //viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            //viewReport.reportViewer1.LocalReport.Refresh();

            //viewReport.ShowDialog();
        }

        #endregion

        private void P1FD02_PROD_BOARD_Activated(object sender, EventArgs e)
        {
            ListSearch();
        }
    }
}
