using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroBiz_Core.Models
{
    public class OurService: BaseEntity
    {
        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(250)]
        public string Description { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? ImgFile { get; set; }
    }
}
