using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class CurrentSystemInformationModel
    {
        public string CurrentSystemId { get; set; }
        public string ItemDescription { get; set; }
        public string ItemVersion { get; set; }
        public string ReleaseDate { get; set; }
    }
}