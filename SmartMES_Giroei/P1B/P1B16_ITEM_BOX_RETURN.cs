using Microsoft.Reporting.WinForms;
using SmartFactory;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B16_ITEM_BOX_RETURN : SmartMES_Giroei.FormBasic
    {
        public P1B16_ITEM_BOX_RETURN()
        {
            InitializeComponent();
        }
        private void P1B16_ITEM_BOX_RETURN_Load(object sender, EventArgs e)
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

                sP_Itembox_Main_ReturnTableAdapter.Fill(dataSetP1B.SP_Itembox_Main_Return, dtFromDate, dtToDate, sSearch);

                var data = dataSetP1B.SP_Item_Box_Main;
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
            if (dataGridView1.Rows.Count <= 1) return;

            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "완료")
                    dataGridView1.Rows[i].Cells[6].Style.BackColor = Color.PaleGreen;
                else
                    dataGridView1.Rows[i].Cells[6].Style.BackColor = Color.LightPink;
            }

            int rowIndex = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible);
            if (rowIndex <= 0) return;

            dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(93, 123, 157);
            dataGridView1.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(93, 123, 157);
            dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.White;

            dataGridView1[1, rowIndex].Value = rowIndex.ToString() + "건";

            dataGridView1[7, rowIndex] = new DataGridViewTextBoxCell();
            dataGridView1[7, rowIndex].Value = "";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (G.Authority == "D") return;
            if (e.RowIndex < 0) return;
            if (e.RowIndex == dataGridView1.RowCount - 1) return;
            if (e.ColumnIndex == 7)
            {
                P1B16_ITEM_BOX_RETURN_SUB sub = new P1B16_ITEM_BOX_RETURN_SUB();
                //sub.sGubun = "구성완료"; sub.Text = "BOM 구성정보";
                sub.sSujuNo = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                sub.sSujuSeq = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                sub.sProdID = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                sub.sProdName = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                sub.sIsComplete = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                sub.sBoxID = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                sub.parentWin = this;
                sub.ShowDialog();
            }
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //
        }
        #endregion

        #region Button Events
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void pbAdd_Click(object sender, EventArgs e)
        {
            //P1B16_ITEM_BOX_SUB2 sub = new P1B16_ITEM_BOX_SUB2();
            //sub.parentWin1 = this;
            //sub.ShowDialog();
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
            //
        }
        #endregion

    }
}
