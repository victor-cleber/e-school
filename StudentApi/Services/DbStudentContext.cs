
using Microsoft.EntityFrameworkCore;
using StudentApi.Models;

namespace StudentApi.Services
{
  public class DbStudentContext : DbContext
  {
    public DbStudentContext(DbContextOptions<DbStudentContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }
  }
}