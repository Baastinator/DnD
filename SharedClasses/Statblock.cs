using System;
using System.Collections.Generic;
using System.Text;

namespace DND
{
    class Statblock
    {
        private Stat Str, Dex, Con, Int, Wis, Cha;
        public int STR
        {
            get
            {
                return Str.Value;
            }
            set
            {
                Str.Value = value;
            }
        }
        public int DEX
        {
            get
            {
                return Dex.Value;
            }
            set
            {
                Dex.Value = value;
            }
        }
        public int CON
        {
            get
            {
                return Con.Value;
            }
            set
            {
                Con.Value = value;
            }
        }
        public int INT
        {
            get
            {
                return Int.Value;
            }
            set
            {
                Int.Value = value;
            }
        }
        public int WIS
        {
            get
            {
                return Wis.Value;
            }
            set
            {
                Wis.Value = value;
            }
        }
        public int CHA
        {
            get
            {
                return Cha.Value;
            }
            set
            {
                Cha.Value = value;
            }
        }
    }
}
