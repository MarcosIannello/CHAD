using System;
using System.Collections.Generic;

namespace DAL.Context.DesarrolloContext;

public partial class USUARIOS_SIST
{
    public int ID_USUARIO { get; set; }

    public int? ID_EMPLEADO { get; set; }

    public int? PERFIL { get; set; }

    public string? username { get; set; }

    public string? password { get; set; }
}
