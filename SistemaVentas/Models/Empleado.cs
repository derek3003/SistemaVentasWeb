using System;
using System.Collections.Generic;

namespace SistemaVentas.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? Nombre { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Telefono { get; set; }

    public DateTime? FechaContratacion { get; set; }

    public int? IdCargo { get; set; }

    public string? Usuario { get; set; }

    public string? Clave { get; set; }

    public virtual Cargo? IdCargoNavigation { get; set; }
}
