﻿namespace SmartMES_Giroei
{
    partial class P1B16_ITEM_BOX_RETURN_SUB
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btTagPrint = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lbSujuInfo = new System.Windows.Forms.Label();
            this.btnMaterial = new System.Windows.Forms.Button();
            this.btnItemBox = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sPItemBoxSubReturnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetP1B = new SmartMES_Giroei.P1B.DataSetP1B();
            this.sP_Item_Box_Sub_ReturnTableAdapter = new SmartMES_Giroei.P1B.DataSetP1BTableAdapters.SP_Item_Box_Sub_ReturnTableAdapter();
            this.수주번호DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수주순번DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.업체코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.업체명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.품목코드DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.품목명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.자재코드DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.자재명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.입고일 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.바코드Surfix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.필요수량DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수주수량DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.총필요수량DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.입고량 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.입고량DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.유실수량 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.사급 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수삽 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.미삽 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.비고 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.바코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnExcel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPItemBoxSubReturnBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1B)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.btTagPrint);
            this.panel1.Controls.Add(this.lblMsg);
            this.panel1.Controls.Add(this.lbSujuInfo);
            this.panel1.Controls.Add(this.btnMaterial);
            this.panel1.Controls.Add(this.btnItemBox);
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 59);
            this.panel1.TabIndex = 3;
            // 
            // btTagPrint
            // 
            this.btTagPrint.Location = new System.Drawing.Point(693, 14);
            this.btTagPrint.Name = "btTagPrint";
            this.btTagPrint.Size = new System.Drawing.Size(153, 29);
            this.btTagPrint.TabIndex = 39;
            this.btTagPrint.Text = "공정현품표 재인쇄";
            this.btTagPrint.UseVisualStyleBackColor = true;
            this.btTagPrint.Click += new System.EventHandler(this.btTagPrint_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(4, 31);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(148, 21);
            this.lblMsg.TabIndex = 13;
            this.lblMsg.Text = "메시지 라벨입니다.";
            // 
            // lbSujuInfo
            // 
            this.lbSujuInfo.AutoSize = true;
            this.lbSujuInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbSujuInfo.Location = new System.Drawing.Point(6, 5);
            this.lbSujuInfo.Name = "lbSujuInfo";
            this.lbSujuInfo.Size = new System.Drawing.Size(106, 21);
            this.lbSujuInfo.TabIndex = 11;
            this.lbSujuInfo.Text = "수주정보라벨";
            // 
            // btnMaterial
            // 
            this.btnMaterial.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMaterial.Location = new System.Drawing.Point(852, 14);
            this.btnMaterial.Name = "btnMaterial";
            this.btnMaterial.Size = new System.Drawing.Size(81, 29);
            this.btnMaterial.TabIndex = 14;
            this.btnMaterial.Text = "저   장";
            this.btnMaterial.UseVisualStyleBackColor = true;
            this.btnMaterial.Visible = false;
            this.btnMaterial.Click += new System.EventHandler(this.btnMaterial_Click);
            // 
            // btnItemBox
            // 
            this.btnItemBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnItemBox.Location = new System.Drawing.Point(939, 14);
            this.btnItemBox.Name = "btnItemBox";
            this.btnItemBox.Size = new System.Drawing.Size(123, 29);
            this.btnItemBox.TabIndex = 12;
            this.btnItemBox.Text = "회수수량등록";
            this.btnItemBox.UseVisualStyleBackColor = true;
            this.btnItemBox.Click += new System.EventHandler(this.btnItemBox_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridView1.ColumnHeadersHeight = 50;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.수주번호DataGridViewTextBoxColumn,
            this.수주순번DataGridViewTextBoxColumn,
            this.업체코드,
            this.업체명,
            this.품목코드DataGridViewTextBoxColumn,
            this.품목명DataGridViewTextBoxColumn,
            this.자재코드DataGridViewTextBoxColumn,
            this.자재명DataGridViewTextBoxColumn,
            this.입고일,
            this.바코드Surfix,
            this.Column1,
            this.필요수량DataGridViewTextBoxColumn,
            this.수주수량DataGridViewTextBoxColumn,
            this.총필요수량DataGridViewTextBoxColumn,
            this.입고량,
            this.입고량DataGridViewTextBoxColumn,
            this.유실수량,
            this.사급,
            this.수삽,
            this.미삽,
            this.비고,
            this.바코드});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView1.DataSource = this.sPItemBoxSubReturnBindingSource;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle26;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(5, 73);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle27.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 35;
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1071, 646);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // sPItemBoxSubReturnBindingSource
            // 
            this.sPItemBoxSubReturnBindingSource.DataMember = "SP_Item_Box_Sub_Return";
            this.sPItemBoxSubReturnBindingSource.DataSource = this.dataSetP1B;
            // 
            // dataSetP1B
            // 
            this.dataSetP1B.DataSetName = "DataSetP1B";
            this.dataSetP1B.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sP_Item_Box_Sub_ReturnTableAdapter
            // 
            this.sP_Item_Box_Sub_ReturnTableAdapter.ClearBeforeFill = true;
            // 
            // 수주번호DataGridViewTextBoxColumn
            // 
            this.수주번호DataGridViewTextBoxColumn.DataPropertyName = "수주번호";
            this.수주번호DataGridViewTextBoxColumn.HeaderText = "수주번호";
            this.수주번호DataGridViewTextBoxColumn.Name = "수주번호DataGridViewTextBoxColumn";
            this.수주번호DataGridViewTextBoxColumn.ReadOnly = true;
            this.수주번호DataGridViewTextBoxColumn.Visible = false;
            // 
            // 수주순번DataGridViewTextBoxColumn
            // 
            this.수주순번DataGridViewTextBoxColumn.DataPropertyName = "수주순번";
            this.수주순번DataGridViewTextBoxColumn.HeaderText = "수주순번";
            this.수주순번DataGridViewTextBoxColumn.Name = "수주순번DataGridViewTextBoxColumn";
            this.수주순번DataGridViewTextBoxColumn.ReadOnly = true;
            this.수주순번DataGridViewTextBoxColumn.Visible = false;
            // 
            // 업체코드
            // 
            this.업체코드.DataPropertyName = "업체코드";
            this.업체코드.HeaderText = "업체코드";
            this.업체코드.Name = "업체코드";
            this.업체코드.Visible = false;
            // 
            // 업체명
            // 
            this.업체명.DataPropertyName = "업체명";
            this.업체명.FillWeight = 80F;
            this.업체명.HeaderText = "업체명";
            this.업체명.Name = "업체명";
            this.업체명.Visible = false;
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
            this.품목명DataGridViewTextBoxColumn.Visible = false;
            // 
            // 자재코드DataGridViewTextBoxColumn
            // 
            this.자재코드DataGridViewTextBoxColumn.DataPropertyName = "자재코드";
            this.자재코드DataGridViewTextBoxColumn.FillWeight = 77.08185F;
            this.자재코드DataGridViewTextBoxColumn.HeaderText = "자재코드";
            this.자재코드DataGridViewTextBoxColumn.Name = "자재코드DataGridViewTextBoxColumn";
            // 
            // 자재명DataGridViewTextBoxColumn
            // 
            this.자재명DataGridViewTextBoxColumn.DataPropertyName = "자재명";
            this.자재명DataGridViewTextBoxColumn.FillWeight = 96.3523F;
            this.자재명DataGridViewTextBoxColumn.HeaderText = "자재명";
            this.자재명DataGridViewTextBoxColumn.Name = "자재명DataGridViewTextBoxColumn";
            // 
            // 입고일
            // 
            this.입고일.DataPropertyName = "입고일";
            this.입고일.FillWeight = 67.44662F;
            this.입고일.HeaderText = "LOTNo";
            this.입고일.Name = "입고일";
            // 
            // 바코드Surfix
            // 
            this.바코드Surfix.DataPropertyName = "바코드Surfix";
            this.바코드Surfix.FillWeight = 96.3523F;
            this.바코드Surfix.HeaderText = "바코드Surfix";
            this.바코드Surfix.Name = "바코드Surfix";
            // 
            // Column1
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.NullValue = "LOT";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle21;
            this.Column1.FillWeight = 25F;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // 필요수량DataGridViewTextBoxColumn
            // 
            this.필요수량DataGridViewTextBoxColumn.DataPropertyName = "필요수량";
            dataGridViewCellStyle22.Format = "N0";
            dataGridViewCellStyle22.NullValue = null;
            this.필요수량DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle22;
            this.필요수량DataGridViewTextBoxColumn.FillWeight = 40F;
            this.필요수량DataGridViewTextBoxColumn.HeaderText = "필요수량";
            this.필요수량DataGridViewTextBoxColumn.Name = "필요수량DataGridViewTextBoxColumn";
            this.필요수량DataGridViewTextBoxColumn.Visible = false;
            // 
            // 수주수량DataGridViewTextBoxColumn
            // 
            this.수주수량DataGridViewTextBoxColumn.DataPropertyName = "수주수량";
            dataGridViewCellStyle23.Format = "N0";
            this.수주수량DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle23;
            this.수주수량DataGridViewTextBoxColumn.FillWeight = 40F;
            this.수주수량DataGridViewTextBoxColumn.HeaderText = "수주수량";
            this.수주수량DataGridViewTextBoxColumn.Name = "수주수량DataGridViewTextBoxColumn";
            this.수주수량DataGridViewTextBoxColumn.Visible = false;
            // 
            // 총필요수량DataGridViewTextBoxColumn
            // 
            this.총필요수량DataGridViewTextBoxColumn.DataPropertyName = "총필요수량";
            dataGridViewCellStyle24.Format = "N0";
            this.총필요수량DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle24;
            this.총필요수량DataGridViewTextBoxColumn.FillWeight = 57.68908F;
            this.총필요수량DataGridViewTextBoxColumn.HeaderText = "소요수량";
            this.총필요수량DataGridViewTextBoxColumn.Name = "총필요수량DataGridViewTextBoxColumn";
            // 
            // 입고량
            // 
            this.입고량.DataPropertyName = "입고량";
            this.입고량.FillWeight = 57.70251F;
            this.입고량.HeaderText = "투입수량";
            this.입고량.Name = "입고량";
            // 
            // 입고량DataGridViewTextBoxColumn
            // 
            this.입고량DataGridViewTextBoxColumn.DataPropertyName = "회수량";
            dataGridViewCellStyle25.Format = "N0";
            dataGridViewCellStyle25.NullValue = null;
            this.입고량DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle25;
            this.입고량DataGridViewTextBoxColumn.FillWeight = 55.7451F;
            this.입고량DataGridViewTextBoxColumn.HeaderText = "회수량";
            this.입고량DataGridViewTextBoxColumn.Name = "입고량DataGridViewTextBoxColumn";
            // 
            // 유실수량
            // 
            this.유실수량.DataPropertyName = "유실수량";
            this.유실수량.FillWeight = 59.86766F;
            this.유실수량.HeaderText = "유실수량";
            this.유실수량.Name = "유실수량";
            // 
            // 사급
            // 
            this.사급.DataPropertyName = "사급";
            this.사급.FillWeight = 30.88129F;
            this.사급.HeaderText = "사급";
            this.사급.Name = "사급";
            this.사급.ReadOnly = true;
            this.사급.Visible = false;
            // 
            // 수삽
            // 
            this.수삽.DataPropertyName = "수삽";
            this.수삽.FillWeight = 30.88129F;
            this.수삽.HeaderText = "수삽";
            this.수삽.Name = "수삽";
            this.수삽.ReadOnly = true;
            this.수삽.Visible = false;
            // 
            // 미삽
            // 
            this.미삽.DataPropertyName = "미삽";
            this.미삽.FillWeight = 30F;
            this.미삽.HeaderText = "미삽";
            this.미삽.Name = "미삽";
            this.미삽.ReadOnly = true;
            this.미삽.Visible = false;
            // 
            // 비고
            // 
            this.비고.DataPropertyName = "비고";
            this.비고.FillWeight = 60F;
            this.비고.HeaderText = "비고";
            this.비고.Name = "비고";
            this.비고.Visible = false;
            // 
            // 바코드
            // 
            this.바코드.DataPropertyName = "바코드";
            this.바코드.HeaderText = "바코드";
            this.바코드.Name = "바코드";
            this.바코드.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(554, 45);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(133, 10);
            this.progressBar1.TabIndex = 45;
            this.progressBar1.Visible = false;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExcel.Location = new System.Drawing.Point(554, 14);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(133, 29);
            this.btnExcel.TabIndex = 44;
            this.btnExcel.Text = "BOM불러오기";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // P1B16_ITEM_BOX_RETURN_SUB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1080, 722);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "P1B16_ITEM_BOX_RETURN_SUB";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Smart Factory MES";
            this.Load += new System.EventHandler(this.P1B16_ITEM_BOX_RETURN_SUB_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPItemBoxSubReturnBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1B)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbSujuInfo;
        public System.Windows.Forms.DataGridView dataGridView1;
        private P1B.DataSetP1B dataSetP1B;
        private System.Windows.Forms.Button btnItemBox;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnMaterial;
        private System.Windows.Forms.Button btTagPrint;
        private P1B.DataSetP1BTableAdapters.SP_Item_Box_Sub_ReturnTableAdapter sP_Item_Box_Sub_ReturnTableAdapter;
        private System.Windows.Forms.BindingSource sPItemBoxSubReturnBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주번호DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주순번DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 업체코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn 업체명;
        private System.Windows.Forms.DataGridViewTextBoxColumn 품목코드DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 품목명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 자재코드DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 자재명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 입고일;
        private System.Windows.Forms.DataGridViewTextBoxColumn 바코드Surfix;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 필요수량DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수주수량DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 총필요수량DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 입고량;
        private System.Windows.Forms.DataGridViewTextBoxColumn 입고량DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 유실수량;
        private System.Windows.Forms.DataGridViewTextBoxColumn 사급;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수삽;
        private System.Windows.Forms.DataGridViewTextBoxColumn 미삽;
        private System.Windows.Forms.DataGridViewTextBoxColumn 비고;
        private System.Windows.Forms.DataGridViewTextBoxColumn 바코드;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnExcel;
    }
}