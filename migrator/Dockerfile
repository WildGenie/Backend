FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
COPY ["./src/GelecekBilimde.Backend.EntityFrameworkCore.DbMigrations/", "/build/src/GelecekBilimde.Backend.EntityFrameworkCore.DbMigrations/"]
COPY ["./src/GelecekBilimde.Backend.EntityFrameworkCore/", "/build/src/GelecekBilimde.Backend.EntityFrameworkCore/"]
COPY ["./src/GelecekBilimde.Backend.Domain.Shared/", "/build/src/GelecekBilimde.Backend.Domain.Shared/"]
COPY ["./src/GelecekBilimde.Backend.Domain/", "/build/src/GelecekBilimde.Backend.Domain/"]
COPY ["./migrator/GelecekBilimde.Backend.DbMigrator/", "/build/migrator/GelecekBilimde.Backend.DbMigrator/"]
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
