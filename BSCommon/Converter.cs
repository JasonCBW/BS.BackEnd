using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace BS.Common
{
    public static class Converter
    {
        /// <summary>
        /// 字符串转ID数组
        /// </summary>
        /// <param name="arry">字符串</param>
        /// <returns>int数组</returns>
        public static int[] StringToIntArry(string arry)
        {
            string[] strArray = arry.Split(',');
            int[] intArray;
            intArray = Array.ConvertAll<string, int>(strArray, s => int.Parse(s));
            return intArray;
        }

        /// <summary>
        /// 字符串转Json格式
        /// </summary>
        /// <param name="str">需要转换的实体字符串对象</param>
        /// <returns>Json数据格式</returns>
        public static HttpResponseMessage StringToJson(string str)
        {
            HttpResponseMessage result = null;

            if (!string.IsNullOrEmpty(str))
            {
                result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            }
            return result;
        }
    }
}
