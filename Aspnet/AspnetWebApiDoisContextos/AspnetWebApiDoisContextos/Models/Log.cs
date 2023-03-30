using System;
using System.Collections.Generic;

namespace AspnetWebApiDoisContextos.Models;

public partial class Log
{
    public int Id { get; set; }

    public DateTime Data { get; set; }

    public string Tipo { get; set; } = null!;

    public string Mensagem { get; set; } = null!;
}
