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
        public int Index { get; set; }

        public int SortIndex { get; set; }

        public Image OriginalImage { get; set; }

        public string Name { get; set; }

        public FileInfo File { get; set; }

        public clsImage(int index, FileInfo file)
        {
            this.Index = index;
            this.SortIndex = index;
            this.File = file;
            this.OriginalImage = Image.FromFile(File.FullName);
            this.Name = File.Name;
        }
    }
}
