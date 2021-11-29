using DND.Shared.Entities.Characters.Psychologies;

namespace DND.Shared.Entities.Characters
{
    public class Psychology
    {
        public Personality Personality { get; set; }
        public PsychValues Values { get; set; }
        public string Display {
            get
            {
                var output = "";
                output += "┌" + Strings.AddWhitespace("", Personality.Longest + 15, '─')        + "┬" +
                                Strings.AddWhitespace("", Values.Longest + 16, '─')        + "┐" + "\n" +
                          "│" + Strings.AddWhitespace(" Personality", Personality.Longest + 15) + "│" +
                                Strings.AddWhitespace(" Values", Values.Longest + 16)      + "│" + "\n" +
                          "├" + Strings.AddWhitespace("", Personality.Longest + 15, '─')        + "┼" +
                                Strings.AddWhitespace("", Values.Longest + 16, '─')        + "┤" + "\n";
                for (var i = 0; i < Personality.Attributes.Length; i++)
                {
                    var PItem = Personality.Attributes[i];

                    output += "│ " + Strings.AddWhitespace(PItem.Name, Personality.Longest) + "=> " + Strings.AddWhitespace(
                        Strings.NumToString(Strings.RoundNumber(PItem.Value)), 9) + " │ ";
                    if (i < Values.Values.Length)
                    {
                        var VItem = Values.Values[i];

                        output += Strings.AddWhitespace(VItem.Name, Values.Longest) + "=> " + Strings.AddWhitespace(
                            Strings.NumToString(Strings.RoundNumber(VItem.Value)), 9) + "  │";
                    }
                    else
                    {
                        output += Strings.AddWhitespace("", Values.Longest + 15) + "│";
                    }

                    output += "\n";
                }

                output += "└" + Strings.AddWhitespace("", Personality.Longest + 15, '─') + "┴" +
                                Strings.AddWhitespace("", Values.Longest + 16, '─') + "┘" + "\n";

                return output;
            }
        }
        public Psychology(double[][] mods)
        {
            Personality = new Personality();
            Values = new PsychValues();
            for (var i = 0; i < Values.Values.Length; i++)
            {
                Values.Values[i].Value += mods[0][i]/2d + mods[1][i] + mods[2][i] + mods[3][i];
            }
        }
    }
}
