using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumeralsKata;

namespace RomanNumeralKata
{
    [TestClass]
    public class UnitTest1
    {
        RomanNumeralsCalculator rnumcalculator;
        [TestInitialize]
        public void Setup()
        {
            rnumcalculator = new RomanNumeralsCalculator();
        }
        [TestMethod]
        public void Test_ArabicNumOneReturnsRomanI()
        {
            //Arrange
            string expected = "I";
            //Act
            string actual = rnumcalculator.arabicToRoman(1);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_ArabicNumTWOReturnsRomanII()
        {
            //Arrange
            string expected = "II";
            //Act
            string actual = rnumcalculator.arabicToRoman(2);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_ArabicNum3ReturnsRomanIII()
        {
            //Arrange
            string expected = "III";
            //Act
            string actual = rnumcalculator.arabicToRoman(3);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_ArabicNum4ReturnsRomanIV()
        {
            //Arrange
            string expected = "IV";
            //Act
            string actual = rnumcalculator.arabicToRoman(4);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_ArabicNum5ReturnsRomanV()
        {
            //Arrange
            string expected = "V";
            //Act
            string actual = rnumcalculator.arabicToRoman(5);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_ArabicNum6ReturnsRVI()
        {
            //Arrange
            string expected = "VI";
            //Act
            string actual = rnumcalculator.arabicToRoman(6);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_ArabicNum7ReturnsRVII()
        {
            //Arrange
            string expected = "VII";
            //Act
            string actual = rnumcalculator.arabicToRoman(7);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_ArabicNum8ReturnsRVIII()
        {
            //Arrange
            string expected = "VIII";
            //Act
            string actual = rnumcalculator.arabicToRoman(8);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_ArabicNum9ReturnsR_IX()
        {
            //Arrange
            string expected = "IX";
            //Act
            string actual = rnumcalculator.arabicToRoman(9);
            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
