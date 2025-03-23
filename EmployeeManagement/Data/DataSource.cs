using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models;

namespace EmployeeManagement.Data
{
    public class DataSource : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DataSource(DbContextOptions<DataSource> options)
            : base(options)
        {
        }

        // Override OnModelCreating to add data seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add seed data here
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    DateOfEmployment = new DateTime(2015, 6, 1),
                    Position = "Software Engineer",
                    DepartmentId = 1,
                    IsActive = true
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1985, 3, 15),
                    DateOfEmployment = new DateTime(2010, 4, 1),
                    Position = "HR Manager",
                    DepartmentId = 2,
                    IsActive = true
                }
            );
        }
    }
}
