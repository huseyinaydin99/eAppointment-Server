using eAppointmentServer.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAppointmentServer.Domain.Entities;

public sealed class Doctor
{
    public Guid Id { get; set; }
    public Doctor()
    {
        Id = Guid.NewGuid();
    }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ", FirstName, LastName);
    public DepartmentEnum Department { get; set; } = DepartmentEnum.Gastroenteroloji;
}