using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data
{
    public partial class vw_lkup_injury_loc_diag
    {
        public int diag_id { get; set; }
        public decimal splmtl_diag_cat_id { get; set; }
        public string splmtl_diag_cat { get; set; }
        public Nullable<decimal> user_intrfc_sort_ord { get; set; }
    }
}
