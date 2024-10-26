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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выбратьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьОтчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownPosition = new System.Windows.Forms.NumericUpDown();
            this.checkBoxWriteLogs = new System.Windows.Forms.CheckBox();
            this.numericUpDownLeft = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxWrong = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxMain = new System.Windows.Forms.ComboBox();
            this.comboBoxSplitter = new System.Windows.Forms.ComboBox();
            this.numericUpDownRight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.rich = new System.Windows.Forms.GroupBox();
            this.checkBoxPairedEnd = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRight)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.rich.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Позиция";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьФайлToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.открытьОтчетыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(530, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip";
            // 
            // выбратьФайлToolStripMenuItem
            // 
            this.выбратьФайлToolStripMenuItem.Name = "выбратьФайлToolStripMenuItem";
            this.выбратьФайлToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.выбратьФайлToolStripMenuItem.Text = "Открыть...";
            this.выбратьФайлToolStripMenuItem.Click += new System.EventHandler(this.OpenFiles);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // открытьОтчетыToolStripMenuItem
            // 
            this.открытьОтчетыToolStripMenuItem.Name = "открытьОтчетыToolStripMenuItem";
            this.открытьОтчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.открытьОтчетыToolStripMenuItem.Text = "Отчеты";
            this.открытьОтчетыToolStripMenuItem.Click += new System.EventHandler(this.открытьОтчетыToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.58334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.41667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 261F));
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownPosition, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxWriteLogs, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownLeft, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxWrong, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxMain, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxSplitter, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownRight, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxPairedEnd, 2, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 187);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(437, 183);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // numericUpDownPosition
            // 
            this.numericUpDownPosition.Location = new System.Drawing.Point(116, 18);
            this.numericUpDownPosition.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownPosition.Name = "numericUpDownPosition";
            this.numericUpDownPosition.Size = new System.Drawing.Size(56, 23);
            this.numericUpDownPosition.TabIndex = 19;
            this.numericUpDownPosition.ValueChanged += new System.EventHandler(this.numericUpDownPosition_ValueChanged);
            // 
            // checkBoxWriteLogs
            // 
            this.checkBoxWriteLogs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxWriteLogs.AutoSize = true;
            this.checkBoxWriteLogs.Location = new System.Drawing.Point(24, 134);
            this.checkBoxWriteLogs.Name = "checkBoxWriteLogs";
            this.checkBoxWriteLogs.Size = new System.Drawing.Size(86, 19);
            this.checkBoxWriteLogs.TabIndex = 16;
            this.checkBoxWriteLogs.Text = "Вести логи";
            this.checkBoxWriteLogs.UseVisualStyleBackColor = true;
            this.checkBoxWriteLogs.CheckedChanged += new System.EventHandler(this.checkBoxWriteLogs_CheckedChanged);
            // 
            // numericUpDownLeft
            // 
            this.numericUpDownLeft.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownLeft.Location = new System.Drawing.Point(116, 47);
            this.numericUpDownLeft.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLeft.Name = "numericUpDownLeft";
            this.numericUpDownLeft.ReadOnly = true;
            this.numericUpDownLeft.Size = new System.Drawing.Size(56, 23);
            this.numericUpDownLeft.TabIndex = 16;
            this.numericUpDownLeft.ValueChanged += new System.EventHandler(this.numericUpDownLeft_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Левый контекст";
            // 
            // comboBoxWrong
            // 
            this.comboBoxWrong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWrong.FormattingEnabled = true;
            this.comboBoxWrong.Items.AddRange(new object[] {
            "C",
            "T",
            "A",
            "G"});
            this.comboBoxWrong.Location = new System.Drawing.Point(178, 18);
            this.comboBoxWrong.Name = "comboBoxWrong";
            this.comboBoxWrong.Size = new System.Drawing.Size(34, 23);
            this.comboBoxWrong.TabIndex = 11;
            this.comboBoxWrong.SelectedIndexChanged += new System.EventHandler(this.comboBoxWrong_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Разделитель";
            // 
            // comboBoxMain
            // 
            this.comboBoxMain.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBoxMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMain.FormattingEnabled = true;
            this.comboBoxMain.Items.AddRange(new object[] {
            "C",
            "T",
            "A",
            "G"});
            this.comboBoxMain.Location = new System.Drawing.Point(76, 18);
            this.comboBoxMain.Name = "comboBoxMain";
            this.comboBoxMain.Size = new System.Drawing.Size(34, 23);
            this.comboBoxMain.TabIndex = 10;
            this.comboBoxMain.SelectedIndexChanged += new System.EventHandler(this.comboBoxMain_SelectedIndexChanged);
            // 
            // comboBoxSplitter
            // 
            this.comboBoxSplitter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSplitter.FormattingEnabled = true;
            this.comboBoxSplitter.Items.AddRange(new object[] {
            ",",
            ";"});
            this.comboBoxSplitter.Location = new System.Drawing.Point(116, 105);
            this.comboBoxSplitter.Name = "comboBoxSplitter";
            this.comboBoxSplitter.Size = new System.Drawing.Size(34, 23);
            this.comboBoxSplitter.TabIndex = 12;
            this.comboBoxSplitter.SelectedIndexChanged += new System.EventHandler(this.comboBoxSplitter_SelectedIndexChanged);
            // 
            // numericUpDownRight
            // 
            this.numericUpDownRight.Location = new System.Drawing.Point(116, 76);
            this.numericUpDownRight.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRight.Name = "numericUpDownRight";
            this.numericUpDownRight.ReadOnly = true;
            this.numericUpDownRight.Size = new System.Drawing.Size(56, 23);
            this.numericUpDownRight.TabIndex = 17;
            this.numericUpDownRight.ValueChanged += new System.EventHandler(this.numericUpDownRight_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Правый контекст";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = ".";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "Норма";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(178, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 20;
            this.label7.Text = "Мутация";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 390);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(530, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(60, 17);
            this.toolStripStatusLabel1.Text = "Прогресс";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(130, 16);
            this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox1.Location = new System.Drawing.Point(3, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(524, 135);
            this.richTextBox1.TabIndex = 17;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // rich
            // 
            this.rich.Controls.Add(this.richTextBox1);
            this.rich.Dock = System.Windows.Forms.DockStyle.Top;
            this.rich.Location = new System.Drawing.Point(0, 24);
            this.rich.Name = "rich";
            this.rich.Size = new System.Drawing.Size(530, 157);
            this.rich.TabIndex = 18;
            this.rich.TabStop = false;
            this.rich.Text = "Эталонный ампликон";
            // 
            // checkBoxPairedEnd
            // 
            this.checkBoxPairedEnd.AutoSize = true;
            this.checkBoxPairedEnd.Location = new System.Drawing.Point(178, 134);
            this.checkBoxPairedEnd.Name = "checkBoxPairedEnd";
            this.checkBoxPairedEnd.Size = new System.Drawing.Size(207, 19);
            this.checkBoxPairedEnd.TabIndex = 21;
            this.checkBoxPairedEnd.Text = "Парноконцевое секвенирование";
            this.checkBoxPairedEnd.UseVisualStyleBackColor = true;
            this.checkBoxPairedEnd.CheckedChanged += new System.EventHandler(this.checkBoxPairedEnd_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 412);
            this.Controls.Add(this.rich);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(0, 358);
            this.Name = "MainForm";
            this.Text = "Главное";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRight)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.rich.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}