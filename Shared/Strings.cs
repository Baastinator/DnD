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

        public static string DisplayPsychology(Psychology input)
        {
            var longestV = 0;
            var longestP = 0;
            foreach (var attribute in input.Personality.Attributes)
            {
                if (longestP < attribute.Name.Length) longestP = attribute.Name.Length;
            }

            foreach (var value in input.Values.Values)
            {
                if (longestV < value.Name.Length) longestV = value.Name.Length;
            }

            var output = "";
            output += "┌" + AddWhitespace("", longestP + 15, '-') + "┬" +
                        AddWhitespace("", longestV + 16, '-') + "┐" + "\n" + 
                        "| " + AddWhitespace("Personality   ", longestP + 14) + "| " + 
                        AddWhitespace("Values",longestV+14) + " |" + "\n" +
                        "├" + AddWhitespace("", longestP + 15, '-')  + "┼" + 
                        AddWhitespace("",longestV+16,'-') + "┤" + "\n";
            for (var i = 0; i < input.Personality.Attributes.Length; i++)
            {
                var PItem = input.Personality.Attributes[i];
                var pos = "";
                var antipos = " ";

                output += "| " + AddWhitespace(PItem.Name, longestP) + "=> " + pos + AddWhitespace(
                    NumToValue(RoundNumber(PItem.Value)), 9) + antipos + "| " ;
                if (i < input.Values.Values.Length)
                {
                    var VItem = input.Values.Values[i];

                    output += AddWhitespace(VItem.Name, longestV) + "=> " + pos + AddWhitespace(
                        NumToValue(RoundNumber(VItem.Value)), 9) + antipos + " |";
                }

                output += "\n";
            }

            return output;
        }
        public static string DisplayArrayBaastiType(PersAttrib[] input)
        {
            var longest = 0;
            foreach (var t in input)
            {
                if (t.Name.Length > longest) longest = t.Name.Length;
            }
            var output = "";
            foreach (var item in input)
            {
                var pos = "";
                if (item.Value >= 0) pos = " ";
                output += AddWhitespace(item.Name, longest) + "- " + pos + RoundNumber(item.Value) + "\n";
            }

            return output;
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
        public static string DisplayArrayBaastiType(PsychValue[] input)
        {
            var longest = 0;
            foreach (var t in input)
            {
                if (t.Name.Length > longest) longest = t.Name.Length;
            }
            var output = "";
            foreach (var item in input)
            {
                var pos = "";
                if (item.Value >= 0) pos = " ";
                output += AddWhitespace(item.Name, longest) + "- " + pos + RoundNumber(item.Value) + "\n";
            }

            return output;
        }
        public static string DisplayArrayBaastiType(Skill[] input)
        {
            var longest = 0;
            foreach (var t in input)
            {
                if (t.Name.Length > longest) longest = t.Name.Length;
            }
            var output = "";
            foreach (var item in input)
            {
                var pos = "";
                if (item.Value >= 0) pos = " ";
                output += AddWhitespace(item.Name, longest) + "- " + pos + RoundNumber(item.Value) + "\n";
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
