FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Shiptech.Api/Shiptech.Api.csproj", "Shiptech.Api/"]
COPY ["Shiptech.Infrastructure/Shiptech.Infrastructure.csproj", "Shiptech.Infrastructure/"]
COPY ["Shiptech.Application/Shiptech.Application.csproj", "Shiptech.Application/"]
COPY ["Shiptech.Domain/Shiptech.Domain.csproj", "Shiptech.Domain/"]
COPY ["Shiptech.Shared.Abstractions/Shiptech.Shared.Abstractions.csproj", "Shiptech.Shared.Abstractions/"]
COPY ["Shiptech.Shared/Shiptech.Shared.csproj", "Shiptech.Shared/"]
RUN dotnet restore "Shiptech.Api/Shiptech.Api.csproj"
COPY . .
WORKDIR "/src/Shiptech.Api"
RUN dotnet build "Shiptech.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Shiptech.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shiptech.Api.dll"]
