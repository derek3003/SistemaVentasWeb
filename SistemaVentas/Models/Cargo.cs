using System;
using System.Collections.Generic;

namespace SistemaVentas.Models;

public partial class Cargo
{
    public int IdCargo { get; set; }

    public string? NombreCargo { get; set; }

    public string? Descripcion { get; set; }

    public decimal? SalarioBase { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
