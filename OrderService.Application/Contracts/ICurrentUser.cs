using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Contracts
{
    public interface ICurrentUser
    {
        string FullName { get; set; }
        string UserId { get; set; }
        string Mobile { get; set; }
       
    }
    public class CurrentUser : ICurrentUser
    {
        public string FullName { get; set ; }
        public string UserId { get ; set ; }
        public string Mobile { get ; set ; }
    }
}
