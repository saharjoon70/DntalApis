using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbTeethLab
{
    public int Id { get; set; }

    public short TeethKey { get; set; }

    public int ServiceKey { get; set; }

    public virtual TlbLabServiceOrder ServiceKeyNavigation { get; set; } = null!;
}
