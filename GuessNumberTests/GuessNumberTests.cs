using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuessNumberNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberNS.Tests
{
    [TestClass()]
    public class GuessNumberTests
    {
        [TestMethod]
        public void GuessNumber_TestValidInput()
        {
            GuessNumber gn = new();

            using StringReader sr = new("50");

            Console.SetIn(sr);

            gn.IsInputValid();

            Assert.AreEqual(50, gn.GetUserNumber());
        }

        [TestMethod]
        public void GuessNumber_TestInvalidInput()
        {
            GuessNumber gn = new();

            using StringReader sr = new("abc\n1");

            Console.SetIn(sr);

            gn.IsInputValid();

            Assert.AreEqual(1, gn.GetUserNumber());
        }

        [TestMethod]
        public void GuessNumber_IsApplicationNumberBetweenZeroAnd100_ReturnTrue()
        {
            GuessNumber gn = new();

            Assert.IsTrue(gn.GetApplicationNumber() > 0 && gn.GetApplicationNumber() <= 100);
        }

        [TestMethod]
        public void GuessNumber_IsUserNumberNumberBetweenZeroAnd100_ReturnTrue()
        {
            GuessNumber gn = new();

            using StringReader sr = new("1");

            Console.SetIn(sr);

            gn.IsInputValid();

            Assert.IsTrue(gn.GetUserNumber() > 0 && gn.GetUserNumber() <= 100);
        }

        [TestMethod]
        public void GuessNumber_IsGameFinishIf2NumbersAreEqualsTrue()
        {
            GuessNumber gn = new();
            int appNumber = gn.GetApplicationNumber();
            using StringReader sr = new(appNumber.ToString());

            Console.SetIn(sr);

            gn.IsInputValid();
            bool gameStatus = gn.IsGameFinish();

            if (gn.GetUserNumber() == appNumber)
            {
                Assert.IsTrue(gameStatus);
            }
        }

        [TestMethod]
        public void GuessNumber_IsGameFinishIf2NumbersAreNotEqualsFalse()
        {
            GuessNumber gn = new();
            int appNumber = gn.GetApplicationNumber() + 1;
            int userNumber;

            if(appNumber != 100)
            {
                userNumber = appNumber + 1;
            }
            else
            {
                userNumber = appNumber - 1;
            }

            using StringReader sr = new(userNumber.ToString());

            Console.SetIn(sr);

            gn.IsInputValid();

            bool gameStatus = gn.IsGameFinish();

            if (gn.GetUserNumber() != appNumber)
            {
                Assert.IsFalse(gameStatus);
            }
        }
    }
}