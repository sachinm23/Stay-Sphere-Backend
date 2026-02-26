namespace StaySphere.Application.Interfaces.PropertyInterfaces
{
    using StaySphere.Domain.Entities.Property;
    public interface IPropertyRepository
    {
        Task<Property> GetPropertyByIdAsync(Guid propertyId);

        Task AddPropertyAsync(Property property);
    }
}