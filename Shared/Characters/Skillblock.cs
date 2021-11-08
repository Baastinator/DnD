using System;
using DND.Characters.Skills;

namespace DND.Characters
{
    public class Skillblock
    {
        public Skill[] skills;
        public Skill[] noProficienciesSkills;
        public int ProficiencyBonus;

        public Skillblock(int lvl, Statblock stats, int[] proficiencyBonus)
        {
            skills = Skill.Skills;
            ProficiencyBonus = (int) Math.Floor(2 + (lvl - 1) / 4d);
            foreach (var skill in skills)
            {
                switch (skill.BaseStat)
                {
                    case 0:
                        skills[skill.ID].Value = stats.StrMod + (proficiencyBonus[skill.ID] * 3);
                        break;
                    case 1:
                        skills[skill.ID].Value = stats.DexMod + (proficiencyBonus[skill.ID] * 3);
                        break;
                    case 2:
                        skills[skill.ID].Value = stats.ConMod + (proficiencyBonus[skill.ID] * 3);
                        break;
                    case 3:
                        skills[skill.ID].Value = stats.IntMod + (proficiencyBonus[skill.ID] * 3);
                        break;
                    case 4:
                        skills[skill.ID].Value = stats.WisMod + (proficiencyBonus[skill.ID] * 3);
                        break;
                    case 5:
                        skills[skill.ID].Value = stats.ChaMod + (proficiencyBonus[skill.ID] * 3);
                        break;
                    default:
                        throw new Exception("Skillblock ctor: the fuck is going on here? ");
                }
            }
            noProficienciesSkills = skills;
        }
    }
}
