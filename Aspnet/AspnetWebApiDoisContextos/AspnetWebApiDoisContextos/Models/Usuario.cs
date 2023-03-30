using System;
using System.Collections.Generic;

namespace AspnetWebApiDoisContextos.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string? Senha { get; set; }

    public DateTime DataInclusao { get; set; }

    public DateTime? DataUltimoLogin { get; set; }

    public int QtdeLogin { get; set; }

    public string PrimeiroNome { get; set; } = null!;

    public string UltimoNome { get; set; } = null!;

    public bool Ativo { get; set; }

    public bool EmailValidado { get; set; }

    public DateTime? DataEmailValidado { get; set; }

    public virtual ICollection<Carteira> Carteiras { get; } = new List<Carteira>();
}
