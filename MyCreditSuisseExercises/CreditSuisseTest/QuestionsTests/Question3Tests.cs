using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountUnsafeQuestion3;

namespace QuestionsTests
{
    [TestClass]
    public class Question3Tests
    {
        [TestMethod]
        public void Test_BalanceGet_ReturnsCorrectBalance_WhenCalledWhenPostingsHaveBeenAdded()
        {
            //Arrange
            AccountUnsafe account = new AccountUnsafe();
            account.Post(100.0M);
            account.Post(100.0M);

            //Act
            Decimal balance = account.Balance;

            //Assert
            Assert.AreEqual(200.0M, balance);
        }

        [TestMethod]
        public void Test_Posting_AmountGet_ReturnsCorrectValue_WhenCalled()
        {
            //Arrange
            Posting posting = new Posting()
            {
                Amount = 100.0M,
                CreatedOn = DateTime.MinValue
            };

            //Act
            Decimal amount = posting.Amount;

            //Assert

        }
    }
}
