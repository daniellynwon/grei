using System.Configuration;

namespace SmartMES_Giroei
{
    public static class G
    {
        public static string Pos;
        public static string ComName;
        public static string PosName;

        public static string UserID;
        public static string UserName;
        public static string Authority;

        public static string conStr = ConfigurationManager.ConnectionStrings["SmartMES_Giroei.Properties.Settings.jiroei_mesConnectionString"].ConnectionString;
        // public static string conStr = "server=db.mes.innobe.co.kr;user id=jiroei;password=jiroei1234!;database=jiroei_mes;SSL Mode=None";
        
    }
}
