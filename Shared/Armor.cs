using System;
using System.Collections.Generic;
using System.Text;

namespace DND
{
    public class Armor
    {

        private uint _id;
        public int ID { get => (int)_id; }

        private int _ac;
        private string _name;
        public int AC { get { return _ac; } set { _ac = value; } }
        public string Name { get => _name; set { _name = value; } }
    }
}

