using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace BatchImageConverter
{
    
    public partial class UDirTree : UserControl
    {
        private TreeNode Root = new TreeNode("C:");
        public delegate void ReturnHandler(object myObject, CArgs myArgs);
        public event ReturnHandler OnReturn;
        private TreeNode SelectedNode = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public UDirTree()
        {
            InitializeComponent();
            InitializeTree();
            Root.Name = "C:\\";
            Root.Text = "C:";
            Root.ImageIndex = 0;
            // Add the event for click on the treeview
            this.treeView1.Click += new EventHandler(treeView1_Click);
            // Add the event for double click on the treeview
            this.treeView1.DoubleClick += new EventHandler(treeView1_DoubleClick);        
            this.treeView1.KeyUp+= new KeyEventHandler(treeView1_KeyDown);
            this.progressBar1.Visible = false;
        }

        /// <summary>
        /// Handle the invocation method (event)
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="addremove"></param>
        /// <param name="preview"></param>
        private void invokeevent(TreeNode Node, bool addremove, bool preview)
        {
            Returnvalues ret = new Returnvalues();
            ret.Node = Node;
            ret.add = addremove;
            ret.preview = preview;
            CArgs myArgs = new CArgs(ret);
            OnReturn(this, myArgs);
        }

        /// <summary>
        /// Handles the keydown on the treeview (arrow navigation)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_KeyDown(object sender, EventArgs e)
        {
            this.progressBar1.Visible = false;
            KeyEventArgs et = (KeyEventArgs)e;
            TreeNode node = treeView1.SelectedNode;
            if (et.KeyCode == Keys.Down || et.KeyCode == Keys.Up)
            {
                invokeevent(node, true, true);
            }
            if (et.KeyCode == Keys.Return || et.KeyCode == Keys.Enter)
            {
                invokeevent(node, true, false);
            }
            if (et.KeyCode == Keys.Delete || et.KeyCode == Keys.Cancel)
            {
                invokeevent(node, false, false);
            }
        }

        /// <summary>
        /// Handles the click on the treeview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_Click(object sender, EventArgs e)
        {
            this.progressBar1.Visible = false;
            MouseEventArgs et = (MouseEventArgs)e;
            Point poi = new Point(et.X,et.Y);
            TreeNode node = treeView1.GetNodeAt(poi);
            if (et.Button == MouseButtons.Right)
            {
                SelectedNode = node;
                // ACTIVATE THIS IF YOU WANT SKIP THE CONTEXTMENU
                //invokeevent(node,true,false);
            }
            // INSERT HERE CODE FOR PREVIEW
            if (et.Button == MouseButtons.Left || et.Button == MouseButtons.Right)
            {
                invokeevent(node, true, true);
            }         
            //invokeevent(node, true, false,true);
        }

        /// <summary>
        /// Handles the doubleclick on the treeview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            this.progressBar1.Visible = false;
            MouseEventArgs et = (MouseEventArgs)e;
            Point poi = new Point(et.X, et.Y);
            TreeNode node = treeView1.GetNodeAt(poi);
            if (et.Button == MouseButtons.Left)
            {
                // Check if the double click is on a directory or a file
                // Rule: double click on a file causes it's insertion
                if (File.Exists(node.Name))
                {
                    // ACTIVATE THIS IF YOU WANT DEACTIVATE DOUBLECLICK
                    invokeevent(node, true,false);
                }
            }
        }

        /// <summary>
        /// Handles the click on the treeview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PopulateNode(e.Node);
            this.progressBar1.Visible = false;
            //invokeevent(e.Node);
        }

        /// <summary>
        /// Initializes the tree
        /// </summary>
        private void InitializeTree()
        {
            treeView1.Nodes.Add(Root);
            Enumdrives();
            SpecialFolders();
        }

        /// <summary>
        /// Get drive letters
        /// </summary>
        private void Enumdrives()
        {
            //string[] drives = Directory.GetLogicalDrives();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo driveinfo in drives)
            {
                if (driveinfo.Name.ToString().ToUpper() != "C:\\")
                {
                    TreeNode drivenode = new TreeNode();
                    drivenode.Name = driveinfo.Name.ToString().ToUpper();
                    drivenode.Text = driveinfo.Name.ToString().Substring(0, driveinfo.Name.ToString().Length - 1).ToUpper();
                    if (driveinfo.DriveType == DriveType.Fixed) drivenode.ImageIndex = 0;
                    if (drivenode.Name == "A:\\" || drivenode.Name == "B:\\") drivenode.ImageIndex = 1;
                    if (driveinfo.DriveType == DriveType.CDRom) drivenode.ImageIndex = 37;
                    if (driveinfo.DriveType == DriveType.Removable) drivenode.ImageIndex = 38;
                    treeView1.Nodes.Add(drivenode);
                }
            }
        }

        /// <summary>
        /// Retrieves special folders
        /// </summary>
        private void SpecialFolders()
        {
            // GET desktop dir
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            TreeNode desktopnode = new TreeNode();
            desktopnode.Name = desktop;
            desktopnode.Text = "Desktop";
            desktopnode.ImageIndex = 39;
            treeView1.Nodes.Add(desktopnode);

            // Get Document
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            TreeNode document = new TreeNode();
            document.Name = documents;
            document.Text = "Documenti";
            document.ImageIndex = 40;
            treeView1.Nodes.Add(document);

            // Get My Pictures
            string mypic = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            TreeNode mypicnode = new TreeNode();
            mypicnode.Name = mypic;
            mypicnode.Text = "My Pictures";
            mypicnode.ImageIndex = 41;
            treeView1.Nodes.Add(mypicnode);

            // Get Recents
            string recent = Environment.GetFolderPath(Environment.SpecialFolder.Recent);
            TreeNode recentnode = new TreeNode();
            recentnode.Name = recent;
            recentnode.Text = "Recents";
            recentnode.ImageIndex = 42;
            treeView1.Nodes.Add(recentnode);

            // Get Program
            string prgfiles = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles);
            TreeNode prgfilesnode = new TreeNode();
            prgfilesnode.Name = prgfiles;
            prgfilesnode.Text = "Program Files";
            prgfilesnode.ImageIndex = 43;
            treeView1.Nodes.Add(prgfilesnode);
        }

        #region Imagelist handler

        /// <summary>
        /// Get index of imagelist by extension for show the right image on tree
        /// </summary>
        /// <param name="validate"></param>
        /// <returns></returns>
        public int getindexbyextension(string validate)
        {
            if (Directory.Exists(validate)) return 2;
            string extension = "und";
            int lun = validate.Length;
            int poi = validate.LastIndexOf(".")+1;
            if (File.Exists(validate)) extension = validate.Substring(poi, lun-poi).ToLower();
            switch (extension)
            {
                case "log":
                    return 4; 
                case "xml":
                    return 5;
                case "zip":
                    return 6;
                case "wav":
                    return 7;
                case "avi":
                    return 8;
                case "mov":
                    return 8;
                case "wmv":
                    return 8;
                case "bmp":
                    return 9;
                case "ico":
                    return 9;
                case "doc":
                    return 10;
                case "rtf":
                    return 10;
                case "exe":
                    return 11;
                case "gif":
                    return 12;
                case "jpg":
                    return 13;
                case "tif":
                    return 13;
                case "mid":
                    return 14;
                case "mp3":
                    return 15;
                case "txt":
                    return 16;
                case "dll":
                    return 18;
                case "ttf":
                    return 19;
                case "fon":
                    return 19;
                case "pdf":
                    return 25;
                case "rar":
                    return 26;
                case "htm":
                    return 27;
                case "chm":
                    return 28;
                case "bin":
                    return 29;
                case "ppt":
                    return 30;
                case "cs":
                    return 31;
                case "vb":
                    return 31;
                case "sln":
                    return 31;
                case "dsp":
                    return 31;
                case "dsw":
                    return 31;
                case "cpp":
                    return 31;
                case "h":
                    return 31;
                case "mdb":
                    return 33;
                case "xls":
                    return 34;
                case "bat":
                    return 35;
                default:
                    return 17;

            }
        }
        #endregion

        /// <summary>
        /// Populate tree
        /// </summary>
        /// <param name="Node"></param>
        protected void PopulateNode(TreeNode Node)
        {
            this.Cursor = Cursors.WaitCursor;
            if (Node.IsExpanded == false && Node.Nodes.Count == 0)  // Prevent double insertion
            {
                string Dir = Node.Name;
                this.progressBar1.Visible = true;
                this.progressBar1.Value = 0;
                // Calculate the present items on the new node and set the maximunm of the progressbar
                int count = 0;
                if (Directory.Exists(Dir))
                {
                    count += Directory.GetDirectories(Dir).Length;
                    count += Directory.GetFiles(Dir).Length;
                }
                this.progressBar1.Maximum = count;
                count = 0;

                if (Directory.Exists(Dir))
                {
                    try
                    {
                        for (int i = 0; i < Directory.GetDirectories(Dir).Length; i++)
                        {
                            String name = Directory.GetDirectories(Dir)[i];
                            TreeNode Child = new TreeNode(name.Remove(0, Dir.Length));
                            if (Child.Text.StartsWith("\\")) Child.Text = Child.Text.Remove(0, 1);
                            if (Child.Text != "System Volume Information")
                            {
                                Child.Name = name;
                                Child.ImageIndex = 2;
                                // Add the context menu on item if it does'nt has
                                Child.ContextMenuStrip = this.contextMenuStrip1;
                                Node.Nodes.Add(Child);
                                count++;
                                this.progressBar1.Visible = true;
                                this.progressBar1.Value = count;
                                Thread.Sleep(2);
                            }
                        }
                    }
                    catch
                    { 
                    }
                    try
                    {
                        for (int i = 0; i < Directory.GetFiles(Dir).Length; i++)
                        {
                            String name = Directory.GetFiles(Dir)[i];
                            TreeNode Child = new TreeNode(name.Remove(0, Dir.Length));
                            if (Child.Text.StartsWith("\\")) Child.Text = Child.Text.Remove(0, 1);
                            Child.Name = name;
                            // Get the image based on the file extension
                            Child.ImageIndex = getindexbyextension(Child.Name);
                            // Add the context menu on item if it does'nt has
                            Child.ContextMenuStrip = this.contextMenuStrip1;
                            Node.Nodes.Add(Child);
                            count++;
                            this.progressBar1.Visible = true;
                            this.progressBar1.Value = count;
                            Thread.Sleep(1);
                        }
                    }
                    catch
                    {
                    }
                this.progressBar1.Visible = false;
                this.progressBar1.Value = 0;
                if (Node.Level > 0 ) Node.ImageIndex = 3;  
                }
            }
            
            Node.Expand();        
            //Node.Checked = true;
            treeView1.SelectedNode = Node;
            //treeView1.SelectedNode
            this.Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Context menu : add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            invokeevent(SelectedNode,true,false);
        }

        /// <summary>
        /// Context menu : remove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            invokeevent(SelectedNode, false,false);
        }

    }
}
