using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbReserf
{
    public long Id { get; set; }

    public long? PlanId { get; set; }

    public int Priority { get; set; }

    public DateTime ReserveDate { get; set; }

    public DateTime UpdateDatetime { get; set; }

    public DateTime? CancelDatetime { get; set; }

    public TimeOnly StartReserveTime { get; set; }

    public TimeOnly EndReserveTime { get; set; }

    public long PatientId { get; set; }

    public string? Title { get; set; }

    public string? RegisterStatus { get; set; }

    public bool Consent { get; set; }

    public bool TypeConsent { get; set; }

    public short Status { get; set; }

    public string? CancelReason { get; set; }

    public double TotalCost { get; set; }

    public double Off { get; set; }

    public double InsuranceContribution { get; set; }

    public double PaidAmount { get; set; }

    public string? Smsdoctor { get; set; }

    public string? Smspatient { get; set; }

    public virtual TlbPatientsFolder Patient { get; set; } = null!;

    public virtual TlbTreatmentPlan? Plan { get; set; }

    public virtual ICollection<TlbInsurenceConsume> TlbInsurenceConsumes { get; set; } = new List<TlbInsurenceConsume>();

    public virtual ICollection<TlbPayment> TlbPayments { get; set; } = new List<TlbPayment>();

    public virtual ICollection<TlbVTreatmentService> TlbVTreatmentServices { get; set; } = new List<TlbVTreatmentService>();
}
