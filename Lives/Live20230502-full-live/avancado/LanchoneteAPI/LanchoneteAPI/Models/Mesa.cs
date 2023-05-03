using System;
using System.Collections.Generic;

namespace LanchoneteAPI.Models;

public partial class Mesa
{
    public int Id { get; set; }

    public int IdFuncionario { get; set; }

    public string? Nome { get; set; }

    public string? Situacao { get; set; }

    public DateTime? Data { get; set; }

    public int? IdEmpresa { get; set; }

    public virtual Empresa? IdEmpresaNavigation { get; set; }

    public virtual Funcionario IdNavigation { get; set; } = null!;

    public virtual ICollection<MesasPedido> MesasPedidos { get; set; } = new List<MesasPedido>();
}
