using System;
using System.Collections.Generic;

namespace CONCURSO_INTERNO_PERSONAL.Models;

public partial class PerfilPuesto
{
    public int IdPp { get; set; }

    public int? IdPuesto { get; set; }

    public int? IdSede { get; set; }

    public int? IdHb { get; set; }

    public int? IdCl { get; set; }

    public virtual ConocimientosLaborale? IdClNavigation { get; set; }

    public virtual HabilidadesBlanda? IdHbNavigation { get; set; }

    public virtual Puesto? IdPuestoNavigation { get; set; }

    public virtual Sede? IdSedeNavigation { get; set; }
}
