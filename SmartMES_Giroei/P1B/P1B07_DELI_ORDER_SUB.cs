﻿using SmartFactory;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B07_DELI_ORDER_SUB : Form
    {
        public P1B07_DELI_ORDER parentWin;

        public P1B07_DELI_ORDER_SUB()
        {
            InitializeComponent();
        }
        private void P1B07_DELI_ORDER_SUB_Load(object sender, EventArgs e)
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

                sP_DeliOrder_ROrderTableAdapter.Fill(dataSetP1B.SP_DeliOrder_ROrder, sSearch);

                var data = dataSetP1B.SP_DeliOrder_ROrder;
                Logger.ApiLog(G.UserID, "출고요청목록", ActionType.조회, data);

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
        
        private void btnDeli_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount < 1) return;

            int iCnt = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[5].Value != null && dataGridView1.Rows[i].Cells[5].Value.ToString() == "1")
                {
                    iCnt++;
                }
            }
            if (iCnt < 1)
            {
                MessageBox.Show("출하대상이 선택되지 않았습니다.");
                return;
            }
            prodDoneDelivery();
        }
        private void prodDoneDelivery()
        {
            string DeliOrderNo = getDeliOrderNo();

            long lMoney = 0;
            int iSeq = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[5].Value != null && dataGridView1.Rows[i].Cells[5].Value.ToString() == "1")
                {
                    parentWin.tbCust.Tag = dataGridView1.Rows[i].Cells[1].Value;
                    parentWin.tbCust.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    parentWin.tbRorder.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    parentWin.tbRorder.Tag = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    //parentWin.tbPlace.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    parentWin.tbContents.Text = dataGridView1.Rows[i].Cells[14].Value.ToString();

                    parentWin.sPDeliorderSubQueryBindingSource.AddNew();
                    //parentWin.dataGridView1.Rows[iSeq].Cells[1].Value = dataGridView1.Rows[i].Cells[].Value; //지시번호
                    parentWin.dataGridView1.Rows[iSeq].Cells[0].Value = DeliOrderNo; //임시지시번호
                    //parentWin.dataGridView1.Rows[iSeq].Cells[2].Value = iSeq + 1; //지시순번
                    parentWin.dataGridView1.Rows[iSeq].Cells[2].Value = dataGridView1.Rows[i].Cells[7].Value; //품목코드
                    parentWin.dataGridView1.Rows[iSeq].Cells[3].Value = dataGridView1.Rows[i].Cells[8].Value; //품목명
                    parentWin.dataGridView1.Rows[iSeq].Cells[4].Value = dataGridView1.Rows[i].Cells[9].Value; //수량
                    parentWin.dataGridView1.Rows[iSeq].Cells[5].Value = dataGridView1.Rows[i].Cells[10].Value; //단가
                    parentWin.dataGridView1.Rows[iSeq].Cells[6].Value = dataGridView1.Rows[i].Cells[11].Value; //금액
                    parentWin.dataGridView1.Rows[iSeq].Cells[7].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[11].Value.ToString()) * 0.1; //부가세
                    parentWin.dataGridView1.Rows[iSeq].Cells[8].Value
                        = Convert.ToDouble(parentWin.dataGridView1.Rows[iSeq].Cells[6].Value.ToString()) + Convert.ToDouble(parentWin.dataGridView1.Rows[iSeq].Cells[7].Value.ToString()); //합계금액
                    //parentWin.dataGridView1.Rows[iSeq].Cells[10].Value = dataGridView1.Rows[i].Cells[12].Value; //비고
                    //parentWin.dataGridView1.Rows[iSeq].Cells[2].Value = dataGridView1.Rows[i].Cells[8].Value; //품목코드
                    //parentWin.dataGridView1.Rows[iSeq].Cells[3].Value = dataGridView1.Rows[i].Cells[9].Value; //품목명
                    //parentWin.dataGridView1.Rows[iSeq].Cells[4].Value = dataGridView1.Rows[i].Cells[11].Value; //규격
                    //parentWin.dataGridView1.Rows[iSeq].Cells[5].Value = dataGridView1.Rows[i].Cells[12].Value; //단위
                    //parentWin.dataGridView1.Rows[iSeq].Cells[6].Value = dataGridView1.Rows[i].Cells[13].Value; //수량
                    //parentWin.dataGridView1.Rows[iSeq].Cells[9].Value = dataGridView1.Rows[i].Cells[16].Value; //비고

                    //parentWin.dataGridView1.Rows[iSeq].Cells[7].Value = dataGridView1.Rows[i].Cells[0].Value; //수주번호
                    parentWin.dataGridView1.Rows[iSeq].Cells[1].Value = dataGridView1.Rows[i].Cells[6].Value; //수주순번
                    iSeq++;
                }
            }
            this.Dispose();
        }

        #region GridView Events
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            //if (e.ColumnIndex != 5) return;

            string sSujuNo;

            if (e.ColumnIndex == 2)
            {
                sSujuNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (sSujuNo == dataGridView1.Rows[i].Cells[0].Value.ToString())
                    {
                        if (dataGridView1.Rows[i].Cells[5].Value == null)
                            dataGridView1.Rows[i].Cells[5].Value = 1;
                        else
                        {
                            if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "1")
                                dataGridView1.Rows[i].Cells[5].Value = 0;
                            else if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "0")
                                dataGridView1.Rows[i].Cells[5].Value = 1;
                        }
                    }
                }
            }
            else if (e.ColumnIndex == 5)
            {
                sSujuNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (dataGridView1.Rows[e.RowIndex].Cells[5].Value == null) return;
                else
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "1")
                        dataGridView1.Rows[e.RowIndex].Cells[5].Value = 0;
                    else if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "0")
                        dataGridView1.Rows[e.RowIndex].Cells[5].Value = 1;
                }

                //for (int i = 0; i < dataGridView1.RowCount; i++)
                //{
                //    if (sSujuNo == dataGridView1.Rows[i].Cells[0].Value.ToString())
                //    {
                //        if (dataGridView1.Rows[i].Cells[5].Value == null)
                //            dataGridView1.Rows[i].Cells[5].Value = 1;
                //        else
                //        {
                //            if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "1")
                //                dataGridView1.Rows[i].Cells[5].Value = 0;
                //            else if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "0")
                //                dataGridView1.Rows[i].Cells[5].Value = 1;
                //        }
                //    }
                //}

                //for (int i = 0; i < dataGridView1.RowCount; i++)
                //{
                //    if (sSujuNo == dataGridView1.Rows[i].Cells[0].Value.ToString())
                //        dataGridView1.Rows[i].Cells[5].Value = 1;
                //    else
                //        dataGridView1.Rows[i].Cells[5].Value = 0;
                //}


            }
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

        private string getDeliOrderNo()
        {
            string sql = @"SELECT UF_DeliOrderNoGenerator()";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
    }
}
