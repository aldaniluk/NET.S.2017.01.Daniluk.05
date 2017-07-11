using System;
using System.Collections;
using System.Diagnostics;

namespace Logic
{
    public class Nod
    {
        #region Euclid
        /// <summary>
        /// Finds NOD using Euclid method for 2 parameters.
        /// </summary>
        /// <param name="lsh">Left int number.</param>
        /// <param name="rsh">Second int number.</param>
        /// <returns>NOD of all parameters.</returns>
        public static int Euclid(int lhs, int rhs)
        {
            lhs = Math.Abs(lhs);
            rhs = Math.Abs(rhs);

            if (lhs == 0) return rhs;
            if (rhs == 0) return lhs;

            while (lhs != rhs)
            {
                if (lhs > rhs)
                {
                    lhs -= rhs;
                }
                else
                {
                    rhs -= lhs;
                }
            }
            return lhs;
        }

        /// <summary>
        /// Finds NOD using Euclid method for array.
        /// </summary>
        /// <param name="array">Array of parameters.</param>
        /// <returns>NOD of all parameters.</returns>
        public static int Euclid(params int[] array)
        {
            CheckArray(array);

            int nod = Euclid(array[0], array[1]);
            for (int i = 2; i < array.Length; i++)
            {
                nod = Euclid(array[i], nod);
            }
            return nod;
        }

        /// <summary>
        /// Finds NOD using Euclid method for array.
        /// </summary>
        /// <param name="time">Time of execution program in milliseconds.</param>
        /// <param name="array">Array of parameters.</param>
        /// <returns>NOD of all parameters.</returns>
        public static int Euclid(out long time, params int[] array)
        {
            CheckArray(array);

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
        #endregion

        #region Stein
        /// <summary>
        /// Finds NOD using Stein method for 2 parameters.
        /// </summary>
        /// <param name="a">Left int parameter.</param>
        /// <param name="b">Right int parameter.</param>
        /// <returns>NOD of all parameters.</returns>
        public static int Stein(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == b) return a;
            if (a == 0) return b;
            if (b == 0) return a;
            if (a == 1 || b == 1) return 1;

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

        /// <summary>
        /// Finds NOD using Stein method for array.
        /// </summary>
        /// <param name="array">Array of parameters.</param>
        /// <returns>NOD of all parameters.</returns>
        public static int Stein(params int[] array)
        {
            CheckArray(array);

            int nod = Stein(array[0], array[1]);
            for (int i = 2; i < array.Length; i++)
            {
                nod = Stein(array[i], nod);
            }
            return nod;
        }

        /// <summary>
        /// Finds NOD using Stein method for array.
        /// </summary>
        /// <param name="time">Time of execution program in milliseconds.</param>
        /// <param name="array">Array of parameters.</param>
        /// <returns>NOD of all parameters.</returns>
        public static int Stein(out long time, params int[] array)
        {
            CheckArray(array);

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
        #endregion

        #region private CheckArray
        private static void CheckArray(int[] array)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException($"{nameof(array)} is null.");
            if (array.Length == 0) throw new ArgumentException($"{nameof(array)} is empty.");
            if (array.Length == 1) throw new ArgumentException($"{nameof(array)} has to take at least 2 elements.");
        }
        #endregion
    }
}
