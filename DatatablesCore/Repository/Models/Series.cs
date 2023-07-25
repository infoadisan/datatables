using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Repository.Models;

public partial class Series
{
    [Key]
    [Column("SeriesID")]
    public int SeriesId { get; set; }

    [Column("StudyID")]
    public int? StudyId { get; set; }

    [Column("SeriesUID")]
    [StringLength(100)]
    public string? SeriesUid { get; set; }

    [StringLength(1000)]
    public string? SeriesDescription { get; set; }

    public short? NumImages { get; set; }

    public short? NumSentImages { get; set; }

    [StringLength(100)]
    public string? SeriesNumber { get; set; }

    [StringLength(1000)]
    public string? BodyPartExamined { get; set; }

    [InverseProperty("Series")]
    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    [ForeignKey("StudyId")]
    [InverseProperty("Series")]
    public virtual Study? Study { get; set; }
}
