//RenaperService/Filters/ApiKeyAuthFilter.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RenaperService.Services;

namespace RenaperService.Filters
{
	public class ApiKeyAuthFilter : IAsyncActionFilter
	{
		private const string API_KEY_HEADER = "X-API-Key";
		private readonly IRenaperService _renaperService;

		public ApiKeyAuthFilter(IRenaperService renaperService)
		{
			_renaperService = renaperService;
		}

		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			if (!context.HttpContext.Request.Headers.TryGetValue(API_KEY_HEADER, out var extractedApiKey))
			{
				context.Result = new UnauthorizedObjectResult(new
				{
					error = "API Key requerida",
					message = "Incluya el header X-API-Key"
				});
				return;
			}

			if (!await _renaperService.ValidarApiKeyAsync(extractedApiKey!))
			{
				context.Result = new UnauthorizedObjectResult(new
				{
					error = "API Key inválida",
					message = "La API Key proporcionada no es válida"
				});
				return;
			}

			await next();
		}
	}
}