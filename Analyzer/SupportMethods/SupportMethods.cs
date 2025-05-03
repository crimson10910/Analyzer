using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer.SupportMethods
{
    public static class SupportMethods
    {
        public static string Reverse(string str)
        {
            string buf = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                buf += str[i];
            }
            return buf;
        }
        public static  string ReverseContextString(string context)
        {
            string result = string.Empty;
            for (int i = 0; i < context.Length; i++)
            {
                if (context[i] == 'A')
                {
                    result += 'T';
                    continue;
                }
                if (context[i] == 'T')
                {
                    result += 'A';
                    continue;
                }
                if (context[i] == 'G')
                {
                    result += 'C';
                    continue;
                }
                if (context[i] == 'C')
                {
                    result += 'G';
                    continue;
                }
            }
            return result;
        }
        public static string GetDateTime()    // Получить дату и время созданного файла
        {
            return DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year
                        + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
        }
    }
}
