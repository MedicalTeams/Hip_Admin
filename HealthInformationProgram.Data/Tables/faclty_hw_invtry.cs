using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data.Tables
{
    public partial class faclty_hw_invtry
    {
        public decimal faclty_hw_invtry_id { get; set; }
        public decimal faclty_id { get; set; }
        public string itm_descn { get; set; }
        public string mac_addr { get; set; }
        public string aplctn_vrsn { get; set; }
        public decimal hw_stat { get; set; }
        public System.DateTime rec_creat_dt { get; set; }
        public string rec_creat_user_id_cd { get; set; }
        public System.DateTime rec_updt_dt { get; set; }
        public string rec_updt_user_id_cd { get; set; }
    }
}
