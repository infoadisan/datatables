using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Repository.Models;

[Keyless]
[Table("RadiologistModalityMapping")]
public partial class RadiologistModalityMapping
{
    [Column("RadiologistID")]
    public int RadiologistId { get; set; }

    [StringLength(100)]
    public string Modality { get; set; } = null!;

    [ForeignKey("RadiologistId")]
    public virtual Radiologist Radiologist { get; set; } = null!;
}
