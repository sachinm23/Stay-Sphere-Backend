namespace StaySphere.Application.DTOs.Auth
{
    public class AuthTokensDto
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }    
}