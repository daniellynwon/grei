using Microsoft.Reporting.WinForms;
using SmartFactory;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1A02_PRODUCT : SmartMES_Giroei.FormBasic
    {
        public P1A02_PRODUCT()
        {
            InitializeComponent();
        }
        private void P1A02_PRODUCT_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            cbGubun.SelectedIndex = 0;

            //string sql = @"SELECT co_code, co_item FROM BAS_common WHERE co_kind = 'C' AND co_item <> '<전체>' ORDER BY co_code";

            //MariaCRUD m = new MariaCRUD();
            //string msg = string.Empty;

            //DataTable table = m.dbDataTable(sql, ref msg);

            //if (msg == "OK")
            //{
            //    cbKind.DataSource = table;
            //    cbKind.ValueMember = "co_code";
            //    cbKind.DisplayMember = "co_item";
            //}

            DataTable table;

            string sql = string.Empty;
            string msg = string.Empty;

            MariaCRUD m = new MariaCRUD();

            if (cbGubun.SelectedIndex == 0)
            {
                sql = @"SELECT co_code, co_item FROM BAS_common WHERE co_kind = 'P' ORDER BY co_code";

                table = m.dbDataTable(sql, ref msg);

                if (msg == "OK")
                {
                    cbKind.DataSource = table;
                    cbKind.ValueMember = "co_code";
                    cbKind.DisplayMember = "co_item";
                }
            }
            else
            {
                sql = @"SELECT co_code, co_item FROM BAS_common WHERE co_kind = 'C' ORDER BY co_code";

                table = m.dbDataTable(sql, ref msg);

                if (msg == "OK")
                {
                    cbKind.DataSource = table;
                    cbKind.ValueMember = "co_code";
                    cbKind.DisplayMember = "co_item";
                }
            }

            ListSearch();

            this.ActiveControl = tbSearch;
        }
        public async void ListSearch()
        {
            lblMsg.Text = "";

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //string sGubun = "A";

                //if (cbGubun.Text.Substring(0, 1) == "A") sGubun = "A";
                //else if (cbGubun.Text.Substring(0, 1) == "B") sGubun = "B";
                //else if (cbGubun.Text.Substring(0, 1) == "C") sGubun = "C";
                //else if (cbGubun.Text.Substring(0, 1) == "D") sGubun = "D";
                //else if (cbGubun.Text.Substring(0, 1) == "Z") sGubun = "Z";

                string sGubun = "P";
                string sGubun2 = "P";

                if (cbGubun.SelectedIndex == 0)
                {
                    sGubun = "P";
                    sGubun2 = "P";
                }
                else if (cbGubun.SelectedIndex == 1)
                {
                    sGubun = "M";
                    sGubun2 = "C";
                }
                else if (cbGubun.SelectedIndex == 2)
                {
                    sGubun = "S";
                    sGubun2 = "C";
                }

                string sKind = cbKind.SelectedValue == null ? string.Empty : cbKind.SelectedValue.ToString();
                string sSearch = tbSearch.Text.Trim();

                sP_Product_QueryTableAdapter.Fill(dataSetP1A.SP_Product_Query, sGubun, sGubun2, sKind, sSearch);

                var data = dataSetP1A.SP_Product_Query;
                var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[17].Value.ToString() == "Y") dataGridView1.Rows[i].Cells[17].Value = "O";
                    else if (dataGridView1.Rows[i].Cells[17].Value.ToString() == "N") dataGridView1.Rows[i].Cells[17].Value = "X";

                    if (dataGridView1.Rows[i].Cells[18].Value.ToString() == "Y") dataGridView1.Rows[i].Cells[18].Value = "O";
                    else if (dataGridView1.Rows[i].Cells[18].Value.ToString() == "N") dataGridView1.Rows[i].Cells[18].Value = "X";
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

        #region Button Events
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void pbAdd_Click(object sender, EventArgs e)
        {
            //string sGubun = "A";
            string sGubun = "P";
            string sKind = cbKind.Text;

            //if (sKind == "<전체>")
            //{
            //    lblMsg.Text = "품목 분류를 확인해 주세요.";
            //    return;
            //}

            //if (cbGubun.Text.Substring(0, 1) == "A") sGubun = "A";
            //else if (cbGubun.Text.Substring(0, 1) == "B") sGubun = "B";
            //else if (cbGubun.Text.Substring(0, 1) == "C") sGubun = "C";
            //else if (cbGubun.Text.Substring(0, 1) == "D") sGubun = "D";
            //else if (cbGubun.Text.Substring(0, 1) == "Z") sGubun = "Z";

            if (cbGubun.SelectedIndex == 0) sGubun = "P";
            else if (cbGubun.SelectedIndex == 1) sGubun = "M";
            else if (cbGubun.SelectedIndex == 2) sGubun = "S";

            P1A02_PRODUCT_SUB sub = new P1A02_PRODUCT_SUB(true);
            sub.lblTitle.Text = sub.lblTitle.Text + "[추가]";
            sub.gubun = sGubun;
            //sub.kind = sKind;
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
            string reportFileName = "SmartMES_Giroei.Reports.P1A02_PRODUCT.rdlc";

            string reportParm1 = "품목명 / 품목코드 / 품목분류 : ";
            string reportParm2 = "품목분류 : ";
            string reportParm3 = "분류 : ";

            reportParm1 = reportParm1 + tbSearch.Text.Trim();
            reportParm2 = reportParm2 + cbKind.Text;
            reportParm3 = reportParm3 + cbGubun.Text;

            ViewReport_H viewReport = new ViewReport_H();
            viewReport.reportViewer1.ProcessingMode = ProcessingMode.Local;
            viewReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportFileName;

            ReportParameter rp1 = new ReportParameter("ReportParameter1", reportParm1);
            ReportParameter rp2 = new ReportParameter("ReportParameter2", reportParm2);
            ReportParameter rp3 = new ReportParameter("ReportParameter3", reportParm3);
            viewReport.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });
            
            ReportDataSource rds = new ReportDataSource("DataSet1", sPProductQueryBindingSource);
            viewReport.reportViewer1.LocalReport.DataSources.Add(rds);
            viewReport.reportViewer1.LocalReport.Refresh();

            viewReport.ShowDialog();
        }
        #endregion

        #region Condition Bar Events
        private void rb_CheckedChanged(object sender, EventArgs e)
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
            DataTable table;

            string sql = string.Empty;
            string msg = string.Empty;

            MariaCRUD m = new MariaCRUD();

            if (cbGubun.SelectedIndex == 0)
            {
                sql = @"SELECT co_code, co_item FROM BAS_common WHERE co_kind = 'P' ORDER BY co_code";

                table = m.dbDataTable(sql, ref msg);

                if (msg == "OK")
                {
                    cbKind.DataSource = table;
                    cbKind.ValueMember = "co_code";
                    cbKind.DisplayMember = "co_item";
                }
            }
            else
            {
                sql = @"SELECT co_code, co_item FROM BAS_common WHERE co_kind = 'C' ORDER BY co_code";

                table = m.dbDataTable(sql, ref msg);

                if (msg == "OK")
                {
                    cbKind.DataSource = table;
                    cbKind.ValueMember = "co_code";
                    cbKind.DisplayMember = "co_item";
                }
            }

            ListSearch();
        }
        private void cbKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
        #endregion

        #region GridView Events
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns[7].DefaultCellStyle.Format = "#,##0";
            dataGridView1.Columns[8].DefaultCellStyle.Format = "#,##0";
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (G.Authority == "D") return;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 4) return;

            string sGubun = "P";
            string sKind = cbKind.Text;

            if (cbGubun.SelectedIndex == 0) sGubun = "P";
            else if (cbGubun.SelectedIndex == 1) sGubun = "M";
            else if (cbGubun.SelectedIndex == 2) sGubun = "S";

            P1A02_PRODUCT_SUB sub = new P1A02_PRODUCT_SUB(true);
            sub.lblTitle.Text = sub.lblTitle.Text + "[수정]";
            sub.gubun = sGubun;
            sub.kind = sKind;
            sub.parentWin = this;
            sub.ShowDialog();
        }
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int columnIndex = dataGridView1.CurrentCell.ColumnIndex;

                if (columnIndex == 7 || columnIndex == 8)
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
        #endregion
    }
}
