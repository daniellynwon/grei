﻿using System.Security.Cryptography;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System;

namespace SmartMES_Giroei
{
    class MyClass
    {
        public MyClass()
        {
            //
            // TODO: 여기에 생성자 논리를 추가합니다.
            //
        }

        //SHA512 암호화(패스워드)
        public string EncryptSHA512(string Data)
        {
            SHA512 sha = new SHA512Managed();
            byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(Data));
            StringBuilder stringBuilder = new StringBuilder();

            foreach (byte b in hash)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }

            return stringBuilder.ToString();
        }

        //숫자를 한글로...
        public string Number2Hangle(long lngNumber)
        {
            string[] NumberChar = new string[] { "", "일", "이", "삼", "사", "오", "육", "칠", "팔", "구" };
            string[] LevelChar = new string[] { "", "십", "백", "천" };
            string[] DecimalChar = new string[] { "", "만", "억", "조", "경" };

            string strMinus = string.Empty;

            if (lngNumber < 0)
            {
                strMinus = "마이너스";
                lngNumber *= -1;
            }

            string strValue = string.Format("{0}", lngNumber);
            string NumToKorea = string.Empty;
            bool UseDecimal = false;

            if (lngNumber == 0) return "영";

            for (int i = 0; i < strValue.Length; i++)
            {
                int Level = strValue.Length - i;
                if (strValue.Substring(i, 1) != "0")
                {
                    UseDecimal = true;
                    if (((Level - 1) % 4) == 0)
                    {
                        if (DecimalChar[(Level - 1) / 4] != string.Empty
                           && strValue.Substring(i, 1) == "1")
                            NumToKorea = NumToKorea + DecimalChar[(Level - 1) / 4];
                        else
                            NumToKorea = NumToKorea
                                              + NumberChar[int.Parse(strValue.Substring(i, 1))]
                                              + DecimalChar[(Level - 1) / 4];
                        UseDecimal = false;
                    }
                    else
                    {
                        if (strValue.Substring(i, 1) == "1")
                            NumToKorea = NumToKorea
                                               + LevelChar[(Level - 1) % 4];
                        else
                            NumToKorea = NumToKorea
                                               + NumberChar[int.Parse(strValue.Substring(i, 1))]
                                               + LevelChar[(Level - 1) % 4];
                    }
                }
                else
                {
                    if ((Level % 4 == 0) && UseDecimal)
                    {
                        NumToKorea = NumToKorea + DecimalChar[Level / 4];
                        UseDecimal = false;
                    }
                }
            }
            return strMinus + NumToKorea;
        }

        //OleDb를 이용한 엑셀파일 업로드
        public DataTable GetExcelSheet(string excelPath)
        {
            string connstring = string.Empty;

            if (excelPath.IndexOf(".xlsx") > -1)
                connstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelPath + ";Extended Properties='Excel 12.0;IMEX=1'";
            else
                connstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelPath + ";Extended Properties='Excel 8.0;IMEX=1'";

            OleDbConnection connect = new OleDbConnection(connstring);

            try
            {   
                connect.Open();
                string sQuery = @"select * from [Sheet1$]";

                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(sQuery, connect);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connect.Close();
            }
        }
    }

}