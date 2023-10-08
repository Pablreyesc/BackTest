using System;
using System.Collections.Generic;

namespace Prueba.Models;

public partial class Comentario
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public int? IdImagen { get; set; }

    public virtual Imagen? IdImagenNavigation { get; set; }
}
