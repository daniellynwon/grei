using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1B08_DELI_ORDER_TERM_SUB : Form
    {
        public P1B08_DELI_ORDER_TERM parentWin;

        public string sRorderNo = string.Empty;
        public string sCustID = string.Empty;
        public string sCustName = string.Empty;
        public string sDeliID = string.Empty;
        public string sProdID = string.Empty;
        public string sProdName = string.Empty;
        public string sQty = string.Empty;

        public P1B08_DELI_ORDER_TERM_SUB()
        {
            InitializeComponent();
        }

        private void P1B08_DELI_ORDER_TERM_SUB_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            cbMethod.SelectedIndex = 0;
            //cbResult.SelectedIndex = 0;

            tbRorderNo.Text = sRorderNo;
            tbCust.Tag = sCustID;
            tbCust.Text = sCustName;
            tbDeliID.Text = sDeliID;
            tbProdName.Tag = sProdID;
            tbProdName.Text = sProdName;
            tbQty.Text = sQty;

            this.ActiveControl = tbSampleCount;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Save() { }
    }
}
