
namespace Analyzer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        public const string FILENAME = "";
        private void выбратьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int allMains = 0;
            int wrongCounter = 0;
            int errors = 0;
            int anotherLatters = 0;
            int allLines = 0;
            int annomally = 0;
            int plus = 0;
            int dog = 0;
            int position = Convert.ToInt32(textBox_Position.Text);
            char mainChar = Convert.ToChar(comboBoxMain.Text);
            char wrongChar = Convert.ToChar(comboBoxWrong.Text);
            openFileDialog.FileName = Settings.Default.filePath;
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            this.Enabled = false;
            string filename = openFileDialog.FileName;
            Settings.Default.filePath = filename;
            Settings.Default.Save();
            string[] fileText = System.IO.File.ReadAllLines(filename);
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
                        allMains ++;
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
            float call = (float)wrongCounter /  (float)allLines;
            float catgc  = (float)wrongCounter / (float) (allLines - errors);
            float catgc2 = (float)wrongCounter / (float) (allMains + anotherLatters + wrongCounter + errors) ;
            int check = allLines - (errors + allMains + anotherLatters + wrongCounter + annomally);
            int pd = dog-plus;
            MessageBox.Show("Всего записей: " + allLines.ToString() + "\n" + 
                "Найдено "+ comboBoxMain.Text + ": " + allMains.ToString() +
                "\nНайдено " + comboBoxWrong.Text + ": " + wrongCounter.ToString() +
                "\nОшибок: " + errors.ToString() +
                "\nC/Все последовательности : " + Convert.ToString(call)
                +"\nС/Все-ошибки:  " + catgc
                +"\nС/Все-ошибки2: " + catgc2
                +"\n Check: " + check
                +"\n +:     " + plus
                +"\n @:     " + dog
                +"\n +-@:   " + pd);
            this.Enabled = true;
        }

        private void comboBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.selectedMain = comboBoxMain.SelectedIndex;
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