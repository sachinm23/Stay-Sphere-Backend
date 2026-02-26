namespace StaySphere.Domain.Entities.Property
{

    using StaySphere.Domain.Enums;
    public class Property
    {
        public Guid Id { get; private set; }
        public Guid HostId { get; private set; }
        public User Host { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal PricePerNight { get; private set; }
        public int Bedrooms { get; private set; }
        public int Bathrooms { get; private set; }
        public int MaxGuests { get; private set; }
        public PropertyType PropertyType { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public PropertyLocation Location { get; private set; }
        public ICollection<PropertyImage> Images { get; private set; }
        private Property() { }
        public Property(
            string title,
            string description,
            decimal pricePerNight,
            int bedrooms,
            int bathrooms,
            int maxGuests,
            PropertyType propertyType,
            Guid hostId)
        {
            if (pricePerNight <= 0)
                throw new ArgumentException("Price must be greater than zero");

            if (maxGuests <= 0)
                throw new ArgumentException("Max guests must be greater than zero");

            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            PricePerNight = pricePerNight;
            Bedrooms = bedrooms;
            Bathrooms = bathrooms;
            MaxGuests = maxGuests;
            PropertyType = propertyType;
            HostId = hostId;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
            Images = new List<PropertyImage>();
        }

        // public void SetLocation(PropertyLocation location)
        // {
        //     Location = location;
        // }

        // public void AddImage(PropertyImage image)
        // {
        //     Images.Add(image);
        // }

        // public void Deactivate()
        // {
        //     IsActive = false;
        // }
    }


}