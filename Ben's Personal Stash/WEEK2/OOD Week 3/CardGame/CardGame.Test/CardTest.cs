using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardGame.Test
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void Test_ACardHasAFaceofFour_WhenConstructed()
        {
            //ARRANGE
            

            //ACT
            Card card = new Card(Face.Four, Suit.Spades);

            //ASSERT
            Assert.AreEqual(Face.Four, card.face);


        }

        [TestMethod]
        public void Test_ACardHasASuitOfHearts_WhenConstructed()
        {
            //ARRANGE


            //ACT
            Card card = new Card(Face.Ace, Suit.Hearts);

            //ASSERT
            Assert.AreEqual(Suit.Hearts, card.suit);


        }
    }
}
