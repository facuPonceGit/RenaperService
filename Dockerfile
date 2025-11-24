FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar el proyecto y restaurar dependencias
COPY *.csproj .
RUN dotnet restore

# Copiar todo el código y publicar
COPY . .
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .

# Exponer puerto (Render usa puerto dinámico)
EXPOSE 8080

# Variable de entorno para el puerto
ENV ASPNETCORE_URLS=http://*:8080

ENTRYPOINT ["dotnet", "RenaperService.dll"]