namespace Analyzer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            выбратьФайлToolStripMenuItem = new ToolStripMenuItem();
            настройкиToolStripMenuItem = new ToolStripMenuItem();
            открытьОтчетыToolStripMenuItem = new ToolStripMenuItem();
            Languages = new ToolStripComboBox();
            openFileDialog = new OpenFileDialog();
            tableLayoutPanel1 = new TableLayoutPanel();
            numericUpDownPosition = new NumericUpDown();
            checkBoxWriteLogs = new CheckBox();
            numericUpDownLeft = new NumericUpDown();
            label2 = new Label();
            comboBoxWrong = new ComboBox();
            label4 = new Label();
            comboBoxMain = new ComboBox();
            comboBoxSplitter = new ComboBox();
            numericUpDownRight = new NumericUpDown();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            checkBoxPairedEnd = new CheckBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripProgressBar = new ToolStripProgressBar();
            richTextBox1 = new RichTextBox();
            rich = new GroupBox();
            menuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPosition).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRight).BeginInit();
            statusStrip1.SuspendLayout();
            rich.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Location = new Point(116, 0);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 2;
            label1.Text = "Позиция";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { выбратьФайлToolStripMenuItem, настройкиToolStripMenuItem, открытьОтчетыToolStripMenuItem, Languages });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(530, 27);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip";
            // 
            // выбратьФайлToolStripMenuItem
            // 
            выбратьФайлToolStripMenuItem.Name = "выбратьФайлToolStripMenuItem";
            выбратьФайлToolStripMenuItem.Size = new Size(75, 23);
            выбратьФайлToolStripMenuItem.Text = "Открыть...";
            выбратьФайлToolStripMenuItem.Click += OpenFiles;
            // 
            // настройкиToolStripMenuItem
            // 
            настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            настройкиToolStripMenuItem.Size = new Size(79, 23);
            настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // открытьОтчетыToolStripMenuItem
            // 
            открытьОтчетыToolStripMenuItem.Name = "открытьОтчетыToolStripMenuItem";
            открытьОтчетыToolStripMenuItem.Size = new Size(60, 23);
            открытьОтчетыToolStripMenuItem.Text = "Отчеты";
            открытьОтчетыToolStripMenuItem.Click += открытьОтчетыToolStripMenuItem_Click;
            // 
            // Languages
            // 
            Languages.Name = "Languages";
            Languages.Size = new Size(121, 23);
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.58334F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.41667F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 261F));
            tableLayoutPanel1.Controls.Add(numericUpDownPosition, 1, 1);
            tableLayoutPanel1.Controls.Add(checkBoxWriteLogs, 0, 5);
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(numericUpDownLeft, 1, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(comboBoxWrong, 2, 1);
            tableLayoutPanel1.Controls.Add(label4, 0, 4);
            tableLayoutPanel1.Controls.Add(comboBoxMain, 0, 1);
            tableLayoutPanel1.Controls.Add(comboBoxSplitter, 1, 4);
            tableLayoutPanel1.Controls.Add(numericUpDownRight, 1, 3);
            tableLayoutPanel1.Controls.Add(label3, 0, 3);
            tableLayoutPanel1.Controls.Add(label5, 2, 4);
            tableLayoutPanel1.Controls.Add(label6, 0, 0);
            tableLayoutPanel1.Controls.Add(label7, 2, 0);
            tableLayoutPanel1.Controls.Add(checkBoxPairedEnd, 2, 5);
            tableLayoutPanel1.Location = new Point(3, 187);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(437, 183);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // numericUpDownPosition
            // 
            numericUpDownPosition.Location = new Point(116, 18);
            numericUpDownPosition.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericUpDownPosition.Name = "numericUpDownPosition";
            numericUpDownPosition.Size = new Size(56, 23);
            numericUpDownPosition.TabIndex = 19;
            numericUpDownPosition.ValueChanged += numericUpDownPosition_ValueChanged;
            // 
            // checkBoxWriteLogs
            // 
            checkBoxWriteLogs.Anchor = AnchorStyles.Right;
            checkBoxWriteLogs.AutoSize = true;
            checkBoxWriteLogs.Location = new Point(24, 134);
            checkBoxWriteLogs.Name = "checkBoxWriteLogs";
            checkBoxWriteLogs.Size = new Size(86, 19);
            checkBoxWriteLogs.TabIndex = 16;
            checkBoxWriteLogs.Text = "Вести логи";
            checkBoxWriteLogs.UseVisualStyleBackColor = true;
            checkBoxWriteLogs.CheckedChanged += checkBoxWriteLogs_CheckedChanged;
            // 
            // numericUpDownLeft
            // 
            numericUpDownLeft.Anchor = AnchorStyles.Left;
            numericUpDownLeft.Location = new Point(116, 47);
            numericUpDownLeft.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownLeft.Name = "numericUpDownLeft";
            numericUpDownLeft.ReadOnly = true;
            numericUpDownLeft.Size = new Size(56, 23);
            numericUpDownLeft.TabIndex = 16;
            numericUpDownLeft.ValueChanged += numericUpDownLeft_ValueChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(16, 51);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 3;
            label2.Text = "Левый контекст";
            // 
            // comboBoxWrong
            // 
            comboBoxWrong.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxWrong.FormattingEnabled = true;
            comboBoxWrong.Items.AddRange(new object[] { "C", "T", "A", "G" });
            comboBoxWrong.Location = new Point(178, 18);
            comboBoxWrong.Name = "comboBoxWrong";
            comboBoxWrong.Size = new Size(34, 23);
            comboBoxWrong.TabIndex = 11;
            comboBoxWrong.SelectedIndexChanged += comboBoxWrong_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(35, 109);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 3;
            label4.Text = "Разделитель";
            // 
            // comboBoxMain
            // 
            comboBoxMain.Anchor = AnchorStyles.Right;
            comboBoxMain.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMain.FormattingEnabled = true;
            comboBoxMain.Items.AddRange(new object[] { "C", "T", "A", "G" });
            comboBoxMain.Location = new Point(76, 18);
            comboBoxMain.Name = "comboBoxMain";
            comboBoxMain.Size = new Size(34, 23);
            comboBoxMain.TabIndex = 10;
            comboBoxMain.SelectedIndexChanged += comboBoxMain_SelectedIndexChanged;
            // 
            // comboBoxSplitter
            // 
            comboBoxSplitter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSplitter.FormattingEnabled = true;
            comboBoxSplitter.Items.AddRange(new object[] { ",", ";" });
            comboBoxSplitter.Location = new Point(116, 105);
            comboBoxSplitter.Name = "comboBoxSplitter";
            comboBoxSplitter.Size = new Size(34, 23);
            comboBoxSplitter.TabIndex = 12;
            comboBoxSplitter.SelectedIndexChanged += comboBoxSplitter_SelectedIndexChanged;
            // 
            // numericUpDownRight
            // 
            numericUpDownRight.Location = new Point(116, 76);
            numericUpDownRight.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownRight.Name = "numericUpDownRight";
            numericUpDownRight.ReadOnly = true;
            numericUpDownRight.Size = new Size(56, 23);
            numericUpDownRight.TabIndex = 17;
            numericUpDownRight.ValueChanged += numericUpDownRight_ValueChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(8, 80);
            label3.Name = "label3";
            label3.Size = new Size(102, 15);
            label3.TabIndex = 15;
            label3.Text = "Правый контекст";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(178, 102);
            label5.Name = "label5";
            label5.Size = new Size(10, 15);
            label5.TabIndex = 18;
            label5.Text = ".";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(65, 0);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 19;
            label6.Text = "Норма";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(178, 0);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 20;
            label7.Text = "Мутация";
            // 
            // checkBoxPairedEnd
            // 
            checkBoxPairedEnd.AutoSize = true;
            checkBoxPairedEnd.Location = new Point(178, 134);
            checkBoxPairedEnd.Name = "checkBoxPairedEnd";
            checkBoxPairedEnd.Size = new Size(207, 19);
            checkBoxPairedEnd.TabIndex = 21;
            checkBoxPairedEnd.Text = "Парноконцевое секвенирование";
            checkBoxPairedEnd.UseVisualStyleBackColor = true;
            checkBoxPairedEnd.CheckedChanged += checkBoxPairedEnd_CheckedChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.AutoSize = false;
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripProgressBar });
            statusStrip1.Location = new Point(0, 390);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(530, 22);
            statusStrip1.TabIndex = 12;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.AutoSize = false;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(60, 17);
            toolStripStatusLabel1.Text = "Прогресс";
            // 
            // toolStripProgressBar
            // 
            toolStripProgressBar.Name = "toolStripProgressBar";
            toolStripProgressBar.Size = new Size(130, 16);
            toolStripProgressBar.Style = ProgressBarStyle.Continuous;
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.Location = new Point(3, 19);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.Size = new Size(524, 135);
            richTextBox1.TabIndex = 17;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // rich
            // 
            rich.Controls.Add(richTextBox1);
            rich.Dock = DockStyle.Top;
            rich.Location = new Point(0, 27);
            rich.Name = "rich";
            rich.Size = new Size(530, 157);
            rich.TabIndex = 18;
            rich.TabStop = false;
            rich.Text = "Эталонный ампликон";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 412);
            Controls.Add(rich);
            Controls.Add(statusStrip1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimumSize = new Size(0, 358);
            Name = "MainForm";
            Text = "Главное";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPosition).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRight).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            rich.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem выбратьФайлToolStripMenuItem;
        private OpenFileDialog openFileDialog;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private ComboBox comboBoxMain;
        private ComboBox comboBoxWrong;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem открытьОтчетыToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar toolStripProgressBar;
        private Label label3;
        private ComboBox comboBoxSplitter;
        private Label label4;
        private CheckBox checkBoxWriteLogs;
        private RichTextBox richTextBox1;
        private GroupBox rich;
        private NumericUpDown numericUpDownLeft;
        private NumericUpDown numericUpDownRight;
        private Label label5;
        private Label label6;
        private Label label7;
        private NumericUpDown numericUpDownPosition;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private CheckBox checkBoxPairedEnd;
        private ToolStripComboBox Languages;
    }
}