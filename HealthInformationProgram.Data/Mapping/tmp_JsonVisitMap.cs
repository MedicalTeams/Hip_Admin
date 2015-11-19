using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Mapping
{
    public class tmp_JsonVisitMap : EntityTypeConfiguration<tmp_JsonVisit>
    {
        public tmp_JsonVisitMap()
        {
            // Primary Key
            this.HasKey(t => new { t.element_id, t.StringValue, t.ValueType, t.visit_uuid });

            // Properties
            this.Property(t => t.element_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .HasMaxLength(2000);

            this.Property(t => t.StringValue)
                .IsRequired();

            this.Property(t => t.ValueType)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.visit_uuid)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tmp_JsonVisit");
            this.Property(t => t.element_id).HasColumnName("element_id");
            this.Property(t => t.sequenceNo).HasColumnName("sequenceNo");
            this.Property(t => t.parent_ID).HasColumnName("parent_ID");
            this.Property(t => t.Object_ID).HasColumnName("Object_ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.StringValue).HasColumnName("StringValue");
            this.Property(t => t.ValueType).HasColumnName("ValueType");
            this.Property(t => t.visit_uuid).HasColumnName("visit_uuid");
        }
    }
}
