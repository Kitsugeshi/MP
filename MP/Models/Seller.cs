using System;
using System.Collections.Generic;

namespace MP.Models;

public partial class Seller
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
