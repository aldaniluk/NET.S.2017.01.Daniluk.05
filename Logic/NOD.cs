using System;
using System.Collections;
using System.Diagnostics;

namespace Logic
{
    public class Nod
    {
        #region Euclid
        /// <summary>
        /// Finds NOD using Euclid method.
        /// </summary>
        /// <param name="time">Time of execution program in milliseconds.</param>
        /// <param name="array">Array of parameters.</param>
        /// <returns>NOD of all parameters.</returns>
        public static int Euclid(out long time, params int[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int nod = Euclid(array[0], array[1]);
            for (int i = 2; i < array.Length; i++)
            {
                nod = Euclid(array[i], nod);
            }
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
            return nod;
        }

        private static int Euclid(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 0) return b;
            if (b == 0) return a;

            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            return a;
        }
        #endregion

        #region Stein
        /// <summary>
        /// Finds NOD using Stein method.
        /// </summary>
        /// <param name="time">Time of execution program in milliseconds.</param>
        /// <param name="array">Array of parameters.</param>
        /// <returns>NOD of all parameters.</returns>
        public static int Stein(out long time, params int[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int nod = Stein(array[0], array[1]);
            for (int i = 2; i < array.Length; i++)
            {
                nod = Stein(array[i], nod);
            }
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
            return nod;
        }

        private static int Stein(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == b) return a;
            if (a == 0) return b;
            if (b == 0) return a;
            if (a == 1 || b == 1) return 1;


            //if ((a & 1) == 0) return ((b & 1) == 1) ? Stein(a >> 1, b) : (Stein(a >> 1, b >> 1) << 1);
            //else return ((b & 1) == 0) ? Stein(a, b >> 1) : ((a < b) ? Stein(a, Math.Abs(a - b) >> 1) : Stein(Math.Abs(a - b) >> 1, b));

            if ((a & 1) == 0)
            {
                if ((b & 1) == 1)
                    return Stein(a >> 1, b);
                else
                    return (Stein(a >> 1, b >> 1) << 1);
            }
            else
            {
                if ((b & 1) == 0)
                    return Stein(a, b >> 1);
                else
                {
                    if (a < b)
                        return Stein(a, Math.Abs(a - b) >> 1);
                    else
                        return Stein(Math.Abs(a - b) >> 1, b);
                }
            }
        }
        #endregion
    }
}
