using System;
using System.Collections.Generic;

namespace AspnetWebApiDoisContextos.Models;

public partial class Transaco
{
    public int Id { get; set; }

    public DateTime Data { get; set; }

    public string Moeda { get; set; } = null!;

    public decimal Quantidade { get; set; }

    public decimal ValorAportado { get; set; }

    public decimal ValorMoeda { get; set; }

    public int CarteiraId { get; set; }

    public decimal ValorCorretora { get; set; }

    public DateTime DataInclusao { get; set; }

    public virtual Carteira Carteira { get; set; } = null!;
}
