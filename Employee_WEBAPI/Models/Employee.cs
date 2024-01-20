using System;
using System.Collections.Generic;

namespace Employee_WEBAPI.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Address { get; set; } = null!;
}
