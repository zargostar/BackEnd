
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.AspNetCore.Identity;

namespace OrderService.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public bool IsActive { get; set; } = true;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }    
       
      
       


    }
    [ComplexType]
    public class Address
    {
        public AddressDetail WorkAddresses { get; set; }
        public AddressDetail HomeAddresses { get; set; }



    }

    [ComplexType]
    public record AddressDetail(string Street, string City, string PostalCode);
    public class Location
    {
       public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
