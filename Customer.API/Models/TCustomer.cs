using System;
using System.Collections.Generic;

namespace Customer.API.Models;

public partial class TCustomer
{
    public int CustId { get; set; }

    public string? CustName { get; set; }

    public string? CustAddress { get; set; }

    public int? PhoneNo { get; set; }
}
