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

            checkBoxRight.Checked = Settings.Default.checkRight;
            checkBoxLeft.Checked = Settings.Default.checkLeft;

            textBoxLContext.Text = Settings.Default.leftContext;
            textBoxRContext.Text = Settings.Default.rightContext;

        }

        string seconds;
        string fullcontext = string.Empty;

        int allMains = 0;
        int mutationCounter = 0;
        int errors = 0;
        int other = 0;
        int allLines = 0;
        int plus = 0;
        int dog = 0;
        int shift = 0;
        int shiftToR = 0;

        int position = 0;
        char mainChar = ' ';
        char wrongChar = ' ';

        bool isBigFileCreated = false;
        bool toOneFile = true;

        public const string FILENAME = "";


        private void ProcessGenomeFile(string[] fileText, string fileName, int countFiles1)
        {
            
            allMains = 0;
            mutationCounter = 0;
            errors = 0;
            other = 0;
            allLines = 0;
            plus = 0;
            dog = 0;
            position = Convert.ToInt32(textBox_Position.Text);
            mainChar = Convert.ToChar(comboBoxMain.Text);
            wrongChar = Convert.ToChar(comboBoxWrong.Text);
            int controllSum = shift + shiftToR;

            int i = 0;
            bool read = false;
            for (i = 0; i < fileText.Count(); i++)
            {
                if (fileText[i][0] == '+')
                {
                    plus++;

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
                    if (fileText[i].Length < position + shiftToR)
                    {
                        errors++;
                        read = false;
                        continue;
                    }
                    string buf = Convert.ToString(fileText[i]);
                    string bufs = string.Empty;
                    for (int g = position - shift - 1; g < position + shiftToR; g++) // вырезаем кусок строки
                    {
                        bufs += buf[g];
                    }

                    if (bufs == fullcontext)
                    {
                        allMains++;
                        read = false;
                        continue;
                    }
                    if (bufs[shift] == wrongChar)
                    {
                        mutationCounter++;
                        read = false;
                        continue;
                    }
                    else
                    {
                        other++;
                        read = false;
                        continue;
                    }
                }
            }
            float call = (float)mutationCounter / (float)allLines;
            float catgc = (float)mutationCounter / (float)(allLines - errors);
            float catgc2 = (float)mutationCounter / (float)(allMains + other + mutationCounter + errors);
            float catgc3 = (float)mutationCounter / ((float)mutationCounter + (float)allMains);
            int check = allLines - (errors + allMains + other + mutationCounter);
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

            WriteToCsv(fileName, position, allMains, mutationCounter, errors, other, catgc3, countFiles1);

        }

        private async void OpenFiles(object sender, EventArgs e)   // запись в файл
        {

            OpenFileDialog dlg = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Выберите файлы",
                InitialDirectory = @"D:\"
            };
            dlg.ShowDialog();
            if (dlg.FileName == String.Empty)
                return;

            
            shift = textBoxLContext.Text.Length;
            shiftToR = textBoxRContext.Text.Length;
            fullcontext = textBoxLContext.Text + comboBoxMain.Text + textBoxRContext.Text;
            int progrressCounter = 0;
            int countOfFiles = dlg.FileNames.Count();
            toolStripProgressBar.Maximum = countOfFiles;
            

            foreach (var file in dlg.FileNames)
            {
                
                string[] fileText = System.IO.File.ReadAllLines(file);
                ProcessGenomeFile(fileText, file, dlg.FileNames.Count());
                progrressCounter++;
            }

            MessageBox.Show(countOfFiles.ToString() + " файлов успешно обработаны!");
            isBigFileCreated = false;
        }


        private void WriteToCsv(string nameFile, int position, int normal, int mutations, int errors, int other,  float result, int countFiles)
        {

            string path = Settings.Default.extractionPath;
            string name = "";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!toOneFile)
            {
                name = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year 
                    + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".csv";
                PreCreateCsv(path + name);
            }
            if (toOneFile)
            {
                if (!isBigFileCreated)
                {
                    name = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year 
                        + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second 
                        + "_(" + countFiles.ToString() + "_files)" + ".csv";
                    Settings.Default.bigFile = name;
                    PreCreateCsv(path + name);
                    isBigFileCreated = true;
                }
                name = Settings.Default.bigFile;


            }

            using (FileStream fstream = new FileStream(path + name, FileMode.Append))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(nameFile.Substring(nameFile.LastIndexOf('\\') + 1) + ";"
                    + position + ";" 
                    + result + ";"
                    + mutations + ";" 
                    + normal + ";" 
                    + other + ";" 
                    + errors + 
                    '\n');
                fstream.Write(buffer, 0, buffer.Length);
            }
            
        }

        private void PreCreateCsv(string fullname)
        {
            File.Create(fullname).Close();
            using (FileStream fstream = new FileStream(fullname, FileMode.Append))
            {
                byte[] buffer1 = Encoding.Default.GetBytes("Name;Position;Result(mut/(normal+mut));Mutations;Normal;Other;Errors;\n");
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

        private void checkBoxLeft_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.checkLeft = checkBoxLeft.Checked;
            Settings.Default.Save();
        }

        private void checkBoxRight_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.checkRight = checkBoxRight.Checked;
            Settings.Default.Save();
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
            Settings.Default.position = textBox_Position.Text;
            Settings.Default.Save();
        }

        private void textBoxLContext_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.leftContext = textBoxLContext.Text;
            Settings.Default.Save();
        }

        private void textBoxRContext_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.rightContext = textBoxRContext.Text;
            Settings.Default.Save();
        }
    }
}