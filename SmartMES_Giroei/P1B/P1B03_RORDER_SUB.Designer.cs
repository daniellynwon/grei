namespace SmartMES_Giroei
{
    partial class P1B03_RORDER_SUB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sPROrderEstBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetP1B = new SmartMES_Giroei.P1B.DataSetP1B();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeli = new System.Windows.Forms.Button();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sP_ROrder_EstTableAdapter = new SmartMES_Giroei.P1B.DataSetP1BTableAdapters.SP_ROrder_EstTableAdapter();
            this.견적번호DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.견적일자DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.거래처ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.거래처 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.프로젝트명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.담당자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.연락처DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.창고 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.품목코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.품목분류 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.품목명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수량 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.기준단가 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.제안단가 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.견적금액 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.부가세 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.비고 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수주여부 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.견적순번 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.공정코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.적용점수 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.층수 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.포장단위 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPROrderEstBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1B)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
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
            this.견적번호DataGridViewTextBoxColumn,
            this.견적일자DataGridViewTextBoxColumn,
            this.거래처ID,
            this.거래처,
            this.프로젝트명DataGridViewTextBoxColumn,
            this.담당자,
            this.연락처DataGridViewTextBoxColumn,
            this.창고,
            this.Column1,
            this.품목코드,
            this.품목분류,
            this.품목명,
            this.수량,
            this.기준단가,
            this.제안단가,
            this.견적금액,
            this.부가세,
            this.비고,
            this.수주여부,
            this.견적순번,
            this.공정코드,
            this.적용점수,
            this.층수,
            this.포장단위});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView1.DataSource = this.sPROrderEstBindingSource;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(5, 79);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 35;
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1024, 637);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // sPROrderEstBindingSource
            // 
            this.sPROrderEstBindingSource.DataMember = "SP_ROrder_Est";
            this.sPROrderEstBindingSource.DataSource = this.dataSetP1B;
            // 
            // dataSetP1B
            // 
            this.dataSetP1B.DataSetName = "DataSetP1B";
            this.dataSetP1B.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDeli);
            this.panel1.Controls.Add(this.pbSearch);
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 68);
            this.panel1.TabIndex = 0;
            // 
            // btnDeli
            // 
            this.btnDeli.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDeli.Location = new System.Drawing.Point(797, 16);
            this.btnDeli.Name = "btnDeli";
            this.btnDeli.Size = new System.Drawing.Size(197, 29);
            this.btnDeli.TabIndex = 5;
            this.btnDeli.Text = "수주처리";
            this.btnDeli.UseVisualStyleBackColor = true;
            this.btnDeli.Click += new System.EventHandler(this.btnDeli_Click);
            // 
            // pbSearch
            // 
            this.pbSearch.BackColor = System.Drawing.Color.Transparent;
            this.pbSearch.Image = global::SmartMES_Giroei.Properties.Resources.search;
            this.pbSearch.Location = new System.Drawing.Point(686, 18);
            this.pbSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(32, 26);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSearch.TabIndex = 4;
            this.pbSearch.TabStop = false;
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            this.pbSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbSearch_MouseDown);
            this.pbSearch.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbSearch_MouseUp);
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbSearch.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbSearch.Location = new System.Drawing.Point(405, 17);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(319, 29);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(204, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "거래처/프로젝트명/소재지";
            // 
            // sP_ROrder_EstTableAdapter
            // 
            this.sP_ROrder_EstTableAdapter.ClearBeforeFill = true;
            // 
            // 견적번호DataGridViewTextBoxColumn
            // 
            this.견적번호DataGridViewTextBoxColumn.DataPropertyName = "견적번호";
            this.견적번호DataGridViewTextBoxColumn.HeaderText = "견적번호";
            this.견적번호DataGridViewTextBoxColumn.Name = "견적번호DataGridViewTextBoxColumn";
            this.견적번호DataGridViewTextBoxColumn.ReadOnly = true;
            this.견적번호DataGridViewTextBoxColumn.Visible = false;
            // 
            // 견적일자DataGridViewTextBoxColumn
            // 
            this.견적일자DataGridViewTextBoxColumn.DataPropertyName = "견적일자";
            dataGridViewCellStyle3.Format = "M\\/d";
            this.견적일자DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.견적일자DataGridViewTextBoxColumn.FillWeight = 50F;
            this.견적일자DataGridViewTextBoxColumn.HeaderText = "일자";
            this.견적일자DataGridViewTextBoxColumn.Name = "견적일자DataGridViewTextBoxColumn";
            this.견적일자DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 거래처ID
            // 
            this.거래처ID.DataPropertyName = "거래처ID";
            this.거래처ID.HeaderText = "거래처ID";
            this.거래처ID.Name = "거래처ID";
            this.거래처ID.ReadOnly = true;
            this.거래처ID.Visible = false;
            // 
            // 거래처
            // 
            this.거래처.DataPropertyName = "거래처";
            this.거래처.HeaderText = "거래처";
            this.거래처.Name = "거래처";
            this.거래처.ReadOnly = true;
            this.거래처.Visible = false;
            // 
            // 프로젝트명DataGridViewTextBoxColumn
            // 
            this.프로젝트명DataGridViewTextBoxColumn.DataPropertyName = "프로젝트명";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.프로젝트명DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.프로젝트명DataGridViewTextBoxColumn.FillWeight = 170F;
            this.프로젝트명DataGridViewTextBoxColumn.HeaderText = "프로젝트명";
            this.프로젝트명DataGridViewTextBoxColumn.Name = "프로젝트명DataGridViewTextBoxColumn";
            this.프로젝트명DataGridViewTextBoxColumn.ReadOnly = true;
            this.프로젝트명DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.프로젝트명DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 담당자
            // 
            this.담당자.DataPropertyName = "담당자";
            this.담당자.HeaderText = "담당자";
            this.담당자.Name = "담당자";
            this.담당자.ReadOnly = true;
            this.담당자.Visible = false;
            // 
            // 연락처DataGridViewTextBoxColumn
            // 
            this.연락처DataGridViewTextBoxColumn.DataPropertyName = "연락처";
            this.연락처DataGridViewTextBoxColumn.HeaderText = "연락처";
            this.연락처DataGridViewTextBoxColumn.Name = "연락처DataGridViewTextBoxColumn";
            this.연락처DataGridViewTextBoxColumn.ReadOnly = true;
            this.연락처DataGridViewTextBoxColumn.Visible = false;
            // 
            // 창고
            // 
            this.창고.DataPropertyName = "창고";
            this.창고.HeaderText = "창고";
            this.창고.Name = "창고";
            this.창고.ReadOnly = true;
            this.창고.Visible = false;
            // 
            // Column1
            // 
            this.Column1.FalseValue = "0";
            this.Column1.FillWeight = 30F;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.TrueValue = "1";
            // 
            // 품목코드
            // 
            this.품목코드.DataPropertyName = "품목코드";
            this.품목코드.HeaderText = "품목코드";
            this.품목코드.Name = "품목코드";
            this.품목코드.ReadOnly = true;
            // 
            // 품목분류
            // 
            this.품목분류.DataPropertyName = "품목분류";
            this.품목분류.HeaderText = "품목분류";
            this.품목분류.Name = "품목분류";
            this.품목분류.ReadOnly = true;
            this.품목분류.Visible = false;
            // 
            // 품목명
            // 
            this.품목명.DataPropertyName = "품목명";
            this.품목명.HeaderText = "품목명";
            this.품목명.Name = "품목명";
            this.품목명.ReadOnly = true;
            // 
            // 수량
            // 
            this.수량.DataPropertyName = "수량";
            this.수량.HeaderText = "수량";
            this.수량.Name = "수량";
            this.수량.ReadOnly = true;
            this.수량.Visible = false;
            // 
            // 기준단가
            // 
            this.기준단가.DataPropertyName = "기준단가";
            this.기준단가.HeaderText = "기준단가";
            this.기준단가.Name = "기준단가";
            this.기준단가.ReadOnly = true;
            this.기준단가.Visible = false;
            // 
            // 제안단가
            // 
            this.제안단가.DataPropertyName = "제안단가";
            this.제안단가.HeaderText = "제안단가";
            this.제안단가.Name = "제안단가";
            this.제안단가.ReadOnly = true;
            this.제안단가.Visible = false;
            // 
            // 견적금액
            // 
            this.견적금액.DataPropertyName = "견적금액";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#,##0";
            this.견적금액.DefaultCellStyle = dataGridViewCellStyle5;
            this.견적금액.HeaderText = "견적금액";
            this.견적금액.Name = "견적금액";
            this.견적금액.ReadOnly = true;
            // 
            // 부가세
            // 
            this.부가세.DataPropertyName = "부가세";
            this.부가세.HeaderText = "부가세";
            this.부가세.Name = "부가세";
            this.부가세.ReadOnly = true;
            this.부가세.Visible = false;
            // 
            // 비고
            // 
            this.비고.DataPropertyName = "비고";
            this.비고.HeaderText = "비고";
            this.비고.Name = "비고";
            this.비고.ReadOnly = true;
            // 
            // 수주여부
            // 
            this.수주여부.DataPropertyName = "수주여부";
            this.수주여부.HeaderText = "수주여부";
            this.수주여부.Name = "수주여부";
            this.수주여부.ReadOnly = true;
            this.수주여부.Visible = false;
            // 
            // 견적순번
            // 
            this.견적순번.DataPropertyName = "견적순번";
            this.견적순번.HeaderText = "견적순번";
            this.견적순번.Name = "견적순번";
            this.견적순번.ReadOnly = true;
            this.견적순번.Visible = false;
            // 
            // 공정코드
            // 
            this.공정코드.DataPropertyName = "공정코드";
            this.공정코드.HeaderText = "공정코드";
            this.공정코드.Name = "공정코드";
            this.공정코드.ReadOnly = true;
            this.공정코드.Visible = false;
            // 
            // 적용점수
            // 
            this.적용점수.DataPropertyName = "적용점수";
            this.적용점수.HeaderText = "적용점수";
            this.적용점수.Name = "적용점수";
            this.적용점수.ReadOnly = true;
            this.적용점수.Visible = false;
            // 
            // 층수
            // 
            this.층수.DataPropertyName = "층수";
            this.층수.HeaderText = "층수";
            this.층수.Name = "층수";
            this.층수.ReadOnly = true;
            this.층수.Visible = false;
            // 
            // 포장단위
            // 
            this.포장단위.DataPropertyName = "포장단위";
            this.포장단위.HeaderText = "포장단위";
            this.포장단위.Name = "포장단위";
            this.포장단위.ReadOnly = true;
            this.포장단위.Visible = false;
            // 
            // P1B03_RORDER_SUB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1033, 720);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "P1B03_RORDER_SUB";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "견적불러오기";
            this.Load += new System.EventHandler(this.P1B03_RORDER_SUB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPROrderEstBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1B)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 전화DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 팩스DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 가공비DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 재료비DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수량DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 합계금액DataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource sPROrderEstBindingSource;
        private P1B.DataSetP1B dataSetP1B;
        private P1B.DataSetP1BTableAdapters.SP_ROrder_EstTableAdapter sP_ROrder_EstTableAdapter;
        private System.Windows.Forms.Button btnDeli;
        private System.Windows.Forms.DataGridViewTextBoxColumn 견적번호DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 견적일자DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 거래처ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 거래처;
        private System.Windows.Forms.DataGridViewLinkColumn 프로젝트명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 담당자;
        private System.Windows.Forms.DataGridViewTextBoxColumn 연락처DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 창고;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 품목코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn 품목분류;
        private System.Windows.Forms.DataGridViewTextBoxColumn 품목명;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수량;
        private System.Windows.Forms.DataGridViewTextBoxColumn 기준단가;
        private System.Windows.Forms.DataGridViewTextBoxColumn 제안단가;
        private System.Windows.Forms.DataGridViewTextBoxColumn 견적금액;
        private System.Windows.Forms.DataGridViewTextBoxColumn 부가세;
        private System.Windows.Forms.DataGridViewTextBoxColumn 비고;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주여부;
        private System.Windows.Forms.DataGridViewTextBoxColumn 견적순번;
        private System.Windows.Forms.DataGridViewTextBoxColumn 공정코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn 적용점수;
        private System.Windows.Forms.DataGridViewTextBoxColumn 층수;
        private System.Windows.Forms.DataGridViewTextBoxColumn 포장단위;
    }
}