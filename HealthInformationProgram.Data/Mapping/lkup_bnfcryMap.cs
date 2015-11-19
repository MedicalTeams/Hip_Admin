using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Mapping
{
    public class lkup_bnfcryMap : EntityTypeConfiguration<lkup_bnfcry>
    {
        public lkup_bnfcryMap()
        {
            // Primary Key
            this.HasKey(t => new { t.bnfcry_id, t.bnfcry, t.rec_creat_dt, t.rec_creat_user_id_cd, t.rec_updt_dt, t.rec_updt_user_id_cd });

            // Properties
            this.Property(t => t.bnfcry_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.bnfcry)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.rec_creat_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.rec_updt_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("lkup_bnfcry");
            this.Property(t => t.bnfcry_id).HasColumnName("bnfcry_id");
            this.Property(t => t.bnfcry).HasColumnName("bnfcry");
            this.Property(t => t.user_intrfc_sort_ord).HasColumnName("user_intrfc_sort_ord");
            this.Property(t => t.rec_creat_dt).HasColumnName("rec_creat_dt");
            this.Property(t => t.rec_creat_user_id_cd).HasColumnName("rec_creat_user_id_cd");
            this.Property(t => t.rec_updt_dt).HasColumnName("rec_updt_dt");
            this.Property(t => t.rec_updt_user_id_cd).HasColumnName("rec_updt_user_id_cd");
        }
    }
}
