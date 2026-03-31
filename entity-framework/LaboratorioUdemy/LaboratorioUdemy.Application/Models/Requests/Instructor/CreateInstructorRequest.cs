using System.ComponentModel.DataAnnotations;

namespace LaboratorioUdemy.Application.Models.Requests.Instructor
{
    public class CreateInstructorRequest
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;

    }
}
