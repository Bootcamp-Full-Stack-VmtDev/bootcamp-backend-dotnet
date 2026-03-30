using System;
using System.Collections.Generic;

namespace LaboratorioUdemy.Domain;

public partial class Leccione
{
    public int LeccionId { get; set; }

    public int SeccionId { get; set; }

    public int TipoLeccionId { get; set; }

    public string Titulo { get; set; } = null!;

    public int DuracionSegundos { get; set; }

    public int Orden { get; set; }

    public virtual ICollection<Progreso> Progresos { get; set; } = new List<Progreso>();

    public virtual Seccione Seccion { get; set; } = null!;

    public virtual TipoLeccion TipoLeccion { get; set; } = null!;
}
