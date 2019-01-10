using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace LHRLA.LHRLA.Core.ApplicationHelper
{
    public class vt_Common
    {

        //public static string ConnectionString
        //{
        //    get
        //    {
        //        if (ConfigurationManager.ConnectionStrings["Constr"] == null)
        //        {
        //            return null;
        //        }
        //        string myCon = ConfigurationManager.ConnectionStrings["Constr"].ToString();
        //        return myCon;
        //    }
        //}

        public string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }



        #region Conversion methods
        public static int CheckInt(object value)
        {
            int parseVal;
            return ((value == null) || (value == DBNull.Value)) ? 0 : int.TryParse(value.ToString(), out parseVal) ? parseVal : 0;
        }

        public static int? CheckIntNullable(object value)
        {
            int parseVal;
            return ((value == null) || (value == DBNull.Value)) ? null : int.TryParse(value.ToString(), out parseVal) ? parseVal : (int?)null;
        }

        public static string CheckString(object value)
        {
            return ((value == null) || (value == DBNull.Value)) ? GetDefaultString() : value.ToString();
        }

        public static DateTime CheckDateTime(object value)
        {
            DateTime parseVal;
            return ((value == null) || (value == DBNull.Value)) ? GetDefaultDate() : DateTime.TryParse(value.ToString(), out parseVal) ? parseVal : GetDefaultDate();
        }

        public static DateTime? CheckDateTimeNullable(object value)
        {
            DateTime parseVal;
            return ((value == null) || (value == DBNull.Value)) ? null : DateTime.TryParse(value.ToString(), out parseVal) ? parseVal : (DateTime?)null;
        }

        public static bool CheckBoolean(object value)
        {
            bool parseVal;
            return ((value == null) || (value == DBNull.Value)) ? GetDefaultBoolean() : bool.TryParse(value.ToString(), out parseVal) ? parseVal : GetDefaultBoolean();
        }

        public static bool? CheckBooleanNullable(object value)
        {
            bool parseVal;
            return ((value == null) || (value == DBNull.Value)) ? (bool?)null : bool.TryParse(value.ToString(), out parseVal) ? parseVal : GetDefaultBoolean();
        }

        public static DateTime GetDefaultDate()
        {
            return new DateTime(1900, 1, 1);
        }
        public static bool GetDefaultBoolean()
        {
            return false;
        }
        public static string GetDefaultString()
        {
            return string.Empty;
        }
        public static double CheckDouble(object value)
        {
            double parseVal;
            return ((value == null) || (value == DBNull.Value)) ? 0 : double.TryParse(value.ToString(), out parseVal) ? parseVal : 0;
        }

        public static decimal CheckDecimal(object value)
        {
            decimal parseVal;
            return ((value == null) || (value == DBNull.Value)) ? 0 : decimal.TryParse(value.ToString(), out parseVal) ? parseVal : 0;
        }

        #endregion

    }
}