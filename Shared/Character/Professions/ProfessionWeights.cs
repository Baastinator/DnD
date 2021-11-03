using System;
using System.Collections.Generic;
using System.Text;

namespace DND.Character.Professions
{
    public static class ProfessionWeights
    {
        static int[] template = new int[]
        {
              0,  0,  0,  0,  0,    0,  0,  0,  0,  0,    0,  0,  0,  0,  0,     0,  0,  0,  0,  0,
              0,  0,  0,  0,  0,    0,  0,  0,  0,  0,    0,  0,  0,  0,  0,     0,  0,  0,  0,  0,
              0,  0,  0,  0,  0,    0,  0,  0,  0,  0,
        };

        public static int[] RuralPeasant = new int[]
        {
             80,  0,  0,  0,  0,    0,  0,  0, 10,  0,    0,  0,  0,  0,  0,     0,  0,  0,  0,  0,
              0,  0,  0,  0, 20,    0,  0,  0,  0,  0,    0, 15,  0,  0,  0,     0,  20,  0,  0,  0,
              0, 80,100,  0,  0,    0,  0, 50,  0, 30,
        };
    }
}
