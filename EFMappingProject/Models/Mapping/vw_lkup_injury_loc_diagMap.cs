using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HealthInformationProgram.Data.Mapping
{
    public class vw_lkup_injury_loc_diagMap : EntityTypeConfiguration<vw_lkup_injury_loc_diag>
    {
        public vw_lkup_injury_loc_diagMap()
        {
            // Primary Key
            this.HasKey(t => new { t.diag_id, t.splmtl_diag_cat_id, t.splmtl_diag_cat });

            // Properties
            this.Property(t => t.diag_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.splmtl_diag_cat_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.splmtl_diag_cat)
                .IsRequired()
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("vw_lkup_injury_loc_diag");
            this.Property(t => t.diag_id).HasColumnName("diag_id");
            this.Property(t => t.splmtl_diag_cat_id).HasColumnName("splmtl_diag_cat_id");
            this.Property(t => t.splmtl_diag_cat).HasColumnName("splmtl_diag_cat");
            this.Property(t => t.user_intrfc_sort_ord).HasColumnName("user_intrfc_sort_ord");
        }
    }
}
