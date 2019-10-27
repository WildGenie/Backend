FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
# Copy csproj for restore
COPY ["./src/", "/build/src/"]
COPY ["./backend/", "/build/backend/"]
COPY ["./common.props", "/build/"]

# Restore Nuget packages
WORKDIR /build/backend/GelecekBilimde.Backend.HttpApi.Host/
RUN dotnet restore

FROM build AS publish
WORKDIR /build/backend/GelecekBilimde.Backend.HttpApi.Host/
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
EXPOSE 5000
VOLUME /app/wwwroot

WORKDIR /app
COPY --from=publish /app .
HEALTHCHECK CMD curl --fail http://localhost:5000/health || exit 1
RUN chmod +x ./wait-for-it.sh
ENTRYPOINT ["./wait-for-it.sh", "postgresql:5432", "--", "dotnet", "GelecekBilimde.Backend.HttpApi.Host.dll"]
