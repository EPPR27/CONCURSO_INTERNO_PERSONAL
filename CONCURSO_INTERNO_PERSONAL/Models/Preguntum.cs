using System;
using System.Collections.Generic;

namespace CONCURSO_INTERNO_PERSONAL.Models;

public partial class Preguntum
{
    public int IdPregunta { get; set; }

    public string Enunciado { get; set; } = null!;

    public string OpcionA { get; set; } = null!;

    public string OpcionB { get; set; } = null!;

    public string OpcionC { get; set; } = null!;

    public string OpcionD { get; set; } = null!;

    public string RespuestaCorrecta { get; set; } = null!;

    public virtual ICollection<Prueba> Pruebas { get; set; } = new List<Prueba>();
}
