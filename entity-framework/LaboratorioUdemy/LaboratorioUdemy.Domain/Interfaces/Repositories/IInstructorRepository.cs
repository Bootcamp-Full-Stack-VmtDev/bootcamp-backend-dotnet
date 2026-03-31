using LaboratorioUdemy.Domain.Database.SqlServer.Entities;

namespace LaboratorioUdemy.Domain.Interfaces.Repositories
{
    public interface IInstructorRepository
    {
        Task<Instructore> Create(Instructore instructor);
        Task<Instructore?> Get(Guid instructorId);
        IQueryable<Instructore> Queryable();
        Task<bool> IfExists(Guid instructorId);
        Task<Instructore> Update(Instructore instructor);
        Task<bool> Delete(Instructore instructor);

    }
}
