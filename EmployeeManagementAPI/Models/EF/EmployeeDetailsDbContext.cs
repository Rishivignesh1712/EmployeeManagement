using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Models.EF;

public partial class EmployeeDetailsDbContext : DbContext
{
    public EmployeeDetailsDbContext()
    {
    }

    public EmployeeDetailsDbContext(DbContextOptions<EmployeeDetailsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=43D1A2BBDA89523;database=EmployeeDetailsDB;integrated security=true;trustservercertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptNo).HasName("PK__Departme__BE2D3F554FA48B01");

            entity.ToTable("Department");

            entity.Property(e => e.DeptNo)
                .ValueGeneratedNever()
                .HasColumnName("deptNo");
            entity.Property(e => e.DeptEmail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("deptEmail");
            entity.Property(e => e.DeptLocation)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("deptLocation");
            entity.Property(e => e.DeptName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("deptName");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Empno).HasName("PK__Employee__AF4C318A14C0F74C");

            entity.ToTable("Employee");

            entity.Property(e => e.Empno)
                .ValueGeneratedNever()
                .HasColumnName("empno");
            entity.Property(e => e.DeptNo).HasColumnName("deptNo");
            entity.Property(e => e.EmpDesignation)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("empDesignation");
            entity.Property(e => e.EmpName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empName");
            entity.Property(e => e.EmpPermanent)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("empPermanent");
            entity.Property(e => e.EmpSalary).HasColumnName("empSalary");

            entity.HasOne(d => d.DeptNoNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DeptNo)
                .HasConstraintName("FK__Employee__deptNo__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
