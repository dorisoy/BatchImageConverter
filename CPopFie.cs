using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;

namespace BatchImageConverter
{

    [DefaultPropertyAttribute("Name")]
    public class CPropFile:CProp
    {
        private string _name;



        [CategoryAttribute("File information"), DescriptionAttribute("FileName"), ReadOnly(true)]
        public string  Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

      
        public CPropFile()
        {
            
        }

        public override void setfile(string filename)
        {
            if (File.Exists(filename))
            {
                FileInfo fi = new FileInfo(filename);
                Name = fi.Name;
                base.setfile(filename);
            }
        }
    }
}
