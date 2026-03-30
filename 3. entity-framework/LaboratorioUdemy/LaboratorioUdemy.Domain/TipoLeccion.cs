using System;
using System.Collections.Generic;

namespace LaboratorioUdemy.Domain;

public partial class TipoLeccion
{
    public int TipoLeccionId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Leccione> Lecciones { get; set; } = new List<Leccione>();
}
