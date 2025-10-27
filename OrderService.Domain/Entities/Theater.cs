using OrderService.Domain.Common;

namespace OrderService.Domain.Entities
{
    public class Theater : BaseEntity
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public List<MovieTheater> Movies { get; set;}
    }
}
