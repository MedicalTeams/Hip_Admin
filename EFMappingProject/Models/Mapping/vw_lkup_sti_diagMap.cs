using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HealthInformationProgram.Data.Mapping
{
    public class vw_lkup_sti_diagMap : EntityTypeConfiguration<vw_lkup_sti_diag>
    {
        public vw_lkup_sti_diagMap()
        {
            // Primary Key
            this.HasKey(t => new { t.diag_id, t.splmtl_diag_id, t.splmtl_diag_descn });

            // Properties
            this.Property(t => t.diag_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.splmtl_diag_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.splmtl_diag_descn)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("vw_lkup_sti_diag");
            this.Property(t => t.diag_id).HasColumnName("diag_id");
            this.Property(t => t.splmtl_diag_id).HasColumnName("splmtl_diag_id");
            this.Property(t => t.splmtl_diag_descn).HasColumnName("splmtl_diag_descn");
            this.Property(t => t.user_intrfc_sort_ord).HasColumnName("user_intrfc_sort_ord");
        }
    }
}
