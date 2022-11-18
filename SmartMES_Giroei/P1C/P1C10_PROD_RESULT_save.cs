using Microsoft.Reporting.WinForms;
using SmartFactory;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1C10_PROD_RESULT_save : SmartMES_Giroei.FormBasic
    {
        int rowIndex = 0;
        public P1C10_PROD_RESULT_save()
        {
            InitializeComponent();
        }
        private void P1C10_PROD_RESULT_save_Load(object sender, EventArgs e)
        {
            dtpDate.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd"));

            string sql = "SELECT co_code, co_item FROM BAS_common WHERE co_kind = 'D' AND LEFT(co_item,3)='SMT'";
            string msg = string.Empty;

            MariaCRUD m = new MariaCRUD();
            DataTable table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbWorkLine.DataSource = table;
                cbWorkLine.ValueMember = "co_code";
                cbWorkLine.DisplayMember = "co_item";
            }

            cbWorkLine.SelectedIndex = 0;
            //this.ActiveControl = tbProd;

            ListSearch();
        }
        public void ListSearch()
        {
            lblMsg.Text = "";

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sLine = cbWorkLine.SelectedValue == null ? "0001" : cbWorkLine.SelectedValue.ToString();

                //sP_ProdResult_Query1TableAdapter.Fill(dataSetP1C.SP_ProdResult_Query1, sLine);

                var data = dataSetP1C.SP_ProdResult_Query1;
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
        public void ListSearch1(string sLine)
        {
            lblMsg.Text = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //sP_ProdResult_Query1TableAdapter.Fill(dataSetP1C.SP_ProdResult_Query1, sLine);

                var data = dataSetP1C.SP_ProdResult_Query1;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

                //rowIndex = dataGridView1.CurrentCell.RowIndex;

                //tbJobNo.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                //tbProd.Tag = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                //tbProd.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
                //dtpStartTime.Text = DateTime.Parse(dataGridView1.Rows[rowIndex].Cells[5].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                //dtpDoneTime.Text = DateTime.Parse(dataGridView1.Rows[rowIndex].Cells[6].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                //tbQty.Text = dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();

                tbJobNo.Text = dataGridView1.Rows[rowIndex].Cells[1].Value == null ? null : dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                tbProd.Tag = dataGridView1.Rows[rowIndex].Cells[3].Value == null ? null : dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                tbProd.Text = dataGridView1.Rows[rowIndex].Cells[4].Value == null ? null : dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
                dtpStartTime.Text = dataGridView1.Rows[rowIndex].Cells[5].Value == null ? null : DateTime.Parse(dataGridView1.Rows[rowIndex].Cells[5].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                dtpDoneTime.Text = dataGridView1.Rows[rowIndex].Cells[6].Value == null ? null : DateTime.Parse(dataGridView1.Rows[rowIndex].Cells[6].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                tbQty.Text = dataGridView1.Rows[rowIndex].Cells[8].Value == null ? null : dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();

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
            tbJobNo.Text = string.Empty;
            cbWorkLine.SelectedValue = (cbWorkLine.SelectedValue == null) ? "0001" : cbWorkLine.SelectedValue.ToString();
            tbProd.Tag = string.Empty;
            tbProd.Text = string.Empty;
            dtpStartTime.Text = string.Empty;
            dtpDoneTime.Text = string.Empty;
            tbQty.Text = string.Empty;

            ListSearch();
        }
        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string sLine = cbWorkLine.SelectedValue.ToString();
            //ListSearch1(sLine);

            tbJobNo.Text = string.Empty;
            tbProd.Tag = string.Empty;
            tbProd.Text = string.Empty;
            dtpStartTime.Text = string.Empty;
            dtpDoneTime.Text = string.Empty;
            tbQty.Text = string.Empty;

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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblMsg.Text = "";

            if (dataGridView1.Rows.Count == 0) return;

            int rowIndex = dataGridView1.CurrentRow.Index;

            tbJobNo.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            tbProd.Tag = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            tbProd.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            dtpStartTime.Text = Convert.ToDateTime(dataGridView1.Rows[rowIndex].Cells[5].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            dtpDoneTime.Text = (dataGridView1.Rows[rowIndex].Cells[6].Value == DBNull.Value) ? null : Convert.ToDateTime(dataGridView1.Rows[rowIndex].Cells[6].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0) return;
            //string sRecipe = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

            //if(e.ColumnIndex == 1)
            //{
            //    //P1C10_PROD_RESULT_save_SUB sub = new P1C10_PROD_RESULT_save_SUB();
            //    //sub.lblTitle.Text = sub.lblTitle.Text + "[수정]";
            //    //sub.parentWin = this;
            //    //sub.ShowDialog();
            //}
            //else if(e.ColumnIndex == 8)
            //{
            //    //P1C10_PROD_RESULT_save_SUB1 sub = new P1C10_PROD_RESULT_save_SUB1();
            //    //sub.sRecipe = sRecipe;
            //    //sub.parentWin = this;
            //    //sub.ShowDialog();
            //}
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //int rowIndex = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible);
            //if (rowIndex <= 0) return;

            //try
            //{
            //    dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(93, 123, 157);
            //    dataGridView1.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(93, 123, 157);
            //    dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.White;

            //    dataGridView1[1, rowIndex].Value = rowIndex.ToString() + "건";

            //    long iSum1 = 0, iSum2 = 0, iSum3 = 0;

            //    for (int i = 0; i < rowIndex; i++)
            //    {
            //        //iSum1 += long.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
            //        //iSum2 += long.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
            //        //iSum3 += long.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
            //    }

            //    //dataGridView1[6, rowIndex].Value = iSum1;
            //    //dataGridView1[7, rowIndex].Value = iSum2;
            //    //dataGridView1[8, rowIndex].Value = iSum3;
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
            tbJobNo.Text = string.Empty;
            cbWorkLine.SelectedValue = (cbWorkLine.SelectedValue == null) ? "0001" : cbWorkLine.SelectedValue.ToString();
            tbProd.Tag = string.Empty;
            tbProd.Text = string.Empty;
            dtpStartTime.Text = string.Empty;
            dtpDoneTime.Text = string.Empty;
            tbQty.Text = string.Empty;

            ListSearch();
        }
        private void pbAdd_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            //P1C02_PROD_RESULT1_SUB sub = new P1C02_PROD_RESULT1_SUB();
            //sub.lblTitle.Text = sub.lblTitle.Text + "[추가]";
            //sub.parentWin = this;
            //sub.ShowDialog();
        }
        private void pbDel_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (G.Authority == "D") return;
            if (dataGridView1.RowCount == 0) return;

            int index = 0;
            string sLotNo = string.Empty;

            try
            {
                index = dataGridView1.CurrentRow.Index;
                sLotNo = dataGridView1.Rows[index].Cells[1].Value.ToString();

                if (dataGridView1.Rows[index].Selected != true)
                {
                    MessageBox.Show("삭제 정보가 선택되지 않았습니다.", this.lblTitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("삭제 정보가 선택되지 않았습니다.", this.lblTitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("LotNo. : " + sLotNo + "\r\r해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No) return;

            string sql = @"select count(job_no) from tb_prod_done_main where job_no = '" + sLotNo + "'";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            string com = m.dbRonlyOne(sql, ref msg).ToString();

            if (msg == "OK" && Int32.Parse(com) > 0)
            {
                MessageBox.Show("실적처리된 Lot번호는 삭제할 수 없습니다.");
                return;
            }

            var data = sql;
            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

            sql = "delete from tb_prod_order where job_no = '" + sLotNo + "'";
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sLotNo);

            data = sql;
            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.삭제, data);

            ListSearch();
        }
        private void pbSave_Click(object sender, EventArgs e)
        {
            //
        }
        private void pbPrint_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            try
            {
                if (dataGridView1.RowCount < 1)
                {
                    lblMsg.Text = "출력정보가 존재하지 않습니다.";
                    return;
                }
                //string reportFileName = "SmartMES_Giroei.Reports.P1C10_PROD_RESULT_save.rdlc";

                //string reportParm1 = "Lot기간 : ";
                //string reportParm2 = "품목명/LotNo : ";
                //string reportParm3 = "";

                //reportParm1 = reportParm1 + dtpDate.Value.ToString("yyyy-MM-dd");

                //if (string.IsNullOrEmpty(tbProd.Text.Trim()))
                //    reportParm2 = reportParm2 + "<전체>";
                //else
                //    reportParm2 = reportParm2 + tbProd.Text.Trim();

                //ViewReport_V viewReport = new ViewReport_V();
                //viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
                //viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

                //ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
                //ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
                //ReportParameter rp3 = new ReportParameter("ReportParameter3", reportParm3);
                //viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });

                //ReportDataSource rds = new ReportDataSource("DataSet1", sPProdOrderQueryBindingSource);
                //viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
                //viewReport.reportViewer1.LocalReport.Refresh();

                //viewReport.ShowDialog();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        #endregion
    
    }
}

