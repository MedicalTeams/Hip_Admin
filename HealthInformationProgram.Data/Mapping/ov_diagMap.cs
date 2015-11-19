using HealthInformationProgram.Data.Tables;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HealthInformationProgram.Data.Mapping
{
    public class ov_diagMap : EntityTypeConfiguration<ov_diag>
    {
        public ov_diagMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ov_diag_id, t.ov_id, t.diag_id, t.rec_creat_dt, t.rec_creat_user_id_cd, t.rec_updt_dt, t.rec_updt_user_id_cd });

            // Properties
            this.Property(t => t.ov_diag_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ov_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.diag_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.oth_diag_descn)
                .HasMaxLength(100);

            this.Property(t => t.oth_splmtl_diag_descn)
                .HasMaxLength(100);

            this.Property(t => t.rec_creat_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.rec_updt_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("ov_diag");
            this.Property(t => t.ov_diag_id).HasColumnName("ov_diag_id");
            this.Property(t => t.ov_id).HasColumnName("ov_id");
            this.Property(t => t.splmtl_diag_id).HasColumnName("splmtl_diag_id");
            this.Property(t => t.diag_id).HasColumnName("diag_id");
            this.Property(t => t.cntct_trmnt_cnt).HasColumnName("cntct_trmnt_cnt");
            this.Property(t => t.splmtl_diag_cat_id).HasColumnName("splmtl_diag_cat_id");
            this.Property(t => t.oth_diag_descn).HasColumnName("oth_diag_descn");
            this.Property(t => t.oth_splmtl_diag_descn).HasColumnName("oth_splmtl_diag_descn");
            this.Property(t => t.rec_creat_dt).HasColumnName("rec_creat_dt");
            this.Property(t => t.rec_creat_user_id_cd).HasColumnName("rec_creat_user_id_cd");
            this.Property(t => t.rec_updt_dt).HasColumnName("rec_updt_dt");
            this.Property(t => t.rec_updt_user_id_cd).HasColumnName("rec_updt_user_id_cd");
        }
    }
}
