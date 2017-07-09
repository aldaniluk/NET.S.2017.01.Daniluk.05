using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public static string ContertToBits (this double number)
        { 
            bool[] bits = new bool[64];

            PutSign(number, bits);

            double n = Math.Abs(number);

            bool[] mantissa = new bool[53];
            int index = GetMantissa(n, mantissa);


            int order = 0;
            for (int i = 0; i < mantissa.Length; i++)
            {
                if (mantissa[i] == true)
                {
                    order = index - i - 1;
                    break;
                }
            }

            order += 1023;
            BitArray orderArr = new BitArray(new int[] { order });

            int j = 0;
            for (int i = 11; i >= 1; i--, j++)
            {
                bits[i] = orderArr[j];
            }
            for (int i = 12; i < bits.Length; i++)
            {
                bits[i] = mantissa[i - 11];
            }

            return ConvertBoolArrToString(bits);
        }

        private static void PutSign(double number, bool[] bits)
        {
            if (number > 0)
            {
                bits[0] = false;
            }
            else
            {
                bits[0] = true;
            }
        }

        private static int GetMantissa(double n, bool[] mantissa)
        {
            //for int part of a number
            BitArray intPartArr = new BitArray(new int[] { (int)n });
            int index = 0;
            for (int i = intPartArr.Length - 1; i >= 0; i--)
            {
                if (intPartArr[i] == true)
                {

                    for (int ii = i; ii >= 0; ii--, index++)
                    {
                        mantissa[index] = intPartArr[ii];
                    }
                    break;
                }
            }

            //for decimal part
            for (int i = index; i < mantissa.Length; i++)
            {
                if ((n * 2 - ((int)n) * 2) >= 1)
                {
                    mantissa[i] = true;
                }
                else
                {
                    mantissa[i] = false;
                }
                n *= 2;
                n -= (int)n;
            }
            return index;
        }

        private static string ConvertBoolArrToString(bool[] arr)
        {
            byte[] result = new byte[64];
            for (int i = 0; i < result.Length; i++)
            {
                if (arr[i])
                {
                    result[i] = 1;
                }
                else
                {
                    result[i] = 0;
                }
            }
            return string.Join("", result);
        }
    }
}
