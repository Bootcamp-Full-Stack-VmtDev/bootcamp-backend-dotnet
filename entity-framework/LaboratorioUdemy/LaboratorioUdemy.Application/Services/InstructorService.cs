using LaboratorioUdemy.Application.Helpers;
using LaboratorioUdemy.Application.Interfaces.Services;
using LaboratorioUdemy.Application.Models.DTOs;
using LaboratorioUdemy.Application.Models.Requests.Instructor;
using LaboratorioUdemy.Application.Models.Responses;
using LaboratorioUdemy.Domain.Database.SqlServer.Entities;
using LaboratorioUdemy.Domain.Interfaces.Repositories;

namespace LaboratorioUdemy.Application.Services
{
    public class InstructorService(IInstructorRepository repository) : IInstructorService
    {
        public async Task<GenericResponse<InstructorDto>> Create(CreateInstructorRequest model)
        {
            var create = await repository.Create(new Domain.Database.SqlServer.Entities.Instructore
            {
                Nombre = model.Name,
                Email = model.Email
            });

            return ResponseHelper.Create(Map(create), "Instructor creado con exito!");
        }

        public async Task<GenericResponse<InstructorDto>> Get(Guid instructorId)
        {
            var instructor = await GetInstructor(instructorId);
            return ResponseHelper.Create(Map(instructor));
        }

        public GenericResponse<List<InstructorDto>> Get(FilterInstructorRequest model)
        {
            var queryable = repository.Queryable();

            // Filtrado de nombre
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                queryable = queryable.Where(x => x.Nombre.Contains(model.Name ?? ""));
                //queryable = querybable.Where(x => x.Nombre != null && x => x.Nombre.Contains(model.Name ?? "")); //Valores que aceptan nulos
            }

            // Realizar paginacion y realizar consulta
            var instructors = queryable.Take(model.Limit).Skip(model.Offset).ToList();

            //Mapear instructores
            List<InstructorDto> mapped = [];

            foreach (var instructor in instructors)
            {
                mapped.Add(Map(instructor));
            }

            return ResponseHelper.Create(mapped);

        }

        public async Task<GenericResponse<bool>> Delete(Guid instructorId)
        {
            var instructor = await GetInstructor(instructorId);

            var delete = await repository.Delete(instructor);
            return ResponseHelper.Create(delete);
        }

        public async Task<GenericResponse<InstructorDto>> Update(Guid instructorId, UpdateInstructorRequest model)
        {
            var instructor = await GetInstructor(instructorId);

            instructor.Nombre = model.Name ?? instructor.Nombre;
            instructor.Email = model.Email ?? instructor.Email;

            var update = await repository.Update(instructor);
            return ResponseHelper.Create(Map(update));
        }

        private async Task<Instructore> GetInstructor(Guid instructorId)
        {
            return await repository.Get(instructorId)
                ?? throw new Exception("El instructor no existe");
        }

        private InstructorDto Map(Instructore instructor)
        {
            return new InstructorDto
            {
                InstructorId = instructor.InstructorId,
                Name = instructor.Nombre,
                Email = instructor.Email
            };
        }
    }
}
