using System;
using System.Collections.Generic;

namespace DND
{
    public class Randomiser
    {
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
    }
}
