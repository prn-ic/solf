using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using solfordTestCase.Domain.Models;

namespace solfordTestCase.Domain.Dto
{
    public class OrderDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Number { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int ProviderId { get; set; }
        [ForeignKey("ProviderId")]
        public Provider? Provider { get; set; }
    }
}