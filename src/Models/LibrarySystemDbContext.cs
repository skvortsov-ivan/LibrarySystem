using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Models;

public partial class LibrarySystemDbContext : DbContext
{
    public LibrarySystemDbContext()
    {
    }

    public LibrarySystemDbContext(DbContextOptions<LibrarySystemDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Library> Libraries { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<ViewActiveLoan> ViewActiveLoans { get; set; }

    public virtual DbSet<ViewBook> ViewBooks { get; set; }

    public virtual DbSet<ViewMember> ViewMembers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=LibrarySystemDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");

            entity.Property(e => e.Author).HasMaxLength(50);
            entity.Property(e => e.FklibraryId).HasColumnName("FKLibraryId");
            entity.Property(e => e.IsAvailable).HasDefaultValue(true);

            entity.HasOne(d => d.Fklibrary).WithMany(p => p.Books)
                .HasForeignKey(d => d.FklibraryId)
                .HasConstraintName("FK_Book_Library");
        });

        modelBuilder.Entity<Library>(entity =>
        {
            entity.ToTable("Library");

            entity.Property(e => e.Adress).HasMaxLength(100);
            entity.Property(e => e.LibraryName).HasMaxLength(100);
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Loan", tb =>
                {
                    tb.HasTrigger("trg_BookBorrowed");
                    tb.HasTrigger("trg_BookReturned");
                });

            entity.Property(e => e.FkbookId).HasColumnName("FKBookId");
            entity.Property(e => e.FkmemberId).HasColumnName("FKMemberId");
            entity.Property(e => e.LoanDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LoanId).ValueGeneratedOnAdd();
            entity.Property(e => e.ReturnDate).HasColumnType("datetime");

            entity.HasOne(d => d.Fkbook).WithMany()
                .HasForeignKey(d => d.FkbookId)
                .HasConstraintName("FK_Loan_Book");

            entity.HasOne(d => d.Fkmember).WithMany()
                .HasForeignKey(d => d.FkmemberId)
                .HasConstraintName("FK_Loan_Member");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.ToTable("Member");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.FklibraryId).HasColumnName("FKLibraryId");
            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.HasOne(d => d.Fklibrary).WithMany(p => p.Members)
                .HasForeignKey(d => d.FklibraryId)
                .HasConstraintName("FK_Member_Library");
        });

        modelBuilder.Entity<ViewActiveLoan>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewActiveLoans");

            entity.Property(e => e.Author).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.LoanDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ViewBook>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewBooks");

            entity.Property(e => e.Author).HasMaxLength(50);
            entity.Property(e => e.LibraryName).HasMaxLength(100);
        });

        modelBuilder.Entity<ViewMember>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewMembers");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.FklibraryId).HasColumnName("FKLibraryId");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MemberId).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
