using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace SmartSchool.WebAPI.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; } = string.Empty;

        public string Telephone { get; set; } = string.Empty;

        public int Registration { get; set; }

        public DateTime DateBirth { get; set; } = DateTime.Now;

        public DateTime DateTimeBegin { get; set; } = DateTime.Now;

        public DateTime? DateTimeEnd { get; set; } = null;

        public bool Active { get; set; } = true;

        public IEnumerable<DisciplineStudent> DisciplineStudent { get; set; }

    }
}
