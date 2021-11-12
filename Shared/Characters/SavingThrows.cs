namespace DND.Characters
{
    public class SavingThrows
    {
        public Statblock Stats { get; set; }
        public SavingThrows(Statblock stats, int[] proficiencies)
        {
            var STtemp = stats.IntArray;
            for (var i = 0; i < 6; i++)
            {
                STtemp[i] = Statblock.getModifier(STtemp[i]) + proficiencies[i] * 3;
            }

            Stats = Statblock.MakeStats(Statblock.STATS_MANUAL, STtemp);
        }
    }
}
