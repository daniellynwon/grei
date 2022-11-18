﻿namespace SmartMES_Giroei
{
    partial class P1A03_COMMON
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P1A03_COMMON));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.번호DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.분류DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.코드분류DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.공통코드DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.항목명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.비고DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPCommonQueryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetP1A = new SmartMES_Giroei.P1A.DataSetP1A();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnA = new System.Windows.Forms.Button();
            this.btnU = new System.Windows.Forms.Button();
            this.btnP = new System.Windows.Forms.Button();
            this.btnG = new System.Windows.Forms.Button();
            this.btnD = new System.Windows.Forms.Button();
            this.btnZ = new System.Windows.Forms.Button();
            this.btnE = new System.Windows.Forms.Button();
            this.btnB = new System.Windows.Forms.Button();
            this.btnI = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.sP_Common_QueryTableAdapter = new SmartMES_Giroei.P1A.DataSetP1ATableAdapters.SP_Common_QueryTableAdapter();
            this.panSearch = new System.Windows.Forms.Panel();
            this.lblSubject = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPCommonQueryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1A)).BeginInit();
            this.panel1.SuspendLayout();
            this.panSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "공통코드정보";
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
            this.pbAdd.Image = global::SmartMES_Giroei.Properties.Resources.add_A;
            this.pbAdd.Click += new System.EventHandler(this.pbAdd_Click);
            // 
            // pbSearch
            // 
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
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
            this.번호DataGridViewTextBoxColumn,
            this.분류DataGridViewTextBoxColumn,
            this.코드분류DataGridViewTextBoxColumn,
            this.공통코드DataGridViewTextBoxColumn,
            this.항목명DataGridViewTextBoxColumn,
            this.비고DataGridViewTextBoxColumn});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView1.DataSource = this.sPCommonQueryBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(285, 131);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 35;
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1036, 852);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // 번호DataGridViewTextBoxColumn
            // 
            this.번호DataGridViewTextBoxColumn.DataPropertyName = "번호";
            this.번호DataGridViewTextBoxColumn.FillWeight = 30F;
            this.번호DataGridViewTextBoxColumn.HeaderText = "번호";
            this.번호DataGridViewTextBoxColumn.Name = "번호DataGridViewTextBoxColumn";
            this.번호DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 분류DataGridViewTextBoxColumn
            // 
            this.분류DataGridViewTextBoxColumn.DataPropertyName = "분류";
            this.분류DataGridViewTextBoxColumn.HeaderText = "분류";
            this.분류DataGridViewTextBoxColumn.Name = "분류DataGridViewTextBoxColumn";
            this.분류DataGridViewTextBoxColumn.ReadOnly = true;
            this.분류DataGridViewTextBoxColumn.Visible = false;
            // 
            // 코드분류DataGridViewTextBoxColumn
            // 
            this.코드분류DataGridViewTextBoxColumn.DataPropertyName = "코드분류";
            this.코드분류DataGridViewTextBoxColumn.FillWeight = 70F;
            this.코드분류DataGridViewTextBoxColumn.HeaderText = "코드분류";
            this.코드분류DataGridViewTextBoxColumn.Name = "코드분류DataGridViewTextBoxColumn";
            this.코드분류DataGridViewTextBoxColumn.ReadOnly = true;
            this.코드분류DataGridViewTextBoxColumn.Visible = false;
            // 
            // 공통코드DataGridViewTextBoxColumn
            // 
            this.공통코드DataGridViewTextBoxColumn.DataPropertyName = "공통코드";
            this.공통코드DataGridViewTextBoxColumn.FillWeight = 60F;
            this.공통코드DataGridViewTextBoxColumn.HeaderText = "공통코드";
            this.공통코드DataGridViewTextBoxColumn.Name = "공통코드DataGridViewTextBoxColumn";
            this.공통코드DataGridViewTextBoxColumn.ReadOnly = true;
            this.공통코드DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.공통코드DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 항목명DataGridViewTextBoxColumn
            // 
            this.항목명DataGridViewTextBoxColumn.DataPropertyName = "항목명";
            this.항목명DataGridViewTextBoxColumn.HeaderText = "항목명";
            this.항목명DataGridViewTextBoxColumn.Name = "항목명DataGridViewTextBoxColumn";
            this.항목명DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 비고DataGridViewTextBoxColumn
            // 
            this.비고DataGridViewTextBoxColumn.DataPropertyName = "비고";
            this.비고DataGridViewTextBoxColumn.HeaderText = "비고";
            this.비고DataGridViewTextBoxColumn.Name = "비고DataGridViewTextBoxColumn";
            this.비고DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sPCommonQueryBindingSource
            // 
            this.sPCommonQueryBindingSource.DataMember = "SP_Common_Query";
            this.sPCommonQueryBindingSource.DataSource = this.dataSetP1A;
            // 
            // dataSetP1A
            // 
            this.dataSetP1A.DataSetName = "DataSetP1A";
            this.dataSetP1A.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.panel1.Controls.Add(this.btnA);
            this.panel1.Controls.Add(this.btnU);
            this.panel1.Controls.Add(this.btnP);
            this.panel1.Controls.Add(this.btnG);
            this.panel1.Controls.Add(this.btnD);
            this.panel1.Controls.Add(this.btnZ);
            this.panel1.Controls.Add(this.btnE);
            this.panel1.Controls.Add(this.btnB);
            this.panel1.Controls.Add(this.btnI);
            this.panel1.Controls.Add(this.btnC);
            this.panel1.Location = new System.Drawing.Point(2, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 925);
            this.panel1.TabIndex = 0;
            // 
            // btnA
            // 
            this.btnA.Location = new System.Drawing.Point(26, 279);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(229, 36);
            this.btnA.TabIndex = 14;
            this.btnA.Tag = "A";
            this.btnA.Text = "공정정보";
            this.btnA.UseVisualStyleBackColor = true;
            this.btnA.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnU
            // 
            this.btnU.Location = new System.Drawing.Point(26, 786);
            this.btnU.Name = "btnU";
            this.btnU.Size = new System.Drawing.Size(229, 36);
            this.btnU.TabIndex = 13;
            this.btnU.Tag = "U";
            this.btnU.Text = "포장단위";
            this.btnU.UseVisualStyleBackColor = true;
            this.btnU.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnP
            // 
            this.btnP.Location = new System.Drawing.Point(26, 116);
            this.btnP.Name = "btnP";
            this.btnP.Size = new System.Drawing.Size(229, 36);
            this.btnP.TabIndex = 12;
            this.btnP.Tag = "P";
            this.btnP.Text = "품목분류(제품)";
            this.btnP.UseVisualStyleBackColor = true;
            this.btnP.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnG
            // 
            this.btnG.Location = new System.Drawing.Point(26, 699);
            this.btnG.Name = "btnG";
            this.btnG.Size = new System.Drawing.Size(229, 36);
            this.btnG.TabIndex = 11;
            this.btnG.Tag = "G";
            this.btnG.Text = "부서코드";
            this.btnG.UseVisualStyleBackColor = true;
            this.btnG.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnD
            // 
            this.btnD.Location = new System.Drawing.Point(26, 615);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(229, 36);
            this.btnD.TabIndex = 10;
            this.btnD.Tag = "D";
            this.btnD.Text = "라인정보";
            this.btnD.UseVisualStyleBackColor = true;
            this.btnD.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnZ
            // 
            this.btnZ.Location = new System.Drawing.Point(26, 527);
            this.btnZ.Name = "btnZ";
            this.btnZ.Size = new System.Drawing.Size(229, 36);
            this.btnZ.TabIndex = 9;
            this.btnZ.Tag = "Z";
            this.btnZ.Text = "설비그룹";
            this.btnZ.UseVisualStyleBackColor = true;
            this.btnZ.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnE
            // 
            this.btnE.Location = new System.Drawing.Point(26, 355);
            this.btnE.Name = "btnE";
            this.btnE.Size = new System.Drawing.Size(229, 36);
            this.btnE.TabIndex = 5;
            this.btnE.Tag = "E";
            this.btnE.Text = "재고변동";
            this.btnE.UseVisualStyleBackColor = true;
            this.btnE.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnB
            // 
            this.btnB.Location = new System.Drawing.Point(26, 35);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(229, 36);
            this.btnB.TabIndex = 2;
            this.btnB.Tag = "B";
            this.btnB.Text = "창  고";
            this.btnB.UseVisualStyleBackColor = true;
            this.btnB.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnI
            // 
            this.btnI.Location = new System.Drawing.Point(26, 441);
            this.btnI.Name = "btnI";
            this.btnI.Size = new System.Drawing.Size(229, 36);
            this.btnI.TabIndex = 7;
            this.btnI.Tag = "I";
            this.btnI.Text = "검사항목";
            this.btnI.UseVisualStyleBackColor = true;
            this.btnI.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnC
            // 
            this.btnC.Location = new System.Drawing.Point(26, 202);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(229, 36);
            this.btnC.TabIndex = 3;
            this.btnC.Tag = "C";
            this.btnC.Text = "품목분류(자재)";
            this.btnC.UseVisualStyleBackColor = true;
            this.btnC.Click += new System.EventHandler(this.btn_Click);
            // 
            // sP_Common_QueryTableAdapter
            // 
            this.sP_Common_QueryTableAdapter.ClearBeforeFill = true;
            // 
            // panSearch
            // 
            this.panSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panSearch.AutoSize = true;
            this.panSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.panSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSearch.Controls.Add(this.lblSubject);
            this.panSearch.Location = new System.Drawing.Point(285, 58);
            this.panSearch.Name = "panSearch";
            this.panSearch.Size = new System.Drawing.Size(1036, 71);
            this.panSearch.TabIndex = 8;
            // 
            // lblSubject
            // 
            this.lblSubject.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSubject.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.lblSubject.ForeColor = System.Drawing.Color.Blue;
            this.lblSubject.Location = new System.Drawing.Point(329, 23);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(370, 27);
            this.lblSubject.TabIndex = 0;
            this.lblSubject.Text = "공통코드 분류명";
            this.lblSubject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // P1A03_COMMON
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.ClientSize = new System.Drawing.Size(1325, 990);
            this.Controls.Add(this.panSearch);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "P1A03_COMMON";
            this.Tag = "";
            this.Text = "P1A03_COMMON";
            this.Load += new System.EventHandler(this.P1A03_COMMON_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panSearch, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPCommonQueryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1A)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panSearch.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnI;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.BindingSource sPCommonQueryBindingSource;
        private P1A.DataSetP1A dataSetP1A;
        private P1A.DataSetP1ATableAdapters.SP_Common_QueryTableAdapter sP_Common_QueryTableAdapter;
        private System.Windows.Forms.Panel panSearch;
        public System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.Button btnE;
        private System.Windows.Forms.Button btnZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 번호DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 분류DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 코드분류DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn 공통코드DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 항목명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 비고DataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnD;
        private System.Windows.Forms.Button btnG;
        private System.Windows.Forms.Button btnP;
        private System.Windows.Forms.Button btnU;
        private System.Windows.Forms.Button btnA;
    }
}
