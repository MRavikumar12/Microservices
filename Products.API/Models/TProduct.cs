using System;
using System.Collections.Generic;

namespace Products.API.Models;

public partial class TProduct
{
    public int ProdId { get; set; }

    public string? ProdName { get; set; }

    public int? ProdPrice { get; set; }

    public string? ProdDesc { get; set; }
}
