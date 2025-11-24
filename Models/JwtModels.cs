//RenaperService/Models/JwtModels.cs
namespace RenaperService.Models
{
    public class LoginRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
    }

    public class LoginResponse
    {
        public string AccessToken { get; set; } = "";
        public string TokenType { get; set; } = "Bearer";
        public int ExpiresIn { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }

    public class JwtUser
    {
        public string UserId { get; set; } = "";
        public string Username { get; set; } = "";
        public string Role { get; set; } = "";
        public List<string> Permissions { get; set; } = new();
    }
}