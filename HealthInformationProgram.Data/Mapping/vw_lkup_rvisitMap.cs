using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Mapping
{
    public class vw_lkup_rvisitMap : EntityTypeConfiguration<vw_lkup_rvisit>
    {
        public vw_lkup_rvisitMap()
        {
            // Primary Key
            //this.HasKey(t => new { t.rvisit_id, t.rvisit_descn, t.rvisit_ind });
            this.HasKey(t => new { t.rvisit_id });
            // Properties
            //this.Property(t => t.rvisit_id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //this.Property(t => t.rvisit_descn)
            //    .IsRequired()
            //    .HasMaxLength(10);

            //this.Property(t => t.rvisit_ind)
            //    .IsRequired()
            //    .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("vw_lkup_rvisit");
            this.Property(t => t.rvisit_id).HasColumnName("rvisit_id");
            this.Property(t => t.rvisit_descn).HasColumnName("rvisit_descn");
            this.Property(t => t.rvisit_ind).HasColumnName("rvisit_ind");
            this.Property(t => t.user_intrfc_sort_ord).HasColumnName("user_intrfc_sort_ord");
        }
    }
}
