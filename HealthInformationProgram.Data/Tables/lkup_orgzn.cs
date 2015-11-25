using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data.Tables
{
    public partial class lkup_orgzn
    {
        public lkup_orgzn()
        {
            this.lkup_faclty = new List<lkup_faclty>();
        }

        public decimal orgzn_id { get; set; }
        public string orgzn { get; set; }
        public Nullable<decimal> user_intrfc_sort_ord { get; set; }
        public string orgzn_stat { get; set; }
        public System.DateTime orgzn_strt_eff_dt { get; set; }
        public System.DateTime orgzn_end_eff_dt { get; set; }
        public System.DateTime rec_creat_dt { get; set; }
        public string rec_creat_user_id_cd { get; set; }
        public System.DateTime rec_updt_dt { get; set; }
        public string rec_updt_user_id_cd { get; set; }
        public virtual ICollection<lkup_faclty> lkup_faclty { get; set; }
    }
}
