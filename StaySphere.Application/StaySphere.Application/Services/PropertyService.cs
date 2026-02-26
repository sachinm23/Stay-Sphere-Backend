namespace StaySphere.Application.Services
{
    using StaySphere.Application.Interfaces.PropertyInterfaces;
    using StaySphere.Application.Interfaces;
    using StaySphere.Domain.Entities.Property;
    using StaySphere.Application.DTOs.Property;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        private readonly IAwsService _awsService;

        public PropertyService(IPropertyRepository propertyRepository, IAwsService awsService)
        {
            _propertyRepository = propertyRepository;
            _awsService = awsService;
        }

        public async Task<PropertyResponseDto> GetPropertyByIdAsync(Guid propertyId)
        {
            var property = await _propertyRepository.GetPropertyByIdAsync(propertyId);

            if (property == null)
            {
                throw new KeyNotFoundException($"Property with ID '{propertyId}' was not found.");
            }

            return new PropertyResponseDto
            {
                Id = property.Id,
                Title = property.Title,
                Description = property.Description,
                PricePerNight = property.PricePerNight,
                Location = new LocationDto
                {
                    AddressLine1 = property.Location.Address,
                    City = property.Location.City,
                    Country = property.Location.Country
                },
                Images = property.Images.Select(img => new PropertyImageDto
                {
                    Id = img.Id,
                    Url = _awsService.GeneratePreSignedUrlAsync(img.S3Key).Result
                }).ToList()
            };
        }

        public async Task AddPropertyAsync(Property property)
        {
            await _propertyRepository.AddPropertyAsync(property);
            
        }   
    }
}