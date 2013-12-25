using Algorithm_Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for SerarchTest and is intended
    ///to contain all SerarchTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SerarchTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for FindElementTwo
        ///</summary>
        [TestMethod()]
        public void FindElementTwoTest()
        {
            Serarch target = new Serarch(); // TODO: Initialize to an appropriate value
            int[,] matrix = { { 1, 2, 3,4,5 }, { 6,7,8,9,10}, { 11,12,13,14,15},{16,17,18,19,20},{21,22,23,24,25} }; 
            int x = 14; // TODO: Initialize to an appropriate value
            Serarch.Coordinate expected = null; // TODO: Initialize to an appropriate value
            Serarch.Coordinate actual;
            actual = target.FindElementTwo(matrix, x);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GetIncreasingSequence
        ///</summary>
        ///
        [TestMethod()]
        public void GetIncreasingSequenceTest()
        {
            
            //(65, 100) (70, 150) (56, 90) (75, 190) (60, 95) (68, 110)
            Serarch target = new Serarch(); // TODO: Initialize to an appropriate value
            List<Serarch.HtWt> items = new List<Serarch.HtWt>();
            items.Add(new Serarch.HtWt(65, 100));
            items.Add(new Serarch.HtWt(70, 150));
            items.Add(new Serarch.HtWt(56, 90));
            items.Add(new Serarch.HtWt(75, 190));
            items.Add(new Serarch.HtWt(60, 95));
            items.Add(new Serarch.HtWt(68, 110));

            List<Serarch.HtWt> expected = null; // TODO: Initialize to an appropriate value
            List<Serarch.HtWt> actual;
            actual = target.GetIncreasingSequence(items);
            Assert.AreEqual(expected, actual);
            
        }
    }
}
