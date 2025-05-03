using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using static Analyzer.SupportMethods.SupportMethods;
namespace Analyzer
{
    public partial class MainForm : Form
    {
        private static string PGORSESS_TEXT = "Процесс ";
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

        float aCount = 0, tCount = 0, gCount = 0, cCount = 0;
        float aCountRev = 0, tCountRev = 0, gCountRev = 0, cCountRev = 0;


        //Контексты 
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

        private void PairedEndSequence()
        {

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
            return;
        }
        private string GetCountOfSequencesToString()
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

        private void ProcessGenomeFile(string[] fileText, string fileName = "")
        {
            if (fileText == null)
            {
                return;
            }
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
                        
                        //PairedEndSequence();
                        //CheckForLog(fileName, fileText[i], i, main, wrong, Leters[0]);
                        //aCount++;
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
                        //PairedEndSequence();
                        //CheckForLog(fileName, fileText[i], i, main, wrong, Leters[3]);
                        //tCount++;
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
                        //PairedEndSequence();
                        //CheckForLog(fileName, fileText[i], i, main, wrong, Leters[1]);
                        //gCount++;
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
                        //PairedEndSequence();
                        //CheckForLog(fileName, fileText[i], i, main, wrong, Leters[2]);
                        // cCount++;
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
                        //PairedEndSequence();
                        //CheckForLog(fileName, fileText[i], i, main, wrong, error: true);
                        //errors++;
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

        private void ProcessGenomeFiles(string[] fileTextR1, string[] fileTextR2, string fileNameR1, 
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
            if (fileNameR2 != null)
            {
                ProcessGenomeFile(fileTextR1, fileNameR1);
            }
            if (fileNameR2 != null)
            {
                ProcessGenomeFile(fileTextR2, fileNameR2);
            }
            // распределяем переменные после результата
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
                PairedEndSequence();
                GetCountOfSequencesToString();
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

            WriteToCsv(fileNameR1, position, aCount, tCount, gCount, cCount, errors, countFiles1, reads, 
                fileNameR2, aCountRev, tCountRev, gCountRev, cCountRev, errorsRev, dogRev);

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

        void CheckForLog(string fileName, string fileText, int i, char cMain, char cWrng, char c = ' ', 
            bool error = false, string ex_massege = "")
        {
            if (!writeLogs)
            {
                return;
            }
            if (error)
            {
                WriteToLog(fileName, fileText, "error", i, ex_massege);
                newLog = false;
                return;
            }
            if (cMain == c)
            {
                WriteToLog(fileName, fileText, "Normal", i, ex_massege);
                newLog = false;
                return;
            }
            if (cWrng == c)
            {
                WriteToLog(fileName, fileText, "Mutation", i, ex_massege);
                newLog = false;
                return;
            }
        }
        private void OpenFiles(object sender, EventArgs e)   // запись в файл
        {

            position = Convert.ToInt32(numericUpDownPosition.Value);
            if (position - shiftL - 1 < 0 || position + shiftR > richTextBox1.Text.Length)
            {
                MessageBox.Show("Сдвиги выходят за пределы референса!");
                return;
            }
            OpenFileDialog dlg = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Выберите файлы",
                InitialDirectory = @"F:\"
            };
            dlg.ShowDialog();
            if (dlg.FileName == String.Empty)
                return;

            //Получение переменных перед работой с файлом
            position = (int)numericUpDownPosition.Value;
            mainChar = Convert.ToChar(comboBoxMain.Text);
            wrongChar = Convert.ToChar(comboBoxWrong.Text);
            writeLogs = Settings.Default.writeLogs;
            mainCharRev = Convert.ToChar(ReverseContextString(comboBoxMain.Text));
            wrongCharRev = Convert.ToChar(ReverseContextString(comboBoxWrong.Text));

            // Получение контекста
            leftContext = richTextBox1.Text.Substring(position - shiftL - 1, shiftL).ToUpper();
            rightContext = richTextBox1.Text.Substring(position, shiftR).ToUpper();
            bool doUppend = false;

            //Создание всех вариантов контекста
            contextA = leftContext + "A" + rightContext;
            contextT = leftContext + "T" + rightContext;
            contextG = leftContext + "G" + rightContext;
            contextC = leftContext + "C" + rightContext;

            //Создание реверсного контекста
            contextARev = Reverse(ReverseContextString(contextA));
            contextTRev = Reverse(ReverseContextString(contextT));
            contextGRev = Reverse(ReverseContextString(contextG));
            contextCRev = Reverse(ReverseContextString(contextC));

            //label5.Text = leftContext + mainChar + rightContext;
            
            int countOfFiles = dlg.FileNames.Count();
            toolStripProgressBar.Maximum = countOfFiles;

            // Сортировка списка файлов в алфавитном порядке 
            Array.Sort(dlg.FileNames);
            
            FILE(dlg);

            toolStripProgressBar.Value = 0;
        }
        int progrressCounter = 0;
        private async void FILE(OpenFileDialog dlg)
        {
            var startTime = DateTime.Now;
            for (int i = 0; i < dlg.FileNames.Length; i++)
            {
                toolStripProgressBar.Value = i;
                toolStripProgressBar.ToolTipText = dlg.FileNames.Length.ToString();
                await Task.Delay(1);
                string[] fileTextR1 = null;// = System.IO.File.ReadAllLines(dlg.FileNames[i]);
                string[] fileTextR2 = null; //= System.IO.File.ReadAllLines(dlg.FileNames[i + 1]);
                if (dlg.FileNames[i].Contains("R1"))
                {
                    fileTextR1 = System.IO.File.ReadAllLines(dlg.FileNames[i]);
                    if (dlg.FileNames.Count() > i + 1)
                    {
                        if (dlg.FileNames[i + 1].Contains("R1"))
                        {
                            ProcessGenomeFiles(fileTextR1, fileTextR2, dlg.FileNames[i], "", dlg.FileNames.Count());
                            progrressCounter++;
                            continue;
                        }
                        if (dlg.FileNames[i + 1].Contains("R2"))
                        {
                            fileTextR2 = System.IO.File.ReadAllLines(dlg.FileNames[i + 1]);
                            ProcessGenomeFiles(fileTextR1, fileTextR2, dlg.FileNames[i], dlg.FileNames[i + 1], dlg.FileNames.Count());
                            progrressCounter += 2;
                            i++;
                            continue;
                        }
                    }
                    ProcessGenomeFiles(fileTextR1, fileTextR2, dlg.FileNames[i], "", dlg.FileNames.Count());
                    continue;
                }
                if (dlg.FileNames[i].Contains("R2"))
                {
                    fileTextR2 = System.IO.File.ReadAllLines(dlg.FileNames[i]);
                    if (dlg.FileNames.Count() > i + 1)
                    {
                        if (dlg.FileNames[i + 1].Contains("R1"))
                        {
                            fileTextR1 = System.IO.File.ReadAllLines(dlg.FileNames[i + 1]);
                            ProcessGenomeFiles(fileTextR1, fileTextR2, dlg.FileNames[i + 1], dlg.FileNames[i], dlg.FileNames.Count());
                            progrressCounter += 2;
                            i++;
                            continue;
                        }
                        if (dlg.FileNames[i + 1].Contains("R2"))
                        {
                            ProcessGenomeFiles(fileTextR1, fileTextR2, "", dlg.FileNames[i], dlg.FileNames.Count());
                            progrressCounter++;
                            continue;
                        }
                    }
                    ProcessGenomeFiles(fileTextR1, fileTextR2, "", dlg.FileNames[i], dlg.FileNames.Count());
                    progrressCounter++;
                    continue;
                }

            }

            var endTime = DateTime.Now;
            toolStripProgressBar.Value = toolStripProgressBar.Maximum;
            MessageBox.Show($"{dlg.FileNames.Length} файл(ов) успешно обработаны!\n{endTime - startTime}");
            toolStripProgressBar.Value = toolStripProgressBar.Minimum;
            //toolStripProgressBar.Value = 0;
            isBigFileCreated = false;

        }
        

        private void WriteToCsv(string nameFile = "", int position = 0, float a = 0, float t = 0, float g = 0, float c = 0, float result = 0, int countFiles = 0, float reads = 0,
            string fileName2 = "", float aRev = 0, float tRev = 0, float gRev = 0, float cRev = 0, float resultRev = 0, float readsRev = 0)
        {

            string path = Settings.Default.extractionPath;
            string name = "";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (toOneFile)
            {
                if (!isBigFileCreated)
                {
                    name = GetDateTime()
                        + "_(" + countFiles.ToString() + "_files)" + ".csv";
                    Settings.Default.bigFile = name;
                    PreCreateCsv(path + name);
                    isBigFileCreated = true;
                }
                name = Settings.Default.bigFile;
            }

            // запись в файл отчета результатов обработки файлов
            using (FileStream fstream = new FileStream(path + name, FileMode.Append))
            {
                string res = Convert.ToString(reads == 0 ? 0 : result / reads * 100).Replace(",", ".");
                string aStr = Convert.ToString((reads == 0 ? 0 : a / reads * 100)).Replace(",", ".");
                string tStr = Convert.ToString((reads == 0 ? 0 : t / reads * 100)).Replace(",", ".");
                string gStr = Convert.ToString((reads == 0 ? 0 : g / reads * 100)).Replace(",", ".");
                string cStr = Convert.ToString((reads == 0 ? 0 : c / reads * 100)).Replace(",", ".");

                string resRev = Convert.ToString(readsRev == 0 ? 0 : resultRev / readsRev * 100).Replace(",", ".");
                string aStrRev = Convert.ToString((readsRev == 0 ? 0 : aRev / readsRev * 100)).Replace(",", ".");
                string tStrRev = Convert.ToString((readsRev == 0 ? 0 : tRev / readsRev * 100)).Replace(",", ".");
                string gStrRev = Convert.ToString((readsRev == 0 ? 0 : gRev / readsRev * 100)).Replace(",", ".");
                string cStrRev = Convert.ToString((readsRev == 0 ? 0 : cRev / readsRev * 100)).Replace(",", ".");
                string desp = Convert.ToString((GetDiscrepancyCount() == 0 ? 0 : GetDiscrepancyCount() / reads)).Replace(",", ".");
                byte[] buffer = Encoding.UTF8.GetBytes(
                    nameFile.Substring(nameFile.LastIndexOf('\\') + 1) + splitter
                    + reads + splitter
                    + position + splitter
                    + aStr + splitter
                    + tStr + splitter
                    + gStr + splitter
                    + cStr + splitter
                    + res + splitter
                    + fileName2.Substring(fileName2.LastIndexOf('\\') + 1) + splitter
                    + readsRev + splitter
                    + position + splitter
                    + tStrRev + splitter        //
                    + aStrRev + splitter        //
                    + cStrRev + splitter        //  
                    + gStrRev + splitter        //
                    + resRev + splitter
                    + GetDiscrepancyCount() + splitter
                    + desp + splitter
                    + '\n');
                fstream.Write(buffer, 0, buffer.Length);
            }
        }

        private void WriteToLogEnd(string filename, int dog, int plus)  // для отладки - получить количество ридов
        {
            using (FileStream fstream = new FileStream(filename, FileMode.Append))
            {
                byte[] buffer1 = Encoding.Default.GetBytes("@=" + dog + splitter + "+=" + plus + "\n");
                fstream.Write(buffer1, 0, buffer1.Length);
            }
        }

        // Запись в Лог-файл
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

        // Предсоздание файла отчета - создание шапок 
        /// <summary>
        /// Можно отправить в другой класс
        /// </summary>
        /// <param name="fullname"></param>
        private void PreCreateCsv(string fullname)
        {
            string a = "A_freq";
            string t = "T_freq";
            string g = "G_freq";
            string c = "C_freq";

            string aR = "A_freq";
            string tR = "T_freq";
            string gR = "G_freq";
            string cR = "C_freq";
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
            using (FileStream fstream = new FileStream(fullname, FileMode.Append))
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
                    + "Name" + splitter
                    + "Reads" + splitter
                    + "Position" + splitter
                    + aR + splitter
                    + tR + splitter
                    + gR + splitter
                    + cR + splitter
                    + "Invalid_seq, %" + splitter
                    + "Discrepancy" + splitter
                    + "Discrepancy, %" + splitter
                    + "\n");

                fstream.Write(buffer1, 0, buffer1.Length);
            }
        }

        private int GetDiscrepancyCount()
        {
            int count = 0;
            foreach (var item in sequenceResult)
            {
                if (item.Value =='E')
                {
                    count++;
                    continue;
                }
            }
            return count;
        }














        private void открытьОтчетыToolStripMenuItem_Click(object sender, EventArgs e)
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
        // Подсветка текста контекста
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