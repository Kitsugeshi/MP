using System;
using System.Collections.Generic;

namespace MP.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int? IdRole { get; set; }

    public int? IdPickUpPoint { get; set; }

    public int? Salary { get; set; }

    public virtual PickUpPoint? IdPickUpPointNavigation { get; set; }

    public virtual Role? IdRoleNavigation { get; set; }

    public virtual ICollection<ProductIssuance> ProductIssuances { get; set; } = new List<ProductIssuance>();
}
