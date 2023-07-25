using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Data.Models;

[PrimaryKey("RadiologistId", "UserId")]
[Table("RadiologistMappingWithUser")]
public partial class RadiologistMappingWithUser
{
    [Key]
    [Column("RadiologistID")]
    public int RadiologistId { get; set; }

    [Key]
    [Column("UserID")]
    public Guid UserId { get; set; }

    [ForeignKey("RadiologistId")]
    [InverseProperty("RadiologistMappingWithUsers")]
    public virtual Radiologist Radiologist { get; set; } = null!;
}
