using SmartFactory;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B16_ITEM_BOX_SUB2 : Form
    {
        public P1B16_ITEM_BOX parentWin;
        public P1B16_ITEM_BOX_INPUT parentWin1;

        string sOrderID = string.Empty;
        string sOrderSeq = string.Empty;
        string sProdID = string.Empty;
        string sProdName = string.Empty;
        int qty = 0;

        public P1B16_ITEM_BOX_SUB2()
        {
            InitializeComponent();
        }
        private void P1B16_ITEM_BOX_SUB2_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            ListSearch();
        }
        public void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                sP_Item_Box_NewTableAdapter.Fill(dataSetP1B.SP_Item_Box_New);

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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sOrderID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            sOrderSeq = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            sProdID = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            sProdName = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            qty = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);

            lblMsg.Text = "";
        }
        #endregion

        private void btItemBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(sOrderID))
                {
                    lblMsg.Text = "선택된 수주정보가 없습니다. ";
                    return;
                }

                MariaCRUD m = new MariaCRUD();
                DataTable table;

                string sql = string.Empty;
                string msg = string.Empty;

                sql = $@"SELECT COUNT(parent_id) FROM BOM_bomlist WHERE prod_id = '{@sProdID}'";
                table = m.dbDataTable(sql, ref msg);

                if (Convert.ToInt64(table.Rows[0][0]) == 0)
                {
                    MessageBox.Show($@"{@sProdName}의 BOM이 등록되어 있지 않습니다. BOM 먼저 등록해 주세요.");
                    return;
                }

                sql = $@"INSERT INTO Item_box_main (order_id, order_seq, prod_id) VALUES ('{@sOrderID}', '{@sOrderSeq}', '{@sProdID}');";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = "현품박스 생성에 실패했습니다.";
                    return;
                }

                sql = $@"SELECT box_id FROM Item_box_main ORDER BY  box_id DESC LIMIT 1";
                string sBoxID = m.dbDataTable(sql, ref msg).Rows[0][0].ToString();

                sql = $@"SELECT prod_id, parent_id, req_qty FROM BOM_bomlist WHERE prod_id = '{@sProdID}'";
                table = m.dbDataTable(sql, ref msg);

                sql = "INSERT INTO Item_box_sub (box_id, prod_id, prod_id_sub, input_date, total_count) VALUES ";

                for (int i = 0; i < table.Rows.Count - 1; i++)
                {
                    sql = sql + $@"({@sBoxID}, '{@table.Rows[i][0].ToString()}', '{@table.Rows[i][1].ToString()}','{@DateTime.Now.ToString("yyyy-MM-dd")}',{@qty * @Convert.ToInt64(table.Rows[i][2])}),";
                }

                sql = sql + $@"({@sBoxID}, '{@table.Rows[table.Rows.Count - 1][0].ToString()}', '{@table.Rows[table.Rows.Count - 1][1].ToString()}','{@DateTime.Now.ToString("yyyy-MM-dd")}', {@qty * @Convert.ToInt64(table.Rows[table.Rows.Count - 1][2])})";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = "현품박스 생성에 실패했습니다.";
                    return;
                }

                parentWin.ListSearch();

                for (int i = 0; i < parentWin.dataGridView1.Rows.Count; i++)
                {
                    if (parentWin.dataGridView1.Rows[i].Cells[1].Value.ToString() == sOrderID && parentWin.dataGridView1.Rows[i].Cells[2].Value.ToString() == sOrderSeq)
                    {
                        parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[0, i];
                        parentWin.dataGridView1.CurrentCell.Selected = true;
                        break;
                    }
                }

                this.DialogResult = DialogResult.OK;
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
    }
}
