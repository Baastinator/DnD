using System;
using DND.Characters.Skills;

namespace DND.Characters
{
    public class Skillblock
    {
        public Skill[] skills;
        public Skill[] noProficienciesSkills;
        public int ProficiencyBonus;
        
        public Skillblock(int lvl, Statblock stats)
        {
            skills = Skill.Skills;
            byte[] STATS = { Skill.STR, Skill.DEX, Skill.CON, Skill.INT, Skill.WIS, Skill.CHA };
            ProficiencyBonus = (int)Math.Floor(2+(lvl-1)/4d);
            foreach (var skill in skills)
            {
                switch (skill.BaseStat)
                {
                    case 0:
                        skills[skill.ID].Value = Statblock.getModifier(stats.STR);
                        break;
                    case 1:
                        skills[skill.ID].Value = Statblock.getModifier(stats.DEX);
                        break;
                    case 2:
                        skills[skill.ID].Value = Statblock.getModifier(stats.CON);
                        break;
                    case 3:
                        skills[skill.ID].Value = Statblock.getModifier(stats.INT);
                        break;
                    case 4:
                        skills[skill.ID].Value = Statblock.getModifier(stats.WIS);
                        break;
                    case 5:
                        skills[skill.ID].Value = Statblock.getModifier(stats.CHA);
                        break;
                    default:
                        throw new Exception("Skillblock ctor: the fuck is going on here? ");
                }
            }

            noProficienciesSkills = skills;
        }

        public void ApplyProficiencies(int[] proficiencyTable)
        {
            foreach (var skill in skills)
            {
                skills[skill.ID].Value = noProficienciesSkills[skill.ID].Value + proficiencyTable[skill.ID] * ProficiencyBonus;
            }
        }
    }
}
