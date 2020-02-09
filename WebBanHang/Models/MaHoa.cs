using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace WebBanHang.Models
{
    public class MaHoa
    {
        public static string MD5(string chuoi)
        {
            string rs = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(chuoi);
            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);
            foreach(byte b in mang)
            {
                rs += b.ToString("X2");
            }
            return rs;
        }
    }
}