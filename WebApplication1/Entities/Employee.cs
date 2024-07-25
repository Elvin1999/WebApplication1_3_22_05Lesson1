using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Firstname { get; set; }
        [Required(ErrorMessage ="Surname is required")]
        [MinLength(10,ErrorMessage ="Should be more than 10 letters")]
        public string Lastname { get; set; }
        [Range(1,12,ErrorMessage ="Should be between 1-12")]
        public int Point { get; set; }
    }
}
