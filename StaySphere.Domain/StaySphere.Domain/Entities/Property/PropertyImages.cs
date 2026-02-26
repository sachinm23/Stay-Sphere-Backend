namespace StaySphere.Domain.Entities.Property
{
    public class PropertyImage
    {
        public Guid Id { get; private set; }
        public string S3Key { get; private set; }
        public Guid PropertyId { get; private set; }
        public Property Property { get; private set; }
        private PropertyImage() { }
        public PropertyImage(string s3Key, Guid propertyId)
        {
            Id = Guid.NewGuid();
            S3Key = s3Key;
            PropertyId = propertyId;
        }
    }
}