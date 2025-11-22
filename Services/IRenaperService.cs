using RenaperService.Models;

namespace RenaperService.Services
{
    public interface IRenaperService
    {
        Task<Persona?> ConsultarPersonaAsync(string dni, string genero);
        Task<bool> ValidarCredencialesAsync(string clientId, string clientSecret);
        Task<bool> ValidarApiKeyAsync(string apiKey);
    }
}