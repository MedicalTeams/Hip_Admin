using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Data
{
    public class BeneficiaryData:BaseHipData
    {
        public List<Models.BeneficiaryModel> GetAll()
        {
            var repo = new Data.Repositories.LookupBeneficiaryTypeRepository();
            var beneficiaryList = new List<Models.BeneficiaryModel>();

            var dataList = repo.GetAll();
            foreach (var item in dataList)
            {
                var beneficiary = new Models.BeneficiaryModel();

                beneficiary.BeneficiaryId = GetDataValue(item.bnfcry_id);
                beneficiary.BeneficiaryType = GetDataValue(item.bnfcry);
                beneficiary.SortOrder = GetDataValue(item.user_intrfc_sort_ord);

                beneficiaryList.Add(beneficiary);
            }

            return beneficiaryList;
        }
    }
}