using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HealthInformationProgram.Data.Mapping
{
    public class lkup_gndrMap : EntityTypeConfiguration<lkup_gndr>
    {
        public lkup_gndrMap()
        {
            // Primary Key
            this.HasKey(t => t.gndr_id);

            // Properties
            this.Property(t => t.gndr_descn)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.gndr_cd)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.rec_creat_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.rec_updt_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("lkup_gndr");
            this.Property(t => t.gndr_id).HasColumnName("gndr_id");
            this.Property(t => t.gndr_descn).HasColumnName("gndr_descn");
            this.Property(t => t.gndr_cd).HasColumnName("gndr_cd");
            this.Property(t => t.user_intrfc_sort_ord).HasColumnName("user_intrfc_sort_ord");
            this.Property(t => t.rec_creat_dt).HasColumnName("rec_creat_dt");
            this.Property(t => t.rec_creat_user_id_cd).HasColumnName("rec_creat_user_id_cd");
            this.Property(t => t.rec_updt_dt).HasColumnName("rec_updt_dt");
            this.Property(t => t.rec_updt_user_id_cd).HasColumnName("rec_updt_user_id_cd");
        }
    }
}
