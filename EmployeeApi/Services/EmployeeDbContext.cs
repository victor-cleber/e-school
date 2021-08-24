
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using EmployeeApi.Models;

namespace EmployeeApi.Services
{
  public class EmployeeDbContext : DbContext
  {
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

    public DbSet<Professor> Professors { get; set; }

    protected override void OnModelCreating(ModelBuilder builder){
        Guid id_professor_01 = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4");
        Guid id_professor_02 = new Guid("C78ACDAF-7CED-4790-B556-B5929EF87F84");
        builder.Entity<Professor>().HasData(
        new Professor{
                    Id = id_professor_01,
                    Name = "Orland Oras",
                    Email = "orland.oras@eschool.com",                        
                    Phone = "+ 234 52 656 12337",
                    Address = "4340 Thompson Av, El Pargo, CA 99313, United States",
                    ProfessorId = "F9168C5E",
                    IsStaff = true,
                },
        new Professor{
            Id = id_professor_02,
            Name = "Jordan Mac Law",
            Email = "j.maclaw@eschool.com",                        
            Phone = "+ 234 52 656 12337",
            Address = "4340 Thompson Av, El Pargo, CA 99313, United States",
            ProfessorId = "C78ACDAF",
            IsStaff = false,
        });
    }
  }
}