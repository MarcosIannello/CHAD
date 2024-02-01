using System;
using System.Collections.Generic;

namespace DAL.Context.DesarrolloContext;

public partial class Empleado_tiendum
{
    public int id_emp_tienda { get; set; }

    public int? id_Empleado { get; set; }

    public int? ID_TIENDA { get; set; }

    public virtual TIENDA? ID_TIENDANavigation { get; set; }

    public virtual Empleado? id_EmpleadoNavigation { get; set; }
}
