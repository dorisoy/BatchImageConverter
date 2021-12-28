using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BatchImageConverter
{

    [DefaultPropertyAttribute("Name")]
    public class CPropImg : CPropFile
    {
       private const int orientation = 0x0112;

        private Size _size;
        private SizeF _resolution;



        [CategoryAttribute("Image properties"), DescriptionAttribute("Size") ,ReadOnly(true)]
        public Size Size
        {
            get
            {
                return _size;
            }

            set
            {
                _size = value;
            }
        }

        [CategoryAttribute("Image properties"), DescriptionAttribute("Resolution") ,ReadOnly(true)]
        public SizeF Resolution
        {
            get
            {
                return _resolution;
            }

            set
            {
                _resolution = value;
            }
        }

        public CPropImg()
        {

        }

        public void setfile(string filename, ref Bitmap bit)
        {
            if (File.Exists(filename))
            {
                FileInfo fi = new FileInfo(filename);
                Size = bit.Size;
                Resolution = new SizeF(bit.HorizontalResolution, bit.VerticalResolution);
                //getpropitem(ref bit);  // not well implemented, don't use
                base.setfile(filename);
            }
        }

        private void getpropitem(ref Bitmap bit)
        {
            try
            {

                // Get the PropertyItems property from image.
                PropertyItem[] propItems = bit.PropertyItems;

                int count = 0;
                foreach (PropertyItem propItem in propItems)
                {
                    String strId = propItem.Id.ToString("x");
                    String strItem = propItem.Type.ToString("x");
                    String strLen = propItem.Len.ToString("x");
                    byte[] val = propItem.Value;
                    
                    String valS = ASCIIEncoding.ASCII.GetString(val);

                    MessageBox.Show(strId+ " "+valS);
                    count += 1;
                }
            }
            catch (Exception)
            {

            }

        }
    }
}