namespace StaySphere.Application.Services
{
    using StaySphere.Application.Interfaces;
    using StaySphere.Application.DTOs.Auth;
    using StaySphere.Domain.Entities;
    using StaySphere.Domain.Enums;
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;
        public AuthService(IUserRepository userRepository, IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }
        public async Task RegisterAsync(string name, string email, string password, UserRole role)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            var user = new User(name, email, passwordHash, role);
            if(await _userRepository.GetByEmailAsync(email) != null)
            {
                throw new InvalidOperationException("A user with this email already exists.");
            }
            await _userRepository.AddAsync(user);
        }
        public async Task<AuthTokensDto> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            var accessToken = _jwtTokenService.GenerateAccessToken(user);

            var refreshToken = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            var refreshTokenExpiry = DateTime.UtcNow.AddDays(7); 

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiry = refreshTokenExpiry;
            await _userRepository.UpdateAsync(user); 
            return new AuthTokensDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
            
        }

        public async Task<AuthTokensDto> RefreshTokenAsync(string refreshToken)
        {
            var user = await _userRepository.GetAllAsync();
            var matchingUser = user.FirstOrDefault(u => u.RefreshToken == refreshToken);
            if (matchingUser == null || matchingUser.RefreshTokenExpiry < DateTime.UtcNow)
            {
                throw new UnauthorizedAccessException("Invalid or expired refresh token.");
            }

            var newAccessToken = _jwtTokenService.GenerateAccessToken(matchingUser);

            var newRefreshToken = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            var newRefreshTokenExpiry = DateTime.UtcNow.AddDays(7); 

            matchingUser.RefreshToken = newRefreshToken;
            matchingUser.RefreshTokenExpiry = newRefreshTokenExpiry;
            await _userRepository.UpdateAsync(matchingUser); 

            return new AuthTokensDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }

    }
}