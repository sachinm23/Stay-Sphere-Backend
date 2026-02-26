namespace StaySphere.Application.DTOs.Property
{
    public class PropertyResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal PricePerNight { get; set; }
        public string PropertyType { get; set; }
        public int MaxGuests { get; set; }
        public List<PropertyImageDto> Images { get; set; } = new List<PropertyImageDto>();
        public LocationDto Location { get; set; }
    }

    public class LocationDto
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }

    public class PropertyImageDto
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public bool IsCover { get; set; }
    }

}