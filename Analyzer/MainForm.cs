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

        }

        string seconds;

        int allMains = 0;
        int wrongCounter = 0;
        int errors = 0;
        int anotherLatters = 0;
        int allLines = 0;
        int annomally = 0;
        int plus = 0;
        int dog = 0;

        int position = 0;
        char mainChar = ' ';
        char wrongChar = ' ';

        bool isBigFileCreated = false;
        bool toOneFile = false;

        public const string FILENAME = "";

        private void ProcessGenomeFile(string[] fileText, string fileName, int countFiles1 = 0)
        {
            allMains = 0;
            wrongCounter = 0;
            errors = 0;
            anotherLatters = 0;
            allLines = 0;
            annomally = 0;
            plus = 0;
            dog = 0;
            position = Convert.ToInt32(textBox_Position.Text);
            mainChar = Convert.ToChar(comboBoxMain.Text);
            wrongChar = Convert.ToChar(comboBoxWrong.Text);
            int i = 0;
            bool read = false;
            for (i = 0; i < fileText.Count(); i++)
            {
                if (fileText[i][0] == '+')
                {
                    plus++;
                    allLines++;
                    continue;
                }
                if (fileText[i][0] == '@')
                {
                    dog++;
                    read = true;
                    continue;
                }
                if (read)
                {

                    if (fileText[i].Length <= position)
                    {
                        errors++;
                        read = false;
                        continue;
                    }
                    if (fileText[i][position] == wrongChar)
                    {
                        wrongCounter++;
                        read = false;
                        continue;
                    }
                    if (fileText[i][position] == mainChar)
                    {
                        allMains++;
                        read = false;
                        continue;
                    }
                    else
                    {
                        anotherLatters++;
                        read = false;
                        continue;
                    }
                    annomally++;
                    read = false;
                }
            }
            float call = (float)wrongCounter / (float)allLines;
            float catgc = (float)wrongCounter / (float)(allLines - errors);
            float catgc2 = (float)wrongCounter / (float)(allMains + anotherLatters + wrongCounter + errors);
            int check = allLines - (errors + allMains + anotherLatters + wrongCounter + annomally);
            int pd = dog - plus;
            /*
            MessageBox.Show("Всего записей: " + allLines.ToString()
                + "\nНайдено " + comboBoxMain.Text + ": " + allMains.ToString()
                + "\nНайдено " + comboBoxWrong.Text + ": " + wrongCounter.ToString()
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

            WriteToCsv(fileName, position, allMains, wrongCounter, errors, countFiles: countFiles1);

        }

        private async void OpenFiles(object sender, EventArgs e)
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
            Stopwatch clock = new Stopwatch();
            toOneFile = true;
            int progrressCounter = 0;
            int countOfFiles = dlg.FileNames.Count();
            toolStripProgressBar.Maximum = countOfFiles;
            int pgrogressValue = countOfFiles - (countOfFiles % 100);

            foreach (var file in dlg.FileNames)
            {
                toolStripProgressBar.Value++;
                toolStripProgressBar.ToolTipText = PGORSESS_TEXT + " " + progrressCounter.ToString() + "/" + countOfFiles.ToString();
                string[] fileText = System.IO.File.ReadAllLines(file);
                ProcessGenomeFile(fileText, file, dlg.FileNames.Count());
                progrressCounter++;
                //toolStripStatusLabel1.Text = PGORSESS_TEXT + " " + progrressCounter.ToString() + "/" + countOfFiles.ToString();
            }

            MessageBox.Show(countOfFiles.ToString() + " файлов успешно обработаны!" +
                "\n секунд " + seconds);
            toolStripProgressBar.Value = 0;
            toOneFile = false;
            isBigFileCreated = false;

        }


        private void WriteToCsv(string nameFile, int position, int normal, int mutations, int errors, int countFiles = 0)
        {

            string path = Settings.Default.extractionPath;
            string name = "";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!toOneFile)
            {
                name = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".csv";
                PreCreateCsv(path + name);
            }
            if (toOneFile)
            {
                if (!isBigFileCreated)
                {
                    name = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + "_(" + countFiles.ToString() + "_files)" + ".csv";
                    Settings.Default.bigFile = name;
                    PreCreateCsv(path + name);
                    isBigFileCreated = true;
                }
                name = Settings.Default.bigFile;


            }

            using (FileStream fstream = new FileStream(path + name, FileMode.Append))
            {
                byte[] buffer = Encoding.Default.GetBytes(nameFile.Substring(nameFile.LastIndexOf('\\') + 1) + ";" + position + ";" + normal + ";" + mutations + ";" + errors + '\n');
                fstream.Write(buffer, 0, buffer.Length);
            }
        }

        private void PreCreateCsv(string fullname)
        {
            File.Create(fullname).Close();
            using (FileStream fstream = new FileStream(fullname, FileMode.Append))
            {
                byte[] buffer1 = Encoding.Default.GetBytes("Name;Position;Normal;Mutations;Errors;\n");
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

    }
}