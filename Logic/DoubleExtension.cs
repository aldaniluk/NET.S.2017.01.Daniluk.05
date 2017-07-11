using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class DoubleExtension
    {
        /// <summary>
        /// Converts double number into bit representation.
        /// </summary>
        /// <param name="number">Double number to be converted.</param>
        /// <returns>String of bits.</returns>
        public static string DoubleToBits(this double number)
        {
            NumberUnion union = new NumberUnion();
            union.dNumber = number;

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < 64; i++)
            {
                result.Append(((union.lNumber & 1) == 1) ? "1" : "0");
                union.lNumber >>= 1;
            }

            char[] resultArray = result.ToString().ToCharArray();
            Array.Reverse(resultArray);

            return new string(resultArray);
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct NumberUnion
        {
            [FieldOffset(0)]
            public double dNumber;
            [FieldOffset(0)]
            public long lNumber;
        }
    }
}
