using System;
using System.Collections.Generic;

namespace DAL.Context.DesarrolloContext;

public partial class RECIBOS_CARGADO
{
    public int ID_RECIBO { get; set; }

    public string? CUIT { get; set; }

    public int? ID_EMPLEADO { get; set; }

    public string? RECIBO_BASE64 { get; set; }

    public bool? FIRMADO { get; set; }
}
