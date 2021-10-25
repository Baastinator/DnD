using System;
using System.Collections.Generic;
using System.Text;

namespace DND
{
    public class Stat
    {
        static Random rng = new Random();
        private int val;
        public int Value { get { return val; } set { val = value; } }
        public Stat(int value = 0)
        {
            val = value;
        }
        static public Stat MakeStat()
        {
            int[] group4 = { rng.Next(1, 7), rng.Next(1, 7), rng.Next(1, 7), rng.Next(1, 7) };
            int min = Math.Min(Math.Min(group4[0], group4[1]), Math.Min(group4[2], group4[3]));
            int sum = group4[0] + group4[1] + group4[2] + group4[3] - min;
            Stat output = new Stat(sum);
            return output;
        }
    }
}
