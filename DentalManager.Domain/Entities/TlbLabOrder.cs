using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbLabOrder
{
    public long OrderId { get; set; }

    public string? OrderCode { get; set; }

    public long DocttorId { get; set; }

    public long Patientd { get; set; }

    public int LabId { get; set; }

    public string? WorkType { get; set; }

    public short ReadyDays { get; set; }

    public short Color { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public double CostOffice { get; set; }

    public DateTime Creation { get; set; }

    public bool Status { get; set; }

    public string? Discription { get; set; }

    public bool Cancel { get; set; }

    public int CostId { get; set; }

    public virtual TlbCost Cost { get; set; } = null!;

    public virtual TlbDoctor Docttor { get; set; } = null!;

    public virtual Tlblaboratory Lab { get; set; } = null!;

    public virtual TlbPatientsFolder PatientdNavigation { get; set; } = null!;

    public virtual ICollection<TlbLabServiceOrder> TlbLabServiceOrders { get; set; } = new List<TlbLabServiceOrder>();
}
