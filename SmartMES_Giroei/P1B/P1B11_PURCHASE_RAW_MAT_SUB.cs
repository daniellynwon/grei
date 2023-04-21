using SmartFactory;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B11_PURCHASE_RAW_MAT_SUB : Form
    {
        public P1B11_PURCHASE_RAW_MAT parentWin;

        public P1B11_PURCHASE_RAW_MAT_SUB()
        {
            InitializeComponent();
        }
        private void P1B11_PURCHASE_RAW_MAT_SUB_Load(object sender, EventArgs e)
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

                sP_PurchaseRawMat_IN_SUBTableAdapter.Fill(dataSetP1B.SP_PurchaseRawMat_IN_SUB, sSearch);

                var data = dataSetP1B.SP_PurchaseRawMat_IN_SUB;
                Logger.ApiLog(G.UserID, "수주내역(사급자재입고등록)", ActionType.조회, data);

                dataGridView1.CurrentCell = null;
                dataGridView1.ClearSelection();

                if (dataGridView1.RowCount <= 0) lblMsg.Text = "수주내역이 없습니다.";
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

        #region dataGridView
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 9) return;

            string sSujuNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string sSujuSeq = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string sCustID = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string sProd = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            string sProdName = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

            lblMsg.Text = "";
            if (dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString() == "Y")
            {
                MessageBox.Show("수주취소건은 사급자재입고등록이 불가능합니다.");
                return;
            }
            // 사급자재등록팝업 연결 여기다가
            P1B11_PURCHASE_RAW_MAT_BOM sub = new P1B11_PURCHASE_RAW_MAT_BOM();
            sub.sSujuNo = sSujuNo;
            sub.sSujuSeq = sSujuSeq;
            sub.sCustID = sCustID;
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
            if (dataGridView1.RowCount == 0) return;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "Y")
                {
                    dataGridView1.Rows[i].Cells[7].Value = "1";
                }
            }

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[10].Value.ToString() == "Y") //특정값이면 배경색 바꿔주기 여기서는 재작업 0 OR 1로 판단하여 배경색 바꿈
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.PaleGoldenrod;

                if (i == 0)
                {
                    dataGridView1.RowsDefaultCellStyle.SelectionBackColor = dataGridView1.Rows[i].DefaultCellStyle.BackColor;
                    dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.White;
                }
            }
        }
        #endregion

        private string getDeliOrderNo()
        {
            string sql = @"SELECT UF_DeliOrderNoGenerator()";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
    }
}
