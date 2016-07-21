using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HealthInformationProgram.Data.Mapping
{
    public class lkup_exceptionsMap : EntityTypeConfiguration<lkup_exceptions>
    {
        public lkup_exceptionsMap()
        {
            // Primary Key
            this.HasKey(t => t.err_cd);

            // Properties
            this.Property(t => t.err_cd)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.exception_descn)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.exception_comment)
                .HasMaxLength(400);

            this.Property(t => t.rec_creat_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.rec_updt_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("lkup_exceptions");
            this.Property(t => t.err_cd).HasColumnName("err_cd");
            this.Property(t => t.exception_descn).HasColumnName("exception_descn");
            this.Property(t => t.exception_comment).HasColumnName("exception_comment");
            this.Property(t => t.user_intrfc_sort_ord).HasColumnName("user_intrfc_sort_ord");
            this.Property(t => t.rec_creat_dt).HasColumnName("rec_creat_dt");
            this.Property(t => t.rec_creat_user_id_cd).HasColumnName("rec_creat_user_id_cd");
            this.Property(t => t.rec_updt_dt).HasColumnName("rec_updt_dt");
            this.Property(t => t.rec_updt_user_id_cd).HasColumnName("rec_updt_user_id_cd");
        }
    }
}
