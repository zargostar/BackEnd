using OrderService.Domain.Common;
using OrderServise.Domain.Entities;

namespace OrderService.Domain.Entities
{
    public class Actor : BaseEntity
    {
        public string Name { get; set; }
        public string? Image { get; set; }
        public string LastName { get; set; }
    

        public string  Title { get; set; }
        public string  ? FullName { get; private set; }
        //public List<ActorMovie>? ActorMovies { get; set; }
        public List<Discription> ? DiscriptionI18n { get; set; }
     
        //public Location Location { get; set; }
        //public Decimal Grade { get; set; } = new Decimal(1.33);
        //public List<int>? Degries { get; set; } 
        public TimeSpan? Delay { get; set; }
      

    }

}
