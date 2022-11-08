using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using solfordTestCase.Domain.Models;

namespace solfordTestCase.Domain.Dto
{
    public class OrderItemDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public Decimal Quantity { get; set; }
        [Required]
        public string? Unit { get; set; }
    }
}