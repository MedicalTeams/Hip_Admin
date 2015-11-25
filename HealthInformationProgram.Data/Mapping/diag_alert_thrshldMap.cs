using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Mapping
{
    public class diag_alert_thrshldMap : EntityTypeConfiguration<diag_alert_thrshld>
    {
        public diag_alert_thrshldMap()
        {
            // Primary Key
            this.HasKey(t => t.diag_alert_thrshld_id);

            // Properties
            this.Property(t => t.rec_creat_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.rec_updt_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("diag_alert_thrshld");
            this.Property(t => t.diag_alert_thrshld_id).HasColumnName("diag_alert_thrshld_id");
            this.Property(t => t.diag_id).HasColumnName("diag_id");
            this.Property(t => t.case_cnt).HasColumnName("case_cnt");
            this.Property(t => t.baseln_multr).HasColumnName("baseln_multr");
            this.Property(t => t.rec_creat_dt).HasColumnName("rec_creat_dt");
            this.Property(t => t.rec_creat_user_id_cd).HasColumnName("rec_creat_user_id_cd");
            this.Property(t => t.rec_updt_dt).HasColumnName("rec_updt_dt");
            this.Property(t => t.rec_updt_user_id_cd).HasColumnName("rec_updt_user_id_cd");
        }
    }
}
