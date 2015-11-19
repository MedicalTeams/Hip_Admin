using HealthInformationProgram.Data.Tables;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HealthInformationProgram.Data.Mapping
{
    public class ovMap : EntityTypeConfiguration<ov>
    {
        public ovMap()
        {
            // Primary Key
            this.HasKey(t => new { t.faclty_id, t.gndr_id, t.bnfcry_id, t.opd_id, t.ov_id, t.faclty_hw_invtry_id, t.dt_of_visit, t.staff_mbr_name, t.infnt_age_mos, t.rvisit_id, t.rec_creat_dt, t.rec_creat_user_id_cd, t.rec_updt_dt, t.rec_updt_user_id_cd });

            // Properties
            this.Property(t => t.faclty_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.gndr_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.bnfcry_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.opd_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ov_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.faclty_hw_invtry_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.staff_mbr_name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.refl_in_ind)
                .HasMaxLength(1);

            this.Property(t => t.refl_out_ind)
                .HasMaxLength(1);

            this.Property(t => t.infnt_age_mos)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.rvisit_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.rec_creat_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.rec_updt_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

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
            this.Property(t => t.infnt_age_mos).HasColumnName("infnt_age_mos");
            this.Property(t => t.rvisit_id).HasColumnName("rvisit_id");
            this.Property(t => t.rec_creat_dt).HasColumnName("rec_creat_dt");
            this.Property(t => t.rec_creat_user_id_cd).HasColumnName("rec_creat_user_id_cd");
            this.Property(t => t.rec_updt_dt).HasColumnName("rec_updt_dt");
            this.Property(t => t.rec_updt_user_id_cd).HasColumnName("rec_updt_user_id_cd");
        }
    }
}
