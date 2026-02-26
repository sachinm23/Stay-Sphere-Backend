namespace StaySphere.Application.DTOs.Property
{   
    using Microsoft.AspNetCore.Http;
    public class CreatePropertyDto
    {
        public  required string Title { get; set; }
        public required string Description { get; set; }
        public decimal PricePerNight { get; set; }
        public required string PropertyType { get; set; }
        public required int MaxGuests { get; set; }
        public required LocationDto Location { get; set; }
        public  required List<IFormFile> Images { get; set; } = new List<IFormFile>();
    }   
}