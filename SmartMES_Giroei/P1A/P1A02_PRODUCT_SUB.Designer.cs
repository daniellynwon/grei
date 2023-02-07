namespace SmartMES_Giroei
{
    partial class P1A02_PRODUCT_SUB
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
            this.cbGubun = new System.Windows.Forms.ComboBox();
            this.tbProdName = new System.Windows.Forms.TextBox();
            this.lbKind = new System.Windows.Forms.Label();
            this.lbProdCode = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.ckbUseFlag = new System.Windows.Forms.CheckBox();
            this.tbQty = new System.Windows.Forms.TextBox();
            this.lbSize = new System.Windows.Forms.Label();
            this.lbQty = new System.Windows.Forms.Label();
            this.lbProdName = new System.Windows.Forms.Label();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.cbKind = new System.Windows.Forms.ComboBox();
            this.lbGubun = new System.Windows.Forms.Label();
            this.tbProdCode = new System.Windows.Forms.TextBox();
            this.lbUnit = new System.Windows.Forms.Label();
            this.lbCertification = new System.Windows.Forms.Label();
            this.tbDanga = new System.Windows.Forms.TextBox();
            this.lbDanga = new System.Windows.Forms.Label();
            this.tbCertification = new System.Windows.Forms.TextBox();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.ckbConsigned = new System.Windows.Forms.CheckBox();
            this.panTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbQty4Array = new System.Windows.Forms.TextBox();
            this.tbMetalMasks = new System.Windows.Forms.TextBox();
            this.tbMountPins = new System.Windows.Forms.TextBox();
            this.lbMountPins = new System.Windows.Forms.Label();
            this.tbDIPPins = new System.Windows.Forms.TextBox();
            this.tbSMDPins = new System.Windows.Forms.TextBox();
            this.lbQty4Array = new System.Windows.Forms.Label();
            this.lbLayers = new System.Windows.Forms.Label();
            this.lbDIPPins = new System.Windows.Forms.Label();
            this.tbLayers = new System.Windows.Forms.TextBox();
            this.lbMetalMasks = new System.Windows.Forms.Label();
            this.lbSMDPins = new System.Windows.Forms.Label();
            this.btnClose = new SmartMES_Giroei.UserButtonA();
            this.btnSave = new SmartMES_Giroei.UserButtonA();
            this.panTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbGubun
            // 
            this.cbGubun.BackColor = System.Drawing.SystemColors.Window;
            this.cbGubun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGubun.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.cbGubun.FormattingEnabled = true;
            this.cbGubun.Items.AddRange(new object[] {
            "제품",
            "원자재",
            "부자재"});
            this.cbGubun.Location = new System.Drawing.Point(135, 117);
            this.cbGubun.Name = "cbGubun";
            this.cbGubun.Size = new System.Drawing.Size(200, 29);
            this.cbGubun.TabIndex = 1;
            this.cbGubun.SelectedIndexChanged += new System.EventHandler(this.cbGubun_SelectedIndexChanged);
            this.cbGubun.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextFocus_KeyDown);
            // 
            // tbProdName
            // 
            this.tbProdName.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbProdName.Location = new System.Drawing.Point(488, 187);
            this.tbProdName.Name = "tbProdName";
            this.tbProdName.Size = new System.Drawing.Size(200, 29);
            this.tbProdName.TabIndex = 4;
            this.tbProdName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbProdName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextFocus_KeyDown);
            // 
            // lbKind
            // 
            this.lbKind.AutoSize = true;
            this.lbKind.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbKind.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbKind.Location = new System.Drawing.Point(408, 120);
            this.lbKind.Name = "lbKind";
            this.lbKind.Size = new System.Drawing.Size(74, 21);
            this.lbKind.TabIndex = 0;
            this.lbKind.Text = "품목분류";
            // 
            // lbProdCode
            // 
            this.lbProdCode.AutoSize = true;
            this.lbProdCode.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbProdCode.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbProdCode.Location = new System.Drawing.Point(55, 190);
            this.lbProdCode.Name = "lbProdCode";
            this.lbProdCode.Size = new System.Drawing.Size(74, 21);
            this.lbProdCode.TabIndex = 0;
            this.lbProdCode.Text = "품목코드";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(55, 72);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(148, 21);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "메시지 라벨입니다.";
            // 
            // ckbUseFlag
            // 
            this.ckbUseFlag.AutoSize = true;
            this.ckbUseFlag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ckbUseFlag.Location = new System.Drawing.Point(960, 190);
            this.ckbUseFlag.Name = "ckbUseFlag";
            this.ckbUseFlag.Size = new System.Drawing.Size(115, 25);
            this.ckbUseFlag.TabIndex = 10;
            this.ckbUseFlag.Text = "미사용 코드";
            this.ckbUseFlag.UseVisualStyleBackColor = true;
            // 
            // tbQty
            // 
            this.tbQty.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbQty.Location = new System.Drawing.Point(875, 260);
            this.tbQty.Name = "tbQty";
            this.tbQty.Size = new System.Drawing.Size(200, 29);
            this.tbQty.TabIndex = 7;
            this.tbQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbQty.TextChanged += new System.EventHandler(this.tbQty_TextChanged);
            this.tbQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextFocus_KeyDown);
            this.tbQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumber_KeyPress);
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbSize.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbSize.Location = new System.Drawing.Point(81, 260);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(48, 21);
            this.lbSize.TabIndex = 0;
            this.lbSize.Text = "규 격";
            // 
            // lbQty
            // 
            this.lbQty.AutoSize = true;
            this.lbQty.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbQty.Location = new System.Drawing.Point(779, 250);
            this.lbQty.Name = "lbQty";
            this.lbQty.Size = new System.Drawing.Size(90, 42);
            this.lbQty.TabIndex = 0;
            this.lbQty.Text = "포장단위내\r\n수량";
            this.lbQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbProdName
            // 
            this.lbProdName.AutoSize = true;
            this.lbProdName.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbProdName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbProdName.Location = new System.Drawing.Point(424, 190);
            this.lbProdName.Name = "lbProdName";
            this.lbProdName.Size = new System.Drawing.Size(58, 21);
            this.lbProdName.TabIndex = 0;
            this.lbProdName.Text = "품목명";
            // 
            // tbSize
            // 
            this.tbSize.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbSize.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbSize.Location = new System.Drawing.Point(135, 257);
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(200, 29);
            this.tbSize.TabIndex = 5;
            this.tbSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextFocus_KeyDown);
            // 
            // cbKind
            // 
            this.cbKind.BackColor = System.Drawing.SystemColors.Window;
            this.cbKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKind.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.cbKind.FormattingEnabled = true;
            this.cbKind.Location = new System.Drawing.Point(488, 117);
            this.cbKind.Name = "cbKind";
            this.cbKind.Size = new System.Drawing.Size(200, 29);
            this.cbKind.TabIndex = 2;
            this.cbKind.SelectedIndexChanged += new System.EventHandler(this.cbKind_SelectedIndexChanged);
            this.cbKind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextFocus_KeyDown);
            // 
            // lbGubun
            // 
            this.lbGubun.AutoSize = true;
            this.lbGubun.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbGubun.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbGubun.Location = new System.Drawing.Point(81, 120);
            this.lbGubun.Name = "lbGubun";
            this.lbGubun.Size = new System.Drawing.Size(48, 21);
            this.lbGubun.TabIndex = 18;
            this.lbGubun.Text = "분 류";
            // 
            // tbProdCode
            // 
            this.tbProdCode.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbProdCode.Location = new System.Drawing.Point(135, 187);
            this.tbProdCode.Name = "tbProdCode";
            this.tbProdCode.ReadOnly = true;
            this.tbProdCode.Size = new System.Drawing.Size(200, 29);
            this.tbProdCode.TabIndex = 3;
            this.tbProdCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbUnit
            // 
            this.lbUnit.AutoSize = true;
            this.lbUnit.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbUnit.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbUnit.Location = new System.Drawing.Point(408, 260);
            this.lbUnit.Name = "lbUnit";
            this.lbUnit.Size = new System.Drawing.Size(74, 21);
            this.lbUnit.TabIndex = 17;
            this.lbUnit.Text = "포장단위";
            // 
            // lbCertification
            // 
            this.lbCertification.AutoSize = true;
            this.lbCertification.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbCertification.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbCertification.Location = new System.Drawing.Point(434, 330);
            this.lbCertification.Name = "lbCertification";
            this.lbCertification.Size = new System.Drawing.Size(48, 21);
            this.lbCertification.TabIndex = 23;
            this.lbCertification.Text = "인 증";
            // 
            // tbDanga
            // 
            this.tbDanga.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbDanga.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbDanga.Location = new System.Drawing.Point(135, 327);
            this.tbDanga.Name = "tbDanga";
            this.tbDanga.Size = new System.Drawing.Size(200, 29);
            this.tbDanga.TabIndex = 8;
            this.tbDanga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDanga.TextChanged += new System.EventHandler(this.tbDanga_TextChanged);
            this.tbDanga.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumber_KeyPress);
            // 
            // lbDanga
            // 
            this.lbDanga.AutoSize = true;
            this.lbDanga.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbDanga.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbDanga.Location = new System.Drawing.Point(81, 330);
            this.lbDanga.Name = "lbDanga";
            this.lbDanga.Size = new System.Drawing.Size(48, 21);
            this.lbDanga.TabIndex = 20;
            this.lbDanga.Text = "단 가";
            // 
            // tbCertification
            // 
            this.tbCertification.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbCertification.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbCertification.Location = new System.Drawing.Point(488, 327);
            this.tbCertification.Name = "tbCertification";
            this.tbCertification.Size = new System.Drawing.Size(200, 29);
            this.tbCertification.TabIndex = 9;
            this.tbCertification.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbUnit
            // 
            this.cbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Items.AddRange(new object[] {
            "Reel",
            "Tray"});
            this.cbUnit.Location = new System.Drawing.Point(488, 257);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(200, 29);
            this.cbUnit.TabIndex = 6;
            // 
            // ckbConsigned
            // 
            this.ckbConsigned.AutoSize = true;
            this.ckbConsigned.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ckbConsigned.Location = new System.Drawing.Point(786, 190);
            this.ckbConsigned.Name = "ckbConsigned";
            this.ckbConsigned.Size = new System.Drawing.Size(93, 25);
            this.ckbConsigned.TabIndex = 24;
            this.ckbConsigned.Text = "사급여부";
            this.ckbConsigned.UseVisualStyleBackColor = true;
            // 
            // panTitle
            // 
            this.panTitle.BackgroundImage = global::SmartMES_Giroei.Properties.Resources.photo_background;
            this.panTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panTitle.Controls.Add(this.lblTitle);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.Location = new System.Drawing.Point(0, 0);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(1194, 54);
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
            this.lblTitle.Text = "품목정보";
            // 
            // tbQty4Array
            // 
            this.tbQty4Array.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbQty4Array.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbQty4Array.Location = new System.Drawing.Point(875, 467);
            this.tbQty4Array.Name = "tbQty4Array";
            this.tbQty4Array.ReadOnly = true;
            this.tbQty4Array.Size = new System.Drawing.Size(200, 29);
            this.tbQty4Array.TabIndex = 50;
            this.tbQty4Array.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbQty4Array.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumber_KeyPress);
            // 
            // tbMetalMasks
            // 
            this.tbMetalMasks.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbMetalMasks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbMetalMasks.Location = new System.Drawing.Point(488, 467);
            this.tbMetalMasks.Name = "tbMetalMasks";
            this.tbMetalMasks.ReadOnly = true;
            this.tbMetalMasks.Size = new System.Drawing.Size(200, 29);
            this.tbMetalMasks.TabIndex = 49;
            this.tbMetalMasks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbMetalMasks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumber_KeyPress);
            // 
            // tbMountPins
            // 
            this.tbMountPins.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbMountPins.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbMountPins.Location = new System.Drawing.Point(135, 467);
            this.tbMountPins.Name = "tbMountPins";
            this.tbMountPins.ReadOnly = true;
            this.tbMountPins.Size = new System.Drawing.Size(200, 29);
            this.tbMountPins.TabIndex = 48;
            this.tbMountPins.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbMountPins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumber_KeyPress);
            // 
            // lbMountPins
            // 
            this.lbMountPins.AutoSize = true;
            this.lbMountPins.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbMountPins.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbMountPins.Location = new System.Drawing.Point(55, 470);
            this.lbMountPins.Name = "lbMountPins";
            this.lbMountPins.Size = new System.Drawing.Size(74, 21);
            this.lbMountPins.TabIndex = 39;
            this.lbMountPins.Text = "적용점수";
            // 
            // tbDIPPins
            // 
            this.tbDIPPins.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbDIPPins.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbDIPPins.Location = new System.Drawing.Point(875, 397);
            this.tbDIPPins.Name = "tbDIPPins";
            this.tbDIPPins.ReadOnly = true;
            this.tbDIPPins.Size = new System.Drawing.Size(200, 29);
            this.tbDIPPins.TabIndex = 47;
            this.tbDIPPins.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDIPPins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumber_KeyPress);
            // 
            // tbSMDPins
            // 
            this.tbSMDPins.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbSMDPins.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbSMDPins.Location = new System.Drawing.Point(488, 397);
            this.tbSMDPins.Name = "tbSMDPins";
            this.tbSMDPins.ReadOnly = true;
            this.tbSMDPins.Size = new System.Drawing.Size(200, 29);
            this.tbSMDPins.TabIndex = 46;
            this.tbSMDPins.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbSMDPins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumber_KeyPress);
            // 
            // lbQty4Array
            // 
            this.lbQty4Array.AutoSize = true;
            this.lbQty4Array.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbQty4Array.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbQty4Array.Location = new System.Drawing.Point(770, 460);
            this.lbQty4Array.Name = "lbQty4Array";
            this.lbQty4Array.Size = new System.Drawing.Size(99, 42);
            this.lbQty4Array.TabIndex = 40;
            this.lbQty4Array.Text = "PCB Array당\r\n보드 수";
            this.lbQty4Array.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbLayers
            // 
            this.lbLayers.AutoSize = true;
            this.lbLayers.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbLayers.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbLayers.Location = new System.Drawing.Point(53, 400);
            this.lbLayers.Name = "lbLayers";
            this.lbLayers.Size = new System.Drawing.Size(76, 21);
            this.lbLayers.TabIndex = 41;
            this.lbLayers.Text = "PCB 층수";
            // 
            // lbDIPPins
            // 
            this.lbDIPPins.AutoSize = true;
            this.lbDIPPins.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbDIPPins.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbDIPPins.Location = new System.Drawing.Point(782, 400);
            this.lbDIPPins.Name = "lbDIPPins";
            this.lbDIPPins.Size = new System.Drawing.Size(87, 21);
            this.lbDIPPins.TabIndex = 42;
            this.lbDIPPins.Text = "DIP PIN 수";
            // 
            // tbLayers
            // 
            this.tbLayers.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tbLayers.Location = new System.Drawing.Point(135, 397);
            this.tbLayers.Name = "tbLayers";
            this.tbLayers.ReadOnly = true;
            this.tbLayers.Size = new System.Drawing.Size(200, 29);
            this.tbLayers.TabIndex = 43;
            this.tbLayers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbLayers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumber_KeyPress);
            // 
            // lbMetalMasks
            // 
            this.lbMetalMasks.AutoSize = true;
            this.lbMetalMasks.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbMetalMasks.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbMetalMasks.Location = new System.Drawing.Point(358, 470);
            this.lbMetalMasks.Name = "lbMetalMasks";
            this.lbMetalMasks.Size = new System.Drawing.Size(124, 21);
            this.lbMetalMasks.TabIndex = 44;
            this.lbMetalMasks.Text = "Metal MASK 수";
            // 
            // lbSMDPins
            // 
            this.lbSMDPins.AutoSize = true;
            this.lbSMDPins.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lbSMDPins.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbSMDPins.Location = new System.Drawing.Point(384, 400);
            this.lbSMDPins.Name = "lbSMDPins";
            this.lbSMDPins.Size = new System.Drawing.Size(98, 21);
            this.lbSMDPins.TabIndex = 45;
            this.lbSMDPins.Text = "SMD PIN 수";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::SmartMES_Giroei.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.buttonImage = global::SmartMES_Giroei.Properties.Resources.close;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(588, 547);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 27);
            this.btnClose.TabIndex = 13;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImage = global::SmartMES_Giroei.Properties.Resources.save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.buttonImage = global::SmartMES_Giroei.Properties.Resources.save;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(374, 547);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 27);
            this.btnSave.TabIndex = 12;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // P1A02_PRODUCT_SUB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1194, 594);
            this.Controls.Add(this.tbQty4Array);
            this.Controls.Add(this.tbMetalMasks);
            this.Controls.Add(this.tbMountPins);
            this.Controls.Add(this.lbMountPins);
            this.Controls.Add(this.tbDIPPins);
            this.Controls.Add(this.tbSMDPins);
            this.Controls.Add(this.lbQty4Array);
            this.Controls.Add(this.lbLayers);
            this.Controls.Add(this.lbDIPPins);
            this.Controls.Add(this.tbLayers);
            this.Controls.Add(this.lbMetalMasks);
            this.Controls.Add(this.lbSMDPins);
            this.Controls.Add(this.ckbConsigned);
            this.Controls.Add(this.cbUnit);
            this.Controls.Add(this.lbCertification);
            this.Controls.Add(this.tbDanga);
            this.Controls.Add(this.lbDanga);
            this.Controls.Add(this.tbCertification);
            this.Controls.Add(this.lbGubun);
            this.Controls.Add(this.tbProdCode);
            this.Controls.Add(this.cbKind);
            this.Controls.Add(this.lbUnit);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.lbProdName);
            this.Controls.Add(this.tbQty);
            this.Controls.Add(this.lbSize);
            this.Controls.Add(this.lbQty);
            this.Controls.Add(this.ckbUseFlag);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbGubun);
            this.Controls.Add(this.tbProdName);
            this.Controls.Add(this.lbKind);
            this.Controls.Add(this.lbProdCode);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.panTitle);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "P1A02_PRODUCT_SUB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Smart Factory MES";
            this.Load += new System.EventHandler(this.P1A02_PRODUCT_SUB_Load);
            this.panTitle.ResumeLayout(false);
            this.panTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panTitle;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cbGubun;
        private System.Windows.Forms.TextBox tbProdName;
        private System.Windows.Forms.Label lbKind;
        private System.Windows.Forms.Label lbProdCode;
        private UserButtonA btnSave;
        private UserButtonA btnClose;
        private System.Windows.Forms.CheckBox ckbUseFlag;
        private System.Windows.Forms.TextBox tbQty;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.Label lbQty;
        private System.Windows.Forms.Label lbProdName;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.ComboBox cbKind;
        private System.Windows.Forms.Label lbGubun;
        private System.Windows.Forms.TextBox tbProdCode;
        private System.Windows.Forms.Label lbUnit;
        private System.Windows.Forms.Label lbCertification;
        private System.Windows.Forms.TextBox tbDanga;
        private System.Windows.Forms.Label lbDanga;
        private System.Windows.Forms.TextBox tbCertification;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.CheckBox ckbConsigned;
        public System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.TextBox tbQty4Array;
        private System.Windows.Forms.TextBox tbMetalMasks;
        private System.Windows.Forms.TextBox tbMountPins;
        private System.Windows.Forms.Label lbMountPins;
        private System.Windows.Forms.TextBox tbDIPPins;
        private System.Windows.Forms.TextBox tbSMDPins;
        private System.Windows.Forms.Label lbQty4Array;
        private System.Windows.Forms.Label lbLayers;
        private System.Windows.Forms.Label lbDIPPins;
        private System.Windows.Forms.TextBox tbLayers;
        private System.Windows.Forms.Label lbMetalMasks;
        private System.Windows.Forms.Label lbSMDPins;
    }
}