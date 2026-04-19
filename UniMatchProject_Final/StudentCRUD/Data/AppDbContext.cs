using Microsoft.EntityFrameworkCore;
using StudentCRUD.Models;

namespace StudentCRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentLogin> StudentLogin { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<StaffLogin> StaffLogin { get; set; }
        public DbSet<GroupMembers> GroupMembers { get; set; }
        public DbSet<GroupName> GroupName { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Submit> Submit { get; set; }
      
    }
}
