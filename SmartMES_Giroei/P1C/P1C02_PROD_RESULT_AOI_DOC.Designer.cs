
namespace SmartMES_Giroei
{
    partial class P1C02_PROD_RESULT_AOI_DOC
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
            this.BtnUpLoad = new System.Windows.Forms.Button();
            this.PtbAOI = new System.Windows.Forms.PictureBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnDBSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PtbAOI)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnUpLoad
            // 
            this.BtnUpLoad.Location = new System.Drawing.Point(23, 524);
            this.BtnUpLoad.Name = "BtnUpLoad";
            this.BtnUpLoad.Size = new System.Drawing.Size(177, 55);
            this.BtnUpLoad.TabIndex = 0;
            this.BtnUpLoad.Text = "사진 업로드";
            this.BtnUpLoad.UseVisualStyleBackColor = true;
            this.BtnUpLoad.Click += new System.EventHandler(this.BtnUpLoad_Click);
            // 
            // PtbAOI
            // 
            this.PtbAOI.Location = new System.Drawing.Point(23, 28);
            this.PtbAOI.Name = "PtbAOI";
            this.PtbAOI.Size = new System.Drawing.Size(570, 370);
            this.PtbAOI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PtbAOI.TabIndex = 1;
            this.PtbAOI.TabStop = false;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(416, 524);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(177, 55);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "사진 저장";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnDBSave
            // 
            this.BtnDBSave.Location = new System.Drawing.Point(221, 524);
            this.BtnDBSave.Name = "BtnDBSave";
            this.BtnDBSave.Size = new System.Drawing.Size(177, 55);
            this.BtnDBSave.TabIndex = 3;
            this.BtnDBSave.Text = "사진 등록";
            this.BtnDBSave.UseVisualStyleBackColor = true;
            this.BtnDBSave.Click += new System.EventHandler(this.BtnDBSave_Click);
            // 
            // P1C02_PROD_RESULT_AOI_DOC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 593);
            this.Controls.Add(this.BtnDBSave);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.PtbAOI);
            this.Controls.Add(this.BtnUpLoad);
            this.Name = "P1C02_PROD_RESULT_AOI_DOC";
            this.Text = "P1C02_PROD_RESULT_AOI_DOC";
            ((System.ComponentModel.ISupportInitialize)(this.PtbAOI)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnUpLoad;
        private System.Windows.Forms.PictureBox PtbAOI;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnDBSave;
    }
}