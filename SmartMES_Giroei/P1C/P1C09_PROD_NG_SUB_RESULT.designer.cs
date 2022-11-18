namespace SmartMES_Giroei
{
    partial class P1C09_PROD_NG_SUB_RESULT
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
            this.lblMsg = new System.Windows.Forms.Label();
            this.lbInsCode = new System.Windows.Forms.Label();
            this.dtpInsDate = new System.Windows.Forms.DateTimePicker();
            this.lbInsDate = new System.Windows.Forms.Label();
            this.lbJobSeq = new System.Windows.Forms.Label();
            this.tbJobSeq = new System.Windows.Forms.TextBox();
            this.lbDefectQty = new System.Windows.Forms.Label();
            this.tbDefectQty = new System.Windows.Forms.TextBox();
            this.lbDefectPart = new System.Windows.Forms.Label();
            this.lbJobNo = new System.Windows.Forms.Label();
            this.tbJobNo = new System.Windows.Forms.TextBox();
            this.lbBigo = new System.Windows.Forms.Label();
            this.tbBigo = new System.Windows.Forms.TextBox();
            this.btnClose = new SmartMES_Giroei.UserButtonA();
            this.btnSave = new SmartMES_Giroei.UserButtonA();
            this.cbInsCode = new System.Windows.Forms.ComboBox();
            this.cbDefectPart = new System.Windows.Forms.ComboBox();
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
            this.panTitle.Size = new System.Drawing.Size(691, 54);
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
            this.lblTitle.Text = "공정불량등록";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(28, 73);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(148, 21);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "메시지 라벨입니다.";
            // 
            // lbInsCode
            // 
            this.lbInsCode.AutoSize = true;
            this.lbInsCode.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbInsCode.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbInsCode.Location = new System.Drawing.Point(60, 179);
            this.lbInsCode.Name = "lbInsCode";
            this.lbInsCode.Size = new System.Drawing.Size(74, 21);
            this.lbInsCode.TabIndex = 0;
            this.lbInsCode.Text = "검사코드";
            // 
            // dtpInsDate
            // 
            this.dtpInsDate.CalendarFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpInsDate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpInsDate.Location = new System.Drawing.Point(454, 176);
            this.dtpInsDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpInsDate.Name = "dtpInsDate";
            this.dtpInsDate.Size = new System.Drawing.Size(185, 29);
            this.dtpInsDate.TabIndex = 3;
            // 
            // lbInsDate
            // 
            this.lbInsDate.AutoSize = true;
            this.lbInsDate.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbInsDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbInsDate.Location = new System.Drawing.Point(374, 179);
            this.lbInsDate.Name = "lbInsDate";
            this.lbInsDate.Size = new System.Drawing.Size(74, 21);
            this.lbInsDate.TabIndex = 0;
            this.lbInsDate.Text = "검사일자";
            // 
            // lbJobSeq
            // 
            this.lbJobSeq.AutoSize = true;
            this.lbJobSeq.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbJobSeq.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbJobSeq.Location = new System.Drawing.Point(358, 109);
            this.lbJobSeq.Name = "lbJobSeq";
            this.lbJobSeq.Size = new System.Drawing.Size(90, 21);
            this.lbJobSeq.TabIndex = 0;
            this.lbJobSeq.Text = "작지시퀀스";
            this.lbJobSeq.Visible = false;
            // 
            // tbJobSeq
            // 
            this.tbJobSeq.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbJobSeq.Location = new System.Drawing.Point(454, 106);
            this.tbJobSeq.Name = "tbJobSeq";
            this.tbJobSeq.ReadOnly = true;
            this.tbJobSeq.Size = new System.Drawing.Size(185, 29);
            this.tbJobSeq.TabIndex = 1;
            this.tbJobSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbJobSeq.Visible = false;
            // 
            // lbDefectQty
            // 
            this.lbDefectQty.AutoSize = true;
            this.lbDefectQty.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbDefectQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbDefectQty.Location = new System.Drawing.Point(44, 249);
            this.lbDefectQty.Name = "lbDefectQty";
            this.lbDefectQty.Size = new System.Drawing.Size(90, 21);
            this.lbDefectQty.TabIndex = 0;
            this.lbDefectQty.Text = "불합격수량";
            // 
            // tbDefectQty
            // 
            this.tbDefectQty.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbDefectQty.Location = new System.Drawing.Point(140, 246);
            this.tbDefectQty.Name = "tbDefectQty";
            this.tbDefectQty.Size = new System.Drawing.Size(185, 29);
            this.tbDefectQty.TabIndex = 4;
            this.tbDefectQty.Text = "0";
            this.tbDefectQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDefectQty.TextChanged += new System.EventHandler(this.tbDefectQty_TextChanged);
            this.tbDefectQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDefectQty_KeyPress);
            // 
            // lbDefectPart
            // 
            this.lbDefectPart.AutoSize = true;
            this.lbDefectPart.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbDefectPart.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbDefectPart.Location = new System.Drawing.Point(374, 249);
            this.lbDefectPart.Name = "lbDefectPart";
            this.lbDefectPart.Size = new System.Drawing.Size(74, 21);
            this.lbDefectPart.TabIndex = 0;
            this.lbDefectPart.Text = "귀책부서";
            // 
            // lbJobNo
            // 
            this.lbJobNo.AutoSize = true;
            this.lbJobNo.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbJobNo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbJobNo.Location = new System.Drawing.Point(28, 109);
            this.lbJobNo.Name = "lbJobNo";
            this.lbJobNo.Size = new System.Drawing.Size(106, 21);
            this.lbJobNo.TabIndex = 0;
            this.lbJobNo.Text = "작업지시번호";
            // 
            // tbJobNo
            // 
            this.tbJobNo.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbJobNo.Location = new System.Drawing.Point(140, 106);
            this.tbJobNo.Name = "tbJobNo";
            this.tbJobNo.ReadOnly = true;
            this.tbJobNo.Size = new System.Drawing.Size(185, 29);
            this.tbJobNo.TabIndex = 0;
            this.tbJobNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbBigo
            // 
            this.lbBigo.AutoSize = true;
            this.lbBigo.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbBigo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbBigo.Location = new System.Drawing.Point(92, 319);
            this.lbBigo.Name = "lbBigo";
            this.lbBigo.Size = new System.Drawing.Size(42, 21);
            this.lbBigo.TabIndex = 0;
            this.lbBigo.Text = "비고";
            // 
            // tbBigo
            // 
            this.tbBigo.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbBigo.Location = new System.Drawing.Point(140, 316);
            this.tbBigo.Multiline = true;
            this.tbBigo.Name = "tbBigo";
            this.tbBigo.Size = new System.Drawing.Size(499, 100);
            this.tbBigo.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::SmartMES_Giroei.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.buttonImage = global::SmartMES_Giroei.Properties.Resources.close;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(378, 459);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 27);
            this.btnClose.TabIndex = 8;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImage = global::SmartMES_Giroei.Properties.Resources.save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.buttonImage = global::SmartMES_Giroei.Properties.Resources.save;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(222, 459);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 27);
            this.btnSave.TabIndex = 7;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbInsCode
            // 
            this.cbInsCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInsCode.FormattingEnabled = true;
            this.cbInsCode.Location = new System.Drawing.Point(140, 176);
            this.cbInsCode.Name = "cbInsCode";
            this.cbInsCode.Size = new System.Drawing.Size(185, 29);
            this.cbInsCode.TabIndex = 2;
            // 
            // cbDefectPart
            // 
            this.cbDefectPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefectPart.FormattingEnabled = true;
            this.cbDefectPart.Location = new System.Drawing.Point(454, 246);
            this.cbDefectPart.Name = "cbDefectPart";
            this.cbDefectPart.Size = new System.Drawing.Size(185, 29);
            this.cbDefectPart.TabIndex = 5;
            // 
            // P1C09_PROD_NG_SUB_RESULT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(691, 542);
            this.Controls.Add(this.cbDefectPart);
            this.Controls.Add(this.lbBigo);
            this.Controls.Add(this.tbBigo);
            this.Controls.Add(this.lbJobNo);
            this.Controls.Add(this.tbJobNo);
            this.Controls.Add(this.lbDefectPart);
            this.Controls.Add(this.lbDefectQty);
            this.Controls.Add(this.tbDefectQty);
            this.Controls.Add(this.lbJobSeq);
            this.Controls.Add(this.tbJobSeq);
            this.Controls.Add(this.dtpInsDate);
            this.Controls.Add(this.lbInsDate);
            this.Controls.Add(this.lbInsCode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.panTitle);
            this.Controls.Add(this.cbInsCode);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "P1C09_PROD_NG_SUB_RESULT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Smart Factory MES";
            this.Load += new System.EventHandler(this.P1C09_PROD_NG_SUB_RESULT_Load);
            this.panTitle.ResumeLayout(false);
            this.panTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panTitle;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMsg;
        private UserButtonA btnSave;
        private UserButtonA btnClose;
        private System.Windows.Forms.Label lbInsCode;
        private System.Windows.Forms.DateTimePicker dtpInsDate;
        private System.Windows.Forms.Label lbInsDate;
        private System.Windows.Forms.Label lbJobSeq;
        private System.Windows.Forms.TextBox tbJobSeq;
        private System.Windows.Forms.Label lbDefectQty;
        private System.Windows.Forms.TextBox tbDefectQty;
        private System.Windows.Forms.Label lbDefectPart;
        private System.Windows.Forms.Label lbJobNo;
        private System.Windows.Forms.TextBox tbJobNo;
        private System.Windows.Forms.Label lbBigo;
        private System.Windows.Forms.TextBox tbBigo;
        private System.Windows.Forms.ComboBox cbInsCode;
        private System.Windows.Forms.ComboBox cbDefectPart;
    }
}