using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbFolderDocsAttachment
{
    public int Id { get; set; }

    public long FolderId { get; set; }

    public string? DocName { get; set; }

    public string? DocDiscription { get; set; }

    public string? DocPath { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public virtual TlbPatientsFolder Folder { get; set; } = null!;
}
