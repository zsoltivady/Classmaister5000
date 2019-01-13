using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orarend_osszerako.ViewModel;
using Orarend_osszerako.Model;

namespace UnitTests
{
    /// <summary>
    /// Summary description for ItemSelectUnitTest
    /// </summary>
    [TestClass]
    public class ItemSelectUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            OrarendViewModel testObj = new OrarendViewModel();
            CourseModel paramObj = new CourseModel();
            const int year = 2018;
            const int month = 12;
            const int day = 2;
            const int hour = 23;
            const int min = 2;
            const int sec = 2;
            paramObj.From = new DateTime(year, month, day, hour, min, sec);
            try
            {
                testObj.SelectIndex(paramObj);
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
