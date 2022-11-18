namespace SmartMES_Giroei
{
    partial class P1D03_MAINTENANCE_SUB
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
            this.tbMoney = new System.Windows.Forms.TextBox();
            this.tbGoal = new System.Windows.Forms.TextBox();
            this.lbKind = new System.Windows.Forms.Label();
            this.lbStartDate = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.tbMan = new System.Windows.Forms.TextBox();
            this.lbResult = new System.Windows.Forms.Label();
            this.lbMan1 = new System.Windows.Forms.Label();
            this.lbGoal = new System.Windows.Forms.Label();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.lbMoney = new System.Windows.Forms.Label();
            this.cbKind = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSelect = new System.Windows.Forms.Label();
            this.tbModel = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbHo = new System.Windows.Forms.TextBox();
            this.lbModel = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbHo = new System.Windows.Forms.Label();
            this.lbMan2 = new System.Windows.Forms.Label();
            this.lbContents = new System.Windows.Forms.Label();
            this.tbContents = new System.Windows.Forms.TextBox();
            this.dtpStartDate = new System.Windows.Forms.MaskedTextBox();
            this.btnClose = new SmartMES_Giroei.UserButtonA();
            this.btnSave = new SmartMES_Giroei.UserButtonA();
            this.dtpRepairDate = new System.Windows.Forms.DateTimePicker();
            this.lbRepairDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.MaskedTextBox();
            this.lbEndDate = new System.Windows.Forms.Label();
            this.panTitle.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.panTitle.Size = new System.Drawing.Size(844, 54);
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
            this.lblTitle.Text = "설비보전등록";
            // 
            // tbMoney
            // 
            this.tbMoney.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbMoney.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbMoney.Location = new System.Drawing.Point(556, 538);
            this.tbMoney.Name = "tbMoney";
            this.tbMoney.Size = new System.Drawing.Size(211, 29);
            this.tbMoney.TabIndex = 7;
            this.tbMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbMoney.TextChanged += new System.EventHandler(this.tbMoney_TextChanged);
            this.tbMoney.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextFocus_KeyDown);
            this.tbMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMoney_KeyPress);
            // 
            // tbGoal
            // 
            this.tbGoal.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbGoal.Location = new System.Drawing.Point(181, 382);
            this.tbGoal.Multiline = true;
            this.tbGoal.Name = "tbGoal";
            this.tbGoal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbGoal.Size = new System.Drawing.Size(586, 53);
            this.tbGoal.TabIndex = 4;
            // 
            // lbKind
            // 
            this.lbKind.AutoSize = true;
            this.lbKind.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbKind.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbKind.Location = new System.Drawing.Point(444, 272);
            this.lbKind.Name = "lbKind";
            this.lbKind.Size = new System.Drawing.Size(74, 21);
            this.lbKind.TabIndex = 0;
            this.lbKind.Text = "점검형태";
            // 
            // lbStartDate
            // 
            this.lbStartDate.AutoSize = true;
            this.lbStartDate.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbStartDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbStartDate.Location = new System.Drawing.Point(69, 326);
            this.lbStartDate.Name = "lbStartDate";
            this.lbStartDate.Size = new System.Drawing.Size(106, 21);
            this.lbStartDate.TabIndex = 0;
            this.lbStartDate.Text = "수리시작시간";
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
            // tbMan
            // 
            this.tbMan.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbMan.Location = new System.Drawing.Point(181, 537);
            this.tbMan.Name = "tbMan";
            this.tbMan.Size = new System.Drawing.Size(211, 29);
            this.tbMan.TabIndex = 6;
            this.tbMan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbMan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextFocus_KeyDown);
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbResult.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbResult.Location = new System.Drawing.Point(69, 452);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(74, 42);
            this.lbResult.TabIndex = 0;
            this.lbResult.Text = "점검및\r\n조치결과";
            // 
            // lbMan1
            // 
            this.lbMan1.AutoSize = true;
            this.lbMan1.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbMan1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbMan1.Location = new System.Drawing.Point(69, 538);
            this.lbMan1.Name = "lbMan1";
            this.lbMan1.Size = new System.Drawing.Size(58, 21);
            this.lbMan1.TabIndex = 0;
            this.lbMan1.Text = "점검자";
            // 
            // lbGoal
            // 
            this.lbGoal.AutoSize = true;
            this.lbGoal.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbGoal.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbGoal.Location = new System.Drawing.Point(66, 386);
            this.lbGoal.Name = "lbGoal";
            this.lbGoal.Size = new System.Drawing.Size(80, 21);
            this.lbGoal.TabIndex = 0;
            this.lbGoal.Text = "내역/목표";
            // 
            // tbResult
            // 
            this.tbResult.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbResult.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbResult.Location = new System.Drawing.Point(181, 448);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbResult.Size = new System.Drawing.Size(586, 53);
            this.tbResult.TabIndex = 5;
            // 
            // lbMoney
            // 
            this.lbMoney.AutoSize = true;
            this.lbMoney.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbMoney.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbMoney.Location = new System.Drawing.Point(444, 541);
            this.lbMoney.Name = "lbMoney";
            this.lbMoney.Size = new System.Drawing.Size(74, 21);
            this.lbMoney.TabIndex = 0;
            this.lbMoney.Text = "소요비용";
            // 
            // cbKind
            // 
            this.cbKind.BackColor = System.Drawing.SystemColors.Window;
            this.cbKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKind.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.cbKind.FormattingEnabled = true;
            this.cbKind.Items.AddRange(new object[] {
            "1.예방보전",
            "2.정기보전",
            "3.개량보전",
            "4.사후보전",
            "5.고장등록",
            "6.고장수리",
            "9.기타"});
            this.cbKind.Location = new System.Drawing.Point(556, 268);
            this.cbKind.Name = "cbKind";
            this.cbKind.Size = new System.Drawing.Size(211, 29);
            this.cbKind.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSelect);
            this.groupBox1.Controls.Add(this.tbModel);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.tbHo);
            this.groupBox1.Controls.Add(this.lbModel);
            this.groupBox1.Controls.Add(this.lbName);
            this.groupBox1.Controls.Add(this.lbHo);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(32, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(777, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Underline);
            this.lblSelect.ForeColor = System.Drawing.Color.Blue;
            this.lblSelect.Location = new System.Drawing.Point(34, 0);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(74, 21);
            this.lblSelect.TabIndex = 1;
            this.lblSelect.Text = "설비선택";
            this.lblSelect.Click += new System.EventHandler(this.lblSelect_Click);
            // 
            // tbModel
            // 
            this.tbModel.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbModel.Location = new System.Drawing.Point(524, 96);
            this.tbModel.Name = "tbModel";
            this.tbModel.ReadOnly = true;
            this.tbModel.Size = new System.Drawing.Size(211, 29);
            this.tbModel.TabIndex = 0;
            this.tbModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbName.Location = new System.Drawing.Point(149, 96);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(211, 29);
            this.tbName.TabIndex = 0;
            this.tbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbHo
            // 
            this.tbHo.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbHo.Location = new System.Drawing.Point(149, 53);
            this.tbHo.Name = "tbHo";
            this.tbHo.ReadOnly = true;
            this.tbHo.Size = new System.Drawing.Size(211, 29);
            this.tbHo.TabIndex = 0;
            this.tbHo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbModel
            // 
            this.lbModel.AutoSize = true;
            this.lbModel.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbModel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbModel.Location = new System.Drawing.Point(412, 100);
            this.lbModel.Name = "lbModel";
            this.lbModel.Size = new System.Drawing.Size(74, 21);
            this.lbModel.TabIndex = 0;
            this.lbModel.Text = "설비그룹";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbName.Location = new System.Drawing.Point(37, 100);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(58, 21);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "설비명";
            // 
            // lbHo
            // 
            this.lbHo.AutoSize = true;
            this.lbHo.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbHo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbHo.Location = new System.Drawing.Point(37, 57);
            this.lbHo.Name = "lbHo";
            this.lbHo.Size = new System.Drawing.Size(48, 21);
            this.lbHo.TabIndex = 0;
            this.lbHo.Text = "호 기";
            // 
            // lbMan2
            // 
            this.lbMan2.AutoSize = true;
            this.lbMan2.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lbMan2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbMan2.Location = new System.Drawing.Point(43, 556);
            this.lbMan2.Name = "lbMan2";
            this.lbMan2.Size = new System.Drawing.Size(116, 19);
            this.lbMan2.TabIndex = 0;
            this.lbMan2.Text = "(A/S업체/연락처)";
            // 
            // lbContents
            // 
            this.lbContents.AutoSize = true;
            this.lbContents.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbContents.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbContents.Location = new System.Drawing.Point(69, 606);
            this.lbContents.Name = "lbContents";
            this.lbContents.Size = new System.Drawing.Size(48, 21);
            this.lbContents.TabIndex = 0;
            this.lbContents.Text = "비 고";
            // 
            // tbContents
            // 
            this.tbContents.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbContents.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbContents.Location = new System.Drawing.Point(181, 602);
            this.tbContents.Name = "tbContents";
            this.tbContents.Size = new System.Drawing.Size(586, 29);
            this.tbContents.TabIndex = 8;
            this.tbContents.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextFocus_KeyDown);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpStartDate.Location = new System.Drawing.Point(181, 323);
            this.dtpStartDate.Mask = "0000-90-90 90:90:90";
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(211, 29);
            this.dtpStartDate.TabIndex = 76;
            this.dtpStartDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::SmartMES_Giroei.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.buttonImage = global::SmartMES_Giroei.Properties.Resources.close;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(450, 675);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 27);
            this.btnClose.TabIndex = 11;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImage = global::SmartMES_Giroei.Properties.Resources.save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.buttonImage = global::SmartMES_Giroei.Properties.Resources.save;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(294, 675);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 27);
            this.btnSave.TabIndex = 10;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpRepairDate
            // 
            this.dtpRepairDate.CalendarFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpRepairDate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpRepairDate.Location = new System.Drawing.Point(181, 268);
            this.dtpRepairDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpRepairDate.Name = "dtpRepairDate";
            this.dtpRepairDate.Size = new System.Drawing.Size(211, 29);
            this.dtpRepairDate.TabIndex = 78;
            // 
            // lbRepairDate
            // 
            this.lbRepairDate.AutoSize = true;
            this.lbRepairDate.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbRepairDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbRepairDate.Location = new System.Drawing.Point(69, 272);
            this.lbRepairDate.Name = "lbRepairDate";
            this.lbRepairDate.Size = new System.Drawing.Size(74, 21);
            this.lbRepairDate.TabIndex = 77;
            this.lbRepairDate.Text = "점검일자";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpEndDate.Location = new System.Drawing.Point(556, 323);
            this.dtpEndDate.Mask = "0000-90-90 90:90:90";
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(211, 29);
            this.dtpEndDate.TabIndex = 80;
            this.dtpEndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbEndDate
            // 
            this.lbEndDate.AutoSize = true;
            this.lbEndDate.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbEndDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbEndDate.Location = new System.Drawing.Point(444, 327);
            this.lbEndDate.Name = "lbEndDate";
            this.lbEndDate.Size = new System.Drawing.Size(106, 21);
            this.lbEndDate.TabIndex = 79;
            this.lbEndDate.Text = "수리종료시간";
            // 
            // P1D03_MAINTENANCE_SUB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(844, 738);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lbEndDate);
            this.Controls.Add(this.dtpRepairDate);
            this.Controls.Add(this.lbRepairDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.tbMan);
            this.Controls.Add(this.lbContents);
            this.Controls.Add(this.tbContents);
            this.Controls.Add(this.lbMan2);
            this.Controls.Add(this.cbKind);
            this.Controls.Add(this.lbMoney);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.lbGoal);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.lbMan1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbMoney);
            this.Controls.Add(this.tbGoal);
            this.Controls.Add(this.lbKind);
            this.Controls.Add(this.lbStartDate);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.panTitle);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "P1D03_MAINTENANCE_SUB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Smart Factory MES";
            this.Load += new System.EventHandler(this.P1D03_MAINTENANCE_SUB_Load);
            this.panTitle.ResumeLayout(false);
            this.panTitle.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panTitle;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbMoney;
        private System.Windows.Forms.TextBox tbGoal;
        private System.Windows.Forms.Label lbKind;
        private System.Windows.Forms.Label lbStartDate;
        private System.Windows.Forms.Label lblMsg;
        private UserButtonA btnSave;
        private UserButtonA btnClose;
        private System.Windows.Forms.TextBox tbMan;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Label lbMan1;
        private System.Windows.Forms.Label lbGoal;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label lbMoney;
        private System.Windows.Forms.ComboBox cbKind;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbModel;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbHo;
        private System.Windows.Forms.Label lbModel;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbHo;
        private System.Windows.Forms.Label lbMan2;
        private System.Windows.Forms.Label lbContents;
        private System.Windows.Forms.TextBox tbContents;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.MaskedTextBox dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpRepairDate;
        private System.Windows.Forms.Label lbRepairDate;
        private System.Windows.Forms.MaskedTextBox dtpEndDate;
        private System.Windows.Forms.Label lbEndDate;
    }
}