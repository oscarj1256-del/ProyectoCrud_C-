using System;
using System.Collections.Generic;

namespace OzzyWeb1.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string CodProducto { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public decimal Valor { get; set; }

    public string Descripcion { get; set; } = null!;

    public int InventarioIdInventario { get; set; }

    public virtual Inventario InventarioIdInventarioNavigation { get; set; } = null!;

    public virtual ICollection<Proveedor> ProveedorIdProveedors { get; set; } = new List<Proveedor>();
}
