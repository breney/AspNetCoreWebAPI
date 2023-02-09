namespace SmartSchool.WebAPI.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Telephone { get; set; }

        public IEnumerable<DisciplineStudent> DisciplineStudents { get; set; }

    }
}
