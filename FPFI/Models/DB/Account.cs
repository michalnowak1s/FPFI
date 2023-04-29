using System;
using System.Collections.Generic;

namespace FPFI.Models.DB;

public partial class Account
{
    public int AccountId { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }
}
