namespace MainFormNS
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonRun = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.imageListMain = new System.Windows.Forms.ImageList(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.imageListIcons = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.tabPageLogParams = new System.Windows.Forms.TabPage();
            this.listViewFiles = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxFolderName = new System.Windows.Forms.TextBox();
            this.labelLogDirectory = new System.Windows.Forms.Label();
            this.labelLogFileSuffix = new System.Windows.Forms.Label();
            this.labelLogAge = new System.Windows.Forms.Label();
            this.labelQueueSize = new System.Windows.Forms.Label();
            this.textBoxLogDir = new System.Windows.Forms.TextBox();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.buttonLogDir = new System.Windows.Forms.Button();
            this.numericUpDownMaxLogAge = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownQueueSize = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxUseExternalLibrary = new System.Windows.Forms.CheckBox();
            this.labelExternalLogLib = new System.Windows.Forms.Label();
            this.textBoxExternalLogLib = new System.Windows.Forms.TextBox();
            this.buttonExternalLogLib = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPageLogParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxLogAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQueueSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRun
            // 
            this.buttonRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRun.Location = new System.Drawing.Point(12, 376);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 0;
            this.buttonRun.Text = "Run test";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 406);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(659, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClose.Location = new System.Drawing.Point(93, 376);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // imageListMain
            // 
            this.imageListMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMain.ImageStream")));
            this.imageListMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMain.Images.SetKeyName(0, "folder.png");
            this.imageListMain.Images.SetKeyName(1, "file_sys.gif");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // imageListIcons
            // 
            this.imageListIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageMain);
            this.tabControl1.Controls.Add(this.tabPageLogParams);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(659, 370);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.listViewFiles);
            this.tabPageMain.Controls.Add(this.label1);
            this.tabPageMain.Controls.Add(this.button1);
            this.tabPageMain.Controls.Add(this.textBoxFolderName);
            this.tabPageMain.Location = new System.Drawing.Point(4, 22);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(648, 344);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "MainPage";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // tabPageLogParams
            // 
            this.tabPageLogParams.Controls.Add(this.buttonSave);
            this.tabPageLogParams.Controls.Add(this.groupBox1);
            this.tabPageLogParams.Controls.Add(this.numericUpDownQueueSize);
            this.tabPageLogParams.Controls.Add(this.numericUpDownMaxLogAge);
            this.tabPageLogParams.Controls.Add(this.buttonLogDir);
            this.tabPageLogParams.Controls.Add(this.textBoxFileName);
            this.tabPageLogParams.Controls.Add(this.textBoxLogDir);
            this.tabPageLogParams.Controls.Add(this.labelQueueSize);
            this.tabPageLogParams.Controls.Add(this.labelLogAge);
            this.tabPageLogParams.Controls.Add(this.labelLogFileSuffix);
            this.tabPageLogParams.Controls.Add(this.labelLogDirectory);
            this.tabPageLogParams.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogParams.Name = "tabPageLogParams";
            this.tabPageLogParams.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogParams.Size = new System.Drawing.Size(651, 344);
            this.tabPageLogParams.TabIndex = 1;
            this.tabPageLogParams.Text = "Log file parameters";
            this.tabPageLogParams.UseVisualStyleBackColor = true;
            // 
            // listViewFiles
            // 
            this.listViewFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFiles.CheckBoxes = true;
            this.listViewFiles.LargeImageList = this.imageListIcons;
            this.listViewFiles.Location = new System.Drawing.Point(9, 50);
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.Size = new System.Drawing.Size(631, 288);
            this.listViewFiles.SmallImageList = this.imageListIcons;
            this.listViewFiles.TabIndex = 10;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = System.Windows.Forms.View.SmallIcon;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Folder with source files";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.ImageIndex = 0;
            this.button1.ImageList = this.imageListMain;
            this.button1.Location = new System.Drawing.Point(603, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 23);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxFolderName
            // 
            this.textBoxFolderName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFolderName.Location = new System.Drawing.Point(9, 24);
            this.textBoxFolderName.Name = "textBoxFolderName";
            this.textBoxFolderName.Size = new System.Drawing.Size(587, 20);
            this.textBoxFolderName.TabIndex = 7;
            this.textBoxFolderName.TextChanged += new System.EventHandler(this.textBoxFolderName_TextChanged);
            // 
            // labelLogDirectory
            // 
            this.labelLogDirectory.AutoSize = true;
            this.labelLogDirectory.Location = new System.Drawing.Point(8, 14);
            this.labelLogDirectory.Name = "labelLogDirectory";
            this.labelLogDirectory.Size = new System.Drawing.Size(86, 13);
            this.labelLogDirectory.TabIndex = 0;
            this.labelLogDirectory.Text = "Directory for logs";
            // 
            // labelLogFileSuffix
            // 
            this.labelLogFileSuffix.AutoSize = true;
            this.labelLogFileSuffix.Location = new System.Drawing.Point(8, 40);
            this.labelLogFileSuffix.Name = "labelLogFileSuffix";
            this.labelLogFileSuffix.Size = new System.Drawing.Size(68, 13);
            this.labelLogFileSuffix.TabIndex = 1;
            this.labelLogFileSuffix.Text = "Log file suffix";
            // 
            // labelLogAge
            // 
            this.labelLogAge.AutoSize = true;
            this.labelLogAge.Location = new System.Drawing.Point(8, 68);
            this.labelLogAge.Name = "labelLogAge";
            this.labelLogAge.Size = new System.Drawing.Size(194, 13);
            this.labelLogAge.TabIndex = 2;
            this.labelLogAge.Text = "Period in sec. between saving log to file";
            // 
            // labelQueueSize
            // 
            this.labelQueueSize.AutoSize = true;
            this.labelQueueSize.Location = new System.Drawing.Point(8, 99);
            this.labelQueueSize.Name = "labelQueueSize";
            this.labelQueueSize.Size = new System.Drawing.Size(173, 13);
            this.labelQueueSize.TabIndex = 3;
            this.labelQueueSize.Text = "Log queue size for saving log to file";
            // 
            // textBoxLogDir
            // 
            this.textBoxLogDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLogDir.Location = new System.Drawing.Point(102, 11);
            this.textBoxLogDir.Name = "textBoxLogDir";
            this.textBoxLogDir.Size = new System.Drawing.Size(489, 20);
            this.textBoxLogDir.TabIndex = 4;
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileName.Location = new System.Drawing.Point(102, 37);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(489, 20);
            this.textBoxFileName.TabIndex = 5;
            // 
            // buttonLogDir
            // 
            this.buttonLogDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogDir.ImageIndex = 0;
            this.buttonLogDir.ImageList = this.imageListMain;
            this.buttonLogDir.Location = new System.Drawing.Point(597, 8);
            this.buttonLogDir.Name = "buttonLogDir";
            this.buttonLogDir.Size = new System.Drawing.Size(37, 23);
            this.buttonLogDir.TabIndex = 9;
            this.buttonLogDir.UseVisualStyleBackColor = true;
            // 
            // numericUpDownMaxLogAge
            // 
            this.numericUpDownMaxLogAge.Location = new System.Drawing.Point(208, 66);
            this.numericUpDownMaxLogAge.Name = "numericUpDownMaxLogAge";
            this.numericUpDownMaxLogAge.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMaxLogAge.TabIndex = 10;
            // 
            // numericUpDownQueueSize
            // 
            this.numericUpDownQueueSize.Location = new System.Drawing.Point(208, 97);
            this.numericUpDownQueueSize.Name = "numericUpDownQueueSize";
            this.numericUpDownQueueSize.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownQueueSize.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonExternalLogLib);
            this.groupBox1.Controls.Add(this.textBoxExternalLogLib);
            this.groupBox1.Controls.Add(this.labelExternalLogLib);
            this.groupBox1.Controls.Add(this.checkBoxUseExternalLibrary);
            this.groupBox1.Location = new System.Drawing.Point(11, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 110);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "External log library";
            // 
            // checkBoxUseExternalLibrary
            // 
            this.checkBoxUseExternalLibrary.AutoSize = true;
            this.checkBoxUseExternalLibrary.Location = new System.Drawing.Point(6, 29);
            this.checkBoxUseExternalLibrary.Name = "checkBoxUseExternalLibrary";
            this.checkBoxUseExternalLibrary.Size = new System.Drawing.Size(187, 17);
            this.checkBoxUseExternalLibrary.TabIndex = 0;
            this.checkBoxUseExternalLibrary.Text = "Use external library for log process";
            this.checkBoxUseExternalLibrary.UseVisualStyleBackColor = true;
            this.checkBoxUseExternalLibrary.CheckStateChanged += new System.EventHandler(this.checkBoxUseExternalLibrary_CheckStateChanged);
            // 
            // labelExternalLogLib
            // 
            this.labelExternalLogLib.AutoSize = true;
            this.labelExternalLogLib.Location = new System.Drawing.Point(6, 59);
            this.labelExternalLogLib.Name = "labelExternalLogLib";
            this.labelExternalLogLib.Size = new System.Drawing.Size(132, 13);
            this.labelExternalLogLib.TabIndex = 1;
            this.labelExternalLogLib.Text = "File with external log library";
            // 
            // textBoxExternalLogLib
            // 
            this.textBoxExternalLogLib.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxExternalLogLib.Location = new System.Drawing.Point(144, 56);
            this.textBoxExternalLogLib.Name = "textBoxExternalLogLib";
            this.textBoxExternalLogLib.Size = new System.Drawing.Size(436, 20);
            this.textBoxExternalLogLib.TabIndex = 5;
            // 
            // buttonExternalLogLib
            // 
            this.buttonExternalLogLib.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExternalLogLib.ImageIndex = 1;
            this.buttonExternalLogLib.ImageList = this.imageListMain;
            this.buttonExternalLogLib.Location = new System.Drawing.Point(586, 54);
            this.buttonExternalLogLib.Name = "buttonExternalLogLib";
            this.buttonExternalLogLib.Size = new System.Drawing.Size(37, 23);
            this.buttonExternalLogLib.TabIndex = 10;
            this.buttonExternalLogLib.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(565, 239);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 428);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonRun);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETL form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestForm_FormClosing);
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            this.tabPageLogParams.ResumeLayout(false);
            this.tabPageLogParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxLogAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQueueSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ImageList imageListMain;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ImageList imageListIcons;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.ListView listViewFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxFolderName;
        private System.Windows.Forms.TabPage tabPageLogParams;
        private System.Windows.Forms.TextBox textBoxLogDir;
        private System.Windows.Forms.Label labelQueueSize;
        private System.Windows.Forms.Label labelLogAge;
        private System.Windows.Forms.Label labelLogFileSuffix;
        private System.Windows.Forms.Label labelLogDirectory;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxLogAge;
        private System.Windows.Forms.Button buttonLogDir;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.NumericUpDown numericUpDownQueueSize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelExternalLogLib;
        private System.Windows.Forms.CheckBox checkBoxUseExternalLibrary;
        private System.Windows.Forms.Button buttonExternalLogLib;
        private System.Windows.Forms.TextBox textBoxExternalLogLib;
        private System.Windows.Forms.Button buttonSave;
    }
}

