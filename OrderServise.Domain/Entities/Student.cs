using OrderServise.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.Domain.Entities
{
    public class Student:BaseEntity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        
        public List<SportStudent> SportStudents { get; set; }
        public List<string> Images { get; set; }
       // public Booking Booking { get; set; } = new();
    }
   
    public class Booking
    {
        public BookingInfo BookingInfo { get; set; }
        public List<BookingInfo> BookingInfos { get; set; }

    }
  
    public class BookingInfo
    {
        public BookingInfo(string street, string city, string postcode, string country)
        {
            Street = street;
            City = city;
            Postcode = postcode;
            Country = country;
        }

        public string Street { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public bool IsMainAddress { get; set; }
    }
}
