using SmartFactory;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1C02_PROD_RESULT_ORDER : Form
    {
        public P1C02_PROD_RESULT parentWin;
        public DateTime dtDate;

        public P1C02_PROD_RESULT_ORDER()
        {
            InitializeComponent();
        }
        private void P1C02_PROD_RESULT_ORDER_Load(object sender, EventArgs e)
        {
            ListSearch();
            this.ActiveControl = dataGridView1;
        }
        public void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                sP_ProdResult_OrderTableAdapter.Fill(dataSetP1C.SP_ProdResult_Order, dtDate);

                var data = dataSetP1C.SP_ProdResult_Order;
                Logger.ApiLog(G.UserID, "작업지시목록", ActionType.조회, data);

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
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 0) return;

            parentWin.tbJobNo.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            parentWin.lblLotNo.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            parentWin.dtpDate.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            parentWin.tbContents.Text = dataGridView1.Rows[e.RowIndex].Cells[20].Value.ToString();
            parentWin.tbProd.Tag = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            parentWin.tbProd.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            parentWin.tbQty.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

            parentWin.timer1.Stop();
            parentWin.timer2.Stop();
            parentWin.btnStart.Tag = null;
            parentWin.btnFinish.Tag = null;
            parentWin.tbStartTime.Text = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString()).ToString("HH:mm:ss");
            parentWin.tbFinishTime.Text = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString()).ToString("HH:mm:ss");

            //parentWin.sP_ProdResult_IdleTableAdapter.Fill(parentWin.dataSetP1C.SP_ProdResult_Idle, DateTime.Parse("1900-01-01"));

            parentWin.dataGridView1.CurrentCell = null;
            parentWin.dataGridView1.ClearSelection();
            parentWin.lblMsg.Text = "작업시작 할 수 있습니다.";

            this.Dispose();
        }
        #endregion
    }
}
