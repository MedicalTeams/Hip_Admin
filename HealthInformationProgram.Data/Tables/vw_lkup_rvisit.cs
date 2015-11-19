using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data.Tables
{
    public partial class vw_lkup_rvisit
    {
        public decimal rvisit_id { get; set; }
        public string rvisit_descn { get; set; }
        public string rvisit_ind { get; set; }
        public Nullable<decimal> user_intrfc_sort_ord { get; set; }
    }
}
