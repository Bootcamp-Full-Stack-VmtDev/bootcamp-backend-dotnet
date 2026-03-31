using LaboratorioUdemy.Domain.Database.SqlServer.Context;
using LaboratorioUdemy.Domain.Database.SqlServer.Entities;
using LaboratorioUdemy.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioUdemy.Infrastructure.Persistence.SqlServer.Repositories
{
    public class InstructorRepository(UdemyClonContext context) : IInstructorRepository
    {
        public async Task<Instructore> Create(Instructore instructor)
        {
            try
            {
                await context.Instructores.AddAsync(instructor);
                await context.SaveChangesAsync();
                return instructor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(Instructore instructor)
        {
            try
            {
                context.Instructores.Update(instructor);
                var deleteCount = await context.SaveChangesAsync();

                return deleteCount > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Instructore?> Get(Guid instructorId)
        {
            try
            {
                return await context.Instructores.FirstOrDefaultAsync(x => x.InstructorId == instructorId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> IfExists(Guid instructorId)
        {
            try
            {
                return await context.Instructores.AnyAsync(x => x.InstructorId == instructorId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<Instructore> Queryable()
        {
            try
            {
                return context.Instructores.AsQueryable();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Instructore> Update(Instructore instructor)
        {
            try
            {
                context.Instructores.Update(instructor);
                await context.SaveChangesAsync();

                return instructor;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
