using System;
using System.Collections.Generic;

namespace DND.Shared.Entities.Characters.Psychologies
{
    public class PsychValues
    {
        public PsychValue[] Values { get; set; }

        public PsychValues(IReadOnlyList<double> mod)
        {
            Values = PsychValue.Values;
            for (int i = 0; i < Values.Length; i++)
            {
                Values[i].Value = Randomiser.NormalDist(mod[i]);
            }
        }

        public static double[] AddValueModifiers(double[] a, double[] b)
        {
            if (a.Length != b.Length) throw new Exception("PsychValues.AddValueModifiers: input length doesn't match");
            double[] c = new double[a.Length];
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = a[i] + b[i];
            }
            return c;
        }
    }
}
