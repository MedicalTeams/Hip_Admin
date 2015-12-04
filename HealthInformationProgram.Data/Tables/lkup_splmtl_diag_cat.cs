using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthInformationProgram.Data.Tables
{
    public partial class lkup_splmtl_diag_cat
    {
        public lkup_splmtl_diag_cat()
        {
            this.ov_diag = new List<ov_diag>();
        }

        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public Nullable<decimal> splmtl_diag_cat_id { get; set; }
        public string splmtl_diag_cat { get; set; }
        public Nullable<decimal> user_intrfc_sort_ord { get; set; }
        public string splmtl_diag_cat_stat { get; set; }
        public System.DateTime splmtl_diag_cat_strt_eff_dt { get; set; }
        public System.DateTime splmtl_diag_cat_end_eff_dt { get; set; }
        public System.DateTime rec_creat_dt { get; set; }
        public string rec_creat_user_id_cd { get; set; }
        public System.DateTime rec_updt_dt { get; set; }
        public string rec_updt_user_id_cd { get; set; }
        public virtual ICollection<ov_diag> ov_diag { get; set; }
    }
}
