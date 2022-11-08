using System.ComponentModel.DataAnnotations;

namespace solfordTestCase.Domain.Dto
{
    public class ProviderDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        public string? Name { get; set; }
    }
}