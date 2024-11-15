#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Annunci.Api/Transazioni.Api.csproj", "Annunci.Api/"]
COPY ["Annunci.Business/Transazioni.Business.csproj", "Annunci.Business/"]
COPY ["Annunci.Repository/Transazioni.Repository.csproj", "Annunci.Repository/"]
COPY ["Annunci.Shared/Transazioni.Shared.csproj", "Annunci.Shared/"]
RUN dotnet restore "./Annunci.Api/Transazioni.Api.csproj"
COPY . .
COPY ["Unipr.Utility.Kafka.dll", "/src/Annunci.Api"]
COPY ["Unipr.Utility.Kafka.dll", "/src/Annunci.Business"]
COPY ["Autenticazione.Http.dll", "/src/Annunci.Api/"]
WORKDIR "/src/Annunci.Api"
RUN dotnet build "./Transazioni.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Transazioni.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Transazioni.Api.dll"]