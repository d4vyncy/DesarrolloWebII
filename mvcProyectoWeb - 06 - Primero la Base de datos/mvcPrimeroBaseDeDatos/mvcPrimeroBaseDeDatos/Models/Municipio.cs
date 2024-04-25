using System;
using System.Collections.Generic;

namespace mvcPrimeroBaseDeDatos.Models;

public partial class Municipio
{
    public int? IdMunicipio { get; set; }

    public string? NombreMunicipio { get; set; }

    public string? Detalle { get; set; }

    public int? DepartamentoId { get; set; }

    public virtual Departamento? Departamento { get; set; }
}
