using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data.Tables
{
    public partial class vw_raw_data_errs
    {
        public string visit_uuid { get; set; }
        public string visit_json { get; set; }
        public Nullable<decimal> opd_id { get; set; }
        public System.DateTime rec_creat_dt { get; set; }
        public string visit_stat { get; set; }
        public Nullable<int> err_cd { get; set; }
        public string exception_descn { get; set; }
    }
}
