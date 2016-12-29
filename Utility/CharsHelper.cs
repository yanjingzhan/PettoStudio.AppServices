using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    public class CharsHelper
    {
        public static string ConvertToPinYin(string str)
        {
            string PYstr = string.Empty;
            foreach (char item in str.ToCharArray())
            {
                if (Microsoft.International.Converters.PinYinConverter.ChineseChar.IsValidChar(item))
                {
                    Microsoft.International.Converters.PinYinConverter.ChineseChar cc = new Microsoft.International.Converters.PinYinConverter.ChineseChar(item);

                    //PYstr += string.Join("", cc.Pinyins.ToArray());
                    PYstr += cc.Pinyins[0].Substring(0, cc.Pinyins[0].Length - 1);
                    //PYstr += cc.Pinyins[0].Substring(0, cc.Pinyins[0].Length - 1).Substring(0, 1).ToLower();
                }
                else
                {
                    PYstr += item.ToString();
                }
            }
            return PYstr.Trim();
        }
    }
}
