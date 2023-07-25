using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Data.Models;

[Table("TransferSyntax")]
public partial class TransferSyntax
{
    [Key]
    [Column("TransferSyntaxID")]
    public int TransferSyntaxId { get; set; }

    [StringLength(100)]
    public string TransferSyntaxCode { get; set; } = null!;

    [StringLength(100)]
    public string? TransferSyntaxDesc { get; set; }

    [InverseProperty("TransferSyntax")]
    public virtual ICollection<StorageScp> StorageScps { get; set; } = new List<StorageScp>();
}
