using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CardGame.Test
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void Test_ADeckHas52Cards_WhenConstructed()
        {
            //ARRANGE


            //ACT
            Deck deck = new Deck();

            //ASSERT
            Assert.AreEqual(52, deck.listOfCards.Count);
        }

        [TestMethod]
        public void Test_ADeckHas52UniqueCards_WhenConstructed()
        {
            //ARRANGE


            //ACT
            Deck deck = new Deck();

            //ASSERT
            CollectionAssert.AllItemsAreUnique(deck.listOfCards);
        }

        [TestMethod]
        public void Test_ADeckIsNotInTheSameOrder_WhenShuffled()
        {
            //ARRANGE
            Deck deckBeforeShuffle = new Deck();
            Deck deckToShuffle = new Deck();


            //ACT
            deckToShuffle.Shuffle();


            //ASSERT
            Assert.AreNotEqual(deckBeforeShuffle.listOfCards, deckToShuffle.listOfCards);
        }
    }
}
