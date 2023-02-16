namespace SmartSchool.WebAPI.Models.Dto
{
    public class TeacherDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Registration { get; set; }

        public DateTime DateTimeBegin { get; set; }

        public bool Active { get; set; } = true;
    }
}
