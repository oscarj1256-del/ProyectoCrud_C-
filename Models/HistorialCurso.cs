using System;
using System.Collections.Generic;

namespace OzzyWeb1.Models;

public partial class HistorialCurso
{
    public int IdHistorialCurso { get; set; }

    public string? CursosTomados { get; set; }

    public string? CantidadCurso { get; set; }

    public int? EstudianteIdEstudiante { get; set; }

    public int? CursoIdCurso { get; set; }

    public virtual Curso? CursoIdCursoNavigation { get; set; }

    public virtual Estudiante? EstudianteIdEstudianteNavigation { get; set; }
}
