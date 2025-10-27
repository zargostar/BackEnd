namespace OrderService.Application.Features.Students.Queries.StudentList
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int Age => new DateTime((DateTime.Now - BirthDate).Ticks).Year;
        public DateTime BirthDate { get; set; }
        public int Sports { get; set;}
    }
}