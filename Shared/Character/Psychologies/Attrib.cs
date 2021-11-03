using System;
using System.Collections.Generic;
using System.Text;

namespace DND.Character.Psychologies
{
    class Attrib
    {
        private byte _val;
        public int val
        {
            get { return _val; }
            set
            {
                if (value > 6)
                {
                    value = 6;
                } 
                else if (value < 0)
                {
                    value = 0;
                }
                val = (byte)value;
            }
        }
    }
}
