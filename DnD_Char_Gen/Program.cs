using System;
using System.Collections.Generic;
using DND;
using DND.Character;
using DND.Character.Professions;

namespace DnD_Char_Gen
{
    class Program
    {
        static bool debugMode = true;
        static void Main(string[] args)
        {
            Randomiser ruralpeasant = new Randomiser(ProfessionWeights.RuralPeasant);
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(Profession.Professions[ruralpeasant.Roll()].Name);
            }
            Console.ReadLine();
        }
    }
}
