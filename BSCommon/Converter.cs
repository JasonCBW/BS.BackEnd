using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
