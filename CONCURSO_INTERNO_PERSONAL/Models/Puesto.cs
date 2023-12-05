using System;
using System.Collections.Generic;

namespace CONCURSO_INTERNO_PERSONAL.Models;

public partial class Puesto
{
    public int IdPuesto { get; set; }

    public string NomPuesto { get; set; } = null!;

    public decimal Sueldo { get; set; }

    public virtual ICollection<PerfilPuesto> PerfilPuestos { get; set; } = new List<PerfilPuesto>();

    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();
}
