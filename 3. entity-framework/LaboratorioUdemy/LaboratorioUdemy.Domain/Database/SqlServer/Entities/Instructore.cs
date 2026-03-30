using System;
using System.Collections.Generic;

namespace LaboratorioUdemy.Domain.Database.SqlServer.Entities;

public partial class Instructore
{
    public int InstructorId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
