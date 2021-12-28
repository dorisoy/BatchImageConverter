namespace BatchImageConverter
{
    partial class FilePreview
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_dimy = new System.Windows.Forms.Label();
            this.label_dimx = new System.Windows.Forms.Label();
            this.label_filename = new System.Windows.Forms.Label();
            this.label_1 = new System.Windows.Forms.Label();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(240, 225);
            this.splitContainer1.SplitterDistance = 87;
            this.splitContainer1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.propertyGrid1);
            this.panel1.Controls.Add(this.label_1);
            this.panel1.Controls.Add(this.label_dimy);
            this.panel1.Controls.Add(this.label_dimx);
            this.panel1.Controls.Add(this.label_filename);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 132);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label_dimy
            // 
            this.label_dimy.Location = new System.Drawing.Point(3, 45);
            this.label_dimy.Name = "label_dimy";
            this.label_dimy.Size = new System.Drawing.Size(228, 16);
            this.label_dimy.TabIndex = 2;
            // 
            // label_dimx
            // 
            this.label_dimx.Location = new System.Drawing.Point(3, 26);
            this.label_dimx.Name = "label_dimx";
            this.label_dimx.Size = new System.Drawing.Size(228, 16);
            this.label_dimx.TabIndex = 1;
            // 
            // label_filename
            // 
            this.label_filename.BackColor = System.Drawing.Color.Transparent;
            this.label_filename.Location = new System.Drawing.Point(3, 5);
            this.label_filename.Name = "label_filename";
            this.label_filename.Size = new System.Drawing.Size(211, 16);
            this.label_filename.TabIndex = 0;
            // 
            // label_1
            // 
            this.label_1.Location = new System.Drawing.Point(1, 63);
            this.label_1.Name = "label_1";
            this.label_1.Size = new System.Drawing.Size(228, 16);
            this.label_1.TabIndex = 3;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(234, 128);
            this.propertyGrid1.TabIndex = 4;
            // 
            // FilePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FilePreview";
            this.Size = new System.Drawing.Size(240, 225);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_dimy;
        private System.Windows.Forms.Label label_dimx;
        private System.Windows.Forms.Label label_filename;
        private System.Windows.Forms.Label label_1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}
