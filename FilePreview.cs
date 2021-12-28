using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace BatchImageConverter
{
    public partial class FilePreview : UserControl
    {
        public FilePreview()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set the image by string
        /// </summary>
        /// <param name="filename"></param>
        public void SetImage(string filename)
        {
            try
            {
                Bitmap bit = new Bitmap(filename);
                double ratio = 0;
                ratio = (double)bit.Width / (double)this.pictureBox1.Width;
                this.pictureBox1.Image = bit.GetThumbnailImage(this.pictureBox1.Width, (int)((double)bit.Height / ratio), null, System.IntPtr.Zero);
                this.SetLabelsInternal(filename, bit.Width, bit.Height, ref bit);
                bit.Dispose();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Set the image by image
        /// </summary>
        /// <param name="bit"></param>
        public void SetImage(ref Bitmap bit)
        {
            try
            {
                this.pictureBox1.Image = bit;
            }
            catch
            {
            }
        }

        /// <summary>
        /// Set the labels for file description
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="dimx"></param>
        /// <param name="dimy"></param>
        public void SetLabels(string filename,int dimx,int dimy)
        {
            if (Directory.Exists(filename))
            {
                FileInfo fi = new FileInfo(filename);

                CPropDir cpropdir = new CPropDir();
                cpropdir.setfile(filename);
                propertyGrid1.SelectedObject = cpropdir;                                             
            }
            if (File.Exists(filename))
            {
                FileInfo fi = new FileInfo(filename);
                CPropFile cpropfile = new CPropFile();
                cpropfile.setfile(filename);
                propertyGrid1.SelectedObject = cpropfile;
            }
        }

        /// <summary>
        ///  Set the labels for file description internal (image)
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="dimx"></param>
        /// <param name="dimy"></param>
        /// <param name="bit"></param>
        private void SetLabelsInternal(string filename, int dimx, int dimy, ref Bitmap bit)
        {
            FileInfo fi = new FileInfo(filename);
            CPropImg cpropfile = new CPropImg();
            cpropfile.setfile(filename,ref bit);
            propertyGrid1.SelectedObject = cpropfile;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
