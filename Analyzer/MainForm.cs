using System.Diagnostics;
using System.Text;
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

            //checkBoxRight.Checked = Settings.Default.checkRight;
            //checkBoxLeft.Checked = Settings.Default.checkLeft;
            checkBoxWriteLogs.Checked = Settings.Default.writeLogs;

            //textBoxLContext.Text = Settings.Default.leftContext;
            //textBoxRContext.Text = Settings.Default.rightContext;

            comboBoxSplitter.SelectedIndex = Settings.Default.splitetrIndex;
            richTextBox1.Text = Settings.Default.bigText;

            numericUpDownLeft.Value = Settings.Default.shiftLeft;
            numericUpDownRight.Value = Settings.Default.shiftRight;
            position = Settings.Default.position;
            numericUpDownPosition.Value = Settings.Default.position;

        }
        string leftContext;
        string rightContext;

        float allMains = 0;
        float mutationCounter = 0;
        int errors = 0;
        int other = 0;
        int allLines = 0;
        int plus = 0;
        int dog = 0;
        int shiftR = 0;
        int shiftL = 0;

        string contextA = "";
        string contextT = "";
        string contextG = "";
        string contextC = "";

        int position = 0;
        char mainChar = ' ';
        char wrongChar = ' ';

        bool isBigFileCreated = false;
        bool toOneFile = true;
        bool newLog = true;

        public const string FILENAME = "";
        private string logName = "";
        public string splitter = "";
        private bool writeLogs;

        private void ProcessGenomeFile(string[] fileText, string fileName, int countFiles1)
        {

            allMains = 0;
            mutationCounter = 0;
            errors = 0;
            other = 0;
            allLines = 0;
            plus = 0;
            dog = 0;

            float aCoun = 0, tCout = 0, gCount = 0, cCount = 0;
            position = (int)numericUpDownPosition.Value;
            mainChar = Convert.ToChar(comboBoxMain.Text);
            wrongChar = Convert.ToChar(comboBoxWrong.Text);
            writeLogs = Settings.Default.writeLogs;


            int i = 0;
            bool read = false;
            for (i = 0; i < fileText.Count(); i++)
            {
                if (fileText[i][0] == '+' && fileText[i].Length == 1)
                {
                    plus++;
                    i++;
                    continue;
                }
                if (fileText[i][0] == '@')
                {
                    dog++;
                    allLines++;
                    read = true;
                    continue;
                }
                if (read)
                {
                    /*
                    if (fileText[i].Length < position + shiftToR)
                    {
                        errors++;
                        if (writeLog)
                        {
                            WriteToLog(fileName, fileText[i], "", i);
                        }
                        newLog = false;
                        read = false;
                        continue;
                    }
                    string buf = Convert.ToString(fileText[i]);
                    string bufs = string.Empty;
                    
                    if (fileText[i].Contains(fullcontext))
                    {
                        allMains++;
                        newLog = false;
                        read = false;
                        continue;
                    }*/

                    if (fileText[i].Contains(contextA))
                    {
                        CheckForLog(fileName, fileText[i], i, mainChar, wrongChar, 'A');
                        aCoun++;
                        read = false;
                        continue;
                    }
                    if (fileText[i].Contains(contextT))
                    {
                        CheckForLog(fileName, fileText[i], i, mainChar, wrongChar, 'T');
                        tCout++;
                        read = false;
                        continue;
                    }
                    if (fileText[i].Contains(contextG))
                    {
                        CheckForLog(fileName, fileText[i], i, mainChar, wrongChar, 'G');
                        gCount++;
                        read = false;
                        continue;
                    }
                    if (fileText[i].Contains(contextC))
                    {
                        CheckForLog(fileName, fileText[i], i, mainChar, wrongChar, 'C');
                        cCount++;
                        read = false;
                        continue;
                    }
                    else
                    {
                        CheckForLog(fileName, fileText[i], i, mainChar, wrongChar, error: true);
                        errors++;
                        read = false;
                        continue;
                    }

                    /*for (int g = position - shift - 1; g < position + shiftToR; g++) // вырезаем кусок строки
                    {
                        bufs += buf[g];
                    }

                    if (bufs == fullcontext)
                    {
                        allMains++;
                        if (writeLog)
                        {
                            WriteToLog(fileName, fileText[i], "Normal", i);
                        }
                        
                        newLog = false;
                        read = false;
                        continue;
                    }
                    if (bufs[shift] == wrongChar)
                    {
                        if (writeLog)
                        {
                            WriteToLog(fileName, fileText[i], "Mutation", i);
                        }
                        
                        mutationCounter++;

                        newLog = false;
                        read = false;
                        continue;
                    }
                    else
                    {
                        if (writeLog)
                        {
                            WriteToLog(fileName, fileText[i], "Other", i);
                        }
                        other++;
                        newLog = false;
                        read = false;
                        continue;
                    }*/
                }

            }
            switch (mainChar)
            {
                case 'A':
                    allMains = aCoun;
                    break;
                case 'T':
                    allMains = tCout;
                    break;
                case 'G':
                    allMains = gCount;
                    break;
                case 'C':
                    allMains = cCount;
                    break;
                default:
                    break;
            }
            switch (wrongChar)
            {
                case 'A':
                    mutationCounter = aCoun;
                    break;
                case 'T':
                    mutationCounter = tCout;
                    break;
                case 'G':
                    mutationCounter = gCount;
                    break;
                case 'C':
                    mutationCounter = cCount;
                    break;
                default:
                    break;
            }
            float catgc3 = (float)mutationCounter / ((float)mutationCounter + (float)allMains);
            int pd = dog - plus;
            /*
            MessageBox.Show("Всего записей: " + allLines.ToString()
                + "\nНайдено " + comboBoxMain.Text + ": " + allMains.ToString()
                + "\nНайдено " + comboBoxWrong.Text + ": " + mutationCounter.ToString()
                + "\nОшибок: " + errors.ToString()
                + "\nC/Все последовательности : " + Convert.ToString(call)
                + "\nС/Все-ошибки:  " + catgc
                + "\nС/Все-ошибки2: " + catgc2
                + "\n-------------------------------------"
                + "\n Check: " + check
                + "\n +:     " + plus
                + "\n @:     " + dog
                + "\n +-@:   " + pd);
            */
            this.Enabled = true;
            newLog = true;
            if (writeLogs)
            {
                WriteToLogEnd(logName, dog, plus);
            }

            float reads = dog;
            float errs = reads - allMains;
            WriteToCsv(fileName, position, aCoun, tCout, gCount, cCount, (errs / reads), countFiles1, reads);
            //WriteToCsv(fileName, position, allMains, mutationCounter, errors, other, catgc3, countFiles1);

        }
        // WriteToLog(fileName, fileText[i], "Other", i);
        void CheckForLog(string fileName, string fileText, int i, char cMain, char cWrng, char c = ' ', bool error = false, string ex_massege = "")
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


            leftContext = richTextBox1.Text.Substring(position - shiftL - 1, shiftL).ToUpper();
            rightContext = richTextBox1.Text.Substring(position, shiftR).ToUpper();

            contextA = leftContext + "A" + rightContext;
            contextT = leftContext + "T" + rightContext;
            contextG = leftContext + "G" + rightContext;
            contextC = leftContext + "C" + rightContext;


            //label5.Text = leftContext + mainChar + rightContext;
            int progrressCounter = 0;
            int countOfFiles = dlg.FileNames.Count();
            
            toolStripProgressBar.Maximum = countOfFiles;

            
            foreach (var file in dlg.FileNames)
            {

                string[] fileText = System.IO.File.ReadAllLines(file);
                ProcessGenomeFile(fileText, file, dlg.FileNames.Count());
                //string str = PGORSESS_TEXT + progrressCounter.ToString() + "/" + countOfFiles.ToString();
                progrressCounter++;
                toolStripProgressBar.Value = progrressCounter;
                //toolStripStatusLabel1.Text = str;
            }
           
            MessageBox.Show(countOfFiles.ToString() + " файл(ов) успешно обработаны!");
            toolStripProgressBar.Value = 0;
            isBigFileCreated = false;
        }

        /*
        private void WriteToCsv(string nameFile, int position, int normal, int mutations, int errors, int other,  float result, int countFiles)
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
        
            using (FileStream fstream = new FileStream(path + name, FileMode.Append))
            {
                string res = Convert.ToString(result);
                res = res.Replace(",", ".");
                byte[] buffer = Encoding.UTF8.GetBytes(nameFile.Substring(nameFile.LastIndexOf('\\') + 1) + splitter
                    + position + splitter 
                    + res  + splitter
                    + mutations + splitter
                    + normal + splitter
                    + other + splitter
                    + errors + 
                    '\n');
                fstream.Write(buffer, 0, buffer.Length);
            }
        }
        */
        void poro<T>()
        {

        }
        private void WriteToCsv(string nameFile, int position, float a, float t, float g, float c, float result, int countFiles, float reads)
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

            using (FileStream fstream = new FileStream(path + name, FileMode.Append))
            {
                string res = Convert.ToString(result * 100);
                res = res.Replace(",", ".");
                string aStr = Convert.ToString((a == 0 ? 0 : a / reads * 100)).Replace(",", ".");
                string tStr = Convert.ToString((t == 0 ? 0 : t / reads * 100)).Replace(",", ".");
                string gStr = Convert.ToString((t == 0 ? 0 : g / reads * 100)).Replace(",", ".");
                string cStr = Convert.ToString((t == 0 ? 0 : c / reads * 100)).Replace(",", ".");
                byte[] buffer = Encoding.UTF8.GetBytes(nameFile.Substring(nameFile.LastIndexOf('\\') + 1) + splitter
                    + reads + splitter
                    + position + splitter
                    + aStr + splitter
                    + tStr + splitter
                    + gStr + splitter
                    + cStr + splitter
                    + res + splitter
                    + '\n');
                fstream.Write(buffer, 0, buffer.Length);
            }
        }

        private string GetDateTime()
        {
            return DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year
                        + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
        }
        private void WriteToLogEnd(string filename, int dog, int plus)
        {
            using (FileStream fstream = new FileStream(filename, FileMode.Append))
            {
                byte[] buffer1 = Encoding.Default.GetBytes("@=" + dog + splitter + "+=" + plus + "\n");
                fstream.Write(buffer1, 0, buffer1.Length);
            }
        }
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

            using (FileStream fstream = new FileStream(logName, FileMode.Append))
            {
                byte[] buffer1 = Encoding.Default.GetBytes(stringLine.ToString() + splitter + result + splitter + textLine + splitter + extMessege + splitter + "\n");
                fstream.Write(buffer1, 0, buffer1.Length);
            }
        }
        private void PreCreateCsv(string fullname)
        {
            string a = "A_freq";
            string t = "T_freq";
            string g = "G_freq";
            string c = "C_freq";
            switch (mainChar)
            {
                case 'A':
                    a += " (ref)";
                    break;
                case 'T':
                    t += " (ref)";
                    break;
                case 'G':
                    g += " (ref)";
                    break;
                case 'C':
                    c += " (ref)";
                    break;
                default:
                    break;
            }
            switch (wrongChar)
            {
                case 'A':
                    a += " (mut)";
                    break;
                case 'T':
                    t += " (mut)";
                    break;
                case 'G':
                    g += " (mut)";
                    break;
                case 'C':
                    c += " (mut)";
                    break;
                default:
                    break;
            }

            File.Create(fullname).Close();
            using (FileStream fstream = new FileStream(fullname, FileMode.Append))
            {
                //byte[] buffer1 = Encoding.Default.GetBytes("Name" + splitter + "Position"+ splitter + "Result(mut/(normal+mut))"+ splitter + "Mutations"+ splitter + "Normal"+ splitter + "Other"+ splitter + "Errors"+ splitter + "\n");
                byte[] buffer1 = Encoding.Default.GetBytes("Name" + splitter + "Reads" + splitter + "Position" + splitter + a + splitter + t + splitter + g + splitter + c + splitter + "Invalid_seq, %" + splitter + "\n");

                fstream.Write(buffer1, 0, buffer1.Length);
            }
        }

        private void открытьОтчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Settings.Default.extractionPath);
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
            splitter = comboBoxSplitter.Text;
            Settings.Default.Save();
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

            richTextBox1.Select(position-shiftL-1, shiftL);
            richTextBox1.SelectionColor= Color.Red;
            //richTextBox1.SelectionBackColor = Color.Purple;

            richTextBox1.Select(position - 1, 1);
            richTextBox1.SelectionColor = Color.Red;
            richTextBox1.SelectionBackColor = Color.Yellow;
            
        }
    }
}