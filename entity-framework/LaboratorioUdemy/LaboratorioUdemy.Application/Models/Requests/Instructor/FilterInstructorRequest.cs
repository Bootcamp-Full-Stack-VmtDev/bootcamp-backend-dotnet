namespace LaboratorioUdemy.Application.Models.Requests.Instructor
{
    public class FilterInstructorRequest : BaseRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
