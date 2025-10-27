using OrderService.Domain.Common;

namespace OrderService.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public List<GenreMovie> GenreMovie { get; set; }
       

    }
}
