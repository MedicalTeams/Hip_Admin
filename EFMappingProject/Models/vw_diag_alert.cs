using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data
{
    public partial class vw_diag_alert
    {
        public decimal diag_alert_thrshld_id { get; set; }
        public decimal diag_id { get; set; }
        public decimal case_cnt { get; set; }
        public decimal baseln_multr { get; set; }
    }
}
