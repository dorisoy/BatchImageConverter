using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace BatchImageConverter
{
    public partial class ExpandedImage : UserControl
    {
        public ExpandedImage()
        {
            InitializeComponent();
        }

        public void setimage(Bitmap bit)
        {
            this.pictureBox1.Image = bit;
        }

        public void expand()
        {
            this.button_Return.Enabled = false;
            this.pictureBox1.BackColor = Color.Green;
            for (int dim = 10; dim < 2000; dim++)
            {
                if (this.Width < this.Parent.Width) this.Width+=5;
                if (this.Height < this.Parent.Height) this.Height+=5;
                if ((this.Width >= this.Parent.Width) && (this.Height >= this.Parent.Height)) break;
                Thread.Sleep(2);
                this.Refresh();
            }
            this.Height = Parent.Height;
            this.Width = Parent.Width;
            this.pictureBox1.BackColor = Color.Transparent;
            this.button_Return.Enabled = true;
        }

        public void impand()
        {
            this.button_Return.Enabled = false;
            this.pictureBox1.BackColor = Color.Green;
            for (int dim = 10; dim < 2000; dim++)
            {
                if (this.Width >= 5) this.Width -= 5;
                if (this.Height >= 5) this.Height -= 5;
                if ((this.Width <= 10) && (this.Height <= 10)) break;
                Thread.Sleep(2);
                this.Refresh();
            }
            this.pictureBox1.BackColor = Color.Transparent;
        }

        private void button_Return_Click(object sender, EventArgs e)
        {
            impand();
            Parent.SendToBack();
            this.Dispose();
        }
    }
}
