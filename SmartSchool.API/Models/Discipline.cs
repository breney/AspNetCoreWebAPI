using Microsoft.Identity.Client;

namespace SmartSchool.WebAPI.Models
{
    public class Discipline
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TeacherId { get; set; }

        public int CourseId { get; set; }

        public int WorkLoad { get; set; }

        public int? PreRequirementId { get; set; } = null;

        public Discipline PreRequirement { get; set; }

        public Teacher Teacher { get; set; }

        public Course Course { get; set; }

        public IEnumerable<DisciplineStudent> DisciplineStudents { get; set; }
    }
}
