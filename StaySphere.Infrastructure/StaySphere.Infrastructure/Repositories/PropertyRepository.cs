namespace StaySphere.Infrastructure.Repositories
{
    using StaySphere.Domain.Entities.Property;
    using StaySphere.Application.Interfaces.PropertyInterfaces;
    using Microsoft.EntityFrameworkCore;
    using StaySphere.Infrastructure.Data;

    public class PropertyRepository : IPropertyRepository
    {
        private readonly StaySphereDbContext _context;
        public PropertyRepository(StaySphereDbContext context)
        {
            _context = context;
        }

        public async Task<Property> GetPropertyByIdAsync(Guid propertyId)
        {
            var property = await _context.Properties
                .Include(p => p.Images)
                .Include(p => p.Location)
                .FirstOrDefaultAsync(p => p.Id == propertyId);

            if (property == null) return null;
            
            return property;
        }

        public async Task AddPropertyAsync(Property property)
        {
            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();
        }
    }
}