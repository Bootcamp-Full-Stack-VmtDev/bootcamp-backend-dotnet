using System;
using System.Collections.Generic;

namespace LaboratorioUdemy.Domain;

public partial class Estudiante
{
    public int EstudianteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Inscripcione> Inscripciones { get; set; } = new List<Inscripcione>();

    public virtual ICollection<Progreso> Progresos { get; set; } = new List<Progreso>();

    public virtual ICollection<Resena> Resenas { get; set; } = new List<Resena>();

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
