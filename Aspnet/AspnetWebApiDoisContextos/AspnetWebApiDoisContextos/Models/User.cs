using System;
using System.Collections.Generic;

namespace AspnetWebApiDoisContextos.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public DateTime DataInclusao { get; set; }
}
