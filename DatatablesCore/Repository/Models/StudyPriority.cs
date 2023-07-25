using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Repository.Models;

[Table("StudyPriority")]
public partial class StudyPriority
{
    [Key]
    [Column("PriorityID")]
    public int PriorityId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string PriorityDesc { get; set; } = null!;

    [InverseProperty("Priority")]
    public virtual ICollection<Study> Studies { get; set; } = new List<Study>();
}
