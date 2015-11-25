using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data.Tables
{
    public partial class vw_lkup_base_splmtl_diag
    {
        public decimal diag_id { get; set; }
        public decimal splmtl_diag_id { get; set; }
        public string splmtl_diag_descn { get; set; }
        public Nullable<decimal> user_intrfc_sort_ord { get; set; }
    }
}
