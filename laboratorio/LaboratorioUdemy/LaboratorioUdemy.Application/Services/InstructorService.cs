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

            return ResponseHelper.Create(instructor, "Instructor creado con exito!");
        }

        public GenericResponse<InstructorDto?> Get(Guid instructorId)
        {
            var instructor = cache.Get(instructorId.ToString());
            return ResponseHelper.Create(instructor);
        }

        public PagedResponse<InstructorDto> Get(int limit, int offset)
        {
            var instructores = cache.Get();
            var total = instructores.Count;
            var data = instructores
                .Skip(offset)
                .Take(limit == 0 ? total : limit)
                .ToList();

            return ResponseHelper.CreatePaged(data, total, limit, offset);
        }

        public GenericResponse<bool> Delete(Guid instructorId)
        {
            var siExiste = cache.Get(instructorId.ToString());
            if (siExiste is null)
            {
                return ResponseHelper.Create(false);
            }

            cache.Delete(instructorId.ToString());
            return ResponseHelper.Create(true);
        }

        public GenericResponse<InstructorDto> Update(Guid instructorId, UpdateInstructorRequest model)
        {
            var instructor = cache.Get(instructorId.ToString());
            if (instructor is null)
            {
                return ResponseHelper.Create<InstructorDto>(null, "Instructor no encontrado");
            }

            if (!string.IsNullOrWhiteSpace(model.Name))
                instructor.Name = model.Name;

            if (!string.IsNullOrWhiteSpace(model.Email))
                instructor.Email = model.Email;

            return ResponseHelper.Create<InstructorDto>(null, "Instructor actualizado correctamente");
        }
    }
}
