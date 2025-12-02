using System;
using System.Collections.Generic;

namespace OzzyWeb1.Models;

public partial class Curso
{
    public int IdCurso { get; set; }

    public string Duracion { get; set; } = null!;

    public string NumeroCurso { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Detalle { get; set; } = null!;

    public decimal Costo { get; set; }

    public string? NivelAprendizaje { get; set; }

    public int CategoriaIdCategoria { get; set; }

    public virtual Categorium? CategoriaIdCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<HistorialCurso>? HistorialCursos { get; set; } = new List<HistorialCurso>();

    public virtual ICollection<Pago>? PagoIdPagos { get; set; } = new List<Pago>();

    public virtual ICollection<Tutor>? TutorIdTutores { get; set; } = new List<Tutor>();
}
