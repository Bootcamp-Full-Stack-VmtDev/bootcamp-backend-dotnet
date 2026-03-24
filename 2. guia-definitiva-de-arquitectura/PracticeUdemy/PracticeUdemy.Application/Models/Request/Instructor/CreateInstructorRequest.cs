using System.ComponentModel.DataAnnotations;

namespace PracticeUdemy.Application.Models.Request.Instructor
{
    public class CreateInstructorRequest
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string email { get; set; }
    }
}
