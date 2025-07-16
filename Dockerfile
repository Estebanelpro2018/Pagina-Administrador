# Imagen base para producción
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Imagen para compilación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["Pagina Administrador.csproj", "./"]
RUN dotnet restore "Pagina Administrador.csproj"

COPY . .
RUN dotnet publish "Pagina Administrador.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Pagina Administrador.dll"]
