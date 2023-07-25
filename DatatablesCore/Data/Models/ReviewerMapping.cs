using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Data.Models;

[PrimaryKey("RadiologistId", "InstitutionId")]
[Table("ReviewerMapping")]
public partial class ReviewerMapping
{
    [Key]
    [Column("RadiologistID")]
    public int RadiologistId { get; set; }

    [Key]
    [Column("InstitutionID")]
    public int InstitutionId { get; set; }

    [Column("ReviewerID")]
    public int ReviewerId { get; set; }

    public bool ShowReviewer { get; set; }

    public bool? IsProofReading { get; set; }

    [ForeignKey("InstitutionId")]
    [InverseProperty("ReviewerMappings")]
    public virtual Institution Institution { get; set; } = null!;

    [ForeignKey("RadiologistId")]
    [InverseProperty("ReviewerMappingRadiologists")]
    public virtual Radiologist Radiologist { get; set; } = null!;

    [ForeignKey("ReviewerId")]
    [InverseProperty("ReviewerMappingReviewers")]
    public virtual Radiologist Reviewer { get; set; } = null!;
}
