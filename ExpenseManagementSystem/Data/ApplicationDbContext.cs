using ExpenseManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagementSystem.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //}

        public DbSet<Department> Departments { get; set; }

        public DbSet<PersonalClaim> PersonalClaims { get; set; }

        public DbSet<ClaimStatus> ClaimStatuses { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Employee> Employees { get; set; }

    }
}
