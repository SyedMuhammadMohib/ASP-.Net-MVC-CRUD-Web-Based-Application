using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mohib.Models;

public partial class MohibContext : DbContext
{
    public MohibContext()
    {
    }

    public MohibContext(DbContextOptions<MohibContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Table> Tables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=UZAIR_SAEEDI;Database=mohib;Trusted_Connection=True;trustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table__3214EC0702FC907A");

            entity.ToTable("Table");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Department)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EarnedCreditHours).HasColumnName("Earned Credit Hours");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Semester)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
