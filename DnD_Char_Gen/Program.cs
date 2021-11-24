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

            character = new Character();
            character.SetName("Cringelord69");
            character.GenGender();
            character.SetLevel(3);
            character.GenRace();    
            character.GenStats();
            character.GenSocialClass();
            character.GenBodyClothes();
            character.GenAppearance();
            character.GenProfession();
            character.GenBackground();
            character.GenClass();
            character.GenSavingThrows();
            character.GenSkills();
            character.GenPsychology();
        }
    }
}
