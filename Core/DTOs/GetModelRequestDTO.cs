using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class GetModelRequestDTO
    {
        [Required]
        public int ModelYear { get; set; }
        [Required]
        public string? Make { get; set; }
    }
}
