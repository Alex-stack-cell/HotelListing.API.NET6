namespace HotelListing.API.Data
{
    /// <summary>
    /// Country Entity representing a table in the database
    /// One country can have many hotel
    /// </summary>
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public virtual IList<Hotel> Hotels { get; set; }

    }
}