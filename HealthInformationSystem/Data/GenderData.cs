using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Data
{
    public class GenderData : BaseHipData
    {
        public List<Models.GenderModel> GetAll()
        {
            var genderList = new List<Models.GenderModel>();
            var repo = new Data.Repositories.LookupGenderRepository();
            var dataList = repo.GetAll();

            foreach (var gender in dataList)
            {
                var g = new Models.GenderModel();

                g.GenderCode = gender.gndr_cd;
                g.GenderDescription = gender.gndr_descn;
                g.GenderId = GetDataValue(gender.gndr_id);
                g.SortOrder = GetDataValue(gender.user_intrfc_sort_ord);

                genderList.Add(g);
            }
            return genderList;

        }

        public Models.GenderModel Get(decimal id)
        {
            var genderList = new List<Models.GenderModel>();
            var repo = new Data.Repositories.LookupGenderRepository();
            var genderData = repo.GetGender(id);

            var gender = new Models.GenderModel();

            gender.GenderCode = genderData.gndr_cd;
            gender.GenderDescription = genderData.gndr_descn;
            gender.GenderId = GetDataValue(genderData.gndr_id);
            gender.SortOrder = GetDataValue(genderData.user_intrfc_sort_ord);


            return gender;
        }
    }
}