using System;
using System.Collections.Generic;

namespace SistemaVentas.Models;

public partial class MovimientoCompra
{
    public int IdCompra { get; set; }

    public DateTime? FechaCompra { get; set; }

    public int? IdProveedor { get; set; }

    public decimal? TotalCompra { get; set; }

    public string? Detalle { get; set; }

    public virtual Proveedore? IdProveedorNavigation { get; set; }
}
