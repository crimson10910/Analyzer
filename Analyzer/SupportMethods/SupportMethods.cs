using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer.SupportMethods
{

    /// <summary>
    /// Переворачивает строку контекста
    /// </summary>
    public static class SupportMethods
    {
        /// <summary>
        /// Простой переворот строки
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Reverse(string str)
        {
            string buf = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                buf += str[i];
            }
            return buf;
        }
        /// <summary>
        /// Заменяет строку контекста на обратно-комплементарную
        /// </summary>
        /// <param name="context">ATGC</param>
        /// <returns>TACG</returns>
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

        public static int GetDiscrepancyCount(Dictionary<int, char> sequenceResult)
        {
            int count = 0;
            foreach (var item in sequenceResult)
            {
                if (item.Value == 'E')
                {
                    count++;
                    continue;
                }
            }
            return count;
        }

        public static Dictionary<int, char> PairedEndSequence(Dictionary<int, char> sequenceR1, Dictionary<int, char> sequenceR2)
        {
            Dictionary<int, char> sequenceResult = new Dictionary<int, char>();
            foreach (var r1 in sequenceR1)
            {
                foreach (var r2 in sequenceR2)
                {
                    if (r1.Value == r2.Value && r1.Key == r2.Key)
                    {
                        sequenceResult.Add(r1.Key, r1.Value);
                        continue;
                    }
                    if (r1.Value != r2.Value && r1.Key == r2.Key)
                    {
                        sequenceResult.Add(r1.Key, 'E');
                        continue;
                    }
                }
            }
            return sequenceResult;
        }
    }
}
