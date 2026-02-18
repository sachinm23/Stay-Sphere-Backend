using StaySphere.Domain.Entities;

namespace StaySphere.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateAccessToken(User user);
        // string GenerateRefreshToken(User user);
    }
}