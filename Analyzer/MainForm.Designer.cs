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
            this.textBox_Position = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выбратьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьОтчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLContext = new System.Windows.Forms.TextBox();
            this.textBoxRContext = new System.Windows.Forms.TextBox();
            this.comboBoxMain = new System.Windows.Forms.ComboBox();
            this.comboBoxWrong = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.checkBoxLeft = new System.Windows.Forms.CheckBox();
            this.checkBoxRight = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Position
            // 
            this.textBox_Position.Location = new System.Drawing.Point(124, 3);
            this.textBox_Position.Name = "textBox_Position";
            this.textBox_Position.Size = new System.Drawing.Size(94, 23);
            this.textBox_Position.TabIndex = 1;
            this.textBox_Position.Text = "112";
            this.textBox_Position.TextChanged += new System.EventHandler(this.textBox_Position_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 6);
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
            this.menuStrip1.Size = new System.Drawing.Size(267, 24);
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
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
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
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.textBox_Position, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(243, 100);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Левый контекст";
            // 
            // textBoxLContext
            // 
            this.textBoxLContext.Location = new System.Drawing.Point(12, 180);
            this.textBoxLContext.Name = "textBoxLContext";
            this.textBoxLContext.Size = new System.Drawing.Size(100, 23);
            this.textBoxLContext.TabIndex = 5;
            this.textBoxLContext.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxLContext.TextChanged += new System.EventHandler(this.textBoxLContext_TextChanged);
            // 
            // textBoxRContext
            // 
            this.textBoxRContext.Location = new System.Drawing.Point(158, 180);
            this.textBoxRContext.Name = "textBoxRContext";
            this.textBoxRContext.Size = new System.Drawing.Size(100, 23);
            this.textBoxRContext.TabIndex = 7;
            this.textBoxRContext.TextChanged += new System.EventHandler(this.textBoxRContext_TextChanged);
            // 
            // comboBoxMain
            // 
            this.comboBoxMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMain.FormattingEnabled = true;
            this.comboBoxMain.Items.AddRange(new object[] {
            "C",
            "T",
            "A",
            "G"});
            this.comboBoxMain.Location = new System.Drawing.Point(118, 180);
            this.comboBoxMain.Name = "comboBoxMain";
            this.comboBoxMain.Size = new System.Drawing.Size(34, 23);
            this.comboBoxMain.TabIndex = 10;
            this.comboBoxMain.SelectedIndexChanged += new System.EventHandler(this.comboBoxMain_SelectedIndexChanged);
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
            this.comboBoxWrong.Location = new System.Drawing.Point(118, 209);
            this.comboBoxWrong.Name = "comboBoxWrong";
            this.comboBoxWrong.Size = new System.Drawing.Size(34, 23);
            this.comboBoxWrong.TabIndex = 11;
            this.comboBoxWrong.SelectedIndexChanged += new System.EventHandler(this.comboBoxWrong_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 297);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(267, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel1.Text = "Прцесс";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(130, 16);
            // 
            // checkBoxLeft
            // 
            this.checkBoxLeft.AutoSize = true;
            this.checkBoxLeft.Enabled = false;
            this.checkBoxLeft.Location = new System.Drawing.Point(15, 247);
            this.checkBoxLeft.Name = "checkBoxLeft";
            this.checkBoxLeft.Size = new System.Drawing.Size(173, 19);
            this.checkBoxLeft.TabIndex = 13;
            this.checkBoxLeft.Text = "Учитывать левый контекст";
            this.checkBoxLeft.UseVisualStyleBackColor = true;
            this.checkBoxLeft.CheckedChanged += new System.EventHandler(this.checkBoxLeft_CheckedChanged);
            // 
            // checkBoxRight
            // 
            this.checkBoxRight.AutoSize = true;
            this.checkBoxRight.Enabled = false;
            this.checkBoxRight.Location = new System.Drawing.Point(15, 272);
            this.checkBoxRight.Name = "checkBoxRight";
            this.checkBoxRight.Size = new System.Drawing.Size(180, 19);
            this.checkBoxRight.TabIndex = 14;
            this.checkBoxRight.Text = "Учитывать правый контекст";
            this.checkBoxRight.UseVisualStyleBackColor = true;
            this.checkBoxRight.CheckedChanged += new System.EventHandler(this.checkBoxRight_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Правый контекст";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 319);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxRight);
            this.Controls.Add(this.checkBoxLeft);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.comboBoxWrong);
            this.Controls.Add(this.comboBoxMain);
            this.Controls.Add(this.textBoxRContext);
            this.Controls.Add(this.textBoxLContext);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(283, 358);
            this.MinimumSize = new System.Drawing.Size(283, 358);
            this.Name = "MainForm";
            this.Text = "Главное";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox_Position;
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem выбратьФайлToolStripMenuItem;
        private OpenFileDialog openFileDialog;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private TextBox textBoxLContext;
        private TextBox textBoxRContext;
        private ComboBox comboBoxMain;
        private ComboBox comboBoxWrong;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem открытьОтчетыToolStripMenuItem;
        private ToolStripMenuItem открытьОдинToolStripMenuItem;
        private ToolStripMenuItem открытьГруппуToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripProgressBar toolStripProgressBar;
        private CheckBox checkBoxLeft;
        private CheckBox checkBoxRight;
        private Label label3;
    }
}