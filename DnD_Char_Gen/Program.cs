using DND;
using System;

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
            character.GenBackground();
            character.GenClass();
            character.MakeSavingThrows();
            character.MakeSkills();
            character.GenPsychology();
            Console.WriteLine(Strings.DisplayPsychology(character.CPsychology));
            Console.ReadLine();
        }
    }
}
