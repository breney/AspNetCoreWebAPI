namespace SmartSchool.WebAPI.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Registration { get; set; }

        public DateTime DateTimeBegin { get; set; } = DateTime.Now;

        public DateTime? DateTimeEnd { get; set; } = null;

        public bool Active { get; set; } = true;

        public IEnumerable<Discipline> Disciplines { get; set; }       
    }
}
