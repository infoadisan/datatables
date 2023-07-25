using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Data.Models;

[PrimaryKey("InstitutionId", "UserId")]
[Table("InstitutionMappingWithUser")]
public partial class InstitutionMappingWithUser
{
    [Key]
    [Column("InstitutionID")]
    public int InstitutionId { get; set; }

    [Key]
    [Column("UserID")]
    public Guid UserId { get; set; }

    [ForeignKey("InstitutionId")]
    [InverseProperty("InstitutionMappingWithUsers")]
    public virtual Institution Institution { get; set; } = null!;
}
