namespace SmartSchool.WebAPI.Models
{
    public class Discipline
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public IEnumerable<DisciplineStudent> DisciplineStudents { get; set; }
    }
}
