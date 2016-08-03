using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HealthInformationProgram.Data.Repositories.Reports;
namespace HealthInformationProgram.Tests.Reports
{
    /// <summary>
    /// Summary description for Catalog_Test
    /// </summary>
    [TestClass]
    public class Catalog_Test
    {
        public Catalog_Test()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Can_Get_Report_List()
        {
            var reports = new CatalogRepository();
            var result= reports.GetAllReports();

            Assert.IsNotNull(result, "Report object is null");
            Assert.IsTrue(result.Count > 0, "Report list is empty");
            Console.WriteLine("Report count: " + result.Count);
        }
    }
}
