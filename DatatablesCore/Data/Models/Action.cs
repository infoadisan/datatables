using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Data.Models;

[Table("Action")]
public partial class Action
{
    [Key]
    public int ActionId { get; set; }

    [Column("Action")]
    [StringLength(50)]
    public string Action1 { get; set; } = null!;

    public string ActionDesc { get; set; } = null!;

    [StringLength(7)]
    public string? ColorCode { get; set; }

    [InverseProperty("Action")]
    public virtual ICollection<StudyActionLog> StudyActionLogs { get; set; } = new List<StudyActionLog>();
}
