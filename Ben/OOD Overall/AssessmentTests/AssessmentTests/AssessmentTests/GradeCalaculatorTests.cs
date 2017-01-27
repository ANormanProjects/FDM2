using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application;

namespace AssessmentTests
{
    [TestClass]
    public class GradeCalaculatorTests
    {
        private GradeCalculator calc;

        [TestInitialize]
        public void SetUp()
        {
            calc = new GradeCalculator();
        }

        [TestMethod]
        public void test_GetClassification_ReturnsStringFail_IfInputDoubleIsLessThan75()
        {
            double mark = 70.0;
            string result = calc.getClassification(mark);
            Assert.AreEqual("fail", result);
        }

        [TestMethod]
        public void test_GetClassification_ReturnsStringPass_IfInputDoubleIsGreaterThanOrEqualTo75AndLessThan80()
        {
            double mark = 76;
            String result = calc.getClassification(mark);
            Assert.AreEqual("pass", result);
        }

        [TestMethod]
        public void test_GetClassification_ReturnsStringMerit_IfInputDoubleIsGreaterThanOrEqualTo80AndLessThan90()
        {
            double mark = 82;
            String result = calc.getClassification(mark);
            Assert.AreEqual("merit", result);
        }

        [TestMethod]
        public void test_GetClassification_ReturnsStringDistinction_IfInputDoubleIsGreaterThanOrEqualTo90()
        {
            double mark = 92;
            String result = calc.getClassification(mark);
            Assert.AreEqual("distinction", result);
        }
    }
}
