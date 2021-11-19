using System;
using System.Collections.Generic;

namespace DND.Shared
{
    public class Randomiser
    {
        private static readonly Random rand = new Random();
        private static readonly Random rng = new Random();
        public List<int> WeightTable;
        public int TotalWeight { get { var sum = 0; foreach (var item in WeightTable) { sum += item; } return sum; } }
        public Randomiser(List<int> weightTable)
        {
            WeightTable = weightTable;
        }
        public Randomiser(IEnumerable<int> weightTable)
        {
            WeightTable = new List<int>();
            foreach (var t in weightTable)
            {
                WeightTable.Add(t);
            }
        }
        public int Roll()
        {
            var num = rng.Next(0, TotalWeight + 1);
            for (var i = 0; i < WeightTable.Count; i++)
            {
                if (num <= WeightTable[i])
                {
                    return i;
                }
                else
                {
                    num -= WeightTable[i];
                }
            }
            throw new Exception("Roll BAD");
        }

        public static double NormalDist(double mean = 0, double stdDev = 0.75)
        {
            var u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
            var u2 = 1.0 - rand.NextDouble();
            var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            return stdDev * randStdNormal; //random normal(mean,stdDev^2)
        }

    }
}
