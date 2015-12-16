namespace ImageSorter
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_InputView = new System.Windows.Forms.Button();
            this.btn_OutputView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_InputPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.txt_OutputPath = new System.Windows.Forms.TextBox();
            this.lbl_InputCheck = new System.Windows.Forms.Label();
            this.lbl_OutputCheck = new System.Windows.Forms.Label();
            this.btn_FreshInput = new System.Windows.Forms.Button();
            this.lbl_ImageCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.clsImageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsImageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listView1.AllowDrop = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.tableLayoutPanel1.SetColumnSpan(this.listView1, 6);
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 55);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(943, 606);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.Controls.Add(this.listView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_InputView, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_OutputView, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_InputPath, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_OK, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.txt_OutputPath, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_InputCheck, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_OutputCheck, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_FreshInput, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbl_ImageCount, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown1, 3, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(949, 694);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btn_InputView
            // 
            this.btn_InputView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_InputView.Location = new System.Drawing.Point(395, 1);
            this.btn_InputView.Margin = new System.Windows.Forms.Padding(1);
            this.btn_InputView.Name = "btn_InputView";
            this.btn_InputView.Size = new System.Drawing.Size(78, 24);
            this.btn_InputView.TabIndex = 1;
            this.btn_InputView.Text = "浏览";
            this.btn_InputView.UseVisualStyleBackColor = true;
            this.btn_InputView.Click += new System.EventHandler(this.btn_InputView_Click);
            // 
            // btn_OutputView
            // 
            this.btn_OutputView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_OutputView.Location = new System.Drawing.Point(869, 1);
            this.btn_OutputView.Margin = new System.Windows.Forms.Padding(1);
            this.btn_OutputView.Name = "btn_OutputView";
            this.btn_OutputView.Size = new System.Drawing.Size(79, 24);
            this.btn_OutputView.TabIndex = 2;
            this.btn_OutputView.Text = "浏览";
            this.btn_OutputView.UseVisualStyleBackColor = true;
            this.btn_OutputView.Click += new System.EventHandler(this.btn_OutputView_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "输入文件夹";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_InputPath
            // 
            this.txt_InputPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_InputPath.Location = new System.Drawing.Point(83, 3);
            this.txt_InputPath.Name = "txt_InputPath";
            this.txt_InputPath.Size = new System.Drawing.Size(308, 21);
            this.txt_InputPath.TabIndex = 4;
            this.txt_InputPath.TextChanged += new System.EventHandler(this.txt_InputPath_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(477, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "输出文件夹";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_OK
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btn_OK, 2);
            this.btn_OK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_OK.Enabled = false;
            this.btn_OK.Location = new System.Drawing.Point(555, 665);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(1);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(393, 28);
            this.btn_OK.TabIndex = 6;
            this.btn_OK.Text = "我排好了 <(￣︶￣)↗[GO!]";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // txt_OutputPath
            // 
            this.txt_OutputPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_OutputPath.Location = new System.Drawing.Point(557, 3);
            this.txt_OutputPath.Name = "txt_OutputPath";
            this.txt_OutputPath.Size = new System.Drawing.Size(308, 21);
            this.txt_OutputPath.TabIndex = 7;
            this.txt_OutputPath.TextChanged += new System.EventHandler(this.txt_OutputPath_TextChanged);
            // 
            // lbl_InputCheck
            // 
            this.lbl_InputCheck.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lbl_InputCheck, 2);
            this.lbl_InputCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_InputCheck.Location = new System.Drawing.Point(83, 26);
            this.lbl_InputCheck.Name = "lbl_InputCheck";
            this.lbl_InputCheck.Size = new System.Drawing.Size(388, 26);
            this.lbl_InputCheck.TabIndex = 8;
            this.lbl_InputCheck.Text = "label3";
            this.lbl_InputCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_OutputCheck
            // 
            this.lbl_OutputCheck.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lbl_OutputCheck, 2);
            this.lbl_OutputCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_OutputCheck.Location = new System.Drawing.Point(557, 26);
            this.lbl_OutputCheck.Name = "lbl_OutputCheck";
            this.lbl_OutputCheck.Size = new System.Drawing.Size(389, 26);
            this.lbl_OutputCheck.TabIndex = 9;
            this.lbl_OutputCheck.Text = "label4";
            this.lbl_OutputCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_FreshInput
            // 
            this.btn_FreshInput.Location = new System.Drawing.Point(3, 667);
            this.btn_FreshInput.Name = "btn_FreshInput";
            this.btn_FreshInput.Size = new System.Drawing.Size(74, 23);
            this.btn_FreshInput.TabIndex = 10;
            this.btn_FreshInput.Text = "刷新";
            this.btn_FreshInput.UseVisualStyleBackColor = true;
            this.btn_FreshInput.Click += new System.EventHandler(this.btn_FreshInput_Click);
            // 
            // lbl_ImageCount
            // 
            this.lbl_ImageCount.AutoSize = true;
            this.lbl_ImageCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ImageCount.Location = new System.Drawing.Point(83, 664);
            this.lbl_ImageCount.Name = "lbl_ImageCount";
            this.lbl_ImageCount.Size = new System.Drawing.Size(308, 30);
            this.lbl_ImageCount.TabIndex = 11;
            this.lbl_ImageCount.Text = "Count：0";
            this.lbl_ImageCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(397, 664);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 30);
            this.label3.TabIndex = 12;
            this.label3.Text = "输出序号:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(477, 667);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(74, 21);
            this.numericUpDown1.TabIndex = 13;
            // 
            // clsImageBindingSource
            // 
            this.clsImageBindingSource.DataSource = typeof(ImageSorter.clsImage);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 694);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "我可是一个正经的图片排序小能手呢 ～(￣▽￣～)(～￣▽￣)～";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsImageBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource clsImageBindingSource;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_InputView;
        private System.Windows.Forms.Button btn_OutputView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_InputPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.TextBox txt_OutputPath;
        private System.Windows.Forms.Label lbl_InputCheck;
        private System.Windows.Forms.Label lbl_OutputCheck;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btn_FreshInput;
        private System.Windows.Forms.Label lbl_ImageCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;



    }
}

