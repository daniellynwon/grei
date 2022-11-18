using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1ED06_Machine_Idle2 : SmartMES_Giroei.FormBasic
    {
        private DataTable table;

        public P1ED06_Machine_Idle2()
        {
            InitializeComponent();
        }
        private void P1ED06_Machine_Idle2_Load(object sender, EventArgs e)
        {
            dtpSelectDate.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM"));

            string sql = @"SELECT machine_name FROM tb_machinecard GROUP BY machine_name ORDER BY machine_id";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            //DataTable table = m.dbDataTable(sql, ref msg);
            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
            }

            ListSearch();
        }
        public void ListSearch()
        {
            lblGraphTitle.Text = dtpSelectDate.Value.ToString("yyyy년 M월") + " 일별 비가동 차트";
            
            sP_Machine_IdleinfoTableAdapter.Fill(dataSetP1E.SP_Machine_Idleinfo, dtpSelectDate.Value);

            lbLine1Machine1.Text = "1차용융기";
            lbLine1Machine2.Text = "2차용융기";
            lbLine1Machine3.Text = "다이스";
            lbLine1Machine4.Text = "냉각통";
            lbLine1Machine5.Text = "절단기";

            lbLine2Machine1.Text = "1차용융기";
            lbLine2Machine2.Text = "2차용융기";
            lbLine2Machine3.Text = "다이스";
            lbLine2Machine4.Text = "냉각통";
            lbLine2Machine5.Text = "절단기";

            //설비별 비가동 시간 기본값(= 0) 설정
            tbTotalIdleTime1.Text = "0";
            tbLine1Machine1.Text = "0";
            tbLine1Machine2.Text = "0";
            tbLine1Machine3.Text = "0";
            tbLine1Machine4.Text = "0";
            tbLine1Machine5.Text = "0";

            tbTotalIdleTime2.Text = "0";
            tbLine2Machine1.Text = "0";
            tbLine2Machine2.Text = "0";
            tbLine2Machine3.Text = "0";
            tbLine2Machine4.Text = "0";
            tbLine2Machine5.Text = "0";

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value == null || dataGridView1.Rows[i].Cells[j].Value == DBNull.Value)
                    {
                        return;
                    }
                }
            }

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                //1번 라인
                if (dataGridView1.Rows[i].Cells[1].Value.ToString() == "1")
                {
                    //1번 설비
                    if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "1차용융기")
                        tbLine1Machine1.Text = (int.Parse(tbLine1Machine1.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                    //2번 설비
                    if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "2차용융기")
                        tbLine1Machine2.Text = (int.Parse(tbLine1Machine2.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                    //3번 설비
                    if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "다이스")
                        tbLine1Machine3.Text = (int.Parse(tbLine1Machine3.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                    //4번 설비
                    if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "냉각통")
                        tbLine1Machine4.Text = (int.Parse(tbLine1Machine4.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                    //5번 설비
                    if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "절단기")
                        tbLine1Machine5.Text = (int.Parse(tbLine1Machine5.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                }

                tbTotalIdleTime1.Text = (int.Parse(tbLine1Machine1.Text) + int.Parse(tbLine1Machine2.Text) + int.Parse(tbLine1Machine3.Text) + int.Parse(tbLine1Machine4.Text) + int.Parse(tbLine1Machine5.Text)).ToString();

                //2번 라인
                if (dataGridView1.Rows[i].Cells[1].Value.ToString() == "2")
                {
                    //1번 설비
                    if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "1차용융기")
                        tbLine2Machine1.Text = (int.Parse(tbLine2Machine1.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                    //2번 설비
                    if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "2차용융기")
                        tbLine2Machine2.Text = (int.Parse(tbLine2Machine2.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                    //3번 설비
                    if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "다이스")
                        tbLine2Machine3.Text = (int.Parse(tbLine2Machine3.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                    //4번 설비
                    if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "냉각통")
                        tbLine2Machine4.Text = (int.Parse(tbLine2Machine4.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                    //5번 설비
                    if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "절단기 ")
                        tbLine2Machine5.Text = (int.Parse(tbLine2Machine5.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                }

                tbTotalIdleTime2.Text = (int.Parse(tbLine2Machine1.Text) + int.Parse(tbLine2Machine2.Text) + int.Parse(tbLine2Machine3.Text) + int.Parse(tbLine2Machine4.Text) + int.Parse(tbLine2Machine5.Text)).ToString();
            }

            ChartSearch1();
            ChartSearch2();
        }

        #region Chart
        public void ChartSearch1()
        {
            string DateyyyyMMdd = dtpSelectDate.Value.ToString("yyyy-MM-dd");

            string Dateyyyy = DateyyyyMMdd.Split('-')[0];
            string DateMM = DateyyyyMMdd.Split('-')[1];

            int DaysInDateyyyyMMdd = DateTime.DaysInMonth(int.Parse(Dateyyyy), int.Parse(DateMM));
            MessageBox.Show(Dateyyyy + "년 " + DateMM + "월은 총 " + DaysInDateyyyyMMdd + "일");

            string DateForCompare = string.Empty;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                sP_Machine_Idleinfo2TableAdapter.Fill(dataSetP1E.SP_Machine_Idleinfo2, dtpSelectDate.Value);

                TotalChart.Series["1번 생산라인"].Points.Clear();
                TotalChart.Series["2번 생산라인"].Points.Clear();

                for (int i = 1; i <= DaysInDateyyyyMMdd; i++)
                {
                    DateForCompare = Dateyyyy + "-" + DateMM + "-" + i.ToString().PadLeft(2,'0');
                    
                    for (int j = 0; j < dataGridView2.RowCount; j++)
                    {
                        if (DateTime.Parse(dataGridView2.Rows[j].Cells[0].Value.ToString()).ToString("yyyy-MM-dd") == DateForCompare)
                        {
                            if (dataGridView2.Rows[j].Cells[1].Value.ToString() == "1")
                            {
                                TotalChart.Series["1번 생산라인"].Points.AddXY(i, dataGridView2.Rows[j].Cells[2].Value.ToString());
                                TotalChart.Series["2번 생산라인"].Points.AddXY(i, 0);
                            }

                            if (dataGridView2.Rows[j].Cells[1].Value.ToString() == "2")
                            {
                                TotalChart.Series["1번 생산라인"].Points.AddXY(i, 0);
                                TotalChart.Series["2번 생산라인"].Points.AddXY(i, dataGridView2.Rows[j].Cells[2].Value.ToString());
                            }
                        }
                    }
                }
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
        public void ChartSearch2()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Line1Chart.Series["Line1"].Points.Clear();
                Line1Chart.Series["Line1"].Points.AddXY("1차용융기", int.Parse(tbLine1Machine1.Text));
                Line1Chart.Series["Line1"].Points.AddXY("2차용융기", int.Parse(tbLine1Machine2.Text));
                Line1Chart.Series["Line1"].Points.AddXY("다이스", int.Parse(tbLine1Machine3.Text));
                Line1Chart.Series["Line1"].Points.AddXY("냉각통", int.Parse(tbLine1Machine4.Text));
                Line1Chart.Series["Line1"].Points.AddXY("절단기", int.Parse(tbLine1Machine5.Text));

                Line2Chart.Series["Line2"].Points.Clear();
                Line2Chart.Series["Line2"].Points.AddXY("1차용융기", int.Parse(tbLine2Machine1.Text));
                Line2Chart.Series["Line2"].Points.AddXY("2차용융기", int.Parse(tbLine2Machine2.Text));
                Line2Chart.Series["Line2"].Points.AddXY("다이스", int.Parse(tbLine2Machine3.Text));
                Line2Chart.Series["Line2"].Points.AddXY("냉각통", int.Parse(tbLine2Machine4.Text));
                Line2Chart.Series["Line2"].Points.AddXY("절단기", int.Parse(tbLine2Machine5.Text));
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
        #endregion

        #region GridView Events
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //for (int i = 0; i < dataGridView1.RowCount; i++)
            //{
            //    if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "0") dataGridView1[3, i].Style.ForeColor = Color.Transparent;
            //    if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "0") dataGridView1[4, i].Style.ForeColor = Color.Transparent;
            //    if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "0") dataGridView1[5, i].Style.ForeColor = Color.Transparent;
            //    if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "0") dataGridView1[6, i].Style.ForeColor = Color.Transparent;
            //    if (dataGridView1.Rows[i].Cells[7].Value.ToString() == "0") dataGridView1[7, i].Style.ForeColor = Color.Transparent;
            //    if (dataGridView1.Rows[i].Cells[8].Value.ToString() == "0") dataGridView1[8, i].Style.ForeColor = Color.Transparent;
            //    if (dataGridView1.Rows[i].Cells[9].Value.ToString() == "0") dataGridView1[9, i].Style.ForeColor = Color.Transparent;
            //    if (dataGridView1.Rows[i].Cells[10].Value.ToString() == "0") dataGridView1[10, i].Style.ForeColor = Color.Transparent;
            //    if (dataGridView1.Rows[i].Cells[11].Value.ToString() == "0") dataGridView1[11, i].Style.ForeColor = Color.Transparent;
            //    if (dataGridView1.Rows[i].Cells[12].Value.ToString() == "0") dataGridView1[12, i].Style.ForeColor = Color.Transparent;
            //    if (dataGridView1.Rows[i].Cells[13].Value.ToString() == "0") dataGridView1[13, i].Style.ForeColor = Color.Transparent;
            //    if (dataGridView1.Rows[i].Cells[14].Value.ToString() == "0") dataGridView1[14, i].Style.ForeColor = Color.Transparent;
            //}
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //dataGridView1.ClearSelection();
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

            //string reportFileName = "SmartMES_Giroei.Reports.P1ED06_Machine_Idle2.rdlc";

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

        //private void P1ED06_Machine_Idle2_Activated(object sender, EventArgs e)
        //{
        //    ListSearch();
        //}

        #region Condition Bar Events
        //private void cb_SearchDateChanged(object sender, EventArgs e)
        //{
        //    ListSearch1();
        //}
        #endregion

        private void dtpSelectDate_ValueChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
    }
}
