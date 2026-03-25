using System.ComponentModel.DataAnnotations;

namespace PracticeUdemy.Application.Models.Request.Instructor
{
    public class CreateInstructorRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

    }
}
