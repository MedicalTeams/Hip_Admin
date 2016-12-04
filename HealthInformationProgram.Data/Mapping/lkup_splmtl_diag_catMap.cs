using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Mapping
{
    public class lkup_splmtl_diag_catMap : EntityTypeConfiguration<lkup_splmtl_diag_cat>
    {
        public lkup_splmtl_diag_catMap()
        {
            // Primary Key
            this.HasKey(t => t.splmtl_diag_cat_id);

            // Properties
            this.Property(t => t.splmtl_diag_cat)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.splmtl_diag_cat_stat)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.rec_creat_user_id_cd)
                    .IsRequired()
                    .HasMaxLength(100);

            this.Property(t => t.rec_updt_user_id_cd)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("lkup_splmtl_diag_cat");
            this.Property(t => t.splmtl_diag_cat_id).HasColumnName("splmtl_diag_cat_id");
            this.Property(t => t.splmtl_diag_cat).HasColumnName("splmtl_diag_cat");
            this.Property(t => t.user_intrfc_sort_ord).HasColumnName("user_intrfc_sort_ord");
            this.Property(t => t.splmtl_diag_cat_stat).HasColumnName("splmtl_diag_cat_stat");
            this.Property(t => t.splmtl_diag_cat_strt_eff_dt).HasColumnName("splmtl_diag_cat_strt_eff_dt");
            this.Property(t => t.splmtl_diag_cat_end_eff_dt).HasColumnName("splmtl_diag_cat_end_eff_dt");
            this.Property(t => t.rec_creat_dt).HasColumnName("rec_creat_dt");
            this.Property(t => t.rec_creat_user_id_cd).HasColumnName("rec_creat_user_id_cd");
            this.Property(t => t.rec_updt_dt).HasColumnName("rec_updt_dt");
            this.Property(t => t.rec_updt_user_id_cd).HasColumnName("rec_updt_user_id_cd");
        }
    }
}
