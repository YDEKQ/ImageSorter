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

namespace ImageSorter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        void Form1_Load(object sender, EventArgs e)
        {
            this.lbl_InputCheck.Text = string.Format("第一步，点“浏览”来选择带图片的文件夹。(。・・)ノ");
            this.lbl_OutputCheck.Text = string.Format("第二步，点“浏览”来选择一个文件夹存放排好序的图片。(￣︶￣)↗");
            this.listView1.MouseDown += listView1_MouseDown;
            this.listView1.MouseUp += listView1_MouseUp;
        }

        #region 输入
        private void btn_InputView_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.txt_InputPath.Text = "";
                this.txt_InputPath.Text = fbd.SelectedPath;
            }
        }
        private void txt_InputPath_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(this.txt_InputPath.Text) == true)
            {
                this.txt_InputPath.BackColor = SystemColors.Window;
                LoadImagesFromPath(this.txt_InputPath.Text);

                if (listView1.Items.Count > 0)
                {
                    this.lbl_InputCheck.Text = string.Format("嗯，很乖~你选的文件夹已经加载了。╰(￣▽￣)╭");
                    this.lbl_InputCheck.BackColor = Color.LightGreen;
                    this.btn_OK.Enabled = true;
                }
                else
                {
                    this.lbl_InputCheck.Text = string.Format("喂，说好的图片呢？？没有图还排个毛线。(#￣～￣#)");
                    this.lbl_InputCheck.BackColor = Color.LightSteelBlue;
                    this.btn_OK.Enabled = false;
                }

            }
            else
            {
                this.txt_InputPath.BackColor = Color.Yellow;
                this.lbl_InputCheck.Text = string.Format("别！玩！我！ε=怒ε=怒ε=怒ε=怒ε=( o｀ω′)ノ");
                this.lbl_InputCheck.BackColor = Color.OrangeRed;
            }
                
        }
        #endregion

        #region 输出
        private void btn_OutputView_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.txt_OutputPath.Text = "";
                this.txt_OutputPath.Text = fbd.SelectedPath;
            }
        }
        private void txt_OutputPath_TextChanged(object sender, EventArgs e)
        {
            string destPath = this.txt_OutputPath.Text;
            if (Directory.Exists(destPath) == true)
            {
                this.txt_OutputPath.BackColor = SystemColors.Window;
                string[] files = Directory.GetFiles(destPath);
                if ((files != null) && (files.Length > 0))
                {
                    this.lbl_OutputCheck.Text = string.Format("这个文件夹不是空的诶，确定吗？(⊙_⊙)?");
                    this.lbl_OutputCheck.BackColor = Color.LightSteelBlue;
                }
                    
                else
                {
                    this.lbl_OutputCheck.Text = string.Format("朕也同意用这个文件夹。(*￣3￣)╭");
                    this.lbl_OutputCheck.BackColor =  Color.LightGreen;
                }
                    
            }
            else
            {
                this.txt_OutputPath.BackColor = Color.Yellow;
                this.lbl_OutputCheck.Text = string.Format("这个文件夹根本就木有！！坏人～(　TロT)σ");
                this.lbl_OutputCheck.BackColor = Color.OrangeRed;
            }
                
        }
        #endregion


        private void btn_OK_Click(object sender, EventArgs e)
        {
            string destPath = this.txt_OutputPath.Text;
            if (Directory.Exists(destPath) == true)
            {
                if(listView1.Items.Count>0)
                {
                    foreach (ListViewItem item in listView1.Items)
                    {
                        FileInfo file = item.Tag as FileInfo;
                        if (file != null)
                        {
                            string newFilePath = Path.Combine(destPath, string.Format("{0}_{1}", item.Index, file.Name));
                            file.CopyTo(newFilePath, true);
                        }
                    }
                    System.Diagnostics.Process.Start("explorer.exe", destPath);
                }
                else
                    MessageBox.Show("根本就没有图好吗？？哼！(＠￣ー￣＠)");

            }
            else
                MessageBox.Show("输出文件夹不存在？？你让我往哪儿存？！\n(╯‵□′)╯︵┻━┻");

        }

        ImageList LargeImagelist = new ImageList();

        private void LoadImagesFromPath(string path)
        {
            LargeImagelist.ImageSize = new Size(256, 192);
            LargeImagelist.Images.Clear();
            this.listView1.Items.Clear();

            List<string> filePathList = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).ToList();
            if (filePathList != null)
            {
                foreach (var filePath in filePathList)
                {
                    try
                    {
                        FileInfo file = new FileInfo(filePath);
                        Image image = Image.FromFile(filePath);

                        LargeImagelist.Images.Add(image);
                        ListViewItem newItem = new ListViewItem();
                        newItem.ImageIndex = LargeImagelist.Images.Count - 1;
                        newItem.Text = file.Name;
                        newItem.Tag = file;
                        this.listView1.Items.Add(newItem);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            this.listView1.LargeImageList = LargeImagelist;
        }

        #region 交换
        ListViewItem dragItem = null;
        ListViewItem destItem = null;

        void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragItem = listView1.GetItemAt(e.X, e.Y);
            }
        }
        void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                destItem = listView1.GetItemAt(e.X, e.Y);
                if ((dragItem != null) && (destItem != null) && (dragItem != destItem))
                {
                    int dragImageIndex = dragItem.ImageIndex;
                    string dragName = dragItem.Text;
                    FileInfo dragfile = dragItem.Tag as FileInfo;

                    int destImageIndex = destItem.ImageIndex;
                    string destName = destItem.Text;
                    FileInfo destfile = destItem.Tag as FileInfo;

                    dragItem.ImageIndex = destImageIndex;
                    dragItem.Text = destName;
                    dragItem.Tag = destfile;

                    destItem.ImageIndex = dragImageIndex;
                    destItem.Text = dragName;
                    destItem.Tag = dragfile;
                }
            }
        }
        #endregion
    }
}
