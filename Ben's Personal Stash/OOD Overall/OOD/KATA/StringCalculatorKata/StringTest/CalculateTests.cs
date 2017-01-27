using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorKata;

namespace StringTest
{
    [TestClass]
    public class CalculateTests
    {
        [TestMethod] // TEST 1
        public void Test_INTAddMethod_WillReturnZero_WhenNotGivenAnyInput()
        {
            //ARRANGE
            StringCalculator stringcalculator = new StringCalculator();
            int expected = 0;

            //ACT
            int actual = stringcalculator.Add("");

            //ASSERT
            Assert.AreEqual(expected, actual);

        }

        [TestMethod] // Task 2
        public void Test_INTAddMethod_WillReturnSUMofNumbers_WhenGivenOneNumberOfOne()
        {
            //ARRANGE
            StringCalculator stringcalculator = new StringCalculator();
            int expected = 1;

            //ACT
            int actual = stringcalculator.Add("1");

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_AddMethod_ReturnSumOfNumbers_WhenGivenOneNumberOfTwo()
        {
            //ARRANGE
            StringCalculator stringcalculator = new StringCalculator();
            int expected = 2;

            //ACT
            int actual = stringcalculator.Add("2");

            //ASSERT
            Assert.AreEqual(expected, actual);

        }

        [TestMethod] //TASK 4
        public void Test_AddMethod_ReturnsSumOfNumbers_WhenGivenTwoNumbersOfOneAndTwo()
        {
            //ARRANGE
            StringCalculator stringcalculator = new StringCalculator();
            int expected = 3;

            //ACT
            int actual = stringcalculator.Add("1, 2");

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] //TASK 5
        public void Test_AddMethod_ReturnsSumOfNumbers_WhenGivenTwoNumbersOfTenAndTwenty()
        {
            //ARRANGE
            StringCalculator stringcalculator = new StringCalculator();
            int expected = 30;

            //ACT
            int actual = stringcalculator.Add("10, 20");

            //ASSERT
            Assert.AreEqual(expected, actual);
        }
    }


}
