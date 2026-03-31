using System;
using System.Collections.Generic;

namespace LaboratorioUdemy.Domain.Database.SqlServer.Entities;

public partial class Resena
{
    public int EstudianteId { get; set; }

    public int CursoId { get; set; }

    public int? Calificacion { get; set; }

    public string Resena1 { get; set; } = null!;

    public DateTime? Fecha { get; set; }

    public virtual Curso Curso { get; set; } = null!;

    public virtual Estudiante Estudiante { get; set; } = null!;
}
