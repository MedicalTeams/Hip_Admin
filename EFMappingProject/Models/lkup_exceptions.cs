using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data
{
    public partial class lkup_exceptions
    {
        public decimal err_cd { get; set; }
        public string exception_descn { get; set; }
        public string exception_comment { get; set; }
        public Nullable<decimal> user_intrfc_sort_ord { get; set; }
        public System.DateTime rec_creat_dt { get; set; }
        public string rec_creat_user_id_cd { get; set; }
        public System.DateTime rec_updt_dt { get; set; }
        public string rec_updt_user_id_cd { get; set; }
    }
}
