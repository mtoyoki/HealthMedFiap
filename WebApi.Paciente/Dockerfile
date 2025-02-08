#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApi.Paciente/WebApi.Paciente.csproj", "WebApi.Paciente/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["WebApi.Shared/WebApi.Shared.csproj", "WebApi.Shared/"]
COPY ["Infra.Data/Infra.Data.csproj", "Infra.Data/"]
RUN dotnet restore "./WebApi.Paciente/WebApi.Paciente.csproj"
COPY . .
WORKDIR "/src/WebApi.Paciente"
RUN dotnet build "./WebApi.Paciente.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebApi.Paciente.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.Paciente.dll"]