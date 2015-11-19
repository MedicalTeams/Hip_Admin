using System;
using HealthInformationProgram.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HealthInformationProgram.Tests
{
    [TestClass]
    public class Diagnosis_Test
    {
        [TestMethod]
        public void Can_GetAllDiagnosis()
        {
            var repo = new DiagnosisRepository();
            var diagnosisList = repo.GetAll();

            Assert.IsNotNull(diagnosisList);
            Assert.IsTrue(diagnosisList.Count > 0);
        }
    }
}
