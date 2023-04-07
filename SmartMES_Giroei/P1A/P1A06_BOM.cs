using SmartFactory;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data;
using System.IO;

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
        string sSuju = string.Empty;

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
                //sP_BOM_ListTableAdapter.Fill(dataSetP1A.SP_BOM_List, sSearch, "P0000001");

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

            dataGridView2.CurrentCell = dataGridView2[1, 0];

            string sql = string.Empty;
            string msg = string.Empty;
            MariaCRUD m = new MariaCRUD();

            string sProdID = string.Empty;
            string sMaterialID = string.Empty;
            string sQty = string.Empty;

            string sConsignedYN = string.Empty;
            string sIsSusap = string.Empty;
            string sIsMisap = string.Empty;
            string sContents = string.Empty;
            string sSeq = string.Empty;

            int iCnt = 0;
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                if(dataGridView2.Rows[i].Cells[1].Value.ToString() == "" || string.IsNullOrEmpty(dataGridView2.Rows[i].Cells[1].Value.ToString()))
                {
                    lblMsg.Text = "순번을 입력하세요";
                    break;  
                }
                sSeq = dataGridView2.Rows[i].Cells[1].Value.ToString();
                sProdID = dataGridView2.Rows[i].Cells[2].Value.ToString();
                sMaterialID = dataGridView2.Rows[i].Cells[3].Value.ToString();
                sQty = dataGridView2.Rows[i].Cells[7].Value.ToString();
                sConsignedYN = (dataGridView2.Rows[i].Cells[8].Value.ToString() == "O") ? "Y" : "N";
                sIsSusap = (dataGridView2.Rows[i].Cells[9].Value.ToString() == "O") ? "Y" : "N";
                sIsMisap = (dataGridView2.Rows[i].Cells[10].Value.ToString() == "O") ? "Y" : "N";
                sContents = dataGridView2.Rows[i].Cells[11].Value.ToString();

                if (string.IsNullOrEmpty(sQty)) sQty = "0";

                sql = $@"UPDATE BOM_bomlist SET seq = {@sSeq}, req_qty = {@sQty}, consignedYN = '{@sConsignedYN}', IsSusap = '{sIsSusap}', IsMiSap = '{sIsMisap}', contents = '" + sContents + 
                    "' WHERE prod_id = '" + sProdID + "' AND parent_id = '" + sMaterialID + "'";
                m.dbCUD(sql, ref msg);

                var data = sql;
                var result = await Logger.ApiLog(G.UserID, lblTitle.Text, ActionType.수정, data);

                iCnt++;
            }
            // bom여부 update기능 없어서 추가, BOM 등록일자 칼럼 추가. 12/14
            sql = "UPDATE BAS_product set bomYN = 'Y', bom_dt = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' where prod_id = '" + sProdID + "'";
            m.dbCUD(sql, ref msg);

            m.TransLogCreate(G.Authority, G.UserID, "M", this.Name, lblTitle.Text, sProdID + " " + iCnt.ToString() + "건");
            lblMsg.Text = "저장되었습니다.";

            dataGridView2.CurrentCell = null;

            ListSearch1("save");
            ListSearch2("");
            ListSearch3("");

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
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("선택된 품목이 없습니다");

                    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[2];

                    return;
                }

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
            if (e.RowIndex < 0 || e.ColumnIndex == 8) return;

            CurrentCellRowIndex = e.RowIndex;

            sProdID = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            sProdName = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            ListSearch2(sProdID);
            tbSearch3.Text = "";
            ListSearch3(sProdID);
        }
        private async void dataGridView2_DragDrop(object sender, DragEventArgs e)
        {
            if (dragTag != 3) return;

            if (dataGridView1.CurrentCell == null ||dataGridView1.CurrentCell.RowIndex < 0) return;

            if (e.Effect == DragDropEffects.Copy)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                int iSeq = 0; string sSeq = string.Empty;
                string sPCode = dataGridView1.Rows[index].Cells[2].Value.ToString();
                string sMCode = (string)e.Data.GetData(DataFormats.StringFormat);

                if (dataGridView2.RowCount > 0)
                {
                    int idx = dataGridView2.RowCount - 1;
                    iSeq = Int32.Parse(dataGridView2.Rows[idx].Cells[1].Value.ToString());
                    iSeq += 1;
                }
                else iSeq = 1; // sSeq = "1";

                string sql = "INSERT INTO BOM_bomlist (prod_id, parent_id, seq, req_qty) " +
                    "VALUES('" + sPCode + "','" + sMCode + "'," + iSeq + ",1)";

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
                    string sCode = dataGridView2.Rows[rowIndexFromMouseDown].Cells[3].Value.ToString();

                    DragDropEffects dropEffect = dataGridView2.DoDragDrop(sCode, DragDropEffects.Copy);
                }
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex < 8 || e.ColumnIndex > 10) return;

            dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == "O") ? "X" : "O";
        }
        private void dataGridView3_DragDrop(object sender, DragEventArgs e)
        {
            if (dragTag != 2) return;

            if (dataGridView1.CurrentCell == null || dataGridView1.CurrentCell.RowIndex < 0) return;

            if (e.Effect == DragDropEffects.Copy)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                string sPCode = dataGridView1.Rows[index].Cells[2].Value.ToString();
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
            string sSusap = string.Empty; string sMisap = string.Empty;
            string sContents = string.Empty; string sKind = string.Empty; /*(P,M,S)*/ string sProdKind = string.Empty; /*품목분류 */
            string sConsign = "N"; /*사급도급*/ string sSeq = string.Empty;

            string sFileName = string.Empty;
            OpenFileDialog ofg = new OpenFileDialog();

            //ofg.Filter = "Excel File 97~2013(*.xls)| *.xls| *.xlsx|*.xlsx| All Files(*.*)|*.*";
            ofg.Filter = "Excel File *.xls| *.xlsx| 97~2013(*.xls)|*.xlsx| All Files(*.*)|*.*"; //양식 액셀이 바로 나오게 수정

            if (ofg.ShowDialog() == DialogResult.OK)
            {
                sFileName = ofg.FileName;
                //MessageBox.Show("sFileName : " + sFileName);
            }
            else       // 1/3/23 취소 경우 
            {
                return;
            }

            try
            {

                excelApp = new Excel.Application(); // 엑셀 어플리케이션 생성 

                workBook = excelApp.Workbooks.Open(ofg.FileName); // 워크북 열기 

                workSheet = workBook.Worksheets.get_Item(1) as Excel.Worksheet; // 엑셀 첫번째 워크시트 가져오기 
                range = workSheet.UsedRange; // 사용중인 셀 범위를 가져오기

                if ((range.Cells[4, 4] as Excel.Range).Value2.ToString().Trim() != sProdName)
                {
                    if (DialogResult.OK == MessageBox.Show("해당 품목의 BOM 엑셀 파일이 아니거나,\r품목명이 일치하지 않습니다.", "엑셀 파일 확인이 필요합니다", MessageBoxButtons.OK, MessageBoxIcon.Warning))
                    {
                        return;
                    }
                    workBook.Close();
                    excelApp.Quit();
                    return;
                }

                progressBar1.Visible = true;

                int count = 0;

                for (int row = 8; row <= range.Rows.Count; row++) // 가져온 행 만큼 반복
                {
                    if ((range.Cells[row, 5] as Excel.Range).Value2 == null || string.IsNullOrEmpty((range.Cells[row, 5] as Excel.Range).Value2.ToString().Trim())) break;
                    
                    //sSeq = (range.Cells[row, 1] as Excel.Range).Value2.ToString().Trim();  // 순번
                    //sKind = (range.Cells[row, 4] as Excel.Range).Value2.ToString().Trim();  // 품목구분
                    //if ((range.Cells[row, 4] as Excel.Range).Value2.ToString().Trim() == "-") sKind = "S";
                    //sProdKind = (range.Cells[row, 2] as Excel.Range).Value2.ToString().Trim();  // 품목분류
                    //sProdNameSub = (range.Cells[row, 6] as Excel.Range).Value2.ToString().Trim();   // 자재명
                    //sProdSize = (range.Cells[row, 7] as Excel.Range).Value2.ToString().Trim();
                    //sQty = (range.Cells[row, 8] as Excel.Range).Value2.ToString().Trim();
                    //sContents = ((range.Cells[row, 15] as Excel.Range).Value2 == null) ? "" : (range.Cells[row, 15] as Excel.Range).Value2.ToString().Trim();
                    //sMisap = ((range.Cells[row, 14] as Excel.Range).Value2 == null) ? "" : (range.Cells[row, 14] as Excel.Range).Value2.ToString().Trim();   // 미삽
                    //sSusap = ((range.Cells[row, 18] as Excel.Range).Value2 == null) ? "" : (range.Cells[row, 18] as Excel.Range).Value2.ToString().Trim();    // 수삽
                    //string sSageop = ((range.Cells[row, 17] as Excel.Range).Value2 == null) ? "도급" : (range.Cells[row, 17] as Excel.Range).Value2.ToString().Trim();    // 사급

                    sSeq = (range.Cells[row, 1] as Excel.Range).Value2.ToString().Trim();  // 순번
                    sKind = (range.Cells[row, 3] as Excel.Range).Value2.ToString().Trim();  // 품목구분
                    if ((range.Cells[row, 3] as Excel.Range).Value2.ToString().Trim() == "-") sKind = "S";
                    sProdKind = (range.Cells[row, 2] as Excel.Range).Value2.ToString().Trim();  // 품목분류
                    sProdNameSub = (range.Cells[row, 5] as Excel.Range).Value2.ToString().Trim();   // 자재명
                    sProdSize = (range.Cells[row, 6] as Excel.Range).Value2.ToString().Trim();
                    sQty = (range.Cells[row, 7] as Excel.Range).Value2.ToString().Trim();
                    sContents = ((range.Cells[row, 14] as Excel.Range).Value2 == null) ? "" : (range.Cells[row, 14] as Excel.Range).Value2.ToString().Trim();
                    sMisap = ((range.Cells[row, 13] as Excel.Range).Value2 == null) ? "" : (range.Cells[row, 13] as Excel.Range).Value2.ToString().Trim();   // 미삽
                    sSusap = ((range.Cells[row, 17] as Excel.Range).Value2 == null) ? "" : (range.Cells[row, 17] as Excel.Range).Value2.ToString().Trim();    // 수삽
                    string sSageop = ((range.Cells[row, 16] as Excel.Range).Value2 == null) ? "도급" : (range.Cells[row, 16] as Excel.Range).Value2.ToString().Trim();    // 사급
                    //sConsign = (range.Cells[row, 17] as Excel.Range).Value2.ToString().Trim();    // 도급(N)/사급(Y)
                    if (sSageop == "사급")
                    {
                        sConsign = "Y";
                    }
                    else
                    {
                        sConsign = "N";
                    }

                    //if (sProcess == "수삽") sProcess = "S";
                    //else if (sProcess == "미삽") sProcess = "M";
                    //else sProcess = "X";
                    // SELECT c.co_code, c.co_item, p.prod_id, p.prod_kind FROM BAS_common c LEFT JOIN BAS_product p ON p.prod_kind = c.co_code WHERE c.co_kind = 'C' AND c.co_item = 'TR'
                    //sql = $@"SELECT co_code, co_item FROM BAS_common WHERE co_kind = 'C' AND prod_name = '{@sProdKind}' ORDER BY prod_id DESC LIMIT 1";

                    //if (m.dbDataTable(sql, ref msg).Rows.Count == 0)

                    sql = $@"SELECT prod_name FROM BAS_product WHERE gubun = 'M' AND prod_name = '{@sProdNameSub}' ORDER BY prod_id DESC LIMIT 1";

                    if (m.dbDataTable(sql, ref msg).Rows.Count == 0)
                    {
                        sql = $@"SELECT DISTINCT c.co_code, c.co_item FROM BAS_common c LEFT JOIN BAS_product p ON p.prod_kind = c.co_code WHERE c.co_kind = 'C' AND c.co_item = '{@sProdKind}'";
                        string sProdKindCode = m.dbDataTable(sql, ref msg).Rows[0][0].ToString();

                        sProdIDSub = getProdCode(sKind);

                        sql = $@"INSERT INTO BAS_product (gubun, prod_id, prod_kind, prod_name, prod_size, consignedYN, enter_man) 
                                VALUES ('M', '{@sProdIDSub}', '{@sProdKindCode}', '{@sProdNameSub}', '{@sProdSize}', '{@sConsign}', '{@G.UserID}');";
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
                        string Misap = "N", Susap = "N";
                        if (sMisap == "미삽" && string.IsNullOrEmpty(sSusap))
                        {
                            Misap = "Y";
                        }
                        else if (sSusap == "수삽" && (string.IsNullOrEmpty(sMisap) || sMisap != "미삽"))
                        {
                            Susap = "Y";
                        }

                        sql = $@"INSERT INTO BOM_bomlist (seq, prod_id, parent_id, req_qty, IsSusap, IsMiSap, contents, consignedYN) VALUES ('{@sSeq}', '{@_sProdID}', '{@sProdIDSub}', '{@sQty}', '{Susap}', '{Misap}', '{sContents}', '{@sConsign}');";
                        m.dbCUD(sql, ref msg);
                    }
                    else
                    {
                        string Misap = "N", Susap = "N";
                        if (sMisap == "미삽" && string.IsNullOrEmpty(sSusap))
                        {
                            Misap = "Y";
                        }
                        else if (sSusap == "수삽" && (string.IsNullOrEmpty(sMisap) || sMisap != "미삽"))
                        {
                            Susap = "Y";
                        }

                        sql = $@"UPDATE BOM_bomlist SET consignedYN = '{@sConsign}', IsSusap = '{Susap}', IsMiSap = '{Misap}', contents = '{sContents}' WHERE prod_id = '{@_sProdID}' AND parent_id = '{@sProdIDSub}'";
                        m.dbCUD(sql, ref msg);
                    }
                    int ratio = (int)Math.Round((count * 100) / ((double)range.Rows.Count - 8.0));
                    progressBar1.Value = (ratio > 100) ? 100 : ratio;
                    count = count + 1;

                    sql = "update BAS_product set bomYN = 'Y', bom_dt = now() where prod_id = '" + _sProdID + "'";
                    m.dbCUD(sql, ref msg);

                }
                progressBar1.Value = 0;
                progressBar1.Visible = false;
                ListSearch1("");
                ListSearch2(_sProdID);
                ListSearch3(_sProdID);

            }
            catch (Exception e2)
            {
                return;
            }
            finally
            {
                workBook.Close(true);
                excelApp.Quit();

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
        private void btnExcelbasic_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            string srcFile = @"Giroel_BOM.xlsx";
            string destFile = string.Empty;

            saveFileDialog1.FileName = "Giroel_BOM" + ".xlsx"; //초기 파일명을 지정할 때 사용
            saveFileDialog1.InitialDirectory = @"C:";
            saveFileDialog1.Title = "Excel 서식 저장";
            saveFileDialog1.DefaultExt = "xls";
            saveFileDialog1.Filter = "Xlsx files(*.xlsx)|*.xlsx";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                destFile = saveFileDialog1.FileName;
            }
            else
            {
                return;
            }
            saveFileDialog1.Dispose();
            File.Copy(srcFile, destFile, true);

            MessageBox.Show("설정하신 경로로 BOM 엑셀 파일이 저장 되었습니다."); //새로 엑셀파일 교체 후 배포버전에서 양식다운로드가 되지 않는다면 항상복사 및 빌드작업 내용을 설정헀는지 확인이 필요합니다.
        }

        private void dataGridView_ExportToExcel(string fileName, DataGridView dgv) 
        {
            //Excel.Application excelApp = new Excel.Application();
            //if (excelApp == null) {
            //    MessageBox.Show("엑셀이 설치되지 않았습니다");
            //    return;
            //}
            //Excel.Workbook wb = excelApp.Workbooks.Add(true);
            //Excel._Worksheet workSheet = wb.Worksheets.get_Item(1) as Excel._Worksheet;
            //workSheet.Name = "EXCELDOWN_소일정계획";

            //if (dgv.Rows.Count == 0) {
            //    MessageBox.Show("출력할 데이터가 없습니다");
            //    return;
            //}

            //// 헤더 출력
            //for (int i = 0; i < dgv.Columns.Count; i++) {
            //    workSheet.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
            //}

            ////내용 출력
            //for (int r = 0; r < dgv.Rows.Count; r++) {
            //    for (int i = 0; i < dgv.Columns.Count; i++) {
            //        workSheet.Cells[r + 2, i + 1] = dgv.Rows[r].Cells[i].Value;
            //    }
            //}

            //workSheet.Columns.AutoFit(); // 글자 크기에 맞게 셀 크기를 자동으로 조절 


            //// 엑셀 2003 으로만 저장이 됨
            //wb.SaveAs(fileName, Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            //    Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            //wb.Close(Type.Missing, Type.Missing, Type.Missing);
            //excelApp.Quit();
            //ReleaseObject(excelApp);
            //ReleaseObject(workSheet);
            //ReleaseObject(wb);


            //MessageBox.Show(fileName + " 엑셀 내보내기 완료");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                CurrentCellRowIndex = e.RowIndex;

                sSuju = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

                P1A06_BOM_Suju sub = new P1A06_BOM_Suju();
                sub.rowIndex = e.RowIndex;
                sub.parentWin = this;
                sub.ShowDialog();
            }
        }
    }
}
