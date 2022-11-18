using System;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B14_UNIT_COST_SUB : Form
    {
        public P1B14_UNIT_COST parentWin;

        private int rowIndex = 0;
        private string sNo = string.Empty;

        public P1B14_UNIT_COST_SUB()
        {
            InitializeComponent();
        }
        private void P1B14_UNIT_COST_SUB_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            //dtpYYYYMMDanga.Value.Year = DateTime.Today.Year;
            //dtpYYYYMMDanga.Value.Month = DateTime.Today.Month + 1;
            dtpYYYYMMDanga.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1,1);

            if (lblTitle.Text.Substring(lblTitle.Text.Length - 4, 4) == "[추가]")
            {
                //this.ActiveControl = lblCust;
                //tbDanga.Focus();
                this.ActiveControl = tbDanga;
            }
            else
            {
                rowIndex = parentWin.dataGridView1.CurrentCell.RowIndex;

                sNo = parentWin.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                tbGubun.Text = sNo;
                //tbMoney.Text = (long.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[8].Value.ToString()) * long.Parse(parentWin.dataGridView1.Rows[rowIndex].Cells[9].Value.ToString())).ToString("#,##0");
                
                this.ActiveControl = btnSave;
            }
        }

        #region 엔터키로 포커스 이동
        public bool NextFocus(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                return true;
            }
            return false;
        }
        private void nextFocus_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = NextFocus(sender, e);
        }
        #endregion

        #region 품목선택
        private void lbProduct_Click(object sender, EventArgs e)
        {
            if (G.Authority == "D") return;

            ProdFinder pop = new ProdFinder();
            pop.cbGubun.SelectedIndex = 0;
            pop._kind = "%";
            pop._stockFlag = "%";
            pop.FormSendEvent += new ProdFinder.FormSendDataHandler(ProdEventMethod);
            pop.ShowDialog();
        }
        private void ProdEventMethod(object sender)
        {
            string sProd = sender.ToString();
            if (string.IsNullOrEmpty(sProd)) return;

            String prod_code = sProd.Substring(0, sProd.IndexOf("#1/"));

            //tbProduct.Tag = sProd.Substring(0, sProd.IndexOf("#1/"));
            tbProduct.Tag = prod_code;
            tbProduct.Text = sProd.Substring(sProd.IndexOf("#1/") + 3, sProd.IndexOf("#2/") - (sProd.IndexOf("#1/") + 3));

            tbUnit.Text = sProd.Substring(sProd.IndexOf("#2/") + 3, sProd.Length - (sProd.IndexOf("#2/") + 3));

            if (prod_code[0] == 'A')
            {
                tbGubun.Text = "제품";
                tbGubun.Tag = prod_code[0];
            }
            else if (prod_code[0] == 'B')
            {
                tbGubun.Text = "원자재";
                tbGubun.Tag = prod_code[0];
            }
        }
        #endregion

        #region 텍스트 박스 숫자 처리
        private void tbDanga_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string lgsText = tbDanga.Text.Replace(",", ""); //** 숫자변환시 콤마로 발생하는 에러방지...
                tbDanga.Text = String.Format("{0:#,##0}", Convert.ToDouble(lgsText));

                tbDanga.SelectionStart = tbDanga.TextLength; //** 캐럿을 맨 뒤로 보낸다...
                tbDanga.SelectionLength = 0;

                //long lQty = long.Parse(tbQty.Text.Replace(",", "").Trim());
                //long lDanga = long.Parse(tbProduct.Text.Replace(",", "").Trim());
                //tbMoney.Text = (lQty * lDanga).ToString("#,##0");
            }
            catch (FormatException)
            {
                return;
            }
        }

        private void tbDanga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        #endregion

        #region 저장
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void Save()
        {
            lblMsg.Text = "";

            if (string.IsNullOrEmpty(tbProduct.Text))
            {
                lblMsg.Text = "품목 정보를 선택해 주세요.";
                tbProduct.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tbDanga.Text))
            {
                lblMsg.Text = "월별기준단가를 입력해 주세요.";
                tbDanga.Focus();
                return;
            }

            string sProd = tbProduct.Text;

            string sDanga = tbProduct.Text.Replace(",", "").Trim();

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            //if (lblTitle.Text.Substring(lblTitle.Text.Length - 4, 4) == "[추가]")
            //{
            //    sNo = getCode("PM");

            //    sql = "insert into tb_purchase_mat (purchase_id, pos, putch_date, cust_id, request_date, prod_id, add_size, putch_qty, danga, enter_man1) " +
            //        "values('" + sNo + "','" + G.Pos + "','" + sPutchDate + "','" + sCust + "','" + sRequestDate + "','" + sProd + "','" + sSize + "'," + sQty + "," + sDanga + ",'" + G.UserID + "')";

            //    m.dbCUD(sql, ref msg);

            //    if (msg != "OK")
            //    {
            //        lblMsg.Text = msg;
            //        return;
            //    }

            //    lblMsg.Text = "저장되었습니다.";

            //    parentWin.ListSearch();

            //    for (int i = 0; i < parentWin.dataGridView1.Rows.Count - 1; i++)
            //    {
            //        if (parentWin.dataGridView1.Rows[i].Cells[0].Value.ToString() == sNo)
            //        {
            //            parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[1, i];
            //            parentWin.dataGridView1.CurrentCell.Selected = true;
            //            break;
            //        }
            //    }

            //    sNo = string.Empty;
            //    tbSize.Text = string.Empty;
            //    tbQty.Text = string.Empty;
            //    tbProduct.Text = string.Empty;
            //    tbMoney.Text = string.Empty;
            //    tbSize.Focus();
            //}
            //else
            //{
            //    sql = "update tb_purchase_mat " +
            //        "set putch_date = '" + sPutchDate + "', cust_id = '" + sCust + "', request_date = '" + sRequestDate + "', prod_id = '" + sProd + "', add_size = '" + sSize + "', putch_qty = " + sQty + ", danga = " + sDanga +
            //        " where purchase_id = '" + sNo + "'";

            //    m.dbCUD(sql, ref msg);

            //    if (msg != "OK")
            //    {
            //        lblMsg.Text = msg;
            //        return;
            //    }

            //    m.TransLogCreate(G.Authority, G.UserID, "M", this.Name, lblTitle.Text, sNo + " " + sPutchDate + " " + tbCust.Text + " " + tbProd.Text);

            //    parentWin.ListSearch();

            //    for (int i = 0; i < parentWin.dataGridView1.Rows.Count - 1; i++)
            //    {
            //        if (parentWin.dataGridView1.Rows[i].Cells[0].Value.ToString() == sNo)
            //        {
            //            parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[1, i];
            //            parentWin.dataGridView1.CurrentCell.Selected = true;
            //            break;
            //        }
            //    }
            //    this.DialogResult = DialogResult.OK;
            //}
        }
        #endregion
    }
}
