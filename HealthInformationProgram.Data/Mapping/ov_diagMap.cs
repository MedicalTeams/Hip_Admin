using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Mapping
{
    public class ov_diagMap : EntityTypeConfiguration<ov_diag>
    {
        public ov_diagMap()
        {
            // Primary Key
            this.HasKey(t => t.ov_diag_id);

            // Properties
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

            // Relationships
            this.HasRequired(t => t.lkup_diag)
                .WithMany(t => t.ov_diag)
                .HasForeignKey(d => d.diag_id);
            this.HasOptional(t => t.lkup_splmtl_diag)
                .WithMany(t => t.ov_diag)
                .HasForeignKey(d => d.splmtl_diag_id);
            this.HasOptional(t => t.lkup_splmtl_diag_cat)
                .WithMany(t => t.ov_diag)
                .HasForeignKey(d => d.splmtl_diag_cat_id);
            this.HasRequired(t => t.ov)
                .WithMany(t => t.ov_diag)
                .HasForeignKey(d => d.ov_id);

        }
    }
}
