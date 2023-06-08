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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string folderImagePath = "folder.png";
            string fileImagePath = "file.png";
            ImageList imageList = new ImageList();
            imageList.Images.Add("folder", Image.FromFile(folderImagePath));
            imageList.Images.Add("file", Image.FromFile(fileImagePath));
            treeView1.ImageList = imageList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string rootPath = @"C:\Program Files (Arm)\";

            TreeNode rootNode = new TreeNode(rootPath, 0, 0);
            treeView1.Nodes.Add(rootNode);

            LoadDirectory(rootNode, rootPath);
        }

        private void LoadDirectory(TreeNode parentNode, string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
            {
                TreeNode directoryNode = new TreeNode(dir.Name, 0, 0);
                parentNode.Nodes.Add(directoryNode);

                LoadDirectory(directoryNode, dir.FullName);
            }

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                TreeNode fileNode = new TreeNode(file.Name, 1, 1);
                parentNode.Nodes.Add(fileNode);
            }
        }
    }
}