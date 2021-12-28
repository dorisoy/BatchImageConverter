using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace BatchImageConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            workfinishedall_delegate = new EventHandler(workfinishedall);
            ImageContainer.workfinishedall_delegate = workfinishedall_delegate;

        }
        public System.EventHandler workfinishedall_delegate;

        /// <summary>
        /// Invoked when the work is totally finished
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void workfinishedall(object sender, EventArgs e)
        {
            // Enable some menu voices
            this.doToolStripMenuItem.Enabled = true;
            suspendToolStripMenuItem.Enabled = false;
            resumeToolStripMenuItem.Enabled = false;
            abortToolStripMenuItem.Enabled = false;
            Go.Enabled = true;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Not implemented
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ImageContainer.ShowSettings();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ImageContainer.ShowWorkPanel();
        }

        /// <summary>
        /// Starts the elaboration thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doToolStripMenuItem_Click(object sender, EventArgs e)
        {
            go();
        }

        /// <summary>
        /// Starts the elaboration
        /// </summary>
        private void go()
        {
            if (this.ImageContainer.Go())
            {
                this.Cursor = Cursors.Arrow;
                this.doToolStripMenuItem.Enabled = false;
                suspendToolStripMenuItem.Enabled = true;
                abortToolStripMenuItem.Enabled = true;
                resumeToolStripMenuItem.Enabled = false;
                Go.Enabled = false;
                this.toolStripProgressBar1.Value = 0;
                this.toolStripStatusLabel2.Text = "Work started";
            }
        }

        /// <summary>
        /// Suspend the work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void suspendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            if (this.ImageContainer.Suspend())
            {
                resumeToolStripMenuItem.Enabled = true;
                abortToolStripMenuItem.Enabled = true;
                doToolStripMenuItem.Enabled = false;
                suspendToolStripMenuItem.Enabled = false;
                Go.Enabled = false;
                this.toolStripStatusLabel2.Text = "Work suspended. Click resume to continue";
                this.Refresh();
            }
        }

        /// <summary>
        /// Resume the suspended work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            if (this.ImageContainer.Resume())
            {
                suspendToolStripMenuItem.Enabled = true;
                resumeToolStripMenuItem.Enabled = false;
                abortToolStripMenuItem.Enabled = true;
                doToolStripMenuItem.Enabled = false;
                Go.Enabled = false;
                this.toolStripStatusLabel2.Text = "Work resumed. Processing...";
                this.Refresh();
            }
        }

        /// <summary>
        /// Abort the work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            if (this.ImageContainer.Abort())
            {
                suspendToolStripMenuItem.Enabled = false;
                resumeToolStripMenuItem.Enabled = false;
                abortToolStripMenuItem.Enabled = false;
                Go.Enabled = true;
                doToolStripMenuItem.Enabled = true;
                this.toolStripProgressBar1.Value = 0;
                this.toolStripStatusLabel2.Text = "用户中止了工作";
                this.Refresh();
            }
        }

        /// <summary>
        /// Adds multiple files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Addfiles();
        }

        /// <summary>
        /// Adds multiple pics
        /// </summary>
        private void Addfiles()
        {
            DialogResult result;
            result = this.openFileDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            this.ImageContainer.AddUimageItem(this.openFileDialog1.FileNames);
        }
        /// <summary>
        /// Adds directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDir();
        }

        /// <summary>
        /// Add a directory
        /// </summary>
        private void AddDir()
        {
            DialogResult result;
            result = this.folderBrowserDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            this.ImageContainer.AddUimageItem(folderBrowserDialog1.SelectedPath);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void Go_Click(object sender, EventArgs e)
        {
            go();
        }

        private void Adddir_Click(object sender, EventArgs e)
        {
            AddDir();
        }

        private void Addfile_Click(object sender, EventArgs e)
        {
            Addfiles();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            this.ImageContainer.ShowSettings();
        }

        private void WorkPanel_Click(object sender, EventArgs e)
        {
            this.ImageContainer.ShowWorkPanel();
        }

        private void authorSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("IExplore", "www.xamarin.top");
            }
            catch
            {
                MessageBox.Show("Visit: www.xamarin.top", "关于作者",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ImageContainer.RemoveAll();
        }

        private void rmoveProcessedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ImageContainer.RemoveProcessed();
        }

        private void saveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = "appsettings.ini";
            Stream myStream;
            try
            {
                if (File.Exists(filename)) File.Delete(filename);
                myStream = File.OpenWrite(filename);
                IFormatter formatter = new SoapFormatter();
                this.ImageContainer.SerializePanel(myStream, ref formatter);
                myStream.Close();
            }
            catch
            {
                MessageBox.Show("Error serializing", "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void loadSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = "appsettings.ini";
            if (File.Exists(filename))
            {
                try
                {
                    Stream myStream = File.OpenRead(filename);
                    IFormatter formatter = new SoapFormatter();
                    this.ImageContainer.DeSerializePanel(myStream, ref formatter);
                    myStream.Close();
                }
                catch
                {
                    MessageBox.Show("Error deserializing", "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else MessageBox.Show("File "+filename+" not exists", "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

    }
}