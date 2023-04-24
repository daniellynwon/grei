namespace SmartMES_Giroei
{
    partial class P1B04_RORDER_LIST
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P1B04_RORDER_LIST));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panSearch = new System.Windows.Forms.Panel();
            this.cb1 = new System.Windows.Forms.CheckBox();
            this.cbAllFeatures = new System.Windows.Forms.CheckBox();
            this.cb0 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.수주번호DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수주일자DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.거래처IDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.거래처명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.영업담당DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.프로젝트명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수량DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.견적금액DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.설계DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.제작DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.조립DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.구매수삽DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.기타METALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.합계금액DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.납기DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.출하DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.수주취소DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPROrderListQueryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetP1B = new SmartMES_Giroei.P1B.DataSetP1B();
            this.sP_ROrderList_QueryTableAdapter = new SmartMES_Giroei.P1B.DataSetP1BTableAdapters.SP_ROrderList_QueryTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.panSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPROrderListQueryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1B)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "수주현황";
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
            this.panSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panSearch.AutoSize = true;
            this.panSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.panSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSearch.Controls.Add(this.cb1);
            this.panSearch.Controls.Add(this.cbAllFeatures);
            this.panSearch.Controls.Add(this.cb0);
            this.panSearch.Controls.Add(this.label3);
            this.panSearch.Controls.Add(this.label2);
            this.panSearch.Controls.Add(this.dtpToDate);
            this.panSearch.Controls.Add(this.dtpFromDate);
            this.panSearch.Controls.Add(this.tbSearch);
            this.panSearch.Controls.Add(this.label1);
            this.panSearch.Location = new System.Drawing.Point(2, 58);
            this.panSearch.Name = "panSearch";
            this.panSearch.Size = new System.Drawing.Size(1319, 77);
            this.panSearch.TabIndex = 0;
            // 
            // cb1
            // 
            this.cb1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cb1.AutoSize = true;
            this.cb1.Checked = true;
            this.cb1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb1.Location = new System.Drawing.Point(1142, 44);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(93, 25);
            this.cb1.TabIndex = 17;
            this.cb1.Text = "수주취소";
            this.cb1.UseVisualStyleBackColor = true;
            this.cb1.Click += new System.EventHandler(this.cb1_Click);
            // 
            // cbAllFeatures
            // 
            this.cbAllFeatures.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbAllFeatures.AutoSize = true;
            this.cbAllFeatures.Checked = true;
            this.cbAllFeatures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAllFeatures.Location = new System.Drawing.Point(1142, 0);
            this.cbAllFeatures.Name = "cbAllFeatures";
            this.cbAllFeatures.Size = new System.Drawing.Size(61, 25);
            this.cbAllFeatures.TabIndex = 12;
            this.cbAllFeatures.Text = "전체";
            this.cbAllFeatures.UseVisualStyleBackColor = true;
            this.cbAllFeatures.CheckedChanged += new System.EventHandler(this.cbAllFeatures_CheckedChanged);
            this.cbAllFeatures.Click += new System.EventHandler(this.cbAllFeatures_Click);
            // 
            // cb0
            // 
            this.cb0.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cb0.AutoSize = true;
            this.cb0.Checked = true;
            this.cb0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb0.Location = new System.Drawing.Point(1142, 22);
            this.cb0.Name = "cb0";
            this.cb0.Size = new System.Drawing.Size(93, 25);
            this.cb0.TabIndex = 16;
            this.cb0.Text = "정상수주";
            this.cb0.UseVisualStyleBackColor = true;
            this.cb0.Click += new System.EventHandler(this.cb0_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(363, 24);
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
            this.label2.Location = new System.Drawing.Point(73, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "수주기간";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpToDate.CalendarFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpToDate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpToDate.Location = new System.Drawing.Point(386, 20);
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
            this.dtpFromDate.Location = new System.Drawing.Point(150, 20);
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
            this.tbSearch.Location = new System.Drawing.Point(801, 21);
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
            this.label1.Location = new System.Drawing.Point(613, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "거래처/수주번호/모델명";
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
            this.수주번호DataGridViewTextBoxColumn,
            this.수주일자DataGridViewTextBoxColumn,
            this.거래처IDDataGridViewTextBoxColumn,
            this.거래처명DataGridViewTextBoxColumn,
            this.영업담당DataGridViewTextBoxColumn,
            this.프로젝트명,
            this.수량DataGridViewTextBoxColumn,
            this.견적금액DataGridViewTextBoxColumn,
            this.설계DataGridViewTextBoxColumn,
            this.제작DataGridViewTextBoxColumn,
            this.조립DataGridViewTextBoxColumn,
            this.구매수삽DataGridViewTextBoxColumn,
            this.기타METALDataGridViewTextBoxColumn,
            this.합계금액DataGridViewTextBoxColumn,
            this.납기DataGridViewTextBoxColumn,
            this.출하DataGridViewTextBoxColumn,
            this.Column1,
            this.수주취소DataGridViewTextBoxColumn});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView1.DataSource = this.sPROrderListQueryBindingSource;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(2, 131);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle16.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
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
            // 수주번호DataGridViewTextBoxColumn
            // 
            this.수주번호DataGridViewTextBoxColumn.DataPropertyName = "수주번호";
            this.수주번호DataGridViewTextBoxColumn.FillWeight = 75F;
            this.수주번호DataGridViewTextBoxColumn.HeaderText = "수주번호";
            this.수주번호DataGridViewTextBoxColumn.Name = "수주번호DataGridViewTextBoxColumn";
            this.수주번호DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 수주일자DataGridViewTextBoxColumn
            // 
            this.수주일자DataGridViewTextBoxColumn.DataPropertyName = "수주일자";
            dataGridViewCellStyle3.Format = "M";
            dataGridViewCellStyle3.NullValue = null;
            this.수주일자DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.수주일자DataGridViewTextBoxColumn.FillWeight = 35F;
            this.수주일자DataGridViewTextBoxColumn.HeaderText = "수주일자";
            this.수주일자DataGridViewTextBoxColumn.Name = "수주일자DataGridViewTextBoxColumn";
            this.수주일자DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 거래처IDDataGridViewTextBoxColumn
            // 
            this.거래처IDDataGridViewTextBoxColumn.DataPropertyName = "거래처ID";
            this.거래처IDDataGridViewTextBoxColumn.HeaderText = "거래처ID";
            this.거래처IDDataGridViewTextBoxColumn.Name = "거래처IDDataGridViewTextBoxColumn";
            this.거래처IDDataGridViewTextBoxColumn.ReadOnly = true;
            this.거래처IDDataGridViewTextBoxColumn.Visible = false;
            // 
            // 거래처명DataGridViewTextBoxColumn
            // 
            this.거래처명DataGridViewTextBoxColumn.DataPropertyName = "거래처명";
            this.거래처명DataGridViewTextBoxColumn.FillWeight = 75F;
            this.거래처명DataGridViewTextBoxColumn.HeaderText = "거래처명";
            this.거래처명DataGridViewTextBoxColumn.Name = "거래처명DataGridViewTextBoxColumn";
            this.거래처명DataGridViewTextBoxColumn.ReadOnly = true;
            this.거래처명DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.거래처명DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 영업담당DataGridViewTextBoxColumn
            // 
            this.영업담당DataGridViewTextBoxColumn.DataPropertyName = "영업담당";
            this.영업담당DataGridViewTextBoxColumn.HeaderText = "영업담당";
            this.영업담당DataGridViewTextBoxColumn.Name = "영업담당DataGridViewTextBoxColumn";
            this.영업담당DataGridViewTextBoxColumn.ReadOnly = true;
            this.영업담당DataGridViewTextBoxColumn.Visible = false;
            // 
            // 프로젝트명
            // 
            this.프로젝트명.DataPropertyName = "프로젝트명";
            this.프로젝트명.FillWeight = 125F;
            this.프로젝트명.HeaderText = "프로젝트명";
            this.프로젝트명.Name = "프로젝트명";
            this.프로젝트명.ReadOnly = true;
            // 
            // 수량DataGridViewTextBoxColumn
            // 
            this.수량DataGridViewTextBoxColumn.DataPropertyName = "수량";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.수량DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.수량DataGridViewTextBoxColumn.FillWeight = 35F;
            this.수량DataGridViewTextBoxColumn.HeaderText = "수량";
            this.수량DataGridViewTextBoxColumn.Name = "수량DataGridViewTextBoxColumn";
            this.수량DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 견적금액DataGridViewTextBoxColumn
            // 
            this.견적금액DataGridViewTextBoxColumn.DataPropertyName = "견적금액";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.견적금액DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.견적금액DataGridViewTextBoxColumn.FillWeight = 50F;
            this.견적금액DataGridViewTextBoxColumn.HeaderText = "견적금액";
            this.견적금액DataGridViewTextBoxColumn.Name = "견적금액DataGridViewTextBoxColumn";
            this.견적금액DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 설계DataGridViewTextBoxColumn
            // 
            this.설계DataGridViewTextBoxColumn.DataPropertyName = "설계";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.설계DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.설계DataGridViewTextBoxColumn.FillWeight = 50F;
            this.설계DataGridViewTextBoxColumn.HeaderText = "설계비용";
            this.설계DataGridViewTextBoxColumn.Name = "설계DataGridViewTextBoxColumn";
            this.설계DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 제작DataGridViewTextBoxColumn
            // 
            this.제작DataGridViewTextBoxColumn.DataPropertyName = "제작";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.제작DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.제작DataGridViewTextBoxColumn.FillWeight = 50F;
            this.제작DataGridViewTextBoxColumn.HeaderText = "제작비용";
            this.제작DataGridViewTextBoxColumn.Name = "제작DataGridViewTextBoxColumn";
            this.제작DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 조립DataGridViewTextBoxColumn
            // 
            this.조립DataGridViewTextBoxColumn.DataPropertyName = "조립";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            this.조립DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.조립DataGridViewTextBoxColumn.FillWeight = 50F;
            this.조립DataGridViewTextBoxColumn.HeaderText = "조립비용";
            this.조립DataGridViewTextBoxColumn.Name = "조립DataGridViewTextBoxColumn";
            this.조립DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 구매수삽DataGridViewTextBoxColumn
            // 
            this.구매수삽DataGridViewTextBoxColumn.DataPropertyName = "구매수삽";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.구매수삽DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.구매수삽DataGridViewTextBoxColumn.FillWeight = 50F;
            this.구매수삽DataGridViewTextBoxColumn.HeaderText = "구매/수삽비용";
            this.구매수삽DataGridViewTextBoxColumn.Name = "구매수삽DataGridViewTextBoxColumn";
            this.구매수삽DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 기타METALDataGridViewTextBoxColumn
            // 
            this.기타METALDataGridViewTextBoxColumn.DataPropertyName = "기타METAL";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = null;
            this.기타METALDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.기타METALDataGridViewTextBoxColumn.FillWeight = 50F;
            this.기타METALDataGridViewTextBoxColumn.HeaderText = "기타(METAL)비용";
            this.기타METALDataGridViewTextBoxColumn.Name = "기타METALDataGridViewTextBoxColumn";
            this.기타METALDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 합계금액DataGridViewTextBoxColumn
            // 
            this.합계금액DataGridViewTextBoxColumn.DataPropertyName = "합계금액";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = null;
            this.합계금액DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.합계금액DataGridViewTextBoxColumn.FillWeight = 50F;
            this.합계금액DataGridViewTextBoxColumn.HeaderText = "합계금액";
            this.합계금액DataGridViewTextBoxColumn.Name = "합계금액DataGridViewTextBoxColumn";
            this.합계금액DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 납기DataGridViewTextBoxColumn
            // 
            this.납기DataGridViewTextBoxColumn.DataPropertyName = "납기";
            dataGridViewCellStyle12.Format = "M";
            dataGridViewCellStyle12.NullValue = null;
            this.납기DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.납기DataGridViewTextBoxColumn.FillWeight = 30F;
            this.납기DataGridViewTextBoxColumn.HeaderText = "납기";
            this.납기DataGridViewTextBoxColumn.Name = "납기DataGridViewTextBoxColumn";
            this.납기DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 출하DataGridViewTextBoxColumn
            // 
            this.출하DataGridViewTextBoxColumn.DataPropertyName = "출하";
            dataGridViewCellStyle13.Format = "M";
            dataGridViewCellStyle13.NullValue = null;
            this.출하DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.출하DataGridViewTextBoxColumn.FillWeight = 30F;
            this.출하DataGridViewTextBoxColumn.HeaderText = "출하";
            this.출하DataGridViewTextBoxColumn.Name = "출하DataGridViewTextBoxColumn";
            this.출하DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Column1
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.NullValue = "조회";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle14;
            this.Column1.FillWeight = 21.68348F;
            this.Column1.HeaderText = "BOM";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // 수주취소DataGridViewTextBoxColumn
            // 
            this.수주취소DataGridViewTextBoxColumn.DataPropertyName = "수주취소";
            this.수주취소DataGridViewTextBoxColumn.HeaderText = "수주취소";
            this.수주취소DataGridViewTextBoxColumn.Name = "수주취소DataGridViewTextBoxColumn";
            this.수주취소DataGridViewTextBoxColumn.ReadOnly = true;
            this.수주취소DataGridViewTextBoxColumn.Visible = false;
            // 
            // sPROrderListQueryBindingSource
            // 
            this.sPROrderListQueryBindingSource.DataMember = "SP_ROrderList_Query";
            this.sPROrderListQueryBindingSource.DataSource = this.dataSetP1B;
            // 
            // dataSetP1B
            // 
            this.dataSetP1B.DataSetName = "DataSetP1B";
            this.dataSetP1B.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sP_ROrderList_QueryTableAdapter
            // 
            this.sP_ROrderList_QueryTableAdapter.ClearBeforeFill = true;
            // 
            // P1B04_RORDER_LIST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.ClientSize = new System.Drawing.Size(1325, 990);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panSearch);
            this.Name = "P1B04_RORDER_LIST";
            this.Text = "P1B04_RORDER_LIST";
            this.Activated += new System.EventHandler(this.P1B04_RORDER_LIST_Activated);
            this.Load += new System.EventHandler(this.P1B04_RORDER_LIST_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.sPROrderListQueryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1B)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panSearch;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 현장정보DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 품목수DataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox cb1;
        private System.Windows.Forms.CheckBox cbAllFeatures;
        private System.Windows.Forms.CheckBox cb0;
        private System.Windows.Forms.BindingSource sPROrderListQueryBindingSource;
        private P1B.DataSetP1B dataSetP1B;
        private P1B.DataSetP1BTableAdapters.SP_ROrderList_QueryTableAdapter sP_ROrderList_QueryTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주번호DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주일자DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 거래처IDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn 거래처명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 영업담당DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 프로젝트명;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수량DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 견적금액DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 설계DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 제작DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 조립DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 구매수삽DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 기타METALDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 합계금액DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 납기DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 출하DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주취소DataGridViewTextBoxColumn;
    }
}
