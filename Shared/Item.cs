using System;
using System.Collections.Generic;
using System.Text;

namespace DND
{
    public class Item
    {
        private uint _id;
        public int ID { get => (int)_id; }

        private uint _num;
        private string _name;
        public int Amount { get => (int)_num; set { _num = (uint)value; if (_num > 999) { _num = 999; } } }
        public string Name { get => _name; set { _name = value; } }

    }
}
