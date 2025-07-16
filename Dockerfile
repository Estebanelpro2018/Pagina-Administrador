# Usa imagen oficial .NET 8.0 SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Pagina Administrador.csproj", "./"]
RUN dotnet restore "Pagina Administrador.csproj"
COPY . .
RUN dotnet publish "Pagina Administrador.csproj" -c Release -o /app/publish

# Usa imagen runtime para producción
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Pagina Administrador.dll"]
