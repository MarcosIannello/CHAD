using System;
using System.Collections.Generic;

namespace DAL.Context.DesarrolloContext;

public partial class DOCUMENTOS_LOTE
{
    public int id { get; set; }

    public string? Nombre { get; set; }

    public int? id_estado { get; set; }

    public string? fecha_alta { get; set; }
}
