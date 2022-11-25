using SmartFactory;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data;

namespace SmartMES_Giroei
{
    public partial class P1A06_BOM : SmartMES_Giroei.FormBasic
    {
        static Excel.Application excelApp = null;
        static Excel.Workbook workBook = null;
        static Excel.Worksheet workSheet = null;
        static Excel.Range range = null;

        private System.Drawing.Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int dragTag;

        int CurrentCellRowIndex = 0;

        string sProdID = string.Empty;
        string sProdName = string.Empty;

        public P1A06_BOM()
        {
            InitializeComponent();
        }
        private void P1A06_BOM_Load(object sender, EventArgs e)
        {
            ListSearch1("");
            ListSearch3("");
            this.ActiveControl = tbSearch1;
        }

        #region ListSearch
        public async void ListSearch1(string gubun)
        {
            if (gubun != "save") lblMsg.Text = "";

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string sSearch = tbSearch1.Text.Trim();
                sP_BOM_QueryTableAdapter.Fill(dataSetP1A.SP_BOM_Query, sSearch);

                var data = dataSetP1A.SP_BOM_Query;
                var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

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
        public async void ListSearch2(string sProd)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                lblMsg.Text = "";
                sP_BOM_SelectTableAdapter.Fill(dataSetP1A.SP_BOM_Select, sProd);

                var data = dataSetP1A.SP_BOM_Select;
                var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

                dataGridView2.CurrentCell = null;
                dataGridView2.ClearSelection();
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
        public async void ListSearch3(string sProd)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                lblMsg.Text = "";

                string sSearch = tbSearch3.Text.Trim();

                sP_BOM_ListTableAdapter.Fill(dataSetP1A.SP_BOM_List, sSearch, sProd);

                var data = dataSetP1A.SP_BOM_List;
                var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.조회, data);

                dataGridView3.CurrentCell = null;
                dataGridView3.ClearSelection();
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
        #endregion

        #region Button Events
        private void pbSearch_Click(object sender, EventArgs e)
        {
            ListSearch1("");
            ListSearch2("");
            ListSearch3("");
        }
        private void pbAdd_Click(object sender, EventArgs e)
        {
            //
        }
        private void pbDel_Click(object sender, EventArgs e)
        {
            //
        }
        private async void pbSave_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (G.Authority == "D") return;

            if (dataGridView2.Rows.Count < 1)
            {
                lblMsg.Text = "구성품 리스트가 존재하지 않습니다.";
                return;
            }

            dataGridView2.CurrentCell = dataGridView2[0, 0];

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            string sProdID = string.Empty;
            string sMaterialID = string.Empty;
            string sQty = string.Empty;

            string sConsignedYN = string.Empty;
            string sIsSusap = string.Empty;
            string sIsMisap = string.Empty;

            int iCnt = 0;
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                sProdID = dataGridView2.Rows[i].Cells[1].Value.ToString();
                sMaterialID = dataGridView2.Rows[i].Cells[2].Value.ToString();
                sQty = dataGridView2.Rows[i].Cells[6].Value.ToString();
                sConsignedYN = (dataGridView2.Rows[i].Cells[8].Value.ToString() == "1") ? "Y" : "N";
                sIsSusap = (dataGridView2.Rows[i].Cells[9].Value.ToString() == "O") ? "Y" : "N";
                sIsMisap = (dataGridView2.Rows[i].Cells[10].Value.ToString() == "O") ? "Y" : "N";

                if (string.IsNullOrEmpty(sQty)) sQty = "0";

                sql = $@"UPDATE BOM_bomlist SET req_qty = {@sQty}, consignedYN = '{@sConsignedYN}', IsSusap = '{sIsSusap}', IsMiSap = '{sIsMisap}' WHERE prod_id = '{@sProdID}' AND parent_id = '{@sMaterialID}'";

                m.dbCUD(sql, ref msg);

                var data = sql;
                var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);

                iCnt++;
            }

            m.TransLogCreate(G.Authority, G.UserID, "M", this.Name, lblTitle.Text, sProdID + " " + iCnt.ToString() + "건");
            lblMsg.Text = "저장되었습니다.";

            dataGridView2.CurrentCell = null;

            ListSearch1("save");

            dataGridView1.CurrentCell = dataGridView1[0, CurrentCellRowIndex];
            dataGridView1.Rows[CurrentCellRowIndex].Selected = true;
        }
        private void pbPrint_Click(object sender, EventArgs e)
        {
            //
        }
        #endregion

        #region Condition Bar Events
        private void tbSearch1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListSearch1("");
                ListSearch2("-");
                tbSearch3.Text = "";
                ListSearch3("-");
            }
        }
        private void tbSearch3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int index = dataGridView1.CurrentRow.Index;
                if (index < 0) return;

                string sProd = dataGridView1.Rows[index].Cells[1].Value.ToString();
                ListSearch3(sProd);
            }
        }
        #endregion

        #region GridView Events
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            CurrentCellRowIndex = e.RowIndex;

            sProdID = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            sProdName = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            ListSearch2(sProdID);
            tbSearch3.Text = "";
            ListSearch3(sProdID);
        }
        private async void dataGridView2_DragDrop(object sender, DragEventArgs e)
        {
            if (dragTag != 3) return;

            if (dataGridView1.CurrentCell == null ||
                    dataGridView1.CurrentCell.RowIndex < 0) return;

            if (e.Effect == DragDropEffects.Copy)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                string sPCode = dataGridView1.Rows[index].Cells[1].Value.ToString();
                string sMCode = (string)e.Data.GetData(DataFormats.StringFormat);

                string sql = "INSERT INTO BOM_bomlist (prod_id, parent_id, req_qty) " +
                    "VALUES('" + sPCode + "', '" + sMCode + "', 1)";

                string msg = string.Empty;

                MariaCRUD m = new MariaCRUD();
                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    MessageBox.Show(msg);
                    return;
                }

                var data = sql;
                var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.등록, data);

                ListSearch2(sPCode);
                ListSearch3(sPCode);
            }
        }
        private void dataGridView2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            rowIndexFromMouseDown = dataGridView2.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                Size dragSize = SystemInformation.DragSize;

                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                                        dragSize);
            }
            else
            {
                dragBoxFromMouseDown = Rectangle.Empty;
            }
        }
        private void dataGridView2_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    dragTag = 2;
                    string sCode = dataGridView2.Rows[rowIndexFromMouseDown].Cells[2].Value.ToString();

                    DragDropEffects dropEffect = dataGridView2.DoDragDrop(sCode, DragDropEffects.Copy);
                }
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0) return;

            ////if (e.ColumnIndex != 6) return;

            ////MessageBox.Show("" + e.ColumnIndex);

            //if (e.ColumnIndex == 8)
            //{
            //    if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == "1")
            //        dataGridView2[9, e.RowIndex].Style.ForeColor = Color.Black;
            //    else
            //        dataGridView2[9, e.RowIndex].Style.ForeColor = Color.Transparent;

            //    dataGridView2.CurrentCell = null;
            //    dataGridView2.ClearSelection();
            //}
        }
        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Cells[7].Value == null)
                    dataGridView2.Rows[i].Cells[8].Value = 0;
                else
                {
                    if (dataGridView2.Rows[i].Cells[7].Value.ToString() == "Y")
                    {
                        dataGridView2.Rows[i].Cells[8].Value = 1;
                    }
                    else
                        dataGridView2.Rows[i].Cells[8].Value = 0;
                }

                if (dataGridView2.Rows[i].Cells[9].Value.ToString() == "Y")
                {
                    dataGridView2.Rows[i].Cells[9].Value = "O";
                }
                else if (dataGridView2.Rows[i].Cells[9].Value.ToString() == "N")
                {
                    dataGridView2.Rows[i].Cells[9].Value = "X";
                }

                if (dataGridView2.Rows[i].Cells[10].Value.ToString() == "Y")
                {
                    dataGridView2.Rows[i].Cells[10].Value = "O";
                }
                else if (dataGridView2.Rows[i].Cells[10].Value.ToString() == "N")
                {
                    dataGridView2.Rows[i].Cells[10].Value = "X";
                }
            }
        }
        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView2.Rows.Count == 0) return;

            //if (e.ColumnIndex == 8)
            //{
            //    if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == "1")
            //        dataGridView2[9, e.RowIndex].Style.ForeColor = Color.Transparent;
            //    else
            //        dataGridView2[9, e.RowIndex].Style.ForeColor = Color.Black;
            //}
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 8)
            //{
            //    if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "1")
            //        dataGridView2[9, e.RowIndex].Style.ForeColor = Color.Black;
            //    else
            //        dataGridView2[9, e.RowIndex].Style.ForeColor = Color.Transparent;

            //    dataGridView2.CurrentCell = null;
            //    dataGridView2.ClearSelection();
            //}
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex < 9 || e.ColumnIndex > 10) return;

            dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == "O") ? "X" : "O";
        }
        private void dataGridView3_DragDrop(object sender, DragEventArgs e)
        {
            if (dragTag != 2) return;

            if (dataGridView1.CurrentCell == null ||
                    dataGridView1.CurrentCell.RowIndex < 0) return;

            if (e.Effect == DragDropEffects.Copy)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                string sPCode = dataGridView1.Rows[index].Cells[1].Value.ToString();
                string sMCode = (string)e.Data.GetData(DataFormats.StringFormat);

                string sql = "DELETE FROM BOM_bomlist WHERE " +
                    "prod_id = '" + sPCode + "' AND parent_id = '" + sMCode + "'";

                string msg = string.Empty;
                MariaCRUD m = new MariaCRUD();
                m.dbCUD(sql, ref msg);

                if (msg != "OK")
                {
                    MessageBox.Show(msg);
                    return;
                }

                ListSearch2(sPCode);
                ListSearch3(sPCode);
            }
        }
        private void dataGridView3_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void dataGridView3_MouseDown(object sender, MouseEventArgs e)
        {
            rowIndexFromMouseDown = dataGridView3.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                Size dragSize = SystemInformation.DragSize;

                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                                        dragSize);
            }
            else
            {
                dragBoxFromMouseDown = Rectangle.Empty;
            }
        }
        private void dataGridView3_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    dragTag = 3;
                    string sCode = dataGridView3.Rows[rowIndexFromMouseDown].Cells[1].Value.ToString();

                    DragDropEffects dropEffect = dataGridView3.DoDragDrop(sCode, DragDropEffects.Copy);
                }
            }
        }
        #endregion

        #region Excel
        private void btnExcel_Click(object sender, EventArgs e)
        {
            MariaCRUD m = new MariaCRUD();

            DataTable table;

            string sql = string.Empty;
            string msg = string.Empty;

            string sOrderNo = string.Empty;

            string _sProdName = sProdName;
            string _sProdID = sProdID;
            string sProdNameSub = string.Empty;
            string sProdIDSub = string.Empty;
            string sProdSize = string.Empty;
            string sQty = string.Empty;
            string sProcess = string.Empty;

            try
            {
                string sFileName = string.Empty;
                OpenFileDialog ofg = new OpenFileDialog();

                ofg.Filter = "Excel File 97~2013(*.xls)| *.xls| *.xlsx|*.xlsx| All Files(*.*)|*.*";

                if (ofg.ShowDialog() == DialogResult.OK)
                {
                    sFileName = ofg.FileName;
                    //MessageBox.Show("sFileName : " + sFileName);
                }

                excelApp = new Excel.Application(); // 엑셀 어플리케이션 생성 

                workBook = excelApp.Workbooks.Open(ofg.FileName); // 워크북 열기 

                workSheet = workBook.Worksheets.get_Item(1) as Excel.Worksheet; // 엑셀 첫번째 워크시트 가져오기 
                range = workSheet.UsedRange; // 사용중인 셀 범위를 가져오기

                //sOrderNo = (range.Cells[2, 4] as Excel.Range).Value2.ToString();
                //sProdName = (range.Cells[4, 4] as Excel.Range).Value2.ToString();

                //sql = $@"SELECT prod_id, prod_name FROM BAS_product WHERE gubun = 'P' AND prod_name = '{@sProdName}' ORDER BY prod_id DESC LIMIT 1";

                //if (m.dbDataTable(sql, ref msg).Rows.Count == 0)
                //{
                //    sProdID = getProdCode("P");

                //    sql = $@"INSERT INTO BAS_product (gubun, prod_id, prod_name) VALUES ('P', '{@sProdID}', '{@sProdName}');";

                //    m.dbCUD(sql, ref msg);
                //}
                //else
                //{
                //    sProdID = m.dbDataTable(sql, ref msg).Rows[0][0].ToString();
                //}

                if ((range.Cells[4, 3] as Excel.Range).Value2.ToString() != sProdName)
                {
                    MessageBox.Show("해당 품목의 BOM 엑셀 파일이 아닙니다.");
                    return;
                }

                for (int row = 8; row <= range.Rows.Count; row++) // 가져온 행 만큼 반복
                {
                    if ((range.Cells[row, 5] as Excel.Range).Value2 == null
                        || string.IsNullOrEmpty((range.Cells[row, 5] as Excel.Range).Value2.ToString())) break;

                    sProdNameSub = (range.Cells[row, 4] as Excel.Range).Value2.ToString();
                    sProdSize = (range.Cells[row, 5] as Excel.Range).Value2.ToString();
                    sQty = (range.Cells[row, 6] as Excel.Range).Value2.ToString();
                    sProcess = ((range.Cells[row, 15] as Excel.Range).Value2 == null) ? "" : (range.Cells[row, 15] as Excel.Range).Value2.ToString();

                    //if (sProcess == "수삽") sProcess = "S";
                    //else if (sProcess == "미삽") sProcess = "M";
                    //else sProcess = "X";

                    sql = $@"SELECT prod_name FROM BAS_product WHERE gubun = 'M' AND prod_name = '{@sProdNameSub}' ORDER BY prod_id DESC LIMIT 1";

                    if (m.dbDataTable(sql, ref msg).Rows.Count == 0)
                    {
                        sProdIDSub = getProdCode("M");

                        sql = $@"INSERT INTO BAS_product (gubun, prod_id, prod_kind, prod_name, prod_size, consignedYN, enter_man) VALUES ('M', '{@sProdIDSub}', '0001', '{@sProdNameSub}', '{@sProdSize}', 'Y', '{@G.UserID}');";

                        m.dbCUD(sql, ref msg);
                    }
                    else
                    {
                        _sProdName = m.dbDataTable(sql, ref msg).Rows[0][0].ToString();

                        sql = $@"SELECT prod_id FROM BAS_product WHERE gubun = 'M' AND prod_name = '{@_sProdName}' ORDER BY prod_id DESC LIMIT 1";
                        sProdIDSub = m.dbDataTable(sql, ref msg).Rows[0][0].ToString();
                    }

                    sql = $@"SELECT prod_id, parent_id FROM BOM_bomlist WHERE prod_id = '{@_sProdID}' AND parent_id = '{@sProdIDSub}' ORDER BY prod_id";

                    if (m.dbDataTable(sql, ref msg).Rows.Count == 0)
                    {
                        if (sProcess == "수삽")
                        {
                            sql = $@"INSERT INTO BOM_bomlist (prod_id, parent_id, req_qty, IsSusap, IsMiSap) VALUES ('{@_sProdID}', '{@sProdIDSub}', '{@sQty}', 'Y', 'N');";
                        }
                        else if (sProcess == "미삽")
                        {
                            sql = $@"INSERT INTO BOM_bomlist (prod_id, parent_id, req_qty, IsSusap, IsMiSap) VALUES ('{@_sProdID}', '{@sProdIDSub}', '{@sQty}', 'N', 'Y');";
                        }
                        else
                        {
                            sql = $@"INSERT INTO BOM_bomlist (prod_id, parent_id, req_qty, IsSusap, IsMiSap) VALUES ('{@_sProdID}', '{@sProdIDSub}', '{@sQty}', 'N', 'N');";
                        }

                        m.dbCUD(sql, ref msg);
                    }
                    else
                    {
                        if (sProcess == "수삽")
                        {
                            sql = $@"UPDATE BOM_bomlist SET IsSusap = 'Y', IsMiSap = 'N' WHERE prod_id = '{@_sProdID}' AND parent_id = '{@sProdIDSub}'";
                        }
                        else if (sProcess == "미삽")
                        {
                            sql = $@"UPDATE BOM_bomlist SET IsSusap = 'N', IsMiSap = 'Y' WHERE prod_id = '{@_sProdID}' AND parent_id = '{@sProdIDSub}'";
                        }
                        else
                        {
                            sql = $@"UPDATE BOM_bomlist SET IsSusap = 'N', IsMiSap = 'N' WHERE prod_id = '{@_sProdID}' AND parent_id = '{@sProdIDSub}'";
                        }

                        m.dbCUD(sql, ref msg);
                    }
                }

                ListSearch1("");
                ListSearch2(_sProdID);
                ListSearch3(_sProdID);

            }
            catch (Exception e2)
            {
                //MessageBox.Show("WHY : " + e2.Message);
            }
            finally
            {
                ReleaseObject(workSheet);
                ReleaseObject(workBook);
                ReleaseObject(excelApp);
            }
        }
        static void ReleaseObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj); // 액셀 객체 해제 
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect(); // 가비지 수집

            }
        }
        private string getProdCode(string _gubun)
        {
            string sql = @"select UF_ProdCodeGenerator('" + _gubun + "')";

            MariaCRUD m = new MariaCRUD();

            string msg = string.Empty;
            return m.dbRonlyOne(sql, ref msg).ToString();
        }
        #endregion
    }
}
