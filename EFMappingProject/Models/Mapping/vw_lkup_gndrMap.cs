using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HealthInformationProgram.Data.Mapping
{
    public class vw_lkup_gndrMap : EntityTypeConfiguration<vw_lkup_gndr>
    {
        public vw_lkup_gndrMap()
        {
            // Primary Key
            this.HasKey(t => new { t.gndr_id, t.gndr_descn, t.gndr_cd });

            // Properties
            this.Property(t => t.gndr_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.gndr_descn)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.gndr_cd)
                .IsRequired()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("vw_lkup_gndr");
            this.Property(t => t.gndr_id).HasColumnName("gndr_id");
            this.Property(t => t.gndr_descn).HasColumnName("gndr_descn");
            this.Property(t => t.gndr_cd).HasColumnName("gndr_cd");
        }
    }
}
