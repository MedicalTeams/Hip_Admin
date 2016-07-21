using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HealthInformationProgram.Data.Mapping
{
    public class vw_lkup_facltyMap : EntityTypeConfiguration<vw_lkup_faclty>
    {
        public vw_lkup_facltyMap()
        {
            // Primary Key
            this.HasKey(t => new { t.faclty_id, t.hlth_care_faclty, t.setlmt, t.cntry, t.rgn });

            // Properties
            this.Property(t => t.faclty_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.hlth_care_faclty)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.setlmt)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.cntry)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.rgn)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vw_lkup_faclty");
            this.Property(t => t.faclty_id).HasColumnName("faclty_id");
            this.Property(t => t.hlth_care_faclty).HasColumnName("hlth_care_faclty");
            this.Property(t => t.setlmt).HasColumnName("setlmt");
            this.Property(t => t.cntry).HasColumnName("cntry");
            this.Property(t => t.rgn).HasColumnName("rgn");
            this.Property(t => t.user_intrfc_sort_ord).HasColumnName("user_intrfc_sort_ord");
        }
    }
}
