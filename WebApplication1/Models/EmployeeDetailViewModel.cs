using System.ComponentModel;

namespace WebApplication1.Models
{
    public class EmployeeDetailViewModel
    {
        [DisplayName("My Name")]
        public string Firstname { get; set; }
        [DisplayName("My Surname")]
        public string Lastname { get; set; }
    }
}