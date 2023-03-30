using System;
using System.Collections.Generic;

namespace AspnetWebApiDoisContextos.Models;

public partial class Carteira
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime DataInclusao { get; set; }

    public int UsuarioId { get; set; }

    public virtual ICollection<Transaco> Transacos { get; } = new List<Transaco>();

    public virtual Usuario Usuario { get; set; } = null!;
}
