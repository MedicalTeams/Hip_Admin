using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Mapping
{
    public class ovMap : EntityTypeConfiguration<ov>
    {
        public ovMap()
        {
            // Primary Key
            this.HasKey(t => t.ov_id);

            // Properties
            this.Property(t => t.staff_mbr_name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.refl_in_ind)
                .HasMaxLength(1);

            this.Property(t => t.refl_out_ind)
                .HasMaxLength(1);

            this.Property(t => t.rec_creat_user_id_cd)
                   .IsRequired()
                   .HasMaxLength(100);

            this.Property(t => t.rec_updt_user_id_cd)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ov");
            this.Property(t => t.faclty_id).HasColumnName("faclty_id");
            this.Property(t => t.gndr_id).HasColumnName("gndr_id");
            this.Property(t => t.bnfcry_id).HasColumnName("bnfcry_id");
            this.Property(t => t.opd_id).HasColumnName("opd_id");
            this.Property(t => t.ov_id).HasColumnName("ov_id");
            this.Property(t => t.faclty_hw_invtry_id).HasColumnName("faclty_hw_invtry_id");
            this.Property(t => t.dt_of_visit).HasColumnName("dt_of_visit");
            this.Property(t => t.staff_mbr_name).HasColumnName("staff_mbr_name");
            this.Property(t => t.refl_in_ind).HasColumnName("refl_in_ind");
            this.Property(t => t.refl_out_ind).HasColumnName("refl_out_ind");
            this.Property(t => t.infnt_age_mos).HasColumnName("age_years_low");
            this.Property(t => t.rvisit_id).HasColumnName("rvisit_id");
            this.Property(t => t.rec_creat_dt).HasColumnName("rec_creat_dt");
            this.Property(t => t.rec_creat_user_id_cd).HasColumnName("rec_creat_user_id_cd");
            this.Property(t => t.rec_updt_dt).HasColumnName("rec_updt_dt");
            this.Property(t => t.rec_updt_user_id_cd).HasColumnName("rec_updt_user_id_cd");

            // Relationships
            this.HasRequired(t => t.faclty_hw_invtry)
                .WithMany(t => t.ovs)
                .HasForeignKey(d => d.faclty_hw_invtry_id);
            this.HasRequired(t => t.lkup_bnfcry)
                .WithMany(t => t.ovs)
                .HasForeignKey(d => d.bnfcry_id);
            this.HasRequired(t => t.lkup_faclty)
                .WithMany(t => t.ovs)
                .HasForeignKey(d => d.faclty_id);
            this.HasRequired(t => t.lkup_gndr)
                .WithMany(t => t.ovs)
                .HasForeignKey(d => d.gndr_id);

        }
    }
}
