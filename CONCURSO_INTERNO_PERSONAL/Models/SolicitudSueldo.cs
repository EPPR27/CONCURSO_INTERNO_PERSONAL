using System;
using System.Collections.Generic;

namespace CONCURSO_INTERNO_PERSONAL.Models;

public partial class SolicitudSueldo
{
    public int IdSolicSueldo { get; set; }

    public int Idpersonal { get; set; }

    public int SueldoSolic { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual Personal oPersonal { get; set; } = null!;

}
