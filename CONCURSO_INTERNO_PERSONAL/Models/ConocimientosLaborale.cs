using System;
using System.Collections.Generic;

namespace CONCURSO_INTERNO_PERSONAL.Models;

public partial class ConocimientosLaborale
{
    public int IdCl { get; set; }

    public string NomCl { get; set; } = null!;

    public virtual ICollection<PerfilPuesto> PerfilPuestos { get; set; } = new List<PerfilPuesto>();

    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();
}
