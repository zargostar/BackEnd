namespace OrderService.Application.Features.Actors.Dto
{

    public class ActorModel
    {
        public string Name { get; set; }
        public string? Image { get; set; }
        public string LastName { get; set; }
      

        public Dictionary<string, string>  Title { get; set; }
        //[ModelBinder(BinderType = typeof(TypeBinder<List<DiscriptionModel>>))]
        public List<DiscriptionModel>? DiscriptionI18n { get; set; }
     
    }


}
