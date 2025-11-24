# RenaperService - Servicio Simulado del RENAPER

## Descripción

RenaperService es una API RESTful simulada del Registro Nacional de las Personas (RENAPER) de Argentina. Diseñada para entornos de desarrollo y testing, permite consultar datos personales ficticios de manera similar a como lo haría el servicio real.

Este proyecto fue desarrollado como parte del Trabajo Final de la materia electiva de 4to año, Programacion de Aplicaciones Distrinuidas, de Ingenieria En sistemas De Informacion.
Docente a cargo : Ing. De la Cruz, Jose.
Universidad Tecnologica Nacional - Facultad Regional Tucuman. 

## Características Principales

- **API RESTful** completa con endpoints para consulta de datos personales
- **Sistema de autenticación** por API Key por cliente
- **Documentación interactiva** con Swagger/OpenAPI
- **Datos de prueba realistas** predefinidos
- **Configuración segura** mediante variables de entorno
- **Contenerización** con Docker para fácil despliegue
- **CORS configurado** para desarrollo frontend
- **Health checks** para monitoreo del servicio

## Stack Tecnológico

### Backend y API
- **.NET 8** - Runtime y framework principal
- **C# 12** - Lenguaje de programación
- **ASP.NET Core** - Framework web
- **Docker** - Contenerización
- **Render.com** - Plataforma de hosting

### Seguridad
- **API Key Authentication** - Autenticación por clave por cliente
- **Configuration Secrets** - Variables de entorno para datos sensibles
- **Input Validation** - Validación robusta de parámetros
- **CORS** - Control de acceso entre dominios

### Calidad de Código
- **Clean Architecture** - Separación de responsabilidades
- **Dependency Injection** - Inyección de dependencias nativa

## Configuración y Despliegue

### Variables de Entorno

El servicio requiere las siguientes variables de entorno:

- `API_KEY_INVENTARIO`: API Key para el cliente principal
- `API_KEY_CLIENTE_1`: API Key para cliente externo 1
- `API_KEY_CLIENTE_2`: API Key para cliente externo 2
- `API_KEY_TESTING`: API Key para entorno de testing

### API Keys Disponibles

| Cliente | API Key | Descripción |
|---------|---------|-------------|
| Sistema de Inventario | `sk_renaper_inventario_2025_secret_key` | Cliente principal |
| Cliente Externo 1 | `sk_cliente_externo_12345` | Para integracion de cliente externo 1 |
| Cliente Externo 2 | `sk_cliente_externo_67890` | Para integracion de cliente externo 2 | 
| Testing | `sk_test_key_abc123` | Desarrollo y pruebas |

### Ejecución Local

1. Clonar el repositorio
2. Configurar las variables de entorno
3. Ejecutar `dotnet run`
4. Acceder a `http://localhost:5196`

### datos de prueba

| DNI | Nombre | Apellido | Género | Ubicación |
|-----|--------|----------|--------|-----------|
| 30123456 | MARIA | GOMEZ | F | Buenos Aires |
| 33456789 | JUAN | PEREZ | M | Mendoza |

### Documentación Interactiva

La documentación Swagger está disponible en `/swagger` cuando se ejecuta en entorno de desarrollo.

## Autenticación

Todas las requests deben incluir el header `X-API-Key` con una clave válida.

## Endpoints Principales

- `GET /api/personas/{dni}?genero={M|F|X}`: Consulta básica por DNI
- `POST /api/personas/consulta`: Consulta con body JSON
- `GET /api/personas/health`: Health check del servicio

## Ejemplo de Uso

```bash
# Consulta de persona
curl -H "X-API-Key: sk_renaper_inventario_2025_secret_key" \
  "https://renaperservice.onrender.com/api/personas/30123456?genero=F"

Licencia
Este proyecto es de uso educativo y no está afiliado al RENAPER real. Desarrollo para fines academicos.