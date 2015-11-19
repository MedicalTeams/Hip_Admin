using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Mapping
{
    public class vw_lkup_diagMap : EntityTypeConfiguration<vw_lkup_diag>
    {
        public vw_lkup_diagMap()
        {
            // Primary Key
            this.HasKey(t => new { t.diag_id, t.diag_descn });

            // Properties
            this.Property(t => t.diag_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.diag_descn)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("vw_lkup_diag");
            this.Property(t => t.diag_id).HasColumnName("diag_id");
            this.Property(t => t.diag_descn).HasColumnName("diag_descn");
            this.Property(t => t.user_intrfc_sort_ord).HasColumnName("user_intrfc_sort_ord");
        }
    }
}
