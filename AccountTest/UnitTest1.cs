using BIT706_A1_5029996;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AccountTest
{
    [TestClass]
    public class UnitTest1
    {

        Everyday edAcc;
        Omni omniAcc;
        Investment invAcc;


        [TestInitialize] //Initializing Tests for reusable data
        public void Initialize()
        {
            edAcc = new Everyday(532.55);
            omniAcc = new Omni(1223.55, 0.05, -300);
            invAcc = new Investment(5000, 0.05);
        }

        [TestMethod]
        public void EverydayBalance_Updated_By_Deposit_Amount()
        {
            double amount = 100;

            edAcc.Deposit(amount);

            double expected = 632.55;
            double actual = edAcc.balance;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InvestmentBalance_Updated_By_Deposit_Amount()
        {
            int amount = 100;

            invAcc.Deposit(amount);

            double expected = 5350;
            double actual = invAcc.balance;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OmniBalance_Updated_By_Deposit_Amount()
        {
            int amount = 100;

            omniAcc.Deposit(amount);

            double expected = 1384.7275;
            double actual = omniAcc.balance;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EverydayBalance_Updated_By_Withdrawal_Amount()
        {
            double amount = 100;

            edAcc.Withdrawal(amount);

            double expected = 432.55;
            double actual = edAcc.balance;

            Assert.AreEqual(expected, actual); //They are equal???
        }

        [TestMethod]
        public void OmniBalance_Updated_By_Withdrawal_Amount()
        {
            int amount = 100;

            omniAcc.Withdrawal(amount);

            double expected = 1184.7275;
            double actual = omniAcc.balance;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InvestmentBalance_Updated_By_Withdrawal_Amount()
        {
            int amount = 100;

            invAcc.Withdrawal(amount);

            double expected = 5150;
            double actual = invAcc.balance;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EverydayBalance_Withdrawal_Amount_Too_High_Error()
        {
            double amount = 600;

            edAcc.Withdrawal(amount);

            double expected = 532.55;
            double actual = edAcc.balance;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InvestmentBalance_Withdrawal_Amount_Too_High_Fee_Charge()
        {
            double amount = 6000;

            invAcc.Withdrawal(amount);

            double expected = 5240;
            double actual = invAcc.balance;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OmniBalance_Withdrawal_Amount_Under_Overdraft()
        {
            double amount = 1300;

            omniAcc.Withdrawal(amount);

            double expected = -15.2725;
            double actual = omniAcc.balance;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OmniBalance_Withdrawal_Amount_Over_Overdraft_Fee_Charge()
        {
            double amount = 3000;

            omniAcc.Withdrawal(amount);

            double expected = 1274.7275;
            double actual = omniAcc.balance;

            Assert.AreEqual(expected, actual);
        }
    }
}
