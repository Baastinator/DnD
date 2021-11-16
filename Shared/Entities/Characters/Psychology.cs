using DND.Shared.Entities.Characters.Psychologies;

namespace DND.Shared.Entities.Characters
{
    public class Psychology
    {
        public Personality Personality { get; set; }
        public PsychValues Values { get; set; }

        public Psychology()
        {
            Personality = new Personality();
            Values = new PsychValues();
        }
    }
}
