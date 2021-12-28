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
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;   // Not used (use alternativelly;
using System.Runtime.Serialization.Formatters.Soap;


namespace BatchImageConverter
{
    public partial class UImageContainer : UserControl
    {
        public System.EventHandler expandimage_delegate; // called when a control is expanded
        public System.EventHandler mouseenter_delegate; // Called when the mouse enter in a control
        public System.EventHandler workfinished_delegate;
        public System.EventHandler workfinishedall_delegate; 
        public bool button_Apply = false;   // Used to blink button1
        private Form1 frm;
        private bool waterselectcolor = false;
        CFile cf;
        Bitmap bit = new Bitmap(10, 10);
        private string lastok = "Image";

        /// <summary>
        /// Constructor
        /// </summary>
        public UImageContainer()
        {
            InitializeComponent();
            this.uDirTree1.OnReturn += new UDirTree.ReturnHandler(TreeViewEvent);
            this.Load += new EventHandler(UImageContainer_Load);
            cf = new CFile(); // Used as a filter for file extension
            expandimage_delegate = new System.EventHandler(expandimage);
            mouseenter_delegate = new System.EventHandler(mouseenter);
            workfinished_delegate = new System.EventHandler(workfinished);  
            this.panello1.expandimage_delegate = this.expandimage_delegate;
            this.panello1.mouseenter_delegate = this.mouseenter_delegate;
            this.panello1.workfinished_delegate = this.workfinished_delegate;
            this.auxpanel.BringToFront();
            this.auxpanel.Dock = DockStyle.Fill;
            this.panello1.BringToFront();
            this.panello1.Dock = DockStyle.Fill;
            this.timer_Button_Blink.Start();
            this.pictureBox_WatermarkPreview.MouseUp += new MouseEventHandler(pictureBox_WatermarkPreview_MouseUp);
            this.pictureBox_WatermarkPreview.MouseMove += new MouseEventHandler(pictureBox_WatermarkPreview_MouseMove);
        }

        void pictureBox_WatermarkPreview_MouseMove(object sender, MouseEventArgs e)
        {
            GetColor();
        }

        /// <summary>
        /// Catck the mouseclick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pictureBox_WatermarkPreview_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) waterselectcolor = true;
            else waterselectcolor = false;
        }

        /// <summary>
        /// Event on load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UImageContainer_Load(object sender, EventArgs e)
        {
            //frm = (Form1)this.Parent;
            //updateformparent();   // This is better, but causes an error on VS form viewer
        }

        /// <summary>
        /// Update the parent form to access some controls
        /// </summary>
        private void updateformparent()
        {
            frm = (Form1)this.Parent;
        }

        /// <summary>
        /// Serializes the status of settings
        /// </summary>
        public void SerializePanel(Stream myStream, ref IFormatter formatter)
        {
            this.SerializeThis(myStream, ref formatter);
            this.panello1.Serialize(myStream,ref formatter);
            
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="myStream"></param>
        public void DeSerializePanel(Stream myStream,ref IFormatter formatter)
        {
            this.DeSerializeThis(myStream, ref formatter);
            this.panello1.DeSerialize(myStream,ref formatter);
            
        }

        /// <summary>
        /// Serialize some controls value
        /// </summary>
        /// <param name="myStream"></param>
        private void SerializeThis(Stream myStream, ref IFormatter formatter)
        {
            formatter.Serialize(myStream,this.textBox_DestinationPath.Text);
            formatter.Serialize(myStream, this.textBox_FontFamily.Text);
            formatter.Serialize(myStream, this.textBox_Overlay_text.Text);
            formatter.Serialize(myStream, this.textBox_Rename.Text);
            formatter.Serialize(myStream, this.textBox_Watermark_ImgFile.Text);
            formatter.Serialize(myStream, this.checkBox_Ellipse.Checked);
            formatter.Serialize(myStream, this.checkBox_Extension.Checked);
            formatter.Serialize(myStream, this.checkBox_Font_Bold.Checked);
            formatter.Serialize(myStream, this.checkBox_Italic.Checked);
            formatter.Serialize(myStream, this.checkBox_Lock_Dim.Checked);
            formatter.Serialize(myStream, this.checkBox_Overlay_3D.Checked);
            formatter.Serialize(myStream, this.checkBox_Overlay_Enabled.Checked);
            formatter.Serialize(myStream, this.checkBox_Rectangle.Checked);
            formatter.Serialize(myStream, this.checkBox_Rename.Checked);
            formatter.Serialize(myStream, this.checkBox_Shadow.Checked);
            formatter.Serialize(myStream, this.checkBox_ShapesEnabled.Checked);
            formatter.Serialize(myStream, this.checkBox_WatermarkEnabled.Checked);
            formatter.Serialize(myStream, this.comboBox_Extension.SelectedIndex);
            formatter.Serialize(myStream, this.comboBox_Overlay_PosX.SelectedIndex);
            formatter.Serialize(myStream, this.comboBox_Overlay_PosY.SelectedIndex);
            formatter.Serialize(myStream, this.comboBox_Watermark_PosX.SelectedIndex);
            formatter.Serialize(myStream, this.comboBox_Watermark_PosY.SelectedIndex);
            formatter.Serialize(myStream, this.numericUpDown_Height.Value);
            formatter.Serialize(myStream, this.numericUpDown_Max.Value);
            formatter.Serialize(myStream, this.numericUpDown_Perc.Value);
            formatter.Serialize(myStream, this.numericUpDown_Thread.Value);
            formatter.Serialize(myStream, this.numericUpDown_Width.Value);
            formatter.Serialize(myStream, this.pictureBox_Overlay_Text_Color.BackColor);
            formatter.Serialize(myStream, this.pictureBox_OverlayShapeColor.BackColor);
            formatter.Serialize(myStream, this.pictureBox_Shadow_Color.BackColor);
            //formatter.Serialize(myStream, this.pictureBox_WatermarkPreview.Image);
            formatter.Serialize(myStream, this.pictureBox_WatermarkTraspKey.BackColor);
            formatter.Serialize(myStream, this.pictureBox_WatermarkTraspKeySelected.BackColor);
            formatter.Serialize(myStream, this.radioButton_Fixed.Checked);
            formatter.Serialize(myStream, this.radioButton_Max.Checked);
            formatter.Serialize(myStream, this.radioButton_Percent.Checked);
            formatter.Serialize(myStream, this.trackBar_JPEG.Value);
            formatter.Serialize(myStream, this.trackBar_Overlay_ShadowTrasp.Value);
            formatter.Serialize(myStream, this.trackBar_Overlay_ShapeTransp.Value);
            formatter.Serialize(myStream, this.trackBar_Overlay_TextReduction.Value);
            formatter.Serialize(myStream, this.trackBar_Overlay_TextTransp.Value);
            formatter.Serialize(myStream, this.trackBar_Resize_Quality.Value);
            formatter.Serialize(myStream, this.trackBar_Watermark_Transp.Value);
            formatter.Serialize(myStream, this.trackBar_WatermarkPerc.Value);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="myStream"></param>
        private void DeSerializeThis(Stream myStream,ref IFormatter formatter)
        {       
            this.textBox_DestinationPath.Text= (string)formatter.Deserialize(myStream);
            this.textBox_FontFamily.Text = (string)formatter.Deserialize(myStream);
            this.textBox_Overlay_text.Text = (string)formatter.Deserialize(myStream);
            this.textBox_Rename.Text = (string)formatter.Deserialize(myStream);
            this.textBox_Watermark_ImgFile.Text = (string)formatter.Deserialize(myStream);
            this.checkBox_Ellipse.Checked = (bool)formatter.Deserialize(myStream);
            this.checkBox_Extension.Checked = (bool)formatter.Deserialize(myStream);
            this.checkBox_Font_Bold.Checked= (bool)formatter.Deserialize(myStream);
            this.checkBox_Italic.Checked= (bool)formatter.Deserialize(myStream);
            this.checkBox_Lock_Dim.Checked= (bool)formatter.Deserialize(myStream);
            this.checkBox_Overlay_3D.Checked= (bool)formatter.Deserialize(myStream);
            this.checkBox_Overlay_Enabled.Checked= (bool)formatter.Deserialize(myStream);
            this.checkBox_Rectangle.Checked = (bool)formatter.Deserialize(myStream);
            this.checkBox_Rename.Checked= (bool)formatter.Deserialize(myStream);
            this.checkBox_Shadow.Checked= (bool)formatter.Deserialize(myStream);
            this.checkBox_ShapesEnabled.Checked= (bool)formatter.Deserialize(myStream);
            this.checkBox_WatermarkEnabled.Checked= (bool)formatter.Deserialize(myStream);
            this.comboBox_Extension.SelectedIndex= (int)formatter.Deserialize(myStream);
            this.comboBox_Overlay_PosX.SelectedIndex= (int)formatter.Deserialize(myStream);
            this.comboBox_Overlay_PosY.SelectedIndex = (int)formatter.Deserialize(myStream);
            this.comboBox_Watermark_PosX.SelectedIndex = (int)formatter.Deserialize(myStream);
            this.comboBox_Watermark_PosY.SelectedIndex= (int)formatter.Deserialize(myStream);
            this.numericUpDown_Height.Value = (decimal)formatter.Deserialize(myStream);
            this.numericUpDown_Max.Value = (decimal)formatter.Deserialize(myStream);
            this.numericUpDown_Perc.Value = (decimal)formatter.Deserialize(myStream);
            this.numericUpDown_Thread.Value = (decimal)formatter.Deserialize(myStream);
            this.numericUpDown_Width.Value = (decimal)formatter.Deserialize(myStream);
            this.pictureBox_Overlay_Text_Color.BackColor = (Color)formatter.Deserialize(myStream);
            this.pictureBox_OverlayShapeColor.BackColor = (Color)formatter.Deserialize(myStream);
            this.pictureBox_Shadow_Color.BackColor = (Color)formatter.Deserialize(myStream);
            //this.pictureBox_WatermarkPreview.Image = (Image)formatter.Deserialize(myStream);
            this.pictureBox_WatermarkTraspKey.BackColor = (Color)formatter.Deserialize(myStream);
            this.pictureBox_WatermarkTraspKeySelected.BackColor = (Color)formatter.Deserialize(myStream);
            this.radioButton_Fixed.Checked= (bool)formatter.Deserialize(myStream);
            this.radioButton_Max.Checked= (bool)formatter.Deserialize(myStream);
            this.radioButton_Percent.Checked= (bool)formatter.Deserialize(myStream);
            this.trackBar_JPEG.Value= (int)formatter.Deserialize(myStream);
            this.trackBar_Overlay_ShadowTrasp.Value= (int)formatter.Deserialize(myStream);
            this.trackBar_Overlay_ShapeTransp.Value= (int)formatter.Deserialize(myStream);
            this.trackBar_Overlay_TextReduction.Value= (int)formatter.Deserialize(myStream);
            this.trackBar_Overlay_TextTransp.Value= (int)formatter.Deserialize(myStream);
            this.trackBar_Resize_Quality.Value= (int)formatter.Deserialize(myStream);
            this.trackBar_Watermark_Transp.Value= (int)formatter.Deserialize(myStream);
            this.trackBar_WatermarkPerc.Value = (int)formatter.Deserialize(myStream);
        }

        /// <summary>
        /// Add a UImage control into this panel
        /// </summary>
        /// <param name="FileName"></param>
        public void AddUimageItem(string[] FileNames)
        {
            this.panello1.AddUimageItem(FileNames);
        }

        /// <summary>
        /// Add a UImage control into this panel
        /// </summary>
        /// <param name="FileName"></param>
        public void AddUimageItem(string DirName)
        {
            this.AddRemoveItem(DirName, ref cf, true);
        }

        /// <summary>
        /// Remove all items
        /// </summary>
        public void RemoveAll()
        {
            this.panello1.RemoveAll();
        }

        /// <summary>
        /// Remove all processed items 
        /// </summary>
        public void RemoveProcessed()
        {
            this.panello1.RemoveProcessed();
        }

        /// <summary>
        /// Show settings tab
        /// </summary>
        public void ShowSettings()
        {
            this.panel_Settings.BringToFront();
        }

        /// <summary>
        /// Show work panel
        /// </summary>
        public void ShowWorkPanel()
        {
            this.panello1.BringToFront();
        }

        /// <summary>
        /// Check file extension
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>true if valid</returns>
        private bool validextension(string filename)
        {
            if (Directory.Exists(filename)) return false;
            if (!File.Exists(filename)) return false;
            IDictionaryEnumerator en = cf.extension.GetEnumerator();
            while (en.MoveNext())
            {
                FileInfo fi = new FileInfo(filename);
                string extension = fi.Extension;
                if (extension.ToLower() == "." + (string)en.Key) return true;
            }
            return false;

        }
       
        /// <summary>
        /// Show the image for preview
        /// </summary>
        /// <param name="filename"></param>
        private void setpreviewimage(string filename)
        {
            if (validextension(filename))
            {
                try
                {
                    this.filePreview1.SetImage(filename); // Set the preview
                    //this.filePreview1.SetLabels(filename, 0, 0); // Set the labels
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    this.filePreview1.SetImage(ref bit); // Set the preview 
                    this.filePreview1.SetLabels(filename, 0, 0); // Set the labels
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// Handles for events on dirtree user control
        /// </summary>
        /// <param name="a"></param>
        /// <param name="e"></param>
        void TreeViewEvent(object a, CArgs e)
        {
            if (e.Ret.preview == true)
            {
                setpreviewimage(e.Ret.Node.Name); 
            }
            else
            {
                if (e.Ret.add)
                {
                    AddRemoveItem(e.Ret.Node.Name, ref cf, true);
                    if (validextension(e.Ret.Node.Name))  e.Ret.Node.ForeColor = Color.Blue;
                }
                else
                {
                    AddRemoveItem(e.Ret.Node.Name, ref cf, false);
                    if (validextension(e.Ret.Node.Name)) e.Ret.Node.ForeColor = Color.Black;
                }
            }
        }
        
        /// <summary>
        /// Handle the add/remove from panel
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="cf"></param>
        /// <param name="addremove"></param>
        private void AddRemoveItem(string dir, ref CFile cf, bool addremove)
        {
            int ItemsAdded = 0;
            if (addremove) this.setparentstriplabel2("Adding images");
                else this.setparentstriplabel2("Removing images");
            // if "DIR" is a directory
            if (Directory.Exists(dir))
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                FileInfo[] rgFiles = di.GetFiles("*.xxx");
                IDictionaryEnumerator en = cf.extension.GetEnumerator();

                // Sets the progressbar max value
                this.setparentprogressbarmax(calculateitems(en, rgFiles, di));
               
                while (en.MoveNext())
                {
                    rgFiles = di.GetFiles("*" + (string)en.Key);
                    // List every files
                    foreach (FileInfo fi in rgFiles)
                    {
                        if (File.Exists(fi.FullName))
                        {
                            // Sets the statustrip and the progressbar
                            this.setparentstriplabel1(fi.Name);
                            ItemsAdded++;
                            this.setparentprogressbarval(ItemsAdded);
                            if (addremove)
                            {
                                this.panello1.AddUimageItem(fi.FullName);
                            }
                            else
                            {
                                this.panello1.RemoveUimageItem(fi.FullName);
                            }
                        }

                    }
                }

            }
            else // "Dir" is a file
            {
                if (File.Exists(dir))
                {
                    IDictionaryEnumerator en = cf.extension.GetEnumerator();

                    while (en.MoveNext())
                    {
                        FileInfo fi = new FileInfo(dir);
                        string extension = fi.Extension;
                        if (extension.ToLower() == "."+(string)en.Key)
                        {
                            // Set the statustrip
                            this.setparentstriplabel1(fi.Name);
                            ItemsAdded++;
                            if (addremove)
                            {
                                this.panello1.AddUimageItem(dir);
                            }
                            else
                            {
                                this.panello1.RemoveUimageItem(dir);
                            }
                        }
                    }
                }
            }
            // Set the statustrip labels and the progressbar
            this.setparentprogressbarval(0);
            string s = "s";
            if (ItemsAdded == 1) s = ""; 
            if (addremove) this.setparentstriplabel1(ItemsAdded.ToString() + " image"+s+" added");
            else this.setparentstriplabel1(ItemsAdded.ToString() + " image"+s+ " removed");
            this.setparentstriplabel2("Ready");
            panello1.ResumeLayout();
            panello1.AutoScroll = true;
        }

        /// <summary>
        /// Calculate the numbers of valid files (considering extension)
        /// </summary>
        /// <param name="en"></param>
        /// <param name="rgFiles"></param>
        /// <returns></returns>
        private int calculateitems(IDictionaryEnumerator en, FileInfo[] rgFiles, DirectoryInfo di)
        {
            int ret = 0;
            while (en.MoveNext())
            {
                rgFiles = di.GetFiles("*" + (string)en.Key);
                // List every files
                foreach (FileInfo fi in rgFiles)
                {
                    if (File.Exists(fi.FullName))
                    {
                        ret++;
                    }
                }
            }
            en.Reset();
            return ret;
        }

        /// <summary>
        /// Handle the image expansion - show
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void expandimage(object sender, EventArgs e)
        {
            this.auxpanel.Dock = DockStyle.Fill;
            ExpandedImage esp = new ExpandedImage();
            esp.Location = new Point(0, 0);
            esp.BringToFront();
            esp.Visible = true;
            esp.Parent = this.auxpanel;
            UImage uitemp = (UImage)sender;
            esp.setimage(new Bitmap(uitemp.Filename));
            esp.BringToFront();
            auxpanel.BringToFront();
            esp.expand();
        }

        /// <summary>
        /// Handle the mouseenter on a control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mouseenter(object sender, EventArgs e)
        {
            UImage uip = (UImage)sender;
            
            this.filePreview1.SetImage(uip.Filename); // Set the preview 
            this.filePreview1.SetLabels(uip.Filename, 0, 0); // Set the labels   
        }
        /// <summary>
        /// Called when a work is finished
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void workfinished(object sender, EventArgs e)
        {
            this.panello1.workfinished(sender, e);

            this.setparentprogressbarmax(panello1.total);
            int total = panello1.total;
            int processed = panello1.processed;
            if (processed == total)
            {
                this.setparentprogressbarval(0);
                this.setparentstriplabel2("Ready");
                this.setparentstriplabel1("work finished");
                workfinishedall_delegate.Invoke(this, null);
                this.panel_Settings.Enabled = true;
            }
            else
            {
                this.setparentprogressbarval(processed);
                this.setparentstriplabel2("Processing... please wait");
                CUtilitties utilityes = new CUtilitties();
                this.setparentstriplabel1("Image "+processed.ToString()+"/"+total.ToString()+" ->"+utilityes.getfilename(panello1.processedname) + " processed");
            }
        }

        /// <summary>
        /// Set the statusstrip label2
        /// </summary>
        /// <param name="text"></param>
        private void setparentstriplabel2(String text)
        {
            updateformparent();
            frm.toolStripStatusLabel2.Text = text;
            //frm.toolStripStatusLabel2.Invalidate();
        }

        /// <summary>
        /// Set the statusstrip label1
        /// </summary>
        /// <param name="text"></param>
        private void setparentstriplabel1(String text)
        {
            updateformparent();
            frm.toolStripStatusLabel1.Text = text;
            //frm.toolStripStatusLabel1.Invalidate();
        }

        /// <summary>
        /// Set the maximum value for progressbar
        /// </summary>
        /// <param name="text"></param>
        private void setparentprogressbarmax(int max)
        {
            updateformparent();
            frm.toolStripProgressBar1.Maximum = max;
        }

        /// <summary>
        /// Set the value for progressbar
        /// </summary>
        /// <param name="text"></param>
        private void setparentprogressbarval(int val)
        {
            updateformparent();
            frm.toolStripProgressBar1.Value = val;
            //frm.toolStripProgressBar1.Invalidate();
        }
        /// <summary>
        /// Start the elaboration
        /// </summary>
        public bool Go()
        {
            
            bool ret = this.panello1.Go();
            if (ret) this.panel_Settings.Enabled = false;
            return ret;
        }

        /// <summary>
        /// Suspend courrent work
        /// </summary>
        public bool Suspend()
        {
            return this.panello1.Suspend();
        }

        public bool Resume()
        {
            return this.panello1.Resume();
        }

        public bool Abort()
        {
            return this.panello1.Abort();
        }

        private void button_Browse_target_Dir_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Choose directory for output";
            DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string outputdir = folderBrowserDialog1.SelectedPath;
                if (!Directory.Exists(outputdir))
                {
                    try
                    {
                        Directory.CreateDirectory(outputdir);
                    }
                    catch
                    {
                        MessageBox.Show("Error creating Directory", "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                this.textBox_DestinationPath.Text = outputdir;
                panello1.SetTargetDir(outputdir+"\\");
                
            }
        }

        /// <summary>
        /// Apply button on size groupbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Apply_Size_Click(object sender, EventArgs e)
        {
            button_Apply = false;
            this.button_Apply_Size.BackColor = Color.Yellow;

            if (this.radioButton_Fixed.Checked == true)
            {
                this.panello1.SetAbsoluteDim((int)this.numericUpDown_Width.Value, (int)this.numericUpDown_Height.Value, this.checkBox_Lock_Dim.Checked);
            }
            if (this.radioButton_Percent.Checked == true)
            {
                this.panello1.SetPercentDim((int)this.numericUpDown_Perc.Value, this.checkBox_Lock_Dim.Checked);
            }
            if (this.radioButton_Max.Checked == true)
            {
                this.panello1.SetMaxDim((int)this.numericUpDown_Max.Value, this.checkBox_Lock_Dim.Checked);
            }
            this.button_Apply_Size.BackColor = Color.White;
        }

        /// <summary>
        /// Timer for blinking button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Button_Blink_Tick(object sender, EventArgs e)
        {
            if (button_Apply)
            {
                if (this.button_Apply_Size.BackColor != Color.Red) this.button_Apply_Size.BackColor = Color.Red;
                else this.button_Apply_Size.BackColor = Color.White;
            }

        }

        private void numericUpDown_Width_ValueChanged(object sender, EventArgs e)
        {
            button_Apply = true;
        }

        private void numericUpDown_Height_ValueChanged(object sender, EventArgs e)
        {
            button_Apply = true;
        }

        private void radioButton_Fixed_CheckedChanged(object sender, EventArgs e)
        {
            button_Apply = true;
        }

        private void numericUpDown_Perc_ValueChanged(object sender, EventArgs e)
        {
            button_Apply = true;
        }

        private void radioButton_Percent_CheckedChanged(object sender, EventArgs e)
        {
            button_Apply = true;
        }

        private void checkBox_Lock_Dim_CheckedChanged(object sender, EventArgs e)
        {
            button_Apply = true;
        }

        private void numericUpDown_Max_ValueChanged(object sender, EventArgs e)
        {
            button_Apply = true;
        }

        private void radioButton_Max_CheckedChanged(object sender, EventArgs e)
        {
            button_Apply = true;
        }

        private void trackBar_Resize_Quality_Scroll(object sender, EventArgs e)
        {
            this.panello1.SetResizeQuality(6 - this.trackBar_Resize_Quality.Value);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.panello1.SetJPEGQuality(this.trackBar_JPEG.Value);
            this.label_JPEG.Text = this.trackBar_JPEG.Value.ToString() + "//100";
        }

        private void comboBox_Overlay_PosX_SelectedIndexChanged(object sender, EventArgs e)
        {
            CImage.XPosition pos = CImage.XPosition.Right;
            if (comboBox_Overlay_PosX.SelectedIndex == 0)
            {
                pos = CImage.XPosition.Right;
                this.label_textpreview.Location = new Point(this.groupBox_Preview.Location.X + 150, this.label_textpreview.Location.Y);
            }
            if (comboBox_Overlay_PosX.SelectedIndex == 1)
            {
                pos = CImage.XPosition.Center;
                this.label_textpreview.Location = new Point(this.groupBox_Preview.Location.X + 70, this.label_textpreview.Location.Y);
            }
            if (comboBox_Overlay_PosX.SelectedIndex == 2)
            {
                pos = CImage.XPosition.Left;
                this.label_textpreview.Location = new Point(this.groupBox_Preview.Location.X + 5, this.label_textpreview.Location.Y);
            }
            this.panello1.SetOverlayPositionX(pos);
        }

        private void comboBox_Overlay_PosY_SelectedIndexChanged(object sender, EventArgs e)
        {
            CImage.YPosition pos = CImage.YPosition.Up;
            if (comboBox_Overlay_PosY.SelectedIndex == 0)
            {
                pos = CImage.YPosition.Up;
                this.label_textpreview.Location = new Point(this.label_textpreview.Location.X, this.groupBox_Preview.Location.Y + 5);
            }
            if (comboBox_Overlay_PosY.SelectedIndex == 1)
            {
                pos = CImage.YPosition.Center;
                this.label_textpreview.Location = new Point(this.label_textpreview.Location.X, this.groupBox_Preview.Location.Y + 55);
            }
            if (comboBox_Overlay_PosY.SelectedIndex == 2)
            {
                pos = CImage.YPosition.Bottom;
                this.label_textpreview.Location = new Point(this.label_textpreview.Location.X, this.groupBox_Preview.Location.Y + 115);
            }
            this.panello1.SetOverlayPositionY(pos);
        }

        private void checkBox_Overlay_Enabled_CheckedChanged(object sender, EventArgs e)
        {
            this.panel1.Enabled = checkBox_Overlay_Enabled.Checked;
            this.panello1.SetEnableTextOverlay(checkBox_Overlay_Enabled.Checked);
        }

        private void button_Font_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = this.fontDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            Font TextFont = fontDialog1.Font;
            this.textBox_FontFamily.Text = TextFont.FontFamily.Name;
            this.checkBox_Font_Bold.Checked = TextFont.Bold;
            this.checkBox_Italic.Checked = TextFont.Italic;
            panello1.SetFontOverlay(TextFont);
        }

        private void textBox_Overlay_text_TextChanged(object sender, EventArgs e)
        {
            this.panello1.SetTextOverlay(this.textBox_Overlay_text.Text);
        }

        private void button_OverlayTextColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = this.pictureBox_Overlay_Text_Color.BackColor;
            DialogResult result;
            result = this.colorDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            this.pictureBox_Overlay_Text_Color.BackColor = colorDialog1.Color;
            
        }

        private void button_OverlayShapeColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = this.pictureBox_OverlayShapeColor.BackColor;
            DialogResult result;
            result = this.colorDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            this.pictureBox_OverlayShapeColor.BackColor = colorDialog1.Color;
            
        }

        private void trackBar_Overlay_TextTransp_Scroll(object sender, EventArgs e)
        {
            this.panello1.SetTransparency((short)this.trackBar_Overlay_TextTransp.Value, (short)this.trackBar_Overlay_ShadowTrasp.Value, (short)this.trackBar_Overlay_ShapeTransp.Value);
        }

        private void trackBar_Overlay_ShadowTrasp_Scroll(object sender, EventArgs e)
        {
            this.panello1.SetTransparency((short)this.trackBar_Overlay_TextTransp.Value, (short)this.trackBar_Overlay_ShadowTrasp.Value, (short)this.trackBar_Overlay_ShapeTransp.Value);
        }

        private void trackBar_Overlay_ShapeTransp_Scroll(object sender, EventArgs e)
        {
            this.panello1.SetTransparency((short)this.trackBar_Overlay_TextTransp.Value, (short)this.trackBar_Overlay_ShadowTrasp.Value, (short)this.trackBar_Overlay_ShapeTransp.Value);
        }

        private void checkBox_ShapesEnabled_CheckedChanged(object sender, EventArgs e)
        {
            this.panello1.SetShapes(this.checkBox_ShapesEnabled.Checked, this.checkBox_Rectangle.Checked, this.checkBox_Ellipse.Checked);
        }

        private void checkBox_Rectangle_CheckedChanged(object sender, EventArgs e)
        {
            this.panello1.SetShapes(this.checkBox_ShapesEnabled.Checked, this.checkBox_Rectangle.Checked, this.checkBox_Ellipse.Checked);
        }

        private void checkBox_Ellipse_CheckedChanged(object sender, EventArgs e)
        {
            this.panello1.SetShapes(this.checkBox_ShapesEnabled.Checked, this.checkBox_Rectangle.Checked, this.checkBox_Ellipse.Checked);
        }

        private void trackBar_Overlay_TextReduction_Scroll(object sender, EventArgs e)
        {
            this.panello1.SetTextReduction(this.trackBar_Overlay_TextReduction.Value);
        }

        private void checkBox_Overlay_3D_CheckedChanged(object sender, EventArgs e)
        {
            this.panello1.SetText3D(checkBox_Overlay_3D.Checked);
        }

        private void checkBox_WatermarkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            this.panel2.Enabled = this.checkBox_WatermarkEnabled.Checked;
            this.panello1.SetWatermarkEnable(this.checkBox_WatermarkEnabled.Checked);
        }

        private void comboBox_Watermark_PosX_SelectedIndexChanged(object sender, EventArgs e)
        {
            CImage.XPosition pos = CImage.XPosition.Right;
            if (comboBox_Watermark_PosX.SelectedIndex == 0)
            {
                pos = CImage.XPosition.Right;
                this.label_Logo.Location = new Point(this.groupBox5.Location.X + 150, this.label_Logo.Location.Y);
            }
            if (comboBox_Watermark_PosX.SelectedIndex == 1)
            {
                pos = CImage.XPosition.Center;
                this.label_Logo.Location = new Point(this.groupBox5.Location.X + 70, this.label_Logo.Location.Y);
            }
            if (comboBox_Watermark_PosX.SelectedIndex == 2)
            {
                pos = CImage.XPosition.Left;
                this.label_Logo.Location = new Point(this.groupBox5.Location.X + 5, this.label_Logo.Location.Y);
            }
            this.panello1.SetWatermarkPosX(pos);
        }

        private void comboBox_Watermark_PosY_SelectedIndexChanged(object sender, EventArgs e)
        {
            CImage.YPosition pos = CImage.YPosition.Up;
            if (comboBox_Watermark_PosY.SelectedIndex == 0)
            {
                pos = CImage.YPosition.Up;
                this.label_Logo.Location = new Point(this.label_Logo.Location.X, this.groupBox5.Location.Y + 5);
            }
            if (comboBox_Watermark_PosY.SelectedIndex == 1)
            {
                pos = CImage.YPosition.Center;
                this.label_Logo.Location = new Point(this.label_Logo.Location.X, this.groupBox5.Location.Y + 55);
            }
            if (comboBox_Watermark_PosY.SelectedIndex == 2)
            {
                pos = CImage.YPosition.Bottom;
                this.label_Logo.Location = new Point(this.label_Logo.Location.X, this.groupBox5.Location.Y + 115);
            }
            this.panello1.SetWatermarkPosY(pos);
        }

        private void button_WatermarkFile_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            try
            {
                if (!File.Exists(openFileDialog1.FileName)) return;
                Bitmap test = new Bitmap(openFileDialog1.FileName);
                this.pictureBox_WatermarkPreview.Image = test;
                //test.Dispose(); // Don't dispopse because it is used in preview picturebox
                this.textBox_Watermark_ImgFile.Text = openFileDialog1.FileName;
                this.panello1.SetWatermarkFilename(openFileDialog1.FileName);
            }
            catch
            {
                MessageBox.Show("Error opening " + openFileDialog1.FileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trackBar_Watermark_Transp_Scroll(object sender, EventArgs e)
        {
            this.label_WatermarkOpacity.Text = ((int)((float)trackBar_Watermark_Transp.Value / 255 * 100)).ToString();
            this.panello1.SetWatermarkTransparence(trackBar_Watermark_Transp.Value);
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            this.label_WatermarkPerc.Text = trackBar_WatermarkPerc.Value.ToString() + "%";
            this.panello1.SetWatermarkPercent(trackBar_WatermarkPerc.Value);
        }

        private void checkBox_Shadow_CheckedChanged(object sender, EventArgs e)
        {
            this.panel3.Enabled = checkBox_Shadow.Checked;
            this.panello1.SetShadowEnabled(checkBox_Shadow.Checked);
        }

        private void button_Shadow_Color_Click(object sender, EventArgs e)
        {
            DialogResult result;
            colorDialog1.Color = this.pictureBox_Shadow_Color.BackColor;
            result = colorDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            this.pictureBox_Shadow_Color.BackColor = colorDialog1.Color;
            this.panello1.SetShadowColor(colorDialog1.Color);
        }

        void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        }

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateDC(string strDriver, string strDevice,
                                             string strOutput, IntPtr pData);
        [DllImport("gdi32.dll")]
        private static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern int GetPixel(IntPtr hdc, int x, int y);

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(ref Point lpPoint);

        /// <summary>
        /// Get the color relative to mouse position
        /// </summary>
        private void GetColor()
        {
            IntPtr hdcScreen = CreateDC("Display", null, null, IntPtr.Zero);
            Point pt = new Point();
            GetCursorPos(ref pt);
            int cr = GetPixel(hdcScreen, pt.X, pt.Y);
            DeleteDC(hdcScreen);
            Color clr = Color.FromArgb((cr & 0x000000FF),(cr & 0x0000FF00) >> 8,(cr & 0x00FF0000) >> 16);
            pictureBox_WatermarkTraspKey.BackColor = clr;
            if (this.waterselectcolor)
            {
                this.pictureBox_WatermarkTraspKeySelected.BackColor = clr;
                this.panello1.SetWaterTranspKey(clr);
            }
            waterselectcolor = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.panello1.SetThreadNum((int)this.numericUpDown_Thread.Value);
        }

        private void textBox_Rename_TextChanged(object sender, EventArgs e)
        {
            if (this.invalidfilename(textBox_Rename.Text))
            {
                lastok = this.textBox_Rename.Text;
                panello1.SetRenameStr(this.textBox_Rename.Text);
            }
            else
            {             
                textBox_Rename.Text = this.lastok;
            }
        }


        /// <summary>
        /// Check if the proposed name is valid for file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private bool invalidfilename(string filename)
        {
            if (filename.IndexOf("/") >= 0) return false;
            if (filename.IndexOf(@"\") >= 0) return false;
            if (filename.IndexOf("?") >= 0) return false;
            if (filename.IndexOf("*") >= 0) return false;
            if (filename.IndexOf(".") >= 0) return false;
            if (filename.IndexOf(">") >= 0) return false;
            if (filename.IndexOf("<") >= 0) return false;
            if (filename.IndexOf("|") >= 0) return false;
            if (filename.IndexOf("\"") >= 0) return false;
            if (filename.IndexOf(":") >= 0) return false;
            return true;
        }

        private void checkBox_Rename_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Rename.Enabled = checkBox_Rename.Checked;
            panello1.SetRename(checkBox_Rename.Checked);
        }

        private void checkBox_Extension_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_Extension.Enabled = checkBox_Extension.Checked;
            panello1.SetConversion(checkBox_Extension.Checked);
        }

        private void comboBox_Extension_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conv = "jpg";
            if (comboBox_Extension.SelectedIndex == 0) conv = "jpg";
            if (comboBox_Extension.SelectedIndex == 1) conv = "bmp";
            if (comboBox_Extension.SelectedIndex == 2) conv = "gif";
            if (comboBox_Extension.SelectedIndex == 3) conv = "tiff";
            if (comboBox_Extension.SelectedIndex == 4) conv = "exif";
            if (comboBox_Extension.SelectedIndex == 5) conv = "png";
            if (comboBox_Extension.SelectedIndex == 6) conv = "wmf";
            if (comboBox_Extension.SelectedIndex == 7) conv = "ico";
            panello1.SetConversionName(conv);
        }
    }
}
