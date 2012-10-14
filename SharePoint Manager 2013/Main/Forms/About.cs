using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Keutmann.SharePointManager.Library;
using System.IO;

namespace Keutmann.SharePointManager.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            InitializeInterfaceStrings();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeInterfaceStrings()
        {
            btnOK.Text          = SPMLocalization.GetString("Interface_Ok");
            
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\Documents\License.txt");
            if(File.Exists(path))
            {
                textBox1.Text = File.ReadAllText(path);
            }
            //richTextBox1.Text   = SPMLocalization.GetString("Intervace_About_Text");
            this.Text           = SPMLocalization.GetString("Interface_About");
        }
    }
}