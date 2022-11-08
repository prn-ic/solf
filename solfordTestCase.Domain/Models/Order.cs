namespace solfordTestCase.Domain.Models
{
    public class Order: BaseEntity
    {
        public string? Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
        public Provider? Provider { get; set; }
    }
}