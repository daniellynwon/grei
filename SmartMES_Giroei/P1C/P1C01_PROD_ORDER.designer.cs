namespace SmartMES_Giroei
{
    partial class P1C01_PROD_ORDER
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panSearch = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sPProdOrderQueryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetP1C = new SmartMES_Giroei.P1C.DataSetP1C();
            this.sP_ProdOrder_QueryTableAdapter = new SmartMES_Giroei.P1C.DataSetP1CTableAdapters.SP_ProdOrder_QueryTableAdapter();
            this.일자DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.거래처코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.거래처명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.프로젝트명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.납기 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.품목코드DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.품목명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.규격 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.유형 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.지시수량 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.공정명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.단위 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수주번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수주순번 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.솔더사양 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MM번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.시작시간 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.종료시간 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.작업자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.지시사항 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수주일자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.책임자ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.책임자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.경과시간 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.완료여부 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.작업시작 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.작업종료 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.양품수량 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.불량수량 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.panSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPProdOrderQueryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1C)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "생산투입정보(작업지시)";
            // 
            // pbPrint
            // 
            this.pbPrint.Enabled = true;
            this.pbPrint.Image = global::SmartMES_Giroei.Properties.Resources.out_A;
            this.pbPrint.Click += new System.EventHandler(this.pbPrint_Click);
            // 
            // pbSave
            // 
            this.pbSave.Image = global::SmartMES_Giroei.Properties.Resources.save_B;
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
            this.pbAdd.Image = global::SmartMES_Giroei.Properties.Resources.add_A;
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
            this.panSearch.Controls.Add(this.lblMsg);
            this.panSearch.Controls.Add(this.tbSearch);
            this.panSearch.Controls.Add(this.label5);
            this.panSearch.Controls.Add(this.label3);
            this.panSearch.Controls.Add(this.label4);
            this.panSearch.Controls.Add(this.dtpToDate);
            this.panSearch.Controls.Add(this.dtpFromDate);
            this.panSearch.Location = new System.Drawing.Point(2, 58);
            this.panSearch.Name = "panSearch";
            this.panSearch.Size = new System.Drawing.Size(1319, 71);
            this.panSearch.TabIndex = 0;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(15, 48);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(148, 21);
            this.lblMsg.TabIndex = 5;
            this.lblMsg.Text = "메시지 라벨입니다.";
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbSearch.BackColor = System.Drawing.SystemColors.Window;
            this.tbSearch.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSearch.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbSearch.Location = new System.Drawing.Point(995, 19);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(176, 29);
            this.tbSearch.TabIndex = 3;
            this.tbSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyUp);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(791, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "품목코드/품목명/거래처명";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(484, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "~";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(170, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Lot생성기간";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpToDate.CalendarFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpToDate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpToDate.Location = new System.Drawing.Point(507, 19);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(211, 29);
            this.dtpToDate.TabIndex = 2;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFromDate.CalendarFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpFromDate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpFromDate.Location = new System.Drawing.Point(271, 19);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(211, 29);
            this.dtpFromDate.TabIndex = 1;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
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
            this.일자DataGridViewTextBoxColumn,
            this.lotNoDataGridViewTextBoxColumn,
            this.거래처코드,
            this.거래처명,
            this.프로젝트명,
            this.납기,
            this.품목코드DataGridViewTextBoxColumn,
            this.품목명DataGridViewTextBoxColumn,
            this.규격,
            this.유형,
            this.지시수량,
            this.공정명,
            this.단위,
            this.수주번호,
            this.수주순번,
            this.솔더사양,
            this.MM번호,
            this.시작시간,
            this.종료시간,
            this.작업자,
            this.지시사항,
            this.수주일자,
            this.책임자ID,
            this.책임자,
            this.경과시간,
            this.완료여부,
            this.작업시작,
            this.작업종료,
            this.양품수량,
            this.불량수량,
            this.Column1});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView1.DataSource = this.sPProdOrderQueryBindingSource;
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
            this.dataGridView1.Size = new System.Drawing.Size(1319, 858);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // sPProdOrderQueryBindingSource
            // 
            this.sPProdOrderQueryBindingSource.DataMember = "SP_ProdOrder_Query";
            this.sPProdOrderQueryBindingSource.DataSource = this.dataSetP1C;
            // 
            // dataSetP1C
            // 
            this.dataSetP1C.DataSetName = "DataSetP1C";
            this.dataSetP1C.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sP_ProdOrder_QueryTableAdapter
            // 
            this.sP_ProdOrder_QueryTableAdapter.ClearBeforeFill = true;
            // 
            // 일자DataGridViewTextBoxColumn
            // 
            this.일자DataGridViewTextBoxColumn.DataPropertyName = "일자";
            dataGridViewCellStyle3.Format = "MM\\/dd";
            this.일자DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.일자DataGridViewTextBoxColumn.FillWeight = 40F;
            this.일자DataGridViewTextBoxColumn.HeaderText = "일자";
            this.일자DataGridViewTextBoxColumn.Name = "일자DataGridViewTextBoxColumn";
            this.일자DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lotNoDataGridViewTextBoxColumn
            // 
            this.lotNoDataGridViewTextBoxColumn.DataPropertyName = "LotNo";
            this.lotNoDataGridViewTextBoxColumn.FillWeight = 70F;
            this.lotNoDataGridViewTextBoxColumn.HeaderText = "LotNo";
            this.lotNoDataGridViewTextBoxColumn.Name = "lotNoDataGridViewTextBoxColumn";
            this.lotNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNoDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lotNoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 거래처코드
            // 
            this.거래처코드.DataPropertyName = "거래처코드";
            this.거래처코드.HeaderText = "거래처코드";
            this.거래처코드.Name = "거래처코드";
            this.거래처코드.ReadOnly = true;
            this.거래처코드.Visible = false;
            // 
            // 거래처명
            // 
            this.거래처명.DataPropertyName = "거래처명";
            this.거래처명.FillWeight = 50F;
            this.거래처명.HeaderText = "거래처명";
            this.거래처명.Name = "거래처명";
            this.거래처명.ReadOnly = true;
            // 
            // 프로젝트명
            // 
            this.프로젝트명.DataPropertyName = "프로젝트명";
            this.프로젝트명.HeaderText = "프로젝트명";
            this.프로젝트명.Name = "프로젝트명";
            this.프로젝트명.ReadOnly = true;
            this.프로젝트명.Visible = false;
            // 
            // 납기
            // 
            this.납기.DataPropertyName = "납기";
            this.납기.FillWeight = 60F;
            this.납기.HeaderText = "납기";
            this.납기.Name = "납기";
            this.납기.ReadOnly = true;
            // 
            // 품목코드DataGridViewTextBoxColumn
            // 
            this.품목코드DataGridViewTextBoxColumn.DataPropertyName = "품목코드";
            this.품목코드DataGridViewTextBoxColumn.HeaderText = "품목코드";
            this.품목코드DataGridViewTextBoxColumn.Name = "품목코드DataGridViewTextBoxColumn";
            this.품목코드DataGridViewTextBoxColumn.ReadOnly = true;
            this.품목코드DataGridViewTextBoxColumn.Visible = false;
            // 
            // 품목명DataGridViewTextBoxColumn
            // 
            this.품목명DataGridViewTextBoxColumn.DataPropertyName = "품목명";
            this.품목명DataGridViewTextBoxColumn.HeaderText = "품목명";
            this.품목명DataGridViewTextBoxColumn.Name = "품목명DataGridViewTextBoxColumn";
            this.품목명DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 규격
            // 
            this.규격.DataPropertyName = "규격";
            this.규격.HeaderText = "규격";
            this.규격.Name = "규격";
            this.규격.ReadOnly = true;
            this.규격.Visible = false;
            // 
            // 유형
            // 
            this.유형.DataPropertyName = "유형";
            this.유형.FillWeight = 35F;
            this.유형.HeaderText = "유형";
            this.유형.Name = "유형";
            this.유형.ReadOnly = true;
            // 
            // 지시수량
            // 
            this.지시수량.DataPropertyName = "지시수량";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,##0";
            this.지시수량.DefaultCellStyle = dataGridViewCellStyle4;
            this.지시수량.FillWeight = 40F;
            this.지시수량.HeaderText = "수량";
            this.지시수량.Name = "지시수량";
            this.지시수량.ReadOnly = true;
            // 
            // 공정명
            // 
            this.공정명.DataPropertyName = "공정명";
            this.공정명.FillWeight = 40F;
            this.공정명.HeaderText = "작업라인";
            this.공정명.Name = "공정명";
            this.공정명.ReadOnly = true;
            // 
            // 단위
            // 
            this.단위.DataPropertyName = "단위";
            this.단위.FillWeight = 40F;
            this.단위.HeaderText = "단위";
            this.단위.Name = "단위";
            this.단위.ReadOnly = true;
            // 
            // 수주번호
            // 
            this.수주번호.DataPropertyName = "수주번호";
            this.수주번호.FillWeight = 70F;
            this.수주번호.HeaderText = "수주번호";
            this.수주번호.Name = "수주번호";
            this.수주번호.ReadOnly = true;
            // 
            // 수주순번
            // 
            this.수주순번.DataPropertyName = "수주순번";
            this.수주순번.HeaderText = "수주순번";
            this.수주순번.Name = "수주순번";
            this.수주순번.ReadOnly = true;
            this.수주순번.Visible = false;
            // 
            // 솔더사양
            // 
            this.솔더사양.DataPropertyName = "솔더사양";
            this.솔더사양.FillWeight = 35F;
            this.솔더사양.HeaderText = "솔더사양";
            this.솔더사양.Name = "솔더사양";
            this.솔더사양.ReadOnly = true;
            this.솔더사양.Visible = false;
            // 
            // MM번호
            // 
            this.MM번호.DataPropertyName = "MM번호";
            this.MM번호.FillWeight = 40F;
            this.MM번호.HeaderText = "M/Mask";
            this.MM번호.Name = "MM번호";
            this.MM번호.ReadOnly = true;
            this.MM번호.Visible = false;
            // 
            // 시작시간
            // 
            this.시작시간.DataPropertyName = "시작시간";
            this.시작시간.HeaderText = "시작시간";
            this.시작시간.Name = "시작시간";
            this.시작시간.ReadOnly = true;
            this.시작시간.Visible = false;
            // 
            // 종료시간
            // 
            this.종료시간.DataPropertyName = "종료시간";
            this.종료시간.HeaderText = "종료시간";
            this.종료시간.Name = "종료시간";
            this.종료시간.ReadOnly = true;
            this.종료시간.Visible = false;
            // 
            // 작업자
            // 
            this.작업자.DataPropertyName = "작업자";
            this.작업자.HeaderText = "작업자";
            this.작업자.Name = "작업자";
            this.작업자.ReadOnly = true;
            this.작업자.Visible = false;
            // 
            // 지시사항
            // 
            this.지시사항.DataPropertyName = "지시사항";
            this.지시사항.HeaderText = "지시사항";
            this.지시사항.Name = "지시사항";
            this.지시사항.ReadOnly = true;
            this.지시사항.Visible = false;
            // 
            // 수주일자
            // 
            this.수주일자.DataPropertyName = "수주일자";
            this.수주일자.HeaderText = "수주일자";
            this.수주일자.Name = "수주일자";
            this.수주일자.ReadOnly = true;
            this.수주일자.Visible = false;
            // 
            // 책임자ID
            // 
            this.책임자ID.DataPropertyName = "책임자ID";
            this.책임자ID.HeaderText = "책임자ID";
            this.책임자ID.Name = "책임자ID";
            this.책임자ID.ReadOnly = true;
            this.책임자ID.Visible = false;
            // 
            // 책임자
            // 
            this.책임자.DataPropertyName = "책임자";
            this.책임자.FillWeight = 50F;
            this.책임자.HeaderText = "책임자";
            this.책임자.Name = "책임자";
            this.책임자.ReadOnly = true;
            // 
            // 경과시간
            // 
            this.경과시간.DataPropertyName = "경과시간";
            this.경과시간.FillWeight = 75F;
            this.경과시간.HeaderText = "경과시간";
            this.경과시간.Name = "경과시간";
            this.경과시간.ReadOnly = true;
            // 
            // 완료여부
            // 
            this.완료여부.DataPropertyName = "완료여부";
            this.완료여부.FillWeight = 30F;
            this.완료여부.HeaderText = "상태";
            this.완료여부.Name = "완료여부";
            this.완료여부.ReadOnly = true;
            // 
            // 작업시작
            // 
            this.작업시작.DataPropertyName = "작업시작";
            this.작업시작.HeaderText = "작업시작";
            this.작업시작.Name = "작업시작";
            this.작업시작.ReadOnly = true;
            this.작업시작.Visible = false;
            // 
            // 작업종료
            // 
            this.작업종료.DataPropertyName = "작업종료";
            this.작업종료.HeaderText = "작업종료";
            this.작업종료.Name = "작업종료";
            this.작업종료.ReadOnly = true;
            this.작업종료.Visible = false;
            // 
            // 양품수량
            // 
            this.양품수량.DataPropertyName = "양품수량";
            this.양품수량.HeaderText = "양품수량";
            this.양품수량.Name = "양품수량";
            this.양품수량.ReadOnly = true;
            this.양품수량.Visible = false;
            // 
            // 불량수량
            // 
            this.불량수량.DataPropertyName = "불량수량";
            this.불량수량.HeaderText = "불량수량";
            this.불량수량.Name = "불량수량";
            this.불량수량.ReadOnly = true;
            this.불량수량.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "작업라인";
            this.Column1.HeaderText = "라인";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // P1C01_PROD_ORDER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.ClientSize = new System.Drawing.Size(1325, 990);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panSearch);
            this.Name = "P1C01_PROD_ORDER";
            this.Text = "P1C01_PROD_ORDER";
            this.Load += new System.EventHandler(this.P1C01_PROD_ORDER_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.sPProdOrderQueryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1C)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker dtpToDate;
        public System.Windows.Forms.DateTimePicker dtpFromDate;
        public System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 제품명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 생산그룹IDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 생산그룹DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot번호DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 공정번호DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 공정명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn 작업조DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업지도DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 완료여부DataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource sPProdOrderQueryBindingSource;
        private P1C.DataSetP1C dataSetP1C;
        private P1C.DataSetP1CTableAdapters.SP_ProdOrder_QueryTableAdapter sP_ProdOrder_QueryTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn 지시일자DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수량DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 완료DataGridViewTextBoxColumn;
        public System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn 일자DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn lotNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 거래처코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn 거래처명;
        private System.Windows.Forms.DataGridViewTextBoxColumn 프로젝트명;
        private System.Windows.Forms.DataGridViewTextBoxColumn 납기;
        private System.Windows.Forms.DataGridViewTextBoxColumn 품목코드DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 품목명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 규격;
        private System.Windows.Forms.DataGridViewTextBoxColumn 유형;
        private System.Windows.Forms.DataGridViewTextBoxColumn 지시수량;
        private System.Windows.Forms.DataGridViewTextBoxColumn 공정명;
        private System.Windows.Forms.DataGridViewTextBoxColumn 단위;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주번호;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주순번;
        private System.Windows.Forms.DataGridViewTextBoxColumn 솔더사양;
        private System.Windows.Forms.DataGridViewTextBoxColumn MM번호;
        private System.Windows.Forms.DataGridViewTextBoxColumn 시작시간;
        private System.Windows.Forms.DataGridViewTextBoxColumn 종료시간;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업자;
        private System.Windows.Forms.DataGridViewTextBoxColumn 지시사항;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주일자;
        private System.Windows.Forms.DataGridViewTextBoxColumn 책임자ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 책임자;
        private System.Windows.Forms.DataGridViewTextBoxColumn 경과시간;
        private System.Windows.Forms.DataGridViewTextBoxColumn 완료여부;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업시작;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업종료;
        private System.Windows.Forms.DataGridViewTextBoxColumn 양품수량;
        private System.Windows.Forms.DataGridViewTextBoxColumn 불량수량;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}
