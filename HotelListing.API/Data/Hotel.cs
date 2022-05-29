using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.API.Data
{
    /// <summary>
    /// Hotel Entity representing a table in the database
    /// One hotel can only be in one country
    /// </summary>
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address{ get; set; }
        public double Rating{ get; set; }
        [ForeignKey(nameof(CountryId))]
        public int CountryId{ get; set; }
        public Country Country { get; set; }
    }
}
