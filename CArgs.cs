using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BatchImageConverter
{
    public class CArgs : EventArgs
    {
        private Returnvalues ret;

        public CArgs(Returnvalues ret)
        {
            this.ret = ret;
        }

        public Returnvalues Ret
        {
            get
            {
                return ret;
            }
        }
    }
}