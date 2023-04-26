using System;
using System.Collections.Generic;

namespace LanchoneteAPI.Models;

public partial class Funcionario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Cpf { get; set; }

    public string? Email { get; set; }

    public string? Perfil { get; set; }

    public string? Login { get; set; }

    public string? Senha { get; set; }

    public DateTime? DataUltimoAcesso { get; set; }

    public bool? Situacao { get; set; }

    public int? IdEmpresa { get; set; }

    public virtual Empresa? IdEmpresaNavigation { get; set; }

    public virtual Mesa? Mesa { get; set; }
}
