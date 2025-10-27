using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Entities
{
    //public class AddressValueObject
    //{
    //    public required string Line1 { get; set; }
    //    public string? Line2 { get; set; }
    //    public required string City { get; set; }
    //    public required string Country { get; set; }
    //    public required string PostCode { get; set; }
    //}
    public record AddressValueObject(string City, string Country, string PostCode, string Line1,string  Line2);
    public class OrderTest
    {
        public int Id { get; set; }
        public required string Contents { get; set; }
        public required AddressValueObject ShippingAddress { get; init; }
        public required AddressValueObject BillingAddress { get; init; }
        public Customer Customer { get; set; } = null!;
    }
    public class Customer
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required AddressValueObject Address { get; init; }
       
    }
}
