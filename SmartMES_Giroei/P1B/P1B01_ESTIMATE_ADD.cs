using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B01_ESTIMATE_ADD : Form
    {
        public P1B01_ESTIMATE parentWin;
        public int parentRow;

        int columnIndex = 0;
        int rowIndex = 0;
        bool endEdit = false;

        public P1B01_ESTIMATE_ADD()
        {
            InitializeComponent();
        }

        private void P1B01_ESTIMATE_ADD_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            this.ActiveControl = dataGridView1;
        }

        public void ListSearch4()
        {
            lblMsg.Text = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int iCnt = 0;
                long lSum = 0;
                string sMoney;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[2].Value != null) iCnt++;

                    if (dataGridView1.Rows[i].Cells[6].Value == null ||
                        string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[6].Value.ToString()))
                        sMoney = "0";
                    else
                        sMoney = dataGridView1.Rows[i].Cells[6].Value.ToString();

                    lSum += long.Parse(sMoney);
                }

                lblSumMoney.Text = "합계금액 : " + lSum.ToString("#,##0") + "원";
                lblCnt.Text = iCnt.ToString() + "건";
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

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;

                    if (columnIndex == 12)
                        dataGridView1.CurrentCell = dataGridView1[4, rowIndex + 1];
                    else
                        dataGridView1.CurrentCell = dataGridView1[columnIndex + 1, rowIndex];
                }
                if (e.KeyCode == Keys.Tab)
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                columnIndex = dataGridView1.CurrentCell.ColumnIndex;
                rowIndex = dataGridView1.CurrentCell.RowIndex;
                endEdit = true;

                int money1 = 0;
                int money2 = 0;
                int money3 = 0;

                if (columnIndex == 7 || columnIndex == 8 || columnIndex == 9)
                {
                    if (dataGridView1.Rows[rowIndex].Cells[7].Value != null &&
                        dataGridView1.Rows[rowIndex].Cells[7].Value.ToString().Length != 0)
                        money1 = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[7].Value.ToString());

                    if (dataGridView1.Rows[rowIndex].Cells[8].Value != null &&
                        dataGridView1.Rows[rowIndex].Cells[8].Value.ToString().Length != 0)
                        money2 = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[8].Value.ToString());

                    if (dataGridView1.Rows[rowIndex].Cells[9].Value != null &&
                        dataGridView1.Rows[rowIndex].Cells[9].Value.ToString().Length != 0)
                        money3 = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[9].Value.ToString());

                    dataGridView1.Rows[rowIndex].Cells[11].Value = money1 + money2 + money3;
                    ListSearch4();
                }
                else if (columnIndex == 10 || columnIndex == 11)
                {
                    if (dataGridView1.Rows[rowIndex].Cells[10].Value != null &&
                        dataGridView1.Rows[rowIndex].Cells[10].Value.ToString().Length != 0)
                        money1 = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[10].Value.ToString());

                    if (dataGridView1.Rows[rowIndex].Cells[11].Value != null &&
                        dataGridView1.Rows[rowIndex].Cells[11].Value.ToString().Length != 0)
                        money2 = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[11].Value.ToString());

                    dataGridView1.Rows[rowIndex].Cells[12].Value = money1 * money2;
                    ListSearch4();
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell != null && endEdit)
                {
                    if (columnIndex == 12)
                        dataGridView1.CurrentCell = dataGridView1[4, rowIndex + 1];
                    else
                        dataGridView1.CurrentCell = dataGridView1[columnIndex + 1, rowIndex];

                    endEdit = false;
                }
            }
            catch (Exception)
            {
                return;
            }

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblMsg.Text = "";
            if (G.Authority == "D") return;
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 3)
            {
                ProdFinder pop = new ProdFinder();
                pop.cbGubun.SelectedIndex = 1;
                pop._kind = "%";
                pop._stockFlag = "%";
                pop.FormSendEvent += new ProdFinder.FormSendDataHandler(ProdEventMethod);
                pop.ShowDialog();
            }
            else if (e.ColumnIndex == 17)
            {
                try
                {
                    //string sNo = parentWin.tbNo.Text;                    

                    //if (string.IsNullOrEmpty(sNo))
                    //{
                    dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                    return;
                    //}

                    //if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == null ||
                    //    string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()))
                    //{
                    //    dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                    //    return;
                    //}

                    //string sSeq = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                    //DialogResult dr = MessageBox.Show("해당 정보를 삭제하시겠습니까?", this.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    //if (dr == DialogResult.No) return;

                    //MariaCRUD m = new MariaCRUD();
                    //string sql = "delete from tb_estimate_sub where estimate_id = '" + sNo + "' and estimate_seq = " + sSeq;
                    //string msg = string.Empty;
                    //m.dbCUD(sql, ref msg);

                    //if (msg != "OK")
                    //{
                    //    MessageBox.Show(msg);
                    //    return;
                    //}

                    //dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                    //m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, this.Text, sNo + " " + sSeq);
                }
                catch (Exception)
                {
                    return;
                }
            }

            ListSearch4();
        }
        private void ProdEventMethod(object sender)
        {
            try
            {
                string sProd = sender.ToString();
                if (string.IsNullOrEmpty(sProd)) return;

                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                if (rowIndex < 0) return;

                dataGridView1.Rows[rowIndex].Cells[2].Value = sProd.Substring(0, 8);
                dataGridView1.Rows[rowIndex].Cells[4].Value = sProd.Substring(9, sProd.Length - 9);
                dataGridView1.CurrentCell = dataGridView1[5, rowIndex];
            }
            catch (Exception)
            {
                return;
            }
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridView1.RowCount < 2) return;

            long lQty = 0;
            long lDanga = 0;
            long lAmount = 0;

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    lQty = Convert.ToInt64(row.Cells[10].Value);
                    lDanga = Convert.ToInt64(row.Cells[11].Value);
                    lAmount = Convert.ToInt64(row.Cells[12].Value);

                    if ((lQty * lDanga) == lAmount)
                        row.Cells[12].Style.ForeColor = Color.Empty;
                    else
                        row.Cells[12].Style.ForeColor = Color.Red;
                }
                ListSearch4();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dataGridView1.CurrentCell = dataGridView1[4, 0];
            lblMsg.Text = "";


            int iBefore = Int32.Parse(parentWin.dataGridView1.Rows[parentRow].Cells[1].Value.ToString());
            int iAfter = 1000;
            if (parentWin.dataGridView1.Rows[parentRow + 1].Cells[1].Value != null &&
                !string.IsNullOrEmpty(parentWin.dataGridView1.Rows[parentRow + 1].Cells[1].Value.ToString()))
                iAfter = Int32.Parse(parentWin.dataGridView1.Rows[parentRow + 1].Cells[1].Value.ToString());
            int iFullCnt = 9;
            if ((iAfter - iBefore - 1) < 9) iFullCnt = iAfter - iBefore - 1;

            if (dataGridView1.Rows.Count > iFullCnt + 1)
            {
                lblMsg.Text = "최대 등록할 수 있는 품목수는 " + iFullCnt.ToString() + "개 입니다.";
                return;
            }

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            string sNo = parentWin.tbNo.Text;
            string sSeq = string.Empty;
            string sProdID = string.Empty;
            string sAddName = string.Empty;
            string sAddSize = string.Empty;
            string sCost1 = string.Empty;
            string sCost2 = string.Empty;
            string sCost3 = string.Empty;
            string sQty = string.Empty;
            string sDanga = string.Empty;
            string sAmount = string.Empty;
            string sRFlag = "0";
            //if (parentWin.cbRorderFlag.Checked) sRFlag = "1";

            int seq = iBefore;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if ((dataGridView1.Rows[i].Cells[5].Value == null ||
                    string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[5].Value.ToString())) &&
                    (dataGridView1.Rows[i].Cells[6].Value == null ||
                    string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[6].Value.ToString()))) continue;

                seq = seq + 1;
                sSeq = seq.ToString();
                if (dataGridView1.Rows[i].Cells[2].Value == null ||
                    string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[2].Value.ToString()))
                    sProdID = "A0000001";
                else
                    sProdID = dataGridView1.Rows[i].Cells[2].Value.ToString();

                sAddName = dataGridView1.Rows[i].Cells[5].Value.ToString().Trim();
                sAddSize = dataGridView1.Rows[i].Cells[6].Value.ToString().Trim();
                sCost1 = dataGridView1.Rows[i].Cells[7].Value.ToString().Trim();
                sCost2 = dataGridView1.Rows[i].Cells[8].Value.ToString().Trim();
                sCost3 = dataGridView1.Rows[i].Cells[9].Value.ToString().Trim();
                sQty = dataGridView1.Rows[i].Cells[10].Value.ToString().Trim();
                sDanga = dataGridView1.Rows[i].Cells[11].Value.ToString().Trim();
                sAmount = dataGridView1.Rows[i].Cells[12].Value.ToString().Trim();

                if (string.IsNullOrEmpty(sCost1)) sCost1 = "0";
                if (string.IsNullOrEmpty(sCost2)) sCost2 = "0";
                if (string.IsNullOrEmpty(sCost3)) sCost3 = "0";
                if (string.IsNullOrEmpty(sQty)) sQty = "0";
                if (string.IsNullOrEmpty(sDanga)) sDanga = "0";
                if (string.IsNullOrEmpty(sAmount)) sAmount = "0";

                sql = "insert into tb_estimate_sub (estimate_id, estimate_seq, prod_id, add_name, add_size, cost1, cost2, cost3, qty, danga, amount, rorder_flag) " +
                      "values('" + sNo + "'," + sSeq + ",'" + sProdID + "','" + sAddName + "','" + sAddSize + "'," + sCost1 + "," + sCost2 + ",'" + sCost3 + "'," + sQty + "," + sDanga + "," + sAmount + "," + sRFlag + ")";

                m.dbCUD(sql, ref msg);
            }

            parentWin.ListSearch3();
            parentWin.ListSearch4();
            this.DialogResult = DialogResult.OK;
            Cursor.Current = Cursors.Default;
        }
    }
}