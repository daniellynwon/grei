namespace SmartMES_Giroei
{
    partial class P1C02_PROD_RESULT_ORDER
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lotNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.일자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.작업라인 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.품목코드DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.품목명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수량DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.분류 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.공정번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.공정코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.공정명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.거래처코드DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.거래처명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.프로젝트명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.납기DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.솔더 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MM번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.작업시작 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.작업종료 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.작업자공수 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.현품표 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.작업지도DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.생산책임자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPProdResultOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetP1C = new SmartMES_Giroei.P1C.DataSetP1C();
            this.sP_ProdResult_OrderTableAdapter = new SmartMES_Giroei.P1C.DataSetP1CTableAdapters.SP_ProdResult_OrderTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPProdResultOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1C)).BeginInit();
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
            this.lotNoDataGridViewTextBoxColumn,
            this.일자,
            this.작업라인,
            this.품목코드DataGridViewTextBoxColumn,
            this.품목명DataGridViewTextBoxColumn,
            this.수량DataGridViewTextBoxColumn,
            this.분류,
            this.공정번호,
            this.공정코드,
            this.공정명,
            this.거래처코드DataGridViewTextBoxColumn,
            this.거래처명DataGridViewTextBoxColumn,
            this.프로젝트명DataGridViewTextBoxColumn,
            this.납기DataGridViewTextBoxColumn,
            this.솔더,
            this.MM번호,
            this.작업시작,
            this.작업종료,
            this.작업자공수,
            this.현품표,
            this.작업지도DataGridViewTextBoxColumn,
            this.생산책임자});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView1.DataSource = this.sPProdResultOrderBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(5, 5);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 35;
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1140, 544);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // lotNoDataGridViewTextBoxColumn
            // 
            this.lotNoDataGridViewTextBoxColumn.DataPropertyName = "LotNo";
            this.lotNoDataGridViewTextBoxColumn.FillWeight = 90F;
            this.lotNoDataGridViewTextBoxColumn.HeaderText = "LotNo";
            this.lotNoDataGridViewTextBoxColumn.Name = "lotNoDataGridViewTextBoxColumn";
            this.lotNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNoDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lotNoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 일자
            // 
            this.일자.DataPropertyName = "생산지시일";
            this.일자.HeaderText = "일자";
            this.일자.Name = "일자";
            this.일자.ReadOnly = true;
            this.일자.Visible = false;
            // 
            // 작업라인
            // 
            this.작업라인.DataPropertyName = "작업라인";
            this.작업라인.FillWeight = 50F;
            this.작업라인.HeaderText = "작업라인";
            this.작업라인.Name = "작업라인";
            this.작업라인.ReadOnly = true;
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
            this.품목명DataGridViewTextBoxColumn.FillWeight = 80F;
            this.품목명DataGridViewTextBoxColumn.HeaderText = "품목명";
            this.품목명DataGridViewTextBoxColumn.Name = "품목명DataGridViewTextBoxColumn";
            this.품목명DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 수량DataGridViewTextBoxColumn
            // 
            this.수량DataGridViewTextBoxColumn.DataPropertyName = "수량";
            this.수량DataGridViewTextBoxColumn.FillWeight = 60F;
            this.수량DataGridViewTextBoxColumn.HeaderText = "수량";
            this.수량DataGridViewTextBoxColumn.Name = "수량DataGridViewTextBoxColumn";
            this.수량DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 분류
            // 
            this.분류.DataPropertyName = "분류";
            this.분류.FillWeight = 50F;
            this.분류.HeaderText = "분류";
            this.분류.Name = "분류";
            this.분류.ReadOnly = true;
            // 
            // 공정번호
            // 
            this.공정번호.DataPropertyName = "공정번호";
            this.공정번호.HeaderText = "공정번호";
            this.공정번호.Name = "공정번호";
            this.공정번호.ReadOnly = true;
            this.공정번호.Visible = false;
            // 
            // 공정코드
            // 
            this.공정코드.DataPropertyName = "공정코드";
            this.공정코드.HeaderText = "공정코드";
            this.공정코드.Name = "공정코드";
            this.공정코드.ReadOnly = true;
            this.공정코드.Visible = false;
            // 
            // 공정명
            // 
            this.공정명.DataPropertyName = "공정명";
            this.공정명.FillWeight = 50F;
            this.공정명.HeaderText = "공정명";
            this.공정명.Name = "공정명";
            this.공정명.ReadOnly = true;
            // 
            // 거래처코드DataGridViewTextBoxColumn
            // 
            this.거래처코드DataGridViewTextBoxColumn.DataPropertyName = "거래처코드";
            this.거래처코드DataGridViewTextBoxColumn.HeaderText = "거래처코드";
            this.거래처코드DataGridViewTextBoxColumn.Name = "거래처코드DataGridViewTextBoxColumn";
            this.거래처코드DataGridViewTextBoxColumn.ReadOnly = true;
            this.거래처코드DataGridViewTextBoxColumn.Visible = false;
            // 
            // 거래처명DataGridViewTextBoxColumn
            // 
            this.거래처명DataGridViewTextBoxColumn.DataPropertyName = "거래처명";
            this.거래처명DataGridViewTextBoxColumn.HeaderText = "거래처명";
            this.거래처명DataGridViewTextBoxColumn.Name = "거래처명DataGridViewTextBoxColumn";
            this.거래처명DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 프로젝트명DataGridViewTextBoxColumn
            // 
            this.프로젝트명DataGridViewTextBoxColumn.DataPropertyName = "프로젝트명";
            this.프로젝트명DataGridViewTextBoxColumn.HeaderText = "프로젝트명";
            this.프로젝트명DataGridViewTextBoxColumn.Name = "프로젝트명DataGridViewTextBoxColumn";
            this.프로젝트명DataGridViewTextBoxColumn.ReadOnly = true;
            this.프로젝트명DataGridViewTextBoxColumn.Visible = false;
            // 
            // 납기DataGridViewTextBoxColumn
            // 
            this.납기DataGridViewTextBoxColumn.DataPropertyName = "납기";
            dataGridViewCellStyle3.Format = "MM\\/dd";
            this.납기DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.납기DataGridViewTextBoxColumn.FillWeight = 40F;
            this.납기DataGridViewTextBoxColumn.HeaderText = "납기";
            this.납기DataGridViewTextBoxColumn.Name = "납기DataGridViewTextBoxColumn";
            this.납기DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 솔더
            // 
            this.솔더.DataPropertyName = "솔더";
            this.솔더.HeaderText = "솔더";
            this.솔더.Name = "솔더";
            this.솔더.ReadOnly = true;
            this.솔더.Visible = false;
            // 
            // MM번호
            // 
            this.MM번호.DataPropertyName = "MM번호";
            this.MM번호.HeaderText = "MM번호";
            this.MM번호.Name = "MM번호";
            this.MM번호.ReadOnly = true;
            this.MM번호.Visible = false;
            // 
            // 작업시작
            // 
            this.작업시작.DataPropertyName = "작업시작";
            this.작업시작.FillWeight = 70F;
            this.작업시작.HeaderText = "작업시작";
            this.작업시작.Name = "작업시작";
            this.작업시작.ReadOnly = true;
            // 
            // 작업종료
            // 
            this.작업종료.DataPropertyName = "작업종료";
            this.작업종료.FillWeight = 70F;
            this.작업종료.HeaderText = "작업종료";
            this.작업종료.Name = "작업종료";
            this.작업종료.ReadOnly = true;
            // 
            // 작업자공수
            // 
            this.작업자공수.DataPropertyName = "작업자공수";
            this.작업자공수.FillWeight = 40F;
            this.작업자공수.HeaderText = "작업자공수";
            this.작업자공수.Name = "작업자공수";
            this.작업자공수.ReadOnly = true;
            this.작업자공수.Visible = false;
            // 
            // 현품표
            // 
            this.현품표.DataPropertyName = "현품표";
            this.현품표.HeaderText = "현품표";
            this.현품표.Name = "현품표";
            this.현품표.ReadOnly = true;
            this.현품표.Visible = false;
            // 
            // 작업지도DataGridViewTextBoxColumn
            // 
            this.작업지도DataGridViewTextBoxColumn.DataPropertyName = "작업지도";
            this.작업지도DataGridViewTextBoxColumn.FillWeight = 150F;
            this.작업지도DataGridViewTextBoxColumn.HeaderText = "작업지도";
            this.작업지도DataGridViewTextBoxColumn.Name = "작업지도DataGridViewTextBoxColumn";
            this.작업지도DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 생산책임자
            // 
            this.생산책임자.DataPropertyName = "생산책임자";
            this.생산책임자.FillWeight = 40F;
            this.생산책임자.HeaderText = "생산책임자";
            this.생산책임자.Name = "생산책임자";
            this.생산책임자.ReadOnly = true;
            // 
            // sPProdResultOrderBindingSource
            // 
            this.sPProdResultOrderBindingSource.DataMember = "SP_ProdResult_Order";
            this.sPProdResultOrderBindingSource.DataSource = this.dataSetP1C;
            // 
            // dataSetP1C
            // 
            this.dataSetP1C.DataSetName = "DataSetP1C";
            this.dataSetP1C.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sP_ProdResult_OrderTableAdapter
            // 
            this.sP_ProdResult_OrderTableAdapter.ClearBeforeFill = true;
            // 
            // P1C02_PROD_RESULT_ORDER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1148, 555);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "P1C02_PROD_RESULT_ORDER";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "작업지시서";
            this.Load += new System.EventHandler(this.P1C02_PROD_RESULT_ORDER_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPProdResultOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1C)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dataGridView1;
        private P1C.DataSetP1CTableAdapters.SP_ProdOrder_QueryTableAdapter sP_ProdOrder_QueryTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn 공정번호DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 공정명DataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource sPProdResultOrderBindingSource;
        private P1C.DataSetP1C dataSetP1C;
        private P1C.DataSetP1CTableAdapters.SP_ProdResult_OrderTableAdapter sP_ProdResult_OrderTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn 제품명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 규격DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn lotNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 일자;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업라인;
        private System.Windows.Forms.DataGridViewTextBoxColumn 품목코드DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 품목명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수량DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 분류;
        private System.Windows.Forms.DataGridViewTextBoxColumn 공정번호;
        private System.Windows.Forms.DataGridViewTextBoxColumn 공정코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn 공정명;
        private System.Windows.Forms.DataGridViewTextBoxColumn 거래처코드DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 거래처명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 프로젝트명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 납기DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 솔더;
        private System.Windows.Forms.DataGridViewTextBoxColumn MM번호;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업시작;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업종료;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업자공수;
        private System.Windows.Forms.DataGridViewTextBoxColumn 현품표;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작업지도DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 생산책임자;
    }
}