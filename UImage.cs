using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;
using System.IO;

namespace BatchImageConverter
{
    public partial class UImage : UserControl
    {
        public UImage()
        {
            InitializeComponent();
            Imageproc = new CImage();
            //this.MouseEnter += new EventHandler(UImage_MouseEnter); // The control is filles by panel working
            this.panel_working.MouseEnter += new EventHandler(UImage_MouseEnter);
            this.pictureBox1.MouseEnter += new EventHandler(UImage_MouseEnter);
            this.MouseDoubleClick += new MouseEventHandler(UImage_MouseDoubleClick);
            textoverlay = new CImage.TextOverlay();
            OriginalBackColor = this.BackColor;
        }

        // Campi
        private Color OriginalBackColor;
        private Size OriginalSize;
        private Size TransformSize;
        private CImage Imageproc;
        public bool pair = false;
        private bool initsafe = false;
        private bool manualxchange = false;
        private bool manualychange = false;
        public string Filename;
        public System.EventHandler deletedcontrol_delegate;
        public System.EventHandler expandimage_delegate;
        public System.EventHandler mouseenter_delegate;
        public System.EventHandler workfinished_delegate;
        public string targetdir = "C:\\Output\\";
        private bool saferesize = false;
        private int quality = 0;
        private int compressionquality = 95;
        private CImage.TextOverlay textoverlay;
        private bool textoverlayenable = false;
        private CImage.ImageOverlay imageoverlay;
        private bool imageoverlayenable = false;
        private Color shadowcolor = Color.White;
        private bool shadowenabled = false;
        public bool processed = false;
        public bool started = false;
        private int _number = 0;
        private bool rename = false;
        private string renamename = "";
        private bool changeext = false;
        private string changeextname = "jpg";

        /// <summary>
        /// Write values on numerical boxes
        /// </summary>
        private void writenumerical()
        {
            this.numericUpDown_SizeX.Maximum = OriginalSize.Width*2;
            this.numericUpDown_SizeX.Value = OriginalSize.Width;
            this.numericUpDown_SizeY.Maximum = OriginalSize.Height*2;
            this.numericUpDown_SizeY.Value = OriginalSize.Height;
            initsafe = true;
        }

        /// <summary>
        /// Activate or disactivate the automatic rename;
        /// </summary>
        /// <param name="ren"></param>
        public void SetRename(bool ren)
        {
            if (this.checkBox_Lock_Changeed.Checked == true) return;
            rename = ren;
        }

        /// <summary>
        /// Set name for rename
        /// </summary>
        /// <param name="name"></param>
        public void SetRenameStr(string name)
        {
            if (this.checkBox_Lock_Changeed.Checked == true) return;
            renamename = name;
        }

        /// <summary>
        /// Set if the image must be converted
        /// </summary>
        /// <param name="ext"></param>
        public void SetConversion(bool ext)
        {
            if (this.checkBox_Lock_Changeed.Checked == true) return;
            changeext = ext;
        }

        /// <summary>
        /// Set the extension / filetype
        /// </summary>
        /// <param name="extension"></param>
        public void SetConversionName(string extension)
        {
            if (this.checkBox_Lock_Changeed.Checked == true) return;
            changeextname = extension;
        }

        /// <summary>
        /// Set a progressive number (usefull for rename batch)
        /// </summary>
        /// <param name="id"></param>
        public void SetNumberId(int id)
        {
            _number = id;
        }

        /// <summary>
        /// Get the progressve number
        /// </summary>
        /// <returns></returns>
        public int GetNumberId()
        {
            return _number;
        }

        /// <summary>
        /// Set background color
        /// </summary>
        /// <param name="cl"></param>
        public void SetBackgroundColor(Color cl)
        {
            this.BackColor = cl;
            OriginalBackColor = cl;
        }

        /// <summary>
        /// Reset original color
        /// </summary>
        public void ResetOriginalColor()
        {
            this.BackColor = OriginalBackColor;
        }

        /// <summary>
        /// Set highlight color
        /// </summary>
        /// <param name="col"></param>
        public void SetHighLightColor(Color col)
        {
            this.BackColor = col;
        }

        /// <summary>
        /// Load image on the picturebox
        /// </summary>
        /// <returns></returns>
        public bool loadimage()
        {
            try
            {
                Bitmap bit = new Bitmap(Filename);
                double ratio = 0;
                ratio = (double)bit.Width / (double)this.pictureBox1.Width;
                this.pictureBox1.Image = bit.GetThumbnailImage(this.pictureBox1.Width, (int)((double)bit.Height/ratio), null, System.IntPtr.Zero); 
                OriginalSize = new Size(bit.Width, bit.Height);
                TransformSize = OriginalSize;
                bit.Dispose();
                writenumerical();
                this.Label_filename.Text = this.Filename;
            }
            catch
            {
                return false;
            }
           return true;
        }

        /// <summary>
        /// Set the target size in absolute values
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetTargetSize_Absolute(int x, int y)
        {
            if (this.checkBox_Lock_Changeed.Checked == true) return;
            saferesize = true;
            if (x > (int)this.numericUpDown_SizeX.Maximum) x = (int)this.numericUpDown_SizeX.Maximum;
            if (this.checkBox_Locked.Checked == true) y = (int)((double)(OriginalSize.Height * x) / (double)OriginalSize.Width);
            if (y > (int)this.numericUpDown_SizeY.Maximum) y = (int)this.numericUpDown_SizeY.Maximum;
            if (x < (int)this.numericUpDown_SizeX.Minimum) x = (int)this.numericUpDown_SizeX.Minimum;
            if (y < (int)this.numericUpDown_SizeY.Minimum) y = (int)this.numericUpDown_SizeY.Minimum;
            this.numericUpDown_SizeX.Value = (decimal)x;
            this.numericUpDown_SizeY.Value = (decimal)y;
            TransformSize = new Size(x, y);
            saferesize = false;
        }

        /// <summary>
        /// Set the target size in max
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetTargetSize_Max(int max)
        {
            if (this.checkBox_Lock_Changeed.Checked == true) return;
            int x = 0;
            int y = 0;
            if (OriginalSize.Width >= OriginalSize.Height)
            {
                // Fat image
                x = max;
                y = (int)((double)(OriginalSize.Height * x) / (double)OriginalSize.Width);
            }
            else
            {
                // Slim image
                y = max;
                x = (int)((double)(OriginalSize.Width * y) / (double)OriginalSize.Height);
            }
            SetTargetSize_Absolute(x, y);
        }

        /// <summary>
        /// Set the target size in percent
        /// </summary>
        /// <param name="perc"></param>
        public void SetTargetSize_Percent(int perc)
        {
            if (this.checkBox_Lock_Changeed.Checked == true) return;
            saferesize = true;
            int x = 0;
            int y = 0;
            x = (int)((float)OriginalSize.Width * perc / 100);
            y = (int)((float)OriginalSize.Height * perc / 100);

            if (x > (int)this.numericUpDown_SizeX.Maximum)
            {
                x = (int)this.numericUpDown_SizeX.Maximum;
                y = (int)((double)(OriginalSize.Height * x) / (double)OriginalSize.Width);
            }
            if (y > (int)this.numericUpDown_SizeY.Maximum)
            {
                y = (int)this.numericUpDown_SizeY.Maximum;
                x = (int)((double)(OriginalSize.Width * y) / (double)OriginalSize.Height);
            }
            if (x < (int)this.numericUpDown_SizeX.Minimum)
            {
                x = (int)this.numericUpDown_SizeX.Minimum;
                y = (int)((double)(OriginalSize.Height * x) / (double)OriginalSize.Width);
            }
            if (y < (int)this.numericUpDown_SizeY.Minimum)
            {
                y = (int)this.numericUpDown_SizeY.Minimum;
                x = (int)((double)(OriginalSize.Width * y) / (double)OriginalSize.Height);
            }
            this.numericUpDown_SizeX.Value = (decimal)x;
            this.numericUpDown_SizeY.Value = (decimal)y;
            TransformSize = new Size(x, y);
            saferesize = false;
        }

        /// <summary>
        /// 设置锁定尺寸x-y与mantein比率
        /// </summary>
        /// <param name="locked"></param>
        public void SetLockXY(bool locked)
        {
            if (this.checkBox_Lock_Changeed.Checked == true) return;
            this.checkBox_Locked.Checked = locked;
        }

        /// <summary>
        /// Set target directory
        /// </summary>
        public void SetTargetDir(string target)
        {
            targetdir = target;
        }

        /// <summary>
        /// Set the resize quality: see CImage Class to know how use the parameter (0=max,6=min)
        /// </summary>
        /// <param name="qual"></param>
        public void SetResizeQuality(int qual)
        {
            this.quality = qual;
        }

        /// <summary>
        /// Set the compression quality for Jpeg encoder
        /// </summary>
        /// <param name="qual"></param>
        public void SetCompressionQuality(int qual)
        {
            if (qual < 0) qual = 0;
            if (qual > 100) qual = 100;
            this.compressionquality = qual;
        }

        /// <summary>
        /// Set x position for text overlay
        /// </summary>
        /// <param name="xpos"></param>
        public void SetOverlayPositionX(CImage.XPosition xpos)
        {
            this.textoverlay.xpos = xpos;
        }

        /// <summary>
        /// Set y position for text overlay
        /// </summary>
        /// <param name="ypos"></param>
        public void SetOverlayPositionY(CImage.YPosition ypos)
        {
            this.textoverlay.ypos = ypos;
        }

        /// <summary>
        /// Enable or disable text overlay
        /// </summary>
        /// <param name="enabled"></param>
        public void SetEnableTextOverlay(bool enabled)
        {
            this.textoverlayenable = enabled;
        }

        /// <summary>
        /// Set the overlay text struct (more speed)
        /// </summary>
        /// <param name="ovl"></param>
        public void SetOverlayTextStruct(CImage.TextOverlay ovl)
        {
            this.textoverlay = ovl;
        }

        /// <summary>
        /// Set the font for text overlay
        /// </summary>
        /// <param name="font"></param>
        public void SetFont(Font font)
        {
            textoverlay.font = font;
        }

        /// <summary>
        /// Set the text color
        /// </summary>
        /// <param name="col"></param>
        public void SetTextColor(Color col)
        {
            this.textoverlay.frontcolor = col;
        }

        /// <summary>
        /// Set the shape color
        /// </summary>
        /// <param name="col"></param>
        public void SetShapeColor(Color col)
        {
            this.textoverlay.shapecolor = col;
        }

        /// <summary>
        /// Set the text for overlay
        /// </summary>
        /// <param name="text"></param>
        public void SetTextOverlay(string text)
        {
            textoverlay.Text = text;
        }

        /// <summary>
        /// Enable or disable shapes (rectangle @ ellipse)
        /// </summary>
        /// <param name="enabled"></param>
        /// <param name="rectangle"></param>
        /// <param name="ellipse"></param>
        public void SetShapes(bool enabled, bool rectangle, bool ellipse)
        {
            this.textoverlay.Shape = enabled;
            this.textoverlay.ShapeRectangle = rectangle;
            this.textoverlay.ShapeEllipse = ellipse;
        }

        /// <summary>
        ///  Set transparency
        /// </summary>
        /// <param name="text"></param>
        /// <param name="shadow"></param>
        /// <param name="shape"></param>
        public void SetTrasparency(short text, short shadow, short shape)
        {
            this.textoverlay.trasp = text;
            this.textoverlay.traspshadow = shadow;
            this.textoverlay.transparencyshape = shape;
        }

        /// <summary>
        /// Set text reduction
        /// </summary>
        /// <param name="reduction"></param>
        public void SetTextReduction(int reduction)
        {
            this.textoverlay.dim = reduction;
        }

        /// <summary>
        /// Set text 3d effect
        /// </summary>
        /// <param name="enabled"></param>
        public void Set3DTextEffect(bool enabled)
        {
            this.textoverlay.D3effetc = enabled;
        }

        /// <summary>
        /// Set the image overlay
        /// </summary>
        /// <param name="ovl"></param>
        public void SetImageOverlayStruct(CImage.ImageOverlay ovl)
        {
            this.imageoverlay = ovl;
        }

        /// <summary>
        /// Set x position for watermark image
        /// </summary>
        /// <param name="pos"></param>
        public void SetWatermarkPositionX(CImage.XPosition pos)
        {
            imageoverlay.xpos = pos;
        }

        /// <summary>
        /// Set x position for watermark image
        /// </summary>
        /// <param name="pos"></param>
        public void SetWatermarkPositionY(CImage.YPosition pos)
        {
            imageoverlay.ypos = pos;
        }

        /// <summary>
        /// Enable or disable the waternark
        /// </summary>
        /// <param name="enable"></param>
        public void SetWatermarkEnable(bool enable)
        {
            imageoverlayenable = enable;
        }

        /// <summary>
        /// Set the filename of watermark image
        /// </summary>
        /// <param name="filename"></param>
        public void SetWatermarkPath(string filename)
        {
            imageoverlay.path = filename;
        }

        /// <summary>
        /// Set the transparency of the watermark image
        /// </summary>
        /// <param name="trasparence"></param>
        public void SetWatermarkTransparence(int transparence)
        {
            imageoverlay.trasp = (short)transparence;
        }

        /// <summary>
        /// Set the size og the watermark image in percent relative to the contaier image
        /// </summary>
        /// <param name="percent"></param>
        public void SetWatrmarkPercen(int percent)
        {
            imageoverlay.percdim = percent;
        }

        /// <summary>
        /// Set the background color for the shadow
        /// </summary>
        /// <param name="col"></param>
        public void SetShadowColor(Color col)
        {
            this.shadowcolor = col;
        }

        /// <summary>
        /// Enable or disable the shadow
        /// </summary>
        /// <param name="enabled"></param>
        public void SetShadowEnable(bool enabled)
        {
            this.shadowenabled = enabled;
        }

        /// <summary>
        /// Set Watermark image transparent key
        /// </summary>
        /// <param name="col"></param>
        public void SetWaterTraspKey(Color col)
        {
            this.imageoverlay.traspkey = col;
        }

        /// <summary>
        /// Update on numericalupdownx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown_SizeX_ValueChanged(object sender, EventArgs e)
        {
            // Handle the lock resize
            if (initsafe && !saferesize)
            {
                manualxchange = true;
                if (manualychange == false)
                {
                    int dimy=0;
                    if (this.checkBox_Locked.Checked == true)
                        dimy = (int)((double)(OriginalSize.Height * numericUpDown_SizeX.Value) / (double)OriginalSize.Width);
                    else 
                        dimy = (int)numericUpDown_SizeY.Value;

                    TransformSize = new Size((int)numericUpDown_SizeX.Value, dimy);
                    if (dimy < (int)this.numericUpDown_SizeY.Minimum) dimy = (int)this.numericUpDown_SizeY.Minimum;
                    this.numericUpDown_SizeY.Value = dimy;
                }
                manualychange = false;
            }
        }

        /// <summary>
        /// Update on numericalupdownY
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown_Sizey_ValueChanged(object sender, EventArgs e)
        {
            // Handle the lock resize
            if (initsafe && !saferesize)
            {
                manualychange = true;
                if (manualxchange == false)
                {
                    int dimx = 0;
                    if (this.checkBox_Locked.Checked == true) dimx = (int)((double)(OriginalSize.Width * numericUpDown_SizeY.Value) / (double)OriginalSize.Height);
                    else dimx = (int)numericUpDown_SizeX.Value;
                    TransformSize = new Size(dimx, (int)numericUpDown_SizeY.Value);
                    if (dimx < (int)this.numericUpDown_SizeX.Minimum) dimx = (int)this.numericUpDown_SizeX.Minimum;
                    this.numericUpDown_SizeX.Value = dimx;
                }
                manualxchange = false;
            }
        }

        /// <summary>
        /// Remove the item from panel container
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Remove_Click(object sender, EventArgs e)
        {
            // Invokes the delegate that is "linked" to the parent one.
            this.Invoke(this.deletedcontrol_delegate);
            //this.deletedcontrol_delegate(this, null); // is the same of previous row (use only one)
        }

        /// <summary>
        /// Expand the image in fullscreen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void expandShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.expandimage_delegate(this, null);
        }

        /// <summary>
        /// Elaborates this single image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void elaborateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (started == false) this.Go();
        }
        /// <summary>
        /// Expand the image in fullscreen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.expandimage_delegate(this, null);
        }

        /// <summary>
        /// Occours when the mouse click on the uimage control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UImage_MouseEnter(object sender, EventArgs e)
        {
            this.mouseenter_delegate(this, e);
        }


        /// <summary>
        /// Start work
        /// </summary>
        public void Go()
        {
            this.BackColor = Color.MintCream;
            processed = false;
            started = true;
            doelaborations(Filename);
            return;
        }

        /// <summary>
        /// Return the file name for the elaborated image
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private string getname(string filename)
        {
            CUtilitties utilityes = new CUtilitties();
            string name = utilityes.getfilenamenoext(filename);
            string ext = utilityes.getextension(filename);
            string extension = ext;
            string targetfilename = "";
            if (changeext) extension = changeextname;
            if (rename)
            {
                targetfilename = this.targetdir + renamename + "_" + _number.ToString() + "." + extension;
            }
            else
            {
                targetfilename = this.targetdir + name + "." + extension;
            }
            Directory.CreateDirectory(targetdir);
            return targetfilename;
        }

        /// <summary>
        /// Do the operation on image  (resize overlay watermark etc)
        /// </summary>
        /// <param name="filename"></param>
        private bool doelaborations(string filename)
        {
            // Get the filename and path
            string targetfilename = getname(filename);
            
            // Create a new bitmap
            Bitmap originale = new Bitmap(filename);
            
            Thread.Sleep(30);
          
            // Do text overlay
            if (this.textoverlayenable) Imageproc.overlaytext(ref originale, this.textoverlay);

            Thread.Sleep(40); 

            // Do resize (TrasformSize is assigned by various methods)
            Imageproc.Resize(ref originale, TransformSize.Width, TransformSize.Height, quality);

            Thread.Sleep(40); 

            // Do image watermark
            
            if (this.imageoverlayenable)
            {
                if (File.Exists(imageoverlay.path))
                {
                    try
                    {
                        Bitmap bit = new Bitmap(imageoverlay.path);
                        Imageproc.overlayimage(ref originale, ref bit, this.imageoverlay);
                        bit.Dispose();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        // This may not occour
                    }
                }
            }
            

            Thread.Sleep(40);
 
            // Make shadow
            if (shadowenabled) Imageproc.makeshadow(ref originale, shadowcolor);
            
            // Save
            save(ref originale, targetfilename, compressionquality);
            
            // Dispose
            originale.Dispose();

            processed = true;
            started = false;
            this.workfinished_delegate(this, null);
            return true;
        }

        /// <summary>
        /// Save the bitmap to file
        /// </summary>
        /// <param name="tosave"></param>
        private void save(ref Bitmap tosave ,string targetfilename, int quality)
        {
            CUtilitties utilityes = new CUtilitties();
            switch (utilityes.getextension(targetfilename).ToLower())
            {
                case "gif":
                    tosave.Save(targetfilename, ImageFormat.Gif);
                    break;
                case "bmp":
                    tosave.Save(targetfilename, ImageFormat.Bmp);
                    break;
                case "exif":
                    tosave.Save(targetfilename, ImageFormat.Exif);
                    break;
                case "ico":
                    tosave.Save(targetfilename, ImageFormat.Icon);
                    break;
                case "png":
                    tosave.Save(targetfilename, ImageFormat.Png);
                    break;
                case "tiff":
                    tosave.Save(targetfilename, ImageFormat.Tiff);
                    break;
                case "wmf":
                    tosave.Save(targetfilename, ImageFormat.Wmf);
                    break;
                default:
                    Imageproc.save(ref tosave, targetfilename, quality);
                    break;
            }
        }
    }
}
