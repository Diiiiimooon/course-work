using Base_Hotel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest4
    {
        public void Policy(uint minimumLength, uint maximumLength, bool requiresUppercase, bool requiresLowercase, bool requiresNumber, bool requiresSpecialCharacter, uint passwordExpirationDays)
        {
            Policy_password.MinimumLength = minimumLength;
            Policy_password.MaximumLength = maximumLength;
            Policy_password.RequiresUppercase = requiresUppercase;
            Policy_password.RequiresLowercase = requiresLowercase;
            Policy_password.RequiresNumber = requiresNumber;
            Policy_password.RequiresSpecialCharacter = requiresSpecialCharacter;
            Policy_password.PasswordExpirationDays = passwordExpirationDays;
        }
        [TestMethod]
        public void TestMethodPolicy1()
        {
            Policy(8, 15, true, true,false,false,90);
            Assert.AreEqual(true, Policy_password.IsValid("adminNNw"));
            Assert.AreEqual(false, Policy_password.IsValid("adminNN"));
            Assert.AreEqual(false, Policy_password.IsValid("!adminNN"));
            Assert.AreEqual(false, Policy_password.IsValid("1dminNN"));
        }
        [TestMethod]
        public void TestMethodPolicy2()
        {
            Policy(3, 7, true, false, false, false, 90);
            Assert.AreEqual(true, Policy_password.IsValid("AAGG"));
            Assert.AreEqual(false, Policy_password.IsValid("A"));
            Assert.AreEqual(false, Policy_password.IsValid("!A1a"));
            Assert.AreEqual(false, Policy_password.IsValid("1!dminNN"));
        }
        [TestMethod]
        public void TestMethodPolicy3()
        {
            Policy(8, 15, false, true, false, false, 90);
            Assert.AreEqual(true, Policy_password.IsValid("aasdhdhsdsd"));
            Assert.AreEqual(false, Policy_password.IsValid("dsadasds12"));
            Assert.AreEqual(false, Policy_password.IsValid("!ddsdA"));
            Assert.AreEqual(false, Policy_password.IsValid("1!adafdfdsA"));
        }
        [TestMethod]
        public void TestMethodPolicy4()
        {
            Policy(8, 15, false, false, true, false, 90);
            Assert.AreEqual(true, Policy_password.IsValid("123445678"));
            Assert.AreEqual(false, Policy_password.IsValid("!@#qwerty1"));
            Assert.AreEqual(false, Policy_password.IsValid("!addasaAA@"));
            Assert.AreEqual(false, Policy_password.IsValid("1!adadsad"));
        }
        [TestMethod]
        public void TestMethodPolicy5()
        {
            Policy(4, 10, false, false, true, true, 90);
            Assert.AreEqual(true, Policy_password.IsValid("12!34@56#"));
            Assert.AreEqual(false, Policy_password.IsValid("adcd23@"));
        }
        [TestMethod]
        public void TestMethodPolicy6()
        {
            Policy(8, 15, true, true, true, true, 90);
            Assert.AreEqual(true, Policy_password.IsValid("Aabcd84!#"));
            Assert.AreEqual(false, Policy_password.IsValid("adminNN"));
            Assert.AreEqual(false, Policy_password.IsValid("!adminNN"));
            Assert.AreEqual(true, Policy_password.IsValid("1!dminNN"));
        }
        [TestMethod]
        public void TestMethodPolicy7()
        {
            Policy(1, 5, true, true, true, true, 90);
            Assert.AreEqual(true, Policy_password.IsValid("A1a!"));
            Assert.AreEqual(false, Policy_password.IsValid("adminNN"));
            Assert.AreEqual(false, Policy_password.IsValid("!adminNN"));
            Assert.AreEqual(false, Policy_password.IsValid("1dminNN"));
        }
        [TestMethod]
        public void TestMethodPolicy8()
        {
            Policy(8, 15, false, false, true, false, 90);
            Assert.AreEqual(true, Policy_password.IsValid("123456789"));
            Assert.AreEqual(false, Policy_password.IsValid("adminNN"));
            Assert.AreEqual(false, Policy_password.IsValid("!adminNN"));
            Assert.AreEqual(false, Policy_password.IsValid("1dminNN"));
        }

    }
}

