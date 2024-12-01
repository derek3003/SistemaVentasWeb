using System;
using System.Collections.Generic;

namespace SistemaVentas.Models;

public partial class Inventario
{
    public int IdProducto { get; set; }

    public int? CantidadDisponible { get; set; }

    public decimal? PrecioCompra { get; set; }

    public decimal? PrecioVenta { get; set; }

    public DateTime? FechaUltimaActualizacion { get; set; }
}
