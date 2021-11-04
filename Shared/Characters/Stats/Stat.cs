using System;

namespace DND.Characters.Stats
{
    public class Stat
    {
        static Random rng = new Random();
        public int Value { get; set; }
        public Stat(int value = 0)
        {
            Value = value;
        }
        public static Stat MakeStat()
        {
            int[] group4 = { rng.Next(1, 7), rng.Next(1, 7), rng.Next(1, 7), rng.Next(1, 7) };
            int min = Math.Min(Math.Min(group4[0], group4[1]), Math.Min(group4[2], group4[3]));
            int sum = group4[0] + group4[1] + group4[2] + group4[3] - min;
            Stat output = new Stat(sum);
            return output;
        }
    }
}
