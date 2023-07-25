using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Data.Models;

[PrimaryKey("InstitutionPatientId", "InstitutionStudyId", "InstitutionId")]
[Table("MappingForInstitution")]
public partial class MappingForInstitution
{
    [Column("ImageSharePatientID")]
    public int ImageSharePatientId { get; set; }

    [Column("ImageShareStudyID")]
    public int ImageShareStudyId { get; set; }

    [Key]
    [Column("InstitutionPatientID")]
    public int InstitutionPatientId { get; set; }

    [Key]
    [Column("InstitutionStudyID")]
    public int InstitutionStudyId { get; set; }

    [Key]
    [Column("InstitutionID")]
    public int InstitutionId { get; set; }

    [ForeignKey("ImageSharePatientId")]
    [InverseProperty("MappingForInstitutions")]
    public virtual Patient ImageSharePatient { get; set; } = null!;

    [ForeignKey("ImageShareStudyId")]
    [InverseProperty("MappingForInstitutions")]
    public virtual Study ImageShareStudy { get; set; } = null!;
}
