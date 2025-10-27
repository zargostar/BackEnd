using OrderService.Domain.Common;

namespace OrderService.Domain.Entities
{
    public class OrderItem:BaseEntity
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int OrderId { get; set; }
        public int Price { get; set; }
    }
}
