
namespace DND.Characters
{
    public class SavingThrows
    {
        public Statblock Stats { get; set; }
        public SavingThrows(int[] proficiencies)
        {
            for (int i = 0; i < proficiencies.Length; i++)
            {
                proficiencies[i] *= 3;
            }
            Stats = Statblock.MakeStats(Statblock.STATS_MANUAL, proficiencies); 
        }
    }
}
