using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;

namespace BatchImageConverter
{

    [DefaultPropertyAttribute("Name")]
    public class CProp
    {
        //private string _name;
        //private int _age;
        //private DateTime _dateOfBirth;
        //private string _SSN;
        //private string _address;
        //private string _email;
        //private bool _frequentBuyer;
        private long _lenght;
        private bool _attrhidden;
        private bool _attrcompressed;
        private bool _attrarchive;
        private bool _encrypted;
        private bool _normal;
        private bool _offline;
        private bool _readonly;
        private bool _system;
        private bool _temporary;
        private string _extension;
        private DateTime _creation;
        private DateTime _lastaccess;
        private DateTime _lastwrite;
        private FileInfo fi;

        [CategoryAttribute("File information"), DescriptionAttribute("Size in bytes"), ReadOnly(true)]
        public long Lenght
        {
            get
            {
                return _lenght;
            }

            set
            {
                _lenght = value;
            }
        }

        [CategoryAttribute("File attributes"), DescriptionAttribute("Hidden"), ReadOnly(true)]
        public bool Hidden
        {
            get
            {
                return _attrhidden;
            }

            set
            {
                _attrhidden = value;
            }
        }

        [CategoryAttribute("File attributes"), DescriptionAttribute("Archive"), ReadOnly(true)]
        public bool Archive
        {
            get
            {
                return _attrarchive;
            }

            set
            {
                _attrarchive = value;
            }
        }

        [CategoryAttribute("File attributes"), DescriptionAttribute("Compressed"), ReadOnly(true)]
        public bool Compressed
        {
            get
            {
                return _attrcompressed;
            }

            set
            {
                _attrcompressed = value;
            }
        }

        [CategoryAttribute("File attributes"), DescriptionAttribute("Encrypted"), ReadOnly(true)]
        public bool Encrypted
        {
            get
            {
                return _encrypted;
            }

            set
            {
                _encrypted = value;
            }
        }

        [CategoryAttribute("File attributes"), DescriptionAttribute("Normal"), ReadOnly(true)]
        public bool Normal
        {
            get
            {
                return _normal;
            }

            set
            {
                _normal = value;
            }
        }

        [CategoryAttribute("File attributes"), DescriptionAttribute("Offline"), ReadOnly(true)]
        public bool Offline
        {
            get
            {
                return _offline;
            }

            set
            {
                _offline = value;
            }
        }

        [CategoryAttribute("File attributes"), DescriptionAttribute("Readonly"), ReadOnly(true)]
        public bool Readonly
        {
            get
            {
                return _readonly;
            }

            set
            {
                _readonly = value;
            }
        }

        [CategoryAttribute("File attributes"), DescriptionAttribute("System"), ReadOnly(true)]
        public bool System
        {
            get
            {
                return _system;
            }

            set
            {
                _system = value;
            }
        }

        [CategoryAttribute("File attributes"), DescriptionAttribute("Temporary"), ReadOnly(true)]
        public bool Temporary
        {
            get
            {
                return _temporary;
            }

            set
            {
                _temporary = value;
            }
        }

        [CategoryAttribute("File information"), DescriptionAttribute("Temporary"), ReadOnly(true)]
        public string Extension
        {
            get
            {
                return _extension;
            }

            set
            {
                _extension = value;
            }
        }

        [CategoryAttribute("File information"), DescriptionAttribute("Creation time"), ReadOnly(true)]
        public DateTime Creation
        {
            get
            {
                return _creation;
            }

            set
            {
                _creation = value;
            }
        }

        [CategoryAttribute("File information"), DescriptionAttribute("Last Access time"), ReadOnly(true)]
        public DateTime LastAccess
        {
            get
            {
                return _lastaccess;
            }

            set
            {
                _lastaccess = value;
            }
        }

        [CategoryAttribute("File information"), DescriptionAttribute("Last Write time"), ReadOnly(true)]
        public DateTime LastWrite
        {
            get
            {
                return _lastwrite;
            }

            set
            {
                _lastwrite = value;
            }
        }
        public CProp()
        {
            
        }

        virtual public void setfile(string filename)
        {
            if (File.Exists(filename))
            {
                fi = new  FileInfo(filename);
                FileAttributes attr = fi.Attributes;
                Lenght = fi.Length;
                if (attr == FileAttributes.Hidden) Hidden = true; else Hidden = false;
                if (attr == FileAttributes.Archive) Archive = true; else Archive = false;
                if (attr == FileAttributes.Compressed) Compressed = true; else Compressed = false;
                if (attr == FileAttributes.Encrypted) Encrypted = true; else Encrypted = false;
                if (attr == FileAttributes.Normal) Normal = true; else Normal = false;
                if (attr == FileAttributes.Offline) Offline = true; else Offline = false;
                if (attr == FileAttributes.ReadOnly) Readonly = true; else Readonly = false;
                if (attr == FileAttributes.System) System = true; else System = false;
                if (attr == FileAttributes.Temporary) Temporary = true; else Temporary = false;
                Extension = fi.Extension;
                Creation = fi.CreationTime;
                LastAccess = fi.LastAccessTime;
                LastWrite = fi.LastWriteTime;
            }
        }
    }
}

