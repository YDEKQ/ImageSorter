using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;


namespace ImageSorter
{
    public class clsImage
    {
        public Image Thumbnail { get; set; }

        public string Name { get; set; }

        public FileInfo File { get; set; }

        public bool Selected { get; set; }

        public clsImage(FileInfo file)
        {
            this.File = file;
            this.Name = File.Name;
            this.Selected = false;

            Image originalImage = Image.FromFile(File.FullName);
            this.Thumbnail = CreateThumbnail(originalImage, 96);
            originalImage.Dispose();         
        }

        public static bool IsImage(FileInfo file)
        {
            if ((file != null) && (file.Exists == true))
            {
                try
                {
                    Image originalImage = Image.FromFile(file.FullName);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return false;
        }

        /// <summary>
        /// 从原始图像创建一个缩略图
        /// </summary>
        /// <param name="originalImage">从中创建缩略图的原始图像</param>
        /// <param name="imageHeight">缩略图的高度</param>
        /// <returns></returns>
        private Image CreateThumbnail(Image originalImage, int imageHeight)
        {
            float ratio = (float)originalImage.Width / originalImage.Height;
            int imageWidth = (int)(imageHeight * ratio);

            Image thumbnailImage = originalImage.GetThumbnailImage(imageWidth, imageHeight,
                new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);

            return thumbnailImage;
        }

        /// <summary>
        /// 扩展，但不是使用
        /// </summary>
        /// <returns>true</returns>
        static private bool ThumbnailCallback()
        {
            return true;
        }
    }
}
