using System;
using System.Collections.Generic;

namespace LanchoneteAPI.Models;

public partial class Empresa
{
    public int Id { get; set; }

    public string? RazaoSocial { get; set; }

    public string? Cnpj { get; set; }

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

    public virtual ICollection<Mesa> Mesas { get; set; } = new List<Mesa>();

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
