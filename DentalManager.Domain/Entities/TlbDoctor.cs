using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbDoctor
{
    public long PersonnelCode { get; set; }

    public string? AccountDetailCode { get; set; }

    public string? UserId { get; set; }

    public short Expertise { get; set; }

    public int TimeScheduleId { get; set; }

    public string? LicenseNumber { get; set; }

    public DateTime RegisterDate { get; set; }

    public int? TlbOfficeid { get; set; }

    public virtual ICollection<TlbDoctorTimeSchedule> TlbDoctorTimeSchedules { get; set; } = new List<TlbDoctorTimeSchedule>();

    public virtual ICollection<TlbFactorsCost> TlbFactorsCosts { get; set; } = new List<TlbFactorsCost>();

    public virtual ICollection<TlbLabOrder> TlbLabOrders { get; set; } = new List<TlbLabOrder>();

    public virtual TlbOfficeBuilding? TlbOffice { get; set; }

    public virtual ICollection<TlbPatientsFolder> TlbPatientsFolders { get; set; } = new List<TlbPatientsFolder>();

    public virtual ICollection<TlbService> TlbServices { get; set; } = new List<TlbService>();

    public virtual AspNetUser? User { get; set; }
}
