namespace SmartMES_Giroei
{
    partial class P1C02_PROD_RESULT1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panSearch = new System.Windows.Forms.Panel();
            this.tbQty = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbWorkLine = new System.Windows.Forms.ComboBox();
            this.tbJobNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpDoneTime = new System.Windows.Forms.MaskedTextBox();
            this.dtpStartTime = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbProd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sPProdResultQuery1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetP1C = new SmartMES_Giroei.P1C.DataSetP1C();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.sP_ProdResult_Query1TableAdapter = new SmartMES_Giroei.P1C.DataSetP1CTableAdapters.SP_ProdResult_Query1TableAdapter();
            this.순번 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.작업라인DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.품목코드DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.품목명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.시작시간DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.종료시간DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.경과시간DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.지시수량DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.생산량 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.진행상황 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.수주번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수주순번 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.panSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPProdResultQuery1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1C)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "생산현황모니터링";
            // 
            // pbPrint
            // 
            this.pbPrint.Image = global::SmartMES_Giroei.Properties.Resources.out_B;
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
            this.panSearch.Controls.Add(this.tbQty);
            this.panSearch.Controls.Add(this.label8);
            this.panSearch.Controls.Add(this.label1);
            this.panSearch.Controls.Add(this.cbWorkLine);
            this.panSearch.Controls.Add(this.tbJobNo);
            this.panSearch.Controls.Add(this.label10);
            this.panSearch.Controls.Add(this.dtpDoneTime);
            this.panSearch.Controls.Add(this.dtpStartTime);
            this.panSearch.Controls.Add(this.label6);
            this.panSearch.Controls.Add(this.label2);
            this.panSearch.Controls.Add(this.tbProd);
            this.panSearch.Controls.Add(this.label5);
            this.panSearch.Controls.Add(this.label4);
            this.panSearch.Controls.Add(this.dtpDate);
            this.panSearch.Location = new System.Drawing.Point(2, 58);
            this.panSearch.Name = "panSearch";
            this.panSearch.Size = new System.Drawing.Size(1319, 104);
            this.panSearch.TabIndex = 0;
            // 
            // tbQty
            // 
            this.tbQty.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbQty.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbQty.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbQty.Location = new System.Drawing.Point(798, 60);
            this.tbQty.Name = "tbQty";
            this.tbQty.ReadOnly = true;
            this.tbQty.Size = new System.Drawing.Size(172, 29);
            this.tbQty.TabIndex = 47;
            this.tbQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbQty.Visible = false;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(718, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 21);
            this.label8.TabIndex = 46;
            this.label8.Text = "목표수량";
            this.label8.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(718, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 45;
            this.label1.Text = "작업라인";
            // 
            // cbWorkLine
            // 
            this.cbWorkLine.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbWorkLine.BackColor = System.Drawing.SystemColors.Window;
            this.cbWorkLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorkLine.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.cbWorkLine.FormattingEnabled = true;
            this.cbWorkLine.Location = new System.Drawing.Point(798, 19);
            this.cbWorkLine.Name = "cbWorkLine";
            this.cbWorkLine.Size = new System.Drawing.Size(172, 29);
            this.cbWorkLine.TabIndex = 44;
            this.cbWorkLine.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedIndexChanged);
            // 
            // tbJobNo
            // 
            this.tbJobNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbJobNo.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbJobNo.ForeColor = System.Drawing.Color.Blue;
            this.tbJobNo.Location = new System.Drawing.Point(453, 19);
            this.tbJobNo.Name = "tbJobNo";
            this.tbJobNo.ReadOnly = true;
            this.tbJobNo.Size = new System.Drawing.Size(211, 29);
            this.tbJobNo.TabIndex = 43;
            this.tbJobNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbJobNo.Visible = false;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(369, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 21);
            this.label10.TabIndex = 42;
            this.label10.Text = "LotNo.";
            this.label10.Visible = false;
            // 
            // dtpDoneTime
            // 
            this.dtpDoneTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpDoneTime.Location = new System.Drawing.Point(453, 56);
            this.dtpDoneTime.Mask = "0000-90-90 90:90:90";
            this.dtpDoneTime.Name = "dtpDoneTime";
            this.dtpDoneTime.Size = new System.Drawing.Size(211, 29);
            this.dtpDoneTime.TabIndex = 39;
            this.dtpDoneTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpDoneTime.Visible = false;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpStartTime.Location = new System.Drawing.Point(112, 56);
            this.dtpStartTime.Mask = "0000-90-90 90:90:90";
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(211, 29);
            this.dtpStartTime.TabIndex = 38;
            this.dtpStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpStartTime.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(32, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 21);
            this.label6.TabIndex = 40;
            this.label6.Text = "시작시간";
            this.label6.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(369, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 41;
            this.label2.Text = "종료시간";
            this.label2.Visible = false;
            // 
            // tbProd
            // 
            this.tbProd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbProd.BackColor = System.Drawing.SystemColors.Window;
            this.tbProd.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbProd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbProd.Location = new System.Drawing.Point(1087, 19);
            this.tbProd.Name = "tbProd";
            this.tbProd.ReadOnly = true;
            this.tbProd.Size = new System.Drawing.Size(211, 29);
            this.tbProd.TabIndex = 3;
            this.tbProd.Visible = false;
            this.tbProd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyUp);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(1023, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "품목명";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(32, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "작업일자";
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpDate.CalendarFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpDate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpDate.Location = new System.Drawing.Point(112, 19);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(213, 29);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
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
            this.순번,
            this.jobNoDataGridViewTextBoxColumn,
            this.작업라인DataGridViewTextBoxColumn,
            this.품목코드DataGridViewTextBoxColumn,
            this.품목명DataGridViewTextBoxColumn,
            this.시작시간DataGridViewTextBoxColumn,
            this.종료시간DataGridViewTextBoxColumn,
            this.경과시간DataGridViewTextBoxColumn,
            this.지시수량DataGridViewTextBoxColumn,
            this.생산량,
            this.진행상황,
            this.Column1,
            this.수주번호,
            this.수주순번});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView1.DataSource = this.sPProdResultQuery1BindingSource;
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
            this.dataGridView1.Location = new System.Drawing.Point(3, 33);
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
            this.dataGridView1.Size = new System.Drawing.Size(1311, 782);
            this.dataGridView1.TabIndex = 57;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // sPProdResultQuery1BindingSource
            // 
            this.sPProdResultQuery1BindingSource.DataMember = "SP_ProdResult_Query1";
            this.sPProdResultQuery1BindingSource.DataSource = this.dataSetP1C;
            // 
            // dataSetP1C
            // 
            this.dataSetP1C.DataSetName = "DataSetP1C";
            this.dataSetP1C.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 168);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1317, 818);
            this.tableLayoutPanel1.TabIndex = 55;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.lblMsg);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1311, 24);
            this.panel2.TabIndex = 55;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(3, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 21);
            this.label9.TabIndex = 53;
            this.label9.Text = "실시간 생산(검사)";
            this.label9.Visible = false;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(173, 2);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(148, 21);
            this.lblMsg.TabIndex = 5;
            this.lblMsg.Text = "메시지 라벨입니다.";
            // 
            // sP_ProdResult_Query1TableAdapter
            // 
            this.sP_ProdResult_Query1TableAdapter.ClearBeforeFill = true;
            // 
            // 순번
            // 
            this.순번.DataPropertyName = "순번";
            this.순번.FillWeight = 40F;
            this.순번.HeaderText = "No.";
            this.순번.Name = "순번";
            this.순번.ReadOnly = true;
            this.순번.Visible = false;
            // 
            // jobNoDataGridViewTextBoxColumn
            // 
            this.jobNoDataGridViewTextBoxColumn.DataPropertyName = "JobNo";
            this.jobNoDataGridViewTextBoxColumn.HeaderText = "JobNo";
            this.jobNoDataGridViewTextBoxColumn.Name = "jobNoDataGridViewTextBoxColumn";
            this.jobNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 작업라인DataGridViewTextBoxColumn
            // 
            this.작업라인DataGridViewTextBoxColumn.DataPropertyName = "작업라인";
            this.작업라인DataGridViewTextBoxColumn.HeaderText = "작업라인";
            this.작업라인DataGridViewTextBoxColumn.Name = "작업라인DataGridViewTextBoxColumn";
            this.작업라인DataGridViewTextBoxColumn.ReadOnly = true;
            this.작업라인DataGridViewTextBoxColumn.Visible = false;
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
            // 시작시간DataGridViewTextBoxColumn
            // 
            this.시작시간DataGridViewTextBoxColumn.DataPropertyName = "시작시간";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd HH:mm:ss";
            this.시작시간DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.시작시간DataGridViewTextBoxColumn.HeaderText = "시작시간";
            this.시작시간DataGridViewTextBoxColumn.Name = "시작시간DataGridViewTextBoxColumn";
            this.시작시간DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 종료시간DataGridViewTextBoxColumn
            // 
            this.종료시간DataGridViewTextBoxColumn.DataPropertyName = "종료시간";
            dataGridViewCellStyle4.Format = "yyyy-MM-dd HH:mm:ss";
            this.종료시간DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.종료시간DataGridViewTextBoxColumn.HeaderText = "종료시간";
            this.종료시간DataGridViewTextBoxColumn.Name = "종료시간DataGridViewTextBoxColumn";
            this.종료시간DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 경과시간DataGridViewTextBoxColumn
            // 
            this.경과시간DataGridViewTextBoxColumn.DataPropertyName = "경과시간";
            this.경과시간DataGridViewTextBoxColumn.HeaderText = "경과시간";
            this.경과시간DataGridViewTextBoxColumn.Name = "경과시간DataGridViewTextBoxColumn";
            this.경과시간DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 지시수량DataGridViewTextBoxColumn
            // 
            this.지시수량DataGridViewTextBoxColumn.DataPropertyName = "지시수량";
            this.지시수량DataGridViewTextBoxColumn.FillWeight = 40F;
            this.지시수량DataGridViewTextBoxColumn.HeaderText = "지시수량";
            this.지시수량DataGridViewTextBoxColumn.Name = "지시수량DataGridViewTextBoxColumn";
            this.지시수량DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 생산량
            // 
            this.생산량.DataPropertyName = "생산량";
            this.생산량.FillWeight = 40F;
            this.생산량.HeaderText = "생산량";
            this.생산량.Name = "생산량";
            this.생산량.ReadOnly = true;
            // 
            // 진행상황
            // 
            this.진행상황.DataPropertyName = "진행상황";
            dataGridViewCellStyle5.NullValue = null;
            this.진행상황.DefaultCellStyle = dataGridViewCellStyle5;
            this.진행상황.FillWeight = 50F;
            this.진행상황.HeaderText = "진행상황";
            this.진행상황.Name = "진행상황";
            this.진행상황.ReadOnly = true;
            // 
            // Column1
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.NullValue = "보고";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column1.FillWeight = 25F;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // 수주번호
            // 
            this.수주번호.DataPropertyName = "수주번호";
            this.수주번호.HeaderText = "수주번호";
            this.수주번호.Name = "수주번호";
            this.수주번호.ReadOnly = true;
            this.수주번호.Visible = false;
            // 
            // 수주순번
            // 
            this.수주순번.DataPropertyName = "수주순번";
            this.수주순번.HeaderText = "수주순번";
            this.수주순번.Name = "수주순번";
            this.수주순번.ReadOnly = true;
            this.수주순번.Visible = false;
            // 
            // P1C02_PROD_RESULT1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.ClientSize = new System.Drawing.Size(1325, 990);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panSearch);
            this.Name = "P1C02_PROD_RESULT1";
            this.Text = "P1C02_PROD_RESULT1";
            this.Load += new System.EventHandler(this.P1C02_PROD_RESULT1_Load);
            this.Controls.SetChildIndex(this.panSearch, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.panSearch.ResumeLayout(false);
            this.panSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPProdResultQuery1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1C)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panSearch;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker dtpDate;
        public System.Windows.Forms.TextBox tbProd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn 제품명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 생산그룹IDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 생산그룹DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot번호DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 공정번호DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 공정명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn 작업조DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업지도DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 완료여부DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 지시일자DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수량DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 완료DataGridViewTextBoxColumn;
        public System.Windows.Forms.MaskedTextBox dtpDoneTime;
        public System.Windows.Forms.MaskedTextBox dtpStartTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbJobNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbWorkLine;
        public System.Windows.Forms.TextBox tbQty;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.DataGridView dataGridView1;
        private P1C.DataSetP1C dataSetP1C;
        private System.Windows.Forms.BindingSource sPProdResultQuery1BindingSource;
        private P1C.DataSetP1CTableAdapters.SP_ProdResult_Query1TableAdapter sP_ProdResult_Query1TableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn 순번;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업라인DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 품목코드DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 품목명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 시작시간DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 종료시간DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 경과시간DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 지시수량DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 생산량;
        private System.Windows.Forms.DataGridViewTextBoxColumn 진행상황;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주번호;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주순번;
    }
}
