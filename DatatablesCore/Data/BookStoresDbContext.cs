using System;
using System.Collections.Generic;
using DatatablesCore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DatatablesCore.Data;

public partial class BookStoresDbContext : DbContext
{
    public BookStoresDbContext()
    {
    }

    public BookStoresDbContext(DbContextOptions<BookStoresDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Action> Actions { get; set; }

    public virtual DbSet<ArchiveLog> ArchiveLogs { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Institution> Institutions { get; set; }

    public virtual DbSet<InstitutionMappingWithUser> InstitutionMappingWithUsers { get; set; }

    public virtual DbSet<License> Licenses { get; set; }

    public virtual DbSet<MappingForInstitution> MappingForInstitutions { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Radiologist> Radiologists { get; set; }

    public virtual DbSet<RadiologistMappingWithUser> RadiologistMappingWithUsers { get; set; }

    public virtual DbSet<RadiologistModalityMapping> RadiologistModalityMappings { get; set; }

    public virtual DbSet<ReviewerMapping> ReviewerMappings { get; set; }

    public virtual DbSet<Series> Series { get; set; }

    public virtual DbSet<StorageScp> StorageScps { get; set; }

    public virtual DbSet<Study> Studies { get; set; }

    public virtual DbSet<StudyActionLog> StudyActionLogs { get; set; }

    public virtual DbSet<StudyPriority> StudyPriorities { get; set; }

    public virtual DbSet<StudyReport> StudyReports { get; set; }

    public virtual DbSet<StudyReportAssignment> StudyReportAssignments { get; set; }

    public virtual DbSet<StudyReportAttachment> StudyReportAttachments { get; set; }

    public virtual DbSet<StudyReportTemplate> StudyReportTemplates { get; set; }

    public virtual DbSet<TransferSyntax> TransferSyntaxes { get; set; }

    public virtual DbSet<VwPmssirrAllCase> VwPmssirrAllCases { get; set; }

    public virtual DbSet<VwPmssirrReportedCase> VwPmssirrReportedCases { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Action>(entity =>
        {
            entity.Property(e => e.ActionId).ValueGeneratedNever();
            entity.Property(e => e.ColorCode).IsFixedLength();
        });

        modelBuilder.Entity<ArchiveLog>(entity =>
        {
            entity.Property(e => e.StudyId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasOne(d => d.Series).WithMany(p => p.Documents).HasConstraintName("FK_Documents_Series");

            entity.HasOne(d => d.Study).WithMany(p => p.Documents).HasConstraintName("FK_Documents_Studies");
        });

        modelBuilder.Entity<Institution>(entity =>
        {
            entity.Property(e => e.InstitutionId).ValueGeneratedNever();
            entity.Property(e => e.IsInLineReport).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsOffLineReport).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsOnLineReport).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<InstitutionMappingWithUser>(entity =>
        {
            entity.HasOne(d => d.Institution).WithMany(p => p.InstitutionMappingWithUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InstitutionMappingWithUser_Institutions");
        });

        modelBuilder.Entity<MappingForInstitution>(entity =>
        {
            entity.HasOne(d => d.ImageSharePatient).WithMany(p => p.MappingForInstitutions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MappingForInstitution_Patients");

            entity.HasOne(d => d.ImageShareStudy).WithMany(p => p.MappingForInstitutions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MappingForInstitution_Studies");
        });

        modelBuilder.Entity<Radiologist>(entity =>
        {
            entity.Property(e => e.RadiologistId).ValueGeneratedNever();
        });

        modelBuilder.Entity<RadiologistMappingWithUser>(entity =>
        {
            entity.HasOne(d => d.Radiologist).WithMany(p => p.RadiologistMappingWithUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RadiologistMappingWithUser_Radiologists");
        });

        modelBuilder.Entity<RadiologistModalityMapping>(entity =>
        {
            entity.HasOne(d => d.Radiologist).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RadiologistModalityMapping_Radiologists");
        });

        modelBuilder.Entity<ReviewerMapping>(entity =>
        {
            entity.HasOne(d => d.Institution).WithMany(p => p.ReviewerMappings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReviewerMapping_Institutions");

            entity.HasOne(d => d.Radiologist).WithMany(p => p.ReviewerMappingRadiologists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReviewerMapping_Radiologists");

            entity.HasOne(d => d.Reviewer).WithMany(p => p.ReviewerMappingReviewers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReviewerMapping_Radiologists1");
        });

        modelBuilder.Entity<Series>(entity =>
        {
            entity.HasOne(d => d.Study).WithMany(p => p.Series).HasConstraintName("FK_Series_Series");
        });

        modelBuilder.Entity<StorageScp>(entity =>
        {
            entity.HasOne(d => d.TransferSyntax).WithMany(p => p.StorageScps).HasConstraintName("FK_StorageSCPs_TransferSyntax");
        });

        modelBuilder.Entity<Study>(entity =>
        {
            entity.HasOne(d => d.Patient).WithMany(p => p.Studies).HasConstraintName("FK_Studies_Patients");

            entity.HasOne(d => d.Priority).WithMany(p => p.Studies).HasConstraintName("FK_Studies_StudyPriority");
        });

        modelBuilder.Entity<StudyActionLog>(entity =>
        {
            entity.HasOne(d => d.Action).WithMany(p => p.StudyActionLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudyActionLog_Action");

            entity.HasOne(d => d.Report).WithMany(p => p.StudyActionLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudyActionLog_StudyReports");
        });

        modelBuilder.Entity<StudyPriority>(entity =>
        {
            entity.HasKey(e => e.PriorityId).HasName("PK_Priority");
        });

        modelBuilder.Entity<StudyReport>(entity =>
        {
            entity.HasOne(d => d.Institution).WithMany(p => p.StudyReports).HasConstraintName("FK_StudyReports_Institutions");

            entity.HasOne(d => d.Radiologist).WithMany(p => p.StudyReports).HasConstraintName("FK_StudyReports_Radiologists");

            entity.HasOne(d => d.Study).WithMany(p => p.StudyReports).HasConstraintName("FK_StudyReports_Studies");
        });

        modelBuilder.Entity<StudyReportAssignment>(entity =>
        {
            entity.HasOne(d => d.Report).WithMany(p => p.StudyReportAssignments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudyReportAssignments_StudyReports");
        });

        modelBuilder.Entity<StudyReportAttachment>(entity =>
        {
            entity.Property(e => e.FileType).IsFixedLength();

            entity.HasOne(d => d.Report).WithMany(p => p.StudyReportAttachments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudyReportAttachments_StudyReports");
        });

        modelBuilder.Entity<StudyReportTemplate>(entity =>
        {
            entity.Property(e => e.ReportTemplateId).IsFixedLength();
        });

        modelBuilder.Entity<VwPmssirrAllCase>(entity =>
        {
            entity.ToView("vw_PMSSIRR_allCases");
        });

        modelBuilder.Entity<VwPmssirrReportedCase>(entity =>
        {
            entity.ToView("vw_PMSSIRR_reportedCases");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
