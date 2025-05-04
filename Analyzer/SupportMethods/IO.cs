using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Analyzer.SupportMethods.SupportMethods;

namespace Analyzer.SupportMethods
{
    public static class IO
    {
        public static void WriteToCsv(
            Dictionary<int, char> sequenceResult,
            bool toOneFile,
            bool isBigFileCreated,
            string nameFile = "",
            int position = 0,
            float a = 0,
            float t = 0,
            float g = 0,
            float c = 0,
            float result = 0,
            int countOfReads = 0,
            float reads = 0,
            string fileName2 = "",
            float aRev = 0,
            float tRev = 0,
            float gRev = 0,
            float cRev = 0,
            float resultRev = 0,
            float readsRev = 0,
            char mainChar = ' ',
            char wrongChar = ' ',
            float shortR1 = 0,
            float shortR2 = 0
           )
        {
            bool doBigFile;
            string path = Settings.Default.extractionPath;
            string name = Settings.Default.bigFile;
            countOfReads = GetDiscrepancyCount(sequenceResult);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string splitter = Settings.Default.csvSplitter;
            string sep = ".";
            if (splitter == ";")
            {
                sep = ",";
            }

            // запись в файл отчета результатов обработки файлов
            using (FileStream fstream = new FileStream(path + name, FileMode.Append))
            {
                string res = Convert.ToString(reads == 0 ? 0 : result / reads * 100).Replace(",", sep);
                string aStr = Convert.ToString((reads == 0 ? 0 : a / reads * 100)).Replace(",", sep);
                string tStr = Convert.ToString((reads == 0 ? 0 : t / reads * 100)).Replace(",", sep);
                string gStr = Convert.ToString((reads == 0 ? 0 : g / reads * 100)).Replace(",", sep     );
                string cStr = Convert.ToString((reads == 0 ? 0 : c / reads * 100)).Replace(",", sep);
                string sh = Convert.ToString((reads == 0 ? 0 : shortR1 / reads * 100)).Replace(",", sep);

                string resRev = Convert.ToString(readsRev == 0 ? 0 : resultRev / readsRev * 100).Replace(",", sep);
                string aStrRev = Convert.ToString((readsRev == 0 ? 0 : aRev / readsRev * 100)).Replace(",", sep );
                string tStrRev = Convert.ToString((readsRev == 0 ? 0 : tRev / readsRev * 100)).Replace(",", sep);
                string gStrRev = Convert.ToString((readsRev == 0 ? 0 : gRev / readsRev * 100)).Replace(",", sep);
                string cStrRev = Convert.ToString((readsRev == 0 ? 0 : cRev / readsRev * 100)).Replace(",", sep);
                string desp = Convert.ToString((countOfReads == 0 ? 0 : countOfReads / reads)).Replace(",", sep);
                string shRev = Convert.ToString((reads == 0 ? 0 : shortR1 / reads * 100)).Replace(",", sep);
                byte[] buffer = Encoding.UTF8.GetBytes(
                      nameFile.Substring(nameFile.LastIndexOf('\\') + 1) + splitter
                    + reads + splitter
                    + position + splitter
                    + aStr + splitter
                    + tStr + splitter
                    + gStr + splitter
                    + cStr + splitter
                    + res + splitter

                    + countOfReads + splitter
                    + shortR1 + splitter
                    + sh + splitter
                    + fileName2.Substring(fileName2.LastIndexOf('\\') + 1) + splitter
                    + readsRev + splitter
                    + position + splitter
                    + tStrRev + splitter        //
                    + aStrRev + splitter        //
                    + cStrRev + splitter        //  
                    + gStrRev + splitter        //
                    + resRev + splitter
                    + shortR2 + splitter
                    + shRev + splitter
                    + desp + splitter
                    + countOfReads + splitter
                    + '\n');
                fstream.Write(buffer, 0, buffer.Length);
            }
        }
        public static void PreCreateCsv(string fullname, char mainChar, char wrongChar)
        {
            string a = "A_freq";
            string t = "T_freq";
            string g = "G_freq";
            string c = "C_freq";

            string aR = "A_freq";
            string tR = "T_freq";
            string gR = "G_freq";
            string cR = "C_freq";
            string splitter = Settings.Default.csvSplitter;
            switch (mainChar)
            {
                case 'A':
                    a += " (ref)";
                    aR += " (ref)";
                    break;
                case 'T':
                    t += " (ref)";
                    tR += " (ref)";
                    break;
                case 'G':
                    g += " (ref)";
                    gR += " (ref)";
                    break;
                case 'C':
                    c += " (ref)";
                    cR += " (ref)";
                    break;
                default:
                    break;
            }
            switch (wrongChar)
            {
                case 'A':
                    a += " (mut)";
                    aR += " (mut)";
                    break;
                case 'T':
                    t += " (mut)";
                    tR += " (mut)";
                    break;
                case 'G':
                    g += " (mut)";
                    gR += " (mut)";
                    break;
                case 'C':
                    c += " (mut)";
                    cR += " (mut)";
                    break;
                default:
                    break;
            }

            File.Create(fullname).Close();
            using (FileStream fstream = new FileStream(fullname, FileMode.Create))
            {
                //byte[] buffer1 = Encoding.Default.GetBytes("Name" + splitter + "Position"+ splitter + "Result(mut/(normal+mut))"+ splitter + "Mutations"+ splitter + "Normal"+ splitter + "Other"+ splitter + "Errors"+ splitter + "\n");
                byte[] buffer1 = Encoding.Default.GetBytes(
                    "Name" + splitter
                    + "Reads" + splitter
                    + "Position" + splitter
                    + a + splitter
                    + t + splitter
                    + g + splitter
                    + c + splitter
                    + "Invalid_seq, %" + splitter
                     + "Invalid_seq" + splitter
                     + "Short" + splitter
                     + "Short %" + splitter
                    + "Name" + splitter
                    + "Reads" + splitter
                    + "Position" + splitter
                    + aR + splitter
                    + tR + splitter
                    + gR + splitter
                    + cR + splitter
                    + "Invalid_seq, %" + splitter
                    + "Short" + splitter
                     + "Short %" + splitter
                    + "Discrepancy" + splitter
                    + "Discrepancy, %" + splitter
                    + "\n");

                fstream.Write(buffer1, 0, buffer1.Length);
                buffer1 = null;
                fstream.Close();
            }
            
        }
        public static bool WriteToOne(int countOfFiles, char mainChar, char wrongChar)
        {
            string name = "";
            string path = Settings.Default.extractionPath;
            name = GetDateTime()
                + "_(" + countOfFiles.ToString() + "_files)" + ".csv";
            Settings.Default.bigFile = name;
            PreCreateCsv(path + name, mainChar, wrongChar);
            return true;

        }
    }
}
