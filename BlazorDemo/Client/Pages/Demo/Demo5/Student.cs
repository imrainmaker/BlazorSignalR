using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Client.Pages.Demo.Demo5
{
    public class Student
    {
        [Required]
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [EmailAddress(ErrorMessage = "On t'as dis une adresse mail !!!")]
        public string Email { get; set; }
        [Range(0, 20, ErrorMessage = "La note doit être comprise entre 0 et 20")]
        public int YearResult { get; set; }
    }
}
