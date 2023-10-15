using System;
using System.Collections.Generic;

namespace CONCURSO_INTERNO_PERSONAL.Models;

public partial class SolicitudSueldo
{
    public int IdSolicSueldo { get; set; }

    public string Dni { get; set; } = null!;

    public int SueldoSolic { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual Personal DniNavigation { get; set; } = null!;

    public virtual ICollection<PersonalPuesto> PersonalPuestos { get; set; } = new List<PersonalPuesto>();
}
