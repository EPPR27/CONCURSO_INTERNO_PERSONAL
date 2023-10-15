using System;
using System.Collections.Generic;

namespace CONCURSO_INTERNO_PERSONAL.Models;

public partial class Sede
{
    public int IdSede { get; set; }

    public string NomSede { get; set; } = null!;

    public virtual ICollection<PerfilPuesto> PerfilPuestos { get; set; } = new List<PerfilPuesto>();
}
