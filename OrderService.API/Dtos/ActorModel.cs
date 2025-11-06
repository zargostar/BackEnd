using OrderService.Domain.Entities;
using OrderServise.Domain.Entities;


namespace OrderService.API.Controllers
{

    public class ActorModel
    {
        public string Name { get; set; }
        public string? Image { get; set; }
        public Dictionary<string, string> MetaData { get; set; }
        public  TAddress Address { get; set; }
        public Location Location { get; set; }



    }
    public class AddressModel{
        public AddressDetail Home { get; set; }
        public AddressDetail Office { get; set; }
    }
    
}
