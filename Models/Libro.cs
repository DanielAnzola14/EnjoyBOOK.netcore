using System;
using System.Collections.Generic;

namespace Proyecto.Models;

public partial class Libro
{
    public int IdLibro { get; set; }

    public string? NombreLibro { get; set; }

    public string? AutorLibro { get; set; }

    public string? EditorialLibro { get; set; }

    public int? NumPag { get; set; }

    public string? Caracteristicas { get; set; }
}
