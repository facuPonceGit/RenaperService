//RenaperService/Services/RenaperService.cs

using RenaperService.Models;

namespace RenaperService.Services
{
    public class RenaperService : IRenaperService
    {
        // Datos simulados del Renaper
        private readonly Dictionary<string, Persona> _personas = new()
        {
            {
                "30123456F",
                new Persona
                {
                    Dni = "30123456",
                    Nombre = "MARIA",
                    Apellido = "GOMEZ",
                    FechaNacimiento = "1985-05-15",
                    LugarNacimiento = "BUENOS AIRES",
                    Sexo = "F",
                    Nacionalidad = "ARGENTINA",
                    EstadoCivil = "CASADA",
                    Domicilio = new Domicilio
                    {
                        Calle = "AV. CORRIENTES",
                        Numero = "1234",
                        Piso = "3",
                        Departamento = "A",
                        CodigoPostal = "C1043",
                        Localidad = "CABA",
                        Provincia = "BUENOS AIRES"
                    }
                }
            },
            {
                "33456789M",
                new Persona
                {
                    Dni = "33456789",
                    Nombre = "JUAN",
                    Apellido = "PEREZ",
                    FechaNacimiento = "1990-08-22",
                    LugarNacimiento = "MENDOZA",
                    Sexo = "M",
                    Nacionalidad = "ARGENTINA",
                    EstadoCivil = "SOLTERO",
                    Domicilio = new Domicilio
                    {
                        Calle = "SAN MARTIN",
                        Numero = "567",
                        Piso = "1",
                        Departamento = "B",
                        CodigoPostal = "M5500",
                        Localidad = "MENDOZA",
                        Provincia = "MENDOZA"
                    }
                }
            }
        };

        // ✅ API KEYS POR CLIENTE (como solicitaste)
        private readonly Dictionary<string, string> _apiKeys = new()
        {
            { "inventario_app", "sk_renaper_inventario_2025_secret_key" }, // Cliente: Sistema de Inventario
            { "cliente_externo_1", "sk_cliente_externo_12345" },           // Cliente: Empresa Externa 1
            { "cliente_externo_2", "sk_cliente_externo_67890" },           // Cliente: Empresa Externa 2
            { "testing", "sk_test_key_abc123" }                            // Cliente: Testing
        };

        public Task<Persona?> ConsultarPersonaAsync(string dni, string genero)
        {
            var key = $"{dni}{genero?.ToUpper() ?? "M"}";
            if (_personas.TryGetValue(key, out var persona))
            {
                return Task.FromResult<Persona?>(persona);
            }
            return Task.FromResult<Persona?>(null);
        }

        public Task<bool> ValidarApiKeyAsync(string apiKey)
        {
            //Validar si la API Key existe en nuestro diccionario
            return Task.FromResult(_apiKeys.ContainsValue(apiKey));
        }

        public Task<bool> ValidarCredencialesAsync(string clientId, string clientSecret)
        {
            //Validar cliente + secret (para sistemas que usen client credentials)
            return Task.FromResult(_apiKeys.TryGetValue(clientId, out var secret) && secret == clientSecret);
        }
    }
}