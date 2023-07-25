using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Data.Models;

[PrimaryKey("ReportId", "UserName")]
public partial class StudyReportAssignment
{
    [Key]
    public int ReportId { get; set; }

    [Key]
    [StringLength(50)]
    public string UserName { get; set; } = null!;

    [ForeignKey("ReportId")]
    [InverseProperty("StudyReportAssignments")]
    public virtual StudyReport Report { get; set; } = null!;
}
