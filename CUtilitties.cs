using System;
using System.Collections.Generic;
using System.Text;

namespace BatchImageConverter
{
    public class CUtilitties
    {
        public CUtilitties()
        {
        }

        public string getextension(string filename)
        {
            string extension = "";
            int lun = filename.Length;
            int poi = filename.LastIndexOf(".") + 1;
            extension = filename.Substring(poi, lun - poi).ToLower();
            return extension;
        }

        public string getfilename(string filename)
        {
            string name = "";
            int lun = filename.Length;
            int poi = filename.LastIndexOf("\\") + 1;
            name = filename.Substring(poi, lun - poi).ToLower();
            return name;
        }

        public string getfilenamenoext(string filename)
        {
            string name = "";
            int lun = filename.Length;
            int poi = filename.LastIndexOf("\\")+1;
            name = filename.Substring(poi, lun - poi- getextension(filename).Length-1).ToLower();
            return name;
        }
    }
}
