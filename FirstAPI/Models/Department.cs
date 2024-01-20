using System;
using System.Collections.Generic;

namespace FirstAPI.Models;

public partial class Department
{
    public int DeptNo { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
