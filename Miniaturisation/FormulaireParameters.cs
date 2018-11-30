using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace Miniaturisation
{
    public partial class FormulaireParameters : Form
    {
        public FormulaireParameters()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var folder = this.GenerateImages(txtFolder.Text, int.Parse(txtHeight.Text), int.Parse(txtWidth.Text), checkBoxSubFolder.Checked);
            var dialogSuccess = new FormSuccess();
            dialogSuccess.FolderLinkValue = folder;
            dialogSuccess.Show();
        }

        private void btnOpenBrowser_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private string GenerateImages(string folder, int height, int width, bool subFolders)
        {
            foreach (var image in Directory.GetFiles(folder, "*.JPG", subFolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))
            {
                var img = Image.FromFile(image);
                var filePath = Path.GetDirectoryName(image);
                var filenameMini = string.Format("{0}_{1}_{2}{3}", Path.GetFileNameWithoutExtension(image), height, width, Path.GetExtension(image));
                var directoryMini = string.Format(@"{0}\{1}_{2}", filePath, height, width);
                if (!Directory.Exists(directoryMini))
                {
                    Directory.CreateDirectory(directoryMini);
                }

                var resizedImg = img.ScaleImage(width, height);
                resizedImg.Save(string.Format(@"{0}\{1}", directoryMini, filenameMini));
                resizedImg.Dispose();
                img.Dispose();
            }

            return folder;
        }
    }
}
