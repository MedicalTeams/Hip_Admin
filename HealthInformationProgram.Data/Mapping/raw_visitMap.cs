using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Mapping
{
    public class raw_visitMap : EntityTypeConfiguration<raw_visit>
    {
        public raw_visitMap()
        {
            // Primary Key
            this.HasKey(t => t.visit_uuid);

            // Properties
            this.Property(t => t.visit_uuid)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.visit_json)
                .IsRequired();

            this.Property(t => t.rec_creat_user_id_cd)
                         .IsRequired()
                         .HasMaxLength(100);

            this.Property(t => t.rec_updt_user_id_cd)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.visit_stat)
                .IsRequired()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("raw_visit");
            this.Property(t => t.visit_uuid).HasColumnName("visit_uuid");
            this.Property(t => t.visit_json).HasColumnName("visit_json");
            this.Property(t => t.rec_creat_dt).HasColumnName("rec_creat_dt");
            this.Property(t => t.rec_creat_user_id_cd).HasColumnName("rec_creat_user_id_cd");
            this.Property(t => t.rec_updt_dt).HasColumnName("rec_updt_dt");
            this.Property(t => t.rec_updt_user_id_cd).HasColumnName("rec_updt_user_id_cd");
            this.Property(t => t.visit_stat).HasColumnName("visit_stat");
            this.Property(t => t.err_cd).HasColumnName("err_cd");
        }
    }
}
