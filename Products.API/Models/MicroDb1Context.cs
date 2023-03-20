using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Products.API.Models;

public partial class MicroDb1Context : DbContext
{
    public MicroDb1Context()
    {
    }

    public MicroDb1Context(DbContextOptions<MicroDb1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TProduct> TProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
/*#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=IN3247948W2;Initial Catalog=MicroDB1;Trusted_Connection=True;TrustServerCertificate=True;database=MicroDB1");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TProduct>(entity =>
        {
            entity.HasKey(e => e.ProdId);

            entity.ToTable("T_Product");

            entity.Property(e => e.ProdDesc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProdName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
