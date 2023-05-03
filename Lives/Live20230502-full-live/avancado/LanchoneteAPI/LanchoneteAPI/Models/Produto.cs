using System;
using System.Collections.Generic;

namespace LanchoneteAPI.Models;

public partial class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public decimal PrecoCusto { get; set; }

    public int EstoqueAtual { get; set; }

    public int EstoqueMinimo { get; set; }

    public decimal? PrecoVenda { get; set; }

    public int? IdEmpresa { get; set; }

    public virtual Empresa? IdEmpresaNavigation { get; set; }

    public virtual ICollection<MesasPedido> MesasPedidos { get; set; } = new List<MesasPedido>();
}
