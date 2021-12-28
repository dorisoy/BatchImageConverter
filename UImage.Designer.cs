namespace BatchImageConverter
{
    partial class UImage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.expandShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elaborateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_working = new System.Windows.Forms.Panel();
            this.checkBox_Lock_Changeed = new System.Windows.Forms.CheckBox();
            this.checkBox_Locked = new System.Windows.Forms.CheckBox();
            this.Label_filename = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_SizeY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_SizeX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            this.panel_working.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Remove,
            this.expandShowToolStripMenuItem,
            this.elaborateToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(241, 127);
            // 
            // Remove
            // 
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(240, 30);
            this.Remove.Text = "移除";
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // expandShowToolStripMenuItem
            // 
            this.expandShowToolStripMenuItem.Name = "expandShowToolStripMenuItem";
            this.expandShowToolStripMenuItem.Size = new System.Drawing.Size(240, 30);
            this.expandShowToolStripMenuItem.Text = "预览";
            this.expandShowToolStripMenuItem.Click += new System.EventHandler(this.expandShowToolStripMenuItem_Click);
            // 
            // elaborateToolStripMenuItem
            // 
            this.elaborateToolStripMenuItem.Name = "elaborateToolStripMenuItem";
            this.elaborateToolStripMenuItem.Size = new System.Drawing.Size(240, 30);
            this.elaborateToolStripMenuItem.Text = "单个优化";
            this.elaborateToolStripMenuItem.Click += new System.EventHandler(this.elaborateToolStripMenuItem_Click);
            // 
            // panel_working
            // 
            this.panel_working.ContextMenuStrip = this.contextMenuStrip1;
            this.panel_working.Controls.Add(this.checkBox_Lock_Changeed);
            this.panel_working.Controls.Add(this.checkBox_Locked);
            this.panel_working.Controls.Add(this.Label_filename);
            this.panel_working.Controls.Add(this.label9);
            this.panel_working.Controls.Add(this.label5);
            this.panel_working.Controls.Add(this.label4);
            this.panel_working.Controls.Add(this.label3);
            this.panel_working.Controls.Add(this.numericUpDown_SizeY);
            this.panel_working.Controls.Add(this.numericUpDown_SizeX);
            this.panel_working.Controls.Add(this.label2);
            this.panel_working.Controls.Add(this.label1);
            this.panel_working.Location = new System.Drawing.Point(92, 6);
            this.panel_working.Margin = new System.Windows.Forms.Padding(4);
            this.panel_working.Name = "panel_working";
            this.panel_working.Size = new System.Drawing.Size(1185, 64);
            this.panel_working.TabIndex = 1;
            // 
            // checkBox_Lock_Changeed
            // 
            this.checkBox_Lock_Changeed.AutoSize = true;
            this.checkBox_Lock_Changeed.Location = new System.Drawing.Point(502, 36);
            this.checkBox_Lock_Changeed.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Lock_Changeed.Name = "checkBox_Lock_Changeed";
            this.checkBox_Lock_Changeed.Size = new System.Drawing.Size(70, 22);
            this.checkBox_Lock_Changeed.TabIndex = 19;
            this.checkBox_Lock_Changeed.Text = "锁定";
            this.checkBox_Lock_Changeed.UseVisualStyleBackColor = true;
            // 
            // checkBox_Locked
            // 
            this.checkBox_Locked.AutoSize = true;
            this.checkBox_Locked.Checked = true;
            this.checkBox_Locked.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Locked.Location = new System.Drawing.Point(396, 35);
            this.checkBox_Locked.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Locked.Name = "checkBox_Locked";
            this.checkBox_Locked.Size = new System.Drawing.Size(106, 22);
            this.checkBox_Locked.TabIndex = 18;
            this.checkBox_Locked.Text = "固定大小";
            this.checkBox_Locked.UseVisualStyleBackColor = true;
            // 
            // Label_filename
            // 
            this.Label_filename.ContextMenuStrip = this.contextMenuStrip1;
            this.Label_filename.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label_filename.Location = new System.Drawing.Point(104, 1);
            this.Label_filename.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_filename.Name = "Label_filename";
            this.Label_filename.Size = new System.Drawing.Size(506, 25);
            this.Label_filename.TabIndex = 17;
            this.Label_filename.Text = "文件名";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(572, 107);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 25);
            this.label9.TabIndex = 16;
            this.label9.Text = "KB";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(568, 69);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "y";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(360, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "y";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(214, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "x";
            // 
            // numericUpDown_SizeY
            // 
            this.numericUpDown_SizeY.Location = new System.Drawing.Point(250, 32);
            this.numericUpDown_SizeY.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_SizeY.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown_SizeY.Name = "numericUpDown_SizeY";
            this.numericUpDown_SizeY.Size = new System.Drawing.Size(102, 28);
            this.numericUpDown_SizeY.TabIndex = 5;
            this.numericUpDown_SizeY.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown_SizeY.ValueChanged += new System.EventHandler(this.numericUpDown_Sizey_ValueChanged);
            // 
            // numericUpDown_SizeX
            // 
            this.numericUpDown_SizeX.Location = new System.Drawing.Point(108, 30);
            this.numericUpDown_SizeX.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_SizeX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown_SizeX.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown_SizeX.Name = "numericUpDown_SizeX";
            this.numericUpDown_SizeX.Size = new System.Drawing.Size(102, 28);
            this.numericUpDown_SizeX.TabIndex = 4;
            this.numericUpDown_SizeX.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown_SizeX.ValueChanged += new System.EventHandler(this.numericUpDown_SizeX_ValueChanged);
            // 
            // label2
            // 
            this.label2.ContextMenuStrip = this.contextMenuStrip1;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "目标大小";
            // 
            // label1
            // 
            this.label1.ContextMenuStrip = this.contextMenuStrip1;
            this.label1.Location = new System.Drawing.Point(6, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "文件名";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Location = new System.Drawing.Point(4, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // UImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel_working);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UImage";
            this.Size = new System.Drawing.Size(1256, 75);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel_working.ResumeLayout(false);
            this.panel_working.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel_working;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_SizeY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Label_filename;
        public System.Windows.Forms.NumericUpDown numericUpDown_SizeX;
        private System.Windows.Forms.CheckBox checkBox_Locked;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Remove;
        private System.Windows.Forms.ToolStripMenuItem expandShowToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_Lock_Changeed;
        private System.Windows.Forms.ToolStripMenuItem elaborateToolStripMenuItem;
    }
}
