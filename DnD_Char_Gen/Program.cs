using System;
using System.Collections.Immutable;
using System.Globalization;
using DND;
using DND.Characters;
using DND.Characters.SocialClasses;

namespace DnD_Char_Gen
{
    public class Program
    {
        public static Character character;
        public static void Main(string[] args)
        {
            character = new Character(true, 2);
            character.GenRace();
            character.MakeStats();
            character.GenSocialClass(1);
            character.GenAppearance();
            character.GenProfession();
            Console.WriteLine(character.CRace.Name+"\n");
            foreach (var num in character.Stats.IntArray)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("\n"+character.CSocialClass.Name);
            Console.WriteLine(character.CAppearance.BodyType.Name);
            Console.WriteLine(character.CAppearance.ClothingType.Name);
            Console.WriteLine(character.CProfession.Name);
            Console.ReadLine();
        }
    }
}
