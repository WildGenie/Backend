FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
COPY ["./src/", "/build/src/"]
COPY ["./migrator/", "/build/migrator/"]
COPY ["./common.props", "/build/"]

WORKDIR /build/migrator/GelecekBilimde.Backend.DbMigrator
RUN dotnet restore
# RUN dotnet build "GelecekBilimde.Backend.DbMigrator.csproj" -c Release -o /app

FROM build AS publish
WORKDIR /build/migrator/GelecekBilimde.Backend.DbMigrator
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
COPY --from=publish /app .

RUN chmod +x ./wait-for-it.sh
ENTRYPOINT ["./wait-for-it.sh", "postgresql:5432", "--", "dotnet", "GelecekBilimde.Backend.DbMigrator.dll"]
