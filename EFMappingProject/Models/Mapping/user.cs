namespace EFMappingProject.Models.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class user
    {
        [Key]
        [Column(Order = 0)]
        public Guid userId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string firstname { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string lastname { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string email { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(100)]
        public string password { get; set; }

        public DateTime? createDate { get; set; }

        public Guid? createdBy { get; set; }
    }
}
