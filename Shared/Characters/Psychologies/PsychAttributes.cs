using System.Collections.Generic;

namespace DND.Characters.Psychologies
{
    class PsychAttributes
    {
        public int GetAttribVal()
        {
            Randomiser rng = new Randomiser(new[] { 10, 20, 30, 50, 30, 20, 10});
            return rng.Roll();
        }
    }
}
