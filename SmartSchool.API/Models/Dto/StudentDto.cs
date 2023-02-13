namespace SmartSchool.WebAPI.Models.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }

        public int Registration { get; set; }

        public string Name { get; set; }

        public string Telephone { get; set; }

        public int Age { get; set; }

        public DateTime DateTimeBegin { get; set; }

        public bool Active { get; set; }
    }
}
