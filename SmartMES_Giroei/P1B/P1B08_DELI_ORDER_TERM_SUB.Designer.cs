namespace SmartMES_Giroei
{
    partial class P1B08_DELI_ORDER_TERM_SUB
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
            this.lbRorderNo = new System.Windows.Forms.Label();
            this.lbCust = new System.Windows.Forms.Label();
            this.lbProdName = new System.Windows.Forms.Label();
            this.tbRorderNo = new System.Windows.Forms.TextBox();
            this.tbCust = new System.Windows.Forms.TextBox();
            this.tbProdName = new System.Windows.Forms.TextBox();
            this.lbMethod = new System.Windows.Forms.Label();
            this.tbQty = new System.Windows.Forms.TextBox();
            this.lbQty = new System.Windows.Forms.Label();
            this.tbSampleCount = new System.Windows.Forms.TextBox();
            this.lbSampleCount = new System.Windows.Forms.Label();
            this.tbNGCount = new System.Windows.Forms.TextBox();
            this.lbNGCount = new System.Windows.Forms.Label();
            this.lbContents = new System.Windows.Forms.Label();
            this.tbContents = new System.Windows.Forms.TextBox();
            this.cbMethod = new System.Windows.Forms.ComboBox();
            this.tbDeliID = new System.Windows.Forms.TextBox();
            this.lbDeliID = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.ckbResult = new System.Windows.Forms.CheckBox();
            this.btnClose = new SmartMES_Giroei.UserButtonA();
            this.btnSave = new SmartMES_Giroei.UserButtonA();
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
            this.panTitle.Size = new System.Drawing.Size(785, 54);
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
            this.lblTitle.Size = new System.Drawing.Size(84, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "출고검사";
            // 
            // lbRorderNo
            // 
            this.lbRorderNo.AutoSize = true;
            this.lbRorderNo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbRorderNo.Location = new System.Drawing.Point(30, 120);
            this.lbRorderNo.Name = "lbRorderNo";
            this.lbRorderNo.Size = new System.Drawing.Size(74, 21);
            this.lbRorderNo.TabIndex = 0;
            this.lbRorderNo.Text = "수주번호";
            // 
            // lbCust
            // 
            this.lbCust.AutoSize = true;
            this.lbCust.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbCust.Location = new System.Drawing.Point(415, 120);
            this.lbCust.Name = "lbCust";
            this.lbCust.Size = new System.Drawing.Size(58, 21);
            this.lbCust.TabIndex = 0;
            this.lbCust.Text = "고객사";
            // 
            // lbProdName
            // 
            this.lbProdName.AutoSize = true;
            this.lbProdName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbProdName.Location = new System.Drawing.Point(30, 220);
            this.lbProdName.Name = "lbProdName";
            this.lbProdName.Size = new System.Drawing.Size(58, 21);
            this.lbProdName.TabIndex = 0;
            this.lbProdName.Text = "상품명";
            // 
            // tbRorderNo
            // 
            this.tbRorderNo.Location = new System.Drawing.Point(165, 117);
            this.tbRorderNo.Name = "tbRorderNo";
            this.tbRorderNo.ReadOnly = true;
            this.tbRorderNo.Size = new System.Drawing.Size(200, 29);
            this.tbRorderNo.TabIndex = 0;
            this.tbRorderNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCust
            // 
            this.tbCust.Location = new System.Drawing.Point(530, 117);
            this.tbCust.Name = "tbCust";
            this.tbCust.ReadOnly = true;
            this.tbCust.Size = new System.Drawing.Size(200, 29);
            this.tbCust.TabIndex = 0;
            this.tbCust.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbProdName
            // 
            this.tbProdName.Location = new System.Drawing.Point(165, 217);
            this.tbProdName.Name = "tbProdName";
            this.tbProdName.ReadOnly = true;
            this.tbProdName.Size = new System.Drawing.Size(200, 29);
            this.tbProdName.TabIndex = 0;
            this.tbProdName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbMethod
            // 
            this.lbMethod.AutoSize = true;
            this.lbMethod.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbMethod.Location = new System.Drawing.Point(30, 270);
            this.lbMethod.Name = "lbMethod";
            this.lbMethod.Size = new System.Drawing.Size(74, 21);
            this.lbMethod.TabIndex = 0;
            this.lbMethod.Text = "검사방식";
            // 
            // tbQty
            // 
            this.tbQty.Location = new System.Drawing.Point(530, 217);
            this.tbQty.Name = "tbQty";
            this.tbQty.Size = new System.Drawing.Size(200, 29);
            this.tbQty.TabIndex = 0;
            // 
            // lbQty
            // 
            this.lbQty.AutoSize = true;
            this.lbQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbQty.Location = new System.Drawing.Point(415, 220);
            this.lbQty.Name = "lbQty";
            this.lbQty.Size = new System.Drawing.Size(58, 21);
            this.lbQty.TabIndex = 0;
            this.lbQty.Text = "생산량";
            // 
            // tbSampleCount
            // 
            this.tbSampleCount.Location = new System.Drawing.Point(165, 317);
            this.tbSampleCount.Name = "tbSampleCount";
            this.tbSampleCount.Size = new System.Drawing.Size(200, 29);
            this.tbSampleCount.TabIndex = 2;
            this.tbSampleCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbSampleCount
            // 
            this.lbSampleCount.AutoSize = true;
            this.lbSampleCount.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbSampleCount.Location = new System.Drawing.Point(30, 320);
            this.lbSampleCount.Name = "lbSampleCount";
            this.lbSampleCount.Size = new System.Drawing.Size(58, 21);
            this.lbSampleCount.TabIndex = 0;
            this.lbSampleCount.Text = "검사수";
            // 
            // tbNGCount
            // 
            this.tbNGCount.Location = new System.Drawing.Point(530, 317);
            this.tbNGCount.Name = "tbNGCount";
            this.tbNGCount.Size = new System.Drawing.Size(200, 29);
            this.tbNGCount.TabIndex = 3;
            this.tbNGCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbNGCount
            // 
            this.lbNGCount.AutoSize = true;
            this.lbNGCount.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbNGCount.Location = new System.Drawing.Point(415, 320);
            this.lbNGCount.Name = "lbNGCount";
            this.lbNGCount.Size = new System.Drawing.Size(58, 21);
            this.lbNGCount.TabIndex = 0;
            this.lbNGCount.Text = "불량수";
            // 
            // lbContents
            // 
            this.lbContents.AutoSize = true;
            this.lbContents.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbContents.Location = new System.Drawing.Point(30, 370);
            this.lbContents.Name = "lbContents";
            this.lbContents.Size = new System.Drawing.Size(74, 21);
            this.lbContents.TabIndex = 44;
            this.lbContents.Text = "특이사항";
            // 
            // tbContents
            // 
            this.tbContents.Location = new System.Drawing.Point(165, 370);
            this.tbContents.Multiline = true;
            this.tbContents.Name = "tbContents";
            this.tbContents.Size = new System.Drawing.Size(565, 150);
            this.tbContents.TabIndex = 5;
            // 
            // cbMethod
            // 
            this.cbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMethod.FormattingEnabled = true;
            this.cbMethod.Items.AddRange(new object[] {
            "1.G-II",
            "2.0.65"});
            this.cbMethod.Location = new System.Drawing.Point(165, 267);
            this.cbMethod.Name = "cbMethod";
            this.cbMethod.Size = new System.Drawing.Size(200, 29);
            this.cbMethod.TabIndex = 1;
            // 
            // tbDeliID
            // 
            this.tbDeliID.Location = new System.Drawing.Point(165, 167);
            this.tbDeliID.Name = "tbDeliID";
            this.tbDeliID.ReadOnly = true;
            this.tbDeliID.Size = new System.Drawing.Size(200, 29);
            this.tbDeliID.TabIndex = 0;
            this.tbDeliID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbDeliID
            // 
            this.lbDeliID.AutoSize = true;
            this.lbDeliID.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbDeliID.Location = new System.Drawing.Point(30, 170);
            this.lbDeliID.Name = "lbDeliID";
            this.lbDeliID.Size = new System.Drawing.Size(116, 21);
            this.lbDeliID.TabIndex = 0;
            this.lbDeliID.Text = "출하(지시)번호";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(30, 75);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(148, 21);
            this.lblMsg.TabIndex = 49;
            this.lblMsg.Text = "메시지 라벨입니다.";
            // 
            // ckbResult
            // 
            this.ckbResult.AutoSize = true;
            this.ckbResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ckbResult.Location = new System.Drawing.Point(637, 526);
            this.ckbResult.Name = "ckbResult";
            this.ckbResult.Size = new System.Drawing.Size(93, 25);
            this.ckbResult.TabIndex = 51;
            this.ckbResult.Text = "합격여부";
            this.ckbResult.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::SmartMES_Giroei.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.buttonImage = global::SmartMES_Giroei.Properties.Resources.close;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(420, 570);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 27);
            this.btnClose.TabIndex = 33;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImage = global::SmartMES_Giroei.Properties.Resources.save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.buttonImage = global::SmartMES_Giroei.Properties.Resources.save;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(264, 570);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 27);
            this.btnSave.TabIndex = 32;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // P1B08_DELI_ORDER_TERM_SUB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(785, 651);
            this.Controls.Add(this.ckbResult);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.tbDeliID);
            this.Controls.Add(this.lbDeliID);
            this.Controls.Add(this.cbMethod);
            this.Controls.Add(this.tbContents);
            this.Controls.Add(this.lbContents);
            this.Controls.Add(this.tbNGCount);
            this.Controls.Add(this.lbNGCount);
            this.Controls.Add(this.tbSampleCount);
            this.Controls.Add(this.lbSampleCount);
            this.Controls.Add(this.tbQty);
            this.Controls.Add(this.lbQty);
            this.Controls.Add(this.lbMethod);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbProdName);
            this.Controls.Add(this.tbCust);
            this.Controls.Add(this.tbRorderNo);
            this.Controls.Add(this.lbProdName);
            this.Controls.Add(this.lbCust);
            this.Controls.Add(this.lbRorderNo);
            this.Controls.Add(this.panTitle);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "P1B08_DELI_ORDER_TERM_SUB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Smart Factory MES";
            this.Load += new System.EventHandler(this.P1B08_DELI_ORDER_TERM_SUB_Load);
            this.panTitle.ResumeLayout(false);
            this.panTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panTitle;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lbRorderNo;
        private System.Windows.Forms.Label lbCust;
        private System.Windows.Forms.Label lbProdName;
        private System.Windows.Forms.TextBox tbRorderNo;
        private System.Windows.Forms.TextBox tbCust;
        private System.Windows.Forms.TextBox tbProdName;
        private UserButtonA btnClose;
        private UserButtonA btnSave;
        private System.Windows.Forms.Label lbMethod;
        private System.Windows.Forms.TextBox tbQty;
        private System.Windows.Forms.Label lbQty;
        private System.Windows.Forms.TextBox tbSampleCount;
        private System.Windows.Forms.Label lbSampleCount;
        private System.Windows.Forms.TextBox tbNGCount;
        private System.Windows.Forms.Label lbNGCount;
        private System.Windows.Forms.Label lbContents;
        private System.Windows.Forms.TextBox tbContents;
        private System.Windows.Forms.ComboBox cbMethod;
        private System.Windows.Forms.TextBox tbDeliID;
        private System.Windows.Forms.Label lbDeliID;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.CheckBox ckbResult;
    }
}