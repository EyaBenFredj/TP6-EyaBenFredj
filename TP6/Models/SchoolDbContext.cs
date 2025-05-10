using Microsoft.EntityFrameworkCore;

namespace SchoolAPI.Models
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public DbSet<School> Schools { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>().HasData(
                new School
                {
                    Id = 1,
                    Name = "ENISo",
                    Sections = "Info, Meca",
                    Director = "Dr. A",
                    Rating = 4.5,
                    WebSite = "http://www.eniso.rnu.tn"
                },
                new School
                {
                    Id = 2,
                    Name = "ENIT",
                    Sections = "Civil",
                    Director = "Dr. B",
                    Rating = 4.0
                    // WebSite is null (not included)
                },
                new School
                {
                    Id = 3,
                    Name = "ENSI",
                    Sections = "Info",
                    Director = "Dr. C",
                    Rating = 5.0,
                    WebSite = "http://www.ensi.rnu.tn"
                }
            );
        }
    }
}