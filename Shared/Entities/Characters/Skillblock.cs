using System;
using DND.Shared.Entities.Characters.Skills;

namespace DND.Shared.Entities.Characters
{
    public class Skillblock
    {
        public Skill[] skills;
        public Skill[] noProficienciesSkills;
        public int ProficiencyBonus;
        public string Display { get
            {
                var longest = 0;
                foreach (var t in skills)
                {
                    if (t.Name.Length > longest) longest = t.Name.Length;
                }
                var output = "";
                foreach (var item in skills)
                {
                    var pos = "";
                    if (item.Value >= 0) pos = " ";
                    output += Strings.AddWhitespace(item.Name, longest) + "- " + pos + Strings.RoundNumber(item.Value) + "\n";
                }

                return output;
            }
        }

        public Skillblock(int lvl, Statblock stats, int[] proficiencyBonus)
        {
            skills = Skill.Skills;
            ProficiencyBonus = (int)Math.Floor(2 + (lvl - 1) / 4d);
            foreach (var skill in skills)
            {
                skills[skill.ID].Value = skill.BaseStat switch
                {
                    0 => stats.StrMod + (proficiencyBonus[skill.ID] * 3),
                    1 => stats.DexMod + (proficiencyBonus[skill.ID] * 3),
                    2 => stats.ConMod + (proficiencyBonus[skill.ID] * 3),
                    3 => stats.IntMod + (proficiencyBonus[skill.ID] * 3),
                    4 => stats.WisMod + (proficiencyBonus[skill.ID] * 3),
                    5 => stats.ChaMod + (proficiencyBonus[skill.ID] * 3),
                    _ => throw new Exception("Skillblock ctor: the fuck is going on here? ")
                };
            }
            noProficienciesSkills = skills;
        }
    }
}
