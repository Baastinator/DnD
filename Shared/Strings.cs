using System;
using DND.Shared.Entities.Characters;
using DND.Shared.Entities.Characters.Psychologies;
using DND.Shared.Entities.Characters.Skills;

namespace DND.Shared
{
    public static class Strings
    {
        public static string AddWhitespace(string input, int totalSize, char Filler = ' ')
        {
            //if (input.Length > totalSize) throw new Exception("add whitespace: yo wtf you tryna do");
            var WS = "";
            var delta = totalSize - input.Length;
            for (var i = 0; i <= delta; i++)
            {
                WS += Filler;
            }

            return input + WS;
        }
        public static string NumToValue(double input)
        {
            var output = "";
            int val = (int) Math.Floor(Math.Abs(input));
            if (input < 0) val *= -1;
            if (val == 0)
            {
                return "";
            } 
            if (val > 0)
            {
                for (int i = 0; i < val; i++)
                {
                    output += "+";
                }

                return output;
            }

            for (int i = 0; i < (int)Math.Abs(val); i++)
            {
                output += "-";
            }

            return output;
        }
        
        public static double RoundNumber(double input)
        {
            double round(double x, int digits)
            {
                x *= Math.Pow(10, digits);
                x += 0.5;
                x = Math.Floor(x);
                x /= Math.Pow(10, digits);
                return x;
            }

            return round(input, 3);
        }
    }
}
