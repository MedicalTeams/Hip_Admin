using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data.Tables
{
    public partial class vw_ov_details
    {
        public decimal ov_id { get; set; }
        public decimal opd_id { get; set; }
        public System.DateTime dt_of_visit { get; set; }
        public string rvisit_descn { get; set; }
        public string hlth_care_faclty { get; set; }
        public string bnfcry { get; set; }
        public string gndr_descn { get; set; }
        public decimal age_in_years { get; set; }
        public decimal faclty_hw_invtry_id { get; set; }
        public string mac_addr { get; set; }
        public string aplctn_vrsn { get; set; }
        public string staff_mbr_name { get; set; }
        public System.DateTime rec_creat_dt { get; set; }
    }
}
