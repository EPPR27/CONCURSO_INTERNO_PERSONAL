using System;
using System.Collections.Generic;

namespace CONCURSO_INTERNO_PERSONAL.Models;

public partial class Prueba
{
    public int IdResultado { get; set; }

    public int? IdPregunta { get; set; }

    public string? RespuestaCorrecta { get; set; }

    public int? Puntaje { get; set; }

    public virtual Preguntum? oPregunta { get; set; }
}
