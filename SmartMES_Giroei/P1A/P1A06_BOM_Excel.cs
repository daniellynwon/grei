using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1A06_BOM_Excel : Form
    {
        string srcFile = @"\\Giroel(BOM).xlsx";
        public P1A06_BOM_Excel()
        {
            InitializeComponent();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            string srcFile = @"\\Giroel(BOM).xlsx";
            string destFile = string.Empty;

            saveFileDialog1.InitialDirectory = @"C:";
            saveFileDialog1.Title = "Excel 서식 저장";
            saveFileDialog1.DefaultExt = "xls";
            saveFileDialog1.Filter = "Xlsx files(*.xlsx)|*.xlsx";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbFname.Text = saveFileDialog1.FileName;
            }

            saveFileDialog1.Dispose();
        }

        private void P1A06_BOM_Excel_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            File.Copy(srcFile, tbFname.Text, true);

            MessageBox.Show("설정하신 경로로 BOM 엑셀 파일이 저장 되었습니다.");
            Close();
        }

        private void lblNotice_Click(object sender, EventArgs e)
        {

        }

        private void tbFname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}