using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data.Tables
{
    public partial class faclty_hw_invtry
    {
        public faclty_hw_invtry()
        {
            this.ovs = new List<ov>();
        }

        public decimal faclty_hw_invtry_id { get; set; }
        public decimal faclty_id { get; set; }
        public string itm_descn { get; set; }
        public string mac_addr { get; set; }
        public string aplctn_vrsn { get; set; }
        public string hw_stat { get; set; }
        public System.DateTime rec_creat_dt { get; set; }
        public string rec_creat_user_id_cd { get; set; }
        public System.DateTime rec_updt_dt { get; set; }
        public string rec_updt_user_id_cd { get; set; }
        public virtual ICollection<ov> ovs { get; set; }
        public virtual lkup_faclty lkup_faclty { get; set; }
    }
}
