using System;
using DND.Shared.Entities.Characters.Skills;

namespace DND.Shared.Entities.Characters
{
    public class Skillblock
    {
        public Skill[] skills;
        public Skill[] noProficienciesSkills;
        public int ProficiencyBonus;
        public int Longest
        {
            get
            {
                var longest = 0;
                foreach (var t in skills)
                {
                    if (t.Name.Length > longest) longest = t.Name.Length;
                }

                return longest + 1;

            }
        }

        public Skillblock(int lvl, Statblock stats, int[] proficiencyBonus)
        {
            skills = Skill.Skills;
            noProficienciesSkills = skills;
            ProficiencyBonus = (int)Math.Floor(2 + (lvl - 1) / 4d);
            foreach (var skill in skills)
            {
                skills[skill.ID].Value = skill.BaseStat switch
                {
                    0 => stats.StrMod + proficiencyBonus[skill.ID] * ProficiencyBonus,
                    1 => stats.DexMod + proficiencyBonus[skill.ID] * ProficiencyBonus,
                    2 => stats.ConMod + proficiencyBonus[skill.ID] * ProficiencyBonus,
                    3 => stats.IntMod + proficiencyBonus[skill.ID] * ProficiencyBonus,
                    4 => stats.WisMod + proficiencyBonus[skill.ID] * ProficiencyBonus,
                    5 => stats.ChaMod + proficiencyBonus[skill.ID] * ProficiencyBonus,
                    _ => throw new Exception("Skillblock ctor: the fuck is going on here? ")
                };
            }
        }
    }
}
