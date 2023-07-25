using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Repository.Models;

[Table("ArchiveLog")]
public partial class ArchiveLog
{
    [Key]
    [Column("StudyID")]
    public int StudyId { get; set; }

    [StringLength(100)]
    public string? PatientCode { get; set; }

    [StringLength(150)]
    public string? PatientName { get; set; }

    [StringLength(100)]
    public string? Modality { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndTime { get; set; }

    public string? SourceFolder { get; set; }

    public string? DestinationFolder { get; set; }

    [Column("NumFilesSRC")]
    public int? NumFilesSrc { get; set; }

    [Column("NumFileDEST")]
    public int? NumFileDest { get; set; }

    [Column("SizeSRC")]
    public long? SizeSrc { get; set; }

    [Column("SizeDEST")]
    public long? SizeDest { get; set; }

    public string? Remarks { get; set; }
}
