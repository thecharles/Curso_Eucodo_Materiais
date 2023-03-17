using System;
using System.Collections.Generic;

namespace TodoListAPI.Models;

public partial class Todo
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public DateTime? DataInclusao { get; set; }
}
