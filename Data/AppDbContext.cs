using EmployeeManagementSystem.Data.Seed;
using EmployeeManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Data
{
    /// <summary>
    /// DbContext acts as a bridge between C# application and database.
    /// It manages entities, relationships, and database operations.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Constructor used by Dependency Injection to pass DB options.
        /// </summary>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Represents Employees table in database.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Represents Departments table in database.
        /// </summary>
        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// Represents Roles table in database.
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Configures entity relationships, constraints, and seed data.
        /// This method is executed when EF builds the model.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================
            // Employee → Department (Many-to-One)
            // =========================
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);

            // =========================
            // Employee → Role (Many-to-One)
            // =========================
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Role)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.RoleId);

            // =========================
            // SEED DATA - Departments
            // =========================
            modelBuilder.Entity<Department>().HasData(DepartmentSeeder.GetDepartments());
            // =========================
            // SEED DATA - Roles
            // =========================
            modelBuilder.Entity<Role>().HasData(RoleSeeder.GetRoles());

        }
    }
}
