
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
        public int Credit { get; set; } = 0;
        public List<Order> Orders { get; set; }
        public double Lat { get; set; } = 0;
        public double Long { get; set; } = 0;


        //AppUserId


    }


 

 
  
}
