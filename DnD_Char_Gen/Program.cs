using System;
using System.Collections.Generic;
using DND;
using DND.Character;
using DND.Character.Inventories;

namespace DnD_Char_Gen
{
    class Program
    {
        static bool debugMode = true;
        static void Main(string[] args)
        {
            
            Adder.ItemAdder("Rope", debugMode);


            Console.ReadLine();
        }
    }
}
