using System.ComponentModel.DataAnnotations;

namespace Exam_HeroBiz.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Surname { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MinLength(7)]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MinLength(7)]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
