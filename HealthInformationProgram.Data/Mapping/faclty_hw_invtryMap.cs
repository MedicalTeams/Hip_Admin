using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Mapping
{
    public class faclty_hw_invtryMap : EntityTypeConfiguration<faclty_hw_invtry>
    {
        public faclty_hw_invtryMap()
        {
            // Primary Key
            this.HasKey(t => new { t.faclty_hw_invtry_id, t.faclty_id, t.itm_descn, t.mac_addr, t.hw_stat, t.rec_creat_dt, t.rec_creat_user_id_cd, t.rec_updt_dt, t.rec_updt_user_id_cd });

            // Properties
            this.Property(t => t.faclty_hw_invtry_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.faclty_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.itm_descn)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.mac_addr)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.aplctn_vrsn)
                .HasMaxLength(25);

            this.Property(t => t.hw_stat)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

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
        }
    }
}
