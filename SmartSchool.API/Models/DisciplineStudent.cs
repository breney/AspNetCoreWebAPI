namespace SmartSchool.WebAPI.Models
{
    public class DisciplineStudent
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int DisciplineId { get; set; }

        public int? Grade { get; set; } = null;

        public DateTime DateBegin { get; set; } = DateTime.Now;

        public DateTime? DateEnd { get; set; } = null;

        public Discipline Discipline { get; set; }
    }
}
