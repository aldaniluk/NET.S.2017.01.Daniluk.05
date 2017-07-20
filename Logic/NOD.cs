using System;
using System.Collections;
using System.Diagnostics;

namespace Logic
{
    public class Nod
    {
        private delegate int NodHelper(int lhs, int rhs);

        #region Euclid
        /// <summary>
        /// Finds NOD using Euclid method for 2 parameters.
        /// </summary>
        /// <param name="lsh">Left int number.</param>
        /// <param name="rsh">Second int number.</param>
        /// <returns>NOD of all parameters.</returns>
        public static int Euclid(int lhs, int rhs) => NodHelperMethod(EuclidHelper, lhs, rhs);

        /// <summary>
        /// Finds NOD using Euclid method for array.
        /// </summary>
        /// <param name="array">Array of parameters.</param>
        /// <returns>NOD of all parameters.</returns>
        public static int Euclid(params int[] array) => NodHelperMethod(EuclidHelper, array);

        /// <summary>
        /// Finds NOD using Euclid method for array.
        /// </summary>
        /// <param name="time">Time of execution program in milliseconds.</param>
        /// <param name="array">Array of parameters.</param>
        /// <returns>NOD of all parameters.</returns>
        public static int Euclid(out long time, params int[] array) => NodHelperMethod(EuclidHelper, out time, array);
        #endregion

        #region Stein
        /// <summary>
        /// Finds NOD using Stein method for 2 parameters.
        /// </summary>
        /// <param name="a">Left int parameter.</param>
        /// <param name="b">Right int parameter.</param>
        /// <returns>NOD of all parameters.</returns>
        public static int Stein(int lhs, int rhs) => NodHelperMethod(SteinHelper, lhs, rhs);

        /// <summary>
        /// Finds NOD using Stein method for array.
        /// </summary>
        /// <param name="array">Array of parameters.</param>
        /// <returns>NOD of all parameters.</returns>
        public static int Stein(params int[] array) => NodHelperMethod(SteinHelper, array);

        /// <summary>
        /// Finds NOD using Stein method for array.
        /// </summary>
        /// <param name="time">Time of execution program in milliseconds.</param>
        /// <param name="array">Array of parameters.</param>
        /// <returns>NOD of all parameters.</returns>
        public static int Stein(out long time, params int[] array) => NodHelperMethod(SteinHelper, out time, array);
        #endregion

        #region private methods
        private static int NodHelperMethod(NodHelper helper, int lhs, int rhs)
        {
            return helper(lhs, rhs);
        }

        private static int NodHelperMethod(NodHelper helper, params int[] array)
        {
            CheckArray(array);

            int nod = helper(array[0], array[1]);
            for (int i = 2; i < array.Length; i++)
            {
                nod = helper(array[i], nod);
            }

            return nod;
        }

        private static int NodHelperMethod(NodHelper helper, out long time, params int[] array)
        {
            CheckArray(array);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int nod = NodHelperMethod(helper, array);

            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;

            return nod;
        }

        private static int EuclidHelper(int lhs, int rhs)
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

        private static int SteinHelper(int lhs, int rhs)
        {
            lhs = Math.Abs(lhs);
            rhs = Math.Abs(rhs);

            if (lhs == rhs) return lhs;
            if (lhs == 0) return rhs;
            if (rhs == 0) return lhs;
            if (lhs == 1 || rhs == 1) return 1;

            if ((lhs & 1) == 0)
            {
                if ((rhs & 1) == 1)
                    return Stein(lhs >> 1, rhs);
                else
                    return (Stein(lhs >> 1, rhs >> 1) << 1);
            }
            else
            {
                if ((rhs & 1) == 0)
                    return Stein(lhs, rhs >> 1);
                else
                {
                    if (lhs < rhs)
                        return Stein(lhs, Math.Abs(lhs - rhs) >> 1);
                    else
                        return Stein(Math.Abs(lhs - rhs) >> 1, rhs);
                }
            }
        }

        private static void CheckArray(int[] array)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException($"{nameof(array)} is null.");
            if (array.Length == 0) throw new ArgumentException($"{nameof(array)} is empty.");
            if (array.Length == 1) throw new ArgumentException($"{nameof(array)} has to take at least 2 elements.");
        }
        #endregion
    }
}
