FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Parts.API/Parts.API.csproj", "src/Parts.API/"]
COPY ["src/Parts.Application/Parts.Application.csproj", "src/Parts.Application/"]
COPY ["src/Parts.Contract/Parts.Contract.csproj", "src/Parts.Contract/"]
COPY ["src/Parts.Domain/Parts.Domain.csproj", "src/Parts.Domain/"]
COPY ["src/Parts.Persistence/Parts.Persistence.csproj", "src/Parts.Persistence/"]
COPY ["src/Parts.Infrastructure.Dapper/Parts.Infrastructure.Dapper.csproj", "src/Parts.Infrastructure.Dapper/"]
COPY ["src/Parts.Infrastructure/Parts.Infrastructure.csproj", "src/Parts.Infrastructure/"]
COPY ["src/Parts.Presentation/Parts.Presentation.csproj", "src/Parts.Presentation/"]
RUN dotnet restore "src/Parts.API/Parts.API.csproj"
COPY . .
WORKDIR "/src/src/Parts.API"
RUN dotnet build "Parts.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Parts.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Parts.API.dll"]
