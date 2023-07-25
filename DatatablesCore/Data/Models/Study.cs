using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Data.Models;

[Index("StudyId", Name = "IX_Studies")]
[Index("StudyUid", Name = "IX_Studies_StudyUID_23186")]
[Index("Modality", Name = "Modality")]
[Index("PatientId", "Modality", Name = "PatientIDModality")]
public partial class Study
{
    [Key]
    [Column("StudyID")]
    public int StudyId { get; set; }

    [Column("StudyUID")]
    [StringLength(100)]
    public string? StudyUid { get; set; }

    [StringLength(1000)]
    public string? StudyDescription { get; set; }

    [Column("PatientID")]
    public int? PatientId { get; set; }

    [StringLength(100)]
    public string? Modality { get; set; }

    public short? NumSeries { get; set; }

    public short? NumImages { get; set; }

    public short? NumSentImages { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StudyDate { get; set; }

    [StringLength(1000)]
    public string? InstitutionName { get; set; }

    public int? IsUploadAndZip { get; set; }

    public int? IsUploadWeb { get; set; }

    [StringLength(1000)]
    public string? ZipFilePath { get; set; }

    [Column("PriorityID")]
    public int? PriorityId { get; set; }

    [StringLength(1000)]
    public string? OnrDriveLink { get; set; }

    [InverseProperty("Study")]
    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    [InverseProperty("ImageShareStudy")]
    public virtual ICollection<MappingForInstitution> MappingForInstitutions { get; set; } = new List<MappingForInstitution>();

    [ForeignKey("PatientId")]
    [InverseProperty("Studies")]
    public virtual Patient? Patient { get; set; }

    [ForeignKey("PriorityId")]
    [InverseProperty("Studies")]
    public virtual StudyPriority? Priority { get; set; }

    [InverseProperty("Study")]
    public virtual ICollection<Series> Series { get; set; } = new List<Series>();

    [InverseProperty("Study")]
    public virtual ICollection<StudyReport> StudyReports { get; set; } = new List<StudyReport>();
}
