using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;

namespace BatchImageConverter
{

    [DefaultPropertyAttribute("Name")]
    public class CPropDir : CProp
    {
        private string _dir;



        [CategoryAttribute("File Information"), DescriptionAttribute("DirName"), ReadOnly(true)]
        public string DirName
        {
            get
            {
                return _dir;
            }

            set
            {
                _dir = value;
            }
        }


        public CPropDir()
        {

        }

        public override void setfile(string filename)
        {
            if (Directory.Exists(filename))
            {
                FileInfo fi = new FileInfo(filename);
                DirName = filename;//fi.Name;
                base.setfile(filename);
            }
        }
    }
}