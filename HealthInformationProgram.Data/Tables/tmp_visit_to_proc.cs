using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data.Tables
{
    public partial class tmp_visit_to_proc
    {
        public string visit_uuid { get; set; }
        public decimal bnfcry_id { get; set; }
        public decimal faclty_id { get; set; }
        public decimal faclty_hw_invtry_id { get; set; }
        public decimal gndr_id { get; set; }
        public Nullable<decimal> splmtl_diag_cat_id { get; set; }
        public decimal rvisit_id { get; set; }
        public Nullable<decimal> opd_id { get; set; }
        public decimal infnt_age_mos { get; set; }
        public string staff_mbr_name { get; set; }
        public Nullable<decimal> cntct_trmnt_cnt { get; set; }
        public System.DateTime dt_of_visit { get; set; }
        public decimal diag_id { get; set; }
        public Nullable<decimal> splmtl_diag_id { get; set; }
        public string oth_diag_descn { get; set; }
        public string oth_splmtl_diag_descn { get; set; }
        public string proc_stat { get; set; }
        public Nullable<int> err_cd { get; set; }
        public System.DateTime rec_creat_dt { get; set; }
        public string rec_creat_user_id_cd { get; set; }
        public System.DateTime rec_updt_dt { get; set; }
        public string rec_updt_user_id_cd { get; set; }
        public decimal visit_to_proc_id { get; set; }
    }
}
