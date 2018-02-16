namespace HealthInformationProgram.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;
    using HealthInformationProgram.CustomAttributes;

    [Table("user")]
    [UniqueUserEmailAddressAttribute]
    public partial class user
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid userId { get; set; }

        [Column(Order = 1)]
        [StringLength(100)]
        [Required]
        [DisplayName("First Name")]
        public string firstname { get; set; }

        [Column(Order = 2)]
        [StringLength(100)]
        [Required]
        [DisplayName("Last Name")]
        public string lastname { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        [Required]
        [DisplayName("E-Mail")]
        public string email { get; set; }

        [Column(Order = 4)]
        [StringLength(100)]
        public string password { get; set; }

        public DateTime? createDate { get; set; }

        public Guid? createdBy { get; set; }
    }
}
