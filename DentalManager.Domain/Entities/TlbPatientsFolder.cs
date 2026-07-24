using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbPatientsFolder
{
    public long Folderid { get; set; }

    public string? Name { get; set; }

    public string? Family { get; set; }

    public bool Gender { get; set; }

    public string? FatherName { get; set; }

    public string? AddressHome { get; set; }

    public string? Phone { get; set; }

    public string? Phone2 { get; set; }

    public string? NationalCode { get; set; }

    public long DoctorId { get; set; }

    public short EducationId { get; set; }

    public string? Job { get; set; }

    public bool Married { get; set; }

    public string? City { get; set; }

    public string? Bio { get; set; }

    public string? HabitsDiscription { get; set; }

    public string? Badhabits { get; set; }

    public string? MedicalHistory { get; set; }

    public string? DrugHistory { get; set; }

    public bool ConsumeDrug { get; set; }

    public bool Insurance { get; set; }

    public bool ActiveInsurance { get; set; }

    public string? Representative { get; set; }

    public int InsuranceNumber { get; set; }

    public double InsuranceAmount { get; set; }

    public int Insurer { get; set; }

    public bool Pregnant { get; set; }

    public short Pmonth { get; set; }

    public DateTime? FromInsuranceDate { get; set; }

    public DateTime? ToInsuranceDate { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? BirthDateTime { get; set; }

    public string? FingerPrintUrl { get; set; }

    public virtual TlbDoctor Doctor { get; set; } = null!;

    public virtual ICollection<TlbCzechBook> TlbCzechBooks { get; set; } = new List<TlbCzechBook>();

    public virtual ICollection<TlbExitGood> TlbExitGoods { get; set; } = new List<TlbExitGood>();

    public virtual ICollection<TlbFolderDocsAttachment> TlbFolderDocsAttachments { get; set; } = new List<TlbFolderDocsAttachment>();

    public virtual ICollection<TlbLabOrder> TlbLabOrders { get; set; } = new List<TlbLabOrder>();

    public virtual ICollection<TlbPayment> TlbPayments { get; set; } = new List<TlbPayment>();

    public virtual ICollection<TlbReserf> TlbReserves { get; set; } = new List<TlbReserf>();

    public virtual ICollection<TlbTreatmentDrug> TlbTreatmentDrugs { get; set; } = new List<TlbTreatmentDrug>();

    public virtual ICollection<TlbTreatmentPlan> TlbTreatmentPlans { get; set; } = new List<TlbTreatmentPlan>();

    public virtual ICollection<TlbSystematicDisease> Diseases { get; set; } = new List<TlbSystematicDisease>();
}
