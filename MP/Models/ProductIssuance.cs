using System;
using System.Collections.Generic;

namespace MP.Models;

public partial class ProductIssuance
{
    public int Id { get; set; }

    public int? IdEmployee { get; set; }

    public int? IdOrder { get; set; }

    public string? DateOfIssuance { get; set; }

    public virtual Employee? IdEmployeeNavigation { get; set; }

    public virtual Order? IdOrderNavigation { get; set; }
}
