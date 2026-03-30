using System;
using System.Collections.Generic;

namespace LaboratorioUdemy.Domain;

public partial class Categorium
{
    public int CategoriaId { get; set; }

    public string Nombre { get; set; } = null!;

    public int? CategoriaPadreId { get; set; }

    public virtual Categorium? CategoriaPadre { get; set; }

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();

    public virtual ICollection<Categorium> InverseCategoriaPadre { get; set; } = new List<Categorium>();
}
