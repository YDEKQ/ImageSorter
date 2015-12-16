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
        ImageList LargeImagelist = new ImageList();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        void Form1_Load(object sender, EventArgs e)
        {
            LargeImagelist.ImageSize = new Size(128, 96);
            LargeImagelist.ColorDepth = ColorDepth.Depth32Bit;
            this.listView1.LargeImageList = LargeImagelist;
            this.listView1.AllowDrop = true;
            this.numericUpDown1.Maximum = decimal.MaxValue;

            this.lbl_InputCheck.Text = string.Format("第一步，点“浏览”来选择带图片的文件夹。(。・・)ノ");
            this.lbl_OutputCheck.Text = string.Format("第二步，点“浏览”来选择一个文件夹存放排好序的图片。(￣︶￣)↗");

            UpdateCount();
        }

        #region 输入文件夹
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
            string inputPath = this.txt_InputPath.Text;
            if (Directory.Exists(inputPath) == true)
            {
                this.txt_InputPath.BackColor = SystemColors.Window;

                Clean();
                List<string> filePathList = Directory.GetFiles(inputPath, "*.*", SearchOption.TopDirectoryOnly).ToList();
                if ((filePathList != null) && (filePathList.Count > 0))
                    LoadImagesFromPath(filePathList);

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
        private void btn_FreshInput_Click(object sender, EventArgs e)
        {
            string inputPath = this.txt_InputPath.Text;
            if (Directory.Exists(inputPath) == true)
            {
                List<string> filePathList = Directory.GetFiles(inputPath, "*.*", SearchOption.TopDirectoryOnly).ToList();
                if ((filePathList != null) && (filePathList.Count > 0))
                {
                    foreach (var imageInfo in ImageInfoList)
                    {
                        if (filePathList.Contains(imageInfo.File.FullName) == false)
                            imageInfo.Selected = true;
                    }
                    ImageInfoList.RemoveAll(imageInfo => imageInfo.Selected == true);

                    LoadImagesFromPath(filePathList);
                }
                    
            }
        }
        #endregion

        #region 输出文件夹
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

        #region 输出
        private void btn_OK_Click(object sender, EventArgs e)
        {
            string destPath = this.txt_OutputPath.Text;
            if (Directory.Exists(destPath) == true)
            {
                if (ImageInfoList.Count > 0)
                {
                    decimal startIndex = this.numericUpDown1.Value;
                    foreach (var imageInfo in ImageInfoList)
                    {
                        FileInfo file = imageInfo.File;
                        if (file != null)
                        {
                            string newFilePath = Path.Combine(destPath, string.Format("{0:D3}_{1}", (int)(startIndex + ImageInfoList.IndexOf(imageInfo)), imageInfo.Name));
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

        #endregion

        #region 加载缩略图
        List<clsImage> ImageInfoList = new List<clsImage>();

        private void LoadImagesFromPath(List<string> filePathList)
        {
            if (filePathList != null)
            {
                foreach (var filePath in filePathList)
                {
                    FileInfo file = new FileInfo(filePath);

                    if (ImageInfoList.Exists(imageInfo => imageInfo.File.Name == file.Name) == false)
                    {
                        try
                        {
                            clsImage newImage = new clsImage(file);

                            if (checkBox1.Checked == true)
                            {
                                int headLength = newImage.Name.IndexOf('_');
                                string head = newImage.Name.Substring(0, headLength);
                                int id = 0;
                                if (int.TryParse(head, out id) == true)
                                    newImage.Name = newImage.Name.Remove(0, headLength+1);
                            }
                           
                            ImageInfoList.Add(newImage);
                        }
                        catch
                        { 
                        
                        }
                    }                        
                }

                FreshListview(ImageInfoList);
            }            
        }

        private void FreshListview(List<clsImage> imageInfoList)
        {
            LargeImagelist.Images.Clear();
            this.listView1.Items.Clear();

            if (imageInfoList != null)
            {
                foreach (var imageInfo in imageInfoList)
                {
                    this.LargeImagelist.Images.Add(imageInfo.Name, imageInfo.Thumbnail);

                    ListViewItem newItem = new ListViewItem();
                    newItem.Name = imageInfo.Name;
                    newItem.Text = imageInfo.Name;
                    newItem.ImageKey = imageInfo.Name;
                    newItem.Tag = imageInfo;
                    this.listView1.Items.Add(newItem);                    
                }
                UpdateCount();
            }
        }
        private void Clean()
        {
            ImageInfoList.Clear();
            FreshListview(ImageInfoList);
        }

        #endregion


        #region 选中
        List<clsImage> selectedImageInfoList = null;
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            clsImage imageInfo = e.Item.Tag as clsImage;
            imageInfo.Selected = e.IsSelected;

            if (this.listView1.SelectedItems.Count > 0)
                selectedImageInfoList = ImageInfoList.FindAll(image => image.Selected == true);

            UpdateCount();
        }
        #endregion

        #region 拖拽

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listView1.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(ListViewItem)) == null) return;

            Point ptScreen = new Point(e.X, e.Y);
            Point pt = listView1.PointToClient(ptScreen);
            ListViewItem destItem = listView1.GetItemAt(pt.X, pt.Y);
            if (destItem != null)
            {
                clsImage destImageInfo = destItem.Tag as clsImage;
                Insert(destItem, selectedImageInfoList);
            }
        }

        private void Insert(ListViewItem destItem, List<clsImage> selectedImageInfoList)
        {
            if (destItem == null) return;

            clsImage destImageInfo = destItem.Tag as clsImage;

            if (selectedImageInfoList == null) return;
            if (selectedImageInfoList.Count <= 0) return;
            if (selectedImageInfoList.Contains(destImageInfo) == true) return;

            ImageInfoList.RemoveAll(imageInfo => imageInfo.Selected == true);
            if (destItem.Index < ImageInfoList.Count)
                ImageInfoList.InsertRange(destItem.Index, selectedImageInfoList);
            else
                ImageInfoList.AddRange(selectedImageInfoList);

            ImageInfoList.ForEach(imageInfo => imageInfo.Selected = false);

            selectedImageInfoList = null;
            FreshListview(ImageInfoList);
        }
        #endregion

        #region 剪切
        private List<clsImage> cutImageInfoList = null;
        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
            {
                if (e.KeyCode == Keys.X)
                {
                    if ((this.selectedImageInfoList != null) && (this.selectedImageInfoList.Count > 0))
                    {
                        cutImageInfoList = new List<clsImage>();
                        cutImageInfoList.AddRange(selectedImageInfoList);
                        selectedImageInfoList = null;

                        ImageInfoList.RemoveAll(imageInfo => imageInfo.Selected == true);
                        FreshListview(ImageInfoList);
                    } 
                }
                else if (e.KeyCode == Keys.V)
                {
                    int insertIndex = ImageInfoList.FindIndex(imageInfo => imageInfo.Selected == true);
                    if (insertIndex != -1)
                    {
                        if (insertIndex < ImageInfoList.Count)
                            ImageInfoList.InsertRange(insertIndex, cutImageInfoList);
                        else
                            ImageInfoList.AddRange(cutImageInfoList);

                        ImageInfoList.ForEach(imageInfo => imageInfo.Selected = false);

                        cutImageInfoList.Clear();
                        selectedImageInfoList = null;
                        FreshListview(ImageInfoList);
                    }
                }
            }
        }
        #endregion

        private void UpdateCount()
        {
            int totalCount = (this.ImageInfoList != null) ? this.ImageInfoList.Count : 0;
            int selectCount = (this.selectedImageInfoList != null) ? this.selectedImageInfoList.Count : 0;
            int cutCount = (this.cutImageInfoList != null) ? this.cutImageInfoList.Count : 0;

            this.lbl_ImageCount.Text = string.Format("Count：{0} 选中：{1} 剪切：{2}", totalCount, selectCount, cutCount);
        }










    }
}
