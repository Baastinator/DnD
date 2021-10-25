using System;
using DND;

namespace DnD_Char_Gen
{
    class Program
    {
        static void Main(string[] args)
        {
            Statblock stats = new Statblock();
            stats = Statblock.makeStats(Statblock.STATS_RANDOM);
            foreach (int stat in stats.IntArray)
            {
                Console.WriteLine(stat);
            }

            Console.ReadLine();
        }
    }
}
