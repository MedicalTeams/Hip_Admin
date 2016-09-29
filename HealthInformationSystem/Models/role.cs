namespace HealthInformationProgram.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("role")]
    public partial class role
    {
        public Guid roleId { get; set; }

        [StringLength(100)]
        public string roleName { get; set; }

        [StringLength(100)]
        public string accessType { get; set; }

        public DateTime? createDate { get; set; }

        public Guid? createdBy { get; set; }
    }
}
