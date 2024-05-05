using System;
using System.Collections.Generic;

namespace MP.Models;

public partial class PickUpPoint
{
    public int Id { get; set; }

    public string? Adress { get; set; }

    public decimal? Rating { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
