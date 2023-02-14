using SmartFactory;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B03_RORDER_DETAIL : Form
    {
        public P1B03_RORDER parentWin;
        public int rowIndex;

        public P1B03_RORDER_DETAIL()
        {
            InitializeComponent();
        }

        private void P1B03_RORDER_DETAIL_Load(object sender, EventArgs e)
        {
            DataTable table;

            string sql = string.Empty;
            string msg = string.Empty;

            MariaCRUD m = new MariaCRUD();

            sql = @"SELECT cust_id, abbname FROM BAS_customer WHERE gubun > 1";

            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbPcbComp.DataSource = table;
                cbPcbComp.ValueMember = "cust_id";
                cbPcbComp.DisplayMember = "abbname";
            }

            sql = @"SELECT cust_id, abbname FROM BAS_customer WHERE gubun > 1";

            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbMaskComp.DataSource = table;
                cbMaskComp.ValueMember = "cust_id";
                cbMaskComp.DisplayMember = "abbname";
            }

            sql = @"SELECT cust_id, abbname FROM BAS_customer WHERE gubun > 1";

            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbDesignComp.DataSource = table;
                cbDesignComp.ValueMember = "cust_id";
                cbDesignComp.DisplayMember = "abbname";
            }

            sql = @"SELECT cust_id, abbname FROM BAS_customer WHERE gubun > 1";

            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbPuchseComp.DataSource = table;
                cbPuchseComp.ValueMember = "cust_id";
                cbPuchseComp.DisplayMember = "abbname";
            }

            sql = @"SELECT cust_id, abbname FROM BAS_customer WHERE gubun > 1";

            table = m.dbDataTable(sql, ref msg);

            if (msg == "OK")
            {
                cbEtcComp.DataSource = table;
                cbEtcComp.ValueMember = "cust_id";
                cbEtcComp.DisplayMember = "abbname";
            }
            tabControl1.SelectedIndex = 0;

            ListSearch();
        }
        public async void ListSearch()
        {
            string sOrderID = parentWin.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            string sSeq = parentWin.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            string sProd = parentWin.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();

            string sql = "select * from SAL_order_sub_detail where order_id = '" + sOrderID + "' and order_seq = '" + sSeq + "';";
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            DataTable dt = m.dbDataTable(sql, ref msg);

            if (dt.Rows.Count < 1)
            {
                lbNotice.Text = "저장된 Detail정보가 없습니다.";
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow[] row = dt.Select();
                if (row.Length > 0)
                {
                    string gubun = row[i][2].ToString();

                    if (gubun == "1")       // PCB
                    {
                        cbPcbComp.SelectedValue = row[i][3].ToString();
                        tbPcbCost.Text = row[i][4].ToString();
                        dtPcbPay.Value = DateTime.Parse(row[i][6].ToString());
                        dtPcbOrder.Value = DateTime.Parse(row[i][7].ToString());
                        dtPcbDuedate.Value = DateTime.Parse(row[i][8].ToString());
                        tbPcbLayer.Text = row[i][11].ToString();
                        tbPcbTinkness.Text = row[i][12].ToString();
                        tbPcbMaterial.Text = row[i][13].ToString();
                        tbPcbOCopper.Text = row[i][16].ToString();
                        tbPcbICopper.Text = row[i][17].ToString();
                        tbPcbSurface.Text = row[i][18].ToString();
                        tbPcbPSR.Text = row[i][19].ToString();
                        tbPcbSILK.Text = row[i][20].ToString();
                        tbPcbSizeW.Text = row[i][14].ToString();
                        tbPcbSizeL.Text = row[i][15].ToString();
                        tbPcbQty.Text = row[i][9].ToString();
                        tbPcbUnit.Text = row[i][10].ToString();
                        tbPcbModel.Text = row[i][21].ToString();
                        tbPcbImp.Text = row[i][22].ToString();
                        tbPcbMetalData.Text = row[i][23].ToString();
                        rtbPcbBigo.Text = row[i][37].ToString();
                    }
                    if (gubun == "2")
                    {
                        cbMaskComp.SelectedValue = row[i][3].ToString();
                        tbMaskCost.Text = row[i][4].ToString();
                        tbMaskZigCost.Text = row[i][5].ToString();
                        dtMaskPay.Value = DateTime.Parse(row[i][6].ToString());
                        dtMaskOrder.Value = DateTime.Parse(row[i][7].ToString());
                        dtMaskDueDate.Value = DateTime.Parse(row[i][8].ToString());
                        tbMaskTOP.Text = row[i][24].ToString();
                        tbMaskBOT.Text = row[i][25].ToString();
                        tbMaskZig.Text = row[i][26].ToString();
                        tbMaskSizeW.Text = row[i][14].ToString();
                        tbMaskSizeL.Text = row[i][15].ToString();
                        tbMaskQty.Text = row[i][9].ToString();
                        tbMaskUnit.Text = row[i][10].ToString();
                        tbMaskOerderNum.Text = row[i][27].ToString();
                        rtbMaskBigo.Text = row[i][37].ToString();
                    }
                    if (gubun == "3")
                    {
                        cbDesignComp.SelectedValue = row[i][3].ToString();
                        tbDesignCost.Text = row[i][4].ToString();

                        dtDesignPay.Value = DateTime.Parse(row[i][6].ToString());
                        dtDesignStart.Value = DateTime.Parse(row[i][7].ToString());
                        dtDesignDone.Value = DateTime.Parse(row[i][8].ToString());
                        tbDesigner.Text = row[i][28].ToString();
                        tbDesignEstiTime.Text = row[i][29].ToString();
                        tbDesignWorkTime.Text = row[i][30].ToString();
                        tbDesignGubun.Text = row[i][31].ToString();
                        tbSMDpoint.Text = row[i][32].ToString();
                        tbDIPpoint.Text = row[i][33].ToString();
                        tbDesignLayer.Text = row[i][11].ToString();
                        tbSMDPinCount.Text = row[i][34].ToString();
                        tbDIPPinCount.Text = row[i][35].ToString();
                        tbDesignTP.Text = row[i][36].ToString();
                        tbDesignSizeW.Text = row[i][14].ToString();
                        tbDesignSizeL.Text = row[i][15].ToString();
                        rtbDesignBogo.Text = row[i][37].ToString();
                    }
                    if (gubun == "4")
                    {
                        cbPuchseComp.SelectedValue = row[i][3].ToString();
                        tbPurchseCost.Text = row[i][4].ToString();

                        dtPurchase.Value = DateTime.Parse(row[i][6].ToString());
                        rtbPuchaseBigo.Text = row[i][37].ToString();

                    }
                    if (gubun == "5")
                    {
                        cbEtcComp.SelectedValue = row[i][3].ToString();
                        tbEtcCost.Text = row[i][4].ToString();

                        dtEtcPay.Value = DateTime.Parse(row[i][6].ToString());
                        rtbEtcBigo.Text = row[i][37].ToString();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                string sOrderID = parentWin.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                string sSeq = parentWin.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();

                string pcbQty = tbPcbQty.Text.Trim() == "" ? "0" : tbPcbQty.Text.Trim();
                string maskQty = tbMaskQty.Text.Trim() == "" ? "0" : tbMaskQty.Text.Trim();
                string dsnCost = tbDesignCost.Text.Trim() == "" ? "0" : tbDesignCost.Text.Trim();
                string purCost = tbPurchseCost.Text.Trim() == "" ? "0" : tbPurchseCost.Text.Trim();
                string etcCost = tbEtcCost.Text.Trim() == "" ? "0" : tbEtcCost.Text.Trim();


                string sql = string.Empty;
                string msg = string.Empty;
                MariaCRUD m = new MariaCRUD();

                string pcbComp = cbPcbComp.SelectedValue.ToString();
                string pcbCost = tbPcbCost.Text.Trim() == "" ? "0" : tbPcbCost.Text.Trim();
                string pcbPayDate = dtPcbPay.Value.ToString("yyyy-MM-dd");
                string pcbOrderDate = dtPcbOrder.Value.ToString("yyyy-MM-dd");
                string pcbDueDate = dtPcbDuedate.Value.ToString("yyyy-MM-dd");
                string pcbLayer = tbPcbLayer.Text.Trim() == "" ? "0" : tbPcbLayer.Text.Trim();
                string pcbThickness = tbPcbTinkness.Text.Trim() == "" ? "0" : tbPcbTinkness.Text.Trim();
                string pcbMaterial = tbPcbMaterial.Text;
                string pcbOCopper = tbPcbOCopper.Text.Trim() == "" ? "0" : tbPcbOCopper.Text.Trim();
                string pcbICopper = tbPcbICopper.Text.Trim() == "" ? "0" : tbPcbICopper.Text.Trim();
                string pcbSurface = tbPcbSurface.Text;
                string pcbPSR = tbPcbPSR.Text;
                string pcbSILK = tbPcbSILK.Text;
                string pcbSizeW = tbPcbSizeW.Text;
                string pcbSizeL = tbPcbSizeL.Text;
                //string pcbQty = tbPcbQty.Text;
                string pcbUnit = tbPcbUnit.Text;
                string pcbModel = tbPcbModel.Text;
                string pcbImp = tbPcbImp.Text;
                string pcbMetalData = tbPcbMetalData.Text;
                string pcbBigo = rtbPcbBigo.Text;

                string iidx = tabControl1.SelectedTab.ToString();

                sql = $@"INSERT INTO SAL_order_sub_detail (order_id, order_seq, proc_id, cust_id, cost, dtPayment, dtOrder, dtDueDate, qty, unit, layer, thickness, material, size_W, size_L, out_copper, in_copper, surface, PSR, SILK, model, impidance, metaldata, bigo) 
                                VALUES('{@sOrderID}', {@sSeq}, 1, '{pcbComp}', {pcbCost}, '{pcbPayDate}', '{pcbOrderDate}', '{pcbDueDate}', {pcbQty}, '{pcbUnit}', {pcbLayer}, {pcbThickness}, '{pcbMaterial}', '{pcbSizeW}', '{pcbSizeL}', {pcbOCopper}, 
                                        {pcbICopper}, '{pcbSurface}', '{pcbModel}', '{pcbPSR}', '{pcbSILK}', '{pcbImp}', '{pcbMetalData}', '{pcbBigo}')
                            ON DUPLICATE KEY UPDATE 
                                cust_id = '{pcbComp}', cost = {pcbCost}, dtPayment = '{pcbPayDate}', dtOrder = '{pcbOrderDate}', dtDueDate = '{pcbDueDate}', qty = {pcbQty}, unit = '{pcbUnit}', layer = {pcbLayer}, thickness = {pcbThickness}, 
                                material = '{pcbMaterial}', size_W = '{pcbSizeW}', size_L = '{pcbSizeL}', out_copper = {pcbOCopper}, in_copper = {pcbICopper}, surface = '{pcbSurface}',  PSR = '{pcbPSR}',  SILK = '{pcbSILK}', model = '{pcbModel}', impidance = '{pcbImp}', metaldata = '{pcbMetalData}', bigo = '{pcbBigo}'";
                m.dbCUD(sql, ref msg);

            {
                string maskComp = cbMaskComp.SelectedValue.ToString();
                string maskCost = tbMaskCost.Text.Trim() == "" ? "0" : tbMaskCost.Text.Trim();
                string maskZigCost = tbMaskZigCost.Text.Trim() == "" ? "0" : tbMaskZigCost.Text.Trim();
                string maskPayDate = dtMaskPay.Value.ToString("yyyy-MM-dd");
                string maskOrderDate = dtMaskOrder.Value.ToString("yyyy-MM-dd");
                string maskDueDate = dtMaskDueDate.Value.ToString("yyyy-MM-dd");
                string maskTOP = tbMaskTOP.Text;
                string maskBOT = tbMaskBOT.Text;
                string maskZig = tbMaskZig.Text;
                string maskSizeW = tbMaskSizeW.Text.Trim() == "" ? "0" : tbMaskSizeW.Text.Trim();
                string maskSizeL = tbMaskSizeL.Text.Trim() == "" ? "0" : tbMaskSizeL.Text.Trim();
                //string maskQty = tbMaskQty.Text;
                string maskUnit = tbMaskUnit.Text;
                string maskBigo = rtbMaskBigo.Text;

                sql = $@"INSERT INTO SAL_order_sub_detail (order_id, order_seq, proc_id, cust_id, cost, zig_cost, dtPayment, dtOrder, dtDueDate, qty, unit, TOP, BOTTOM, ZIG, size_W, size_L, bigo) 
                                VALUES('{@sOrderID}', {@sSeq}, 2, '{maskComp}', {maskCost}, {maskZigCost}, '{maskPayDate}', '{maskOrderDate}', '{maskDueDate}', {maskQty}, '{maskUnit}', '{maskTOP}', '{maskBOT}',  '{maskZig}', {maskSizeW}, {maskSizeL},'{maskBigo}')
                            ON DUPLICATE KEY UPDATE 
                                cust_id = '{maskComp}', cost = {maskCost}, zig_cost = {maskZigCost}, dtPayment = '{maskPayDate}', dtOrder = '{maskOrderDate}', dtDueDate = '{maskDueDate}', qty = {maskQty}, unit = '{maskUnit}', TOP = '{maskTOP}', BOTTOM = '{maskBOT}', 
                                ZIG = '{maskZig}', size_W = '{maskSizeW}', size_L = '{maskSizeL}', bigo = '{maskBigo}'";
                m.dbCUD(sql, ref msg);
            }
            {
                string dsnComp = cbDesignComp.SelectedValue.ToString();
                //string dsnCost = tbDesignCost.Text;
                string dsnPayDate = dtDesignPay.Value.ToString("yyyy-MM-dd");
                string dsnOrderDate = dtDesignStart.Value.ToString("yyyy-MM-dd");
                string dsnDueDate = dtDesignDone.Value.ToString("yyyy-MM-dd");
                string dsnDesigner = tbDesigner.Text;
                string dsnEstiTime = tbDesignEstiTime.Text;
                string dsnWorkTime = tbDesignWorkTime.Text;
                string dsnGubun = tbDesignGubun.Text;
                string dsnSMDpoint = tbSMDpoint.Text.Trim() == "" ? "0" : tbSMDpoint.Text.Trim();
                string dsnDIPpoint = tbDIPpoint.Text.Trim() == "" ? "0" : tbDIPpoint.Text.Trim();
                string dsnSMDpin = tbSMDPinCount.Text.Trim() == "" ? "0" : tbSMDPinCount.Text.Trim();
                string dsnDIPpin = tbDIPPinCount.Text.Trim() == "" ? "0" : tbDIPPinCount.Text.Trim();
                string dsnTP = tbDesignTP.Text.Trim() == "" ? "0" : tbDesignTP.Text.Trim();
                string dsnSizeW = tbDesignSizeW.Text;
                string dsnSizeL = tbDesignSizeL.Text;
                string dsnBigo = rtbDesignBogo.Text;

                sql = $@"INSERT INTO SAL_order_sub_detail (order_id, order_seq, proc_id, cust_id, cost, dtPayment, dtOrder, dtDueDate, designer, esti_time, work_time, design_gubun, SMDpoint, DIPpoint, SMDpin, DIPpin, TP, size_W, size_L, bigo) 
                                VALUES('{@sOrderID}', {@sSeq}, 3, '{dsnComp}', {dsnCost}, '{dsnPayDate}', '{dsnOrderDate}', '{dsnDueDate}', '{dsnDesigner}', '{dsnEstiTime}', '{dsnWorkTime}', '{dsnGubun}',  {dsnSMDpoint}, {dsnDIPpoint}, {dsnTP},
                                        {dsnSMDpin}, {dsnDIPpin}, '{dsnSizeW}', '{dsnSizeL}','{dsnBigo}')
                            ON DUPLICATE KEY UPDATE 
                                cust_id = '{dsnComp}', cost = {dsnCost}, dtPayment = '{dsnPayDate}', dtOrder = '{dsnOrderDate}', dtDueDate = '{dsnDueDate}', designer = {maskQty}, esti_time = '{dsnEstiTime}', work_time = '{dsnWorkTime}', design_gubun = '{dsnGubun}', 
                                SMDpoint = {dsnSMDpoint}, DIPpoint = {dsnDIPpoint}, SMDpin = {dsnSMDpin}, DIPpin = {dsnDIPpin},  TP = {dsnTP}, size_W = '{dsnSizeW}', size_L = '{dsnSizeL}', bigo = '{dsnBigo}'";
                m.dbCUD(sql, ref msg);
            }
            {
                string purComp = cbPuchseComp.SelectedValue.ToString();
                //string purCost = tbPurchseCost.Text;
                string purPayDate = dtPurchase.Value.ToString("yyyy-MM-dd");

                string purBigo = rtbPuchaseBigo.Text;

                sql = $@"INSERT INTO SAL_order_sub_detail (order_id, order_seq, proc_id, cust_id, cost, dtPayment, bigo) 
                                VALUES('{@sOrderID}', {@sSeq}, 4, '{purComp}', {purCost}, '{purPayDate}', '{purBigo}')
                            ON DUPLICATE KEY UPDATE 
                                cust_id = '{purComp}', cost = {purCost}, dtPayment = '{purPayDate}', bigo = '{purBigo}'";
                m.dbCUD(sql, ref msg);
            }
            {
                string etcComp = cbEtcComp.SelectedValue.ToString();
                //string etcCost = tbEtcCost.Text;
                string etcPayDate = dtEtcPay.Value.ToString("yyyy-MM-dd");

                string etcBigo = rtbEtcBigo.Text;

                sql = $@"INSERT INTO SAL_order_sub_detail (order_id, order_seq, proc_id, cust_id, cost, dtPayment, bigo) 
                                VALUES('{@sOrderID}', {@sSeq}, 5, '{etcComp}', {etcCost}, '{etcPayDate}', '{etcBigo}')
                            ON DUPLICATE KEY UPDATE 
                                cust_id = '{etcComp}', cost = {etcCost}, dtPayment = '{etcPayDate}', bigo = '{etcBigo}'";
                m.dbCUD(sql, ref msg);
                if (msg == "OK")
                lbNotice.Text = "저장되었습니다.";
                ListSearch();
            }



            //////if (!(string.IsNullOrEmpty(pcbQty) || pcbQty == "0"))
            //////{
            //////    string pcbComp = cbPcbComp.SelectedValue.ToString();
            //////    string pcbCost = tbPcbCost.Text;
            //////    string pcbPayDate = dtPcbPay.Value.ToString("yyyy-MM-dd");
            //////    string pcbOrderDate = dtPcbOrder.Value.ToString("yyyy-MM-dd");
            //////    string pcbDueDate = dtPcbDuedate.Value.ToString("yyyy-MM-dd");
            //////    string pcbLayer = tbPcbLayer.Text;
            //////    string pcbThickness = tbPcbTinkness.Text;
            //////    string pcbMaterial = tbPcbMaterial.Text;
            //////    string pcbOCopper = tbPcbOCopper.Text;
            //////    string pcbICopper = tbPcbICopper.Text;
            //////    string pcbSurface = tbPcbSurface.Text;
            //////    string pcbPSR = tbPcbPSR.Text;
            //////    string pcbSILK = tbPcbSILK.Text;
            //////    string pcbSizeW = tbPcbSizeW.Text;
            //////    string pcbSizeL = tbPcbSizeL.Text;
            //////    //string pcbQty = tbPcbQty.Text;
            //////    string pcbUnit = tbPcbUnit.Text;
            //////    string pcbModel = tbPcbModel.Text;
            //////    string pcbImp = tbPcbImp.Text;
            //////    string pcbMetalData = tbPcbMetalData.Text;
            //////    string pcbBigo = rtbPcbBigo.Text;

            //////    sql = $@"INSERT INTO SAL_order_sub_detail (order_id, order_seq, proc_id, cust_id, cost, dtPayment, dtOrder, dtDueDate, qty, unit, layer, thickness, material, size_W, size_L, out_copper, in_copper, surface, PSR, SILK, model, impidance, metaldata, bigo) 
            //////                    VALUES('{@sOrderID}', {@sSeq}, 1, '{pcbComp}', {pcbCost}, '{pcbPayDate}', '{pcbOrderDate}', '{pcbDueDate}', {pcbQty}, '{pcbUnit}', {pcbLayer}, {pcbThickness}, '{pcbMaterial}', '{pcbSizeW}', '{pcbSizeL}', {pcbOCopper}, 
            //////                            {pcbICopper}, '{pcbSurface}', '{pcbModel}', '{pcbPSR}', '{pcbSILK}', '{pcbImp}', '{pcbMetalData}', '{pcbBigo}')
            //////                ON DUPLICATE KEY UPDATE 
            //////                    cust_id = '{pcbComp}', cost = {pcbCost}, dtPayment = '{pcbPayDate}', dtOrder = '{pcbOrderDate}', dtDueDate = '{pcbDueDate}', qty = {pcbQty}, unit = '{pcbUnit}', layer = {pcbLayer}, thickness = {pcbThickness}, 
            //////                    material = '{pcbMaterial}', size_W = '{pcbSizeW}', size_L = '{pcbSizeL}', out_copper = {pcbOCopper}, in_copper = {pcbICopper}, surface = '{pcbSurface}',  PSR = '{pcbPSR}',  SILK = '{pcbSILK}', model = '{pcbModel}', impidance = '{pcbImp}', metaldata = '{pcbMetalData}', bigo = '{pcbBigo}'";
            //////    m.dbCUD(sql, ref msg);

            //////}
            //////if (!(string.IsNullOrEmpty(maskQty) || maskQty == "0"))
            //////{
            //////    string maskComp = cbMaskComp.SelectedValue.ToString();
            //////    string maskCost = tbMaskCost.Text;
            //////    string maskZigCost = tbMaskZigCost.Text;
            //////    string maskPayDate = dtMaskPay.Value.ToString("yyyy-MM-dd");
            //////    string maskOrderDate = dtMaskOrder.Value.ToString("yyyy-MM-dd");
            //////    string maskDueDate = dtMaskDueDate.Value.ToString("yyyy-MM-dd");
            //////    string maskTOP = tbMaskTOP.Text;
            //////    string maskBOT = tbMaskBOT.Text;
            //////    string maskZig = tbMaskZig.Text;
            //////    string maskSizeW = tbMaskSizeW.Text;
            //////    string maskSizeL = tbMaskSizeL.Text;
            //////    //string maskQty = tbMaskQty.Text;
            //////    string maskUnit = tbMaskUnit.Text;
            //////    string maskBigo = rtbMaskBigo.Text;

            //////    sql = $@"INSERT INTO SAL_order_sub_detail (order_id, order_seq, proc_id, cust_id, cost, zig_cost, dtPayment, dtOrder, dtDueDate, qty, unit, TOP, BOTTOM, ZIG, size_W, size_L, bigo) 
            //////                    VALUES('{@sOrderID}', {@sSeq}, 2, '{maskComp}', {maskCost}, {maskZigCost}, '{maskPayDate}', '{maskOrderDate}', '{maskDueDate}', {maskQty}, '{maskUnit}', '{maskTOP}', '{maskBOT}',  '{maskZig}', {maskSizeW}, {maskSizeL},'{maskBigo}')
            //////                ON DUPLICATE KEY UPDATE 
            //////                    cust_id = '{maskComp}', cost = {maskCost}, zig_cost = {maskZigCost}, dtPayment = '{maskPayDate}', dtOrder = '{maskOrderDate}', dtDueDate = '{maskDueDate}', qty = {maskQty}, unit = '{maskUnit}', TOP = '{maskTOP}', BOTTOM = '{maskBOT}', 
            //////                    ZIG = '{maskZig}', size_W = '{maskSizeW}', size_L = '{maskSizeL}', bigo = '{maskBigo}'";
            //////    m.dbCUD(sql, ref msg);

            //////    if (msg == "OK")
            //////        lbNotice.Text = "저장되었습니다.";

            //////}
            //////if (!(string.IsNullOrEmpty(dsnCost) || dsnCost == "0"))
            //////{
            //////    string dsnComp = cbDesignComp.SelectedValue.ToString();
            //////    //string dsnCost = tbDesignCost.Text;
            //////    string dsnPayDate = dtDesignPay.Value.ToString("yyyy-MM-dd");
            //////    string dsnOrderDate = dtDesignStart.Value.ToString("yyyy-MM-dd");
            //////    string dsnDueDate = dtDesignDone.Value.ToString("yyyy-MM-dd");
            //////    string dsnDesigner = tbDesigner.Text;
            //////    string dsnEstiTime = tbDesignEstiTime.Text;
            //////    string dsnWorkTime = tbDesignWorkTime.Text;
            //////    string dsnGubun = tbDesignGubun.Text;
            //////    string dsnSMDpoint = tbSMDpoint.Text;
            //////    string dsnDIPpoint = tbDIPpoint.Text;
            //////    string dsnSMDpin = tbSMDPinCount.Text;
            //////    string dsnDIPpin = tbDIPPinCount.Text;
            //////    string dsnTP = tbDesignTP.Text;
            //////    string dsnSizeW = tbDesignSizeW.Text;
            //////    string dsnSizeL = tbDesignSizeL.Text;
            //////    string dsnBigo = rtbDesignBogo.Text;

            //////    sql = $@"INSERT INTO SAL_order_sub_detail (order_id, order_seq, proc_id, cust_id, cost, dtPayment, dtOrder, dtDueDate, designer, esti_time, work_time, design_gubun, SMDpoint, DIPpoint, SMDpin, DIPpin, TP, size_W, size_L, bigo) 
            //////                    VALUES('{@sOrderID}', {@sSeq}, 3, '{dsnComp}', {dsnCost}, '{dsnPayDate}', '{dsnOrderDate}', '{dsnDueDate}', '{dsnDesigner}', '{dsnEstiTime}', '{dsnWorkTime}', '{dsnGubun}',  {dsnSMDpoint}, {dsnDIPpoint}, {dsnTP},
            //////                            {dsnSMDpin}, {dsnDIPpin}, '{dsnSizeW}', '{dsnSizeL}','{dsnBigo}')
            //////                ON DUPLICATE KEY UPDATE 
            //////                    cust_id = '{dsnComp}', cost = {dsnCost}, dtPayment = '{dsnPayDate}', dtOrder = '{dsnOrderDate}', dtDueDate = '{dsnDueDate}', designer = {maskQty}, esti_time = '{dsnEstiTime}', work_time = '{dsnWorkTime}', design_gubun = '{dsnGubun}', 
            //////                    SMDpoint = {dsnSMDpoint}, DIPpoint = {dsnDIPpoint}, SMDpin = {dsnSMDpin}, DIPpin = {dsnDIPpin},  TP = {dsnTP}, size_W = '{dsnSizeW}', size_L = '{dsnSizeL}', bigo = '{dsnBigo}'";
            //////    m.dbCUD(sql, ref msg);

            //////}
            //////if (!(string.IsNullOrEmpty(purCost) || purCost == "0"))
            //////{
            //////    string purComp = cbPuchseComp.SelectedValue.ToString();
            //////    //string purCost = tbPurchseCost.Text;
            //////    string purPayDate = dtPurchase.Value.ToString("yyyy-MM-dd");

            //////    string purBigo = rtbPuchaseBigo.Text;

            //////    sql = $@"INSERT INTO SAL_order_sub_detail (order_id, order_seq, proc_id, cust_id, cost, dtPayment, bigo) 
            //////                    VALUES('{@sOrderID}', {@sSeq}, 4, '{purComp}', {purCost}, '{purPayDate}', '{purBigo}')
            //////                ON DUPLICATE KEY UPDATE 
            //////                    cust_id = '{purComp}', cost = {purCost}, dtPayment = '{purPayDate}', bigo = '{purBigo}'";
            //////    m.dbCUD(sql, ref msg);

            //////}
            //////if (!(string.IsNullOrEmpty(etcCost) || etcCost == "0"))
            //////{
            //////    string etcComp = cbEtcComp.SelectedValue.ToString();
            //////    //string etcCost = tbEtcCost.Text;
            //////    string etcPayDate = dtEtcPay.Value.ToString("yyyy-MM-dd");

            //////    string etcBigo = rtbEtcBigo.Text;

            //////    sql = $@"INSERT INTO SAL_order_sub_detail (order_id, order_seq, proc_id, cust_id, cost, dtPayment, bigo) 
            //////                    VALUES('{@sOrderID}', {@sSeq}, 5, '{etcComp}', {etcCost}, '{etcPayDate}', '{etcBigo}')
            //////                ON DUPLICATE KEY UPDATE 
            //////                    cust_id = '{etcComp}', cost = {etcCost}, dtPayment = '{etcPayDate}', bigo = '{etcBigo}'";
            //////    m.dbCUD(sql, ref msg);

            //////}


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
