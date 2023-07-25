using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Repository.Models;

[Index("InstitutionId", Name = "IX_StudyReports_InstitutionID_17CD7")]
[Index("InstitutionId", Name = "IX_StudyReports_InstitutionID_33138")]
[Index("StudyId", Name = "StudyID")]
public partial class StudyReport
{
    [Key]
    [Column("ReportID")]
    public int ReportId { get; set; }

    [StringLength(150)]
    public string? ReportCode { get; set; }

    [Column("StudyID")]
    public int? StudyId { get; set; }

    [Column("RadiologistID")]
    public int? RadiologistId { get; set; }

    [Column("InstitutionID")]
    public int? InstitutionId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReportExpectedTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StudySentDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? HistorySentDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReportSentDate { get; set; }

    public byte[]? Report { get; set; }

    [StringLength(1000)]
    public string? ReportPath { get; set; }

    public int? IsCheckOut { get; set; }

    public string? Comments { get; set; }

    [StringLength(1000)]
    public string? StudyDescription { get; set; }

    [StringLength(1000)]
    public string? ExtraScreening { get; set; }

    [StringLength(100)]
    public string? NoOfStudy { get; set; }

    [StringLength(100)]
    public string? NoOfScreening { get; set; }

    public int? IsDownloaded { get; set; }

    public int? DownloadedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DownloadedDate { get; set; }

    [StringLength(1000)]
    public string? ReportType { get; set; }

    public string? ReportData { get; set; }

    public string? Impression { get; set; }

    public int? ReportStatus { get; set; }

    [Column("ReportData_RTF")]
    public string? ReportDataRtf { get; set; }

    [Column("Impression_RTF")]
    public string? ImpressionRtf { get; set; }

    [ForeignKey("InstitutionId")]
    [InverseProperty("StudyReports")]
    public virtual Institution? Institution { get; set; }

    [ForeignKey("RadiologistId")]
    [InverseProperty("StudyReports")]
    public virtual Radiologist? Radiologist { get; set; }

    [ForeignKey("StudyId")]
    [InverseProperty("StudyReports")]
    public virtual Study? Study { get; set; }

    [InverseProperty("Report")]
    public virtual ICollection<StudyActionLog> StudyActionLogs { get; set; } = new List<StudyActionLog>();

    [InverseProperty("Report")]
    public virtual ICollection<StudyReportAssignment> StudyReportAssignments { get; set; } = new List<StudyReportAssignment>();

    [InverseProperty("Report")]
    public virtual ICollection<StudyReportAttachment> StudyReportAttachments { get; set; } = new List<StudyReportAttachment>();
}
