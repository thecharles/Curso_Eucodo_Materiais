using System;
using System.Collections.Generic;

namespace LanchoneteAPI.Models;

public partial class MesasPedido
{
    public int Id { get; set; }

    public int IdMesa { get; set; }

    public int IdProduto { get; set; }

    public int Quantidade { get; set; }

    public virtual Mesa IdMesaNavigation { get; set; } = null!;

    public virtual Produto IdProdutoNavigation { get; set; } = null!;
}
