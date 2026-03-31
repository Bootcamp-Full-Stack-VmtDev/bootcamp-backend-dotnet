using LaboratorioUdemy.Application.Models.DTOs;
using LaboratorioUdemy.Application.Models.Requests.Instructor;
using LaboratorioUdemy.Application.Models.Responses;

namespace LaboratorioUdemy.Application.Interfaces.Services
{
    public interface IInstructorService
    {
        public Task<GenericResponse<InstructorDto>> Create(CreateInstructorRequest model);
        public Task<GenericResponse<InstructorDto>> Get(Guid instructorId);
        public GenericResponse<List<InstructorDto>> Get(FilterInstructorRequest model);
        public Task<GenericResponse<bool>> Delete(Guid instructorId);

        public Task<GenericResponse<InstructorDto>> Update(Guid instructorId, UpdateInstructorRequest model);
    }
}
