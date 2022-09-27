FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build


ARG TOKEN
WORKDIR /src

COPY ["UsersManagement/TrialsSystem.UserTasksService/TrialsSystem.UserTasksService.Api/TrialsSystem.UserTasksService.Api.csproj", "UsersManagement/TrialsSystem.UserTasksService/TrialsSystem.UserTasksService.Api/"]
COPY ["UsersManagement/TrialsSystem.UserTasksService/TrialsSystem.UserTasksService.Domain/TrialsSystem.UserTasksService.Domain.csproj", "UsersManagement/TrialsSystem.UserTasksService/TrialsSystem.UserTasksService.Domain/"]
COPY ["UsersManagement/TrialsSystem.UserTasksService/TrialsSystem.UserTasksService.Infrastructure/TrialsSystem.UserTasksService.Infrastructure.csproj", "UsersManagement/TrialsSystem.UserTasksService/TrialsSystem.UserTasksService.Infrastructure/"]
COPY ["UsersManagement/TrialsSystem.UserTasksService/TrialsSystem.UserTasksService.Tests/TrialsSystem.UserTasksService.Tests.csproj", "UsersManagement/TrialsSystem.UserTasksService/TrialsSystem.UserTasksService.Tests/"]
COPY ["UsersManagement/TrialsSystem.UserTasksService/TrialsSystem.UserTasksService.sln", "UsersManagement/TrialsSystem.UserTasksService/"]
COPY ["UsersManagement/TrialsSystem.UserTasksService/nuget.config", "UsersManagement/TrialsSystem.UserTasksService/"]

RUN dotnet restore "UsersManagement/TrialsSystem.UserTasksService/TrialsSystem.UserTasksService.sln"
COPY . .

WORKDIR UsersManagement/TrialsSystem.UserTasksService/TrialsSystem.UserTasksService.Api
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM build as unittest
WORKDIR UsersManagement/TrialsSystem.UserTasksService/TrialsSystem.UserTasksService.Tests

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "TrialsSystem.UserTasksService.Api.dll"]