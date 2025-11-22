# RenaperService - Servicio Simulado del RENAPER

Servicio API RESTful simulado del Registro Nacional de las Personas (RENAPER) de Argentina, diseñado para entornos de desarrollo y testing.

## Características

- **Consulta de datos personales** por DNI y género
- **Autenticación por API Key** por cliente
- **Documentación Swagger** integrada
- **Datos de prueba realistas** predefinidos
- **CORS habilitado** para desarrollo
- **Health checks** para monitoreo

## Autenticación

Todas las requests requieren API Key en el header:
X-API-Key: sk_renaper_inventario_2025_secret_key

text

### API Keys Disponibles

| Cliente | API Key | Descripción |
|---------|---------|-------------|
| Sistema de Inventario | `sk_renaper_inventario_2025_secret_key` | Cliente principal |
| Cliente Externo 1 | `sk_cliente_externo_12345` | Para integraciones futuras |
| Cliente Externo 2 | `sk_cliente_externo_67890` | Para integraciones futuras |
| Testing | `sk_test_key_abc123` | Desarrollo y pruebas |

## Endpoints

### Consulta Básica
GET /api/personas/{dni}?genero={M|F|X}

### Consulta con Body
POST /api/personas/consulta
Content-Type: application/json

{
"dni": "30123456",
"genero": "F"
}

### Health Check
GET /api/personas/health

## Datos de Prueba

| DNI | Nombre | Apellido | Género | Ubicación |
|-----|--------|----------|--------|-----------|
| 30123456 | MARIA | GOMEZ | F | Buenos Aires |
| 33456789 | JUAN | PEREZ | M | Mendoza |
| 35234123 | ALEX | RODRIGUEZ | X | Córdoba |

## Desarrollo

### Requisitos
- .NET 8.0 SDK
- Visual Studio 2022 o VS Code

### Ejecutar Localmente
```bash
dotnet run
La aplicación estará disponible en: http://localhost:5196

Documentación Interactiva
Disponible en: http://localhost:5196/swagger 