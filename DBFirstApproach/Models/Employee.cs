using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBFirstApproach.Models;

public partial class Employee
{
    public int EmpNo { get; set; }

    public string Name { get; set; } = null!;

    public decimal Basic { get; set; }

    public int DeptNo { get; set; }

    [Display(Name = "Department")]
    public virtual Department? DeptNoNavigation { get; set; } = null!;
}
