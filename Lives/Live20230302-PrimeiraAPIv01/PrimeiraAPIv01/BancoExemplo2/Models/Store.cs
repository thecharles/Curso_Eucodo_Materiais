using System;
using System.Collections.Generic;

namespace BancoExemplo2.Models;

public partial class Store
{
    public int StoreId { get; set; }

    public string StoreName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<Staff> Staff { get; } = new List<Staff>();

    public virtual ICollection<Stock> Stocks { get; } = new List<Stock>();
}
