using System;
using System.Collections.Generic;

namespace BancoExemplo2.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public byte Active { get; set; }

    public int StoreId { get; set; }

    public int? ManagerId { get; set; }

    public virtual ICollection<Staff> InverseManager { get; } = new List<Staff>();

    public virtual Staff? Manager { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual Store Store { get; set; } = null!;
}
