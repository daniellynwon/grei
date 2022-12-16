namespace SmartMES_Giroei
{
    partial class P1B05_DELIVERY
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sPDeliverySubQueryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetP1B = new SmartMES_Giroei.P1B.DataSetP1B();
            this.sPZCommonIDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnProd = new System.Windows.Forms.Button();
            this.dataGridViewList = new System.Windows.Forms.DataGridView();
            this.출하번호DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.출하요청일자DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.거래처IDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.거래처명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.영업담당DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.프로젝트명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.현장정보DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송수단DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송정보DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수주번호DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.비고DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송비용DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.포장단위DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.출하창고 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPDeliveryMainQueryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.tbBarcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotMoney = new System.Windows.Forms.Label();
            this.lblCnt = new System.Windows.Forms.Label();
            this.lblSumMoney = new System.Windows.Forms.Label();
            this.sP_Z_Common_IDTableAdapter = new SmartMES_Giroei.P1B.DataSetP1BTableAdapters.SP_Z_Common_IDTableAdapter();
            this.sPDeliveryPrintBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sP_Delivery_PrintTableAdapter = new SmartMES_Giroei.P1B.DataSetP1BTableAdapters.SP_Delivery_PrintTableAdapter();
            this.panSearch = new System.Windows.Forms.Panel();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.cbDeport = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDeliCost = new System.Windows.Forms.TextBox();
            this.cbPackingType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRorder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDeliCar = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbContents = new System.Windows.Forms.TextBox();
            this.tbPlace = new System.Windows.Forms.TextBox();
            this.tbCust = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.tbNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCust = new System.Windows.Forms.Label();
            this.tbDeliInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbNo = new System.Windows.Forms.CheckBox();
            this.sP_DeliverySub_QueryTableAdapter = new SmartMES_Giroei.P1B.DataSetP1BTableAdapters.SP_DeliverySub_QueryTableAdapter();
            this.sP_DeliveryMain_QueryTableAdapter = new SmartMES_Giroei.P1B.DataSetP1BTableAdapters.SP_DeliveryMain_QueryTableAdapter();
            this.출하번호DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.순번DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.출하창고DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.품목코드DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.품목명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.제품명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.단위DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수량DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.단가DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.금액DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.부가세DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.합계금액DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수주번호DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPDeliverySubQueryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPZCommonIDBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPDeliveryMainQueryBindingSource)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sPDeliveryPrintBindingSource)).BeginInit();
            this.panSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "출고등록";
            // 
            // pbPrint
            // 
            this.pbPrint.Enabled = true;
            this.pbPrint.Image = global::SmartMES_Giroei.Properties.Resources.out_A;
            this.pbPrint.Click += new System.EventHandler(this.pbPrint_Click);
            // 
            // pbSave
            // 
            this.pbSave.Enabled = true;
            this.pbSave.Image = global::SmartMES_Giroei.Properties.Resources.save_A;
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            // 
            // pbDel
            // 
            this.pbDel.Image = global::SmartMES_Giroei.Properties.Resources.del_A;
            this.pbDel.Click += new System.EventHandler(this.pbDel_Click);
            // 
            // pbAdd
            // 
            this.pbAdd.Image = global::SmartMES_Giroei.Properties.Resources.add_A;
            this.pbAdd.Click += new System.EventHandler(this.pbAdd_Click);
            // 
            // pbSearch
            // 
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            // 
            // dataGridView1
            // 
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
            this.출하번호DataGridViewTextBoxColumn1,
            this.순번DataGridViewTextBoxColumn,
            this.출하창고DataGridViewTextBoxColumn,
            this.품목코드DataGridViewTextBoxColumn,
            this.품목명DataGridViewTextBoxColumn,
            this.제품명DataGridViewTextBoxColumn,
            this.단위DataGridViewTextBoxColumn,
            this.수량DataGridViewTextBoxColumn,
            this.단가DataGridViewTextBoxColumn,
            this.금액DataGridViewTextBoxColumn,
            this.부가세DataGridViewTextBoxColumn,
            this.합계금액DataGridViewTextBoxColumn,
            this.수주번호DataGridViewTextBoxColumn1,
            this.ColumnDel,
            this.Column1});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView1.DataSource = this.sPDeliverySubQueryBindingSource;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(310, 394);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 35;
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1011, 589);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // sPDeliverySubQueryBindingSource
            // 
            this.sPDeliverySubQueryBindingSource.DataMember = "SP_DeliverySub_Query";
            this.sPDeliverySubQueryBindingSource.DataSource = this.dataSetP1B;
            // 
            // dataSetP1B
            // 
            this.dataSetP1B.DataSetName = "DataSetP1B";
            this.dataSetP1B.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sPZCommonIDBindingSource
            // 
            this.sPZCommonIDBindingSource.DataMember = "SP_Z_Common_ID";
            this.sPZCommonIDBindingSource.DataSource = this.dataSetP1B;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Location = new System.Drawing.Point(2, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 71);
            this.panel1.TabIndex = 0;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(31, 22);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(237, 29);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyUp);
            // 
            // btnProd
            // 
            this.btnProd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnProd.Location = new System.Drawing.Point(868, 3);
            this.btnProd.Name = "btnProd";
            this.btnProd.Size = new System.Drawing.Size(134, 29);
            this.btnProd.TabIndex = 20;
            this.btnProd.Text = "검사완료현황";
            this.btnProd.UseVisualStyleBackColor = true;
            this.btnProd.Visible = false;
            this.btnProd.Click += new System.EventHandler(this.btnProd_Click);
            // 
            // dataGridViewList
            // 
            this.dataGridViewList.AllowUserToAddRows = false;
            this.dataGridViewList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewList.AutoGenerateColumns = false;
            this.dataGridViewList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridViewList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewList.ColumnHeadersHeight = 35;
            this.dataGridViewList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.출하번호DataGridViewTextBoxColumn,
            this.출하요청일자DataGridViewTextBoxColumn,
            this.거래처IDDataGridViewTextBoxColumn,
            this.거래처명DataGridViewTextBoxColumn,
            this.영업담당DataGridViewTextBoxColumn,
            this.프로젝트명DataGridViewTextBoxColumn,
            this.현장정보DataGridViewTextBoxColumn,
            this.배송수단DataGridViewTextBoxColumn,
            this.배송정보DataGridViewTextBoxColumn,
            this.수주번호DataGridViewTextBoxColumn,
            this.비고DataGridViewTextBoxColumn,
            this.배송비용DataGridViewTextBoxColumn,
            this.포장단위DataGridViewTextBoxColumn,
            this.출하창고});
            this.dataGridViewList.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridViewList.DataSource = this.sPDeliveryMainQueryBindingSource;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewList.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewList.EnableHeadersVisualStyles = false;
            this.dataGridViewList.Location = new System.Drawing.Point(2, 132);
            this.dataGridViewList.MultiSelect = false;
            this.dataGridViewList.Name = "dataGridViewList";
            this.dataGridViewList.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewList.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewList.RowHeadersVisible = false;
            this.dataGridViewList.RowHeadersWidth = 35;
            this.dataGridViewList.RowTemplate.Height = 35;
            this.dataGridViewList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewList.Size = new System.Drawing.Size(302, 851);
            this.dataGridViewList.TabIndex = 2;
            this.dataGridViewList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewList_CellClick);
            // 
            // 출하번호DataGridViewTextBoxColumn
            // 
            this.출하번호DataGridViewTextBoxColumn.DataPropertyName = "출하번호";
            this.출하번호DataGridViewTextBoxColumn.HeaderText = "출하번호";
            this.출하번호DataGridViewTextBoxColumn.Name = "출하번호DataGridViewTextBoxColumn";
            this.출하번호DataGridViewTextBoxColumn.ReadOnly = true;
            this.출하번호DataGridViewTextBoxColumn.Visible = false;
            // 
            // 출하요청일자DataGridViewTextBoxColumn
            // 
            this.출하요청일자DataGridViewTextBoxColumn.DataPropertyName = "출하요청일자";
            this.출하요청일자DataGridViewTextBoxColumn.HeaderText = "요청일자";
            this.출하요청일자DataGridViewTextBoxColumn.Name = "출하요청일자DataGridViewTextBoxColumn";
            this.출하요청일자DataGridViewTextBoxColumn.ReadOnly = true;
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
            this.거래처명DataGridViewTextBoxColumn.HeaderText = "거래처명";
            this.거래처명DataGridViewTextBoxColumn.Name = "거래처명DataGridViewTextBoxColumn";
            this.거래처명DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 영업담당DataGridViewTextBoxColumn
            // 
            this.영업담당DataGridViewTextBoxColumn.DataPropertyName = "영업담당";
            this.영업담당DataGridViewTextBoxColumn.HeaderText = "영업담당";
            this.영업담당DataGridViewTextBoxColumn.Name = "영업담당DataGridViewTextBoxColumn";
            this.영업담당DataGridViewTextBoxColumn.ReadOnly = true;
            this.영업담당DataGridViewTextBoxColumn.Visible = false;
            // 
            // 프로젝트명DataGridViewTextBoxColumn
            // 
            this.프로젝트명DataGridViewTextBoxColumn.DataPropertyName = "프로젝트명";
            this.프로젝트명DataGridViewTextBoxColumn.HeaderText = "프로젝트명";
            this.프로젝트명DataGridViewTextBoxColumn.Name = "프로젝트명DataGridViewTextBoxColumn";
            this.프로젝트명DataGridViewTextBoxColumn.ReadOnly = true;
            this.프로젝트명DataGridViewTextBoxColumn.Visible = false;
            // 
            // 현장정보DataGridViewTextBoxColumn
            // 
            this.현장정보DataGridViewTextBoxColumn.DataPropertyName = "현장정보";
            this.현장정보DataGridViewTextBoxColumn.HeaderText = "현장정보";
            this.현장정보DataGridViewTextBoxColumn.Name = "현장정보DataGridViewTextBoxColumn";
            this.현장정보DataGridViewTextBoxColumn.ReadOnly = true;
            this.현장정보DataGridViewTextBoxColumn.Visible = false;
            // 
            // 배송수단DataGridViewTextBoxColumn
            // 
            this.배송수단DataGridViewTextBoxColumn.DataPropertyName = "배송수단";
            this.배송수단DataGridViewTextBoxColumn.HeaderText = "배송수단";
            this.배송수단DataGridViewTextBoxColumn.Name = "배송수단DataGridViewTextBoxColumn";
            this.배송수단DataGridViewTextBoxColumn.ReadOnly = true;
            this.배송수단DataGridViewTextBoxColumn.Visible = false;
            // 
            // 배송정보DataGridViewTextBoxColumn
            // 
            this.배송정보DataGridViewTextBoxColumn.DataPropertyName = "배송정보";
            this.배송정보DataGridViewTextBoxColumn.HeaderText = "배송정보";
            this.배송정보DataGridViewTextBoxColumn.Name = "배송정보DataGridViewTextBoxColumn";
            this.배송정보DataGridViewTextBoxColumn.ReadOnly = true;
            this.배송정보DataGridViewTextBoxColumn.Visible = false;
            // 
            // 수주번호DataGridViewTextBoxColumn
            // 
            this.수주번호DataGridViewTextBoxColumn.DataPropertyName = "수주번호";
            this.수주번호DataGridViewTextBoxColumn.HeaderText = "수주번호";
            this.수주번호DataGridViewTextBoxColumn.Name = "수주번호DataGridViewTextBoxColumn";
            this.수주번호DataGridViewTextBoxColumn.ReadOnly = true;
            this.수주번호DataGridViewTextBoxColumn.Visible = false;
            // 
            // 비고DataGridViewTextBoxColumn
            // 
            this.비고DataGridViewTextBoxColumn.DataPropertyName = "비고";
            this.비고DataGridViewTextBoxColumn.HeaderText = "비고";
            this.비고DataGridViewTextBoxColumn.Name = "비고DataGridViewTextBoxColumn";
            this.비고DataGridViewTextBoxColumn.ReadOnly = true;
            this.비고DataGridViewTextBoxColumn.Visible = false;
            // 
            // 배송비용DataGridViewTextBoxColumn
            // 
            this.배송비용DataGridViewTextBoxColumn.DataPropertyName = "배송비용";
            this.배송비용DataGridViewTextBoxColumn.HeaderText = "배송비용";
            this.배송비용DataGridViewTextBoxColumn.Name = "배송비용DataGridViewTextBoxColumn";
            this.배송비용DataGridViewTextBoxColumn.ReadOnly = true;
            this.배송비용DataGridViewTextBoxColumn.Visible = false;
            // 
            // 포장단위DataGridViewTextBoxColumn
            // 
            this.포장단위DataGridViewTextBoxColumn.DataPropertyName = "포장단위";
            this.포장단위DataGridViewTextBoxColumn.HeaderText = "포장단위";
            this.포장단위DataGridViewTextBoxColumn.Name = "포장단위DataGridViewTextBoxColumn";
            this.포장단위DataGridViewTextBoxColumn.ReadOnly = true;
            this.포장단위DataGridViewTextBoxColumn.Visible = false;
            // 
            // 출하창고
            // 
            this.출하창고.DataPropertyName = "출하창고";
            this.출하창고.HeaderText = "출하창고";
            this.출하창고.Name = "출하창고";
            this.출하창고.ReadOnly = true;
            this.출하창고.Visible = false;
            // 
            // sPDeliveryMainQueryBindingSource
            // 
            this.sPDeliveryMainQueryBindingSource.DataMember = "SP_DeliveryMain_Query";
            this.sPDeliveryMainQueryBindingSource.DataSource = this.dataSetP1B;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Location = new System.Drawing.Point(310, 350);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1011, 38);
            this.panel4.TabIndex = 25;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.panel3.Controls.Add(this.lblBarcode);
            this.panel3.Controls.Add(this.tbBarcode);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(469, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(541, 38);
            this.panel3.TabIndex = 25;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lblBarcode.ForeColor = System.Drawing.Color.Red;
            this.lblBarcode.Location = new System.Drawing.Point(4, 8);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(148, 21);
            this.lblBarcode.TabIndex = 26;
            this.lblBarcode.Text = "메시지 라벨입니다.";
            // 
            // tbBarcode
            // 
            this.tbBarcode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbBarcode.Location = new System.Drawing.Point(279, 4);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.Size = new System.Drawing.Size(244, 29);
            this.tbBarcode.TabIndex = 24;
            this.tbBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbBarcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbBarcode_KeyUp);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(215, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 25;
            this.label3.Text = "바코드";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.panel2.Controls.Add(this.lblTotMoney);
            this.panel2.Controls.Add(this.lblCnt);
            this.panel2.Controls.Add(this.lblSumMoney);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(472, 38);
            this.panel2.TabIndex = 24;
            // 
            // lblTotMoney
            // 
            this.lblTotMoney.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotMoney.AutoSize = true;
            this.lblTotMoney.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotMoney.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTotMoney.Location = new System.Drawing.Point(222, 8);
            this.lblTotMoney.Name = "lblTotMoney";
            this.lblTotMoney.Size = new System.Drawing.Size(115, 21);
            this.lblTotMoney.TabIndex = 4;
            this.lblTotMoney.Text = "전체금액 : 0원";
            // 
            // lblCnt
            // 
            this.lblCnt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCnt.AutoSize = true;
            this.lblCnt.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCnt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCnt.Location = new System.Drawing.Point(429, 8);
            this.lblCnt.Name = "lblCnt";
            this.lblCnt.Size = new System.Drawing.Size(35, 21);
            this.lblCnt.TabIndex = 5;
            this.lblCnt.Text = "0건";
            // 
            // lblSumMoney
            // 
            this.lblSumMoney.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSumMoney.AutoSize = true;
            this.lblSumMoney.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSumMoney.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSumMoney.Location = new System.Drawing.Point(8, 8);
            this.lblSumMoney.Name = "lblSumMoney";
            this.lblSumMoney.Size = new System.Drawing.Size(115, 21);
            this.lblSumMoney.TabIndex = 6;
            this.lblSumMoney.Text = "합계금액 : 0원";
            // 
            // sP_Z_Common_IDTableAdapter
            // 
            this.sP_Z_Common_IDTableAdapter.ClearBeforeFill = true;
            // 
            // sPDeliveryPrintBindingSource
            // 
            this.sPDeliveryPrintBindingSource.DataMember = "SP_Delivery_Print";
            this.sPDeliveryPrintBindingSource.DataSource = this.dataSetP1B;
            // 
            // sP_Delivery_PrintTableAdapter
            // 
            this.sP_Delivery_PrintTableAdapter.ClearBeforeFill = true;
            // 
            // panSearch
            // 
            this.panSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panSearch.AutoSize = true;
            this.panSearch.BackColor = System.Drawing.SystemColors.Info;
            this.panSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSearch.Controls.Add(this.btnBarcode);
            this.panSearch.Controls.Add(this.cbDeport);
            this.panSearch.Controls.Add(this.label9);
            this.panSearch.Controls.Add(this.lblMsg);
            this.panSearch.Controls.Add(this.label5);
            this.panSearch.Controls.Add(this.tbDeliCost);
            this.panSearch.Controls.Add(this.btnProd);
            this.panSearch.Controls.Add(this.cbPackingType);
            this.panSearch.Controls.Add(this.label4);
            this.panSearch.Controls.Add(this.tbRorder);
            this.panSearch.Controls.Add(this.label1);
            this.panSearch.Controls.Add(this.cbDeliCar);
            this.panSearch.Controls.Add(this.label6);
            this.panSearch.Controls.Add(this.tbContents);
            this.panSearch.Controls.Add(this.tbPlace);
            this.panSearch.Controls.Add(this.tbCust);
            this.panSearch.Controls.Add(this.dtpDate);
            this.panSearch.Controls.Add(this.tbNo);
            this.panSearch.Controls.Add(this.label10);
            this.panSearch.Controls.Add(this.label7);
            this.panSearch.Controls.Add(this.lblCust);
            this.panSearch.Controls.Add(this.tbDeliInfo);
            this.panSearch.Controls.Add(this.label2);
            this.panSearch.Controls.Add(this.label8);
            this.panSearch.Controls.Add(this.cbNo);
            this.panSearch.Location = new System.Drawing.Point(310, 58);
            this.panSearch.Name = "panSearch";
            this.panSearch.Size = new System.Drawing.Size(1011, 286);
            this.panSearch.TabIndex = 26;
            // 
            // btnBarcode
            // 
            this.btnBarcode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBarcode.Location = new System.Drawing.Point(460, 56);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(134, 29);
            this.btnBarcode.TabIndex = 24;
            this.btnBarcode.Text = "바코드 출력";
            this.btnBarcode.UseVisualStyleBackColor = true;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // cbDeport
            // 
            this.cbDeport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbDeport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeport.FormattingEnabled = true;
            this.cbDeport.Items.AddRange(new object[] {
            "1.Box",
            "2.Pallet"});
            this.cbDeport.Location = new System.Drawing.Point(460, 135);
            this.cbDeport.Name = "cbDeport";
            this.cbDeport.Size = new System.Drawing.Size(211, 29);
            this.cbDeport.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(383, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 21);
            this.label9.TabIndex = 22;
            this.label9.Text = "출하창고";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(3, 255);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(148, 21);
            this.lblMsg.TabIndex = 21;
            this.lblMsg.Text = "메시지 라벨입니다.";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(383, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 19;
            this.label5.Text = "배송비용";
            // 
            // tbDeliCost
            // 
            this.tbDeliCost.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbDeliCost.Location = new System.Drawing.Point(460, 175);
            this.tbDeliCost.Name = "tbDeliCost";
            this.tbDeliCost.Size = new System.Drawing.Size(211, 29);
            this.tbDeliCost.TabIndex = 20;
            this.tbDeliCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbPackingType
            // 
            this.cbPackingType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbPackingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPackingType.FormattingEnabled = true;
            this.cbPackingType.Items.AddRange(new object[] {
            "1.Box",
            "2.Pallet"});
            this.cbPackingType.Location = new System.Drawing.Point(145, 135);
            this.cbPackingType.Name = "cbPackingType";
            this.cbPackingType.Size = new System.Drawing.Size(211, 29);
            this.cbPackingType.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(54, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 17;
            this.label4.Text = "포장단위";
            // 
            // tbRorder
            // 
            this.tbRorder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbRorder.Location = new System.Drawing.Point(460, 15);
            this.tbRorder.Name = "tbRorder";
            this.tbRorder.ReadOnly = true;
            this.tbRorder.Size = new System.Drawing.Size(211, 29);
            this.tbRorder.TabIndex = 16;
            this.tbRorder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(383, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "수주번호";
            // 
            // cbDeliCar
            // 
            this.cbDeliCar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbDeliCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeliCar.FormattingEnabled = true;
            this.cbDeliCar.Items.AddRange(new object[] {
            "1.용차",
            "2.택배",
            "3.직납",
            "4.자차",
            "5.퀵",
            "9.기타"});
            this.cbDeliCar.Location = new System.Drawing.Point(145, 175);
            this.cbDeliCar.Name = "cbDeliCar";
            this.cbDeliCar.Size = new System.Drawing.Size(211, 29);
            this.cbDeliCar.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(383, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "현장정보";
            // 
            // tbContents
            // 
            this.tbContents.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbContents.Location = new System.Drawing.Point(145, 215);
            this.tbContents.Name = "tbContents";
            this.tbContents.Size = new System.Drawing.Size(526, 29);
            this.tbContents.TabIndex = 12;
            // 
            // tbPlace
            // 
            this.tbPlace.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbPlace.Location = new System.Drawing.Point(460, 95);
            this.tbPlace.Name = "tbPlace";
            this.tbPlace.Size = new System.Drawing.Size(211, 29);
            this.tbPlace.TabIndex = 8;
            this.tbPlace.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCust
            // 
            this.tbCust.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbCust.Location = new System.Drawing.Point(145, 95);
            this.tbCust.Name = "tbCust";
            this.tbCust.ReadOnly = true;
            this.tbCust.Size = new System.Drawing.Size(211, 29);
            this.tbCust.TabIndex = 6;
            this.tbCust.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpDate.CalendarFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpDate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpDate.Location = new System.Drawing.Point(145, 55);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(211, 29);
            this.dtpDate.TabIndex = 5;
            // 
            // tbNo
            // 
            this.tbNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbNo.Location = new System.Drawing.Point(145, 16);
            this.tbNo.Name = "tbNo";
            this.tbNo.ReadOnly = true;
            this.tbNo.Size = new System.Drawing.Size(211, 29);
            this.tbNo.TabIndex = 4;
            this.tbNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(54, 218);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 21);
            this.label10.TabIndex = 0;
            this.label10.Text = "비  고";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(54, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "배송수단";
            // 
            // lblCust
            // 
            this.lblCust.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCust.AutoSize = true;
            this.lblCust.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCust.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCust.Location = new System.Drawing.Point(54, 99);
            this.lblCust.Name = "lblCust";
            this.lblCust.Size = new System.Drawing.Size(74, 21);
            this.lblCust.TabIndex = 0;
            this.lblCust.Text = "거래처명";
            // 
            // tbDeliInfo
            // 
            this.tbDeliInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbDeliInfo.Location = new System.Drawing.Point(693, 56);
            this.tbDeliInfo.Multiline = true;
            this.tbDeliInfo.Name = "tbDeliInfo";
            this.tbDeliInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDeliInfo.Size = new System.Drawing.Size(264, 188);
            this.tbDeliInfo.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(689, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "배송정보";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(54, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "요청일자";
            // 
            // cbNo
            // 
            this.cbNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbNo.AutoSize = true;
            this.cbNo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbNo.Location = new System.Drawing.Point(39, 18);
            this.cbNo.Name = "cbNo";
            this.cbNo.Size = new System.Drawing.Size(93, 25);
            this.cbNo.TabIndex = 3;
            this.cbNo.Text = "출고번호";
            this.cbNo.UseVisualStyleBackColor = true;
            // 
            // sP_DeliverySub_QueryTableAdapter
            // 
            this.sP_DeliverySub_QueryTableAdapter.ClearBeforeFill = true;
            // 
            // sP_DeliveryMain_QueryTableAdapter
            // 
            this.sP_DeliveryMain_QueryTableAdapter.ClearBeforeFill = true;
            // 
            // 출하번호DataGridViewTextBoxColumn1
            // 
            this.출하번호DataGridViewTextBoxColumn1.DataPropertyName = "출하번호";
            this.출하번호DataGridViewTextBoxColumn1.HeaderText = "출하번호";
            this.출하번호DataGridViewTextBoxColumn1.Name = "출하번호DataGridViewTextBoxColumn1";
            this.출하번호DataGridViewTextBoxColumn1.Visible = false;
            // 
            // 순번DataGridViewTextBoxColumn
            // 
            this.순번DataGridViewTextBoxColumn.DataPropertyName = "순번";
            this.순번DataGridViewTextBoxColumn.FillWeight = 40F;
            this.순번DataGridViewTextBoxColumn.HeaderText = "순번";
            this.순번DataGridViewTextBoxColumn.Name = "순번DataGridViewTextBoxColumn";
            this.순번DataGridViewTextBoxColumn.Visible = false;
            // 
            // 출하창고DataGridViewTextBoxColumn
            // 
            this.출하창고DataGridViewTextBoxColumn.DataPropertyName = "출하창고";
            this.출하창고DataGridViewTextBoxColumn.HeaderText = "출하창고";
            this.출하창고DataGridViewTextBoxColumn.Name = "출하창고DataGridViewTextBoxColumn";
            this.출하창고DataGridViewTextBoxColumn.Visible = false;
            // 
            // 품목코드DataGridViewTextBoxColumn
            // 
            this.품목코드DataGridViewTextBoxColumn.DataPropertyName = "품목코드";
            this.품목코드DataGridViewTextBoxColumn.HeaderText = "품목코드";
            this.품목코드DataGridViewTextBoxColumn.Name = "품목코드DataGridViewTextBoxColumn";
            this.품목코드DataGridViewTextBoxColumn.Visible = false;
            // 
            // 품목명DataGridViewTextBoxColumn
            // 
            this.품목명DataGridViewTextBoxColumn.DataPropertyName = "품목명";
            this.품목명DataGridViewTextBoxColumn.HeaderText = "품목명";
            this.품목명DataGridViewTextBoxColumn.Name = "품목명DataGridViewTextBoxColumn";
            // 
            // 제품명DataGridViewTextBoxColumn
            // 
            this.제품명DataGridViewTextBoxColumn.DataPropertyName = "제품명";
            this.제품명DataGridViewTextBoxColumn.HeaderText = "제품명";
            this.제품명DataGridViewTextBoxColumn.Name = "제품명DataGridViewTextBoxColumn";
            this.제품명DataGridViewTextBoxColumn.Visible = false;
            // 
            // 단위DataGridViewTextBoxColumn
            // 
            this.단위DataGridViewTextBoxColumn.DataPropertyName = "단위";
            this.단위DataGridViewTextBoxColumn.HeaderText = "단위";
            this.단위DataGridViewTextBoxColumn.Name = "단위DataGridViewTextBoxColumn";
            // 
            // 수량DataGridViewTextBoxColumn
            // 
            this.수량DataGridViewTextBoxColumn.DataPropertyName = "수량";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.수량DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.수량DataGridViewTextBoxColumn.HeaderText = "수량";
            this.수량DataGridViewTextBoxColumn.Name = "수량DataGridViewTextBoxColumn";
            // 
            // 단가DataGridViewTextBoxColumn
            // 
            this.단가DataGridViewTextBoxColumn.DataPropertyName = "단가";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.단가DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.단가DataGridViewTextBoxColumn.HeaderText = "단가";
            this.단가DataGridViewTextBoxColumn.Name = "단가DataGridViewTextBoxColumn";
            // 
            // 금액DataGridViewTextBoxColumn
            // 
            this.금액DataGridViewTextBoxColumn.DataPropertyName = "금액";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.금액DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.금액DataGridViewTextBoxColumn.HeaderText = "금액";
            this.금액DataGridViewTextBoxColumn.Name = "금액DataGridViewTextBoxColumn";
            // 
            // 부가세DataGridViewTextBoxColumn
            // 
            this.부가세DataGridViewTextBoxColumn.DataPropertyName = "부가세";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.부가세DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.부가세DataGridViewTextBoxColumn.HeaderText = "부가세";
            this.부가세DataGridViewTextBoxColumn.Name = "부가세DataGridViewTextBoxColumn";
            // 
            // 합계금액DataGridViewTextBoxColumn
            // 
            this.합계금액DataGridViewTextBoxColumn.DataPropertyName = "합계금액";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.합계금액DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.합계금액DataGridViewTextBoxColumn.HeaderText = "합계금액";
            this.합계금액DataGridViewTextBoxColumn.Name = "합계금액DataGridViewTextBoxColumn";
            // 
            // 수주번호DataGridViewTextBoxColumn1
            // 
            this.수주번호DataGridViewTextBoxColumn1.DataPropertyName = "수주번호";
            this.수주번호DataGridViewTextBoxColumn1.HeaderText = "수주번호";
            this.수주번호DataGridViewTextBoxColumn1.Name = "수주번호DataGridViewTextBoxColumn1";
            this.수주번호DataGridViewTextBoxColumn1.Visible = false;
            // 
            // ColumnDel
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.NullValue = "X";
            this.ColumnDel.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColumnDel.FillWeight = 30F;
            this.ColumnDel.HeaderText = "";
            this.ColumnDel.Name = "ColumnDel";
            this.ColumnDel.Text = "X";
            this.ColumnDel.Visible = false;
            // 
            // Column1
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.NullValue = "0";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column1.FillWeight = 30F;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.TrueValue = "1";
            this.Column1.Visible = false;
            // 
            // P1B05_DELIVERY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.ClientSize = new System.Drawing.Size(1325, 990);
            this.Controls.Add(this.panSearch);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataGridViewList);
            this.Controls.Add(this.panel1);
            this.Name = "P1B05_DELIVERY";
            this.Tag = "";
            this.Text = "P1B05_DELIVERY";
            this.Load += new System.EventHandler(this.P1B05_DELIVERY_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dataGridViewList, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.Controls.SetChildIndex(this.panSearch, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPDeliverySubQueryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPZCommonIDBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPDeliveryMainQueryBindingSource)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sPDeliveryPrintBindingSource)).EndInit();
            this.panSearch.ResumeLayout(false);
            this.panSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dataGridViewList;
        public System.Windows.Forms.TextBox tbSearch;
        private P1B.DataSetP1B dataSetP1B;
        private System.Windows.Forms.BindingSource sPZCommonIDBindingSource;
        private P1B.DataSetP1BTableAdapters.SP_Z_Common_IDTableAdapter sP_Z_Common_IDTableAdapter;
        private System.Windows.Forms.BindingSource sPDeliveryPrintBindingSource;
        private P1B.DataSetP1BTableAdapters.SP_Delivery_PrintTableAdapter sP_Delivery_PrintTableAdapter;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblBarcode;
        public System.Windows.Forms.TextBox tbBarcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotMoney;
        private System.Windows.Forms.Label lblCnt;
        private System.Windows.Forms.Label lblSumMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn 전표번호DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 사업장DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 출하일자DataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnProd;
        private System.Windows.Forms.Panel panSearch;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox tbDeliCost;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tbRorder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDeliCar;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox tbContents;
        public System.Windows.Forms.TextBox tbPlace;
        public System.Windows.Forms.TextBox tbCust;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCust;
        private System.Windows.Forms.TextBox tbDeliInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbNo;
        private System.Windows.Forms.Label lblMsg;
        private P1B.DataSetP1BTableAdapters.SP_DeliverySub_QueryTableAdapter sP_DeliverySub_QueryTableAdapter;
        private System.Windows.Forms.BindingSource sPDeliveryMainQueryBindingSource;
        private P1B.DataSetP1BTableAdapters.SP_DeliveryMain_QueryTableAdapter sP_DeliveryMain_QueryTableAdapter;
        public System.Windows.Forms.BindingSource sPDeliverySubQueryBindingSource;
        private System.Windows.Forms.ComboBox cbDeport;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox tbNo;
        public System.Windows.Forms.ComboBox cbPackingType;
        private System.Windows.Forms.DataGridViewTextBoxColumn 출하번호DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 출하요청일자DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 거래처IDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 거래처명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 영업담당DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 프로젝트명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 현장정보DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송수단DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송정보DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주번호DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 비고DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송비용DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 포장단위DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 출하창고;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn 출하번호DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 순번DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 출하창고DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 품목코드DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 품목명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 제품명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 단위DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수량DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 단가DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 금액DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 부가세DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 합계금액DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주번호DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnDel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
    }
}
