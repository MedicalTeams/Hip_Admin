using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Mapping
{
    public class lkup_splmtl_diagMap : EntityTypeConfiguration<lkup_splmtl_diag>
    {
        public lkup_splmtl_diagMap()
        {
            // Primary Key
            this.HasKey(t => t.splmtl_diag_id);

            // Properties
            this.Property(t => t.splmtl_diag_descn)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.splmtl_diag_stat)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.rec_creat_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.rec_updt_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("lkup_splmtl_diag");
            this.Property(t => t.splmtl_diag_id).HasColumnName("splmtl_diag_id");
            this.Property(t => t.splmtl_diag_descn).HasColumnName("splmtl_diag_descn");
            this.Property(t => t.diag_id).HasColumnName("diag_id");
            this.Property(t => t.user_intrfc_sort_ord).HasColumnName("user_intrfc_sort_ord");
            this.Property(t => t.splmtl_diag_stat).HasColumnName("splmtl_diag_stat");
            this.Property(t => t.splmtl_diag_strt_eff_dt).HasColumnName("splmtl_diag_strt_eff_dt");
            this.Property(t => t.splmtl_diag_end_eff_dt).HasColumnName("splmtl_diag_end_eff_dt");
            this.Property(t => t.rec_creat_dt).HasColumnName("rec_creat_dt");
            this.Property(t => t.rec_creat_user_id_cd).HasColumnName("rec_creat_user_id_cd");
            this.Property(t => t.rec_updt_dt).HasColumnName("rec_updt_dt");
            this.Property(t => t.rec_updt_user_id_cd).HasColumnName("rec_updt_user_id_cd");

            // Relationships
            this.HasRequired(t => t.lkup_diag)
                .WithMany(t => t.lkup_splmtl_diag)
                .HasForeignKey(d => d.diag_id);

        }
    }
}
