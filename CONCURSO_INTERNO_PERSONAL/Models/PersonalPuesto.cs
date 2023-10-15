using System;
using System.Collections.Generic;

namespace CONCURSO_INTERNO_PERSONAL.Models;

public partial class PersonalPuesto
{
    public int IdPerPuesto { get; set; }

    public int IdSolicSueldo { get; set; }

    public int IdPuesto { get; set; }

    public virtual Puesto IdPuestoNavigation { get; set; } = null!;

    public virtual SolicitudSueldo IdSolicSueldoNavigation { get; set; } = null!;
}
