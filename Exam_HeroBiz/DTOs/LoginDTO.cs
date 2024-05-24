using System.ComponentModel.DataAnnotations;

namespace Exam_HeroBiz.DTOs
{
    public class LoginDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string UserNameOrEmail { get; set; }
        [Required]
        [MinLength(7)]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
