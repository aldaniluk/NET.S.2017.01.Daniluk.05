using System;
using Logic;
using NUnit.Framework;

namespace Logic.NUnitTests
{
    [TestFixture]
    class PolynomialTests
    {
        #region ToStringTest
        [TestCase(new double[] { 2, 0, 1 }, ExpectedResult = "2 + 1*(x^2)")]
        [TestCase(new double[] { 3, 5 }, ExpectedResult = "3 + 5*(x^1)")]
        [TestCase(new double[] { 0, 0, 4, 6 }, ExpectedResult = "4*(x^2) + 6*(x^3)")]
        public string ToStringTest_CorrectValues_PositiveTest(double[] array1)
        {
            Polynomial p1 = new Polynomial(array1);
            return p1.ToString();
        }
        #endregion

        #region EqualsTest
        [TestCase(new double[] { 2, 0, 1 }, new double[] { 2, 0, 1 }, ExpectedResult = true)]
        [TestCase(new double[] { 2, 0, 1 }, new double[] { 2, 0, 2 }, ExpectedResult = false)]
        [TestCase(new double[] { 2, 0, 1 }, new double[] { 2, 0 }, ExpectedResult = false)]
        public bool EqualsTest_CorrectValues_PositiveTest(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            return p1.Equals(p2);
        }

        [Test]
        public void EqualsTest_NullInputValues_PositiveTest()
        {
            Polynomial p1 = new Polynomial(new double[] { 2, 0, 1 });
            Polynomial p2 = null;
            Assert.False(p1.Equals(p2));
        }

        [Test]
        public void EqualsTest_SameInputValues_PositiveTest()
        {
            Polynomial p1 = new Polynomial(new double[] { 2, 0, 1 });
            Polynomial p2 = p1;
            Assert.True(p1.Equals(p2));
        }
        #endregion

        #region operators +,-,*,==,!=
        #region +
        [TestCase(new double[] { 2, 0, 1 }, new double[] { 1, 4 }, new double[] { 3, 4, 1 })]
        [TestCase(new double[] { 0, 0, 1 }, new double[] { 1, 4 }, new double[] { 1, 4, 1 })]
        public void OperatorPlus_CorrectValues_PositiveTest(double[] array1, double[] array2, double[] result)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Polynomial expected = new Polynomial(result);
            Assert.True((p1+p2).Equals(expected));
        }
        #endregion

        #region -
        [TestCase(new double[] { 2, 0, 1 }, new double[] { 1, 4 }, new double[] { 1, -4, 1 })]
        [TestCase(new double[] { 0, 0, 1 }, new double[] { 1, 4 }, new double[] { -1, -4, 1 })]
        public void OperatorMinus_CorrectValues_PositiveTest(double[] array1, double[] array2, double[] result)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Polynomial expected = new Polynomial(result);
            Assert.True((p1 - p2).Equals(expected));
        }
        #endregion

        #region *
        [TestCase(new double[] { 2, 0, 1 }, new double[] { 1, 4 }, new double[] { 2, 8, 1, 4 })]
        [TestCase(new double[] { 0, 0, 1 }, new double[] { 1, 4 }, new double[] { 0, 0, 1, 4 })]
        public void OperatorMultiply_CorrectValues_PositiveTest(double[] array1, double[] array2, double[] result)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Polynomial expected = new Polynomial(result);
            Assert.True((p1 * p2).Equals(expected));
        }
        #endregion

        #region ==
        [TestCase(new double[] { 2, 0, 1 }, new double[] { 2, 0, 1 })]
        [TestCase(new double[] { 0, 0, 1 }, new double[] { 0, 0, 1 })]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 })]
        public void OperatorEqual_True_PositiveTest(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Assert.True(p1 == p2);
        }

        [TestCase(new double[] { 2, 0, 1 }, new double[] { 2, 0 })]
        [TestCase(new double[] { 0, 0, 1 }, new double[] { 0, 0, 2 })]
        [TestCase(new double[] { 0, 0 }, new double[] { 0, 0, 0 })]
        public void OperatorEqual_False_PositiveTest(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Assert.False(p1 == p2);
        }
        #endregion

        #region !=
        [TestCase(new double[] { 2, 0, 1 }, new double[] { 2, 0 })]
        [TestCase(new double[] { 0, 0, 1 }, new double[] { 0, 0, 2 })]
        [TestCase(new double[] { 1, 0, 0 }, new double[] { 0, 0, 0 })]
        public void OperatorNotEqual_True_PositiveTest(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Assert.True(p1 != p2);
        }

        [TestCase(new double[] { 2, 0, 1 }, new double[] { 2, 0, 1 })]
        [TestCase(new double[] { 0, 0, 1 }, new double[] { 0, 0, 1 })]
        [TestCase(new double[] { 0, 0 }, new double[] { 0, 0 })]
        public void OperatorNotEqual_False_PositiveTest(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Assert.False(p1 != p2);
        }
        #endregion

        #endregion

        #region CalculateByValue
        [TestCase(new double[] { 2, 0, 1 }, 2, ExpectedResult = 6)]
        [TestCase(new double[] { 0, 0, 0 }, 2, ExpectedResult = 0)]
        [TestCase(new double[] { 5, 4, 2, 11 }, 0, ExpectedResult = 5)]
        [TestCase(new double[] { 2, 3 }, 3, ExpectedResult = 11)]
        public double CalculateByValue_CorrectValues_PositiveTest(double[] array1, double value)
        {
            Polynomial p1 = new Polynomial(array1);
            return p1.CalculateByValue(value);
        }
        #endregion
    }
}
