using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace BatchImageConverter
{

    public partial class Panello : System.Windows.Forms.Panel
    {
        public Panello(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            deletedcontrol_delegate = new System.EventHandler(deletedcontrol);
            this.HScroll = false;
            memo = new Memo();
            CheckForIllegalCrossThreadCalls = false;        // Elimina errori di cross process (vs 2003)
            threads = new Thread[12];
            this.AutoScroll = true;
            this.DoubleBuffered = true;
            this.HScroll = false;
            this.DoubleBuffered = true;
        }

        private Color BkRow1 = Color.WhiteSmoke;
        private Color BkRow2 = Color.LightGray;
        public System.EventHandler deletedcontrol_delegate; // called when a control is deleted
        public System.EventHandler expandimage_delegate;    // called when a control is expanded
        public System.EventHandler mouseenter_delegate;     // called when the mouse enter in a control
        public System.EventHandler workfinished_delegate;  // called when a control finishes the work
        private volatile int _processed;
        private int _total;
        private volatile int index;
        private string _processedname;
        private int CONCURRENT_THREADS = 3;
        private Thread[] threads;
        private Memo memo;

        /// <summary>
        /// Class useed to store, set, save, load settings from settings panel
        /// </summary>
        [Serializable]
        private class Memo
        {
            public Memo()
            {
                textoverlay = new CImage.TextOverlay();
                imageoverlay = new CImage.ImageOverlay();
            }

            // Use for Uimage initialization or modify in respect to settings
            public int width = 1024;
            public int heiht = 768;
            public int max = 1024;
            public int perc = 100;
            public int jpegqual = 95;
            public int resizequal = 0;
            public string targetdir = "C:\\Output\\";
            public bool absolutemethod = false;
            public bool percmethod = true;
            public bool maxmethod = false;
            public bool dimlocked = true;
            public CImage.TextOverlay textoverlay;
            public bool textoverlayenabled = false;
            public CImage.ImageOverlay imageoverlay;
            public bool imageoverlayenabled = false;
            public bool shadowenable = false;
            public Color shadowcolor = Color.White;
            public bool rename = false;
            public string renamename = "";
            public bool extension = false;
            public string extensionname = "";
 
            /// <summary>
            /// Set all propriety settings. used to store settings and use them when an UImage is created.
            /// </summary>
            /// <param name="objuimg"></param>
            public void setimage(ref UImage objuimg)
            {
                if (absolutemethod) objuimg.SetTargetSize_Absolute(width, heiht);
                if (percmethod) objuimg.SetTargetSize_Percent(perc);
                if (maxmethod) objuimg.SetTargetSize_Max(max);
                objuimg.SetLockXY(dimlocked);
                objuimg.SetCompressionQuality(jpegqual);
                objuimg.SetResizeQuality(resizequal);
                objuimg.SetTargetDir(targetdir);
                objuimg.SetEnableTextOverlay(textoverlayenabled);
                objuimg.SetOverlayTextStruct(textoverlay);
                objuimg.SetWatermarkEnable(imageoverlayenabled);
                objuimg.SetImageOverlayStruct(imageoverlay);
                objuimg.SetShadowEnable(shadowenable);
                objuimg.SetShadowColor(shadowcolor);
                objuimg.SetRename(rename);
                objuimg.SetRenameStr(renamename);
                objuimg.SetConversion(extension);
                objuimg.SetConversionName(extensionname);
            }

            /// <summary>
            /// Serialization
            /// </summary>
            /// <param name="myStream"></param>
            public void Serialize(Stream myStream,ref IFormatter formatter)
            {
                formatter.Serialize(myStream,this.absolutemethod);
                formatter.Serialize(myStream, this.dimlocked);
                formatter.Serialize(myStream, this.extension);
                formatter.Serialize(myStream, this.extensionname);
                formatter.Serialize(myStream, this.heiht);
                formatter.Serialize(myStream, this.imageoverlay);
                formatter.Serialize(myStream, this.imageoverlayenabled);
                formatter.Serialize(myStream, this.jpegqual);
                formatter.Serialize(myStream, this.max);
                formatter.Serialize(myStream, this.maxmethod);
                formatter.Serialize(myStream, this.perc);
                formatter.Serialize(myStream, this.percmethod);
                formatter.Serialize(myStream, this.rename);
                formatter.Serialize(myStream, this.renamename);
                formatter.Serialize(myStream, this.resizequal);
                formatter.Serialize(myStream, this.shadowcolor);
                formatter.Serialize(myStream, this.shadowenable);
                formatter.Serialize(myStream, this.targetdir);
                formatter.Serialize(myStream, this.textoverlay);
                formatter.Serialize(myStream, this.textoverlayenabled);
                formatter.Serialize(myStream, this.width);

            }

            /// <summary>
            /// Deserialization
            /// </summary>
            /// <param name="myStream"></param>
            public void DeSerialize(Stream myStream, ref IFormatter formatter)
            {
                this.absolutemethod = (bool) formatter.Deserialize(myStream);
                this.dimlocked = (bool) formatter.Deserialize(myStream);
                this.extension = (bool) formatter.Deserialize(myStream);
                this.extensionname = (string) formatter.Deserialize(myStream);
                this.heiht = (int) formatter.Deserialize(myStream);
                this.imageoverlay = (CImage.ImageOverlay)formatter.Deserialize(myStream);
                this.imageoverlayenabled = (bool) formatter.Deserialize(myStream);
                this.jpegqual = (int) formatter.Deserialize(myStream);
                this.max = (int) formatter.Deserialize(myStream);
                this.maxmethod = (bool) formatter.Deserialize(myStream);
                this.perc = (int) formatter.Deserialize(myStream);
                this.percmethod = (bool) formatter.Deserialize(myStream);
                this.rename = (bool) formatter.Deserialize(myStream);
                this.renamename = (string) formatter.Deserialize(myStream);
                this.resizequal = (int) formatter.Deserialize(myStream);
                this.shadowcolor = (Color) formatter.Deserialize(myStream);
                this.shadowenable = (bool) formatter.Deserialize(myStream);
                this.targetdir = (string) formatter.Deserialize(myStream);
                this.textoverlay = (CImage.TextOverlay)formatter.Deserialize(myStream);
                this.textoverlayenabled = (bool) formatter.Deserialize(myStream);
                this.width = (int)formatter.Deserialize(myStream);
            }
        }

        public void Serialize(Stream myStream, ref IFormatter formatter)
        {
            memo.Serialize(myStream, ref formatter);
        }

        public void DeSerialize(Stream myStream, ref IFormatter formatter)
        {
            memo.DeSerialize(myStream, ref formatter);
        }

        public int processed
        {
            get
            {
                return _processed;
            }
        }

        public int total
        {
            get
            {
                return _total;
            }
        }

        public string processedname
        {
            get
            {
                return _processedname;
            }
        }

        /// <summary>
        /// Set horizontal scroll
        /// </summary>
        /// <param name="b"></param>
        public void SetHScroll(bool b)
        {
            this.HScroll = b;
        }

        /// <summary>
        /// Returns the id for the last item in the panel
        /// </summary>
        /// <returns></returns>
        private int CalculateInitialProgressive()
        {
            if (Controls.Count == 0) return 0;
            return ((UImage)(Controls[Controls.Count - 1])).GetNumberId();
        }

        /// <summary>
        /// Add a UImage control into this panel
        /// </summary>
        /// <param name="FileName"></param>
        public void AddUimageItem(string FileName)
        {
            if (checkduplicates(FileName) == false) // Check the presence of duplicates
            {
                UImage objuimg = new UImage();
                objuimg.Filename = FileName;
                if (objuimg.loadimage())
                {
                    this.AutoScroll = false;
                    this.SuspendLayout();
                       
                    try
                    {
                        if (Controls.Count % 2 == 0)
                        {
                            objuimg.SetBackgroundColor(BkRow1);
                            objuimg.pair = true;
                        }
                        else
                        {
                            objuimg.SetBackgroundColor(BkRow2);
                            objuimg.pair = false;
                        }
                        objuimg.Location = new Point(0, 0 + (objuimg.Height+1) * this.Controls.Count);
                        objuimg.deletedcontrol_delegate = deletedcontrol_delegate; // "link" the delegates for back handling. Very important
                        objuimg.expandimage_delegate = expandimage_delegate;
                        objuimg.mouseenter_delegate = mouseenter_delegate;
                        objuimg.workfinished_delegate = workfinished_delegate;
                        objuimg.SetNumberId(CalculateInitialProgressive()+1);
                        memo.setimage(ref objuimg);
                        this.Controls.Add(objuimg);
                    }
                    catch
                    {
                        objuimg.Dispose();
                    }
                this.ResumeLayout();
                this.AutoScroll = true;
                }
            }
        }

        /// <summary>
        /// Add a UImage control into this panel
        /// </summary>
        /// <param name="FileName"></param>
        public void AddUimageItem(string[] FileNames)
        {
            foreach (string filename in FileNames)
            {
                AddUimageItem(filename);
            }
        }

        /// <summary>
        /// Remove all items
        /// </summary>
        public void RemoveAll()
        {
            int total = Controls.Count;
            for (int i = 0; i < total ; i++)
            {
                this.RemoveUimageItem(((UImage)(Controls[0])).Filename);
            }
        }

        /// <summary>
        /// Remove all processed files
        /// </summary>
        public void RemoveProcessed()
        {
            int total = Controls.Count;
            for (int i = 0; i < total; i++)
            {
                if (((UImage)(Controls[i])).processed)
                {
                    this.RemoveUimageItem(((UImage)(Controls[i])).Filename);
                    total = Controls.Count;
                    i--;
                }
            }
        }

        /// <summary>
        /// Remove a UImage from panel
        /// </summary>
        /// <param name="FileName"></param>
        public void RemoveUimageItem(string FileName)
        {
            if (checkduplicates(FileName) == true) // Check the presence of duplicates
            {
                int yorpos = 0;
                foreach (UImage objimg in this.Controls)
                {
                // Rimuove il componente
                    if (objimg.Filename == FileName)
                    {
                        AutoScroll = false;
                        SuspendLayout();
                        yorpos = objimg.Location.Y; // Store the position of the removed item
                        Controls.Remove(objimg);
                        ResumeLayout();
                        AutoScroll = true;
                        objimg.Dispose();
                        break;
                    }
                }
                foreach (UImage objimg in this.Controls)
                {
                    if (objimg.Location.Y > yorpos)     // Shift (move) the items having position after the removed
                    {
                        int xpos = objimg.Location.X;
                        int ypos = objimg.Location.Y - objimg.Height;
                        Point poi = new Point(xpos, ypos);
                        objimg.Location = poi;
                        objimg.pair = !objimg.pair;
                        if (objimg.processed == false)
                        {
                            if (objimg.pair == true)
                            {
                                objimg.SetBackgroundColor(BkRow1);
                            }
                            else
                            {
                                objimg.SetBackgroundColor(BkRow2);
                            }
                        }
                        objimg.SetNumberId(objimg.GetNumberId() - 1);
                    }
                }
            }
        }

        /// <summary>
        /// Check if the file is yet present
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private bool checkduplicates(string Name)
        {
            foreach (UImage objimg in this.Controls)
            {
                if (objimg.Filename == Name) return true;
            }
            return false;
        }

        /// <summary>
        /// Invoked by controls to remove and dispose them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void deletedcontrol(object sender, EventArgs e)
        {
            try
            {
                UImage uitemp = (UImage)sender;
                RemoveUimageItem(uitemp.Filename);
            }
            catch
            {
                // This must not happen
            }
        }

        /// <summary>
        /// Set the target directory
        /// </summary>
        /// <param name="path"></param>
        public void SetTargetDir(string path)
        {
            memo.targetdir = path;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetTargetDir(path);       
            }
        }

        /// <summary>
        /// Set absolute target size
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="locked"></param>
        public void SetAbsoluteDim(int width, int height, bool locked)
        {
            memo.width = width;
            memo.heiht = height;
            memo.dimlocked = locked;
            memo.absolutemethod = true;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetLockXY(locked);
                objimg.SetTargetSize_Absolute(width, height);
            }
        }

        /// <summary>
        /// Set percent size
        /// </summary>
        /// <param name="percent"></param>
        /// <param name="locked"></param>
        public void SetPercentDim(int percent, bool locked)
        {
            memo.perc = percent;
            memo.dimlocked = locked;
            memo.percmethod = true;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetLockXY(locked);
                objimg.SetTargetSize_Percent(percent);
            }
        }

        /// <summary>
        /// Set max size
        /// </summary>
        /// <param name="max"></param>
        /// <param name="locked"></param>
        public void SetMaxDim(int max, bool locked)
        {
            memo.max = max;
            memo.dimlocked = locked;
            memo.maxmethod = true;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetLockXY(locked);
                objimg.SetTargetSize_Max(max);
            }
        }

        /// <summary>
        /// Set lock dim to mantein aspect ratio
        /// </summary>
        /// <param name="locked"></param>
        public void SetLockDim(bool locked)
        {
            memo.dimlocked = locked;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetLockXY(locked);
            }
        }

        /// <summary>
        /// Set resize quality
        /// </summary>
        /// <param name="quality"></param>
        public void SetResizeQuality(int quality)
        {
            memo.resizequal = quality;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetResizeQuality(quality);
            }        
        }

        /// <summary>
        /// Set Compression quality for Jpeg
        /// </summary>
        /// <param name="quality"></param>
        public void SetJPEGQuality(int quality)
        {
            memo.jpegqual = quality;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetCompressionQuality(quality);
            }
        }

        /// <summary>
        /// Activate or disactivate the automatic rename;
        /// </summary>
        /// <param name="ren"></param>
        public void SetRename(bool ren)
        {
            memo.rename = ren;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetRename(ren);
            }
        }

        /// <summary>
        /// Set name for rename
        /// </summary>
        /// <param name="name"></param>
        public void SetRenameStr(string name)
        {
            memo.renamename = name;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetRenameStr(name);
            }
        }

        /// <summary>
        /// Set if the file must be converted (gif -> jpg etc...)
        /// </summary>
        /// <param name="ext"></param>
        public void SetConversion(bool ext)
        {
            memo.extension = ext;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetConversion(ext);
            }
        }

        /// <summary>
        /// Set the extension / filetype
        /// </summary>
        /// <param name="extension"></param>
        public void SetConversionName(string extension)
        {
            memo.extensionname = extension;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetConversionName(extension);
            }
        }


        /// <summary>
        /// Set x position for text overlay
        /// </summary>
        /// <param name="xpos"></param>
        public void SetOverlayPositionX(CImage.XPosition xpos)
        {
            memo.textoverlay.xpos = xpos;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetOverlayPositionX(xpos);
            }
        }

        /// <summary>
        /// Set y position for text overlay
        /// </summary>
        /// <param name="ypos"></param>
        public void SetOverlayPositionY(CImage.YPosition ypos)
        {
            memo.textoverlay.ypos = ypos;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetOverlayPositionY(ypos);
            }
        }

        /// <summary>
        /// Enable or disable text overlay
        /// </summary>
        /// <param name="enabled"></param>
        public void SetEnableTextOverlay(bool enabled)
        {
            memo.textoverlayenabled = enabled;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetEnableTextOverlay(enabled);
            }
        }

        /// <summary>
        /// Set Font for overlay
        /// </summary>
        /// <param name="font"></param>
        public void SetFontOverlay(Font font)
        {
            memo.textoverlay.font = font;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetFont(font);
            }
        }

        /// <summary>
        /// Set text for overlay
        /// </summary>
        /// <param name="text"></param>
        public void SetTextOverlay(string text)
        {
            memo.textoverlay.Text = text;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetTextOverlay(text);
            }
        }

        /// <summary>
        /// Set the text color
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        public void SetTextColor(Color col)
        {
            memo.textoverlay.frontcolor = col;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetTextColor(col);
            }
        }

        /// <summary>
        /// Set the shape color
        /// </summary>
        /// <param name="col"></param>
        public void SetTextShape(Color col)
        {
            memo.textoverlay.shapecolor = col;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetShapeColor(col);
            }
        }

        /// <summary>
        ///  Enable or disable the shapes
        /// </summary>
        /// <param name="enabled"></param>
        /// <param name="rectangle"></param>
        /// <param name="ellipse"></param>
        public void SetShapes(bool enabled, bool rectangle, bool ellipse)
        {
            memo.textoverlay.Shape = enabled;
            memo.textoverlay.ShapeRectangle = rectangle;
            memo.textoverlay.ShapeEllipse = ellipse;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetShapes(enabled, rectangle, ellipse);
            }
        }

        /// <summary>
        /// Set transparency
        /// </summary>
        /// <param name="text"></param>
        /// <param name="shadow"></param>
        /// <param name="shape"></param>
        public void SetTransparency(short text, short shadow, short shape)
        {
            memo.textoverlay.trasp = text;
            memo.textoverlay.traspshadow = shadow;
            memo.textoverlay.transparencyshape = shape;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetTrasparency(text, shadow, shape);
            }
        }

        /// <summary>
        /// Set text reduction
        /// </summary>
        /// <param name="reduction"></param>
        public void SetTextReduction(int reduction)
        {
            memo.textoverlay.dim = reduction;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetTextReduction(reduction);
            }
        }

        /// <summary>
        /// Set 3d effect on text
        /// </summary>
        /// <param name="enabled"></param>
        public void SetText3D(bool enabled)
        {
            memo.textoverlay.D3effetc = enabled;
            foreach (UImage objimg in this.Controls)
            {
                objimg.Set3DTextEffect(enabled);
            }
        }

        /// <summary>
        /// Set watermark position x into image
        /// </summary>
        /// <param name="pos"></param>
        public void SetWatermarkPosX(CImage.XPosition pos)
        {
            memo.imageoverlay.xpos = pos;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetWatermarkPositionX(pos);
            }
        }

        /// <summary>
        /// Set watermark position y into image
        /// </summary>
        /// <param name="pos"></param>
        public void SetWatermarkPosY(CImage.YPosition pos)
        {
            memo.imageoverlay.ypos = pos;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetWatermarkPositionY(pos);
            }
        }

        /// <summary>
        /// Enable or disable the watermark over the image
        /// </summary>
        /// <param name="enabled"></param>
        public void SetWatermarkEnable(bool enabled)
        {
            memo.imageoverlayenabled = enabled;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetWatermarkEnable(enabled);
            }
        }

        /// <summary>
        /// Set the watermark filename
        /// </summary>
        /// <param name="filename"></param>
        public void SetWatermarkFilename(string filename)
        {
            memo.imageoverlay.path = filename;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetWatermarkPath(filename);
            }
        }

        /// <summary>
        /// Set the transparence of the watermark image
        /// </summary>
        /// <param name="transparence"></param>
        public void SetWatermarkTransparence(int transparence)
        {
            memo.imageoverlay.trasp = (short)transparence;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetWatermarkTransparence(transparence);
            }
        }

        /// <summary>
        /// Set the size of the watermark image related to the container image
        /// </summary>
        /// <param name="percent"></param>
        public void SetWatermarkPercent(int percent)
        {
            memo.imageoverlay.percdim = percent;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetWatrmarkPercen(percent);
            }
        }

        /// <summary>
        ///  Set the shadow background color
        /// </summary>
        /// <param name="col"></param>
        public void SetShadowColor(Color col)
        {
            memo.shadowcolor = col;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetShadowColor(col);
            }
        }

        /// <summary>
        /// Enable or disable the shadow effect
        /// </summary>
        /// <param name="enabled"></param>
        public void SetShadowEnabled(bool enabled)
        {
            memo.shadowenable = enabled;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetShadowEnable(enabled);
            }
        }

        /// <summary>
        /// Set watermark image transparent key
        /// </summary>
        /// <param name="col"></param>
        public void SetWaterTranspKey(Color col)
        {
            memo.imageoverlay.traspkey = col;
            foreach (UImage objimg in this.Controls)
            {
                objimg.SetWaterTraspKey(col);
            } 
        }

        /// <summary>
        /// Set thread number 
        /// </summary>
        /// <param name="count"></param>
        public void SetThreadNum(int count)
        {
            this.CONCURRENT_THREADS = count;
        }

        /// <summary>
        /// Invoked by controls to expand it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void expandimage(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Reset original color for background
        /// </summary>
        public void ResetOriginalColor()
        {
            foreach (UImage objimg in this.Controls)
            {
                objimg.ResetOriginalColor();
            } 
        }

        /// <summary>
        /// Perform the elaboration
        /// </summary>
        public bool Go()
        {
            if (this.Controls.Count == 0) return false;

            this.Cursor = Cursors.WaitCursor;
            // reset values
            for (int i = 0; i < Controls.Count; i++)
            {
                ((UImage)Controls[i]).processed = false;
                ((UImage)Controls[i]).started = false;
            }
            ResetOriginalColor();

            

            _total = this.Controls.Count;
            _processed = 0;
            index = 0;
            
            this.Cursor = Cursors.WaitCursor;

            

            for (int i = 0 ; i < 11; i++)
            {
                threads[i] = new Thread(StarkWork);
                threads[i].Priority = ThreadPriority.Lowest;
                threads[i].IsBackground = false;
            }

            int Simultaneous = CONCURRENT_THREADS;

            int interval = (int) Math.Floor((double)((double)total / (double)Simultaneous));
            int accumulator = 0;

            for (int i = 0; i < Simultaneous-1; i++)
            {
                ThreadInterval Bounds = new ThreadInterval();
                Bounds.LowerBound = accumulator;
                Bounds.UpperBound = accumulator+interval;
                threads[i].Start(Bounds);
                accumulator += interval;
            }
            ThreadInterval BoundsRemained = new ThreadInterval();
            BoundsRemained.LowerBound = accumulator;
            BoundsRemained.UpperBound = total;
            threads[Simultaneous].Start(BoundsRemained);


            return true;
        }

        /// <summary>
        /// Suspends the thread work
        /// </summary>
        public bool Suspend()
        {
            for (int i = 0; i < this.CONCURRENT_THREADS+1; i++)
            {
                if (threads[i] != null)
                {
                    if (threads[i].ThreadState == ThreadState.Running) threads[i].Suspend();
                }
            }
            this.Cursor = Cursors.Arrow;
            return true;
        }

        /// <summary>
        /// Abort the thread work
        /// </summary>
        public bool Abort()
        {
            for (int i = 0; i < this.CONCURRENT_THREADS+1; i++)
            {
                if (threads[i] != null)
                {
                    if (threads[i].ThreadState != ThreadState.Aborted)
                    {

                        if (threads[i].ThreadState == ThreadState.Suspended)
                        {
                            threads[i].Resume();
                            Thread.Sleep(50);
                            if (threads[i].ThreadState != ThreadState.Suspended) threads[i].Abort();
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            threads[i].Abort();
                        }
                    }
                }
            }
            this.Cursor = Cursors.Arrow;
            return true;
        }

        /// <summary>
        /// Resume the thread work
        /// </summary>
        public bool Resume()
        {
            for (int i = 0; i < this.CONCURRENT_THREADS+1; i++)
            {
                if (threads[i] != null)
                {
                    if (threads[i].ThreadState == ThreadState.Suspended) threads[i].Resume();
                }
            }
            this.Cursor = Cursors.WaitCursor;
            return true;
        }

        /// <summary>
        /// Starts the work processing
        /// </summary>
        private void StarkWork(object obj)
        {
            for (int i = (((ThreadInterval)obj).LowerBound); i < (((ThreadInterval)obj).UpperBound); i++)
            {
                ((UImage)Controls[i]).Go();
            }
        }

        /// <summary>
        /// Occurs when a work ends
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void workfinished(object sender, EventArgs e)
        {
            _processedname = (((UImage)sender).Filename);
            
            ((UImage)sender).SetHighLightColor(Color.Green);
            
            if (processed < total)
            {
                index++;
                _processed++;
            }
            if (processed == total)
            {
                this.Cursor = Cursors.Default;
                _processed = _total;
            }
            if (processed > total)
            {
                _processed = _total;
            }
            
        }

        /// <summary>
        /// Class used to pass to bounds to the thread (used to divide the entire work into smaller)
        /// </summary>
        public class ThreadInterval
        {
            public ThreadInterval()
            {
            }
            public int LowerBound;
            public int UpperBound;
        }
    }
}
