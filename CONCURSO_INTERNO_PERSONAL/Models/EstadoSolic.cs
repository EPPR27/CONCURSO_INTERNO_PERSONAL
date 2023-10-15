using System;
using System.Collections.Generic;

namespace CONCURSO_INTERNO_PERSONAL.Models;

public partial class EstadoSolic
{
    public int IdEstado { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<AprobacionSueldo> AprobacionSueldos { get; set; } = new List<AprobacionSueldo>();
}
