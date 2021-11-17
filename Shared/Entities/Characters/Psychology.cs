using DND.Shared.Entities.Characters.Psychologies;
using Microsoft.VisualBasic;

namespace DND.Shared.Entities.Characters
{
    public class Psychology
    {
        public Personality Personality { get; set; }
        public PsychValues Values { get; set; }
        public string Display {
            get
            {
                var longestV = 0;
                var longestP = 0;
                foreach (var attribute in Personality.Attributes)
                {
                    if (longestP < attribute.Name.Length) longestP = attribute.Name.Length;
                }

                foreach (var value in Values.Values)
                {
                    if (longestV < value.Name.Length) longestV = value.Name.Length;
                }

                var output = "";
                output += "┌" + Strings.AddWhitespace("", longestP + 15, '-') + "┬" +
                          Strings.AddWhitespace("", longestV + 16, '-') + "┐" + "\n" +
                          "| " + Strings.AddWhitespace("Personality   ", longestP + 14) + "| " +
                          Strings.AddWhitespace("Values", longestV + 14) + " |" + "\n" +
                          "├" + Strings.AddWhitespace("", longestP + 15, '-') + "┼" +
                          Strings.AddWhitespace("", longestV + 16, '-') + "┤" + "\n";
                for (var i = 0; i < Personality.Attributes.Length; i++)
                {
                    var PItem = Personality.Attributes[i];

                    output += "| " + Strings.AddWhitespace(PItem.Name, longestP) + "=> " + Strings.AddWhitespace(
                        Strings.NumToString(Strings.RoundNumber(PItem.Value)), 9) + " | ";
                    if (i < Values.Values.Length)
                    {
                        var VItem = Values.Values[i];

                        output += Strings.AddWhitespace(VItem.Name, longestV) + "=> " + Strings.AddWhitespace(
                            Strings.NumToString(Strings.RoundNumber(VItem.Value)), 9) + "  |";
                    }
                    else
                    {
                        output += Strings.AddWhitespace("", longestV + 3);
                    }

                    output += "\n";
                }

                return output;
            }
        }
        public Psychology(double[] socMod)
        {
            Personality = new Personality();
            double[] mod = PsychValues.AddValueModifiers(socMod, socMod);
            Values = new PsychValues(mod);
        }
    }
}
