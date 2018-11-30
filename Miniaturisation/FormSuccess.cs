using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Miniaturisation
{
    public partial class FormSuccess : Form
    {
        public FormSuccess()
        {
            InitializeComponent();
        }
        
        public string FolderLinkValue
        {
            get { return txtFolderLink.Text; }
            set { txtFolderLink.Text = value; }
        }

        private void txtFolderLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(txtFolderLink.Text);
        }
    }
}
