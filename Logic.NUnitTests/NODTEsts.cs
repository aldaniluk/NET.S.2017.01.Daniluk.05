using NUnit.Framework;
using System;
using Logic;

namespace Logic.NUnitTests
{
    [TestFixture]
    public class NodTests
    {
        #region Euclid
        [TestCase(12, 16, ExpectedResult = 4)]
        [TestCase(12, 0, ExpectedResult = 12)]
        [TestCase(0, 16, ExpectedResult = 16)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(-12, 16, ExpectedResult = 4)]
        [TestCase(12, -16, ExpectedResult = 4)]
        [TestCase(-12, -16, ExpectedResult = 4)]
        [TestCase(12, 16, 11, ExpectedResult = 1)]
        [TestCase(12, 16, 36, ExpectedResult = 4)]
        [TestCase(0, 16, 36, ExpectedResult = 4)]
        [TestCase(12, 0, 36, ExpectedResult = 12)]
        [TestCase(0, 16, 0, ExpectedResult = 16)]
        [TestCase(0,0,0,0,0, ExpectedResult = 0)]
        public int Euclid_CorrectValues_PositiveTest(params int[] array)
        { 
            long time;
            return Nod.Euclid(out time, array);
        }
        #endregion

        #region Stein
        [TestCase(12, 16, ExpectedResult = 4)]
        [TestCase(12, 0, ExpectedResult = 12)]
        [TestCase(0, 16, ExpectedResult = 16)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(-12, 16, ExpectedResult = 4)]
        [TestCase(12, -16, ExpectedResult = 4)]
        [TestCase(-12, -16, ExpectedResult = 4)]
        [TestCase(12, 16, 11, ExpectedResult = 1)]
        [TestCase(12, 16, 36, ExpectedResult = 4)]
        [TestCase(0, 16, 36, ExpectedResult = 4)]
        [TestCase(12, 0, 36, ExpectedResult = 12)]
        [TestCase(0, 16, 0, ExpectedResult = 16)]
        [TestCase(0, 0, 0, 0, 0, ExpectedResult = 0)]
        public int Stein_CorrectValues_PositiveTest(params int[] array)
        {
            long time;
            return Nod.Stein(out time, array);
        }
        #endregion
    }
}
