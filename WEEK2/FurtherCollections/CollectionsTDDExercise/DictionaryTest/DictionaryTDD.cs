using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DictionaryTask3;
using System.Drawing;
using System.Collections.Generic;

namespace DictionaryTest
{
    [TestClass]
    public class DictionaryTDD
    {
        [TestMethod]
        public void Test_GetColor_ReturnEmptyDictionary_IfNoColorWasPassed()
        {
            //ARRANGE
            DictionaryController DicCon = new DictionaryController();
            Dictionary<string, Color> expected = new Dictionary<string, Color>();

            expected.Add("Red", Color.Red);
            expected.Add("Blue", Color.Blue);
            expected.Add("Green", Color.Green);
            expected.Add("White", Color.White);
            expected.Add("Black", Color.Black);


            //ACT
            Dictionary<string, Color> actual = DicCon.GetColor();

            //ASSERT
            CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod] //TEST 2
        //public void Test_GetColor_ReturnDictionaryListOfOne_IfRedColorWasPassed()
        //{
        //    //ARRANGE
        //    DictionaryController DicCon = new DictionaryController();
        //    //Dictionary<string, Color> expected = new Dictionary<string, Color>();
        //    int expected = 2;
            

        //    //ACT
        //    DicCon.AddColor("Red", Color.Red);
        //    //Dictionary<string, Color> 
        //    int actual = DicCon.GetColor().Count;

        //    //ASSERT
        //    Assert.AreEqual(expected, actual);
        //}
    }
}
