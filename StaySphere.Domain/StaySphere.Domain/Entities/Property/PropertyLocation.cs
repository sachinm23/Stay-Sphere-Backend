namespace StaySphere.Domain.Entities.Property
{
    using StaySphere.Domain.Enums;
public class PropertyLocation
{
    public Guid Id { get; private set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public string Country { get; private set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }
    public Guid PropertyId { get; private set; }
    public Property Property { get; private set; }
    private PropertyLocation() { }
    public PropertyLocation(string address, string city,string country,
                            double latitude, double longitude)
    {
        Id = Guid.NewGuid();
        Address = address;
        City = city;
        Country = country;
        Latitude = latitude;
        Longitude = longitude;
    }
}

}