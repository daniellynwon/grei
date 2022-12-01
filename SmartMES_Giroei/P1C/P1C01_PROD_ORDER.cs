﻿using Microsoft.Reporting.WinForms;
using SmartFactory;
using System;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1C01_PROD_ORDER : SmartMES_Giroei.FormBasic
    {
        public P1C01_PROD_ORDER()
        {
            InitializeComponent();
        }
        private void P1C01_PROD_ORDER_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-01"));
            this.ActiveControl = tbSearch;
        }
        public void ListSearch()
        {
            lblMsg.Text = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sFrom = dtpFromDate.Value.ToString("yyyy-MM-dd");
                string sTo = dtpToDate.Value.ToString("yyyy-MM-dd");
                string sSearch = tbSearch.Text.Trim();

                sP_ProdOrder_QueryTableAdapter.Fill(dataSetP1C.SP_ProdOrder_Query, DateTime.Parse(sFrom), DateTime.Parse(sTo), sSearch);

                var data = dataSetP1C.SP_ProdOrder_Query;
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblMsg.Text = "";
            if (e.RowIndex < 0) return;

            int index = dataGridView1.CurrentRow.Index;
            string lotno = dataGridView1.Rows[index].Cells[1].Value.ToString();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string sRecipe = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

            if(e.ColumnIndex == 1)
            {
                P1C01_PROD_ORDER_SUB sub = new P1C01_PROD_ORDER_SUB();
                sub.lblTitle.Text = sub.lblTitle.Text + "[수정]";
                sub.parentWin = this;
                sub.ShowDialog();
            }
            else if(e.ColumnIndex == 8)
            {
                //P1C01_PROD_ORDER_SUB1 sub = new P1C01_PROD_ORDER_SUB1();
                //sub.sRecipe = sRecipe;
                //sub.parentWin = this;
                //sub.ShowDialog();
            }
        }
        #endregion

        #region Button Events
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void pbAdd_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            P1C01_PROD_ORDER_SUB sub = new P1C01_PROD_ORDER_SUB();
            sub.lblTitle.Text = sub.lblTitle.Text + "[추가]";
            sub.parentWin = this;
            sub.ShowDialog();
        }
        private void pbDel_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (G.Authority == "D") return;
            if (dataGridView1.RowCount == 0) return;

            int index = 0;
            string sLotNo = string.Empty;
            string sSujuNo = string.Empty;
            string sSujuSeq = string.Empty;

            try
            {
                index = dataGridView1.CurrentRow.Index;
                sLotNo = dataGridView1.Rows[index].Cells[1].Value.ToString();

                sSujuNo = dataGridView1.Rows[index].Cells[13].Value.ToString();
                sSujuSeq = dataGridView1.Rows[index].Cells[14].Value.ToString();

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

            string sql = @"select count(job_no) from PRD_prod_result where job_no = '" + sLotNo + "'";
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

            if (string.IsNullOrEmpty(sSujuNo) == false)
            {
                sql = "update SAL_order_sub set prod_status = 2 where order_id = '" + sSujuNo + "' and order_seq = " + sSujuSeq;
                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }
            }

            sql = "delete from PRD_prod_order where job_no = '" + sLotNo + "'";
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sLotNo);

            data = sql;
            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.삭제, data);

            //sql = $@"UPDATE SAL_order_sub SET SusapProcessOX = 'O' WHERE order_id = '{@sSujuNo}' AND order_seq = {@sSujuSeq}";
            //m.dbCUD(sql, ref msg);

            //if (msg != "OK")
            //{
            //    lblMsg.Text = msg;
            //    return;
            //}

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
                string reportFileName = "SmartMES_Giroei.Reports.P1C01_PROD_ORDER.rdlc";

                string reportParm1 = "Lot기간 : ";
                string reportParm2 = "품목명/LotNo : ";
                string reportParm3 = "";

                reportParm1 = reportParm1 + dtpFromDate.Value.ToString("yyyy-MM-dd") + " ~ " + dtpToDate.Value.ToString("yyyy-MM-dd");

                if (string.IsNullOrEmpty(tbSearch.Text.Trim()))
                    reportParm2 = reportParm2 + "<전체>";
                else
                    reportParm2 = reportParm2 + tbSearch.Text.Trim();

                ViewReport_V viewReport = new ViewReport_V();
                viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
                viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

                ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
                ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
                ReportParameter rp3 = new ReportParameter("ReportParameter3", reportParm3);
                viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });

                ReportDataSource rds = new ReportDataSource("DataSet1", sPProdOrderQueryBindingSource);
                viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
                viewReport.reportViewer1.LocalReport.Refresh();

                viewReport.ShowDialog();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        #endregion
    
    }
}

