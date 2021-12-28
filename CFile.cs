using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BatchImageConverter
{
    public class CFile
    {
        public Hashtable extension = new Hashtable();
        public CFile()
        {
            extension.Add("jpg", "jpg");
            extension.Add("jpeg", "jpg");
            extension.Add("gif", "gif");
            extension.Add("bmp", "bmp");
            extension.Add("ico", "ico");
            extension.Add("tif", "tif");
        }
    }
}
