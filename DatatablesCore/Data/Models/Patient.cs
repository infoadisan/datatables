using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Data.Models;

[Index("PatientCode", Name = "PatientCode")]
[Index("PatientName", Name = "PatientName")]
public partial class Patient
{
    [Key]
    [Column("PatientID")]
    public int PatientId { get; set; }

    [StringLength(100)]
    public string? PatientCode { get; set; }

    [StringLength(150)]
    public string? PatientName { get; set; }

    [StringLength(5)]
    public string? Sex { get; set; }

    [StringLength(10)]
    public string? Age { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? BirthDate { get; set; }

    [StringLength(100)]
    public string? ResAdd1 { get; set; }

    [StringLength(100)]
    public string? ResAdd2 { get; set; }

    [StringLength(100)]
    public string? ResAdd3 { get; set; }

    [StringLength(20)]
    public string? ResCity { get; set; }

    [StringLength(20)]
    public string? ResState { get; set; }

    [StringLength(8)]
    public string? ResZip { get; set; }

    [StringLength(15)]
    public string? PhoneRes1 { get; set; }

    [StringLength(15)]
    public string? PhoneRes2 { get; set; }

    [StringLength(12)]
    public string? MobileNo { get; set; }

    [Column("EMail")]
    [StringLength(25)]
    public string? Email { get; set; }

    public string? Comments { get; set; }

    [StringLength(100)]
    public string? RefferingDoctor { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Regdate { get; set; }

    public string? HealthAlerts { get; set; }

    public string? Allergies { get; set; }

    public string? History { get; set; }

    public int? IsHistorySent { get; set; }

    [StringLength(10)]
    public string? BloodGroup { get; set; }

    [InverseProperty("ImageSharePatient")]
    public virtual ICollection<MappingForInstitution> MappingForInstitutions { get; set; } = new List<MappingForInstitution>();

    [InverseProperty("Patient")]
    public virtual ICollection<Study> Studies { get; set; } = new List<Study>();
}
