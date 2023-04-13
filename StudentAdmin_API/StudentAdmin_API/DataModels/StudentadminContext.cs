using Microsoft.EntityFrameworkCore;
namespace StudentAdmin_API.DataModels

{
    public class StudentadminContext : DbContext
    {
        public StudentadminContext(DbContextOptions<StudentadminContext> options) : base(options) { }
        public DbSet<Student> Student { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Address> Address { get; set; }
    }

}
