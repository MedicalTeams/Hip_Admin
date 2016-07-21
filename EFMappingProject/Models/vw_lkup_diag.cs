using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data
{
    public partial class vw_lkup_diag
    {
        public decimal diag_id { get; set; }
        public string diag_descn { get; set; }
        public Nullable<decimal> user_intrfc_sort_ord { get; set; }
    }
}
