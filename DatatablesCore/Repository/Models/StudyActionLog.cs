using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Repository.Models;

[Table("StudyActionLog")]
[Index("ReportId", Name = "IX_StudyActionLog_ReportId_E2760")]
public partial class StudyActionLog
{
    [Key]
    public int LogId { get; set; }

    public int ReportId { get; set; }

    public int ActionId { get; set; }

    public Guid ActionBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ActionDate { get; set; }

    [StringLength(50)]
    public string ActionByName { get; set; } = null!;

    [StringLength(256)]
    public string LoggedInRoleName { get; set; } = null!;

    [ForeignKey("ActionId")]
    [InverseProperty("StudyActionLogs")]
    public virtual Action Action { get; set; } = null!;

    [ForeignKey("ReportId")]
    [InverseProperty("StudyActionLogs")]
    public virtual StudyReport Report { get; set; } = null!;
}
