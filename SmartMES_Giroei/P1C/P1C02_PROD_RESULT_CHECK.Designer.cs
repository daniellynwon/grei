namespace SmartMES_Giroei
{
    partial class P1C02_PROD_RESULT_CHECK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P1C02_PROD_RESULT_CHECK));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panSearch = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sPProdResultCheckBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetP1C = new SmartMES_Giroei.P1C.DataSetP1C();
            this.sP_Prod_Result_CheckTableAdapter = new SmartMES_Giroei.P1C.DataSetP1CTableAdapters.SP_Prod_Result_CheckTableAdapter();
            this.작업지시번호DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수주번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.검사시작시간DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.검사종료시간DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.경과시간 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baking실시여부DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPI실시여부DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.극성자재확인DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.원자재유실확인DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.피드백DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.미삽POINT점검DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.납땜상태확인DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.점검자DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.panSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPProdResultCheckBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1C)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "생산실적사양점검";
            // 
            // pbPrint
            // 
            this.pbPrint.Image = global::SmartMES_Giroei.Properties.Resources.out_B;
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
            this.panSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panSearch.AutoSize = true;
            this.panSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.panSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSearch.Controls.Add(this.label3);
            this.panSearch.Controls.Add(this.label2);
            this.panSearch.Controls.Add(this.dtpToDate);
            this.panSearch.Controls.Add(this.dtpFromDate);
            this.panSearch.Controls.Add(this.tbSearch);
            this.panSearch.Controls.Add(this.label1);
            this.panSearch.Location = new System.Drawing.Point(2, 58);
            this.panSearch.Name = "panSearch";
            this.panSearch.Size = new System.Drawing.Size(1319, 71);
            this.panSearch.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(324, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "~";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(34, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "작업일자";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpToDate.CalendarFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpToDate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpToDate.Location = new System.Drawing.Point(347, 20);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(211, 29);
            this.dtpToDate.TabIndex = 3;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFromDate.CalendarFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpFromDate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpFromDate.Location = new System.Drawing.Point(111, 20);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(211, 29);
            this.dtpFromDate.TabIndex = 2;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbSearch.BackColor = System.Drawing.SystemColors.Window;
            this.tbSearch.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSearch.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbSearch.Location = new System.Drawing.Point(707, 19);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(257, 29);
            this.tbSearch.TabIndex = 4;
            this.tbSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyUp);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(594, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "작업지시번호";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.수주번호,
            this.검사시작시간DataGridViewTextBoxColumn,
            this.검사종료시간DataGridViewTextBoxColumn,
            this.경과시간,
            this.baking실시여부DataGridViewTextBoxColumn,
            this.sPI실시여부DataGridViewTextBoxColumn,
            this.극성자재확인DataGridViewTextBoxColumn,
            this.원자재유실확인DataGridViewTextBoxColumn,
            this.피드백DataGridViewTextBoxColumn,
            this.미삽POINT점검DataGridViewTextBoxColumn,
            this.납땜상태확인DataGridViewTextBoxColumn,
            this.점검자DataGridViewTextBoxColumn});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView1.DataSource = this.sPProdResultCheckBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(2, 131);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 35;
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1319, 852);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // sPProdResultCheckBindingSource
            // 
            this.sPProdResultCheckBindingSource.DataMember = "SP_Prod_Result_Check";
            this.sPProdResultCheckBindingSource.DataSource = this.dataSetP1C;
            // 
            // dataSetP1C
            // 
            this.dataSetP1C.DataSetName = "DataSetP1C";
            this.dataSetP1C.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sP_Prod_Result_CheckTableAdapter
            // 
            this.sP_Prod_Result_CheckTableAdapter.ClearBeforeFill = true;
            // 
            // 작업지시번호DataGridViewTextBoxColumn
            // 
            this.작업지시번호DataGridViewTextBoxColumn.DataPropertyName = "작업지시번호";
            this.작업지시번호DataGridViewTextBoxColumn.FillWeight = 90F;
            this.작업지시번호DataGridViewTextBoxColumn.HeaderText = "작업지시번호";
            this.작업지시번호DataGridViewTextBoxColumn.Name = "작업지시번호DataGridViewTextBoxColumn";
            this.작업지시번호DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 수주번호
            // 
            this.수주번호.DataPropertyName = "수주번호";
            this.수주번호.FillWeight = 90F;
            this.수주번호.HeaderText = "수주번호";
            this.수주번호.Name = "수주번호";
            this.수주번호.ReadOnly = true;
            // 
            // 검사시작시간DataGridViewTextBoxColumn
            // 
            this.검사시작시간DataGridViewTextBoxColumn.DataPropertyName = "검사시작시간";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd HH:mm:ss";
            this.검사시작시간DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.검사시작시간DataGridViewTextBoxColumn.FillWeight = 105F;
            this.검사시작시간DataGridViewTextBoxColumn.HeaderText = "검사시작시간";
            this.검사시작시간DataGridViewTextBoxColumn.Name = "검사시작시간DataGridViewTextBoxColumn";
            this.검사시작시간DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 검사종료시간DataGridViewTextBoxColumn
            // 
            this.검사종료시간DataGridViewTextBoxColumn.DataPropertyName = "검사종료시간";
            dataGridViewCellStyle4.Format = "yyyy-MM-dd HH:mm:ss";
            this.검사종료시간DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.검사종료시간DataGridViewTextBoxColumn.FillWeight = 105F;
            this.검사종료시간DataGridViewTextBoxColumn.HeaderText = "검사종료시간";
            this.검사종료시간DataGridViewTextBoxColumn.Name = "검사종료시간DataGridViewTextBoxColumn";
            this.검사종료시간DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 경과시간
            // 
            this.경과시간.DataPropertyName = "경과시간";
            this.경과시간.HeaderText = "경과시간";
            this.경과시간.Name = "경과시간";
            this.경과시간.ReadOnly = true;
            // 
            // baking실시여부DataGridViewTextBoxColumn
            // 
            this.baking실시여부DataGridViewTextBoxColumn.DataPropertyName = "Baking실시여부";
            this.baking실시여부DataGridViewTextBoxColumn.FillWeight = 85F;
            this.baking실시여부DataGridViewTextBoxColumn.HeaderText = "Baking실시여부";
            this.baking실시여부DataGridViewTextBoxColumn.Name = "baking실시여부DataGridViewTextBoxColumn";
            this.baking실시여부DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sPI실시여부DataGridViewTextBoxColumn
            // 
            this.sPI실시여부DataGridViewTextBoxColumn.DataPropertyName = "SPI실시여부";
            this.sPI실시여부DataGridViewTextBoxColumn.FillWeight = 85F;
            this.sPI실시여부DataGridViewTextBoxColumn.HeaderText = "SPI실시여부";
            this.sPI실시여부DataGridViewTextBoxColumn.Name = "sPI실시여부DataGridViewTextBoxColumn";
            this.sPI실시여부DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 극성자재확인DataGridViewTextBoxColumn
            // 
            this.극성자재확인DataGridViewTextBoxColumn.DataPropertyName = "극성자재확인";
            this.극성자재확인DataGridViewTextBoxColumn.FillWeight = 85F;
            this.극성자재확인DataGridViewTextBoxColumn.HeaderText = "극성자재확인";
            this.극성자재확인DataGridViewTextBoxColumn.Name = "극성자재확인DataGridViewTextBoxColumn";
            this.극성자재확인DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 원자재유실확인DataGridViewTextBoxColumn
            // 
            this.원자재유실확인DataGridViewTextBoxColumn.DataPropertyName = "원자재유실확인";
            this.원자재유실확인DataGridViewTextBoxColumn.FillWeight = 85F;
            this.원자재유실확인DataGridViewTextBoxColumn.HeaderText = "원자재유실확인";
            this.원자재유실확인DataGridViewTextBoxColumn.Name = "원자재유실확인DataGridViewTextBoxColumn";
            this.원자재유실확인DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 피드백DataGridViewTextBoxColumn
            // 
            this.피드백DataGridViewTextBoxColumn.DataPropertyName = "피드백";
            this.피드백DataGridViewTextBoxColumn.FillWeight = 55F;
            this.피드백DataGridViewTextBoxColumn.HeaderText = "피드백";
            this.피드백DataGridViewTextBoxColumn.Name = "피드백DataGridViewTextBoxColumn";
            this.피드백DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 미삽POINT점검DataGridViewTextBoxColumn
            // 
            this.미삽POINT점검DataGridViewTextBoxColumn.DataPropertyName = "미삽POINT점검";
            this.미삽POINT점검DataGridViewTextBoxColumn.FillWeight = 85F;
            this.미삽POINT점검DataGridViewTextBoxColumn.HeaderText = "미삽POINT점검";
            this.미삽POINT점검DataGridViewTextBoxColumn.Name = "미삽POINT점검DataGridViewTextBoxColumn";
            this.미삽POINT점검DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 납땜상태확인DataGridViewTextBoxColumn
            // 
            this.납땜상태확인DataGridViewTextBoxColumn.DataPropertyName = "납땜상태확인";
            this.납땜상태확인DataGridViewTextBoxColumn.FillWeight = 85F;
            this.납땜상태확인DataGridViewTextBoxColumn.HeaderText = "납땜상태확인";
            this.납땜상태확인DataGridViewTextBoxColumn.Name = "납땜상태확인DataGridViewTextBoxColumn";
            this.납땜상태확인DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 점검자DataGridViewTextBoxColumn
            // 
            this.점검자DataGridViewTextBoxColumn.DataPropertyName = "점검자";
            this.점검자DataGridViewTextBoxColumn.FillWeight = 85F;
            this.점검자DataGridViewTextBoxColumn.HeaderText = "점검자";
            this.점검자DataGridViewTextBoxColumn.Name = "점검자DataGridViewTextBoxColumn";
            this.점검자DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // P1C02_PROD_RESULT_CHECK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.ClientSize = new System.Drawing.Size(1325, 990);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panSearch);
            this.Name = "P1C02_PROD_RESULT_CHECK";
            this.Text = "P1C02_PROD_RESULT_CHECK";
            this.Load += new System.EventHandler(this.P1C02_PROD_RESULT_CHECK_Load);
            this.Controls.SetChildIndex(this.panSearch, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.panSearch.ResumeLayout(false);
            this.panSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPProdResultCheckBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1C)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panSearch;
        public System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 전화DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 팩스DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 가공비DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 재료비DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 합계금액DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수량DataGridViewTextBoxColumn;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource sPProdResultCheckBindingSource;
        private P1C.DataSetP1C dataSetP1C;
        private P1C.DataSetP1CTableAdapters.SP_Prod_Result_CheckTableAdapter sP_Prod_Result_CheckTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업지시번호DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주번호;
        private System.Windows.Forms.DataGridViewTextBoxColumn 검사시작시간DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 검사종료시간DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 경과시간;
        private System.Windows.Forms.DataGridViewTextBoxColumn baking실시여부DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sPI실시여부DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 극성자재확인DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 원자재유실확인DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 피드백DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 미삽POINT점검DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 납땜상태확인DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 점검자DataGridViewTextBoxColumn;
    }
}
