using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data
{
    public partial class curr_sys_info
    {
        public decimal curr_sys_id { get; set; }
        public string itm_descn { get; set; }
        public string itm_vrsn { get; set; }
        public Nullable<System.DateTime> dt_of_rlse { get; set; }
        public Nullable<System.DateTime> last_exception_rpt { get; set; }
        public Nullable<System.DateTime> last_constant_update { get; set; }
    }
}
