using SmartFactory;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B10_PURCHASE_MAT1_SUB : Form
    {
        public P1B10_PURCHASE_MAT1 parentWin;

        public P1B10_PURCHASE_MAT1_SUB()
        {
            InitializeComponent();
        }
        private void P1B10_PURCHASE_MAT1_SUB_Load(object sender, EventArgs e)
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

                sP_PurchaseMat1_SubTableAdapter.Fill(dataSetP1B.SP_PurchaseMat1_Sub, sSearch);

                var data = dataSetP1B.SP_PurchaseMat1_Sub;
                Logger.ApiLog(G.UserID, "자재발주등록 SUB", ActionType.조회, data);

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

        private void btnROrder_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount < 1) return;

            int iCnt = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                    if (dataGridView1.Rows[i].Cells[6].Value != null && dataGridView1.Rows[i].Cells[6].Value.ToString() == "1")
                    {
                        iCnt++;
                    }
            }
            if (iCnt < 1)
            {
                MessageBox.Show("수주정보가 선택되지 않았습니다.");
                return;
            }
            prodDoneDelivery();
        }
        private void btnDeli_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.RowCount < 1) return;

            //int iCnt = 0;

            //for (int i = 0; i < dataGridView1.RowCount; i++)
            //{
            //    if (dataGridView1.Rows[i].Cells[5].Value != null && dataGridView1.Rows[i].Cells[5].Value.ToString() == "1")
            //    {
            //        iCnt++;
            //    }
            //}
            //if (iCnt < 1)
            //{
            //    MessageBox.Show("출하대상이 선택되지 않았습니다.");
            //    return;
            //}
            //prodDoneDelivery();
        }
        private void prodDoneDelivery()
        {
            int iSeq = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[6].Value != null && dataGridView1.Rows[i].Cells[6].Value.ToString() == "1")
                {
                    parentWin.tbROrderNo.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    
                    parentWin.sPPurchaseMatSubQueryBindingSource.AddNew();
                    parentWin.dataGridView1.Rows[iSeq].Cells[3].Value = dataGridView1.Rows[i].Cells[4].Value; //품목코드
                    parentWin.dataGridView1.Rows[iSeq].Cells[4].Value = dataGridView1.Rows[i].Cells[5].Value; //품목명
                    iSeq++;
                }
            }
            
            this.Dispose();
        }

        #region GridView Events
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString() == "Y")
            {
                MessageBox.Show("수주취소건은 자재발주등록이 불가능합니다.");
                return;
            }
                int CheckFlag = 1;
                int DataCount = 0;

                if (e.RowIndex < 0) return;
                if (e.ColumnIndex != 0) return;

                string sROrderNo, sModelName;

                if (e.ColumnIndex == 0)
                {
                    sROrderNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    sModelName = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

                    parentWin.tbROrderNo.Text = sROrderNo;
                    parentWin.tbModelName.Text = sModelName;

                    this.Dispose();
                }

            //if (e.ColumnIndex == 0)
            //{
            //    sROrderNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            //    //for (int i = 0; i < dataGridView1.RowCount; i++)
            //    //{
            //    //    if (sROrderNo == dataGridView1.Rows[i].Cells[0].Value.ToString())
            //    //    {
            //    //        dataGridView1.Rows[i].Cells[6].Value = 1;
            //    //    }
            //    //}

            //    for (int i = 0; i < dataGridView1.RowCount; i++)
            //    {
            //        if (sROrderNo == dataGridView1.Rows[i].Cells[0].Value.ToString())
            //        {
            //            if (dataGridView1.Rows[i].Cells[6].Value != null)
            //            {
            //                CheckFlag = CheckFlag * Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value.ToString());
            //                DataCount++;
            //            }
            //        }
            //    }

            //    if (CheckFlag == 1)
            //    {
            //        for (int i = 0; i < dataGridView1.RowCount; i++)
            //        {
            //            if (sROrderNo == dataGridView1.Rows[i].Cells[0].Value.ToString())
            //            {
            //                if (dataGridView1.Rows[i].Cells[6].Value == null)
            //                    dataGridView1.Rows[i].Cells[6].Value = 1;
            //                else
            //                    dataGridView1.Rows[i].Cells[6].Value = 0;
            //            }
            //        }
            //    }
            //    else if (CheckFlag == 0)
            //    {
            //        for (int i = 0; i < dataGridView1.RowCount; i++)
            //        {
            //            if (sROrderNo == dataGridView1.Rows[i].Cells[0].Value.ToString())
            //            {
            //                if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "0") DataCount--;
            //            }
            //        }

            //        if (DataCount > 0)
            //        {
            //            for (int i = 0; i < dataGridView1.RowCount; i++)
            //            {
            //                if (sROrderNo == dataGridView1.Rows[i].Cells[0].Value.ToString())
            //                {
            //                    dataGridView1.Rows[i].Cells[6].Value = 0;
            //                }
            //            }
            //        }
            //        else if (DataCount == 0)
            //        {
            //            for (int i = 0; i < dataGridView1.RowCount; i++)
            //            {
            //                if (sROrderNo == dataGridView1.Rows[i].Cells[0].Value.ToString())
            //                {
            //                    dataGridView1.Rows[i].Cells[6].Value = 1;
            //                }
            //            }
            //        }
            //    }
            //}
            //else if (e.ColumnIndex == 6)
            //{
            //    sROrderNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            //    if (dataGridView1.Rows[e.RowIndex].Cells[6].Value == null) return;
            //    else
            //    {
            //        if (dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString() == "1")
            //            dataGridView1.Rows[e.RowIndex].Cells[6].Value = 0;
            //        else if (dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString() == "0")
            //            dataGridView1.Rows[e.RowIndex].Cells[6].Value = 1;
            //    }

            //    //for (int i = 0; i < dataGridView1.RowCount; i++)
            //    //{
            //    //    if (sSujuNo == dataGridView1.Rows[i].Cells[0].Value.ToString())
            //    //    {
            //    //        if (dataGridView1.Rows[i].Cells[5].Value == null)
            //    //            dataGridView1.Rows[i].Cells[5].Value = 1;
            //    //        else
            //    //        {
            //    //            if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "1")
            //    //                dataGridView1.Rows[i].Cells[5].Value = 0;
            //    //            else if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "0")
            //    //                dataGridView1.Rows[i].Cells[5].Value = 1;
            //    //        }
            //    //    }
            //    //}

            //    //for (int i = 0; i < dataGridView1.RowCount; i++)
            //    //{
            //    //    if (sSujuNo == dataGridView1.Rows[i].Cells[0].Value.ToString())
            //    //        dataGridView1.Rows[i].Cells[5].Value = 1;
            //    //    else
            //    //        dataGridView1.Rows[i].Cells[5].Value = 0;
            //    //}

            //}
            //this.Dispose();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridView1.RowCount < 2) return;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[10].Value.ToString() == "Y") //특정값이면 배경색 바꿔주기 여기서는 수주취소 Y OR N로 판단하여 배경색 바꿈
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
