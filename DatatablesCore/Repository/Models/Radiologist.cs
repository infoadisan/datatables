using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Repository.Models;

public partial class Radiologist
{
    [Key]
    [Column("RadiologistID")]
    public int RadiologistId { get; set; }

    [StringLength(100)]
    public string? RadiologistCode { get; set; }

    [StringLength(150)]
    public string? RadiologisticName { get; set; }

    [Column("UserID")]
    public Guid? UserId { get; set; }

    [StringLength(2000)]
    public string? Signature { get; set; }

    [StringLength(1000)]
    public string? SignPath { get; set; }

    [StringLength(1000)]
    public string? SignPathVirtual { get; set; }

    [StringLength(1000)]
    public string? CommandToRun { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("Radiologist")]
    public virtual ICollection<RadiologistMappingWithUser> RadiologistMappingWithUsers { get; set; } = new List<RadiologistMappingWithUser>();

    [InverseProperty("Radiologist")]
    public virtual ICollection<ReviewerMapping> ReviewerMappingRadiologists { get; set; } = new List<ReviewerMapping>();

    [InverseProperty("Reviewer")]
    public virtual ICollection<ReviewerMapping> ReviewerMappingReviewers { get; set; } = new List<ReviewerMapping>();

    [InverseProperty("Radiologist")]
    public virtual ICollection<StudyReport> StudyReports { get; set; } = new List<StudyReport>();
}
