using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Mapping
{
    public class lkup_orgznMap : EntityTypeConfiguration<lkup_orgzn>
    {
        public lkup_orgznMap()
        {
            // Primary Key
            this.HasKey(t => t.orgzn_id);

            // Properties
            this.Property(t => t.orgzn)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.orgzn_stat)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.rec_creat_user_id_cd)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.rec_updt_user_id_cd)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("lkup_orgzn");
            this.Property(t => t.orgzn_id).HasColumnName("orgzn_id");
            this.Property(t => t.orgzn).HasColumnName("orgzn");
            this.Property(t => t.user_intrfc_sort_ord).HasColumnName("user_intrfc_sort_ord");
            this.Property(t => t.orgzn_stat).HasColumnName("orgzn_stat");
            this.Property(t => t.orgzn_strt_eff_dt).HasColumnName("orgzn_strt_eff_dt");
            this.Property(t => t.orgzn_end_eff_dt).HasColumnName("orgzn_end_eff_dt");
            this.Property(t => t.rec_creat_dt).HasColumnName("rec_creat_dt");
            this.Property(t => t.rec_creat_user_id_cd).HasColumnName("rec_creat_user_id_cd");
            this.Property(t => t.rec_updt_dt).HasColumnName("rec_updt_dt");
            this.Property(t => t.rec_updt_user_id_cd).HasColumnName("rec_updt_user_id_cd");
        }
    }
}
