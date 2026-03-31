using System;
using System.Collections.Generic;

namespace LaboratorioUdemy.Domain.Database.SqlServer.Entities;

public partial class Inscripcione
{
    public int InscripcionId { get; set; }

    public int EstudianteId { get; set; }

    public int CursoId { get; set; }

    public DateTime? FechaInscripcion { get; set; }

    public decimal PrecioPagado { get; set; }

    public string? CuponCodigo { get; set; }

    public virtual Curso Curso { get; set; } = null!;

    public virtual Estudiante Estudiante { get; set; } = null!;
}
