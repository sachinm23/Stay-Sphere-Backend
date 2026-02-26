namespace StayShere.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StaySphere.Application.Interfaces.PropertyInterfaces;
    using StaySphere.Application.DTOs.Property;
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;

    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [Authorize(Roles = "admin,host")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyById(Guid id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }
            return Ok(property);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProperty([FromForm] CreatePropertyDto createPropertyDto)
        {
            return Ok("Property created successfully.");
        }
    }
}