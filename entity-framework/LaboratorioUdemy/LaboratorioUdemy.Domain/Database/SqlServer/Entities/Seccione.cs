using System;
using System.Collections.Generic;

namespace LaboratorioUdemy.Domain.Database.SqlServer.Entities;

public partial class Seccione
{
    public int SeccionId { get; set; }

    public int CursoId { get; set; }

    public string Titulo { get; set; } = null!;

    public int Orden { get; set; }

    public virtual Curso Curso { get; set; } = null!;

    public virtual ICollection<Leccione> Lecciones { get; set; } = new List<Leccione>();
}
