using System;
using DND.Shared.Entities.Cities;
using static DND.Shared.Strings;

namespace DnD.City_Gen_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var river in River.Rivers)
            {
                Console.WriteLine(river.Name);
            }
            Console.ReadLine();
        }
    }
}
