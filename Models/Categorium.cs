using System;
using System.Collections.Generic;

namespace OzzyWeb1.Models;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public int? EstudianteIdEstudiante { get; set; }

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();

    public virtual Estudiante? EstudianteIdEstudianteNavigation { get; set; }
}
