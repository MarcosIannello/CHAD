using System;
using System.Collections.Generic;

namespace DAL.Context.DesarrolloContext;

public partial class usuario_perfil
{
    public int id_usuario_perfil { get; set; }

    public int? ID_USUARIO { get; set; }

    public int? ID_PERFIL { get; set; }

    public virtual PERFILE? ID_PERFILNavigation { get; set; }

    public virtual USUARIOS_SIST? ID_USUARIONavigation { get; set; }
}
