using LaboratorioUdemy.Application.Models.DTOs;
using LaboratorioUdemy.Application.Models.Requests.Instructor;
using LaboratorioUdemy.Application.Models.Responses;

namespace LaboratorioUdemy.Application.Interfaces.Services
{
    public interface IInstructorService
    {
        public GenericResponse<InstructorDto> Create(CreateInstructorRequest model);
    }
}
