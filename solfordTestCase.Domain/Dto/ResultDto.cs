using System.ComponentModel.DataAnnotations;

namespace solfordTestCase.Domain.Dto
{
    public class ResultDto
    {
        [Required]
        public bool Success { get; set; }
    }
}
