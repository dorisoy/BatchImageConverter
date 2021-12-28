namespace BatchImageConverter
{
    partial class UDirTree
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UDirTree));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 36;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(240, 240);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "drive.ico");
            this.imageList1.Images.SetKeyName(1, "Floppy.ico");
            this.imageList1.Images.SetKeyName(2, "folder.gif");
            this.imageList1.Images.SetKeyName(3, "Folder2.ico");
            this.imageList1.Images.SetKeyName(4, "text.gif");
            this.imageList1.Images.SetKeyName(5, "xml.ico");
            this.imageList1.Images.SetKeyName(6, "zip.gif");
            this.imageList1.Images.SetKeyName(7, "audio.gif");
            this.imageList1.Images.SetKeyName(8, "avi.gif");
            this.imageList1.Images.SetKeyName(9, "bmp.gif");
            this.imageList1.Images.SetKeyName(10, "doc.gif");
            this.imageList1.Images.SetKeyName(11, "exe.gif");
            this.imageList1.Images.SetKeyName(12, "gif.gif");
            this.imageList1.Images.SetKeyName(13, "jpg.gif");
            this.imageList1.Images.SetKeyName(14, "mid.gif");
            this.imageList1.Images.SetKeyName(15, "mp3.gif");
            this.imageList1.Images.SetKeyName(16, "Notepad2.ico");
            this.imageList1.Images.SetKeyName(17, "Page4.ico");
            this.imageList1.Images.SetKeyName(18, "Page9.ico");
            this.imageList1.Images.SetKeyName(19, "Page11.ico");
            this.imageList1.Images.SetKeyName(20, "Page13.ico");
            this.imageList1.Images.SetKeyName(21, "page34.ico");
            this.imageList1.Images.SetKeyName(22, "Page40.ico");
            this.imageList1.Images.SetKeyName(23, "page41.ico");
            this.imageList1.Images.SetKeyName(24, "Page42.ico");
            this.imageList1.Images.SetKeyName(25, "pdf.gif");
            this.imageList1.Images.SetKeyName(26, "rar.gif");
            this.imageList1.Images.SetKeyName(27, "Page19.ico");
            this.imageList1.Images.SetKeyName(28, "Page51.ico");
            this.imageList1.Images.SetKeyName(29, "Page66.ico");
            this.imageList1.Images.SetKeyName(30, "Powerpoint3.ico");
            this.imageList1.Images.SetKeyName(31, "vb3.ico");
            this.imageList1.Images.SetKeyName(32, "!3.ico");
            this.imageList1.Images.SetKeyName(33, "access 005.ico");
            this.imageList1.Images.SetKeyName(34, "Excel 002.ico");
            this.imageList1.Images.SetKeyName(35, "MS-DOS Application.ico");
            this.imageList1.Images.SetKeyName(36, "short2.ico");
            this.imageList1.Images.SetKeyName(37, "cd-rom.ico");
            this.imageList1.Images.SetKeyName(38, "removable.ico");
            this.imageList1.Images.SetKeyName(39, "desktop.ico");
            this.imageList1.Images.SetKeyName(40, "document.ico");
            this.imageList1.Images.SetKeyName(41, "pictures.ico");
            this.imageList1.Images.SetKeyName(42, "recent.ico");
            this.imageList1.Images.SetKeyName(43, "apps.ico");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.ForeColor = System.Drawing.Color.Lime;
            this.progressBar1.Location = new System.Drawing.Point(0, 225);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(240, 15);
            this.progressBar1.TabIndex = 1;
            // 
            // UDirTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.treeView1);
            this.Name = "UDirTree";
            this.Size = new System.Drawing.Size(240, 240);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
