using System;
using System.Collections.Generic;

namespace SucursalesABM.Models;

public partial class Sucursale
{
    public int SucursalId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Provincia { get; set; } = null!;

    public string CodigoPostal { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly FechaApertura { get; set; }

    public string Estado { get; set; } = null!;
}
