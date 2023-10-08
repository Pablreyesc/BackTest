using System;
using System.Collections.Generic;

namespace Prueba.Models;

public partial class Imagen
{
    public int Id { get; set; }

    public byte[] Imagen1 { get; set; } 

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
}
