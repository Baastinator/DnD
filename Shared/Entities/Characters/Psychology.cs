using System;
using DND.Shared.Entities.Characters.Psychologies;
using static DND.Shared.Entities.Characters.Psychologies.PsychValues;

namespace DND.Shared.Entities.Characters
{
    public class Psychology
    {
        public Personality Personality { get; set; }
        public PsychValues oValues { get; set; }
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
                output += "┌" + Strings.AddWhitespace("", longestP + 15, '─')        + "┬" +
                                Strings.AddWhitespace("", longestV + 16, '─')        + "┐" + "\n" +
                          "│" + Strings.AddWhitespace(" Personality", longestP + 15) + "│" +
                                Strings.AddWhitespace(" Values", longestV + 16)      + "│" + "\n" +
                          "├" + Strings.AddWhitespace("", longestP + 15, '─')        + "┼" +
                                Strings.AddWhitespace("", longestV + 16, '─')        + "┤" + "\n";
                for (var i = 0; i < Personality.Attributes.Length; i++)
                {
                    var PItem = Personality.Attributes[i];

                    output += "│ " + Strings.AddWhitespace(PItem.Name, longestP) + "=> " + Strings.AddWhitespace(
                        Strings.NumToString(Strings.RoundNumber(PItem.Value)), 9) + " │ ";
                    if (i < Values.Values.Length)
                    {
                        var VItem = Values.Values[i];

                        output += Strings.AddWhitespace(VItem.Name, longestV) + "=> " + Strings.AddWhitespace(
                            Strings.NumToString(Strings.RoundNumber(VItem.Value)), 9) + "  │";
                    }
                    else
                    {
                        output += Strings.AddWhitespace("", longestV + 15) + "│";
                    }

                    output += "\n";
                }

                output += "└" + Strings.AddWhitespace("", longestP + 15, '─') + "┴" +
                                Strings.AddWhitespace("", longestV + 16, '─') + "┘" + "\n";

                return output;
            }
        }
        public Psychology(double[] socMod, double[] proMod)
        {
            Personality = new Personality();
            oValues = new PsychValues();
            Values = new PsychValues(false);
            for (var i = 0; i < Values.Values.Length; i++)
            {
                Console.WriteLine(oValues.Values[i].Value);
                Values.Values[i].Value = oValues.Values[i].Value + socMod[i] + proMod[i];
            }
        }
    }
}
