using System;
using System.Collections.Generic;

namespace CONCURSO_INTERNO_PERSONAL.Models;

public partial class SolicitudSueldo
{
    public int IdSolicSueldo { get; set; }

    public int Idpersonal { get; set; }

    public int SueldoSolic { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual Personal IdpersonalNavigation { get; set; } = null!;

    public virtual ICollection<PersonalPuesto> PersonalPuestos { get; set; } = new List<PersonalPuesto>();
}
