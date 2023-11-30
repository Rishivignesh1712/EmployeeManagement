using System;
using System.Collections.Generic;

namespace EmployeeManagementAPI.Models.EF;

public partial class Employee
{
    public int Empno { get; set; }

    public string? EmpName { get; set; }

    public string? EmpDesignation { get; set; }

    public int? EmpSalary { get; set; }

    public int? DeptNo { get; set; }

    public string? EmpPermanent { get; set; }

    public virtual Department? DeptNoNavigation { get; set; }
}
