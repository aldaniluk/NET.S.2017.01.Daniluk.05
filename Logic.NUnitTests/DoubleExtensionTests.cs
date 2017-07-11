﻿using NUnit.Framework;
using System;
using Logic;

namespace Logic.NUnitTests
{
    [TestFixture]
    class DoubleExtensionTests
    {
        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-7.333, ExpectedResult = "1100000000011101010101001111110111110011101101100100010110100010")]
        [TestCase(11.478, ExpectedResult = "0100000000100110111101001011110001101010011111101111100111011011")]
        [TestCase(-111.57, ExpectedResult = "1100000001011011111001000111101011100001010001111010111000010100")]
        public string DoubleToBits_CorrectValues_PositiveTest(double number)
        {
            return number.DoubleToBits();
        }
    }
}
