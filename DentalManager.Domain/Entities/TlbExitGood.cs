using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbExitGood
{
    public int Id { get; set; }

    public string? DelivererPerson { get; set; }

    public string? TransfereePerson { get; set; }

    public DateTime ExitDate { get; set; }

    public TimeOnly ExitTime { get; set; }

    public int StockId { get; set; }

    public string? Discription { get; set; }

    public int Count { get; set; }

    public long? PatientsFolderFolderid { get; set; }

    public virtual TlbPatientsFolder? PatientsFolderFolder { get; set; }

    public virtual TlbStock Stock { get; set; } = null!;
}
