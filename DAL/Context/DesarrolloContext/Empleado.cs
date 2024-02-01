﻿using System;
using System.Collections.Generic;

namespace DAL.Context.DesarrolloContext;

public partial class Empleado
{
    public int id_Empleado { get; set; }

    public string? nombre { get; set; }

    public string? apellido { get; set; }

    public int? DNI { get; set; }

    public string? fecha_nac { get; set; }

    public string? CUIT { get; set; }

    public string? MAIL { get; set; }

    public string? TURNO { get; set; }

    public int? EMPRESA { get; set; }

    public int? TIENDA { get; set; }

    public int? PUESTO { get; set; }

    public string? FECHA_ALTA { get; set; }

    public string? FECHA_BAJA { get; set; }

    public int? COD_OPERARIO { get; set; }

    public string? CALLE { get; set; }

    public int? ALTURA_CALLE { get; set; }

    public string? LOCALIDAD { get; set; }

    public int? COD_POSTAL { get; set; }

    public int? COMPANIA_CEL { get; set; }

    public int? TELEFONO { get; set; }

    public string? NRO_CUENTA { get; set; }

    public string? BANCO { get; set; }

    public string? VTO_FECHA_SANITARIA { get; set; }

    public string? UNIFORME { get; set; }

    public string? TALLE_PANTALON { get; set; }

    public string? TALLE_CHOMBA { get; set; }
}
