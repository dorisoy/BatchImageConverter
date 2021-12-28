using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BatchImageConverter
{
    public struct Returnvalues
    {
        public TreeNode Node;   // the node selected
        public bool add;    // reference to the contextmenu
        public bool preview;
    }
}