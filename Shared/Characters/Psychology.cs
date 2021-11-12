using DND.Characters.Psychologies;

namespace DND.Characters
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
