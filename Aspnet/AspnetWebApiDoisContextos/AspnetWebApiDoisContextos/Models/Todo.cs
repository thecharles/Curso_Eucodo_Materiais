using System;
using System.Collections.Generic;

namespace AspnetWebApiDoisContextos.Models;

public partial class Todo
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public DateTime? DataInclusao { get; set; }
}
