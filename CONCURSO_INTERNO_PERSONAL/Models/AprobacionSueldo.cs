using System;
using System.Collections.Generic;

namespace CONCURSO_INTERNO_PERSONAL.Models;

public partial class AprobacionSueldo
{
    public int IdAprobacion { get; set; }

    public int? Idpersonal { get; set; }

    public int? IdEstado { get; set; }

    public virtual Personal? IdpersonalNavigation { get; set; }

    public virtual EstadoSolic? IdEstadoNavigation { get; set; }
}
