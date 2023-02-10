using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    public partial class P1C02_PROD_RESULT_AOI_DOC : Form
    {
        public string filename;
        public int index;
        public string sNo;

        public P1C02_PROD_RESULT_AOI_DOC()
        {
            InitializeComponent();
        }
        string image_file;           //선택한 이미지를 담기위한 지역변수를 생성합니다.

        private void P1C02_PROD_RESULT_AOI_DOC_Load(object sender, EventArgs e)
        {
            //PtbAOI.ImageLocation = image_file;

            Load_Exist_Image();

        }

        private void Load_Exist_Image()
        {
            MySqlConnection con = new MySqlConnection(G.conStr);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();

            if (!string.IsNullOrEmpty(filename))
            {
                string sql = "select file" + index.ToString() + "_name, file" + index.ToString() + " from QLT_inspection_AOI where job_no ='" + sNo + "'";

                try
                {
                    cmd.Connection = con;
                    cmd.CommandText = sql;

                    MySqlDataReader dr = cmd.ExecuteReader();

                    if (!dr.HasRows)
                    {
                        dr.Close();
                        return;
                    }

                    dr.Read();

                    lblFname.Text = dr.GetString("file" + index.ToString() + "_name");

                    Stream rawStream = dr.GetStream(1);

                    PtbAOI.Image = Image.FromStream(rawStream);

                    dr.Close(); 
                } catch (MySqlException ex)
                {
                    MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void BtnUpLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();             //이미지를 선택하기 위한 다이얼로그를 생성합니다.
            dialog.InitialDirectory = @"C:\";            //다이얼로그를 열었을때 보여줄 초기 위치를 설정합니다.
            dialog.Filter = "All Files(*.*)|*.*| JPEG 파일(*.jpg)|*.jpg|PNG 파일(*.png)|*.png";

            if (dialog.ShowDialog() == DialogResult.OK)             //다이얼로그의 결과값에 따라 처리를 해줍니다.OK : 선택한 이미지의 값을 image_file 변수에 대입합니다.
            {
                image_file = dialog.FileName;
            }
            else  //Cencel: 해당 이벤트를 종료합니다.
            {
                return;
            }
            PtbAOI.Image = Bitmap.FromFile(image_file);             //PictureBox 컨트롤에 선택한 이미지를 넣습니다.
            PtbAOI.SizeMode = PictureBoxSizeMode.Zoom;
          
            filename = image_file;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //string save_route = @"C:\GiroeiMESAOI";            //저장할 이미지의 디렉토리 경로를 문자열로 생성합니다.
            //if (!System.IO.Directory.Exists(save_route))            //지정한 경로에 실제로 디렉토리가 있는지 확인합니다.            
            //    System.IO.Directory.CreateDirectory(save_route);//경로에 디렉토리가 없다면 만들어주고 있다면 만들지 않습니다.
                                                                
            //    PtbAOI.Image.Save(save_route + "\\GiroeiAOI.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);//PictureBox의 이미지를 저장합니다.  (경로 + "\\저장이미지 이름", 이미지 포맷);
            //    MessageBox.Show("AOI 이미지 파일이 설정하신 경로로 저장되었습니다.");

            PtbAOI.Image.Dispose();
            PtbAOI.Image = null;
            this.Dispose();
        }
    }
}
