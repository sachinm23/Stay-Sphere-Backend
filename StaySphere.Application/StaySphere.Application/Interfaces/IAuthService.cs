namespace StaySphere.Application.Interfaces

{
    using System.Threading.Tasks;
    using StaySphere.Application.DTOs.Auth;
    using StaySphere.Domain.Enums;
    /// <summary> /// Interface for authentication service. /// Provides methods for user registration, login, and logout. /// </summary>
    public interface IAuthService
    {
        Task RegisterAsync(string name, string email, string password, UserRole role);
        Task<AuthTokensDto> LoginAsync(string email, string password); 
        // Task LogoutAsync(); 
    }
}