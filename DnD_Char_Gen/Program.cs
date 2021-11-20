using System;
using DND.Shared.Entities;

namespace DnD.Char_Gen_Test
{
    public class Program
    {
        public static Character character;
        public static void Main(string[] args)
        {
            /*var a1 = new List<double>();
            for (int i = 0; i < PsychValue.Values.Length; i++)
            {
                a1.Add(i/10d);
            }
            var a = new DoubleArray(a1.ToArray());
            var b = new PsychValues(a.Array,false);
            foreach (var d in b.Values)
            {
                Console.WriteLine(d.Value);
            }*/
            
            character = new Character(true, 2);
            character.GenRace();    
            character.MakeStats();
            character.GenSocialClass();
            character.GenAppearanceBodyAndClothes();
            character.GenProfession();
            character.GenBackground();
            character.GenClass();
            character.MakeSavingThrows();
            character.MakeSkills();
            character.GenPsychology();
            Console.WriteLine(character.CPsychology.Display);
            Console.WriteLine(character.PsychModString);
            Console.ReadLine();
        }
    }
}
