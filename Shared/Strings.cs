﻿using System;

namespace DND.Shared
{
    public static class Strings
    {

        public static string RemoveWhitespace(string input)
        {
            for (var i = 0; i <= input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    break;
                }

                if (i == input.Length)
                {
                    return "";
                }
            }
            while (true)
            {
                if (input.StartsWith(' '))
                {
                    input = input[1..];
                }
                else break;
            }

            while (true)
            {
                if (input.EndsWith(' '))
                {
                    input = input[..^1];
                }
                else break;
            }

            return input;
        }
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
        public static string NumToString(double input)
        {
            var output = "";
            var val = (int) Math.Floor(Math.Abs(input));
            if (input < 0) val *= -1;
            if (val == 0)
            {
                return "";
            } 
            if (val > 0)
            {
                for (var i = 0; i < val; i++)
                {
                    output += "+";
                }

                return output;
            }

            for (var i = 0; i < (int)Math.Abs(val); i++)
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
