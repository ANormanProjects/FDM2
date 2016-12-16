using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGameKata;

namespace BowlingTest
{
    [TestClass]
    public class BowlingKataTest
    {
        Game g;
        [TestInitialize]
        public void Setup()
        {
            g = new Game();
        }

        [TestCleanup]
        public void Cleanup()
        {
            g = null;
        }
        [TestMethod]
        public void Test_GetTotalScore_ReturnsZero_WhenNoPinsHaveBeenKnockedOver()
        {
            //ARRANGE

            //ACT
            AllRolls(20, 0);

            //ASSERT
            Assert.AreEqual(0, g.Score());
        }

        [TestMethod]
        public void Test_GetTotalScore_Return20_WhenAllRollsAreOne()
        {
            //ARRANGE

            //ACT
            AllRolls(20, 1);

            //ASSERT
            Assert.AreEqual(20, g.Score());
        }

        [TestMethod]
        public void Test_GetTotalScore_WhenGettingOneSpare()
        {
            //ARRANGE

            //ACT
            RollSpare();
            g.Roll(3);
            AllRolls(17, 0);
            //ASSERT
            Assert.AreEqual(16, g.Score());
        }

        [TestMethod]
        public void Test_GetTotalScore_WhenGettingOneStrike()
        {
            //ARRANGE

            //ACT
            RollStrike();
            g.Roll(3);
            g.Roll(4);
            AllRolls(16, 0);
            //ASSERT
            Assert.AreEqual(24, g.Score());
        }

        [TestMethod]
        public void Test_PerfectScoreForBowling()
        {
            //ARRANGE

            //ACT
            AllRolls(12, 10);

            //ASSERT
            Assert.AreEqual(300, g.Score());
        }




        //Rolling Rules
        private void AllRolls(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                g.Roll(pins);
            }
        }

        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }

        private void RollStrike()
        {
            g.Roll(10);
        }
    }
}
