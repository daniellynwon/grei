namespace SmartMES_Giroei
{
    partial class P1C09_PROD_NG_RESULT
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P1C09_PROD_NG_RESULT));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panSearch = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sPProdDefectResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetP1C = new SmartMES_Giroei.P1C.DataSetP1C();
            this.sP_Prod_Defect_ResultTableAdapter = new SmartMES_Giroei.P1C.DataSetP1CTableAdapters.SP_Prod_Defect_ResultTableAdapter();
            this.작업지시번호DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수주번호DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수주순번DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.품목코드DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.품목명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.작업장DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.작업라인DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.공정번호DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.생산책임자DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.작업지시수량DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.작업시작시간DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.작업종료시간DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.불량IDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.작지시퀀스DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.검사코드DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.검사항목DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.검사일자DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.불합격수량DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.귀책부서코드DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.귀책부서DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.비고DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.panSearch.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPProdDefectResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1C)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "공정불량현황";
            // 
            // pbPrint
            // 
            this.pbPrint.Enabled = true;
            this.pbPrint.Image = global::SmartMES_Giroei.Properties.Resources.out_A;
            this.pbPrint.Click += new System.EventHandler(this.pbPrint_Click);
            // 
            // pbSave
            // 
            this.pbSave.Image = ((System.Drawing.Image)(resources.GetObject("pbSave.Image")));
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            // 
            // pbDel
            // 
            this.pbDel.Enabled = false;
            this.pbDel.Image = global::SmartMES_Giroei.Properties.Resources.del_B;
            this.pbDel.Click += new System.EventHandler(this.pbDel_Click);
            // 
            // pbAdd
            // 
            this.pbAdd.Enabled = false;
            this.pbAdd.Image = global::SmartMES_Giroei.Properties.Resources.add_B;
            this.pbAdd.Click += new System.EventHandler(this.pbAdd_Click);
            // 
            // pbSearch
            // 
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            // 
            // panSearch
            // 
            this.panSearch.AutoSize = true;
            this.panSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.panSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSearch.Controls.Add(this.lblMsg);
            this.panSearch.Controls.Add(this.label1);
            this.panSearch.Controls.Add(this.label4);
            this.panSearch.Controls.Add(this.dtpToDate);
            this.panSearch.Controls.Add(this.dtpFromDate);
            this.panSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panSearch.Location = new System.Drawing.Point(3, 3);
            this.panSearch.Name = "panSearch";
            this.panSearch.Size = new System.Drawing.Size(1319, 65);
            this.panSearch.TabIndex = 0;
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(581, 23);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(148, 21);
            this.lblMsg.TabIndex = 17;
            this.lblMsg.Text = "메시지 라벨입니다.";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(337, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "~";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(40, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 12;
            this.label4.Text = "작업일자";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpToDate.CalendarFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpToDate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpToDate.Location = new System.Drawing.Point(364, 17);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(211, 29);
            this.dtpToDate.TabIndex = 14;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpFromDate.CalendarFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpFromDate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpFromDate.Location = new System.Drawing.Point(120, 17);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(211, 29);
            this.dtpFromDate.TabIndex = 13;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panSearch, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 56);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1325, 934);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.작업지시번호DataGridViewTextBoxColumn,
            this.수주번호DataGridViewTextBoxColumn,
            this.수주순번DataGridViewTextBoxColumn,
            this.품목코드DataGridViewTextBoxColumn,
            this.품목명DataGridViewTextBoxColumn,
            this.작업장DataGridViewTextBoxColumn,
            this.작업라인DataGridViewTextBoxColumn,
            this.공정번호DataGridViewTextBoxColumn,
            this.생산책임자DataGridViewTextBoxColumn,
            this.작업지시수량DataGridViewTextBoxColumn,
            this.작업시작시간DataGridViewTextBoxColumn,
            this.작업종료시간DataGridViewTextBoxColumn,
            this.불량IDDataGridViewTextBoxColumn,
            this.작지시퀀스DataGridViewTextBoxColumn,
            this.검사코드DataGridViewTextBoxColumn,
            this.검사항목DataGridViewTextBoxColumn,
            this.검사일자DataGridViewTextBoxColumn,
            this.불합격수량DataGridViewTextBoxColumn,
            this.귀책부서코드DataGridViewTextBoxColumn,
            this.귀책부서DataGridViewTextBoxColumn,
            this.비고DataGridViewTextBoxColumn});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView1.DataSource = this.sPProdDefectResultBindingSource;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(3, 74);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 35;
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1319, 857);
            this.dataGridView1.TabIndex = 13;
            // 
            // sPProdDefectResultBindingSource
            // 
            this.sPProdDefectResultBindingSource.DataMember = "SP_Prod_Defect_Result";
            this.sPProdDefectResultBindingSource.DataSource = this.dataSetP1C;
            // 
            // dataSetP1C
            // 
            this.dataSetP1C.DataSetName = "DataSetP1C";
            this.dataSetP1C.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sP_Prod_Defect_ResultTableAdapter
            // 
            this.sP_Prod_Defect_ResultTableAdapter.ClearBeforeFill = true;
            // 
            // 작업지시번호DataGridViewTextBoxColumn
            // 
            this.작업지시번호DataGridViewTextBoxColumn.DataPropertyName = "작업지시번호";
            this.작업지시번호DataGridViewTextBoxColumn.FillWeight = 110F;
            this.작업지시번호DataGridViewTextBoxColumn.HeaderText = "JobNo";
            this.작업지시번호DataGridViewTextBoxColumn.Name = "작업지시번호DataGridViewTextBoxColumn";
            this.작업지시번호DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 수주번호DataGridViewTextBoxColumn
            // 
            this.수주번호DataGridViewTextBoxColumn.DataPropertyName = "수주번호";
            this.수주번호DataGridViewTextBoxColumn.HeaderText = "수주번호";
            this.수주번호DataGridViewTextBoxColumn.Name = "수주번호DataGridViewTextBoxColumn";
            this.수주번호DataGridViewTextBoxColumn.ReadOnly = true;
            this.수주번호DataGridViewTextBoxColumn.Visible = false;
            // 
            // 수주순번DataGridViewTextBoxColumn
            // 
            this.수주순번DataGridViewTextBoxColumn.DataPropertyName = "수주순번";
            this.수주순번DataGridViewTextBoxColumn.HeaderText = "수주순번";
            this.수주순번DataGridViewTextBoxColumn.Name = "수주순번DataGridViewTextBoxColumn";
            this.수주순번DataGridViewTextBoxColumn.ReadOnly = true;
            this.수주순번DataGridViewTextBoxColumn.Visible = false;
            // 
            // 품목코드DataGridViewTextBoxColumn
            // 
            this.품목코드DataGridViewTextBoxColumn.DataPropertyName = "품목코드";
            this.품목코드DataGridViewTextBoxColumn.HeaderText = "품목코드";
            this.품목코드DataGridViewTextBoxColumn.Name = "품목코드DataGridViewTextBoxColumn";
            this.품목코드DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 품목명DataGridViewTextBoxColumn
            // 
            this.품목명DataGridViewTextBoxColumn.DataPropertyName = "품목명";
            this.품목명DataGridViewTextBoxColumn.HeaderText = "품목명";
            this.품목명DataGridViewTextBoxColumn.Name = "품목명DataGridViewTextBoxColumn";
            this.품목명DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 작업장DataGridViewTextBoxColumn
            // 
            this.작업장DataGridViewTextBoxColumn.DataPropertyName = "작업장";
            this.작업장DataGridViewTextBoxColumn.HeaderText = "작업장";
            this.작업장DataGridViewTextBoxColumn.Name = "작업장DataGridViewTextBoxColumn";
            this.작업장DataGridViewTextBoxColumn.ReadOnly = true;
            this.작업장DataGridViewTextBoxColumn.Visible = false;
            // 
            // 작업라인DataGridViewTextBoxColumn
            // 
            this.작업라인DataGridViewTextBoxColumn.DataPropertyName = "작업라인";
            this.작업라인DataGridViewTextBoxColumn.HeaderText = "작업라인";
            this.작업라인DataGridViewTextBoxColumn.Name = "작업라인DataGridViewTextBoxColumn";
            this.작업라인DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 공정번호DataGridViewTextBoxColumn
            // 
            this.공정번호DataGridViewTextBoxColumn.DataPropertyName = "공정번호";
            this.공정번호DataGridViewTextBoxColumn.HeaderText = "공정번호";
            this.공정번호DataGridViewTextBoxColumn.Name = "공정번호DataGridViewTextBoxColumn";
            this.공정번호DataGridViewTextBoxColumn.ReadOnly = true;
            this.공정번호DataGridViewTextBoxColumn.Visible = false;
            // 
            // 생산책임자DataGridViewTextBoxColumn
            // 
            this.생산책임자DataGridViewTextBoxColumn.DataPropertyName = "생산책임자";
            this.생산책임자DataGridViewTextBoxColumn.FillWeight = 60F;
            this.생산책임자DataGridViewTextBoxColumn.HeaderText = "책임자";
            this.생산책임자DataGridViewTextBoxColumn.Name = "생산책임자DataGridViewTextBoxColumn";
            this.생산책임자DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 작업지시수량DataGridViewTextBoxColumn
            // 
            this.작업지시수량DataGridViewTextBoxColumn.DataPropertyName = "작업지시수량";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.작업지시수량DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.작업지시수량DataGridViewTextBoxColumn.FillWeight = 50F;
            this.작업지시수량DataGridViewTextBoxColumn.HeaderText = "지시수량";
            this.작업지시수량DataGridViewTextBoxColumn.Name = "작업지시수량DataGridViewTextBoxColumn";
            this.작업지시수량DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 작업시작시간DataGridViewTextBoxColumn
            // 
            this.작업시작시간DataGridViewTextBoxColumn.DataPropertyName = "작업시작시간";
            dataGridViewCellStyle4.Format = "yyyy-MM-dd HH:mm:ss";
            dataGridViewCellStyle4.NullValue = null;
            this.작업시작시간DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.작업시작시간DataGridViewTextBoxColumn.HeaderText = "작업시작";
            this.작업시작시간DataGridViewTextBoxColumn.Name = "작업시작시간DataGridViewTextBoxColumn";
            this.작업시작시간DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 작업종료시간DataGridViewTextBoxColumn
            // 
            this.작업종료시간DataGridViewTextBoxColumn.DataPropertyName = "작업종료시간";
            dataGridViewCellStyle5.Format = "yyyy-MM-dd HH:mm:ss";
            this.작업종료시간DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.작업종료시간DataGridViewTextBoxColumn.HeaderText = "작업종료";
            this.작업종료시간DataGridViewTextBoxColumn.Name = "작업종료시간DataGridViewTextBoxColumn";
            this.작업종료시간DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 불량IDDataGridViewTextBoxColumn
            // 
            this.불량IDDataGridViewTextBoxColumn.DataPropertyName = "불량ID";
            this.불량IDDataGridViewTextBoxColumn.HeaderText = "불량ID";
            this.불량IDDataGridViewTextBoxColumn.Name = "불량IDDataGridViewTextBoxColumn";
            this.불량IDDataGridViewTextBoxColumn.ReadOnly = true;
            this.불량IDDataGridViewTextBoxColumn.Visible = false;
            // 
            // 작지시퀀스DataGridViewTextBoxColumn
            // 
            this.작지시퀀스DataGridViewTextBoxColumn.DataPropertyName = "작지시퀀스";
            this.작지시퀀스DataGridViewTextBoxColumn.HeaderText = "작지시퀀스";
            this.작지시퀀스DataGridViewTextBoxColumn.Name = "작지시퀀스DataGridViewTextBoxColumn";
            this.작지시퀀스DataGridViewTextBoxColumn.ReadOnly = true;
            this.작지시퀀스DataGridViewTextBoxColumn.Visible = false;
            // 
            // 검사코드DataGridViewTextBoxColumn
            // 
            this.검사코드DataGridViewTextBoxColumn.DataPropertyName = "검사코드";
            this.검사코드DataGridViewTextBoxColumn.HeaderText = "검사코드";
            this.검사코드DataGridViewTextBoxColumn.Name = "검사코드DataGridViewTextBoxColumn";
            this.검사코드DataGridViewTextBoxColumn.ReadOnly = true;
            this.검사코드DataGridViewTextBoxColumn.Visible = false;
            // 
            // 검사항목DataGridViewTextBoxColumn
            // 
            this.검사항목DataGridViewTextBoxColumn.DataPropertyName = "검사항목";
            this.검사항목DataGridViewTextBoxColumn.HeaderText = "검사항목";
            this.검사항목DataGridViewTextBoxColumn.Name = "검사항목DataGridViewTextBoxColumn";
            this.검사항목DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 검사일자DataGridViewTextBoxColumn
            // 
            this.검사일자DataGridViewTextBoxColumn.DataPropertyName = "검사일자";
            this.검사일자DataGridViewTextBoxColumn.FillWeight = 70F;
            this.검사일자DataGridViewTextBoxColumn.HeaderText = "검사일자";
            this.검사일자DataGridViewTextBoxColumn.Name = "검사일자DataGridViewTextBoxColumn";
            this.검사일자DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 불합격수량DataGridViewTextBoxColumn
            // 
            this.불합격수량DataGridViewTextBoxColumn.DataPropertyName = "불합격수량";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.불합격수량DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.불합격수량DataGridViewTextBoxColumn.FillWeight = 50F;
            this.불합격수량DataGridViewTextBoxColumn.HeaderText = "불합격수량";
            this.불합격수량DataGridViewTextBoxColumn.Name = "불합격수량DataGridViewTextBoxColumn";
            this.불합격수량DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 귀책부서코드DataGridViewTextBoxColumn
            // 
            this.귀책부서코드DataGridViewTextBoxColumn.DataPropertyName = "귀책부서코드";
            this.귀책부서코드DataGridViewTextBoxColumn.HeaderText = "귀책부서코드";
            this.귀책부서코드DataGridViewTextBoxColumn.Name = "귀책부서코드DataGridViewTextBoxColumn";
            this.귀책부서코드DataGridViewTextBoxColumn.ReadOnly = true;
            this.귀책부서코드DataGridViewTextBoxColumn.Visible = false;
            // 
            // 귀책부서DataGridViewTextBoxColumn
            // 
            this.귀책부서DataGridViewTextBoxColumn.DataPropertyName = "귀책부서";
            this.귀책부서DataGridViewTextBoxColumn.FillWeight = 60F;
            this.귀책부서DataGridViewTextBoxColumn.HeaderText = "부서";
            this.귀책부서DataGridViewTextBoxColumn.Name = "귀책부서DataGridViewTextBoxColumn";
            this.귀책부서DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 비고DataGridViewTextBoxColumn
            // 
            this.비고DataGridViewTextBoxColumn.DataPropertyName = "비고";
            this.비고DataGridViewTextBoxColumn.HeaderText = "비고";
            this.비고DataGridViewTextBoxColumn.Name = "비고DataGridViewTextBoxColumn";
            this.비고DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // P1C09_PROD_NG_RESULT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.ClientSize = new System.Drawing.Size(1325, 990);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "P1C09_PROD_NG_RESULT";
            this.Text = "`";
            this.Load += new System.EventHandler(this.P1C09_PROD_NG_RESULT_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.panSearch.ResumeLayout(false);
            this.panSearch.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPProdDefectResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1C)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker dtpToDate;
        public System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.BindingSource sPProdDefectResultBindingSource;
        private P1C.DataSetP1C dataSetP1C;
        private P1C.DataSetP1CTableAdapters.SP_Prod_Defect_ResultTableAdapter sP_Prod_Defect_ResultTableAdapter;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업지시번호DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주번호DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주순번DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 품목코드DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 품목명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업장DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업라인DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 공정번호DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 생산책임자DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업지시수량DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업시작시간DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업종료시간DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 불량IDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작지시퀀스DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 검사코드DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 검사항목DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 검사일자DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 불합격수량DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 귀책부서코드DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 귀책부서DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 비고DataGridViewTextBoxColumn;
    }
}
