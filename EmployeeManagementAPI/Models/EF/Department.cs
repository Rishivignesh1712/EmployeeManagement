using System;
using System.Collections.Generic;

namespace EmployeeManagementAPI.Models.EF;

public partial class Department
{
    public int DeptNo { get; set; }

    public string? DeptName { get; set; }

    public string? DeptLocation { get; set; }

    public string? DeptEmail { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
