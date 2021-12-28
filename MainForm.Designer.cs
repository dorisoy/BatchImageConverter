namespace BatchImageConverter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Addfile = new System.Windows.Forms.ToolStripButton();
            this.Adddir = new System.Windows.Forms.ToolStripButton();
            this.Go = new System.Windows.Forms.ToolStripButton();
            this.Settings = new System.Windows.Forms.ToolStripButton();
            this.WorkPanel = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rmoveProcessedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elaborationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suspendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authorSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ImageContainer = new BatchImageConverter.UImageContainer();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Addfile,
            this.Adddir,
            this.Go,
            this.Settings,
            this.WorkPanel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 32);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1866, 33);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Addfile
            // 
            this.Addfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Addfile.Image = global::BatchImageConverter.Properties.Resources.files;
            this.Addfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Addfile.Name = "Addfile";
            this.Addfile.Size = new System.Drawing.Size(34, 28);
            this.Addfile.Text = "添加文件";
            this.Addfile.Click += new System.EventHandler(this.Addfile_Click);
            // 
            // Adddir
            // 
            this.Adddir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Adddir.Image = global::BatchImageConverter.Properties.Resources.open;
            this.Adddir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Adddir.Name = "Adddir";
            this.Adddir.Size = new System.Drawing.Size(34, 28);
            this.Adddir.Text = "添加目录";
            this.Adddir.Click += new System.EventHandler(this.Adddir_Click);
            // 
            // Go
            // 
            this.Go.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Go.Image = global::BatchImageConverter.Properties.Resources.down;
            this.Go.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(34, 28);
            this.Go.Text = "开始优化";
            this.Go.Click += new System.EventHandler(this.Go_Click);
            // 
            // Settings
            // 
            this.Settings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Settings.Image = global::BatchImageConverter.Properties.Resources.control;
            this.Settings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(34, 28);
            this.Settings.Text = "设置视图";
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // WorkPanel
            // 
            this.WorkPanel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.WorkPanel.Image = global::BatchImageConverter.Properties.Resources.office;
            this.WorkPanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.WorkPanel.Name = "WorkPanel";
            this.WorkPanel.Size = new System.Drawing.Size(34, 28);
            this.WorkPanel.Text = "列表视图";
            this.WorkPanel.Click += new System.EventHandler(this.WorkPanel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.elaborationToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1866, 32);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFilesToolStripMenuItem,
            this.importDirectoryToolStripMenuItem,
            this.saveSettingsToolStripMenuItem,
            this.loadSettingsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.fileToolStripMenuItem.Text = "文件";
            // 
            // importFilesToolStripMenuItem
            // 
            this.importFilesToolStripMenuItem.Name = "importFilesToolStripMenuItem";
            this.importFilesToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.importFilesToolStripMenuItem.Text = "导入文件";
            this.importFilesToolStripMenuItem.Click += new System.EventHandler(this.importFilesToolStripMenuItem_Click);
            // 
            // importDirectoryToolStripMenuItem
            // 
            this.importDirectoryToolStripMenuItem.Name = "importDirectoryToolStripMenuItem";
            this.importDirectoryToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.importDirectoryToolStripMenuItem.Text = "导入目录";
            this.importDirectoryToolStripMenuItem.Click += new System.EventHandler(this.importDirectoryToolStripMenuItem_Click);
            // 
            // saveSettingsToolStripMenuItem
            // 
            this.saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            this.saveSettingsToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.saveSettingsToolStripMenuItem.Text = "保存设置";
            this.saveSettingsToolStripMenuItem.Click += new System.EventHandler(this.saveSettingsToolStripMenuItem_Click);
            // 
            // loadSettingsToolStripMenuItem
            // 
            this.loadSettingsToolStripMenuItem.Name = "loadSettingsToolStripMenuItem";
            this.loadSettingsToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.loadSettingsToolStripMenuItem.Text = "载入设置";
            this.loadSettingsToolStripMenuItem.Click += new System.EventHandler(this.loadSettingsToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resizeToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.settingsToolStripMenuItem.Text = "设置";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            this.resizeToolStripMenuItem.Size = new System.Drawing.Size(146, 34);
            this.resizeToolStripMenuItem.Text = "显示";
            this.resizeToolStripMenuItem.Click += new System.EventHandler(this.resizeToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.removeAllToolStripMenuItem,
            this.rmoveProcessedToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.projectToolStripMenuItem.Text = "项目";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.showToolStripMenuItem.Text = "显示";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // removeAllToolStripMenuItem
            // 
            this.removeAllToolStripMenuItem.Name = "removeAllToolStripMenuItem";
            this.removeAllToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.removeAllToolStripMenuItem.Text = "移除全部";
            this.removeAllToolStripMenuItem.Click += new System.EventHandler(this.removeAllToolStripMenuItem_Click);
            // 
            // rmoveProcessedToolStripMenuItem
            // 
            this.rmoveProcessedToolStripMenuItem.Name = "rmoveProcessedToolStripMenuItem";
            this.rmoveProcessedToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.rmoveProcessedToolStripMenuItem.Text = "移除已处理";
            this.rmoveProcessedToolStripMenuItem.Click += new System.EventHandler(this.rmoveProcessedToolStripMenuItem_Click);
            // 
            // elaborationToolStripMenuItem
            // 
            this.elaborationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doToolStripMenuItem,
            this.suspendToolStripMenuItem,
            this.resumeToolStripMenuItem,
            this.abortToolStripMenuItem});
            this.elaborationToolStripMenuItem.Name = "elaborationToolStripMenuItem";
            this.elaborationToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.elaborationToolStripMenuItem.Text = "优化";
            // 
            // doToolStripMenuItem
            // 
            this.doToolStripMenuItem.Name = "doToolStripMenuItem";
            this.doToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.doToolStripMenuItem.Text = "开始";
            this.doToolStripMenuItem.Click += new System.EventHandler(this.doToolStripMenuItem_Click);
            // 
            // suspendToolStripMenuItem
            // 
            this.suspendToolStripMenuItem.Enabled = false;
            this.suspendToolStripMenuItem.Name = "suspendToolStripMenuItem";
            this.suspendToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.suspendToolStripMenuItem.Text = "暂停";
            this.suspendToolStripMenuItem.Click += new System.EventHandler(this.suspendToolStripMenuItem_Click);
            // 
            // resumeToolStripMenuItem
            // 
            this.resumeToolStripMenuItem.Enabled = false;
            this.resumeToolStripMenuItem.Name = "resumeToolStripMenuItem";
            this.resumeToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.resumeToolStripMenuItem.Text = "重新开始";
            this.resumeToolStripMenuItem.Click += new System.EventHandler(this.resumeToolStripMenuItem_Click);
            // 
            // abortToolStripMenuItem
            // 
            this.abortToolStripMenuItem.Enabled = false;
            this.abortToolStripMenuItem.Name = "abortToolStripMenuItem";
            this.abortToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.abortToolStripMenuItem.Text = "关于";
            this.abortToolStripMenuItem.Click += new System.EventHandler(this.abortToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.authorSiteToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.aboutToolStripMenuItem.Text = "关于";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.infoToolStripMenuItem.Text = "程序信息";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // authorSiteToolStripMenuItem
            // 
            this.authorSiteToolStripMenuItem.Name = "authorSiteToolStripMenuItem";
            this.authorSiteToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.authorSiteToolStripMenuItem.Text = "联系作者";
            this.authorSiteToolStripMenuItem.Click += new System.EventHandler(this.authorSiteToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1022);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1866, 35);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.ForeColor = System.Drawing.Color.Lime;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(225, 27);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(335, 28);
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(1279, 28);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "Ready";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "bmp |*.bmp|jpeg|*.jpg|gif|*.gif|ico|*.ico|tiff|*.tiff|wmf|*.wmf|png|*.png|all|*.*" +
    "";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.Multiselect = true;
            // 
            // ImageContainer
            // 
            this.ImageContainer.BackColor = System.Drawing.SystemColors.Window;
            this.ImageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageContainer.Location = new System.Drawing.Point(0, 65);
            this.ImageContainer.Margin = new System.Windows.Forms.Padding(6);
            this.ImageContainer.Name = "ImageContainer";
            this.ImageContainer.Size = new System.Drawing.Size(1866, 957);
            this.ImageContainer.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1866, 1057);
            this.Controls.Add(this.ImageContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1189, 809);
            this.Name = "Form1";
            this.Text = "BatchImageConverter (多线程批量图片压缩转化)";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private UImageContainer ImageContainer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elaborationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suspendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authorSiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton Addfile;
        private System.Windows.Forms.ToolStripButton Adddir;
        private System.Windows.Forms.ToolStripButton Go;
        private System.Windows.Forms.ToolStripButton Settings;
        private System.Windows.Forms.ToolStripButton WorkPanel;
        private System.Windows.Forms.ToolStripMenuItem removeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rmoveProcessedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSettingsToolStripMenuItem;

    }
}

