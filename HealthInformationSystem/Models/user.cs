namespace HealthInformationProgram.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;

    [Table("user")]
    public partial class user
    {
        [Key]
        [Column(Order = 0)]
        public Guid userId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        [Required]
        [DisplayName("First Name")]
        public string firstname { get; set; }

        [Key]
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

        [Key]
        [Column(Order = 4)]
        [StringLength(100)]
        [RegularExpression("^[a-zA-Z0-9'!@#$%^&*.][\\S]{6,50}$", ErrorMessage = "Invalid Password")]
        public string password { get; set; }

        public DateTime? createDate { get; set; }

        public Guid? createdBy { get; set; }
    }
}
