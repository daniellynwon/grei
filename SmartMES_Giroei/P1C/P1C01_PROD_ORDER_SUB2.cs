using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1C01_PROD_ORDER_SUB2 : Form
    {
        internal P1C01_PROD_ORDER_SUB parentWin;
        static public string rid;
        static public string rseq;
        int rowIndex = -1;

        public P1C01_PROD_ORDER_SUB2(string v, string seq, string sBigo)
        {

            InitializeComponent();

            this.tbBigo.Text = "";
            rid = v;
            rseq = seq;
            dataGridViewA.CurrentCell = null;
            search();
            timer1.Enabled = true;
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            //MariaCRUD m = new MariaCRUD();
            //string sql = "update tb_rorder_sub set bigo = '" + tbBigo.Text + "' where rorder_id = '" + rid  + "' " + "AND rorder_seq = " + rseq;
            //string msg = string.Empty;
            //m.dbCUD(sql, ref msg);

            //if (msg != "OK")
            //{
            //    MessageBox.Show(msg);
            //    return;
            //}
            timer1.Enabled = false;
            this.Dispose();
        }
        private void search()
        {
            sP_Job_CommentTableAdapter.Fill(dataSetP1C.SP_Job_Comment, rid, Convert.ToInt32(rseq));
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();
            int aseq = 0;

            if (tbBigo.Tag == null)
            {
                sql = "SELECT IFNULL(MAX(a_seq),0) FROM tb_rorder_sub1 WHERE rorder_id = '" + rid + "' and rorder_seq = '" + rseq + "' ORDER BY a_seq DESC LIMIT 1";

                try
                {
                    string saseq = m.dbRonlyOne(sql, ref msg).ToString();
                    aseq = Convert.ToInt32(saseq) + 1;
                }
                catch (NullReferenceException)
                {
                    aseq = 1;
                }

                sql = "INSERT INTO tb_rorder_sub1 (rorder_id, rorder_seq, a_seq, comments, enter_man)" +
                    " VALUES ('" + rid + "', '" + rseq + "', '" + aseq.ToString() + "','" + this.tbBigo.Text.ToString() + "','" + G.UserID.ToString() + "')";

            } else
            {
                if (dataGridViewA.Rows[rowIndex].Cells[3].Value.ToString() != G.UserID.ToString())
                {
                    MessageBox.Show("작성자가 상이하여 수정할수 없습니다.");
                    return;
                }
                sql = "Update tb_rorder_sub1 SET comments = '" + this.tbBigo.Text.ToString() + "' where rorder_id = '" + rid + "' and rorder_seq ='" + rseq + "' and a_seq ='" + tbBigo.Tag.ToString() + "'";
            }
            m.dbCUD(sql, ref msg);

            this.tbBigo.Text = "";
            search();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //sP_job3_sub2TableAdapter.Fill(dataSetP1C_Job.SP_job3_sub2, rid, Convert.ToInt32(rseq));
            try
            {
                foreach (DataGridViewRow row in dataGridViewA.Rows)
                {
                    if (tbBigo.Tag != null)
                    {
                        if (Convert.ToString(row.Cells[0].Value) == tbBigo.Tag.ToString())
                        {
                            rowIndex = int.Parse(row.Index.ToString());
                            dataGridViewA.CurrentCell = dataGridViewA[2, rowIndex];
                            dataGridViewA.CurrentCell.Selected = true;
                        }
                    }
                }
            } catch(Exception)
            {
                return;
            }
        }
        private void dataGridViewA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            rowIndex = dataGridViewA.CurrentCell.RowIndex;
            if (e.ColumnIndex == 5)
            {
                if (dataGridViewA.Rows[rowIndex].Cells[3].Value.ToString() != G.UserID.ToString())
                {
                    MessageBox.Show("작성자가 상이하여 수정할수 없습니다.");
                    return;
                }
                else
                {
                    DialogResult dr = MessageBox.Show("저장된 내용을삭제하시겠습니까?", this.Text + "[삭제]", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No) return;

                    sql = "DELETE FROM tb_rorder_sub1 where rorder_id = '" + rid + "' and rorder_seq ='" + rseq + "' and a_seq ='" + dataGridViewA.Rows[rowIndex].Cells[0].Value.ToString() + "'";
                    m.dbCUD(sql, ref msg);

                    search();
                }
            }
            else
            {
                tbBigo.Text = dataGridViewA.Rows[rowIndex].Cells[1].Value.ToString();
                if (dataGridViewA.Rows[rowIndex].Cells[3].Value.ToString() != G.UserID.ToString())
                {
                    tbBigo.ReadOnly = true;
                    tbBigo.Tag = dataGridViewA.Rows[rowIndex].Cells[0].Value.ToString();
                }
                else
                {
                    tbBigo.ReadOnly = false;
                    tbBigo.Tag = dataGridViewA.Rows[rowIndex].Cells[0].Value.ToString();
                }
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            tbBigo.ReadOnly = false;
            tbBigo.Tag = null;
            tbBigo.Text = "";
        }
    }
}