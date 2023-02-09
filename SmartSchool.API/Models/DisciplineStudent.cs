namespace SmartSchool.WebAPI.Models
{
    public class DisciplineStudent
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int DisciplineId { get; set; }

        public Discipline Discipline { get; set; }
    }
}
