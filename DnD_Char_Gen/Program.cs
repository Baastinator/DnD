using System;
using DND.Shared.Entities;

namespace DnD.Char_Gen
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
            character.GenAppearance();
            character.GenProfession();
            character.GenBackground();
            character.GenClass();
            character.MakeSavingThrows();
            character.MakeSkills();
            character.GenPsychology();
            //Console.WriteLine(character.CPsychology.Display);
            Console.WriteLine("\n\n" + character.CSocialClass.Name + " - " + character.CProfession.Name +
                              "\nValue:  full = original + SoCl mod + Pro mod\n");
            for (int i = 0; i < character.CPsychology.Values.Values.Length; i++)
            {
                Console.WriteLine(
                    character.CPsychology.Values.Values[i].Name + ":  " + 
                    character.CPsychology.Values.Values[i].Value + " = " + 
                    character.CPsychology.oValues.Values[i].Value + " + " + 
                   (character.CSocialClass.PsychMod[i] / 2) + " + " + 
                    character.CProfession.PsychMod[i]);
            }
            Console.ReadLine();
        }
    }
}
