using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Mapping
{
    public class lkup_facltyMap : EntityTypeConfiguration<lkup_faclty>
    {
        public lkup_facltyMap()
        {
            // Primary Key
            this.HasKey(t => t.faclty_id);

            // Properties
            this.Property(t => t.hlth_care_faclty)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.hlth_care_faclty_lvl)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.hlth_coordtr)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.setlmt)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.cntry)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.rgn)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.faclty_stat)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.rec_creat_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.rec_updt_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("lkup_faclty");
            this.Property(t => t.faclty_id).HasColumnName("faclty_id");
            this.Property(t => t.hlth_care_faclty).HasColumnName("hlth_care_faclty");
            this.Property(t => t.hlth_care_faclty_lvl).HasColumnName("hlth_care_faclty_lvl");
            this.Property(t => t.hlth_coordtr).HasColumnName("hlth_coordtr");
            this.Property(t => t.setlmt).HasColumnName("setlmt");
            this.Property(t => t.cntry).HasColumnName("cntry");
            this.Property(t => t.rgn).HasColumnName("rgn");
            this.Property(t => t.orgzn_id).HasColumnName("orgzn_id");
            this.Property(t => t.faclty_stat).HasColumnName("faclty_stat");
            this.Property(t => t.faclty_strt_eff_dt).HasColumnName("faclty_strt_eff_dt");
            this.Property(t => t.faclty_end_eff_dt).HasColumnName("faclty_end_eff_dt");
            this.Property(t => t.user_intrfc_sort_ord).HasColumnName("user_intrfc_sort_ord");
            this.Property(t => t.longtd).HasColumnName("longtd");
            this.Property(t => t.lattd).HasColumnName("lattd");
            this.Property(t => t.rec_creat_dt).HasColumnName("rec_creat_dt");
            this.Property(t => t.rec_creat_user_id_cd).HasColumnName("rec_creat_user_id_cd");
            this.Property(t => t.rec_updt_dt).HasColumnName("rec_updt_dt");
            this.Property(t => t.rec_updt_user_id_cd).HasColumnName("rec_updt_user_id_cd");

            // Relationships
            this.HasRequired(t => t.lkup_orgzn)
                .WithMany(t => t.lkup_faclty)
                .HasForeignKey(d => d.orgzn_id);

        }
    }
}
