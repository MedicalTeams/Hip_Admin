using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInformationProgram.Data.Tables.Reports
{
    public partial class Catalog
    {
        public Guid ItemId { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }

    }
}
