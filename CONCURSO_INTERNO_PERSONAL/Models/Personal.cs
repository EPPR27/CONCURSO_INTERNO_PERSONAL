using System;
using System.Collections.Generic;

namespace CONCURSO_INTERNO_PERSONAL.Models;

public partial class Personal
{
    public string Dni { get; set; } = null!;

    public string NombapePers { get; set; } = null!;

    public int? IdHb { get; set; }

    public int? IdCl { get; set; }

    public string? RefeLaboral { get; set; }

    public int? Ppc { get; set; }

    public int? Pcv { get; set; }

    public int? Pentrevista { get; set; }

    public int? IdPuesto { get; set; }

    public int? IdPruebasMedicas { get; set; }

    public virtual ICollection<AprobacionSueldo> AprobacionSueldos { get; set; } = new List<AprobacionSueldo>();

    public virtual ConocimientosLaborale? IdClNavigation { get; set; }

    public virtual HabilidadesBlanda? IdHbNavigation { get; set; }

    public virtual PruebasMedica? IdPruebasMedicasNavigation { get; set; }

    public virtual Puesto? IdPuestoNavigation { get; set; }

    public virtual ICollection<SolicitudSueldo> SolicitudSueldos { get; set; } = new List<SolicitudSueldo>();
}
