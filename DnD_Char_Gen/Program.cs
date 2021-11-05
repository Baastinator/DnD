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
            character = new Character(true, 2);
            character.SetRace(4);
            character.MakeStats(new[] {5,5,5,5,5,5});
            Console.WriteLine(character.Race.Name);
            foreach (var i in character.Stats.IntArray)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
