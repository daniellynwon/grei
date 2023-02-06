﻿namespace SmartMES_Giroei
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new SmartMES_Giroei.UserButtonA();
            this.btnSave = new SmartMES_Giroei.UserButtonA();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMan = new System.Windows.Forms.ComboBox();
            this.tbJobTimeStart = new System.Windows.Forms.TextBox();
            this.tbJobTimeFinish = new System.Windows.Forms.TextBox();
            this.tbCustName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbProdName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbInspCount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbSonap = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbnengttaem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbOverTurned = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMiSap = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbReverse = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbShort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbMiNap = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbLeadOpen = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbEtcError = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbTwisted = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbManhattan = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.rtbContents = new System.Windows.Forms.RichTextBox();
            this.btnFile1 = new System.Windows.Forms.Button();
            this.btnFile2 = new System.Windows.Forms.Button();
            this.lbFname1 = new System.Windows.Forms.Label();
            this.lbFname2 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tbTotalDefect = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.Font = new System.Drawing.Font("Malgun Gothic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(470, 27);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(156, 23);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "메시지 라벨입니다.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(319, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "점검자";
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
            this.panel1.Size = new System.Drawing.Size(740, 54);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(27, 15);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(121, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "AOI검사일보";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::SmartMES_Giroei.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.buttonImage = global::SmartMES_Giroei.Properties.Resources.close;
            this.btnClose.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(358, 592);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 27);
            this.btnClose.TabIndex = 35;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImage = global::SmartMES_Giroei.Properties.Resources.save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.buttonImage = global::SmartMES_Giroei.Properties.Resources.save;
            this.btnSave.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(189, 592);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 27);
            this.btnSave.TabIndex = 34;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(42, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 21);
            this.label6.TabIndex = 36;
            this.label6.Text = "검사시작시간";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(323, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 37;
            this.label2.Text = "검사종료시간";
            // 
            // cbMan
            // 
            this.cbMan.FormattingEnabled = true;
            this.cbMan.Location = new System.Drawing.Point(383, 70);
            this.cbMan.Name = "cbMan";
            this.cbMan.Size = new System.Drawing.Size(196, 29);
            this.cbMan.TabIndex = 40;
            // 
            // tbJobTimeStart
            // 
            this.tbJobTimeStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbJobTimeStart.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.tbJobTimeStart.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbJobTimeStart.Location = new System.Drawing.Point(153, 140);
            this.tbJobTimeStart.Name = "tbJobTimeStart";
            this.tbJobTimeStart.Size = new System.Drawing.Size(149, 29);
            this.tbJobTimeStart.TabIndex = 87;
            this.tbJobTimeStart.Tag = "";
            this.tbJobTimeStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbJobTimeFinish
            // 
            this.tbJobTimeFinish.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbJobTimeFinish.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.tbJobTimeFinish.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbJobTimeFinish.Location = new System.Drawing.Point(435, 140);
            this.tbJobTimeFinish.Name = "tbJobTimeFinish";
            this.tbJobTimeFinish.Size = new System.Drawing.Size(144, 29);
            this.tbJobTimeFinish.TabIndex = 88;
            this.tbJobTimeFinish.Tag = "";
            this.tbJobTimeFinish.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCustName
            // 
            this.tbCustName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbCustName.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.tbCustName.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbCustName.Location = new System.Drawing.Point(106, 70);
            this.tbCustName.Name = "tbCustName";
            this.tbCustName.Size = new System.Drawing.Size(196, 29);
            this.tbCustName.TabIndex = 90;
            this.tbCustName.Tag = "";
            this.tbCustName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(42, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 21);
            this.label10.TabIndex = 89;
            this.label10.Text = "회사명";
            // 
            // tbProdName
            // 
            this.tbProdName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbProdName.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.tbProdName.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbProdName.Location = new System.Drawing.Point(106, 105);
            this.tbProdName.Name = "tbProdName";
            this.tbProdName.Size = new System.Drawing.Size(196, 29);
            this.tbProdName.TabIndex = 92;
            this.tbProdName.Tag = "";
            this.tbProdName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(42, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 21);
            this.label12.TabIndex = 91;
            this.label12.Text = "모델명";
            // 
            // tbInspCount
            // 
            this.tbInspCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbInspCount.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.tbInspCount.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbInspCount.Location = new System.Drawing.Point(383, 105);
            this.tbInspCount.Name = "tbInspCount";
            this.tbInspCount.Size = new System.Drawing.Size(196, 29);
            this.tbInspCount.TabIndex = 94;
            this.tbInspCount.Tag = "";
            this.tbInspCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(308, 108);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 21);
            this.label13.TabIndex = 93;
            this.label13.Text = "검사수량";
            // 
            // tbSonap
            // 
            this.tbSonap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbSonap.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.tbSonap.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbSonap.Location = new System.Drawing.Point(90, 205);
            this.tbSonap.Name = "tbSonap";
            this.tbSonap.Size = new System.Drawing.Size(59, 29);
            this.tbSonap.TabIndex = 96;
            this.tbSonap.Tag = "";
            this.tbSonap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(43, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 21);
            this.label3.TabIndex = 95;
            this.label3.Text = "소납";
            // 
            // tbnengttaem
            // 
            this.tbnengttaem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbnengttaem.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.tbnengttaem.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbnengttaem.Location = new System.Drawing.Point(234, 205);
            this.tbnengttaem.Name = "tbnengttaem";
            this.tbnengttaem.Size = new System.Drawing.Size(59, 29);
            this.tbnengttaem.TabIndex = 98;
            this.tbnengttaem.Tag = "";
            this.tbnengttaem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(172, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 97;
            this.label4.Text = "냉땜";
            // 
            // tbOverTurned
            // 
            this.tbOverTurned.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbOverTurned.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.tbOverTurned.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbOverTurned.Location = new System.Drawing.Point(521, 205);
            this.tbOverTurned.Name = "tbOverTurned";
            this.tbOverTurned.Size = new System.Drawing.Size(59, 29);
            this.tbOverTurned.TabIndex = 102;
            this.tbOverTurned.Tag = "";
            this.tbOverTurned.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(446, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 21);
            this.label5.TabIndex = 101;
            this.label5.Text = "뒤집힘";
            // 
            // tbMiSap
            // 
            this.tbMiSap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbMiSap.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.tbMiSap.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbMiSap.Location = new System.Drawing.Point(367, 205);
            this.tbMiSap.Name = "tbMiSap";
            this.tbMiSap.Size = new System.Drawing.Size(59, 29);
            this.tbMiSap.TabIndex = 100;
            this.tbMiSap.Tag = "";
            this.tbMiSap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(309, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 21);
            this.label7.TabIndex = 99;
            this.label7.Text = "미삽";
            // 
            // tbReverse
            // 
            this.tbReverse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbReverse.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.tbReverse.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbReverse.Location = new System.Drawing.Point(521, 240);
            this.tbReverse.Name = "tbReverse";
            this.tbReverse.Size = new System.Drawing.Size(59, 29);
            this.tbReverse.TabIndex = 110;
            this.tbReverse.Tag = "";
            this.tbReverse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(462, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 21);
            this.label8.TabIndex = 109;
            this.label8.Text = "역삽";
            // 
            // tbShort
            // 
            this.tbShort.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbShort.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.tbShort.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbShort.Location = new System.Drawing.Point(367, 240);
            this.tbShort.Name = "tbShort";
            this.tbShort.Size = new System.Drawing.Size(59, 29);
            this.tbShort.TabIndex = 108;
            this.tbShort.Tag = "";
            this.tbShort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(309, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 21);
            this.label9.TabIndex = 107;
            this.label9.Text = "쇼트";
            // 
            // tbMiNap
            // 
            this.tbMiNap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbMiNap.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.tbMiNap.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbMiNap.Location = new System.Drawing.Point(234, 240);
            this.tbMiNap.Name = "tbMiNap";
            this.tbMiNap.Size = new System.Drawing.Size(59, 29);
            this.tbMiNap.TabIndex = 106;
            this.tbMiNap.Tag = "";
            this.tbMiNap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(172, 243);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 21);
            this.label11.TabIndex = 105;
            this.label11.Text = "미납";
            // 
            // tbLeadOpen
            // 
            this.tbLeadOpen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbLeadOpen.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.tbLeadOpen.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbLeadOpen.Location = new System.Drawing.Point(90, 240);
            this.tbLeadOpen.Name = "tbLeadOpen";
            this.tbLeadOpen.Size = new System.Drawing.Size(59, 29);
            this.tbLeadOpen.TabIndex = 104;
            this.tbLeadOpen.Tag = "";
            this.tbLeadOpen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(26, 243);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 21);
            this.label14.TabIndex = 103;
            this.label14.Text = "리드뜸";
            // 
            // tbEtcError
            // 
            this.tbEtcError.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbEtcError.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.tbEtcError.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbEtcError.Location = new System.Drawing.Point(367, 275);
            this.tbEtcError.Name = "tbEtcError";
            this.tbEtcError.Size = new System.Drawing.Size(59, 29);
            this.tbEtcError.TabIndex = 116;
            this.tbEtcError.Tag = "";
            this.tbEtcError.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label16.Location = new System.Drawing.Point(309, 278);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 21);
            this.label16.TabIndex = 115;
            this.label16.Text = "기타";
            // 
            // tbTwisted
            // 
            this.tbTwisted.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbTwisted.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.tbTwisted.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbTwisted.Location = new System.Drawing.Point(234, 275);
            this.tbTwisted.Name = "tbTwisted";
            this.tbTwisted.Size = new System.Drawing.Size(59, 29);
            this.tbTwisted.TabIndex = 114;
            this.tbTwisted.Tag = "";
            this.tbTwisted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label17.Location = new System.Drawing.Point(172, 278);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 21);
            this.label17.TabIndex = 113;
            this.label17.Text = "틀어짐";
            // 
            // tbManhattan
            // 
            this.tbManhattan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbManhattan.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.tbManhattan.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbManhattan.Location = new System.Drawing.Point(90, 275);
            this.tbManhattan.Name = "tbManhattan";
            this.tbManhattan.Size = new System.Drawing.Size(59, 29);
            this.tbManhattan.TabIndex = 112;
            this.tbManhattan.Tag = "";
            this.tbManhattan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label18.Location = new System.Drawing.Point(26, 278);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 21);
            this.label18.TabIndex = 111;
            this.label18.Text = "맨하탄";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(29, 349);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 21);
            this.label15.TabIndex = 117;
            this.label15.Text = "특이사항";
            // 
            // rtbContents
            // 
            this.rtbContents.Location = new System.Drawing.Point(114, 349);
            this.rtbContents.Name = "rtbContents";
            this.rtbContents.Size = new System.Drawing.Size(466, 96);
            this.rtbContents.TabIndex = 118;
            this.rtbContents.Text = "";
            // 
            // btnFile1
            // 
            this.btnFile1.Image = global::SmartMES_Giroei.Properties.Resources.clipA;
            this.btnFile1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFile1.Location = new System.Drawing.Point(114, 467);
            this.btnFile1.Name = "btnFile1";
            this.btnFile1.Size = new System.Drawing.Size(108, 46);
            this.btnFile1.TabIndex = 119;
            this.btnFile1.Text = "파일1";
            this.btnFile1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFile1.UseVisualStyleBackColor = true;
            this.btnFile1.Click += new System.EventHandler(this.btnFile1_Click);
            // 
            // btnFile2
            // 
            this.btnFile2.BackColor = System.Drawing.SystemColors.Info;
            this.btnFile2.Image = global::SmartMES_Giroei.Properties.Resources.clipA;
            this.btnFile2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFile2.Location = new System.Drawing.Point(114, 528);
            this.btnFile2.Name = "btnFile2";
            this.btnFile2.Size = new System.Drawing.Size(108, 46);
            this.btnFile2.TabIndex = 120;
            this.btnFile2.Text = "파일2";
            this.btnFile2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFile2.UseVisualStyleBackColor = false;
            this.btnFile2.Click += new System.EventHandler(this.btnFile2_Click);
            // 
            // lbFname1
            // 
            this.lbFname1.AutoSize = true;
            this.lbFname1.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbFname1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbFname1.Location = new System.Drawing.Point(228, 480);
            this.lbFname1.Name = "lbFname1";
            this.lbFname1.Size = new System.Drawing.Size(39, 21);
            this.lbFname1.TabIndex = 121;
            this.lbFname1.Text = "File:";
            // 
            // lbFname2
            // 
            this.lbFname2.AutoSize = true;
            this.lbFname2.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbFname2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbFname2.Location = new System.Drawing.Point(228, 541);
            this.lbFname2.Name = "lbFname2";
            this.lbFname2.Size = new System.Drawing.Size(39, 21);
            this.lbFname2.TabIndex = 122;
            this.lbFname2.Text = "File:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label19.Location = new System.Drawing.Point(26, 318);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(90, 21);
            this.label19.TabIndex = 123;
            this.label19.Text = "총불량수량";
            // 
            // tbTotalDefect
            // 
            this.tbTotalDefect.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbTotalDefect.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.tbTotalDefect.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbTotalDefect.Location = new System.Drawing.Point(122, 314);
            this.tbTotalDefect.Name = "tbTotalDefect";
            this.tbTotalDefect.Size = new System.Drawing.Size(149, 29);
            this.tbTotalDefect.TabIndex = 124;
            this.tbTotalDefect.Tag = "";
            this.tbTotalDefect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // P1C02_PROD_RESULT_AOI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(629, 639);
            this.Controls.Add(this.tbTotalDefect);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lbFname2);
            this.Controls.Add(this.lbFname1);
            this.Controls.Add(this.btnFile2);
            this.Controls.Add(this.btnFile1);
            this.Controls.Add(this.rtbContents);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbEtcError);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tbTwisted);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tbManhattan);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.tbReverse);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbShort);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbMiNap);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbLeadOpen);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tbOverTurned);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbMiSap);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbnengttaem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSonap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbInspCount);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbProdName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbCustName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbJobTimeFinish);
            this.Controls.Add(this.tbJobTimeStart);
            this.Controls.Add(this.cbMan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
        private System.Windows.Forms.Label label1;
        private UserButtonA btnClose;
        private UserButtonA btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbMan;
        public System.Windows.Forms.TextBox tbJobTimeStart;
        public System.Windows.Forms.TextBox tbJobTimeFinish;
        public System.Windows.Forms.TextBox tbCustName;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox tbProdName;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox tbInspCount;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox tbSonap;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tbnengttaem;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tbOverTurned;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox tbMiSap;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox tbReverse;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox tbShort;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox tbMiNap;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox tbLeadOpen;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox tbEtcError;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox tbTwisted;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox tbManhattan;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RichTextBox rtbContents;
        private System.Windows.Forms.Button btnFile1;
        private System.Windows.Forms.Button btnFile2;
        private System.Windows.Forms.Label lbFname1;
        private System.Windows.Forms.Label lbFname2;
        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.TextBox tbTotalDefect;
    }
}