using DND.Characters;
using DND.Characters.Stats;

namespace DND
{
    public class Character
    {

        public bool Player;
        public int Level;
        public Skillblock Skills;
        public Statblock Stats;
        public Psychology Psychology;
        public Appearance Appearance;
        public Profession Profession;
        public Character(bool isPlayer, int level = 0)
        {
            Player = isPlayer;
            if (level == 0)
            {
                Level = new Randomiser(new[] {10, 10, 10}).Roll()+1;
            }
            else
            {
                Level = level;
            }
        }
        // NOTE
        // GENENERATION ORDER: 
        // 
        // RACE         // ALL
        // STATS        // ALL
        // PSYCHOLOGY   // ALL
        // SOCIAL CLASS // ALL
        // APPEARANCE   // ALL
        // PROFESSION   // ALL (adventurers locked on "adventurer" profession, trigger for background and class creation
        // BACKGROUND   // ADVENTURER
        // CLASS        // ADVENTURER
        // SKILLS       // ALL (only adventurers get proficiencies - inherited from class and background
        //
        #region Stats
        public void MakeStats(int[] statTable)
        {
            Stats = Statblock.MakeStats(Statblock.STATS_MANUAL, statTable);
        }

        public void MakeStats()
        {
            Stats = Statblock.MakeStats(Statblock.STATS_RANDOM, null!);
        }

        #endregion

        #region Skills

        public void MakeSkills(int[] proficiencyTable, Statblock stats, int playerLvl)
        {

        }

        #endregion

        #region Psychology

        #endregion

        #region Appearance

        #endregion

        #region Profession

        public void GenProfession(int[] weightTable)
        {
            var randomiser = new Randomiser(weightTable);
            Profession = Profession.Professions[randomiser.Roll()];
        }

        public void SetProfession(int ID)
        {
            Profession = Profession.Professions[ID];
        }
        #endregion

        #region Background

        #endregion
    }
}
