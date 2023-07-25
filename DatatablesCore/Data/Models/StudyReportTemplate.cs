using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Data.Models;

[PrimaryKey("ReportTemplateId", "InstitutionId")]
public partial class StudyReportTemplate
{
    [Key]
    [Column("ReportTemplateID")]
    [StringLength(10)]
    public string ReportTemplateId { get; set; } = null!;

    [StringLength(100)]
    public string? ReportTemplateDesc { get; set; }

    [StringLength(1000)]
    public string ReportTemplatePath { get; set; } = null!;

    [StringLength(1000)]
    public string? ReportType { get; set; }

    public string? ReportData { get; set; }

    public string? Impression { get; set; }

    [Key]
    [Column("InstitutionID")]
    public int InstitutionId { get; set; }

    [Column("ReportData_RTF")]
    public string? ReportDataRtf { get; set; }

    [Column("Impression_RTF")]
    public string? ImpressionRtf { get; set; }

    [Column("UserID")]
    public Guid? UserId { get; set; }
}
