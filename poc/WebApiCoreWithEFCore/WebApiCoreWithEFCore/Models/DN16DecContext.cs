using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiCoreWithEFCore.Models
{
    public partial class DN16DecContext : DbContext
    {
        public DN16DecContext()
        {
        }

        public DN16DecContext(DbContextOptions<DN16DecContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeesAddress> EmployeesAddresses { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=IMCCBCP52-MSL2\\SQLEXPRESS2019;Initial Catalog=DN16Dec;User Id=sa;Password=password_123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.LastName).HasMaxLength(20);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId, "IX_Employees_DepartmentId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId);

                entity.HasMany(d => d.Projects)
                    .WithMany(p => p.Employees)
                    .UsingEntity<Dictionary<string, object>>(
                        "EmployeeProject",
                        l => l.HasOne<Project>().WithMany().HasForeignKey("ProjectId"),
                        r => r.HasOne<Employee>().WithMany().HasForeignKey("EmployeeId"),
                        j =>
                        {
                            j.HasKey("EmployeeId", "ProjectId");

                            j.ToTable("EmployeeProjects");

                            j.HasIndex(new[] { "ProjectId" }, "IX_EmployeeProjects_ProjectId");
                        });
            });

            modelBuilder.Entity<EmployeesAddress>(entity =>
            {
                entity.ToTable("EmployeesAddress");

                entity.HasIndex(e => e.EmployeeId, "IX_EmployeesAddress_EmployeeId")
                    .IsUnique();

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.EmployeesAddress)
                    .HasForeignKey<EmployeesAddress>(d => d.EmployeeId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.OrderDate).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Orders__Customer__49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
