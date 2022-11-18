using SmartFactory;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B16_ITEM_BOX_SUB : Form
    {
        public P1B16_ITEM_BOX parentWin;

        public string sGubun = string.Empty;
        public string sIsComplete = string.Empty;

        public string sSujuNo = string.Empty;
        public string sSujuSeq = string.Empty;
        public string sProdID = string.Empty;
        public string sProdName = string.Empty;
        public string sBoxID = string.Empty;

        public P1B16_ITEM_BOX_SUB()
        {
            InitializeComponent();
        }
        private void P1B16_ITEM_BOX_SUB_Load(object sender, EventArgs e)
        {
            if (sGubun == "자재입고")
            {
                btnItemBox.Visible = false;
                btnMaterial.Visible = true;
            }
            else if (sGubun == "구성완료")
            {
                btnItemBox.Visible = true;
                btnMaterial.Visible = false;

                if (sIsComplete == "완료") btnItemBox.Visible = false;
                else if (sIsComplete == "진행중") btnItemBox.Visible = true;
            }

            ListSearch();
        }

        public void ListSearch()
        {
            //lblMsg.Text = "";

            lbSujuInfo.Text = $@"수주번호 : {@sSujuNo} / 수주순번 : {@sSujuSeq} / 품목명 : {@sProdName}";

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                sP_Item_Box_SubTableAdapter.Fill(dataSetP1B.SP_Item_Box_Sub, sSujuNo, Convert.ToInt32(sSujuSeq));
                var data = dataSetP1B.SP_Item_Box_Sub;
                Logger.ApiLog(G.UserID, "BOM 정보(현품박스)", ActionType.조회, data);

                dataGridView1.CurrentCell = null;
                dataGridView1.ClearSelection();

                if (sGubun == "자재입고")
                {
                    dataGridView1.Columns[9].ReadOnly = false;
                }
                else if (sGubun == "구성완료")
                {
                    dataGridView1.Enabled = false;
                }
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

        #region Button Events
        private void btnItemBox_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            string msg = string.Empty;

            MariaCRUD m = new MariaCRUD();

            sql = $@"SELECT COUNT(box_id) FROM Item_box_main WHERE order_id = '{@sSujuNo}' AND order_seq = '{@sSujuSeq}'";
            DataTable table = m.dbDataTable(sql, ref msg);

            if (Convert.ToInt64(table.Rows[0][0]) == 0)
            {
                MessageBox.Show("해당 현품박스 정보가 없습니다.");
                return;
            }

            sql = $@"UPDATE SAL_order_sub SET prod_status = 2 WHERE order_id = '{@sSujuNo}' AND order_seq = '{@sSujuSeq}'";

            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            lblMsg.Text = "해당 수주건의 현품박스 구성상태 변경에 성공했습니다.";

            sql = $@"UPDATE Item_box_main SET completeYN = 'Y', complete_dt = '{@DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE order_id = '{@sSujuNo}' AND order_seq = '{@sSujuSeq}'";

            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            parentWin.ListSearch();

            for (int i = 0; i < parentWin.dataGridView1.Rows.Count; i++)
            {
                if (parentWin.dataGridView1.Rows[i].Cells[1].Value.ToString() == sSujuNo
                    && parentWin.dataGridView1.Rows[i].Cells[2].Value.ToString() == sSujuSeq)
                {
                    parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[0, i];
                    parentWin.dataGridView1.CurrentCell.Selected = true;
                    break;
                }
            }

            this.DialogResult = DialogResult.OK;
        }
        private void btnMaterial_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sBoxID)) return;
            if (dataGridView1.Rows.Count == 0) return;

            int ItemCount = 0;
            string sSubID = string.Empty;

            string sql = string.Empty;
            string msg = string.Empty;

            MariaCRUD m = new MariaCRUD();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                ItemCount = Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value);
                sSubID = dataGridView1.Rows[i].Cells[4].Value.ToString().Replace(",","");

                sql = $@"UPDATE Item_box_sub SET item_count = '{@ItemCount}' WHERE box_id = '{@sBoxID}' AND prod_id_sub = '{@sSubID}'";

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    //lblMsg.Text = msg;
                    MessageBox.Show(msg);

                    return;
                }
            }

            MessageBox.Show($@"{@sBoxID}번 현품박스의 입고처리가 완료되었습니다.");

            this.DialogResult = DialogResult.OK;
        }
        #endregion

        #region GridView Events
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int columnIndex = dataGridView1.CurrentCell.ColumnIndex;

            if (columnIndex == 9)
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '.'))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
                {
                    e.Handled = true;
                }
            }
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        #endregion

    }
}
