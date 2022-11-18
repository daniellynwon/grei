using Microsoft.Reporting.WinForms;
using SmartFactory;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B08_DELI_ORDER_TERM : SmartMES_Giroei.FormBasic
    {
        public P1B08_DELI_ORDER_TERM()
        {
            InitializeComponent();
        }
        private void P1B08_DELI_ORDER_TERM_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-01"));
            ListSearch();
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

                sP_Delivery_QueryTableAdapter.Fill(dataSetP1B.SP_Delivery_Query, dtFromDate, dtToDate, sSearch);

                var data = dataSetP1B.SP_Delivery_Query;
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

                long iSum1 = 0, iSum2 = 0;

                for (int i = 0; i < rowIndex; i++)
                {
                    iSum1 += long.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
                    iSum2 += long.Parse(dataGridView1.Rows[i].Cells[10].Value.ToString());
                }

                dataGridView1[8, rowIndex].Value = iSum1;
                dataGridView1[10, rowIndex].Value = iSum2;

                dataGridView1[12, rowIndex] = new DataGridViewTextBoxCell();
                dataGridView1[12, rowIndex].Value = "";
            }
            catch (NullReferenceException)
            {
                return;
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (G.Authority == "D") return;

            if (dataGridView1.Rows.Count > 1)
            {
                if (e.RowIndex < 0) return;
                if (e.ColumnIndex != 12) return;

                if (e.ColumnIndex == 12)
                {
                    if (G.Authority == "D") return;

                    ListSearch();

                    P1B08_DELI_ORDER_TERM_SUB sub = new P1B08_DELI_ORDER_TERM_SUB();
                    sub.parentWin = this;

                    sub.sRorderNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    sub.sCustID = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    sub.sCustName = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    sub.sDeliID = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    sub.sProdID = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    sub.sProdName = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    sub.sQty = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

                    sub.ShowDialog();
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

            string reportFileName = "SmartMES_Giroei.Reports.P1B08_DELI_ORDER_TERM.rdlc";

            string reportParm1 = "요청일자 : ";
            string reportParm2 = "거래처/출하번호/품목정보 : ";
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

            ReportDataSource rds = new ReportDataSource("DataSet1", sPDeliveryQueryBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }
        #endregion

        private void P1B08_DELI_ORDER_TERM_Activated(object sender, EventArgs e)
        {
            ListSearch();
        }
    }
}
