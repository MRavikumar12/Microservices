using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Customer.API.Models;

public partial class MicroDbContext : DbContext
{
    public MicroDbContext()
    {
    }

    public MicroDbContext(DbContextOptions<MicroDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TCustomer> TCustomers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
/*#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=IN3247948W2;Initial Catalog=MicroDB;Trusted_Connection=True;TrustServerCertificate=True;database=MicroDB");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TCustomer>(entity =>
        {
            entity.HasKey(e => e.CustId);

            entity.ToTable("T_Customer");

            entity.Property(e => e.CustAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
