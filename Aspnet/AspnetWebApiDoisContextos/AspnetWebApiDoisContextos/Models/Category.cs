using System;
using System.Collections.Generic;

namespace AspnetWebApiDoisContextos.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
