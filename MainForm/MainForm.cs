using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordTools;
using System.IO;
using LogWriterNameSpace;
using CommonInterfaces;

namespace TestForm
{
    public partial class MainForm : Form
    {
        private bool processedWithErrors;
        private string errorMessage;
        private bool needToBreak;
        private List<String> filesToProcess;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            // Инициализируем переменные для запуска разбора файлов
            buttonRun.Enabled = false;
            processedWithErrors = false;
            errorMessage = "";
            needToBreak = false;
            try
            {
                filesToProcess = new List<string>();
                foreach (ListViewItem currentItem in listViewFiles.Items)
                {
                    if (currentItem.Checked) filesToProcess.Add((string)currentItem.Tag);
                }
            }
            catch (Exception er)
            {
                buttonRun.Enabled = true;
                MessageBox.Show(er.Message, "Parsing result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            toolStripProgressBar1.Maximum = filesToProcess.Count;
            toolStripStatusLabel1.Text = "Processing...";
            // Запустим разбор файлов в отдельном процессе
            backgroundWorker1.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = textBoxFolderName.Text;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxFolderName.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            LogWriter logWriter = LogWriter.Instance;
            logWriter.SetLogDir("log");
            logWriter.SetLogFileName("etl_log.txt");
            logWriter.SetMaxLogAge(10); // Сбрасывать лог будем каждые 10с
            logWriter.SetQueueSize(1000); // Или по достижению очереди 1000 записей
            try
            {
                logWriter.WriteToLog("=== PROCESS STARTED ===", LogType.Info);
                WordParser lib = new WordParser();
                lib.SetLogWriter(logWriter);
                int pos = 0;
                foreach (string fileName in filesToProcess)
                {
                    lib.fileName = fileName;
                    lib.ParseFile();
                    pos++;
                    backgroundWorker1.ReportProgress(pos);
                    if (needToBreak) break;
                }
                logWriter.WriteToLog("=== PROCESS FINISHED ===", LogType.Info);
            }
            catch (Exception er)
            {
                logWriter.WriteToLog("=== PROCESS FINISHED ===", LogType.Info);
                processedWithErrors = true;
                errorMessage = er.Message;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            toolStripStatusLabel1.Text = "Processing... Processed " + e.ProgressPercentage + " file(s) of " + toolStripProgressBar1.Maximum;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonRun.Enabled = true;
            if (processedWithErrors)
            {
                MessageBox.Show(errorMessage, "Parsing result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Parsing completed", "Parsing result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            toolStripStatusLabel1.Text = "";
            toolStripProgressBar1.Value = 0;
        }

        private void TestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                e.Cancel = true;
                if (MessageBox.Show("Parsing in process. Do you want to break process after current file?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    needToBreak = true;
                }
            }
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            listViewFiles.Items.Clear();
        }

        private void textBoxFolderName_TextChanged(object sender, EventArgs e)
        {
            listViewFiles.Items.Clear();
            try
            {
                List<String> filteredFiles = Directory
                    .EnumerateFiles(@textBoxFolderName.Text) //<--- .NET 4.5
                    .Where(file => file.ToLower().EndsWith(".doc") || file.ToLower().EndsWith(".docx"))
                    .ToList();
                listViewFiles.BeginUpdate();
                foreach (string fileName in filteredFiles)
                {
                    ListViewItem newItem = listViewFiles.Items.Add(Path.GetFileName(fileName));
                    newItem.Checked = true;
                    newItem.Tag = fileName;
                    FileInfo file = new FileInfo(fileName);
                    Icon iconForFile = SystemIcons.WinLogo;
                    iconForFile = Icon.ExtractAssociatedIcon(file.FullName);
                    if (!imageListIcons.Images.ContainsKey(file.Extension))
                    {
                        iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(file.FullName);
                        imageListIcons.Images.Add(file.Extension, iconForFile);
                    }
                    newItem.ImageKey = file.Extension;
                }
                listViewFiles.EndUpdate();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Parsing result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
