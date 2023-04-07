using SmartFactory;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1A06_BOM_Suju : Form
    {
        public P1A06_BOM parentWin;

        public int rowIndex;

        public P1A06_BOM_Suju()
        {
            InitializeComponent();
        }
        private async void P1A06_BOM_Suju_Load(object sender, EventArgs e)
        {
            string s_id = parentWin.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();

            this.sP_BOM_SujuTableAdapter1.Fill(this.dataSetP1A.SP_BOM_Suju, s_id);

            var data = this.dataSetP1A.SP_BOM_Suju;
            var result = await Logger.ApiLog(G.UserID, "수주내역", ActionType.조회, data);

            ListSearch();
        }
        public async void ListSearch()
        {
            try
            {
                string s_id = parentWin.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                Cursor.Current = Cursors.WaitCursor;

                sP_BOM_SujuTableAdapter1.Fill(dataSetP1A.SP_BOM_Suju, s_id);

                var data = dataSetP1A.SP_BOM_Suju;
                var result = await Logger.ApiLog(G.UserID, "수주내역", ActionType.조회, data);

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
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridView1.RowCount == 0) return;
        }
        #endregion
    }
}
