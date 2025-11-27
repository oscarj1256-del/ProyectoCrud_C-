using System;
using System.Collections.Generic;

namespace OzzyWeb1.Models;

public partial class Inventario
{
    public int IdInventario { get; set; }

    public int Cantidad { get; set; }

    public DateTime? UltimaActualización { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public int StockMinimo { get; set; }

    public int StockMaximo { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
