using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data.Tables
{
    public partial class vw_lkup_bnfcry
    {
        public decimal bnfcry_id { get; set; }
        public string bnfcry { get; set; }
        public Nullable<decimal> user_intrfc_sort_ord { get; set; }
    }
}
