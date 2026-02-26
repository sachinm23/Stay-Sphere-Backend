namespace StaySphere.Application.Interfaces.PropertyInterfaces
{
    using StaySphere.Application.DTOs.Property;
    public interface IPropertyService
    {
        Task<PropertyResponseDto> GetPropertyByIdAsync(Guid propertyId);
               
    }
}