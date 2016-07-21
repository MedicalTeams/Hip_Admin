using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data
{
    public partial class ov
    {
        public ov()
        {
            this.ov_diag = new List<ov_diag>();
        }

        public decimal faclty_id { get; set; }
        public decimal gndr_id { get; set; }
        public decimal bnfcry_id { get; set; }
        public decimal opd_id { get; set; }
        public decimal ov_id { get; set; }
        public decimal faclty_hw_invtry_id { get; set; }
        public System.DateTime dt_of_visit { get; set; }
        public string staff_mbr_name { get; set; }
        public string refl_in_ind { get; set; }
        public string refl_out_ind { get; set; }
        public decimal infnt_age_mos { get; set; }
        public decimal rvisit_id { get; set; }
        public System.DateTime rec_creat_dt { get; set; }
        public string rec_creat_user_id_cd { get; set; }
        public System.DateTime rec_updt_dt { get; set; }
        public string rec_updt_user_id_cd { get; set; }
        public virtual faclty_hw_invtry faclty_hw_invtry { get; set; }
        public virtual lkup_bnfcry lkup_bnfcry { get; set; }
        public virtual lkup_faclty lkup_faclty { get; set; }
        public virtual lkup_gndr lkup_gndr { get; set; }
        public virtual ICollection<ov_diag> ov_diag { get; set; }
    }
}
