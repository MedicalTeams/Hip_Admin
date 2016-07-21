using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data
{
    public partial class diag_alert_thrshld
    {
        public decimal diag_alert_thrshld_id { get; set; }
        public decimal diag_id { get; set; }
        public decimal case_cnt { get; set; }
        public decimal baseln_multr { get; set; }
        public System.DateTime rec_creat_dt { get; set; }
        public string rec_creat_user_id_cd { get; set; }
        public System.DateTime rec_updt_dt { get; set; }
        public string rec_updt_user_id_cd { get; set; }
    }
}
