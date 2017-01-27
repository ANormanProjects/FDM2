using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;

namespace CollectionTest
{
    [TestClass]
    public class RemoveDupesFromListTests
    {
        [TestMethod]
        public void Test_RemoveDupes_RemovesAllDuplicateValuesWhenGivenAnArrayOfStrings()
        {
            //ARRANGE
            RemoveDupesFromList rmd = new RemoveDupesFromList();
            string[] expected = { "bill", "andrew", "ben", "bob" };

            //ACT
            string[] actual = rmd.removedupes("bill", "bill", "andrew", "ben", "bob", "andrew", "ben", "ben");

            //ASSERT
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}
