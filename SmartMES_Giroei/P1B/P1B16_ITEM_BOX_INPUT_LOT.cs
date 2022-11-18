using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B16_ITEM_BOX_INPUT_LOT : Form
    {
        public P1B16_ITEM_BOX_INPUT_SUB parentWin;
        public int parentRow;
        public string sBarcode;

        int columnIndex = 0;
        int rowIndex = 0;
        bool endEdit = false;

        public P1B16_ITEM_BOX_INPUT_LOT()
        {
            InitializeComponent();
        }

        private void P1B16_ITEM_BOX_INPUT_LOT_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            //this.ActiveControl = dataGridView1;
        }

        public void ListSearch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                sP_Barcode_QueryTableAdapter.Fill(dataSetP1B.SP_Barcode_Query, sBarcode);

                dataGridView1.CurrentCell = null;
                dataGridView1.ClearSelection();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        #region GridView Events
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblMsg.Text = "";
            if (G.Authority == "D") return;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 0) return;

            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value == null) return;
            else
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() == "1")
                    dataGridView1.Rows[e.RowIndex].Cells[0].Value = 0;
                else if (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() == "0")
                    dataGridView1.Rows[e.RowIndex].Cells[0].Value = 1;
            }
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
        }
        #endregion

        #region Button Control
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount < 1) return;

            int iCnt = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[0].Value.ToString() == "1")
                {
                    iCnt++;
                }
            }
            if (iCnt < 1)
            {
                MessageBox.Show("LotNo가 선택되지 않았습니다.");
                return;
            }
            else if (iCnt > 1)
            {
                MessageBox.Show("LotNo가 하나 이상 선택되었습니다..");
                return;
            }
            // call function 
        }
        private void barcodeSearch()
        {
            int iSeq = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[0].Value.ToString() == "1")
                {
                    parentWin.sPItemBoxSubBindingSource.AddNew();
                    parentWin.dataGridView1.Rows[iSeq].Cells[19].Value = dataGridView1.Rows[i].Cells[2].Value; //바코드 Surfix
                    iSeq++;
                }
            }
            this.Dispose();
        }
        #endregion
    }
}