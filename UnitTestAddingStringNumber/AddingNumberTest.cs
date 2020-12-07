using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddingStringNumber;
using System.Collections.Generic;

namespace UnitTestAddingStringNumber
{
    [TestClass]
    public class AddingNumberTest
    {

        [TestMethod]
        public void addBlankstringShouldReturnZero()
        {
            string str = "";
            if (string.IsNullOrEmpty(str))
            {
                int result = ManageData.Add(new List<int>());
                Assert.AreEqual(0, 0);
            }
        }

        [TestMethod]
        public void validateNumberToAdd()
        {
            string str = @"+22\n33,41\n10";
            string str2 = @"1;\n10";
            bool result = ManageData.validateNumberFormat(str);
            bool result2 = ManageData.validateNumberFormat(str2);
            Assert.IsTrue(result);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void ExtractNumberToAdd()
        {
            string str = @"1\n10";
            string str2 = @"+22\n33,41\n10";

            List<int> result = ManageData.extractAddingNumber(str);
            List<int> result2 = ManageData.extractAddingNumber(str2);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(4, result2.Count);
        }
        [TestMethod]
        public void addStringNumberBySettingDelimiter()
        {
            string str = @"//;\n1;2;3";
            
            List<int> numbers = ManageData.extractAddingNumber(str);
            int result = ManageData.Add(numbers);
            Assert.AreEqual(6, result);
        }
        [TestMethod]
        public void addStringNumberWithDelimiter()
        {
            string str = "22;10;3";

            var numbers = ManageData.extractAddingNumber(str);
            int result = ManageData.Add(numbers);
            Assert.AreEqual(35, result);
        }
        [TestMethod]
        public void addStringNumberWithNewLineDelimiter()
        {
            string str = @"1\n10;+3;2\n6";

            var numbers = ManageData.extractAddingNumber(str);
            int result = ManageData.Add(numbers);
            Assert.AreEqual(22, result);
        }


    }
}
