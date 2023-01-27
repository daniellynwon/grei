using SmartFactory;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1A02_PRODUCT_SUB : Form
    {
        public P1A02_PRODUCT parentWin;
        //public Object parentWin;
        public string gubun, kind, _prodName;

        public bool isProduct = true;

        private int rowIndex = 0;
        //private string prodCode = string.Empty;

        public P1A02_PRODUCT_SUB()
        {
            InitializeComponent();
        }

        public P1A02_PRODUCT_SUB(bool product_flag)
        {
            InitializeComponent();

            isProduct = (product_flag == true) ? true : false;
        }

        private void P1A02_PRODUCT_SUB_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            //if (gubun == "A") cbGubun.Text = "A.제품";
            //else if (gubun == "B") cbGubun.Text = "B.원/부자재";
            //else if (gubun == "C") cbGubun.Text = "C.반제품";
            //else if (gubun == "D") cbGubun.Text = "D.세트";
            //else cbGubun.Text = "Z.기타";

            if (gubun == "P") cbGubun.Text = "제품";
            else if (gubun == "M") cbGubun.Text = "원자재";
            else if (gubun == "S") cbGubun.Text = "부자재";

            DataTable table;

            string sql = string.Empty;
            string msg = string.Empty;

            MariaCRUD m = new MariaCRUD();

            sql = @"SELECT co_code, co_item FROM BAS_common WHERE co_kind = 'U' ORDER BY co_code";

            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbUnit.DataSource = table;
                cbUnit.ValueMember = "co_code";
                cbUnit.DisplayMember = "co_item";
            }

            if (cbGubun.SelectedIndex == 0)
            {
                tbLayers.ReadOnly = false;
                tbSMDPins.ReadOnly = false;
                tbDIPPins.ReadOnly = false;
                tbMountPins.ReadOnly = false;
                tbMetalMasks.ReadOnly = false;
                tbQty4Array.ReadOnly = false;

                sql = @"SELECT co_code, co_item FROM BAS_common WHERE co_kind = 'P' ORDER BY co_code";

                table = m.dbDataTable(sql, ref msg);

                if (msg == "OK")
                {
                    cbKind.DataSource = table;
                    cbKind.ValueMember = "co_code";
                    cbKind.DisplayMember = "co_item";
                }
            }
            else
            {
                tbLayers.ReadOnly = true;
                tbSMDPins.ReadOnly = true;
                tbDIPPins.ReadOnly = true;
                tbMountPins.ReadOnly = true;
                tbMetalMasks.ReadOnly = true;
                tbQty4Array.ReadOnly = true;

                sql = @"SELECT co_code, co_item FROM BAS_common WHERE co_kind = 'C' AND co_code <> '' ORDER BY co_code";

                table = m.dbDataTable(sql, ref msg);

                if (msg == "OK")
                {
                    cbKind.DataSource = table;
                    cbKind.ValueMember = "co_code";
                    cbKind.DisplayMember = "co_item";
                }
            }

            if (lblTitle.Text.Substring(lblTitle.Text.Length - 4, 4) == "[추가]")
            {
                //cbKind.SelectedIndex = 0;
                //cbUnit.SelectedIndex = 0;

                //if (gubun == "P") cbGubun.SelectedIndex = 0;
                //else if (gubun == "M") cbGubun.SelectedIndex = 1;
                //else if (gubun == "S") cbGubun.SelectedIndex = 2;

                cbKind.SelectedIndex = 0;

                if (!string.IsNullOrEmpty(_prodName))
                    tbProdName.Text = _prodName;

                this.ActiveControl = tbProdName;
            }
            else
            {
                rowIndex = parentWin.dataGridView1.CurrentCell.RowIndex;

                cbKind.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                tbProdCode.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                tbProdName.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
                tbSize.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
                cbUnit.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
                tbQty.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
                tbDanga.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();
                tbCertification.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[9].Value.ToString();

                if (cbGubun.SelectedIndex == 0)
                {
                    tbLayers.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[10].Value.ToString(); ;
                    tbSMDPins.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[11].Value.ToString(); ;
                    tbDIPPins.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[12].Value.ToString(); ;
                    tbMountPins.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[13].Value.ToString(); ;
                    tbMetalMasks.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[14].Value.ToString(); ;
                    tbQty4Array.Text = parentWin.dataGridView1.Rows[rowIndex].Cells[15].Value.ToString(); ;
                }

                //if (parentWin.dataGridView1.Rows[rowIndex].Cells[18].Value.ToString() == "N")
                if (parentWin.dataGridView1.Rows[rowIndex].Cells[17].Value.ToString() == "O")
                    ckbConsigned.Checked = true;
                if (parentWin.dataGridView1.Rows[rowIndex].Cells[18].Value.ToString() == "X")
                    ckbUseFlag.Checked = true;

                cbGubun.Enabled = false;
                //cbKind.Enabled = false;

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

        #region 품목코드 생성 / 품목명 확인
        private string getProdCode(string _gubun)
        {
            string sql = @"select UF_ProdCodeGenerator('" + _gubun + "')";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
        private bool isProdName(string _gubun, string _prodName)
        {
            string sql = @"select prod_id from BAS_product where gubun = '" + _gubun + "' and prod_name = '" + _prodName + "'";

            MariaCRUD m = new MariaCRUD();
            string msg = string.Empty;
            object id = m.dbRonlyOne(sql, ref msg);

            if (msg == "OK" && id != null)
                return true;
            else
                return false;
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
        private async void Save()
        {
            lblMsg.Text = "";

            string sProdName = tbProdName.Text.Trim();

            if (String.IsNullOrEmpty(sProdName))
            {
                lblMsg.Text = "품목명을 입력해 주세요.";

                tbProdName.Focus();

                return;
            }

            string sGubun = string.Empty;
            if (cbGubun.SelectedIndex == 0) sGubun = "P";
            else if (cbGubun.SelectedIndex == 1) sGubun = "M";
            else if (cbGubun.SelectedIndex == 1) sGubun = "S";

            string sKind = cbKind.SelectedValue.ToString();

            string sProdCode = tbProdCode.Text;

            string sSize = tbSize.Text.Trim();
            string sUnit = cbUnit.SelectedValue.ToString();

            //string sQty = tbQty.Text;
            string sQty = tbQty.Text.Replace(",", "");
            if (string.IsNullOrEmpty(tbQty.Text)) sQty = "0";

            //string sDanga = tbDanga.Text;
            string sDanga = tbDanga.Text.Replace(",", "");
            if (string.IsNullOrEmpty(tbDanga.Text)) sDanga = "0";

            string sCertification = tbCertification.Text;

            string sConsigned = "N";
            if (ckbConsigned.Checked) sConsigned = "Y";
            string sUseFlag = "Y";
            if (ckbUseFlag.Checked) sUseFlag = "N";

            string sLayers = tbLayers.Text;
            if (string.IsNullOrEmpty(sLayers)) sLayers = "0";
            string sSMDPins = tbSMDPins.Text;
            if (string.IsNullOrEmpty(sSMDPins)) sSMDPins = "0";
            string sDIPPins = tbDIPPins.Text;
            if (string.IsNullOrEmpty(sDIPPins)) sDIPPins = "0";
            string sMountPins = tbMountPins.Text;
            if (string.IsNullOrEmpty(sMountPins)) sMountPins = "0";
            string sMetalMasks = tbMetalMasks.Text;
            if (string.IsNullOrEmpty(sMetalMasks)) sMetalMasks = "0";
            string sQty4Array = tbQty4Array.Text;
            if (string.IsNullOrEmpty(sQty4Array)) sQty4Array = "0";

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            if (lblTitle.Text.Substring(lblTitle.Text.Length - 4, 4) == "[추가]")
            {
                //입력한 품목명이 중복인지 확인..
                if (isProdName(sGubun, sProdName))
                {
                    lblMsg.Text = "이미 존재하는 품목명입니다.";
                    tbProdName.Focus();
                    return;
                }

                //수량 / 단가 값 입력 확인
                //if (string.IsNullOrEmpty(tbQty.Text) || string.IsNullOrEmpty(tbDanga.Text))
                //{
                //    lblMsg.Text = "값을 정확히 입력해 주세요";

                //    return;
                //}

                //prodCode = getProdCode(sGubun);

                if (cbGubun.Text == "제품" && cbKind.Text == "SMT")
                {
                    sql = $@"INSERT INTO BAS_product ( gubun, prod_kind, prod_id, prod_name, prod_size, pack_type, qty, stock_money, certification, useYN, enter_man, layers, smd_pins, dip_pins, mount_pins, metalmasks, qty4array, consignedYN )
                        VALUES('{@sGubun}', '{@sKind}', '{@sProdCode}', '{@sProdName}', '{@sSize}', '{@sUnit}', {@sQty}, {@sDanga}, '{@sCertification}', '{@sUseFlag}', '{@G.UserID}',
                        '{@sLayers}', '{@sSMDPins}', '{@sDIPPins}', '{@sMountPins}', '{@sMetalMasks}', '{@sQty4Array}', '{@sConsigned}')";
                }
                else
                {
                    sql = $@"INSERT INTO BAS_product ( gubun, prod_kind, prod_id, prod_name, prod_size, pack_type, qty, stock_money, certification, useYN, enter_man, consignedYN )
                        VALUES('{@sGubun}', '{@sKind}', '{@sProdCode}', '{@sProdName}', '{@sSize}', '{@sUnit}', {@sQty}, {@sDanga}, '{@sCertification}', '{@sUseFlag}', '{@G.UserID}', '{@sConsigned}' )";
                }

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = msg;
                    return;
                }

                var data = sql;
                var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);

                if (isProduct)
                {
                    lblMsg.Text = "저장되었습니다.";

                    parentWin.tbSearch.Text = "";
                    //if (sGubun == "A") parentWin.rbA.Checked = true;
                    //else if (sGubun == "B") parentWin.rbB.Checked = true;
                    //else if (sGubun == "C") parentWin.rbC.Checked = true;
                    //else if (sGubun == "D") parentWin.rbD.Checked = true;
                    //else parentWin.rbZ.Checked = true;

                    if (gubun == "P") parentWin.cbGubun.Text = "P.제품";
                    else if (gubun == "M") parentWin.cbGubun.Text = "M.원자재";
                    else if (gubun == "S") parentWin.cbGubun.Text = "S.부자재";

                    parentWin.ListSearch();

                    for (int i = 0; i < parentWin.dataGridView1.Rows.Count; i++)
                    {
                        if (parentWin.dataGridView1.Rows[i].Cells[3].Value.ToString() == sProdCode)
                        {
                            parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[0, i];
                            parentWin.dataGridView1.CurrentCell.Selected = true;
                            break;
                        }
                    }

                    tbProdName.Text = string.Empty;
                    tbSize.Text = string.Empty;
                    tbQty.Text = string.Empty;
                    tbDanga.Text = string.Empty;
                    tbCertification.Text = string.Empty;

                    ckbUseFlag.Checked = false;

                    tbLayers.Text = string.Empty;
                    tbSMDPins.Text = string.Empty;
                    tbDIPPins.Text = string.Empty;
                    tbMountPins.Text = string.Empty;
                    tbMetalMasks.Text = string.Empty;
                    tbQty4Array.Text = string.Empty;

                    tbProdName.Focus();
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                if (cbGubun.Text == "제품" && cbKind.Text == "SMT")
                {
                    sql = $@"UPDATE BAS_product 
                            SET prod_name = '{@sProdName}', prod_size = '{@sSize}', pack_type = '{@sUnit}', qty = {@sQty}, stock_money = {@sDanga}, certification = '{@sCertification}',useYN = '{@sUseFlag}', enter_man = '{@G.UserID}',
                            layers = '{@sLayers}', smd_pins = '{@sSMDPins}', dip_pins = '{@sDIPPins}', mount_pins = '{@sMountPins}', metalmasks = '{@sMetalMasks}', qty4array = '{@sQty4Array}', consignedYN = '{@sConsigned}'
                            WHERE prod_id = '{@sProdCode}';";
                }
                else
                {
                    sql = $@"UPDATE BAS_product 
                            SET prod_name = '{@sProdName}', prod_size = '{@sSize}', pack_type = '{@sUnit}', qty = {@sQty}, stock_money = {@sDanga}, certification = '{@sCertification}',useYN = '{@sUseFlag}', enter_man = '{@G.UserID}', consignedYN = '{@sConsigned}'
                            WHERE prod_id = '{@sProdCode}';";
                }

                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    lblMsg.Text = "데이터 저장에 실패했습니다.";

                    Debug.Print(msg);
                    Debug.Print(sql);

                    return;
                }

                m.TransLogCreate(G.Authority, G.UserID, "M", this.Name, lblTitle.Text, sProdCode + " " + sProdName);

                var data = sql;
                var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);

                parentWin.ListSearch();
                parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[0, rowIndex];
                parentWin.dataGridView1.Rows[rowIndex].Selected = true;

                //parentWin.ListSearch();

                //for (int i = 0; i < parentWin.dataGridView1.Rows.Count; i++)
                //{
                //    if (parentWin.dataGridView1.Rows[i].Cells[1].Value.ToString() == sJobNo)
                //    {
                //        parentWin.dataGridView1.CurrentCell = parentWin.dataGridView1[0, i];
                //        parentWin.dataGridView1.CurrentCell.Selected = true;
                //        break;
                //    }
                //}

                this.DialogResult = DialogResult.OK;
            }


        }
        #endregion

        #region ComboBox
        private void cbGubun_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table;

            string sql = string.Empty;
            string msg = string.Empty;

            MariaCRUD m = new MariaCRUD();

            string _gubun = string.Empty;

            if (cbGubun.SelectedIndex == 0) _gubun = "P";
            else if (cbGubun.SelectedIndex == 1) _gubun = "M";
            else if (cbGubun.SelectedIndex == 2) _gubun = "S";

            tbProdCode.Text = getProdCode(_gubun);

            if (cbGubun.Text == "제품")
            {
                tbLayers.Text = string.Empty;
                tbSMDPins.Text = string.Empty;
                tbDIPPins.Text = string.Empty;
                tbMountPins.Text = string.Empty;
                tbMetalMasks.Text = string.Empty;
                tbQty4Array.Text = string.Empty;

                sql = @"SELECT co_code, co_item FROM BAS_common WHERE co_kind = 'P' ORDER BY co_code";

                table = m.dbDataTable(sql, ref msg);

                if (msg == "OK")
                {
                    cbKind.DataSource = table;
                    cbKind.ValueMember = "co_code";
                    cbKind.DisplayMember = "co_item";
                }
            }
            else
            {
                tbLayers.Text = string.Empty;
                tbSMDPins.Text = string.Empty;
                tbDIPPins.Text = string.Empty;
                tbMountPins.Text = string.Empty;
                tbMetalMasks.Text = string.Empty;
                tbQty4Array.Text = string.Empty;

                sql = @"SELECT co_code, co_item FROM BAS_common WHERE co_kind = 'C' AND co_code <> '' ORDER BY co_code";

                table = m.dbDataTable(sql, ref msg);

                if (msg == "OK")
                {
                    cbKind.DataSource = table;
                    cbKind.ValueMember = "co_code";
                    cbKind.DisplayMember = "co_item";
                }
            }
        }
        private void cbKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbKind.Text = kind;

            if (cbKind.Text == "SMT")
            {
                tbLayers.Text = string.Empty;
                tbSMDPins.Text = string.Empty;
                tbDIPPins.Text = string.Empty;
                tbMountPins.Text = string.Empty;
                tbMetalMasks.Text = string.Empty;
                tbQty4Array.Text = string.Empty;

                tbLayers.ReadOnly = false;
                tbSMDPins.ReadOnly = false;
                tbDIPPins.ReadOnly = false;
                tbMountPins.ReadOnly = false;
                tbMetalMasks.ReadOnly = false;
                tbQty4Array.ReadOnly = false;
            }
            else
            {
                tbLayers.Text = string.Empty;
                tbSMDPins.Text = string.Empty;
                tbDIPPins.Text = string.Empty;
                tbMountPins.Text = string.Empty;
                tbMetalMasks.Text = string.Empty;
                tbQty4Array.Text = string.Empty;

                tbLayers.ReadOnly = true;
                tbSMDPins.ReadOnly = true;
                tbDIPPins.ReadOnly = true;
                tbMountPins.ReadOnly = true;
                tbMetalMasks.ReadOnly = true;
                tbQty4Array.ReadOnly = true;
            }
        }
        #endregion

        #region TextBox
        private void tbQty_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbQty.Text)) return;

            string sQty = tbQty.Text.Replace(",", "");

            tbQty.Text = string.Format("{0:#,##0}", Convert.ToInt64(sQty));

            tbQty.SelectionStart = tbQty.TextLength;
        }
        private void tbDanga_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbDanga.Text)) return;

            string sDanga = tbDanga.Text.Replace(",", "");

            tbDanga.Text = string.Format("{0:#,##0}", Convert.ToInt64(sDanga));

            tbDanga.SelectionStart = tbDanga.TextLength;
        }
        private void tbNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '.'))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}