using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Mapping
{
    public class curr_sys_infoMap : EntityTypeConfiguration<curr_sys_info>
    {
        public curr_sys_infoMap()
        {
            // Primary Key
            this.HasKey(t => t.curr_sys_id);

            // Properties
            this.Property(t => t.itm_descn)
                .HasMaxLength(50);

            this.Property(t => t.itm_vrsn)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("curr_sys_info");
            this.Property(t => t.curr_sys_id).HasColumnName("curr_sys_id");
            this.Property(t => t.itm_descn).HasColumnName("itm_descn");
            this.Property(t => t.itm_vrsn).HasColumnName("itm_vrsn");
            this.Property(t => t.dt_of_rlse).HasColumnName("dt_of_rlse");
        }
    }
}
