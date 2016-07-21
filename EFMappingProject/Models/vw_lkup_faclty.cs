using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data
{
    public partial class vw_lkup_faclty
    {
        public decimal faclty_id { get; set; }
        public string hlth_care_faclty { get; set; }
        public string setlmt { get; set; }
        public string cntry { get; set; }
        public string rgn { get; set; }
        public Nullable<decimal> user_intrfc_sort_ord { get; set; }
    }
}
