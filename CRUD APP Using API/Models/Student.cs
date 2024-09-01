using System.ComponentModel.DataAnnotations;

namespace CRUD_APP_Using_API.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public int Standard { get; set; }




    }
}
