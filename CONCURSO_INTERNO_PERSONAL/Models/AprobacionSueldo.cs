using System;
using System.Collections.Generic;

namespace CONCURSO_INTERNO_PERSONAL.Models;

public partial class AprobacionSueldo
{
    public int IdAprobacion { get; set; }

    public string? Dni { get; set; }

    public int? IdEstado { get; set; }

    public virtual Personal? DniNavigation { get; set; }

    public virtual EstadoSolic? IdEstadoNavigation { get; set; }
}
