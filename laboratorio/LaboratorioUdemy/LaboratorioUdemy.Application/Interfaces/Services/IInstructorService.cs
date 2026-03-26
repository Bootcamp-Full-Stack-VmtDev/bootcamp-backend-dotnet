using LaboratorioUdemy.Application.Models.DTOs;
using LaboratorioUdemy.Application.Models.Requests.Instructor;
using LaboratorioUdemy.Application.Models.Responses;

namespace LaboratorioUdemy.Application.Interfaces.Services
{
    public interface IInstructorService
    {
        public GenericResponse<InstructorDto> Create(CreateInstructorRequest model);
        public GenericResponse<InstructorDto?> Get(Guid instructorId);
        public GenericResponse<List<InstructorDto>> Get(int limit, int offset);
    }
}
