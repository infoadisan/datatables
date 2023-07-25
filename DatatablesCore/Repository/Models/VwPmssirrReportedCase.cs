using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Repository.Models;

[Keyless]
public partial class VwPmssirrReportedCase
{
    [StringLength(150)]
    public string? PatientName { get; set; }

    [StringLength(1000)]
    public string? StudyDescription { get; set; }

    [StringLength(100)]
    public string? Modality { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StudySentDate { get; set; }

    [StringLength(1000)]
    public string? InstitutionName { get; set; }

    public short? NumImages { get; set; }

    [StringLength(150)]
    public string? RadiologisticName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReportSentDate { get; set; }

    [StringLength(1000)]
    public string? ReportType { get; set; }

    [Column("UserID")]
    public Guid UserId { get; set; }
}
