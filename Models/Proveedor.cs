using System;
using System.Collections.Generic;

namespace OzzyWeb1.Models;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string Ubicacion { get; set; } = null!;

    public string NoProveedor { get; set; } = null!;

    public int? PersonaIdPersona { get; set; }

    public virtual Persona? PersonaIdPersonaNavigation { get; set; }

    public virtual ICollection<Producto> ProductoIdProductos { get; set; } = new List<Producto>();
}
