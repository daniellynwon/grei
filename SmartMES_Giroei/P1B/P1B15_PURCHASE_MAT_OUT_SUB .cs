using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B15_PURCHASE_MAT_OUT_SUB : Form
    {
        public P1B15_PURCHASE_MAT_OUT parentWin;

        public P1B15_PURCHASE_MAT_OUT_SUB()
        {
            InitializeComponent();
        }
        private void P1B15_PURCHASE_MAT_OUT_SUB_Load(object sender, EventArgs e)
        {
            ListSearch();
            this.ActiveControl = tbSearch;
        }
        public void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string sSearch = tbSearch.Text.Trim();

                sP_PurchaseRawMat_OUT_SUBTableAdapter.Fill(dataSetP1B.SP_PurchaseRawMat_OUT_SUB, sSearch);

                dataGridView1.CurrentCell = null;
                dataGridView1.ClearSelection();

                if (dataGridView1.RowCount <= 0) lblMsg.Text = "출하지시내역이 없습니다.";
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

        #region tbSearch
        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListSearch();
            }
        }
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void pbSearch_MouseDown(object sender, MouseEventArgs e)
        {
            pbSearch.Location = new Point(pbSearch.Location.X + 1, pbSearch.Location.Y + 1);
        }
        private void pbSearch_MouseUp(object sender, MouseEventArgs e)
        {
            pbSearch.Location = new Point(pbSearch.Location.X - 1, pbSearch.Location.Y - 1);
        }
        #endregion

        #region GridView Events
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 7) return;

            string sJobNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string sSujuNo = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string sSujuSeq = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string sCustID = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            string sCustName = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            string sProd = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            string sProdName = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

            lblMsg.Text = "";

            P1B15_PURCHASE_MAT_OUT_BOM sub = new P1B15_PURCHASE_MAT_OUT_BOM();
            sub.sJobNo = sJobNo;
            sub.sSujuNo = sSujuNo;
            sub.sSujuSeq = sSujuSeq;
            sub.sCustID = sCustID;
            sub.sCustName = sCustName;
            sub.sProd = sProd;
            sub.sProdName = sProdName;
            sub.parentWin = this;
            sub.ShowDialog();

        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridView1.RowCount < 2) return;
        }
        #endregion
    }
}
