
using System;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Models;

namespace SchoolApi.Services
{
  public class SchoolDbContext : DbContext
  {
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

    public DbSet<School> Schools { get; set; }

    protected override void OnModelCreating(ModelBuilder builder){
          Guid id = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4");

          builder.Entity<School>().HasData(
            new School{
                        Id = id,
                        CompanyName = "School of the future",
                        TradingName = "School of the future",
                        WebSite = "www.schoolofthefuture.com",
                        Phone = "+ 234 52 656 12337",
                        Address = "4340 Thompson Av, El Pargo, CA 99313, United States"
                    }
          );
    }
  }
}