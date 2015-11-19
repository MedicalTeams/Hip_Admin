using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Mapping
{
    public class vw_lkup_bnfcryMap : EntityTypeConfiguration<vw_lkup_bnfcry>
    {
        public vw_lkup_bnfcryMap()
        {
            // Primary Key
            this.HasKey(t => new { t.bnfcry_id, t.bnfcry });

            // Properties
            this.Property(t => t.bnfcry_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.bnfcry)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("vw_lkup_bnfcry");
            this.Property(t => t.bnfcry_id).HasColumnName("bnfcry_id");
            this.Property(t => t.bnfcry).HasColumnName("bnfcry");
            this.Property(t => t.user_intrfc_sort_ord).HasColumnName("user_intrfc_sort_ord");
        }
    }
}
