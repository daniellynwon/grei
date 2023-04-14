namespace SmartMES_Giroei
{
    partial class P1C02_PROD_RESULT_AOI
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
            this.lblMsg = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.rtbContents = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cbWorkLine = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.doc2 = new SmartMES_Giroei.UserButtonA();
            this.doc1 = new SmartMES_Giroei.UserButtonA();
            this.btnClose = new SmartMES_Giroei.UserButtonA();
            this.btnSave = new SmartMES_Giroei.UserButtonA();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(417, 27);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(120, 17);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "메시지 라벨입니다.";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SmartMES_Giroei.Properties.Resources.photo_background;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.lblMsg);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 54);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(27, 15);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(62, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Pause";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(67, 109);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 21);
            this.label15.TabIndex = 117;
            this.label15.Text = "특이사항";
            // 
            // rtbContents
            // 
            this.rtbContents.Location = new System.Drawing.Point(147, 106);
            this.rtbContents.Name = "rtbContents";
            this.rtbContents.Size = new System.Drawing.Size(466, 96);
            this.rtbContents.TabIndex = 19;
            this.rtbContents.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(4, 234);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 21);
            this.label10.TabIndex = 132;
            this.label10.Text = "파일1";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label21.Location = new System.Drawing.Point(4, 290);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(51, 21);
            this.label21.TabIndex = 133;
            this.label21.Text = "파일2";
            // 
            // cbWorkLine
            // 
            this.cbWorkLine.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbWorkLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorkLine.FormattingEnabled = true;
            this.cbWorkLine.Location = new System.Drawing.Point(147, 63);
            this.cbWorkLine.Name = "cbWorkLine";
            this.cbWorkLine.Size = new System.Drawing.Size(203, 29);
            this.cbWorkLine.TabIndex = 135;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label22.Location = new System.Drawing.Point(66, 66);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(74, 21);
            this.label22.TabIndex = 134;
            this.label22.Text = "중지사유";
            // 
            // doc2
            // 
            this.doc2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.doc2.BackColor = System.Drawing.Color.Transparent;
            this.doc2.BackgroundImage = global::SmartMES_Giroei.Properties.Resources.clipA;
            this.doc2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.doc2.buttonImage = global::SmartMES_Giroei.Properties.Resources.clipA;
            this.doc2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.doc2.Location = new System.Drawing.Point(85, 266);
            this.doc2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.doc2.Name = "doc2";
            this.doc2.Size = new System.Drawing.Size(60, 45);
            this.doc2.TabIndex = 130;
            this.doc2.Tag = "";
            this.doc2.Click += new System.EventHandler(this.userButtonA2_Click);
            // 
            // doc1
            // 
            this.doc1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.doc1.BackColor = System.Drawing.Color.Transparent;
            this.doc1.BackgroundImage = global::SmartMES_Giroei.Properties.Resources.clipA;
            this.doc1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.doc1.buttonImage = global::SmartMES_Giroei.Properties.Resources.clipA;
            this.doc1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.doc1.Location = new System.Drawing.Point(85, 210);
            this.doc1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.doc1.Name = "doc1";
            this.doc1.Size = new System.Drawing.Size(60, 45);
            this.doc1.TabIndex = 129;
            this.doc1.Tag = "";
            this.doc1.Click += new System.EventHandler(this.userButtonA1_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::SmartMES_Giroei.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.buttonImage = global::SmartMES_Giroei.Properties.Resources.close;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(437, 342);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
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
            this.btnSave.Location = new System.Drawing.Point(268, 342);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 27);
            this.btnSave.TabIndex = 30;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // P1C02_PROD_RESULT_AOI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(742, 390);
            this.Controls.Add(this.cbWorkLine);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.doc2);
            this.Controls.Add(this.doc1);
            this.Controls.Add(this.rtbContents);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "P1C02_PROD_RESULT_AOI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Smart Factory MES";
            this.Load += new System.EventHandler(this.P1C02_PROD_RESULT_AOI_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMsg;
        private UserButtonA btnClose;
        private UserButtonA btnSave;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RichTextBox rtbContents;
        public UserButtonA doc1;
        public UserButtonA doc2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cbWorkLine;
        private System.Windows.Forms.Label label22;
    }
}