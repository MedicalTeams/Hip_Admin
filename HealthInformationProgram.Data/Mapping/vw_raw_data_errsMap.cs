using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Mapping
{
    public class vw_raw_data_errsMap : EntityTypeConfiguration<vw_raw_data_errs>
    {
        public vw_raw_data_errsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.visit_uuid, t.visit_json, t.rec_creat_dt, t.visit_stat });

            // Properties
            this.Property(t => t.visit_uuid)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.visit_json)
                .IsRequired();

            this.Property(t => t.visit_stat)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.exception_descn)
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("vw_raw_data_errs");
            this.Property(t => t.visit_uuid).HasColumnName("visit_uuid");
            this.Property(t => t.visit_json).HasColumnName("visit_json");
            this.Property(t => t.opd_id).HasColumnName("opd_id");
            this.Property(t => t.rec_creat_dt).HasColumnName("rec_creat_dt");
            this.Property(t => t.visit_stat).HasColumnName("visit_stat");
            this.Property(t => t.err_cd).HasColumnName("err_cd");
            this.Property(t => t.exception_descn).HasColumnName("exception_descn");
        }
    }
}
