using SmartFactory;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B03_RORDER_SUB : Form
    {
        public P1B03_RORDER parentWin;

        public P1B03_RORDER_SUB()
        {
            InitializeComponent();
        }

        private void P1B03_RORDER_SUB_Load(object sender, EventArgs e)
        {
            ListSearch();
            this.ActiveControl = tbSearch;
        }
        public async void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                sP_ROrder_EstTableAdapter.Fill(dataSetP1B.SP_ROrder_Est, "");

                var data = dataSetP1B.SP_ROrder_Est;
                var result = await Logger.ApiLog(G.UserID, "견적조회", ActionType.조회, data);

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

        private void btnDeli_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount < 1) return;

            int iCnt = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[8].Value != null && dataGridView1.Rows[i].Cells[8].Value.ToString() == "1")
                {
                    iCnt++;
                }
            }
            if (iCnt < 1)
            {
                MessageBox.Show("수주대상이 선택되지 않았습니다.");
                return;
            }
            estimateDelivery();
        }
        private void estimateDelivery()
        {
            long lMoney = 0;
            int iSeq = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[8].Value != null && dataGridView1.Rows[i].Cells[8].Value.ToString() == "1")
                {
                    parentWin.sPROrderSubQueryBindingSource.AddNew();
                    parentWin.tbCust.Tag = dataGridView1.Rows[i].Cells[2].Value.ToString();   // 거래처ID
                    parentWin.tbCust.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();   // 거래처명
                    parentWin.tbContents.Text = dataGridView1.Rows[i].Cells[17].Value.ToString();   // 비고
                    parentWin.tbEstiNo.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();   // 견적번호

                    parentWin.dataGridView1.Rows[iSeq].Cells[20].Value = dataGridView1.Rows[i].Cells[19].Value; //estimate_seq
                    parentWin.dataGridView1.Rows[iSeq].Cells[2].Value = dataGridView1.Rows[i].Cells[9].Value; //품목코드
                    parentWin.dataGridView1.Rows[iSeq].Cells[4].Value = dataGridView1.Rows[i].Cells[11].Value; ; //품목명
                    parentWin.dataGridView1.Rows[iSeq].Cells[5].Value = dataGridView1.Rows[i].Cells[20].Value; //공정코드
                    parentWin.dataGridView1.Rows[iSeq].Cells[8].Value = dataGridView1.Rows[i].Cells[21].Value; //적용점수
                    //parentWin.dataGridView1.Rows[iSeq].Cells[9].Value = dataGridView1.Rows[i].Cells[8].Value; //M/M
                    //parentWin.dataGridView1.Rows[iSeq].Cells[10].Value = dataGridView1.Rows[i].Cells[8].Value; //부품수
                    parentWin.dataGridView1.Rows[iSeq].Cells[13].Value = dataGridView1.Rows[i].Cells[12].Value; //수량
                    parentWin.dataGridView1.Rows[iSeq].Cells[14].Value = dataGridView1.Rows[i].Cells[13].Value; //기준단가
                    parentWin.dataGridView1.Rows[iSeq].Cells[15].Value = dataGridView1.Rows[i].Cells[15].Value; //금액
                    //parentWin.dataGridView1.Rows[iSeq].Cells[9].Value = "양면";

                    iSeq++;
                }
            }
            this.Dispose();
        }

        #region GridView Events
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            //if (e.ColumnIndex != 4) return;

            parentWin.ListInit();

            string sNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //for (int i = 0; i < dataGridView1.RowCount; i++)
            //{
            //    if (sNo == dataGridView1.Rows[i].Cells[0].Value.ToString())
            //        dataGridView1.Rows[i].Cells[8].Value = 1;
            //    else
            //        dataGridView1.Rows[i].Cells[8].Value = 0;
            //}

            if (e.ColumnIndex == 4)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (sNo == dataGridView1.Rows[i].Cells[0].Value.ToString())
                    {
                        if (dataGridView1.Rows[i].Cells[8].Value == null)
                            dataGridView1.Rows[i].Cells[8].Value = 1;
                        else
                        {
                            if (dataGridView1.Rows[i].Cells[8].Value.ToString() == "1")
                                dataGridView1.Rows[i].Cells[8].Value = 0;
                            else if (dataGridView1.Rows[i].Cells[8].Value.ToString() == "0")
                                dataGridView1.Rows[i].Cells[8].Value = 1;
                        }
                    }
                }
            }
            else if (e.ColumnIndex == 8)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[8].Value == null) return;
                else
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString() == "1")
                        dataGridView1.Rows[e.RowIndex].Cells[8].Value = 0;
                    else if (dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString() == "0")
                        dataGridView1.Rows[e.RowIndex].Cells[8].Value = 1;
                }
            }

            //estimateDelivery(sNo);
            //this.Dispose();
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
