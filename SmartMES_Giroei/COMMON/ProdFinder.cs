using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class ProdFinder : Form
    {
        public delegate void FormSendDataHandler(object obj);
        public event FormSendDataHandler FormSendEvent;
        public string _kind;
        public string _stockFlag;
        public string _prodName;

        public ProdFinder()
        {
            InitializeComponent();
        }
        private void ProdFinder_Load(object sender, EventArgs e)
        {
            ListSearch();
            this.ActiveControl = tbSearch;
        }

        public void ListSearch()
        {
            try
            {
                string sSearch = tbSearch.Text.Trim();
                string sGubun = cbGubun.Text;

                int index = cbGubun.SelectedIndex - 1;

                if (sGubun == "<전체>") sGubun = "PMSDZ";
                else sGubun = "PMSDZ"[index] + "----";
                //else sGubun = sGubun.Substring(0, 1) + "----";

                if (!string.IsNullOrEmpty(_prodName))
                {
                    sSearch = _prodName;
                    tbSearch.Text = _prodName;
                }

                sP_Product_CommonTableAdapter.Fill(dataSetCOMMON.SP_Product_Common, sGubun, _kind, _stockFlag, sSearch);

                dataGridView1.CurrentCell = null;
                dataGridView1.ClearSelection();
            }

            catch (NullReferenceException)
            {
                return;
            }
        }

        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _prodName = tbSearch.Text.Trim();

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
        private void cbGubun_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListSearch();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 2) return;
            // 품목코드, 품목명, 단위, 규격 - 층수, 점수, MM, 기준단가
            //this.FormSendEvent(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString() + "#1/" + dataGridView1[3, e.RowIndex].Value.ToString() + "#2/" + dataGridView1[6, e.RowIndex].Value.ToString() + "#3/" + dataGridView1[4, e.RowIndex].Value.ToString()
            //     + "#4/" + dataGridView1[7, e.RowIndex].Value.ToString() + "#5/" + dataGridView1[10, e.RowIndex].Value.ToString() + "#6/" + dataGridView1[11, e.RowIndex].Value.ToString() + "#7/" + dataGridView1[12, e.RowIndex].Value.ToString());

            //string sProdCode = dataGridView1[e.ColumnIndex, e.RowIndex].Value == null ? " " : dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
            //string sProdName = dataGridView1[3, e.RowIndex].Value == null ? " " : dataGridView1[3, e.RowIndex].Value.ToString();
            //string sProdPackType = dataGridView1[6, e.RowIndex].Value == null ? " " : dataGridView1[6, e.RowIndex].Value.ToString();
            //string sProdProdSize = dataGridView1[4, e.RowIndex].Value == null ? " " : dataGridView1[4, e.RowIndex].Value.ToString();
            //string sProdLayers = dataGridView1[7, e.RowIndex].Value == null ? " " : dataGridView1[7, e.RowIndex].Value.ToString();
            //string sProdMountPins = dataGridView1[10, e.RowIndex].Value == null ? " " : dataGridView1[10, e.RowIndex].Value.ToString();
            //string sProdMetalmasks = dataGridView1[11, e.RowIndex].Value == null ? " " : dataGridView1[11, e.RowIndex].Value.ToString();
            //string sProdStockMoney = dataGridView1[12, e.RowIndex].Value == null ? " " : dataGridView1[12, e.RowIndex].Value.ToString();

            this.FormSendEvent(
                                    dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString() + "#1/"   // 품목코드
                                    + dataGridView1[3, e.RowIndex].Value.ToString() + "#2/"             // 품목명
                                    + dataGridView1[6, e.RowIndex].Value.ToString() + "#3/"             // 단위
                                    + dataGridView1[4, e.RowIndex].Value.ToString() + "#4/"             // 규격
                                    + dataGridView1[7, e.RowIndex].Value.ToString() + "#5/"             // 층수
                                    + dataGridView1[10, e.RowIndex].Value.ToString() + "#6/"            // 적용점수
                                    + dataGridView1[11, e.RowIndex].Value.ToString() + "#7/"            // MM
                                    + dataGridView1[12, e.RowIndex].Value.ToString()                    // 기준단가
                                    //+ dataGridView1[12, e.RowIndex].Value.ToString() + "#8/"            // 기준단가
                                    //+ dataGridView1[14, e.RowIndex].Value.ToString() + "#9/"            // 공정코드
                                    //+ dataGridView1[15, e.RowIndex].Value.ToString()                    // 공정명
                                );

            //this.FormSendEvent(
            //                        sProdCode + "#1/"           // 품목코드
            //                        + sProdName + "#2/"         // 품목명
            //                        + sProdPackType + "#3/"     // 단위
            //                        + sProdProdSize + "#4/"     // 규격
            //                        + sProdLayers + "#5/"       // 층수
            //                        + sProdMountPins + "#6/"    // 적용점수
            //                        + sProdMetalmasks + "#7/"   // MM
            //                        + sProdStockMoney           // 기준단가
            //                    );
            this.Dispose();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //P1A02_PRODUCT_SUB sub = new P1A02_PRODUCT_SUB("Estimate");
            P1A02_PRODUCT_SUB sub = new P1A02_PRODUCT_SUB(false);
            sub.lblTitle.Text = sub.lblTitle.Text + "[추가]";
            sub.gubun = "P";
            sub._prodName = tbSearch.Text;
            sub.ShowDialog();

            ListSearch();
        }
    }
}
