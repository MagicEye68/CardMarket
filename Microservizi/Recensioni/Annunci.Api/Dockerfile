#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Annunci.Api/Recensioni.Api.csproj", "Annunci.Api/"]
COPY ["Annunci.Business/Recensioni.Business.csproj", "Annunci.Business/"]
COPY ["Annunci.Repository/Recensioni.Repository.csproj", "Annunci.Repository/"]
COPY ["Annunci.Shared/Recensioni.Shared.csproj", "Annunci.Shared/"]
RUN dotnet restore "./Annunci.Api/Recensioni.Api.csproj"
COPY . .
COPY ["Unipr.Utility.Kafka.dll", "/src/Annunci.Api"]
COPY ["Unipr.Utility.Kafka.dll", "/src/Annunci.Business"]
COPY ["Autenticazione.Http.dll", "/src/Annunci.Api/"]
WORKDIR "/src/Annunci.Api"
RUN dotnet build "./Recensioni.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Recensioni.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Recensioni.Api.dll"]