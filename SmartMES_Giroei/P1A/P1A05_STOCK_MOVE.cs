using SmartFactory;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1A05_STOCK_MOVE : SmartMES_Giroei.FormBasic
    {
        public P1A05_STOCK_MOVE()
        {
            InitializeComponent();
        }
        private void P1A05_STOCK_MOVE_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-01-01"));

            string sql = @"select co_code, co_item from BAS_common where co_kind = 'B' order by co_code";
            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            DataTable table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbDepot.DataSource = table;
                cbDepot.ValueMember = "co_code";
                cbDepot.DisplayMember = "co_item";
            }
            cbGubun.SelectedIndex = 0;
        }

        public async void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sFrom = dtpFromDate.Value.ToString("yyyy-MM-dd");
                string sTo = dtpToDate.Value.ToString("yyyy-MM-dd");
                string sDepot = "0001";
                //if (string.IsNullOrEmpty(cbDepot.SelectedValue.ToString())) sDepot = "0001";
                //else sDepot = cbDepot.SelectedValue.ToString(); //string sDepot = cbDepot.SelectedValue.ToString();
                string sGubun = cbGubun.Text.Substring(0, 1);
                if (cbGubun.Text == "제품") sGubun = "P";
                else if(cbGubun.Text == "원자재") sGubun = "M";
                else if(cbGubun.Text == "부자재") sGubun = "S";

                sP_StockMove_QueryTableAdapter.Fill(dataSetP1A.SP_StockMove_Query, G.Pos, DateTime.Parse(sFrom), DateTime.Parse(sTo), sDepot, sGubun);

                var data = dataSetP1A.SP_StockMove_Query;
                var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

                dataGridView1.CurrentCell = null;
                dataGridView1.ClearSelection();
            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #region Button Events
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void pbAdd_Click(object sender, EventArgs e)
        {
            P1A05_STOCK_MOVE_SUB sub = new P1A05_STOCK_MOVE_SUB();
            sub.lblTitle.Text = sub.lblTitle.Text + "[추가]";
            sub.parentWin = this;
            sub.ShowDialog();
        }
        private async void pbDel_Click(object sender, EventArgs e)
        {
            int index = 0;
            string sID = string.Empty;
            string sDate = string.Empty;
            string sProdName = string.Empty;

            try
            {
                index = dataGridView1.CurrentRow.Index;
                sID = dataGridView1.Rows[index].Cells[0].Value.ToString();
                sDate = DateTime.Parse(dataGridView1.Rows[index].Cells[1].Value.ToString()).ToString("yyyy-MM-dd");
                sProdName = dataGridView1.Rows[index].Cells[5].Value.ToString();

                if (dataGridView1.Rows[index].Selected != true)
                {
                    MessageBox.Show("삭제 정보가 선택되지 않았습니다.", this.lblTitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("삭제 정보가 선택되지 않았습니다.", this.lblTitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DialogResult dr = MessageBox.Show(sDate + "\r" + sProdName + "\r\r해당 정보를 삭제하시겠습니까?", this.lblTitle.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.No) return;

            MariaCRUD m = new MariaCRUD();
            string sql = "delete from tb_stock_move where move_id = " + sID;
            string msg = string.Empty;
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                MessageBox.Show(msg);
                return;
            }

            m.TransLogCreate(G.Authority, G.UserID, "D", this.Name, lblTitle.Text, sDate + " " + sProdName);

            var data = sql;
            var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.삭제, data);

            ListSearch();
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

        #region Condition Bar Events
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListSearch();
        }
        #endregion

        #region GridView Events
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int rowIndex = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible);
            if (rowIndex <= 0) return;

            dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(93, 123, 157);
            dataGridView1.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(93, 123, 157);
            dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.White;

            dataGridView1[1, rowIndex].Value = rowIndex.ToString() + "건";

            try
            {
                long iSum1 = 0, iSum2 = 0, iSum3 = 0, iSum4 = 0;
                DataGridViewButtonCell buttonCell;

                for (int i = 0; i < rowIndex; i++)
                {
                    iSum1 += long.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString());
                }

                dataGridView1[9, rowIndex].Value = iSum1;
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (G.Authority == "D") return;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 5) return;

            P1A05_STOCK_MOVE_SUB sub = new P1A05_STOCK_MOVE_SUB();
            sub.lblTitle.Text = sub.lblTitle.Text + "[수정]";
            sub.parentWin = this;
            sub.ShowDialog();
        }
        #endregion
    }
}
