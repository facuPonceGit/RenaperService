using Microsoft.Extensions.Configuration;
using RenaperService.Models;

namespace RenaperService.Services
{
    public class RenaperService : IRenaperService
    {
        private readonly Dictionary<string, Persona> _personas;
        private readonly Dictionary<string, string> _apiKeys;

        public RenaperService(IConfiguration configuration)
        {
            // Datos simulados del Renaper
            _personas = new Dictionary<string, Persona>
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

            // CARGAR API KEYS DESDE VARIABLES DE ENTORNO
            _apiKeys = new Dictionary<string, string>();

            // Clave para inventario_app
            var inventarioKey = configuration["API_KEY_INVENTARIO"]
                ?? throw new ArgumentNullException("API_KEY_INVENTARIO no configurada");
            _apiKeys["inventario_app"] = inventarioKey;

            // Claves para clientes externos (opcionales)
            var cliente1Key = configuration["API_KEY_CLIENTE_1"];
            var cliente2Key = configuration["API_KEY_CLIENTE_2"];
            var testingKey = configuration["API_KEY_TESTING"];

            if (!string.IsNullOrEmpty(cliente1Key))
                _apiKeys["cliente_externo_1"] = cliente1Key;

            if (!string.IsNullOrEmpty(cliente2Key))
                _apiKeys["cliente_externo_2"] = cliente2Key;

            if (!string.IsNullOrEmpty(testingKey))
                _apiKeys["testing"] = testingKey;
        }

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
            return Task.FromResult(_apiKeys.ContainsValue(apiKey));
        }

        public Task<bool> ValidarCredencialesAsync(string clientId, string clientSecret)
        {
            return Task.FromResult(_apiKeys.TryGetValue(clientId, out var secret) && secret == clientSecret);
        }
    }
}