namespace SmartMES_Giroei
{
    partial class P1B14_UNIT_COST_SUB
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
            this.panTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbProduct = new System.Windows.Forms.TextBox();
            this.lbProduct = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblDanga = new System.Windows.Forms.Label();
            this.lbGubun = new System.Windows.Forms.Label();
            this.btnClose = new SmartMES_Giroei.UserButtonA();
            this.btnSave = new SmartMES_Giroei.UserButtonA();
            this.lbSize = new System.Windows.Forms.Label();
            this.tbGubun = new System.Windows.Forms.TextBox();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.lbUnit = new System.Windows.Forms.Label();
            this.tbUnit = new System.Windows.Forms.TextBox();
            this.tbDanga = new System.Windows.Forms.TextBox();
            this.lbYYYYMMDanga = new System.Windows.Forms.Label();
            this.dtpYYYYMMDanga = new System.Windows.Forms.DateTimePicker();
            this.panTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTitle
            // 
            this.panTitle.BackgroundImage = global::SmartMES_Giroei.Properties.Resources.photo_background;
            this.panTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panTitle.Controls.Add(this.lblTitle);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.Location = new System.Drawing.Point(0, 0);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(406, 54);
            this.panTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(27, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(120, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "월별기준단가";
            // 
            // tbProduct
            // 
            this.tbProduct.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbProduct.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbProduct.Location = new System.Drawing.Point(151, 110);
            this.tbProduct.Name = "tbProduct";
            this.tbProduct.ReadOnly = true;
            this.tbProduct.Size = new System.Drawing.Size(211, 29);
            this.tbProduct.TabIndex = 12;
            this.tbProduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextFocus_KeyDown);
            // 
            // lbProduct
            // 
            this.lbProduct.AutoSize = true;
            this.lbProduct.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Underline);
            this.lbProduct.ForeColor = System.Drawing.Color.Blue;
            this.lbProduct.Location = new System.Drawing.Point(28, 113);
            this.lbProduct.Name = "lbProduct";
            this.lbProduct.Size = new System.Drawing.Size(58, 21);
            this.lbProduct.TabIndex = 0;
            this.lbProduct.Text = "품목명";
            this.lbProduct.Click += new System.EventHandler(this.lbProduct_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(12, 67);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(148, 21);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "메시지 라벨입니다.";
            // 
            // lblDanga
            // 
            this.lblDanga.AutoSize = true;
            this.lblDanga.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lblDanga.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDanga.Location = new System.Drawing.Point(28, 396);
            this.lblDanga.Name = "lblDanga";
            this.lblDanga.Size = new System.Drawing.Size(106, 21);
            this.lblDanga.TabIndex = 0;
            this.lblDanga.Text = "월별기준단가";
            // 
            // lbGubun
            // 
            this.lbGubun.AutoSize = true;
            this.lbGubun.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbGubun.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbGubun.Location = new System.Drawing.Point(28, 183);
            this.lbGubun.Name = "lbGubun";
            this.lbGubun.Size = new System.Drawing.Size(42, 21);
            this.lbGubun.TabIndex = 33;
            this.lbGubun.Text = "구분";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::SmartMES_Giroei.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.buttonImage = global::SmartMES_Giroei.Properties.Resources.close;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(224, 538);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 27);
            this.btnClose.TabIndex = 31;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImage = global::SmartMES_Giroei.Properties.Resources.save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.buttonImage = global::SmartMES_Giroei.Properties.Resources.save;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(68, 538);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 27);
            this.btnSave.TabIndex = 30;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbSize.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbSize.Location = new System.Drawing.Point(28, 323);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(42, 21);
            this.lbSize.TabIndex = 35;
            this.lbSize.Text = "규격";
            // 
            // tbGubun
            // 
            this.tbGubun.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbGubun.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbGubun.Location = new System.Drawing.Point(151, 180);
            this.tbGubun.Name = "tbGubun";
            this.tbGubun.ReadOnly = true;
            this.tbGubun.Size = new System.Drawing.Size(211, 29);
            this.tbGubun.TabIndex = 12;
            this.tbGubun.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbGubun.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextFocus_KeyDown);
            // 
            // tbSize
            // 
            this.tbSize.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbSize.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbSize.Location = new System.Drawing.Point(151, 320);
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(211, 29);
            this.tbSize.TabIndex = 12;
            this.tbSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextFocus_KeyDown);
            // 
            // lbUnit
            // 
            this.lbUnit.AutoSize = true;
            this.lbUnit.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbUnit.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbUnit.Location = new System.Drawing.Point(28, 253);
            this.lbUnit.Name = "lbUnit";
            this.lbUnit.Size = new System.Drawing.Size(42, 21);
            this.lbUnit.TabIndex = 37;
            this.lbUnit.Text = "단위";
            // 
            // tbUnit
            // 
            this.tbUnit.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbUnit.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbUnit.Location = new System.Drawing.Point(151, 250);
            this.tbUnit.Name = "tbUnit";
            this.tbUnit.ReadOnly = true;
            this.tbUnit.Size = new System.Drawing.Size(211, 29);
            this.tbUnit.TabIndex = 36;
            this.tbUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextFocus_KeyDown);
            // 
            // tbDanga
            // 
            this.tbDanga.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbDanga.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbDanga.Location = new System.Drawing.Point(151, 390);
            this.tbDanga.Name = "tbDanga";
            this.tbDanga.Size = new System.Drawing.Size(211, 29);
            this.tbDanga.TabIndex = 38;
            this.tbDanga.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbDanga.TextChanged += new System.EventHandler(this.tbDanga_TextChanged);
            this.tbDanga.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextFocus_KeyDown);
            this.tbDanga.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDanga_KeyPress);
            // 
            // lbYYYYMMDanga
            // 
            this.lbYYYYMMDanga.AutoSize = true;
            this.lbYYYYMMDanga.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbYYYYMMDanga.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbYYYYMMDanga.Location = new System.Drawing.Point(28, 463);
            this.lbYYYYMMDanga.Name = "lbYYYYMMDanga";
            this.lbYYYYMMDanga.Size = new System.Drawing.Size(74, 21);
            this.lbYYYYMMDanga.TabIndex = 0;
            this.lbYYYYMMDanga.Text = "계획일자";
            // 
            // dtpYYYYMMDanga
            // 
            this.dtpYYYYMMDanga.CustomFormat = "yyyy-MM";
            this.dtpYYYYMMDanga.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYYYYMMDanga.Location = new System.Drawing.Point(151, 460);
            this.dtpYYYYMMDanga.Name = "dtpYYYYMMDanga";
            this.dtpYYYYMMDanga.Size = new System.Drawing.Size(211, 29);
            this.dtpYYYYMMDanga.TabIndex = 39;
            this.dtpYYYYMMDanga.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextFocus_KeyDown);
            // 
            // P1B14_UNIT_COST_SUB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(406, 621);
            this.Controls.Add(this.dtpYYYYMMDanga);
            this.Controls.Add(this.tbDanga);
            this.Controls.Add(this.lbUnit);
            this.Controls.Add(this.tbUnit);
            this.Controls.Add(this.lbSize);
            this.Controls.Add(this.lbYYYYMMDanga);
            this.Controls.Add(this.lbGubun);
            this.Controls.Add(this.lblDanga);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.tbGubun);
            this.Controls.Add(this.tbProduct);
            this.Controls.Add(this.lbProduct);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.panTitle);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "P1B14_UNIT_COST_SUB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Smart Factory MES";
            this.Load += new System.EventHandler(this.P1B14_UNIT_COST_SUB_Load);
            this.panTitle.ResumeLayout(false);
            this.panTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panTitle;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbProduct;
        private System.Windows.Forms.Label lbProduct;
        private System.Windows.Forms.Label lblMsg;
        private UserButtonA btnSave;
        private UserButtonA btnClose;
        private System.Windows.Forms.Label lblDanga;
        private System.Windows.Forms.Label lbGubun;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.TextBox tbGubun;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.Label lbUnit;
        private System.Windows.Forms.TextBox tbUnit;
        private System.Windows.Forms.TextBox tbDanga;
        private System.Windows.Forms.Label lbYYYYMMDanga;
        private System.Windows.Forms.DateTimePicker dtpYYYYMMDanga;
    }
}