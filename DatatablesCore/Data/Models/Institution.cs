using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Data.Models;

public partial class Institution
{
    [Key]
    [Column("InstitutionID")]
    public int InstitutionId { get; set; }

    [StringLength(50)]
    public string? InstitutionCode { get; set; }

    [StringLength(1000)]
    public string? InstitutionName { get; set; }

    [Column("UserID")]
    public Guid? UserId { get; set; }

    [StringLength(50)]
    public string? IntegrateWith { get; set; }

    public bool? IsInLineReport { get; set; }

    public bool? IsOffLineReport { get; set; }

    public bool? IsOnLineReport { get; set; }

    [InverseProperty("Institution")]
    public virtual ICollection<InstitutionMappingWithUser> InstitutionMappingWithUsers { get; set; } = new List<InstitutionMappingWithUser>();

    [InverseProperty("Institution")]
    public virtual ICollection<ReviewerMapping> ReviewerMappings { get; set; } = new List<ReviewerMapping>();

    [InverseProperty("Institution")]
    public virtual ICollection<StudyReport> StudyReports { get; set; } = new List<StudyReport>();
}
