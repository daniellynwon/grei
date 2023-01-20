using System;
using System.Windows.Forms;

namespace SmartMES_Giroei
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            G.UserID = "admin";
            G.Pos = "A";
            G.ComName = "지로이아이";
            G.PosName = "지로이아이";
            G.UserName = "admin";
            G.Authority = "A";
            //Application.Run(new MDIForm());

            using (var form = new FormLogin())
            {
                if (form.ShowDialog() == DialogResult.OK)
                    Application.Run(new MDIForm());
            }
        }
    }
}
