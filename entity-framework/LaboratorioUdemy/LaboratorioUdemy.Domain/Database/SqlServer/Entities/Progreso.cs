using System;
using System.Collections.Generic;

namespace LaboratorioUdemy.Domain.Database.SqlServer.Entities;

public partial class Progreso
{
    public int EstudianteId { get; set; }

    public int LeccionId { get; set; }

    public DateTime? FechaTerminada { get; set; }

    public virtual Estudiante Estudiante { get; set; } = null!;

    public virtual Leccione Leccion { get; set; } = null!;
}
