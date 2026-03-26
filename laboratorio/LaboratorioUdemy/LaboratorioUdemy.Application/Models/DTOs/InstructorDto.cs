namespace LaboratorioUdemy.Application.Models.DTOs
{
    public class InstructorDto
    {
        public Guid InstructorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
