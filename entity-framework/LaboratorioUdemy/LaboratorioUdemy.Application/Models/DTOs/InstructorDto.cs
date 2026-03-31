namespace LaboratorioUdemy.Application.Models.DTOs
{
    public class InstructorDto
    {
        public Guid InstructorId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime RegisterDate { get; set; }
    }
}
