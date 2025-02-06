#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApi.Medico/WebApi.Medico.csproj", "WebApi.Medico/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["WebApi.Shared/WebApi.Shared.csproj", "WebApi.Shared/"]
COPY ["Infra.Data/Infra.Data.csproj", "Infra.Data/"]
RUN dotnet restore "./WebApi.Medico/WebApi.Medico.csproj"
COPY . .
WORKDIR "/src/WebApi.Medico"
RUN dotnet build "./WebApi.Medico.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebApi.Medico.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.Medico.dll"]