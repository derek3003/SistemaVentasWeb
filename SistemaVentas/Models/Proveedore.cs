using System;
using System.Collections.Generic;

namespace SistemaVentas.Models;

public partial class Proveedore
{
    public int IdProveedor { get; set; }

    public string? NombreEmpresa { get; set; }

    public string? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public virtual ICollection<MovimientoCompra> MovimientoCompras { get; set; } = new List<MovimientoCompra>();
}
