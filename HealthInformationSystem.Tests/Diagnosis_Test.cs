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

        [TestMethod]
        public void Can_CreateDiagnosis()
        {
            var model = new HealthInformationProgram.Data.Tables.lkup_diag();
            var repo = new DiagnosisRepository();
           
            model.diag_abrvn = "tnd";
            model.diag_descn = "test new description 2";
            model.diag_stat = "A";
            model.diag_strt_eff_dt = new DateTime(2015, 11, 30);
            model.diag_end_eff_dt = new DateTime(2016, 12, 01);
            model.rec_creat_dt = DateTime.Now;
            model.rec_creat_user_id_cd = "test user";
            model.rec_updt_dt = DateTime.Now;
            model.rec_updt_user_id_cd = "test user";


            var result = repo.CreateDiagnosis(model);

            Assert.AreEqual(1,result, "Not right number of records affected");
        
        }
    }
}
