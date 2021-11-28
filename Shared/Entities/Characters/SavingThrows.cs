namespace DND.Shared.Entities.Characters
{
    public class SavingThrows
    {
        public Statblock Stats { get; set; }
        public int STR => Stats.STR;
        public int DEX => Stats.DEX;
        public int CON => Stats.CON;
        public int INT => Stats.INT;
        public int WIS => Stats.WIS;
        public int CHA => Stats.CHA;

        public SavingThrows(Statblock stats, int[] proficiencies)
        {
            var STtemp = stats.IntArray;
            for (var i = 0; i < 6; i++)
            {
                STtemp[i] = Statblock.getModifier(STtemp[i]) + proficiencies[i] * 3;
            }

            Stats = Statblock.MakeStats(STtemp);
        }
    }
}
