using System;
using System.Collections.Generic;

namespace MP.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Price { get; set; }

    public int? Rating { get; set; }

    public int? IdSeller { get; set; }

    public int? Amount { get; set; }

    public virtual Seller? IdSellerNavigation { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
}
