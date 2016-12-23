using System.Security.Cryptography;
using System.Text;

namespace BS.Code
{
    /// <summary>
    /// MD5加密
    /// </summary>
    public class Md5
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">加密字符</param> 
        /// <returns></returns>
        public static string md5(string str)
        {
            MD5 algorithm = MD5.Create();
            byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(str));
            string strEncrypt = "";
            for (int i = 0; i < data.Length; i++)
            {
                strEncrypt += data[i].ToString("x2").ToUpperInvariant();
            }

            return strEncrypt;
        }
    }
}
