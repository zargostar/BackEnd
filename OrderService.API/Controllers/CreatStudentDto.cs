namespace OrderService.API.Controllers
{
    public class CreatStudentDto
    {
        public string Name { get; set; }
        public string LastName { get; set;}
        public List<int>? ides  { get; set; }
    }
}