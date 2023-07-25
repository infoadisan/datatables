using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Repository.Models;

[Index("StudyId", Name = "StudyId")]
public partial class Document
{
    [Key]
    [Column("DocumentID")]
    public int DocumentId { get; set; }

    [Column("InstanceUID")]
    [StringLength(100)]
    public string? InstanceUid { get; set; }

    [Column("StudyID")]
    public int? StudyId { get; set; }

    public string? DicomFilePath { get; set; }

    public byte[]? FileInBinary { get; set; }

    public short? NumFrames { get; set; }

    public string? JpegFilePath { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SentDate { get; set; }

    [Column("SeriesID")]
    public int? SeriesId { get; set; }

    [ForeignKey("SeriesId")]
    [InverseProperty("Documents")]
    public virtual Series? Series { get; set; }

    [ForeignKey("StudyId")]
    [InverseProperty("Documents")]
    public virtual Study? Study { get; set; }
}
