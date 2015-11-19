using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data.Tables
{
    public partial class lkup_bnfcry
    {
        public decimal bnfcry_id { get; set; }
        public string bnfcry { get; set; }
        public Nullable<decimal> user_intrfc_sort_ord { get; set; }
        public System.DateTime rec_creat_dt { get; set; }
        public string rec_creat_user_id_cd { get; set; }
        public System.DateTime rec_updt_dt { get; set; }
        public string rec_updt_user_id_cd { get; set; }
    }
}
