#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Autenticazione/Autenticazione.csproj", "Autenticazione/"]
COPY ["Autenticazione.Business1/Autenticazione.Business.csproj", "Autenticazione.Business1/"]
COPY ["Autenticazione.Repository/Autenticazione.Repository.csproj", "Autenticazione.Repository/"]
COPY ["Autenticazione.Shared/Autenticazione.Shared.csproj", "Autenticazione.Shared/"]
RUN dotnet restore "./Autenticazione/Autenticazione.csproj"
COPY . .
COPY ["Unipr.Utility.Kafka.dll", "/src/Autenticazione/"]
COPY ["Unipr.Utility.Kafka.dll", "/src/Autenticazione.Business1"]
WORKDIR "/src/Autenticazione"
RUN dotnet build "./Autenticazione.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Autenticazione.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Autenticazione.dll"]