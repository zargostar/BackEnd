using OrderService.Domain.Common;
using OrderServise.Domain.Entities;

namespace OrderService.Domain.Entities
{
    public class Actor : BaseEntity
    {
        public string Name { get; set; }
        public string? Image { get; set; }
        public Dictionary<string,string> ? MetaData { get; set; }
        public List<ActorMovie>? ActorMovies { get; set; }
        public TAddress? Address { get; set; }
        public Location Location { get; set; }
        public Decimal Grade { get; set; } = new Decimal(1.33);
        public List<int>? Degries { get; set; } 
        public TimeSpan Delay { get; set; }
      

    }
}
