using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordParser;

namespace TestForm
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            ParserLib lib = new ParserLib();
            try
            {
                lib.fileName = "E:\\Projects\\word-parser.git\\trunk\\Files for test\\opt-3.doc";
                lib.ParseFile();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Parsing error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
