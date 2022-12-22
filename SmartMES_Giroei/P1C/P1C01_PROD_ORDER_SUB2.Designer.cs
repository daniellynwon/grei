
namespace SmartMES_Giroei
{
    partial class P1C01_PROD_ORDER_SUB2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbBigo = new System.Windows.Forms.TextBox();
            this.btClose = new System.Windows.Forms.Button();
            this.dataGridViewA = new System.Windows.Forms.DataGridView();
            this.btn_Save = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSetP1C = new SmartMES_Giroei.P1C.DataSetP1C();
            this.sPJobCommentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sP_Job_CommentTableAdapter = new SmartMES_Giroei.P1C.DataSetP1CTableAdapters.SP_Job_CommentTableAdapter();
            this.순번DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.작성인DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1C)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPJobCommentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbBigo
            // 
            this.tbBigo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbBigo.Location = new System.Drawing.Point(577, 50);
            this.tbBigo.MaxLength = 255;
            this.tbBigo.Multiline = true;
            this.tbBigo.Name = "tbBigo";
            this.tbBigo.Size = new System.Drawing.Size(474, 331);
            this.tbBigo.TabIndex = 0;
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btClose.Location = new System.Drawing.Point(12, 433);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(1038, 42);
            this.btClose.TabIndex = 1;
            this.btClose.Text = "닫기";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // dataGridViewA
            // 
            this.dataGridViewA.AllowUserToAddRows = false;
            this.dataGridViewA.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewA.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewA.AutoGenerateColumns = false;
            this.dataGridViewA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewA.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridViewA.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewA.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewA.ColumnHeadersHeight = 35;
            this.dataGridViewA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.순번DataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.작성인DataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn8,
            this.Column1});
            this.dataGridViewA.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridViewA.DataSource = this.sPJobCommentBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewA.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewA.EnableHeadersVisualStyles = false;
            this.dataGridViewA.Location = new System.Drawing.Point(12, 8);
            this.dataGridViewA.MultiSelect = false;
            this.dataGridViewA.Name = "dataGridViewA";
            this.dataGridViewA.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewA.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewA.RowHeadersVisible = false;
            this.dataGridViewA.RowHeadersWidth = 35;
            this.dataGridViewA.RowTemplate.Height = 35;
            this.dataGridViewA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewA.Size = new System.Drawing.Size(539, 373);
            this.dataGridViewA.TabIndex = 2;
            this.dataGridViewA.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewA_CellClick);
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Save.Location = new System.Drawing.Point(575, 387);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(476, 40);
            this.btn_Save.TabIndex = 3;
            this.btn_Save.Text = "저장";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(574, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(457, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "한번에 작성할수 있는 최대크기는 255자 까지 가능합니다. ";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNew.Location = new System.Drawing.Point(12, 387);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(539, 40);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "새로작성";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "a_seq";
            this.dataGridViewTextBoxColumn1.FillWeight = 30.45686F;
            this.dataGridViewTextBoxColumn1.HeaderText = "a_seq";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "보고사항";
            this.dataGridViewTextBoxColumn2.HeaderText = "보고사항";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 107;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "작성일";
            dataGridViewCellStyle7.Format = "yyyy.MM.dd HH:mm";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn3.FillWeight = 134.7716F;
            this.dataGridViewTextBoxColumn3.HeaderText = "작성일시";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 241;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "enter_man";
            this.dataGridViewTextBoxColumn4.HeaderText = "enter_man";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 107;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "작성자";
            this.dataGridViewTextBoxColumn5.FillWeight = 134.7716F;
            this.dataGridViewTextBoxColumn5.HeaderText = "작성자";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 241;
            // 
            // dataSetP1C
            // 
            this.dataSetP1C.DataSetName = "DataSetP1C";
            this.dataSetP1C.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sPJobCommentBindingSource
            // 
            this.sPJobCommentBindingSource.DataMember = "SP_Job_Comment";
            this.sPJobCommentBindingSource.DataSource = this.dataSetP1C;
            // 
            // sP_Job_CommentTableAdapter
            // 
            this.sP_Job_CommentTableAdapter.ClearBeforeFill = true;
            // 
            // 순번DataGridViewTextBoxColumn
            // 
            this.순번DataGridViewTextBoxColumn.DataPropertyName = "순번";
            this.순번DataGridViewTextBoxColumn.FillWeight = 30F;
            this.순번DataGridViewTextBoxColumn.HeaderText = "No";
            this.순번DataGridViewTextBoxColumn.Name = "순번DataGridViewTextBoxColumn";
            this.순번DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "보고사항";
            this.dataGridViewTextBoxColumn6.HeaderText = "보고사항";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "작성일";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd HH:mm";
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn7.FillWeight = 160F;
            this.dataGridViewTextBoxColumn7.HeaderText = "작성일";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // 작성인DataGridViewTextBoxColumn
            // 
            this.작성인DataGridViewTextBoxColumn.DataPropertyName = "작성인";
            this.작성인DataGridViewTextBoxColumn.HeaderText = "작성인";
            this.작성인DataGridViewTextBoxColumn.Name = "작성인DataGridViewTextBoxColumn";
            this.작성인DataGridViewTextBoxColumn.ReadOnly = true;
            this.작성인DataGridViewTextBoxColumn.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "작성자";
            this.dataGridViewTextBoxColumn8.HeaderText = "작성자";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // Column1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column1.FillWeight = 30F;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Text = "X";
            this.Column1.UseColumnTextForButtonValue = true;
            // 
            // P1C01_PROD_ORDER_SUB2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 486);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.dataGridViewA);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.tbBigo);
            this.Name = "P1C01_PROD_ORDER_SUB2";
            this.Text = "내부진행상황";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1C)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPJobCommentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbBigo;
        private System.Windows.Forms.Button btClose;
        public System.Windows.Forms.DataGridView dataGridViewA;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        //private DataSetP1C_Job dataSetP1C_Job;
        //private DataSetP1C_JobTableAdapters.SP_job3_sub2TableAdapter sP_job3_sub2TableAdapter;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn aseqDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 보고사항DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작성일DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entermanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작성자DataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource sPJobCommentBindingSource;
        private P1C.DataSetP1C dataSetP1C;
        private P1C.DataSetP1CTableAdapters.SP_Job_CommentTableAdapter sP_Job_CommentTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn 순번DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn 작성인DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
    }
}