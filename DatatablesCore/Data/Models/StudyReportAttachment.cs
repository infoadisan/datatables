using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Data.Models;

public partial class StudyReportAttachment
{
    [Key]
    [Column("AttachmentID")]
    public int AttachmentId { get; set; }

    [Column("ReportID")]
    public int ReportId { get; set; }

    [StringLength(1000)]
    public string FileName { get; set; } = null!;

    [StringLength(10)]
    public string FileType { get; set; } = null!;

    public byte[] FileInBinary { get; set; } = null!;

    [ForeignKey("ReportId")]
    [InverseProperty("StudyReportAttachments")]
    public virtual StudyReport Report { get; set; } = null!;
}
