using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HealthInformationProgram.Data.Mapping
{
    public class vw_ov_detailsMap : EntityTypeConfiguration<vw_ov_details>
    {
        public vw_ov_detailsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ov_id, t.opd_id, t.dt_of_visit, t.age_in_years, t.faclty_hw_invtry_id, t.staff_mbr_name, t.rec_creat_dt });

            // Properties
            this.Property(t => t.ov_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.opd_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.rvisit_descn)
                .HasMaxLength(10);

            this.Property(t => t.hlth_care_faclty)
                .HasMaxLength(50);

            this.Property(t => t.bnfcry)
                .HasMaxLength(10);

            this.Property(t => t.gndr_descn)
                .HasMaxLength(10);

            this.Property(t => t.age_in_years)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.faclty_hw_invtry_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.mac_addr)
                .HasMaxLength(25);

            this.Property(t => t.aplctn_vrsn)
                .HasMaxLength(25);

            this.Property(t => t.staff_mbr_name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("vw_ov_details");
            this.Property(t => t.ov_id).HasColumnName("ov_id");
            this.Property(t => t.opd_id).HasColumnName("opd_id");
            this.Property(t => t.dt_of_visit).HasColumnName("dt_of_visit");
            this.Property(t => t.rvisit_descn).HasColumnName("rvisit_descn");
            this.Property(t => t.hlth_care_faclty).HasColumnName("hlth_care_faclty");
            this.Property(t => t.bnfcry).HasColumnName("bnfcry");
            this.Property(t => t.gndr_descn).HasColumnName("gndr_descn");
            this.Property(t => t.age_in_years).HasColumnName("age in years");
            this.Property(t => t.faclty_hw_invtry_id).HasColumnName("faclty_hw_invtry_id");
            this.Property(t => t.mac_addr).HasColumnName("mac_addr");
            this.Property(t => t.aplctn_vrsn).HasColumnName("aplctn_vrsn");
            this.Property(t => t.staff_mbr_name).HasColumnName("staff_mbr_name");
            this.Property(t => t.rec_creat_dt).HasColumnName("rec_creat_dt");
        }
    }
}
