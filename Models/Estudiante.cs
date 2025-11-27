using System;
using System.Collections.Generic;

namespace OzzyWeb1.Models;

public partial class Estudiante
{
    public int IdEstudiante { get; set; }

    public int? IdEstadoEstudiante { get; set; }

    public string Contraseña { get; set; } = null!;

    public string Progreso { get; set; } = null!;

    public int PersonaIdPersona { get; set; }

    public virtual ICollection<Acudiente> Acudientes { get; set; } = new List<Acudiente>();

    public virtual ICollection<Categorium> Categoria { get; set; } = new List<Categorium>();

    public virtual ICollection<HistorialCurso> HistorialCursos { get; set; } = new List<HistorialCurso>();

    public virtual EstadoAdim? IdEstadoEstudianteNavigation { get; set; }

    public virtual ICollection<Inscripcion> Inscripcions { get; set; } = new List<Inscripcion>();

    public virtual ICollection<Notificación> Notificacións { get; set; } = new List<Notificación>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual Persona PersonaIdPersonaNavigation { get; set; } = null!;
}
