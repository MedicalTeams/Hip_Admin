using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data
{
    public partial class raw_visit
    {
        public string visit_uuid { get; set; }
        public string visit_json { get; set; }
        public System.DateTime rec_creat_dt { get; set; }
        public string rec_creat_user_id_cd { get; set; }
        public System.DateTime rec_updt_dt { get; set; }
        public string rec_updt_user_id_cd { get; set; }
        public string visit_stat { get; set; }
        public Nullable<int> err_cd { get; set; }
    }
}
