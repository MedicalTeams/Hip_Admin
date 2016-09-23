namespace HealthInformationProgram.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("userrole")]
    public partial class userrole
    {
        [Key]
        [Column(Order = 0)]
        public Guid id { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid userId { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid roleId { get; set; }

        public DateTime? createDate { get; set; }

        public Guid? createdBy { get; set; }
    }
}
