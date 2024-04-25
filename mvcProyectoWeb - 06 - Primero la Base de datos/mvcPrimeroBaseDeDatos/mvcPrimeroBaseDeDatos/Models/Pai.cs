using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcPrimeroBaseDeDatos.Models;

//[Table("Pais")]
public partial class Pai
{
    public int IdPais { get; set; }

    public string? NombrePais { get; set; }

    public string? Detalle { get; set; }

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}
