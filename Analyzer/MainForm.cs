using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using static Analyzer.SupportMethods.SupportMethods;
using static Analyzer.SupportMethods.IO;
using System.IO;
using System.Xml.Linq;
namespace Analyzer
{
    public partial class MainForm : Form
    {
        private static string PGORSESS_TEXT = "������� ";
        public MainForm()
        {
            InitializeComponent();

            comboBoxMain.SelectedIndex = Settings.Default.selectedMain;
            comboBoxWrong.SelectedIndex = Settings.Default.selectedWrong;
            checkBoxWriteLogs.Checked = Settings.Default.writeLogs;
            checkBoxPairedEnd.Checked = Settings.Default.pairedEnd;
            comboBoxSplitter.SelectedIndex = Settings.Default.splitetrIndex;
            richTextBox1.Text = Settings.Default.bigText;
            numericUpDownLeft.Value = Settings.Default.shiftLeft;
            numericUpDownRight.Value = Settings.Default.shiftRight;
            position = Settings.Default.position;
            numericUpDownPosition.Value = Settings.Default.position;



        }
        string leftContext;
        string rightContext;

        string leftContextRev;
        string rightContextRev;

        float allMains = 0;
        float allMainsRev = 0;
        float mutationCounter = 0;
        float mutationCounterRev = 0;
        int errors = 0;
        int errorsRev = 0;
        int other = 0;
        int otherRev = 0;
        int allLines = 0;
        int allLinesRev = 0;
        int plus = 0;
        int plusRev = 0;
        int dog = 0;
        int dogRev = 0;
        int shiftR = 0;
        int shiftL = 0;
        float shortR1 = 0;
        float shortR2 = 0;

        float aCount = 0, tCount = 0, gCount = 0, cCount = 0;
        float aCountRev = 0, tCountRev = 0, gCountRev = 0, cCountRev = 0;


        //��������� 
        string contextA = "";
        string contextT = "";
        string contextG = "";
        string contextC = "";

        string contextARev = "";
        string contextTRev = "";
        string contextGRev = "";
        string contextCRev = "";

        int position = 0;
        char mainChar = ' ';
        char wrongChar = ' ';
        char mainCharRev = ' ';
        char wrongCharRev = ' ';

        bool isBigFileCreated = false;
        bool toOneFile = true;
        bool newLog = true;
        bool newLogSeq = true;
        bool pairedEndSeq = false;

        public const string FILENAME = "";
        private string logName = "";
        public string splitter = "";
        private bool writeLogs;

        Dictionary<int, char> sequenceR1 = new Dictionary<int, char>();
        Dictionary<int, char> sequenceR2 = new Dictionary<int, char>();
        Dictionary<int, char> sequenceResult = new Dictionary<int, char>();
        Dictionary<int, string> allReadsR1 = new Dictionary<int, string>();
        Dictionary<int, string> allReadsR2 = new Dictionary<int, string>();

        
        private string GetCountOfSequencesToString(Dictionary<int, char> sequenceResult)
        {
            int a = 0;
            int t = 0;
            int g = 0;
            int c = 0;
            int e = 0;
            string count = "";
            foreach (var item in sequenceResult)
            {
                if (item.Value == 'A')
                {
                    a++;
                    continue;
                }
                if (item.Value == 'T')
                {
                    t++;
                    continue;
                }
                if (item.Value == 'G')
                {
                    g++;
                    continue;
                }
                if (item.Value == 'C')
                {
                    c++;
                    continue;
                }
                if (item.Value == 'E')
                {
                    e++;
                    continue;
                }
            }
            count = a.ToString() + splitter + t.ToString() + splitter +  g.ToString() + splitter 
                + c.ToString() + splitter + e.ToString() + splitter;

            return count;
        }

        private void ProcessGenomeFile(string fileName = "")
        {

            string[] fileText = null;
            bool R1 = false;
            char main = ' ', wrong = ' ';
            string context = "";
            bool read = false;
            string cA = "", cT = "", cG = "", cC = "";
            string Leters = "AGCT";
            int a = 0, t = 0, g = 0, c = 0, ers = 0, dgs = 0;
            if (fileName.Contains("R1"))
            {
                R1 = true;
                main = mainChar;
                wrong = wrongChar;
                cA = contextA;
                cT = contextT;
                cG = contextG;
                cC = contextC;
            }
            if (fileName.Contains("R2"))
            {

                main = mainCharRev;
                wrong = wrongCharRev;
                cA = contextARev;
                cT = contextTRev;
                cG = contextGRev;
                cC = contextCRev;
                Leters = Reverse(Leters);

            }

            string[] fileTextR2 = null;
            fileText = System.IO.File.ReadAllLines(fileName);
            if (fileText == null)
            {
                return;
            }
            for (int i = 0; i < fileText.Count(); i++)
            {
                if (fileText[i][0] == '+' && fileText[i].Length == 1)
                {
                    plus++;
                    i++;
                    continue;
                }
                if (fileText[i][0] == '@')
                {
                    //dog++;
                    dgs++;
                    allLines++;
                    read = true;
                    continue;
                }
                if (fileText[i].Length <= position + rightContext.Length)
                {
                    if (R1)
                    {
                        shortR1++;
                    }
                    else { shortR2++; }
                    read = false;
                    continue;
                }
                if (read)
                {
                    if (pairedEndSeq && R1)
                    {
                        allReadsR1.Add(i, fileText[i]);
                    }
                    if (pairedEndSeq && !R1)
                    {
                        allReadsR2.Add(i, fileText[i]);
                    }
                    if (fileText[i].Contains(cA))
                    {
                        if (R1 && pairedEndSeq)
                        {
                            sequenceR1.Add(i, 'A');
                        }
                        if (!R1 && pairedEndSeq)
                        {
                            sequenceR2.Add(i, 'A');
                        }
                        a++;
                        read = false;
                        continue;
                    }
                    if (fileText[i].Contains(cT))
                    {
                        if (R1 && pairedEndSeq)
                        {
                            sequenceR1.Add(i, 'T');
                        }
                        if (!R1 && pairedEndSeq)
                        {
                            sequenceR2.Add(i, 'T');
                        }
                        t++;
                        read = false;
                        continue;
                    }
                    if (fileText[i].Contains(cG))
                    {
                        if (R1 && pairedEndSeq)
                        {
                            sequenceR1.Add(i, 'G');
                        }
                        if (!R1 && pairedEndSeq)
                        {
                            sequenceR2.Add(i, 'G');
                        }
                        g++;
                        read = false;
                        continue;
                    }
                    if (fileText[i].Contains(cC))
                    {
                        if (R1 && pairedEndSeq)
                        {
                            sequenceR1.Add(i, 'C');
                        }
                        if (!R1 && pairedEndSeq)
                        {
                            sequenceR2.Add(i, 'C');
                        }
                        c++;
                        read = false;
                        continue;
                    }
                    else
                    {
                        if (R1 && pairedEndSeq)
                        {
                            sequenceR1.Add(i, 'E');
                        }
                        if (!R1 && pairedEndSeq)
                        {
                            sequenceR2.Add(i, 'E');
                        }
                        ers++;
                        read = false;
                        continue;
                    }
                }
            }
            if (fileName.Contains("R1"))
            {
                aCount = a;
                tCount = t;
                gCount = g;
                cCount = c;
                errors = ers;
                dog = dgs;
            }
            if (fileName.Contains("R2"))
            {
                aCountRev = t;
                tCountRev = a;
                gCountRev = c;
                cCountRev = g;
                errorsRev = ers;
                dogRev = dgs;
            }


        }

        private void ProcessGenomeFiles( string fileNameR1, 
            string fileNameR2, int countFiles1 = 0)
        {
            aCount = 0;
            aCountRev = 0;
            tCount = 0;
            tCountRev = 0;
            gCount = 0;
            gCountRev = 0;
            cCount = 0;
            cCountRev = 0;
            shortR2 = 0;
            shortR1 = 0;
            allMains = 0;
            mutationCounter = 0;
            mutationCounterRev = 0;
            errors = 0;
            errorsRev = 0;
            other = 0;
            allLines = 0;
            plus = 0;
            dog = 0;
            dogRev = 0;
            if (fileNameR1 != null)
            {
                ProcessGenomeFile( fileNameR1);
            }
            if (fileNameR2 != null)
            {
                ProcessGenomeFile(fileNameR2);
            }
            // ������������ ���������� ����� ����������
            switch (mainChar)
            {
                case 'A':
                    allMains = aCount;
                    allMainsRev = tCountRev;
                    break;
                case 'T':
                    allMains = tCount;
                    allMainsRev = aCountRev;
                    break;
                case 'G':
                    allMains = gCount;
                    allMainsRev = cCountRev;
                    break;
                case 'C':
                    allMains = cCount;
                    allMainsRev = gCountRev;
                    break;
                default:
                    break;
            }
            switch (wrongChar)
            {
                case 'A':
                    mutationCounter = aCount;
                    mutationCounterRev = tCountRev;
                    break;
                case 'T':
                    mutationCounter = tCount;
                    mutationCounterRev = aCountRev;
                    break;
                case 'G':
                    mutationCounter = gCount;
                    mutationCounterRev = cCountRev;
                    break;
                case 'C':
                    mutationCounter = cCount;
                    mutationCounterRev = gCountRev;
                    break;
                default:
                    break;
            }


            if (pairedEndSeq)
            {
                sequenceResult = PairedEndSequence(sequenceR1, sequenceR2);
                GetCountOfSequencesToString(sequenceResult);
                if (writeLogs)
                {
                    PairedSequenceLog(fileNameR1);
                }
            }

            this.Enabled = true;
            newLog = true;
            newLogSeq = true;
            float reads = dog;
            //string resultString = CreateResultString(fileNameR1, );

            WriteToCsv(sequenceResult, toOneFile, isBigFileCreated, fileNameR1, position, aCount, tCount, gCount, cCount, errors, countFiles1, reads, 
                fileNameR2, aCountRev, tCountRev, gCountRev, cCountRev, errorsRev, dogRev, mainChar, wrongChar, shortR1, shortR2);

            sequenceR1.Clear();
            sequenceR2.Clear();
            sequenceResult.Clear();
            allReadsR1.Clear();
            allReadsR2.Clear();

        }

        private string CreateResultString(string fileNameR1 = "", string fileNameR2 = "")
        {
            string result = "";
            if (pairedEndSeq)
            {

            }
            if (!pairedEndSeq)
            {

            }
            return result;
        }

        private void OpenFiles(object sender, EventArgs e)   // ������ � ����
        {

            position = Convert.ToInt32(numericUpDownPosition.Value);
            if (position - shiftL - 1 < 0 || position + shiftR > richTextBox1.Text.Length)
            {
                MessageBox.Show("������ ������� �� ������� ���������!");
                return;
            }
            OpenFileDialog dlg = new OpenFileDialog
            {
                Multiselect = true,
                Title = "�������� �����",
                InitialDirectory = @"F:\"
            };
            dlg.ShowDialog();
            if (dlg.FileName == String.Empty)
                return;

            //��������� ���������� ����� ������� � ������
            position = (int)numericUpDownPosition.Value;
            mainChar = Convert.ToChar(comboBoxMain.Text);
            wrongChar = Convert.ToChar(comboBoxWrong.Text);
            writeLogs = Settings.Default.writeLogs;
            mainCharRev = Convert.ToChar(ReverseContextString(comboBoxMain.Text));
            wrongCharRev = Convert.ToChar(ReverseContextString(comboBoxWrong.Text));

            // ��������� ���������
            leftContext = richTextBox1.Text.Substring(position - shiftL - 1, shiftL).ToUpper();
            rightContext = richTextBox1.Text.Substring(position, shiftR).ToUpper();

            //�������� ���� ��������� ���������
            contextA = leftContext + "A" + rightContext;
            contextT = leftContext + "T" + rightContext;
            contextG = leftContext + "G" + rightContext;
            contextC = leftContext + "C" + rightContext;

            //�������� ���������� ���������
            contextARev = Reverse(ReverseContextString(contextA));
            contextTRev = Reverse(ReverseContextString(contextT));
            contextGRev = Reverse(ReverseContextString(contextG));
            contextCRev = Reverse(ReverseContextString(contextC));

            //label5.Text = leftContext + mainChar + rightContext;
            
            int countOfFiles = dlg.FileNames.Count();
            toolStripProgressBar.Maximum = countOfFiles;

            // ���������� ������ ������ � ���������� ������� 
            Array.Sort(dlg.FileNames);
            
            FILE(dlg);

            toolStripProgressBar.Value = 0;
        }

        /// <summary>
        /// ����� ��������� ���� ������
        /// </summary>
        /// <param name="dlg"></param>
        private async void FILE(OpenFileDialog dlg)
        {
            var startTime = DateTime.Now;
            string name = "";
            string path = Settings.Default.extractionPath;
            int countOfFiles = dlg.FileNames.Count();
            if (toOneFile && !isBigFileCreated)
            {
                isBigFileCreated = WriteToOne(countOfFiles, mainChar, wrongChar);
            }
            name = ""; int i = 0;
            //PreCreateCsv(dlg.FileName, mainChar, wrongChar);
            for (; i < countOfFiles; i+=2)      // ������ �� ���� ������
            {
                string fileNameR1 = dlg.FileNames[i];
                string fileNameR2 = dlg.FileNames[i + 1];
                
                toolStripProgressBar.Value = i;
                toolStripProgressBar.ToolTipText = countOfFiles.ToString();
                await Task.Delay(1);
                
                ProcessGenomeFiles(fileNameR1, fileNameR2, countOfFiles);
                //i++;
                //if (dlg.FileNames[i].Contains("R1"))
                //{
                //    fileTextR1 = System.IO.File.ReadAllLines(dlg.FileNames[i]);     // ������ ����� ���������� ����� � ����������

                //    if (countOfFiles >= i + 1)
                //    {
                //        if (dlg.FileNames[i + 1].Contains("R1"))
                //        {
                //            //ProcessGenomeFiles(fileTextR1, fileTextR2, dlg.FileNames[i], "", countOfFiles);
                //            //progrressCounter++;
                //            continue;
                //        }
                //        if (dlg.FileNames[i + 1].Contains("R2"))
                //        {
                //            fileTextR2 = System.IO.File.ReadAllLines(dlg.FileNames[i + 1]);
                //            ProcessGenomeFiles(fileTextR1, fileTextR2, dlg.FileNames[i], dlg.FileNames[i + 1]   );
                //            //progrressCounter += 2;
                //            i++;
                //            continue;
                //        }
                //    }
                //    ProcessGenomeFiles(fileTextR1, fileTextR2, dlg.FileNames[i], "", countOfFiles);
                //    continue;
                //}
                //if (dlg.FileNames[i].Contains("R2"))
                //{
                //    fileTextR2 = System.IO.File.ReadAllLines(dlg.FileNames[i]);
                //    if (countOfFiles >= i + 1)
                //    {
                //        if (dlg.FileNames[i + 1].Contains("R1"))
                //        {
                //            fileTextR1 = System.IO.File.ReadAllLines(dlg.FileNames[i + 1]);
                //            ProcessGenomeFiles(fileTextR1, fileTextR2, dlg.FileNames[i + 1], dlg.FileNames[i], countOfFiles);
                //            //progrressCounter += 2;
                //            i++;
                //            continue;
                //        }
                //        if (dlg.FileNames[i + 1].Contains("R2"))
                //        {
                //            //ProcessGenomeFiles(fileTextR1, fileTextR2, "", dlg.FileNames[i], countOfFiles);
                //            // progrressCounter++;
                //            continue;
                //        }
                //    }
                //    ProcessGenomeFiles(fileTextR1, fileTextR2, "", dlg.FileNames[i], countOfFiles);
                //    //progrressCounter++;
                //    continue;
                //} 

            }

            var endTime = DateTime.Now;
            toolStripProgressBar.Value = toolStripProgressBar.Maximum;
            MessageBox.Show($"{countOfFiles} ����(��) ������� ����������!\n{endTime - startTime}");
            toolStripProgressBar.Value = toolStripProgressBar.Minimum;
            //toolStripProgressBar.Value = 0;
            isBigFileCreated = false;

        }
        
        private void WriteToLogEnd(string filename, int dog, int plus)  // ��� ������� - �������� ���������� �����
        {
            using (FileStream fstream = new FileStream(filename, FileMode.Append))
            {
                byte[] buffer1 = Encoding.Default.GetBytes("@=" + dog + splitter + "+=" + plus + "\n");
                fstream.Write(buffer1, 0, buffer1.Length);
            }
        }

        // ������ � ���-����
        private void WriteToLog(string filename, string textLine, string result, int stringLine, string extMessege = "")
        {
            if (!Directory.Exists("Log"))
            {
                Directory.CreateDirectory("Log");
            }
            if (newLog)
            {
                logName = "Log\\Log_" + filename.Substring(filename.LastIndexOf('\\') + 1) + GetDateTime() + ".csv";

                File.Create(logName).Close();
                using (FileStream fstream = new FileStream(logName, FileMode.Append))
                {
                    byte[] buffer1 = Encoding.Default.GetBytes("line" + splitter + "type" + splitter + "amplicon" + splitter + "ext_massege" + splitter + "\n");
                    fstream.Write(buffer1, 0, buffer1.Length);
                }
            }
            //PairedSequenceLog(textLine, result, stringLine, extMessege);
            using (FileStream fstream = new FileStream(logName, FileMode.Append))
            {
                byte[] buffer1 = Encoding.Default.GetBytes(stringLine.ToString() + splitter + result + splitter + textLine + splitter + extMessege + splitter + "\n");
                fstream.Write(buffer1, 0, buffer1.Length);
            }
        }

        private void PairedSequenceLog(string nameFile, string extMessege = "")
        {
            if (!pairedEndSeq)
            {
                return;
            }
            if (!Directory.Exists("Log"))
            {
                Directory.CreateDirectory("Log");
            }
            if (newLogSeq)
            {
                logName = "Log\\Log_PairedSeq_" + nameFile.Substring(nameFile.LastIndexOf('\\') + 1) + GetDateTime() + ".csv";

                File.Create(logName).Close();
                using (FileStream fstream = new FileStream(logName, FileMode.Append))
                {
                    byte[] buffer1 = Encoding.Default.GetBytes(
                        "line" + splitter +
                        "type" + splitter +
                        "R1" + splitter +
                        "R2" + splitter +
                        "discrepancy" + splitter +
                        "amplicon_R1" + splitter +
                        "amplicon_R2" + splitter
                        + "ext_massege" + splitter + "\n"); ;
                    fstream.Write(buffer1, 0, buffer1.Length);
                }
                newLogSeq = false;
            }
            using (FileStream fstream = new FileStream(logName, FileMode.Append))
            {
                foreach (var item in allReadsR1)
                {
                    string buf = sequenceResult[item.Key] == 'E' ? "1" : "0";
                    string latter = sequenceResult[item.Key] == 'E'? "Error" : sequenceResult[item.Key].ToString();
                    string result = "";//Convert.ToChar(sequenceResult[item.Key]) == wrongChar ? "Mutation" : "Normal";
                    if (Convert.ToChar(sequenceResult[item.Key]) == wrongChar)
                    {
                        result = "Mutation";
                    }
                    if (Convert.ToChar(sequenceResult[item.Key]) == mainChar)
                    {
                        result = "Normal";
                    }
                    else
                    {
                        result = "Other";
                    }
                    byte[] buffer1 = Encoding.Default.GetBytes(
                    item.Key.ToString()                         + splitter +
                    result + splitter +
                    sequenceR1[item.Key].ToString()                                      + splitter +
                    sequenceR2[item.Key].ToString() + splitter +
                    buf + splitter +
                    item.Value.ToString()                       + splitter +
                    Reverse(ReverseContextString(allReadsR2[item.Key].ToString())) + splitter +
                    extMessege                                  + splitter + 
                    "\n"); 
                    fstream.Write(buffer1, 0, buffer1.Length);
                }
                
            }
            newLogSeq = true;
        }

        // ������������ ����� ������ - �������� ����� 
        /// <summary>
        /// ����� ��������� � ������ �����
        /// </summary>
        /// <param name="fullname"></param>

        private void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Settings.Default.extractionPath);
        }
        private void comboBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.selectedMain = comboBoxMain.SelectedIndex;
            Settings.Default.Save();

        }
        private void comboBoxWrong_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.selectedWrong = comboBoxWrong.SelectedIndex;
            Settings.Default.Save();
        }
        private void textBox_Position_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.position = Convert.ToInt32(numericUpDownPosition.Value);
            position = Convert.ToInt32(numericUpDownPosition.Value);
            Settings.Default.Save();
            TextColorChage();
        }
        private void comboBoxSplitter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.splitetrIndex = comboBoxSplitter.SelectedIndex;
            Settings.Default.csvSplitter = comboBoxSplitter.Text;
            Settings.Default.Save();
            splitter = comboBoxSplitter.Text;
        }
        private void checkBoxPairedEnd_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.pairedEnd = checkBoxPairedEnd.Checked;
            Settings.Default.Save();
            pairedEndSeq = checkBoxPairedEnd.Checked;
        }
        private void checkBoxWriteLogs_CheckedChanged(object sender, EventArgs e)
        {

            Settings.Default.writeLogs = checkBoxWriteLogs.Checked;
            Settings.Default.Save();
        }
        private void numericUpDownPosition_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.position = (int)numericUpDownPosition.Value;
            position = Settings.Default.position;
            Settings.Default.Save();
            TextColorChage();
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            label5.Text = richTextBox1.SelectedText;
            Settings.Default.bigText = richTextBox1.Text;
            Settings.Default.Save();
        }
        private void numericUpDownLeft_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.shiftLeft = (int)numericUpDownLeft.Value;
            shiftL = Settings.Default.shiftLeft;
            Settings.Default.Save();
            TextColorChage();
        }
        private void numericUpDownRight_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.shiftRight = (int)numericUpDownRight.Value;
            shiftR = Settings.Default.shiftRight;
            Settings.Default.Save();
            TextColorChage();
        }
        // ��������� ������ ���������
        private void TextColorChage()
        {
            position = Convert.ToInt32(numericUpDownPosition.Value);
            if (richTextBox1.Text == null || richTextBox1.Text.Length < position + shiftR || position - shiftL - 1 < 0)
            {
                return;
            }
            richTextBox1.Select(0, richTextBox1.Text.Length);
            richTextBox1.SelectionColor = Color.Black;
            richTextBox1.SelectionBackColor = Color.White;


            richTextBox1.Select(position, shiftR);
            richTextBox1.SelectionColor = Color.Red;
            //richTextBox1.SelectionBackColor = Color.Purple;

            richTextBox1.Select(position - shiftL - 1, shiftL);
            richTextBox1.SelectionColor = Color.Red;
            //richTextBox1.SelectionBackColor = Color.Purple;

            richTextBox1.Select(position - 1, 1);
            richTextBox1.SelectionColor = Color.Red;
            richTextBox1.SelectionBackColor = Color.Yellow;
        }
    }
}