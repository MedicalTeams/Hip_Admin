using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Mapping
{
    public class vw_diag_alertMap : EntityTypeConfiguration<vw_diag_alert>
    {
        public vw_diag_alertMap()
        {
            // Primary Key
            this.HasKey(t => new { t.diag_alert_thrshld_id, t.diag_id, t.case_cnt, t.baseln_multr });

            // Properties
            this.Property(t => t.diag_alert_thrshld_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.diag_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.case_cnt)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.baseln_multr)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("vw_diag_alert");
            this.Property(t => t.diag_alert_thrshld_id).HasColumnName("diag_alert_thrshld_id");
            this.Property(t => t.diag_id).HasColumnName("diag_id");
            this.Property(t => t.case_cnt).HasColumnName("case_cnt");
            this.Property(t => t.baseln_multr).HasColumnName("baseln_multr");
        }
    }
}
