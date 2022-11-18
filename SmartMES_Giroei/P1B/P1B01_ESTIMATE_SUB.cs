using SmartFactory;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B01_ESTIMATE_SUB : Form
    {
        public P1B01_ESTIMATE parentWin;

        public int rowIndex;
        public string sSujuNo = string.Empty;

        public P1B01_ESTIMATE_SUB()
        {
            InitializeComponent();
        }
        private async void P1B01_ESTIMATE_SUB_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'dataSetP1B.SP_ROrderToEstimate_Query' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.sP_ROrderToEstimate_QueryTableAdapter.Fill(this.dataSetP1B.SP_ROrderToEstimate_Query);

            var data = this.dataSetP1B.SP_ROrderToEstimate_Query;
            var result = await Logger.ApiLog(G.UserID, "수주내역", ActionType.조회, data);

            ListSearch();
        }
        public async void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                sP_ROrderToEstimate_QueryTableAdapter.Fill(dataSetP1B.SP_ROrderToEstimate_Query);

                var data = dataSetP1B.SP_ROrderToEstimate_Query;
                var result = await Logger.ApiLog(G.UserID, "수주내역", ActionType.조회, data);

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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int iSeq = 0;
            string sSujuNo = string.Empty;

            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 0)
            {
                sSujuNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                parentWin.tbRorder.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                parentWin.tbCustName.Tag = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                parentWin.tbCustName.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                parentWin.tbProject.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                parentWin.tbAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                parentWin.tbCustMan.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                parentWin.tbManHp.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                parentWin.tbEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == sSujuNo)
                    {
                        parentWin.sPEstimateSubQueryBindingSource.AddNew();

                        parentWin.dataGridView1.Rows[iSeq].Cells[2].Value = dataGridView1.Rows[i].Cells[10].Value;
                        parentWin.dataGridView1.Rows[iSeq].Cells[4].Value = dataGridView1.Rows[i].Cells[11].Value;
                        parentWin.dataGridView1.Rows[iSeq].Cells[5].Value = dataGridView1.Rows[i].Cells[12].Value;
                        parentWin.dataGridView1.Rows[iSeq].Cells[11].Value = dataGridView1.Rows[i].Cells[14].Value;
                        parentWin.dataGridView1.Rows[iSeq].Cells[12].Value = dataGridView1.Rows[i].Cells[15].Value;
                        parentWin.dataGridView1.Rows[iSeq].Cells[13].Value = dataGridView1.Rows[i].Cells[16].Value;
                        parentWin.dataGridView1.Rows[iSeq].Cells[14].Value = dataGridView1.Rows[i].Cells[17].Value;

                        iSeq++;
                    }
                }

                this.Dispose();
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
