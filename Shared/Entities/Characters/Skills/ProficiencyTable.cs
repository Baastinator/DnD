using System;

namespace DND.Shared.Entities.Characters.Skills
{
    public static class ProficiencyTable
    {
        public static int[] AddTables(int[] t1, int[] t2)
        {
            if (t1.Length == t2.Length)
            {
                var t3 = new int[t1.Length];
                for (var i = 0; i < t1.Length; i++)
                {
                    t3[i] = t1[i] + t2[i];
                }
                return t3;
            }
            else throw new Exception("Proficiency Table Addtables: mismatched size");
        }
    }
}
