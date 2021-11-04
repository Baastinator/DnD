using System;
using System.Collections.Generic;

namespace DND
{
    public class Randomiser
    {
        static Random rng = new Random();
        public List<int> WeightTable;
        public int TotalWeight { get { int sum = 0; foreach (int item in WeightTable) { sum += item; } return sum; } }
        public Randomiser(List<int> weightTable)
        {
            WeightTable = weightTable;
        }
        public Randomiser(int[] weightTable)
        {
            WeightTable = new List<int>();
            for (int i = 0; i < weightTable.Length; i++)
            {
                WeightTable.Add(weightTable[i]);
            }
        }
        public int Roll()
        {
            int num = rng.Next(0, TotalWeight + 1);
            for (int i = 0; i < WeightTable.Count; i++)
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
