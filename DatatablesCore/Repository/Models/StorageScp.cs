using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Repository.Models;

[Table("StorageSCPs")]
public partial class StorageScp
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("RemoteAET")]
    [StringLength(50)]
    public string? RemoteAet { get; set; }

    [Column("IPAddress")]
    [StringLength(50)]
    public string? Ipaddress { get; set; }

    [StringLength(50)]
    public string? Port { get; set; }

    public bool? IsLocal { get; set; }

    [Column("TransferSyntaxID")]
    public int? TransferSyntaxId { get; set; }

    public int? EchoStatus { get; set; }

    [StringLength(50)]
    public string? Description { get; set; }

    public bool? IsDownSample { get; set; }

    [ForeignKey("TransferSyntaxId")]
    [InverseProperty("StorageScps")]
    public virtual TransferSyntax? TransferSyntax { get; set; }
}
