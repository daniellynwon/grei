using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SmartFactory;

namespace SmartMES_Giroei
{

    public partial class P1C11_AOI_CHART : SmartMES_Giroei.FormBasic
    {
        public P1C11_AOI_CHART()
        {
            InitializeComponent();
            this.Text = "Using Chart Control";
        }

        private void P1C11_AOI_CHART_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-01"));
            ListSearch();
        }
        public void ListSearch()
        {
            try
            {
                string sFrom = dtpFromDate.Value.ToString("yyyy-MM-dd");
                string sTo = dtpToDate.Value.ToString("yyyy-MM-dd");

                sP_Aoi_ChartTableAdapter.Fill(dataSetP1C.SP_Aoi_Chart, DateTime.Parse(sFrom), DateTime.Parse(sTo));

                var data = dataSetP1C.SP_Aoi_Chart;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);
                Chart2Search();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch();
        }

        public void ChartSearch(int sId, string sNo)
        {
            try
            {
                var sSP = dataSetP1C.SP_Aoi_Chart;
                string sCheckItem = string.Empty;

                chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;
                chartTitle.Text = sNo;
                chartTitle.ForeColor = Color.Blue;
                chartTitle.Font = new Font("새굴림", 25, FontStyle.Bold);
                sCheckItem = "불량";
                chart1.Series[sCheckItem].Points.Clear();

                chart1.Series[sCheckItem].Points.AddXY("소납", dataGridView1.Rows[sId].Cells[6].Value.ToString());
                chart1.Series[sCheckItem].Points.AddXY("냉땜", dataGridView1.Rows[sId].Cells[7].Value.ToString());
                chart1.Series[sCheckItem].Points.AddXY("미삽", dataGridView1.Rows[sId].Cells[8].Value.ToString());
                chart1.Series[sCheckItem].Points.AddXY("뒤집힘", dataGridView1.Rows[sId].Cells[9].Value.ToString());
                chart1.Series[sCheckItem].Points.AddXY("리드뜸", dataGridView1.Rows[sId].Cells[10].Value.ToString());
                chart1.Series[sCheckItem].Points.AddXY("미납", dataGridView1.Rows[sId].Cells[11].Value.ToString());
                chart1.Series[sCheckItem].Points.AddXY("쇼트", dataGridView1.Rows[sId].Cells[12].Value.ToString());
                chart1.Series[sCheckItem].Points.AddXY("역삽", dataGridView1.Rows[sId].Cells[13].Value.ToString());
                chart1.Series[sCheckItem].Points.AddXY("맨하탄", dataGridView1.Rows[sId].Cells[14].Value.ToString());
                chart1.Series[sCheckItem].Points.AddXY("틀어짐", dataGridView1.Rows[sId].Cells[15].Value.ToString());
                chart1.Series[sCheckItem].Points.AddXY("기타", dataGridView1.Rows[sId].Cells[16].Value.ToString());
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        public void Chart2Search()
        {
            int rowIndex = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible);
            if (rowIndex <= 0) return;
            try
            {
                var sSP = dataSetP1C.SP_Aoi_Chart;
                string sCheckItem = string.Empty;

                chart2.ChartAreas["ChartArea2"].AxisX.LabelStyle.Interval = 1;
                chart2Title.Text = dtpFromDate.Value.ToString("yyyy.MM.dd");
                chart2Title.ForeColor = Color.Green;
                chart2Title.Font = new Font("새굴림", 25, FontStyle.Bold);

                chart3Title.Text = dtpToDate.Value.ToString("yyyy.MM.dd");
                chart3Title.ForeColor = Color.Green;
                chart3Title.Font = new Font("새굴림", 25, FontStyle.Bold);

                sCheckItem = "불량합계";
                chart2.Series[sCheckItem].Points.Clear();

                chart2.Series[sCheckItem].Points.AddXY("소납", dataGridView1[6, rowIndex].Value);
                chart2.Series[sCheckItem].Points.AddXY("냉땜", dataGridView1[7, rowIndex].Value);
                chart2.Series[sCheckItem].Points.AddXY("미삽", dataGridView1[8, rowIndex].Value);
                chart2.Series[sCheckItem].Points.AddXY("뒤집힘", dataGridView1[9, rowIndex].Value);
                chart2.Series[sCheckItem].Points.AddXY("리드뜸", dataGridView1[10, rowIndex].Value);
                chart2.Series[sCheckItem].Points.AddXY("미납", dataGridView1[11, rowIndex].Value);
                chart2.Series[sCheckItem].Points.AddXY("쇼트", dataGridView1[12, rowIndex].Value);
                chart2.Series[sCheckItem].Points.AddXY("역삽", dataGridView1[13, rowIndex].Value);
                chart2.Series[sCheckItem].Points.AddXY("맨하탄", dataGridView1[14, rowIndex].Value);
                chart2.Series[sCheckItem].Points.AddXY("틀어짐", dataGridView1[15, rowIndex].Value);
                chart2.Series[sCheckItem].Points.AddXY("기타", dataGridView1[16, rowIndex].Value);
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        #region Condition Bar Events
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

            try
            {
                dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(93, 123, 157);
                dataGridView1.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(93, 123, 157);
                dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.White;

                dataGridView1[0, rowIndex].Value = rowIndex.ToString() + "건";

                long iSum1 = 0, iSum2 = 0, iSum3 = 0, iSum4 = 0, iSum5 = 0, iSum6 = 0, iSum7 = 0, iSum8 = 0, iSum9 = 0, iSum10 = 0, iSum11 = 0;

                for (int i = 0; i < rowIndex; i++)
                {
                    iSum1 += long.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                    iSum2 += long.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                    iSum3 += long.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
                    iSum4 += long.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString());
                    iSum5 += long.Parse(dataGridView1.Rows[i].Cells[10].Value.ToString());
                    iSum6 += long.Parse(dataGridView1.Rows[i].Cells[11].Value.ToString());
                    iSum7 += long.Parse(dataGridView1.Rows[i].Cells[12].Value.ToString());
                    iSum8 += long.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());
                    iSum9 += long.Parse(dataGridView1.Rows[i].Cells[14].Value.ToString());
                    iSum10 += long.Parse(dataGridView1.Rows[i].Cells[15].Value.ToString());
                    iSum11 += long.Parse(dataGridView1.Rows[i].Cells[16].Value.ToString());
                }

                dataGridView1[6, rowIndex].Value = iSum1;
                dataGridView1[7, rowIndex].Value = iSum2;
                dataGridView1[8, rowIndex].Value = iSum3;
                dataGridView1[9, rowIndex].Value = iSum4;
                dataGridView1[10, rowIndex].Value = iSum5;
                dataGridView1[11, rowIndex].Value = iSum6;
                dataGridView1[12, rowIndex].Value = iSum7;
                dataGridView1[13, rowIndex].Value = iSum8;
                dataGridView1[14, rowIndex].Value = iSum9;
                dataGridView1[15, rowIndex].Value = iSum10;
                dataGridView1[16, rowIndex].Value = iSum11;

            }
            catch (NullReferenceException)
            {
                return;
            }

        }
        #endregion
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int sID = dataGridView1.CurrentCell.RowIndex;
            string sNo = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            ChartSearch(sID, sNo);
        }
    }
}
