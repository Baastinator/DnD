namespace DND.Shared.Entities.Characters.Psychologies
{
    public class PsychValues
    {
        private readonly double[] _mod;
        public PsychValue[] Values { get; set; }

        public static double[] empty =
            {0.0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        public PsychValues(double[] mod,bool randomise = true)
        {
            Values = PsychValue.Values;
            for (int i = 0; i < Values.Length; i++)
            {
                Values[i].Value = randomise ? Randomiser.NormalDist() + mod[i] : mod[i];
            }
        }
        public PsychValues(bool randomise)
        {
            Values = PsychValue.Values;
            for (var index = 0; index < Values.Length; index++)
            {
                var t = Values[index];
                t.Value = randomise ? Randomiser.NormalDist() : 0d;
                Values[index] = t;
            }
        }

        public PsychValues()
        {
            Values = PsychValue.Values;
            for (var index = 0; index < Values.Length; index++)
            {
                var t = Values[index];
                t.Value = Randomiser.NormalDist();
                Values[index] = t;
            }
        }
        public static PsychValues operator +(PsychValues a, PsychValues b)
        {
            var c = new PsychValues(empty, false);
            for (int i = 0; i < a.Values.Length; i++)
            {
                c.Values[i].Value = a.Values[i].Value + b.Values[i].Value;
            }

            return c;
        }
    }
}
