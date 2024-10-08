# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

ARG NUGET_PASSWORD
RUN dotnet nuget add source "https://pkgs.dev.azure.com/sanjyotagureddy/merastore/_packaging/merastore/nuget/v3/index.json" -n "mera-store" -u "sanjyotagureddy" -p "$NUGET_PASSWORD" --store-password-in-clear-text

COPY ["src/MeraStore.Service.Logging.Api/MeraStore.Service.Logging.Api.csproj", "src/MeraStore.Service.Logging.Api/"]
COPY ["src/MeraStore.Service.Logging.Application/MeraStore.Service.Logging.Application.csproj", "src/MeraStore.Service.Logging.Application/"]
COPY ["src/MeraStore.Service.Logging.Core/MeraStore.Service.Logging.Core.csproj", "src/MeraStore.Service.Logging.Core/"]
COPY ["src/MeraStore.Service.Logging.Infrastructure/MeraStore.Service.Logging.Infrastructure.csproj", "src/MeraStore.Service.Logging.Infrastructure/"]
RUN dotnet restore "./src/MeraStore.Service.Logging.Api/MeraStore.Service.Logging.Api.csproj"
COPY . .
WORKDIR "/src/src/MeraStore.Service.Logging.Api"
RUN dotnet build "./MeraStore.Service.Logging.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MeraStore.Service.Logging.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MeraStore.Service.Logging.Api.dll"]