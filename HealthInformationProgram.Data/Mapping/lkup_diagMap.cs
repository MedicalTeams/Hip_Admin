using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Mapping
{
    public class lkup_diagMap : EntityTypeConfiguration<lkup_diag>
    {
        public lkup_diagMap()
        {
            // Primary Key
            this.HasKey(t => new { t.diag_id, t.diag_descn, t.diag_stat, t.diag_strt_eff_dt, t.diag_end_eff_dt, t.rec_creat_dt, t.rec_creat_user_id_cd, t.rec_updt_dt, t.rec_updt_user_id_cd });

            // Properties
            this.Property(t => t.diag_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.diag_descn)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.icd_cd)
                .HasMaxLength(10);

            this.Property(t => t.diag_abrvn)
                .HasMaxLength(10);

            this.Property(t => t.diag_stat)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.rec_creat_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.rec_updt_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("lkup_diag");
            this.Property(t => t.diag_id).HasColumnName("diag_id");
            this.Property(t => t.diag_descn).HasColumnName("diag_descn");
            this.Property(t => t.icd_cd).HasColumnName("icd_cd");
            this.Property(t => t.diag_abrvn).HasColumnName("diag_abrvn");
            this.Property(t => t.user_intrfc_sort_ord).HasColumnName("user_intrfc_sort_ord");
            this.Property(t => t.diag_stat).HasColumnName("diag_stat");
            this.Property(t => t.diag_strt_eff_dt).HasColumnName("diag_strt_eff_dt");
            this.Property(t => t.diag_end_eff_dt).HasColumnName("diag_end_eff_dt");
            this.Property(t => t.rec_creat_dt).HasColumnName("rec_creat_dt");
            this.Property(t => t.rec_creat_user_id_cd).HasColumnName("rec_creat_user_id_cd");
            this.Property(t => t.rec_updt_dt).HasColumnName("rec_updt_dt");
            this.Property(t => t.rec_updt_user_id_cd).HasColumnName("rec_updt_user_id_cd");
        }
    }
}
