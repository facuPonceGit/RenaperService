//RenaperService/Models/Persona.cs
namespace RenaperService.Models
{
    public class Persona
    {
        public string Dni { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
        public string FechaNacimiento { get; set; } = "";
        public string LugarNacimiento { get; set; } = "";
        public string Sexo { get; set; } = "";
        public string Nacionalidad { get; set; } = "";
        public string EstadoCivil { get; set; } = "";
        public Domicilio? Domicilio { get; set; }
    }

    public class Domicilio
    {
        public string Calle { get; set; } = "";
        public string Numero { get; set; } = "";
        public string Piso { get; set; } = "";
        public string Departamento { get; set; } = "";
        public string CodigoPostal { get; set; } = "";
        public string Localidad { get; set; } = "";
        public string Provincia { get; set; } = "";
    }

    public class ConsultaPersonaRequest
    {
        public string Dni { get; set; } = "";
        public string Genero { get; set; } = "M";
    }
}