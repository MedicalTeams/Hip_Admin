using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using HealthInformationProgram.Data.Tables.Reports;

namespace HealthInformationProgram.Data.Mapping.Reports
{
    public class CatalogMap:EntityTypeConfiguration<Catalog>
    {
        public CatalogMap()
        {
            // Primary Key
            this.HasKey(t => t.ItemId);


            // Table & Column Mappings
            this.ToTable("Catalog");
            this.Property(t => t.ItemId).HasColumnName("ItemID");
            this.Property(t => t.Path).HasColumnName("Path");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Type).HasColumnName("Type");
        }
    }
}
