using System;
using HealthInformationProgram.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HealthInformationProgram.Tests
{
    [TestClass]
    public class FacilityHardwareInventory_Test
    {
        [TestMethod]
        public void TesCan_GetAll()
        {
            var repo = new FacilityHardwareInventoryRespository();
            var facilityHardwareList = repo.GetAll();

            Assert.IsNotNull(facilityHardwareList);

        }
    }
}
