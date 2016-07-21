using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HealthInformationProgram.Data.Mapping
{
    public class faclty_hw_invtryMap : EntityTypeConfiguration<faclty_hw_invtry>
    {
        public faclty_hw_invtryMap()
        {
            // Primary Key
            this.HasKey(t => t.faclty_hw_invtry_id);

            // Properties
            this.Property(t => t.itm_descn)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.mac_addr)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.aplctn_vrsn)
                .HasMaxLength(25);

            this.Property(t => t.hw_stat)
                .HasMaxLength(1);

            this.Property(t => t.rec_creat_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.rec_updt_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("faclty_hw_invtry");
            this.Property(t => t.faclty_hw_invtry_id).HasColumnName("faclty_hw_invtry_id");
            this.Property(t => t.faclty_id).HasColumnName("faclty_id");
            this.Property(t => t.itm_descn).HasColumnName("itm_descn");
            this.Property(t => t.mac_addr).HasColumnName("mac_addr");
            this.Property(t => t.aplctn_vrsn).HasColumnName("aplctn_vrsn");
            this.Property(t => t.hw_stat).HasColumnName("hw_stat");
            this.Property(t => t.rec_creat_dt).HasColumnName("rec_creat_dt");
            this.Property(t => t.rec_creat_user_id_cd).HasColumnName("rec_creat_user_id_cd");
            this.Property(t => t.rec_updt_dt).HasColumnName("rec_updt_dt");
            this.Property(t => t.rec_updt_user_id_cd).HasColumnName("rec_updt_user_id_cd");

            // Relationships
            this.HasRequired(t => t.lkup_faclty)
                .WithMany(t => t.faclty_hw_invtry)
                .HasForeignKey(d => d.faclty_id);

        }
    }
}
