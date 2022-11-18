﻿using System;
using System.Data;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B13_STOCK_TABLE_MOVE : Form
    {
        public P1B13_STOCK_TABLE parentWin;
        private int rowIndex = 0;

        public P1B13_STOCK_TABLE_MOVE()
        {
            InitializeComponent();
        }
        private void P1B13_STOCK_TABLE_MOVE_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            rowIndex = parentWin.dataGridView1.CurrentCell.RowIndex;

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

            sql = @"select co_code, co_item from BAS_common where co_kind = 'E' order by co_code";
            m = new MariaCRUD();
            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbKind.DataSource = table;
                cbKind.ValueMember = "co_code";
                cbKind.DisplayMember = "co_item";
            }

            dtpDate.Value = parentWin.dtpToDate.Value;

            if (parentWin.cbDepot.SelectedValue.ToString() == "%")
                cbDepot.SelectedIndex = 0;
            else
                cbDepot.SelectedValue = parentWin.cbDepot.SelectedValue;

            tbProd.Tag = parentWin.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            tbProd.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            cbKind.SelectedValue = "0003";
            this.ActiveControl = tbQty;
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

        #region 품목명
        private void lblProd_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            ProdFinder pop = new ProdFinder();
            pop.cbGubun.Text = "<전체>";
            pop._kind = "%";
            pop._stockFlag = "1";
            pop.FormSendEvent += new ProdFinder.FormSendDataHandler(ProdEventMethod);
            pop.ShowDialog();
        }
        private void ProdEventMethod(object sender)
        {
            string sProd = sender.ToString();

            if (string.IsNullOrEmpty(sProd)) return;

            tbProd.Tag = sProd.Substring(0, 8);
            tbProd.Text = sProd.Substring(9, sProd.Length - 9);
            tbQty.Focus();
        }
        #endregion

        #region 텍스트 박스 숫자 처리
        private void tbQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string lgsText;

                lgsText = tbQty.Text.Replace(",", ""); //** 숫자변환시 콤마로 발생하는 에러방지...
                tbQty.Text = String.Format("{0:#,##0}", Convert.ToDouble(lgsText));

                tbQty.SelectionStart = tbQty.TextLength; //** 캐럿을 맨 뒤로 보낸다...
                tbQty.SelectionLength = 0;
            }
            catch (FormatException)
            {
                return;
            }
        }
        private void tbQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '-'))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
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

            if (tbProd.Tag == null)
            {
                lblMsg.Text = "품목명을 선택해 주세요.";
                lblProd.Focus();
                return;
            }

            string sProd = tbProd.Tag.ToString();
            string sQty = tbQty.Text.Replace(",", "").Trim();

            if (String.IsNullOrEmpty(sQty))
            {
                lblMsg.Text = "조정수량을 입력해 주세요.";
                tbQty.Focus();
                return;
            }

            string sDate = dtpDate.Value.ToString("yyyy-MM-dd");
            string sDepot = cbDepot.SelectedValue.ToString();
            string sKind = cbKind.SelectedValue.ToString();
            string sContents = tbContents.Text.Trim();

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            sql = "insert into tb_stock_move (pos, move_date, depot, prod_id, move_kind, move_qty, contents, enter_man) " +
                    "values('" + G.Pos + "','" + sDate + "','" + sDepot + "','" + sProd + "','" + sKind + "'," + sQty + ",'" + sContents + "','" + G.UserID + "')";

            m.dbCUD(sql, ref msg);

            if (msg != "OK")
            {
                lblMsg.Text = msg;
                return;
            }

            parentWin.ListSearch();

            for (int i = 0; i < parentWin.dataGridView1.Rows.Count; i++)
            {
                if (parentWin.dataGridView1.Rows[i].Cells[2].Value.ToString() == sProd)
                {
                    parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[0, i];
                    parentWin.dataGridView1.CurrentCell.Selected = true;
                    break;
                }
            }

            this.DialogResult = DialogResult.OK;
        }
        #endregion
    }
}
