using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data.Tables
{
    public partial class ov_diag
    {
        public decimal ov_diag_id { get; set; }
        public decimal ov_id { get; set; }
        public Nullable<decimal> splmtl_diag_id { get; set; }
        public decimal diag_id { get; set; }
        public Nullable<decimal> cntct_trmnt_cnt { get; set; }
        public Nullable<decimal> splmtl_diag_cat_id { get; set; }
        public string oth_diag_descn { get; set; }
        public string oth_splmtl_diag_descn { get; set; }
        public System.DateTime rec_creat_dt { get; set; }
        public string rec_creat_user_id_cd { get; set; }
        public System.DateTime rec_updt_dt { get; set; }
        public string rec_updt_user_id_cd { get; set; }
    }
}
