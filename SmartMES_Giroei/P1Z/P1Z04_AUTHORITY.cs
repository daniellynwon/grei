using SmartFactory;
using System;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1Z04_AUTHORITY : SmartMES_Giroei.FormBasic
    {
        public P1Z04_AUTHORITY()
        {
            InitializeComponent();
        }
        private void P1Z04_AUTHORITY_Load(object sender, EventArgs e)
        {
            ListSearch();
            this.ActiveControl = tbSearch;
        }

        public void ListSearch()
        {
            lblMsg.Text = "";

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sSearch = tbSearch.Text.Trim();

                sP_User_QueryTableAdapter.Fill(dataSetP1Z.SP_User_Query, sSearch, "Y");

                var data1 = dataSetP1Z.SP_User_Query;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data1);

                dataGridView1.CurrentCell = null;
                dataGridView1.ClearSelection();

                lblID.Text = "";
                lblName.Text = "";

                sP_Menu_AuthorityTableAdapter.Fill(dataSetP1Z.SP_Menu_Authority, "", "");

                var data2 = dataSetP1Z.SP_Menu_Authority;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data2);
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
        public void MenuSearch(string lang, string id)
        {
            lblMsg.Text = "";

            try
            {
                sP_Menu_AuthorityTableAdapter.Fill(dataSetP1Z.SP_Menu_Authority, lang, id);

                var data = dataSetP1Z.SP_Menu_Authority;
                Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

                dataGridView2.CurrentCell = null;
                dataGridView2.ClearSelection();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        #region Button Events
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch();
        }
        private void pbAdd_Click(object sender, EventArgs e)
        {
            //
        }
        private void pbDel_Click(object sender, EventArgs e)
        {
            //
        }
        private void pbSave_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "잠시 기다려 주세요.";

            int rowCnt = dataGridView2.RowCount;
            string id = lblID.Text;

            if (rowCnt < 1) return;
            if (string.IsNullOrEmpty(id)) return;

            MariaCRUD m = new MariaCRUD();
            string sql = "delete from SYS_authority where user_id = '" + id + "'";
            string msg = string.Empty;
            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            var data = sql;
            Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.삭제, data);

            string menuID;

            for (int i = 0; i < rowCnt; i++)
            {
                if (dataGridView2.Rows[i].Cells[0].Value.ToString() == "O")
                {
                    menuID = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    sql = "insert into SYS_authority values ('" + id + "','KO','" + menuID + "')";
                    m.dbCUD(sql, ref msg);

                    data = sql;
                    Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);
                }
            }

            lblMsg.Text = "저장되었습니다.";
        }
        private void pbPrint_Click(object sender, EventArgs e)
        {
            //
        }
        #endregion

        #region Condition Bar Events
        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListSearch();
            }
        }
        #endregion

        #region GridView Events
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int index = dataGridView1.CurrentRow.Index;

            lblID.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            lblName.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();

            MenuSearch("KO", lblID.Text);
        }
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 0) return;

            string flag = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();

            if (flag == "O") dataGridView2.Rows[e.RowIndex].Cells[0].Value = "";
            else dataGridView2.Rows[e.RowIndex].Cells[0].Value = "O";
        }
        #endregion

        private void lblAll_Click(object sender, EventArgs e)
        {
            int rowCnt = dataGridView2.Rows.Count;
            if (rowCnt < 1) return;

            string flag = dataGridView2.Rows[0].Cells[0].Value.ToString();
            if (flag == "O") flag = "";
            else flag = "O";

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = flag;
            }
        }
    }
}
