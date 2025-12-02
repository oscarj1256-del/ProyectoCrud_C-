using System;
using System.Collections.Generic;

namespace OzzyWeb1.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public decimal Monto { get; set; }

    public DateOnly FechaPago { get; set; }

    public string Metodo { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public int EstudianteIdEstudiante { get; set; }

    public virtual Estudiante EstudianteIdEstudianteNavigation { get; set; } = null!;

    public virtual ICollection<Curso> CursoIdCursos { get; set; } = new List<Curso>();
}
