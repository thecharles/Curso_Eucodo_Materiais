﻿using System;
using System.Collections.Generic;

namespace BancoExemplo2.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string BrandName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
