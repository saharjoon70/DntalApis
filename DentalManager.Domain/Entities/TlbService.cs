using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbService
{
    public int Id { get; set; }

    public long DoctorId { get; set; }

    public int Group { get; set; }

    public string? Title { get; set; }

    public double CostServices { get; set; }

    public long? RelDoctorPersonnelCode { get; set; }

    public virtual TlbDoctor? RelDoctorPersonnelCodeNavigation { get; set; }

    public virtual ICollection<TlbInsurenceSrvice> TlbInsurenceSrvices { get; set; } = new List<TlbInsurenceSrvice>();

    public virtual ICollection<TlbTreatmentService> TlbTreatmentServices { get; set; } = new List<TlbTreatmentService>();

    public virtual ICollection<TlbVTreatmentService> TlbVTreatmentServices { get; set; } = new List<TlbVTreatmentService>();
}
