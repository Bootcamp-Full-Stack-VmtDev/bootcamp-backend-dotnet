namespace LaboratorioUdemy.Application.Models.Requests.Instructor
{
    public class GetAllInstructorRequest
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
