using LaboratorioUdemy.Application.Helpers;
using LaboratorioUdemy.Application.Interfaces.Services;
using LaboratorioUdemy.Application.Models.DTOs;
using LaboratorioUdemy.Application.Models.Requests.Instructor;
using LaboratorioUdemy.Application.Models.Responses;
using LaboratorioUdemy.Shared;
using LaboratorioUdemy.Shared.Helpers;

namespace LaboratorioUdemy.Application.Services
{
    public class InstructorService(Cache<InstructorDto> cache) : IInstructorService
    {
        public GenericResponse<InstructorDto> Create(CreateInstructorRequest model)
        {
            var instructor = new InstructorDto
            {
                InstructorId = Guid.NewGuid(),
                Name = model.Name,
                Email = model.Email,
                RegisterDate = DateTimeHelper.UtcNow()
            };

            cache.Add(instructor.InstructorId.ToString(), instructor);

            return ResponseHelper.Create(instructor);
        }

        public GenericResponse<InstructorDto?> Get(Guid instructorId)
        {
            var instructor = cache.Get(instructorId.ToString());
            return ResponseHelper.Create(instructor);
        }
    }
}
