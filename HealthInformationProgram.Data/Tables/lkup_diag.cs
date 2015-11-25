using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data.Tables
{
    public partial class lkup_diag
    {
        public lkup_diag()
        {
            this.lkup_splmtl_diag = new List<lkup_splmtl_diag>();
            this.ov_diag = new List<ov_diag>();
        }

        public decimal diag_id { get; set; }
        public string diag_descn { get; set; }
        public string icd_cd { get; set; }
        public string diag_abrvn { get; set; }
        public Nullable<decimal> user_intrfc_sort_ord { get; set; }
        public string diag_stat { get; set; }
        public System.DateTime diag_strt_eff_dt { get; set; }
        public System.DateTime diag_end_eff_dt { get; set; }
        public System.DateTime rec_creat_dt { get; set; }
        public string rec_creat_user_id_cd { get; set; }
        public System.DateTime rec_updt_dt { get; set; }
        public string rec_updt_user_id_cd { get; set; }
        public virtual ICollection<lkup_splmtl_diag> lkup_splmtl_diag { get; set; }
        public virtual ICollection<ov_diag> ov_diag { get; set; }
    }
}
