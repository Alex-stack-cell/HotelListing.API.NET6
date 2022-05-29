using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    /// <summary>
    /// Database context used to query and save instances
    /// to our entities. It acts as a contract between the app and DB
    /// </summary>
    public class HotelListingDbContext : DbContext
    {
        /// <summary>
        /// Constructor taking in argument the options provided by the API which is the connection string (line 13 - Program.cs)
        /// </summary>
        /// <param name="options"></param>
        public HotelListingDbContext(DbContextOptions options ) : base( options )
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        /// <summary>
        /// Configure the behaviour on how data go in.
        /// This is for data seeding
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
            new Country
            {
                Id = 1,
                Name = "Jamaica",
                ShortName = "JM"
            },
            new Country
            {
                Id=2,
                Name="Bahamas",
                ShortName="BS"
            },
            new Country
            {
                Id =3,
                Name = "Cayman Island",
                ShortName = "CI"
            });

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Sandals Resort and Spa",
                    Address = "Negril",
                    CountryId = 1,
                    Rating = 4.5
                },
                new Hotel
                {
                    Id=2,
                    Name="Comfort Suites",
                    Address = "George Town",
                    CountryId = 3,
                    Rating = 4.3
                },
                new Hotel
                {
                    Id= 3,
                    Name = "Grand Pallddium", 
                    Address="Nassua",
                    CountryId =2,
                    Rating=4
                }
                );
        }
    }
}
