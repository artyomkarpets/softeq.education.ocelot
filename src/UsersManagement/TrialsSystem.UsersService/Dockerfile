FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build


ARG TOKEN
WORKDIR /src

COPY ["UsersManagement/TrialsSystem.UsersService/TrialsSystem.UsersService.Api/TrialsSystem.UsersService.Api.csproj", "UsersManagement/TrialsSystem.UsersService/TrialsSystem.UsersService.Api/"]
COPY ["UsersManagement/TrialsSystem.UsersService/TrialsSystem.UsersService.Domain/TrialsSystem.UsersService.Domain.csproj", "UsersManagement/TrialsSystem.UsersService/TrialsSystem.UsersService.Domain/"]
COPY ["UsersManagement/TrialsSystem.UsersService/TrialsSystem.UsersService.Infrastructure/TrialsSystem.UsersService.Infrastructure.csproj", "UsersManagement/TrialsSystem.UsersService/TrialsSystem.UsersService.Infrastructure/"]
COPY ["UsersManagement/TrialsSystem.UsersService/TrialsSystem.UsersService.Tests/TrialsSystem.UsersService.Tests.csproj", "UsersManagement/TrialsSystem.UsersService/TrialsSystem.UsersService.Tests/"]
COPY ["UsersManagement/TrialsSystem.UsersService/TrialsSystem.UsersService.sln", "UsersManagement/TrialsSystem.UsersService/"]
COPY ["UsersManagement/TrialsSystem.UsersService/nuget.config", "UsersManagement/TrialsSystem.UsersService/"]

RUN dotnet restore "UsersManagement/TrialsSystem.UsersService/TrialsSystem.UsersService.sln"
COPY . .

WORKDIR UsersManagement/TrialsSystem.UsersService/TrialsSystem.UsersService.Api
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM build as unittest
WORKDIR UsersManagement/TrialsSystem.UsersService/TrialsSystem.UsersService.Tests

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "TrialsSystem.UsersService.Api.dll"]