using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbDrug
{
    public int Id { get; set; }

    public string? ScientificName { get; set; }

    public short GroupDrug { get; set; }

    public bool Usepregnancy { get; set; }

    public string? Sideeffects { get; set; }

    public short Shape { get; set; }

    public string? ConsumeMethod { get; set; }

    public string? MedicalInfo { get; set; }

    public string? Contraindications { get; set; }

    public double Drugdose { get; set; }

    public virtual ICollection<TlbTreatmentDrug> TlbTreatmentDrugs { get; set; } = new List<TlbTreatmentDrug>();
}
