using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HealthInformationProgram.Data.Mapping
{
    public class lkup_diagMap : EntityTypeConfiguration<lkup_diag>
    {
        public lkup_diagMap()
        {
            // Primary Key
            this.HasKey(t => t.diag_id);

            // Properties
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
