using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data
{
    public partial class lkup_faclty
    {
        public lkup_faclty()
        {
            this.faclty_hw_invtry = new List<faclty_hw_invtry>();
            this.ovs = new List<ov>();
        }

        public decimal faclty_id { get; set; }
        public string hlth_care_faclty { get; set; }
        public string hlth_care_faclty_lvl { get; set; }
        public string hlth_coordtr { get; set; }
        public string setlmt { get; set; }
        public string cntry { get; set; }
        public string rgn { get; set; }
        public decimal orgzn_id { get; set; }
        public string faclty_stat { get; set; }
        public System.DateTime faclty_strt_eff_dt { get; set; }
        public System.DateTime faclty_end_eff_dt { get; set; }
        public Nullable<decimal> user_intrfc_sort_ord { get; set; }
        public Nullable<decimal> longtd { get; set; }
        public Nullable<decimal> lattd { get; set; }
        public System.DateTime rec_creat_dt { get; set; }
        public string rec_creat_user_id_cd { get; set; }
        public System.DateTime rec_updt_dt { get; set; }
        public string rec_updt_user_id_cd { get; set; }
        public virtual ICollection<faclty_hw_invtry> faclty_hw_invtry { get; set; }
        public virtual ICollection<ov> ovs { get; set; }
        public virtual lkup_orgzn lkup_orgzn { get; set; }
    }
}
