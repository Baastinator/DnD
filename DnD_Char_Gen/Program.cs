using System;
using DND;
using DND.Characters;

namespace DnD_Char_Gen
{
    public class Program
    {
        public static Character character;
        public static void Main(string[] args)
        {
            Statblock stats = Statblock.MakeStats(Statblock.STATS_RANDOM, null!);
            Skillblock skills = new Skillblock(10,stats);
            skills.ApplyProficiencies(new int[] {0,0,0, 0,0,0, 0,0,50, 0,0,0, 0,0,0, 0,0,0});
            foreach (var stat in stats.StatArray)
            {
                Console.WriteLine(stat.Value);
            }
            Console.WriteLine();
            foreach (var skill in skills.skills) 
            {
                Console.WriteLine(skill.Value);
            }
            Console.ReadLine();
        }
    }
}
