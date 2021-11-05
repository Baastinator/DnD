using System;
using System.Security.Cryptography.X509Certificates;
using DND.Characters;
using DND.Characters.Stats;

namespace DND
{
    public class Character
    {

        public bool Player;
        public int Level;
        public Race Race;
        public Statblock Stats;
        public Psychology Psychology;
        public SocialClass SocialClass;
        public Appearance Appearance;
        public Profession Profession;
        public Background Background;
        public Class Class;
        public SavingThrows SavingThrows;
        public Skillblock Skills;
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
        // RACE             // ALL 
        // STATS            // ALL
        // SOCIAL CLASS     // ALL
        // APPEARANCE       // ALL
        // PROFESSION       // ALL (adventurers locked on "adventurer" profession, trigger for background and class creation
        // BACKGROUND       // ADVENTURER
        // CLASS            // ADVENTURER
        // SAVING THROWS    // ADVENTURER
        // SKILLS           // ALL (only adventurers get proficiencies - inherited from class and background
        // PSYCHOLOGY       // ALL
        //
        // NOTE
        #region RACE

        public void GenRace()
        {
            var raceRandomiser = new Randomiser(new[] {100,70,60,50,30,20,20,20,15,10,10,5,5,5});
            Race = Race.Races[raceRandomiser.Roll()];
        }

        public void SetRace(int ID)
        {
            Race = Race.Races[ID];
        }

        #endregion

        #region STATS
        public void MakeStats(int[] statTable)
        {
            var stats = Statblock.MakeStats(Statblock.STATS_MANUAL, statTable);
            var bonus = Statblock.MakeStats(Statblock.STATS_MANUAL, Race.StatBonus);
            Stats = Statblock.AddStats(stats, bonus);
        }

        public void MakeStats()
        {
            var stats = Statblock.MakeStats(Statblock.STATS_RANDOM, null!);
            var bonus = Statblock.MakeStats(Statblock.STATS_MANUAL, Race.StatBonus);
            Stats = Statblock.AddStats(stats, bonus);
        }

        #endregion

        #region PSYCHOLOGY

        #endregion

        #region SOCIAL CLASS

        

        #endregion

        #region APPEARANCE

        #endregion

        #region PROFESSION

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

        #region BACKGROUND

        #endregion

        #region CLASS



        #endregion

        #region SAVING THROWS

        

        #endregion

        #region SKILLS

        public void MakeSkills(int[] proficiencyTable, Statblock stats, int playerLvl)
        {

        }

        #endregion
    }
}
