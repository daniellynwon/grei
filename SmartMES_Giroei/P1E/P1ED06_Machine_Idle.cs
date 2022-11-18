using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1ED06_Machine_Idle : SmartMES_Giroei.FormBasic
    {
        private DataTable Line1Machine, Line2Machine;

        public P1ED06_Machine_Idle()
        {
            InitializeComponent();
        }
        private void P1ED06_Machine_Idle_Load(object sender, EventArgs e)
        {
            //dtpSelectDate.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM"));

            tbYear.Text = DateTime.Today.ToString("yyyy-MM-dd").Split('-')[0];
            cbMonth.SelectedItem = DateTime.Today.ToString("yyyy-MM-dd").Split('-')[1];

            lblMsg.Text = "";

            ListSearch();
        }
        public void ListSearch()
        {
            lblMsg.Text = "";

            string sql1 = @"SELECT model_no, machine_name FROM tb_machinecard WHERE model_no = '0001' ORDER BY machine_id";
            MariaCRUD m1 = new MariaCRUD();
            string msg1 = string.Empty;

            //DataTable Line1Machine = m1.dbDataTable(sql1, ref msg1);
            Line1Machine = m1.dbDataTable(sql1, ref msg1);

            if (msg1 == "OK")
            {
                ////Convert.ToString(Line1Machine.Rows[0][1]);
                //MessageBox.Show("1-1 : " + Convert.ToString(Line1Machine.Rows[0][1]));
                //MessageBox.Show("1-2 : " + Convert.ToString(Line1Machine.Rows[1][1]));
                //MessageBox.Show("1-3 : " + Convert.ToString(Line1Machine.Rows[2][1]));
                //MessageBox.Show("1-4 : " + Convert.ToString(Line1Machine.Rows[3][1]));
                //MessageBox.Show("1-5 : " + Convert.ToString(Line1Machine.Rows[4][1]));
            }

            string sql2 = @"SELECT model_no, machine_name FROM tb_machinecard WHERE model_no = '0002' ORDER BY machine_id";
            MariaCRUD m2 = new MariaCRUD();
            string msg2 = string.Empty;

            //DataTable Line2Machine = m2.dbDataTable(sql2, ref msg2);
            Line2Machine = m2.dbDataTable(sql2, ref msg2);

            if (msg2 == "OK")
            {
                ////Convert.ToString(Line2Machine.Rows[0][1]);
                //MessageBox.Show("2-1 : " + Convert.ToString(Line2Machine.Rows[0][1]));
                //MessageBox.Show("2-2 : " + Convert.ToString(Line2Machine.Rows[1][1]));
                //MessageBox.Show("2-3 : " + Convert.ToString(Line2Machine.Rows[2][1]));
                //MessageBox.Show("2-4 : " + Convert.ToString(Line2Machine.Rows[3][1]));
                //MessageBox.Show("2-5 : " + Convert.ToString(Line2Machine.Rows[4][1]));
            }

            //tbYear.Text = DateTime.Today.ToString("yyyy-MM-dd").Split('-')[0];
            //cbMonth.SelectedItem = DateTime.Today.ToString("yyyy-MM-dd").Split('-')[1];

            tbYear.Text = string.IsNullOrEmpty(tbYear.Text) == true ? DateTime.Today.ToString("yyyy-MM-dd").Split('-')[0] : tbYear.Text.Trim();
            cbMonth.SelectedItem = string.IsNullOrEmpty(cbMonth.Text) == true ? DateTime.Today.ToString("yyyy-MM-dd").Split('-')[1] : cbMonth.SelectedItem;

            //lblGraphTitle.Text = dtpSelectDate.Value.ToString("yyyy년 M월") + " 일별 비가동 차트";

            lblGraphTitle.Text = tbYear.Text + "년 " + cbMonth.SelectedItem + "월 일별 비가동 차트";

            //sP_Machine_IdleinfoTableAdapter.Fill(dataSetP1E.SP_Machine_Idleinfo, dtpSelectDate.Value);
            sP_Machine_IdleinfoTableAdapter.Fill(dataSetP1E.SP_Machine_Idleinfo, DateTime.Parse(tbYear.Text + "-" + cbMonth.SelectedItem));

            if (dataGridView1.RowCount > 0)
            {
                lbLine1Machine1.Text = Convert.ToString(Line1Machine.Rows[0][1]); //1번라인 1차용융기
                lbLine1Machine2.Text = Convert.ToString(Line1Machine.Rows[1][1]); //1번라인 2차용융기
                lbLine1Machine3.Text = Convert.ToString(Line1Machine.Rows[2][1]); //1번라인 다이스
                lbLine1Machine4.Text = Convert.ToString(Line1Machine.Rows[3][1]); //1번라인 냉각통
                lbLine1Machine5.Text = Convert.ToString(Line1Machine.Rows[4][1]); //1번라인 절단기

                lbLine2Machine1.Text = Convert.ToString(Line2Machine.Rows[0][1]); //2번라인 1차용융기
                lbLine2Machine2.Text = Convert.ToString(Line2Machine.Rows[1][1]); //2번라인 2차용융기
                lbLine2Machine3.Text = Convert.ToString(Line2Machine.Rows[2][1]); //2번라인 다이스
                lbLine2Machine4.Text = Convert.ToString(Line2Machine.Rows[3][1]); //2번라인 냉각통
                lbLine2Machine5.Text = Convert.ToString(Line2Machine.Rows[4][1]); //2번라인 절단기

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
                        if (dataGridView1.Rows[i].Cells[3].Value.ToString() == Convert.ToString(Line1Machine.Rows[0][1])) //1차용융기
                            tbLine1Machine1.Text = (int.Parse(tbLine1Machine1.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                        //2번 설비
                        if (dataGridView1.Rows[i].Cells[3].Value.ToString() == Convert.ToString(Line1Machine.Rows[1][1])) //2차용융기
                            tbLine1Machine2.Text = (int.Parse(tbLine1Machine2.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                        //3번 설비
                        if (dataGridView1.Rows[i].Cells[3].Value.ToString() == Convert.ToString(Line1Machine.Rows[2][1])) //다이스
                            tbLine1Machine3.Text = (int.Parse(tbLine1Machine3.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                        //4번 설비
                        if (dataGridView1.Rows[i].Cells[3].Value.ToString() == Convert.ToString(Line1Machine.Rows[3][1])) //냉각통
                            tbLine1Machine4.Text = (int.Parse(tbLine1Machine4.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                        //5번 설비
                        if (dataGridView1.Rows[i].Cells[3].Value.ToString() == Convert.ToString(Line1Machine.Rows[4][1])) //절단기
                            tbLine1Machine5.Text = (int.Parse(tbLine1Machine5.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                    }

                    tbTotalIdleTime1.Text = (int.Parse(tbLine1Machine1.Text) + int.Parse(tbLine1Machine2.Text) + int.Parse(tbLine1Machine3.Text) + int.Parse(tbLine1Machine4.Text) + int.Parse(tbLine1Machine5.Text)).ToString();

                    //2번 라인
                    if (dataGridView1.Rows[i].Cells[1].Value.ToString() == "2")
                    {
                        //1번 설비
                        if (dataGridView1.Rows[i].Cells[3].Value.ToString() == Convert.ToString(Line2Machine.Rows[0][1])) //1차용융기
                            tbLine2Machine1.Text = (int.Parse(tbLine2Machine1.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                        //2번 설비
                        if (dataGridView1.Rows[i].Cells[3].Value.ToString() == Convert.ToString(Line2Machine.Rows[1][1])) //2차용융기
                            tbLine2Machine2.Text = (int.Parse(tbLine2Machine2.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                        //3번 설비
                        if (dataGridView1.Rows[i].Cells[3].Value.ToString() == Convert.ToString(Line2Machine.Rows[2][1])) //다이스
                            tbLine2Machine3.Text = (int.Parse(tbLine2Machine3.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                        //4번 설비
                        if (dataGridView1.Rows[i].Cells[3].Value.ToString() == Convert.ToString(Line2Machine.Rows[3][1])) //냉각통
                            tbLine2Machine4.Text = (int.Parse(tbLine2Machine4.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                        //5번 설비
                        if (dataGridView1.Rows[i].Cells[3].Value.ToString() == Convert.ToString(Line2Machine.Rows[4][1])) //절단기
                            tbLine2Machine5.Text = (int.Parse(tbLine2Machine5.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();
                    }

                    tbTotalIdleTime2.Text = (int.Parse(tbLine2Machine1.Text) + int.Parse(tbLine2Machine2.Text) + int.Parse(tbLine2Machine3.Text) + int.Parse(tbLine2Machine4.Text) + int.Parse(tbLine2Machine5.Text)).ToString();
                }

                ChartSearch1(true);
                ChartSearch2(true);
            }
            else
            {
                //MessageBox.Show(tbYear.Text + "년 " + cbMonth.SelectedItem + "월의 데이터가 없습니다!");
                lblMsg.Text = tbYear.Text + "년 " + cbMonth.SelectedItem + "월의 데이터가 없습니다!";

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

                ChartSearch1(false);
                ChartSearch2(false);

                return;
            }
            
        }

        #region Chart
        public void ChartSearch1(bool _IsData)
        {
            //string DateyyyyMMdd = dtpSelectDate.Value.ToString("yyyy-MM-dd");

            //string Dateyyyy = DateyyyyMMdd.Split('-')[0];
            //string DateMM = DateyyyyMMdd.Split('-')[1];

            string Dateyyyy = string.IsNullOrEmpty(tbYear.Text) == true ? DateTime.Today.ToString("yyyy-MM-dd").Split('-')[0] : tbYear.Text.Trim();
            string DateMM = string.IsNullOrEmpty(cbMonth.Text) == true ? DateTime.Today.ToString("yyyy-MM-dd").Split('-')[1] : cbMonth.SelectedItem.ToString();

            int DaysInDateyyyyMMdd = DateTime.DaysInMonth(int.Parse(Dateyyyy), int.Parse(DateMM));
            //MessageBox.Show(Dateyyyy + "년 " + DateMM + "월은 총 " + DaysInDateyyyyMMdd + "일");

            string DateForCompare = string.Empty;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                sP_Machine_Idleinfo2TableAdapter.Fill(dataSetP1E.SP_Machine_Idleinfo2, DateTime.Parse(tbYear.Text + "-" + cbMonth.SelectedItem));

                //bool IsValue = true;
                bool IsLine1Search, IsLine2Search;

                TotalChart.Series["1번 생산라인"].Points.Clear();
                TotalChart.Series["2번 생산라인"].Points.Clear();

                if (_IsData)
                {
                    for (int i = 1; i <= DaysInDateyyyyMMdd; i++)
                    {
                        DateForCompare = Dateyyyy + "-" + DateMM + "-" + i.ToString().PadLeft(2, '0');

                        IsLine1Search = true;
                        IsLine2Search = true;

                        for (int j = 0; j < dataGridView2.RowCount; j++)
                        {
                            if (IsLine1Search || IsLine2Search)
                            {
                                if (DateTime.Parse(dataGridView2.Rows[j].Cells[0].Value.ToString()).ToString("yyyy-MM-dd") == DateForCompare)
                                {
                                    if (dataGridView2.Rows[j].Cells[1].Value.ToString() == "1")
                                    {
                                        TotalChart.Series["1번 생산라인"].Points.AddXY(i, dataGridView2.Rows[j].Cells[2].Value.ToString());
                                        TotalChart.Series["2번 생산라인"].Points.AddXY(i, 0);

                                        TotalChart.Series["2번 생산라인"].Points[TotalChart.Series["2번 생산라인"].Points.Count - 1].Label = " ";

                                        IsLine1Search = false;
                                    }

                                    if (dataGridView2.Rows[j].Cells[1].Value.ToString() == "2")
                                    {
                                        TotalChart.Series["1번 생산라인"].Points.AddXY(i, 0);
                                        TotalChart.Series["2번 생산라인"].Points.AddXY(i, dataGridView2.Rows[j].Cells[2].Value.ToString());

                                        TotalChart.Series["1번 생산라인"].Points[TotalChart.Series["1번 생산라인"].Points.Count - 1].Label = " ";

                                        IsLine2Search = false;
                                    }
                                }
                            }
                        }

                        if (IsLine1Search && IsLine2Search)
                        {
                            TotalChart.Series["1번 생산라인"].Points.AddXY(i, 0);
                            TotalChart.Series["1번 생산라인"].Points[TotalChart.Series["1번 생산라인"].Points.Count - 1].Label = " ";

                            TotalChart.Series["2번 생산라인"].Points.AddXY(i, 0);
                            TotalChart.Series["2번 생산라인"].Points[TotalChart.Series["2번 생산라인"].Points.Count - 1].Label = " ";
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= DaysInDateyyyyMMdd; i++)
                    {
                        TotalChart.Series["1번 생산라인"].Points.AddXY(i, 0);
                        TotalChart.Series["1번 생산라인"].Points[TotalChart.Series["1번 생산라인"].Points.Count - 1].Label = " ";
                        TotalChart.Series["2번 생산라인"].Points.AddXY(i, 0);
                        TotalChart.Series["2번 생산라인"].Points[TotalChart.Series["2번 생산라인"].Points.Count - 1].Label = " ";
                    }
                }

                TotalChart.ChartAreas["ChartArea1"].AxisX.Minimum = 1;
                TotalChart.ChartAreas["ChartArea1"].AxisX.Maximum = DaysInDateyyyyMMdd;
                TotalChart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;
                TotalChart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "{0:D} 일";
                TotalChart.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "{0:D} 분";
                //TotalChart.ChartAreas["ChartArea1"].AxisX.TitleAlignment = StringAlignment.Far;
                //TotalChart.ChartAreas["ChartArea1"].AxisX.Title = "일";
                //TotalChart.ChartAreas["ChartArea1"].AxisY.TitleAlignment = StringAlignment.Far;
                //TotalChart.ChartAreas["ChartArea1"].AxisY.Title = "분";
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
        public void ChartSearch2(bool _IsData)
        {
            try
            {
                Line1Chart.Series["Line1"].Points.Clear();
                Line2Chart.Series["Line2"].Points.Clear();

                if (_IsData)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    //1번라인 1차용융기
                    Line1Chart.Series["Line1"].Points.AddXY(Convert.ToString(Line1Machine.Rows[0][1]), int.Parse(tbLine1Machine1.Text));
                    Line1Chart.Series["Line1"].Points[Line1Chart.Series["Line1"].Points.Count - 1].Label = Convert.ToString(Line1Machine.Rows[0][1]);
                    Line1Chart.Series["Line1"].Points[0].LegendText = Convert.ToString(Line1Machine.Rows[0][1]);
                    if (int.Parse(tbLine1Machine1.Text) == 0) Line1Chart.Series["Line1"].Points[0].Label = " ";

                    //1번라인 2차용융기
                    Line1Chart.Series["Line1"].Points.AddXY(Convert.ToString(Line1Machine.Rows[1][1]), int.Parse(tbLine1Machine2.Text));
                    Line1Chart.Series["Line1"].Points[Line1Chart.Series["Line1"].Points.Count - 1].Label = Convert.ToString(Line1Machine.Rows[1][1]);
                    Line1Chart.Series["Line1"].Points[1].LegendText = Convert.ToString(Line1Machine.Rows[1][1]);
                    if (int.Parse(tbLine1Machine2.Text) == 0) Line1Chart.Series["Line1"].Points[1].Label = " ";

                    //1번라인 다이스
                    Line1Chart.Series["Line1"].Points.AddXY(Convert.ToString(Line1Machine.Rows[2][1]), int.Parse(tbLine1Machine3.Text));
                    Line1Chart.Series["Line1"].Points[Line1Chart.Series["Line1"].Points.Count - 1].Label = Convert.ToString(Line1Machine.Rows[2][1]);
                    Line1Chart.Series["Line1"].Points[2].LegendText = Convert.ToString(Line1Machine.Rows[2][1]);
                    if (int.Parse(tbLine1Machine3.Text) == 0) Line1Chart.Series["Line1"].Points[2].Label = " ";

                    //1번라인 냉각통
                    Line1Chart.Series["Line1"].Points.AddXY(Convert.ToString(Line1Machine.Rows[3][1]), int.Parse(tbLine1Machine4.Text));
                    Line1Chart.Series["Line1"].Points[Line1Chart.Series["Line1"].Points.Count - 1].Label = Convert.ToString(Line1Machine.Rows[3][1]);
                    Line1Chart.Series["Line1"].Points[3].LegendText = Convert.ToString(Line1Machine.Rows[3][1]);
                    if (int.Parse(tbLine1Machine4.Text) == 0) Line1Chart.Series["Line1"].Points[3].Label = " ";

                    //1번라인 절단기
                    Line1Chart.Series["Line1"].Points.AddXY(Convert.ToString(Line1Machine.Rows[4][1]), int.Parse(tbLine1Machine5.Text));
                    Line1Chart.Series["Line1"].Points[Line1Chart.Series["Line1"].Points.Count - 1].Label = Convert.ToString(Line1Machine.Rows[4][1]);
                    Line1Chart.Series["Line1"].Points[4].LegendText = Convert.ToString(Line1Machine.Rows[4][1]);
                    if (int.Parse(tbLine1Machine5.Text) == 0) Line1Chart.Series["Line1"].Points[4].Label = " ";

                    //2번라인 1차용융기
                    Line2Chart.Series["Line2"].Points.AddXY(Convert.ToString(Line2Machine.Rows[0][1]), int.Parse(tbLine2Machine1.Text));
                    Line2Chart.Series["Line2"].Points[Line2Chart.Series["Line2"].Points.Count - 1].Label = Convert.ToString(Line1Machine.Rows[0][1]);
                    Line2Chart.Series["Line2"].Points[0].LegendText = Convert.ToString(Line2Machine.Rows[0][1]);
                    if (int.Parse(tbLine2Machine1.Text) == 0) Line2Chart.Series["Line2"].Points[0].Label = " ";

                    //2번라인 2차용융기
                    Line2Chart.Series["Line2"].Points.AddXY(Convert.ToString(Line2Machine.Rows[1][1]), int.Parse(tbLine2Machine2.Text));
                    Line2Chart.Series["Line2"].Points[Line2Chart.Series["Line2"].Points.Count - 1].Label = Convert.ToString(Line2Machine.Rows[1][1]);
                    Line2Chart.Series["Line2"].Points[1].LegendText = Convert.ToString(Line2Machine.Rows[1][1]);
                    if (int.Parse(tbLine2Machine2.Text) == 0) Line2Chart.Series["Line2"].Points[1].Label = " ";

                    //2번라인 다이스
                    Line2Chart.Series["Line2"].Points.AddXY(Convert.ToString(Line2Machine.Rows[2][1]), int.Parse(tbLine2Machine3.Text));
                    Line2Chart.Series["Line2"].Points[Line2Chart.Series["Line2"].Points.Count - 1].Label = Convert.ToString(Line2Machine.Rows[2][1]);
                    Line2Chart.Series["Line2"].Points[2].LegendText = Convert.ToString(Line2Machine.Rows[2][1]);
                    if (int.Parse(tbLine2Machine3.Text) == 0) Line2Chart.Series["Line2"].Points[2].Label = " ";

                    //2번라인 냉각통
                    Line2Chart.Series["Line2"].Points.AddXY(Convert.ToString(Line2Machine.Rows[3][1]), int.Parse(tbLine2Machine4.Text));
                    Line2Chart.Series["Line2"].Points[Line2Chart.Series["Line2"].Points.Count - 1].Label = Convert.ToString(Line2Machine.Rows[3][1]);
                    Line2Chart.Series["Line2"].Points[3].LegendText = Convert.ToString(Line2Machine.Rows[3][1]);
                    if (int.Parse(tbLine2Machine4.Text) == 0) Line2Chart.Series["Line2"].Points[3].Label = " ";

                    //2번라인 절단기
                    Line2Chart.Series["Line2"].Points.AddXY(Convert.ToString(Line2Machine.Rows[4][1]), int.Parse(tbLine2Machine5.Text));
                    Line2Chart.Series["Line2"].Points[Line2Chart.Series["Line2"].Points.Count - 1].Label = Convert.ToString(Line2Machine.Rows[4][1]);
                    Line2Chart.Series["Line2"].Points[4].LegendText = Convert.ToString(Line2Machine.Rows[4][1]);
                    if (int.Parse(tbLine2Machine5.Text) == 0) Line2Chart.Series["Line2"].Points[4].Label = " ";
                }
                else
                {
                    //1번라인
                    Line1Chart.Series["Line1"].Points.AddXY(Convert.ToString(Line1Machine.Rows[0][1]), 0);
                    Line1Chart.Series["Line1"].Points[0].Label = Convert.ToString(Line1Machine.Rows[0][1]);
                    Line1Chart.Series["Line1"].Points.AddXY(Convert.ToString(Line1Machine.Rows[1][1]), 0);
                    Line1Chart.Series["Line1"].Points[1].Label = Convert.ToString(Line1Machine.Rows[1][1]);
                    Line1Chart.Series["Line1"].Points.AddXY(Convert.ToString(Line1Machine.Rows[2][1]), 0);
                    Line1Chart.Series["Line1"].Points[2].Label = Convert.ToString(Line1Machine.Rows[2][1]);
                    Line1Chart.Series["Line1"].Points.AddXY(Convert.ToString(Line1Machine.Rows[3][1]), 0);
                    Line1Chart.Series["Line1"].Points[3].Label = Convert.ToString(Line1Machine.Rows[3][1]);
                    Line1Chart.Series["Line1"].Points.AddXY(Convert.ToString(Line1Machine.Rows[4][1]), 0);
                    Line1Chart.Series["Line1"].Points[4].Label = Convert.ToString(Line1Machine.Rows[4][1]);

                    //2번라인
                    Line2Chart.Series["Line2"].Points.AddXY(Convert.ToString(Line2Machine.Rows[0][1]), 0);
                    Line2Chart.Series["Line2"].Points[0].Label = Convert.ToString(Line2Machine.Rows[0][1]);
                    Line2Chart.Series["Line2"].Points.AddXY(Convert.ToString(Line2Machine.Rows[1][1]), 0);
                    Line2Chart.Series["Line2"].Points[1].Label = Convert.ToString(Line2Machine.Rows[1][1]);
                    Line2Chart.Series["Line2"].Points.AddXY(Convert.ToString(Line2Machine.Rows[2][1]), 0);
                    Line2Chart.Series["Line2"].Points[2].Label = Convert.ToString(Line2Machine.Rows[2][1]);
                    Line2Chart.Series["Line2"].Points.AddXY(Convert.ToString(Line2Machine.Rows[3][1]), 0);
                    Line2Chart.Series["Line2"].Points[3].Label = Convert.ToString(Line2Machine.Rows[3][1]);
                    Line2Chart.Series["Line2"].Points.AddXY(Convert.ToString(Line2Machine.Rows[4][1]), 0);
                    Line2Chart.Series["Line2"].Points[4].Label = Convert.ToString(Line2Machine.Rows[4][1]);
                }

                //Line1Chart.Series["Line1"]["PieLabelStyle"] = "Outside";//Line1Chart.Series["Line1"].SetCustomProperty("PieLabelStyle", "outside");
                //Line2Chart.Series["Line2"]["PieLabelStyle"] = "Outside";//Line2Chart.Series["Line2"].SetCustomProperty("PieLabelStyle", "outside");
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

            //string reportFileName = "SmartMES_Giroei.Reports.P1ED06_Machine_Idle.rdlc";

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

        //private void P1ED06_Machine_Idle_Activated(object sender, EventArgs e)
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

        private void tbYear_KeyUp(object sender, KeyEventArgs e)
        {
            int YearCheck = 0;

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    YearCheck = int.Parse(tbYear.Text.Trim());

                    if (YearCheck > 9999)
                    {
                        lblMsg.Text = "입력한 연도의 자릿수가 너무 큽니다";

                        tbYear.Text = DateTime.Today.ToString("yyyy-MM-dd").Split('-')[0];

                        return;
                    }

                    //tbYear.Text = YearCheck.ToString();

                    ListSearch();
                }
                catch (FormatException)
                {
                    lblMsg.Text = "연도는 숫자로만 입력해 주세요";

                    tbYear.Text = DateTime.Today.ToString("yyyy-MM-dd").Split('-')[0];

                    return;
                }
            }
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //연도도 같이 확인
            int YearCheck = 0;

            try
            {
                YearCheck = int.Parse(tbYear.Text.Trim());

                if (YearCheck > 9999)
                {
                    lblMsg.Text = "입력한 연도의 자릿수가 너무 큽니다";

                    tbYear.Text = DateTime.Today.ToString("yyyy-MM-dd").Split('-')[0];

                    return;
                }

                //tbYear.Text = YearCheck.ToString();

                ListSearch();
            }
            catch (FormatException)
            {
                lblMsg.Text = "연도는 숫자로만 입력해 주세요";

                tbYear.Text = DateTime.Today.ToString("yyyy-MM-dd").Split('-')[0];

                return;
            }

            ListSearch();
        }
    }
}
