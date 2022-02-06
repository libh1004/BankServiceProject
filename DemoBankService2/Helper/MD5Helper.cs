using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DemoBankService2.Helper
{
    public class MD5Helper
    {
        public string PasswordHash(string password, string salt)
        {
            //MD5 md5 = new MD5CryptoServiceProvider();
            //// bam password 
            //byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            //// lay ra ket qua vua bam de dung
            //var result = md5.Hash;
            //// dung chuoi ky tu co the thay doi duoc
            //StringBuilder strBuilder = new StringBuilder();
            //// dung vong lap de bien password vua bam thanh he thap luc phan.
            //for(int i = 0;i < result.Length; i++)
            //{
            //    strBuilder.Append(result[i].ToString("x2"));
            //}
            //return strBuilder.ToString();

            var passwordString = password + salt;
            var stringPasswordHash = new StringBuilder();
            var md5 = new MD5CryptoServiceProvider();
            var bytes = md5.ComputeHash(new UTF8Encoding().GetBytes(passwordString));
            foreach (var c in bytes)
            {
                stringPasswordHash.Append(c.ToString("x2"));
            }

            return stringPasswordHash.ToString();
        }
    }
}
