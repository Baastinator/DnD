using System;

namespace DND.Characters
{
    public static class Proficiencies
    {
        public static int[] AddTables(int[] s, int[] o)
        {
            if (s.Length == o.Length && s.Length == 18)
            {
                var output = new int[s.Length];
                for (var i = 0; i < s.Length; i++)
                {
                    output[i] = o[i] + s[i];
                }
                return output;
            }
            else throw new Exception("");
        }
    }
}
