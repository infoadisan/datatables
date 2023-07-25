using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Data.Models;

public partial class License
{
    [Key]
    [Column("LicenseID")]
    public int LicenseId { get; set; }

    [Column("ApplicationID")]
    [StringLength(50)]
    [Unicode(false)]
    public string ApplicationId { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string ApplicationName { get; set; } = null!;

    [StringLength(1000)]
    public string InstitutionName { get; set; } = null!;

    [Column("MachineID")]
    [StringLength(50)]
    public string MachineId { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? RegisteredDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ExpiryDate { get; set; }

    [StringLength(50)]
    public string? LicenseType { get; set; }

    [Column("CRC")]
    [StringLength(8)]
    public string? Crc { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public bool? IsApprove { get; set; }
}
