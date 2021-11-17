using System;
using System.Collections.Generic;
using System.Text;

namespace DND.Shared
{
    public class DoubleArray
    {
        public double[] Array { get; set; }

        public DoubleArray(double[] a)
        {
            Array = a;
        }

        public static DoubleArray operator +(DoubleArray a, DoubleArray b)
        {
            if (a.Array.Length != b.Array.Length) throw new Exception("DoubleArray: operator+ sizes don't match");
            for (int i = 0; i < a.Array.Length; i++)
            {
                a.Array[i] += b.Array[i];
            }
            return a;
        }

        public static DoubleArray operator -(DoubleArray a)
        {
            for (int i = 0; i < a.Array.Length; i++)
            {
                a.Array[i] = -a.Array[i];
            }

            return a;
        }

        public static DoubleArray operator *(DoubleArray a, double b)
        {
            for (int i = 0; i < a.Array.Length; i++)
            {
                a.Array[i] *= b;
            }

            return a;
        }
        public static DoubleArray operator /(DoubleArray a, double b)
        {
            for (int i = 0; i < a.Array.Length; i++)
            {
                a.Array[i] /= b;
            }

            return a;
        }
    }

    public class IntArray
    {
        public int[] Array { get; set; }

        public static IntArray operator +(IntArray a, IntArray b)
        {
            if (a.Array.Length != b.Array.Length) throw new Exception("IntArray: operator+ sizes don't match");
            for (int i = 0; i < a.Array.Length; i++)
            {
                a.Array[i] += b.Array[i];
            }

            return a;
        }

        public static IntArray operator -(IntArray a)
        {
            for (int i = 0; i < a.Array.Length; i++)
            {
                a.Array[i] = -a.Array[i];
            }

            return a;
        }

        public static IntArray operator *(IntArray a, int b)
        {
            for (int i = 0; i < a.Array.Length; i++)
            {
                a.Array[i] *= b;
            }

            return a;
        }
        public static IntArray operator /(IntArray a, int b)
        {
            for (int i = 0; i < a.Array.Length; i++)
            {
                a.Array[i] /= b;
            }

            return a;
        }
    }
}
