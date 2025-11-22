namespace RenaperService.Middleware
{
	public class ApiKeyMiddleware
	{
		private readonly RequestDelegate _next;
		private const string APIKEY = "X-API-Key";
		private const string VALID_API_KEY = "MiClaveSecreta"; // En producción, guardar en configuración
		private readonly string _validApiKey;

		public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
		{
			_next = next;
			_validApiKey = configuration.GetValue<string>("ApiKey") ?? throw new ArgumentNullException("ApiKey no configurada");
		}

		public async Task InvokeAsync(HttpContext context)
		{
			if (!context.Request.Headers.TryGetValue(APIKEY, out var extractedApiKey))
			{
				context.Response.StatusCode = 401;
				await context.Response.WriteAsync("Api Key no fue proporcionada");
				return;
			}

			if (!_validApiKey.Equals(extractedApiKey))
			{
				context.Response.StatusCode = 401;
				await context.Response.WriteAsync("Api Key no es válida");
				return;
			}

			await _next(context);
		}
	}
}