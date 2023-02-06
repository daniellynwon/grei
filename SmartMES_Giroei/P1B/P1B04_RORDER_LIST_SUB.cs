using SmartFactory;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B04_RORDER_LIST_SUB : Form
    {
        public P1B04_RORDER_LIST parentWin;

        public int rowIndex;
        public string sSujuNo = string.Empty;

        public P1B04_RORDER_LIST_SUB()
        {
            InitializeComponent();
        }
        private void P1B04_RORDER_LIST_SUB_Load(object sender, EventArgs e)
        {
            lbSujuNo.Text = "수주번호 : " + sSujuNo;
            //lbProd.Text = "";

            tbCust.Tag = parentWin.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            tbCust.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();

            tbROrderDate.Text = Convert.ToDateTime(parentWin.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString()).ToString("yyyy-MM-dd");
            tbDeliDate.Text = Convert.ToDateTime(parentWin.dataGridView1.Rows[rowIndex].Cells[15].Value.ToString()).ToString("yyyy-MM-dd");

            ListSearch();
        }
        public async void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                sP_ROrderList_Sub1TableAdapter.Fill(dataSetP1B.SP_ROrderList_Sub1, sSujuNo);

                var data = dataSetP1B.SP_ROrderList_Sub1;
                var result = await Logger.ApiLog(G.UserID, "수주별 품목정보", ActionType.조회, data);

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

        #region GridView Events
        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 7) return;

            tbProdName.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

            string sProdID = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                sP_ROrderList_Sub2TableAdapter.Fill(dataSetP1B.SP_ROrderList_Sub2, sSujuNo, sProdID);

                var data = dataSetP1B.SP_ROrderList_Sub2;
                var result = await Logger.ApiLog(G.UserID, "수주별 품목정보의 BOM 및 재고정보", ActionType.조회, data);

                dataGridView2.CurrentCell = null;
                dataGridView2.ClearSelection();
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
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridView1.RowCount == 0) return;
        }
        #endregion
    }
}
