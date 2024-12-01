using System;
using System.Collections.Generic;

namespace SistemaVentas.Models;

public partial class MovimientoVenta
{
    public int IdVenta { get; set; }

    public DateTime? FechaVenta { get; set; }

    public int? IdCliente { get; set; }

    public decimal? TotalVenta { get; set; }

    public string? Detalle { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }
}
