using System;
using System.Collections.Generic;

namespace CONCURSO_INTERNO_PERSONAL.Models;

public partial class Preguntum
{
    public int IdPregunta { get; set; }

    public string? Enunciado { get; set; }

    public string? OpcionA { get; set; }

    public string? OpcionB { get; set; }

    public string? OpcionC { get; set; }

    public string? OpcionD { get; set; }

    public string? RespuestaCorrecta { get; set; }

    public virtual ICollection<Prueba> Pruebas { get; set; } = new List<Prueba>();
}
