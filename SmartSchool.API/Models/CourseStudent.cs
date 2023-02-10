namespace SmartSchool.WebAPI.Models
{
    public class CourseStudent
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int CourseId { get; set; }

        public DateTime DateBegin { get; set; } = DateTime.Now;

        public DateTime? DateEnd { get; set; } = null;

        public Course Course { get; set; }
    }
}
