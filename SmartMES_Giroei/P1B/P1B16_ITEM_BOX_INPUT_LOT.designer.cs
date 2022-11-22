namespace SmartMES_Giroei
{
    partial class P1B16_ITEM_BOX_INPUT_LOT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblProdNm = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblProd = new System.Windows.Forms.Label();
            this.sPBarcodeQueryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetP1B = new SmartMES_Giroei.P1B.DataSetP1B();
            this.sP_Barcode_QueryTableAdapter = new SmartMES_Giroei.P1B.DataSetP1BTableAdapters.SP_Barcode_QueryTableAdapter();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.바코드DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.바코드SDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.이전바코드DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.공급업체DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.자재코드DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.입고일DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.입고수량DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.잔량DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.등록자DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.갱신자DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sPBarcodeQueryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1B)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
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
            this.Column1,
            this.바코드DataGridViewTextBoxColumn,
            this.바코드SDataGridViewTextBoxColumn,
            this.이전바코드DataGridViewTextBoxColumn,
            this.공급업체DataGridViewTextBoxColumn,
            this.자재코드DataGridViewTextBoxColumn,
            this.입고일DataGridViewTextBoxColumn,
            this.입고수량DataGridViewTextBoxColumn,
            this.잔량DataGridViewTextBoxColumn,
            this.등록자DataGridViewTextBoxColumn,
            this.갱신자DataGridViewTextBoxColumn});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView1.DataSource = this.sPBarcodeQueryBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(5, 84);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
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
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(763, 520);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblBarcode);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.lblDate);
            this.panel2.Controls.Add(this.lblProdNm);
            this.panel2.Controls.Add(this.lblMsg);
            this.panel2.Controls.Add(this.lblProd);
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(763, 73);
            this.panel2.TabIndex = 0;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBarcode.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblBarcode.Location = new System.Drawing.Point(191, 29);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(81, 21);
            this.lblBarcode.TabIndex = 16;
            this.lblBarcode.Text = "BARCODE";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Location = new System.Drawing.Point(595, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 29);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "선  택";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDate.Location = new System.Drawing.Point(7, 29);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(73, 21);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "LOTNO: ";
            // 
            // lblProdNm
            // 
            this.lblProdNm.AutoSize = true;
            this.lblProdNm.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProdNm.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblProdNm.Location = new System.Drawing.Point(191, 5);
            this.lblProdNm.Name = "lblProdNm";
            this.lblProdNm.Size = new System.Drawing.Size(68, 21);
            this.lblProdNm.TabIndex = 3;
            this.lblProdNm.Text = "자재명: ";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(7, 50);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(148, 21);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "메시지 라벨입니다.";
            // 
            // lblProd
            // 
            this.lblProd.AutoSize = true;
            this.lblProd.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProd.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblProd.Location = new System.Drawing.Point(7, 5);
            this.lblProd.Name = "lblProd";
            this.lblProd.Size = new System.Drawing.Size(84, 21);
            this.lblProd.TabIndex = 0;
            this.lblProd.Text = "자재코드: ";
            // 
            // sPBarcodeQueryBindingSource
            // 
            this.sPBarcodeQueryBindingSource.DataMember = "SP_Barcode_Query";
            this.sPBarcodeQueryBindingSource.DataSource = this.dataSetP1B;
            // 
            // dataSetP1B
            // 
            this.dataSetP1B.DataSetName = "DataSetP1B";
            this.dataSetP1B.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sP_Barcode_QueryTableAdapter
            // 
            this.sP_Barcode_QueryTableAdapter.ClearBeforeFill = true;
            // 
            // Column1
            // 
            this.Column1.FalseValue = "0";
            this.Column1.FillWeight = 30F;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.TrueValue = "1";
            // 
            // 바코드DataGridViewTextBoxColumn
            // 
            this.바코드DataGridViewTextBoxColumn.DataPropertyName = "바코드";
            this.바코드DataGridViewTextBoxColumn.HeaderText = "바코드";
            this.바코드DataGridViewTextBoxColumn.Name = "바코드DataGridViewTextBoxColumn";
            this.바코드DataGridViewTextBoxColumn.Visible = false;
            // 
            // 바코드SDataGridViewTextBoxColumn
            // 
            this.바코드SDataGridViewTextBoxColumn.DataPropertyName = "바코드S";
            this.바코드SDataGridViewTextBoxColumn.HeaderText = "Surfix";
            this.바코드SDataGridViewTextBoxColumn.Name = "바코드SDataGridViewTextBoxColumn";
            // 
            // 이전바코드DataGridViewTextBoxColumn
            // 
            this.이전바코드DataGridViewTextBoxColumn.DataPropertyName = "이전바코드";
            this.이전바코드DataGridViewTextBoxColumn.HeaderText = "이전바코드";
            this.이전바코드DataGridViewTextBoxColumn.Name = "이전바코드DataGridViewTextBoxColumn";
            this.이전바코드DataGridViewTextBoxColumn.Visible = false;
            // 
            // 공급업체DataGridViewTextBoxColumn
            // 
            this.공급업체DataGridViewTextBoxColumn.DataPropertyName = "공급업체";
            this.공급업체DataGridViewTextBoxColumn.HeaderText = "공급업체";
            this.공급업체DataGridViewTextBoxColumn.Name = "공급업체DataGridViewTextBoxColumn";
            // 
            // 자재코드DataGridViewTextBoxColumn
            // 
            this.자재코드DataGridViewTextBoxColumn.DataPropertyName = "자재코드";
            this.자재코드DataGridViewTextBoxColumn.HeaderText = "자재코드";
            this.자재코드DataGridViewTextBoxColumn.Name = "자재코드DataGridViewTextBoxColumn";
            // 
            // 입고일DataGridViewTextBoxColumn
            // 
            this.입고일DataGridViewTextBoxColumn.DataPropertyName = "입고일";
            this.입고일DataGridViewTextBoxColumn.HeaderText = "입고일";
            this.입고일DataGridViewTextBoxColumn.Name = "입고일DataGridViewTextBoxColumn";
            // 
            // 입고수량DataGridViewTextBoxColumn
            // 
            this.입고수량DataGridViewTextBoxColumn.DataPropertyName = "입고수량";
            this.입고수량DataGridViewTextBoxColumn.FillWeight = 50F;
            this.입고수량DataGridViewTextBoxColumn.HeaderText = "입고수량";
            this.입고수량DataGridViewTextBoxColumn.Name = "입고수량DataGridViewTextBoxColumn";
            // 
            // 잔량DataGridViewTextBoxColumn
            // 
            this.잔량DataGridViewTextBoxColumn.DataPropertyName = "잔량";
            this.잔량DataGridViewTextBoxColumn.FillWeight = 50F;
            this.잔량DataGridViewTextBoxColumn.HeaderText = "잔량";
            this.잔량DataGridViewTextBoxColumn.Name = "잔량DataGridViewTextBoxColumn";
            // 
            // 등록자DataGridViewTextBoxColumn
            // 
            this.등록자DataGridViewTextBoxColumn.DataPropertyName = "등록자";
            this.등록자DataGridViewTextBoxColumn.HeaderText = "등록자";
            this.등록자DataGridViewTextBoxColumn.Name = "등록자DataGridViewTextBoxColumn";
            this.등록자DataGridViewTextBoxColumn.Visible = false;
            // 
            // 갱신자DataGridViewTextBoxColumn
            // 
            this.갱신자DataGridViewTextBoxColumn.DataPropertyName = "갱신자";
            this.갱신자DataGridViewTextBoxColumn.HeaderText = "갱신자";
            this.갱신자DataGridViewTextBoxColumn.Name = "갱신자DataGridViewTextBoxColumn";
            this.갱신자DataGridViewTextBoxColumn.Visible = false;
            // 
            // P1B16_ITEM_BOX_INPUT_LOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(771, 609);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "P1B16_ITEM_BOX_INPUT_LOT";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LOT 선택";
            this.Load += new System.EventHandler(this.P1B16_ITEM_BOX_INPUT_LOT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sPBarcodeQueryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1B)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 제품명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 규격DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 가공비DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 재료비DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 외주DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 단가DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주여부DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주DataGridViewTextBoxColumn1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMsg;
        public System.Windows.Forms.Label lblProdNm;
        public System.Windows.Forms.Label lblDate;
        public System.Windows.Forms.Label lblProd;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.BindingSource sPBarcodeQueryBindingSource;
        private P1B.DataSetP1B dataSetP1B;
        private P1B.DataSetP1BTableAdapters.SP_Barcode_QueryTableAdapter sP_Barcode_QueryTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 바코드DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 바코드SDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 이전바코드DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 공급업체DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 자재코드DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 입고일DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 입고수량DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 잔량DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 등록자DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 갱신자DataGridViewTextBoxColumn;
    }
}