using Microsoft.Reporting.WinForms;
using SmartFactory;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B11_PURCHASE_RAW_MAT : SmartMES_Giroei.FormBasic
    {
        public P1B11_PURCHASE_RAW_MAT()
        {
            InitializeComponent();
        }
        private void P1B11_PURCHASE_RAW_MAT_Load(object sender, EventArgs e)
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

                //sP_PurchaseMat_QueryTableAdapter.Fill(dataSetP1B.SP_PurchaseMat_Query, sFlag, dtFromDate, dtToDate, sSearch, sGubun);
                sP_PurchaseRawMat_INTableAdapter.Fill(dataSetP1B.SP_PurchaseRawMat_IN, dtFromDate, dtToDate, sSearch);

                var data = dataSetP1B.SP_PurchaseRawMat_IN;
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
        private void cbTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
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
        private void cbGubun_SelectedIndexChanged(object sender, EventArgs e)
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

            //dataGridView1[0, rowIndex].Value = rowIndex.ToString() + "건";

            try
            {
                int iSujuCount = 1;
                long iSum1 = 0, iSum2 = 0, iSum3 = 0, iSum4 = 0;
                DataGridViewButtonCell buttonCell;
                string sCodeA = dataGridView1.Rows[0].Cells[0].Value.ToString();        // 수주번호
                string sCodeB = dataGridView1.Rows[0].Cells[1].Value.ToString();        // 수주순번

                for (int i = 0; i < rowIndex; i++)
                {
                    //
                    //   중복 제거
                    if (sCodeA == dataGridView1.Rows[i].Cells[0].Value.ToString() && sCodeB == dataGridView1.Rows[i].Cells[1].Value.ToString())
                    {
                        if (i > 0)
                        {
                            dataGridView1.Rows[i].Cells[0].Style.ForeColor = Color.Transparent;
                            dataGridView1.Rows[i].Cells[1].Style.ForeColor = Color.Transparent;
                            dataGridView1.Rows[i].Cells[2].Style.ForeColor = Color.Transparent;
                            dataGridView1.Rows[i].Cells[3].Style.ForeColor = Color.Transparent;
                            dataGridView1.Rows[i].Cells[4].Style.ForeColor = Color.Transparent;
                            dataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.Transparent;
                        }
                    }
                    sCodeA = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    sCodeB = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    //
                    if (i > 0)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() != dataGridView1.Rows[i - 1].Cells[0].Value.ToString())
                        {
                            iSujuCount++;
                        }
                    }
                    if (!(string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[9].Value.ToString())))
                        iSum1 += long.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString());
                    else iSum1 += 0;

                    if (!(string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[10].Value.ToString())))
                        iSum2 += long.Parse(dataGridView1.Rows[i].Cells[10].Value.ToString());
                    else iSum2 += 0;

                    if (!(string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[11].Value.ToString())))
                        iSum3 += long.Parse(dataGridView1.Rows[i].Cells[11].Value.ToString());
                    else iSum3 += 0;

                    if (!(string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[15].Value.ToString())))
                        iSum4 += long.Parse(dataGridView1.Rows[i].Cells[15].Value.ToString());
                    else iSum4 += 0;
                }

                dataGridView1[0, rowIndex].Value = iSujuCount.ToString() + "건";

                dataGridView1[9, rowIndex].Value = iSum1;
                dataGridView1[10, rowIndex].Value = iSum2;
                dataGridView1[11, rowIndex].Value = iSum3;
                dataGridView1[15, rowIndex].Value = iSum4;
            }
            catch (NullReferenceException)
            {
                return;
            }



            //if (dataGridView1.RowCount < 1) return;

            //try
            //{
            //    string sCodeA = dataGridView1.Rows[0].Cells[0].Value.ToString();        // 수주번호
            //    string sCodeB = dataGridView1.Rows[0].Cells[4].Value.ToString();        // 품목코드

            //    for (int i = 1; i < dataGridView1.RowCount; i++)
            //    {
            //        if (sCodeA == dataGridView1.Rows[i].Cells[0].Value.ToString())
            //        {
            //            dataGridView1.Rows[i].Cells[0].Style.ForeColor = Color.Transparent;
            //            dataGridView1.Rows[i].Cells[1].Style.ForeColor = Color.Transparent;
            //            dataGridView1.Rows[i].Cells[2].Style.ForeColor = Color.Transparent;
            //            dataGridView1.Rows[i].Cells[3].Style.ForeColor = Color.Transparent;
            //            dataGridView1.Rows[i].Cells[4].Style.ForeColor = Color.Transparent;
            //            dataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.Transparent;
            //        }
            //        sCodeA = dataGridView1.Rows[i].Cells[0].Value.ToString();
            //    }
            //}
            //catch (NullReferenceException)
            //{
            //    return;
            //}
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (G.Authority == "D") return;
            //if (e.RowIndex < 0) return;
            //if (e.RowIndex == dataGridView1.RowCount - 1) return;

            //dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
            //dataGridView1.CurrentCell.Selected = true;

            //if (e.ColumnIndex == 5)
            //{
            //    //P1B11_PURCHASE_RAW_MAT_SUB sub = new P1B11_PURCHASE_RAW_MAT_SUB();
            //    //sub.lblTitle.Text = sub.lblTitle.Text + "[수정]";
            //    //sub.parentWin = this;
            //    //sub.ShowDialog();
            //}
            //else if (e.ColumnIndex == 10)   // 입고
            //{
            //    //P1B11_PURCHASE_RAW_MAT_IN sub = new P1B11_PURCHASE_RAW_MAT_IN();
            //    //if (dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString() == "N")
            //    //    sub.lblTitle.Text = sub.lblTitle.Text + "[추가]";
            //    //else
            //    //    sub.lblTitle.Text = sub.lblTitle.Text + "[수정]";
            //    //sub.parentWin = this;
            //    //sub.ShowDialog();
            //}
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == dataGridView1.RowCount - 1) return;

            if (!(e.ColumnIndex == 14 || e.ColumnIndex == 15))
                return;

            if (e.Value.ToString() == "0")
                e.CellStyle.ForeColor = Color.Transparent;

            //if (e.RowIndex == dataGridView1.RowCount - 1) return;

            //if (!(e.ColumnIndex == 14 || e.ColumnIndex == 15))
            //    return;

            //if (e.Value.ToString() == "0")
            //    e.CellStyle.ForeColor = Color.Transparent;
            //else
            //{
            //    //if (e.ColumnIndex == 18)
            //    //{
            //    //    long lQty = long.Parse(dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString());
            //    //    long lDanga = long.Parse(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
            //    //    long lAmount = long.Parse(dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString());

            //    //    if ((lQty * lDanga) == lAmount)
            //    //        e.CellStyle.ForeColor = Color.Black;
            //    //    else
            //    //        e.CellStyle.ForeColor = Color.Red;
            //    //}
            //    //else
            //    //    e.CellStyle.ForeColor = Color.Black;
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
            P1B11_PURCHASE_RAW_MAT_SUB sub = new P1B11_PURCHASE_RAW_MAT_SUB();
            sub.parentWin = this;
            sub.ShowDialog();
        }
        private void pbDel_Click(object sender, EventArgs e)
        {
            //int index = 0;
            //string sNo = string.Empty;
            //string sCustName = string.Empty;
            //string sProdName = string.Empty;

            //try
            //{
            //    index = dataGridView1.CurrentRow.Index;
            //    sNo = dataGridView1.Rows[index].Cells[0].Value.ToString();
            //    sCustName = dataGridView1.Rows[index].Cells[3].Value.ToString();
            //    sProdName = dataGridView1.Rows[index].Cells[5].Value.ToString();

            //    if (dataGridView1.Rows[index].Selected != true)
            //    {
            //        MessageBox.Show("삭제 정보가 선택되지 않았습니다.", this.lblTitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            //catch (NullReferenceException)
            //{
            //    MessageBox.Show("삭제 정보가 선택되지 않았습니다.", this.lblTitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}


            //DialogResult dr = MessageBox.Show(sNo + "\r" + sCustName + "\r(" + sProdName + ")\r\r해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //if (dr == DialogResult.No) return;

            //MariaCRUD m = new MariaCRUD();
            //string sql = "delete from tb_purchase_mat where purchase_id = '" + sNo + "'";
            //string msg = string.Empty;
            //m.dbCUD(sql, ref msg);

            //if (msg != "OK")
            //{
            //    MessageBox.Show(msg);
            //    return;
            //}

            //m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sNo + " " + sCustName + " (" + sProdName + ")");

            //ListSearch();
        }
        private void pbSave_Click(object sender, EventArgs e)
        {
            //
        }
        private void pbPrint_Click(object sender, EventArgs e)
        {
            string reportFileName = "SmartMES_Giroei.Reports.P1B11_PURCHASE_RAW_MAT.rdlc";

            string reportParm1 = "수주일자 : ";
            string reportParm2 = "고객사/자재명 : ";
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

            ReportDataSource rds = new ReportDataSource("DataSet1", sPPurchaseRawMatINBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }
        #endregion
    }
}
