using Camp.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Camp.Data.DbContexts
{
    public class CampDbContext : DbContext
    {
        public DbSet<Entites.Camp> Camps { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Talk> Talks { get; set; }

        public CampDbContext(DbContextOptions<CampDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<Entites.Camp>()
              .HasData(new
              {
                  CampId = 1,
                  Moniker = "ATL2018",
                  Name = "Atlanta Code Camp",
                  EventDate = new DateTime(2018, 10, 18),
                  LocationId = 1,
                  Length = 1
              });

            bldr.Entity<Location>()
              .HasData(new
              {
                  LocationId = 1,
                  VenueName = "Atlanta Convention Center",
                  Address1 = "123 Main Street",
                  CityTown = "Atlanta",
                  StateProvince = "GA",
                  PostalCode = "12345",
                  Country = "USA"
              });

            bldr.Entity<Talk>()
              .HasData(new
              {
                  TalkId = 1,
                  CampId = 1,
                  SpeakerId = 1,
                  Title = "Entity Framework From Scratch",
                  Abstract = "Entity Framework from scratch in an hour. Probably cover it all",
                  Level = 100
              },
              new
              {
                  TalkId = 2,
                  CampId = 1,
                  SpeakerId = 2,
                  Title = "Writing Sample Data Made Easy",
                  Abstract = "Thinking of good sample data examples is tiring.",
                  Level = 200
              });

            bldr.Entity<Speaker>()
              .HasData(new
              {
                  SpeakerId = 1,
                  FirstName = "Shawn",
                  LastName = "Wildermuth",
                  BlogUrl = "http://wildermuth.com",
                  Company = "Wilder Minds LLC",
                  CompanyUrl = "http://wilderminds.com",
                  GitHub = "shawnwildermuth",
                  Twitter = "shawnwildermuth"
              }, new
              {
                  SpeakerId = 2,
                  FirstName = "Resa",
                  LastName = "Wildermuth",
                  BlogUrl = "http://shawnandresa.com",
                  Company = "Wilder Minds LLC",
                  CompanyUrl = "http://wilderminds.com",
                  GitHub = "resawildermuth",
                  Twitter = "resawildermuth"
              });
        }
    }
}
