using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzTDD;

namespace UnitTestProject1
{
    [TestClass]
    public class FizzBuzzTest
    {
        [TestMethod]
        public void Test_ThreeIsDivisibleByThree()
        {
            FizzBuzz fb = new FizzBuzz();

            bool divisible = fb.IsDivisibleByThree(3);

            Assert.IsTrue(divisible);
        }

        [TestMethod]
        public void Test_FiveIsDivisibleByFive()
        {
            FizzBuzz fb = new FizzBuzz();

            bool divisible = fb.IsDivisibleByFive(5);

            Assert.IsTrue(divisible);
        }

        [TestMethod]
        public void Test_15IsDivisibleBy15()
        {
            FizzBuzz fb = new FizzBuzz();

            bool divisible = fb.IsDivisibleBy15(15);

            Assert.IsTrue(divisible);
        }

        [TestMethod]
        public void Test_TextForDivisibleByThreeIsFizz()
        {
            FizzBuzz fb = new FizzBuzz();

            string expected = "Fizz";
            string actual = fb.GetTextForNumber(3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_TextForDivisibleByFiveIsBuzz()
        {
            //ARRANGE
            FizzBuzz fb = new FizzBuzz();

            //ACT
            string expected = "Buzz";
            string actual = fb.GetTextForNumber(5);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_TextForDivisibleByThreeAndFiveIsFizzBuzz()
        {
            //ARRANGE
            FizzBuzz fb = new FizzBuzz();

            //ACT
            string expected = "FizzBuzz";
            string actual = fb.GetTextForNumber(15);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_TextForNotDivisibleByThreeorFiveIsItselfText()
        {
            //ARRANGE
            FizzBuzz fb = new FizzBuzz();

            //ACT
            string expected = "4";
            string actual = fb.GetTextForNumber(4);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CanDoTheWholeFizzBuzz()
        {
            //ARRANGE
            FizzBuzz fb = new FizzBuzz();

            //ACT
            string expected = "1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz ";
            string actual = fb.DoTheFullFizzBuzz(15);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
