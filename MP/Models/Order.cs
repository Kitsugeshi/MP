using System;
using System.Collections.Generic;

namespace MP.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? Price { get; set; }

    public int? IdPickUpPoint { get; set; }

    public int? IdClient { get; set; }

    public virtual Client? IdClientNavigation { get; set; }

    public virtual PickUpPoint? IdPickUpPointNavigation { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual ICollection<ProductIssuance> ProductIssuances { get; set; } = new List<ProductIssuance>();
}
