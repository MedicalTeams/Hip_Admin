using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HealthInformationProgram.Tests
{
    [TestClass]
    public class DataConnection_Test
    {
        [TestMethod]
        public void Can_Get_Connection()
        {
            var config = new HealthInformationProgram.Data.Configuration();
            var conn = config.GetConnection("SqlAzure_Clinic");

            Assert.IsTrue(conn != string.Empty, "connection string empty");
        }
    }
}
