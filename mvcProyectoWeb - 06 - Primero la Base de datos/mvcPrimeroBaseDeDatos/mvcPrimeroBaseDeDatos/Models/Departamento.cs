using System;
using System.Collections.Generic;

namespace mvcPrimeroBaseDeDatos.Models;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string? NombreDepartamento { get; set; }

    public string? Detalle { get; set; }

    public int? PaisId { get; set; }

    public virtual Pai? Pais { get; set; }
}
