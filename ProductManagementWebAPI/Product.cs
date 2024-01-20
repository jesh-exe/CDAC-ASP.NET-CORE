using System;
using System.Collections.Generic;

namespace ProductManagementWebAPI;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Qty { get; set; }

    public decimal? Price { get; set; }

    public string? Url { get; set; }

    public string? Desc { get; set; }
}
