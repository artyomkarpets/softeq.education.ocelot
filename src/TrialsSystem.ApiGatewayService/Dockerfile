FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build


ARG TOKEN
WORKDIR /src

COPY ["TrialsSystem.ApiGatewayService/TrialsSystem.ApiGatewayService.Api/TrialsSystem.ApiGatewayService.Api.csproj", "TrialsSystem.ApiGatewayService/TrialsSystem.ApiGatewayService.Api/"]
COPY ["TrialsSystem.ApiGatewayService/TrialsSystem.ApiGatewayService.sln", "TrialsSystem.ApiGatewayService/"]
COPY ["TrialsSystem.ApiGatewayService/nuget.config", "TrialsSystem.ApiGatewayService/"]

RUN dotnet restore "TrialsSystem.ApiGatewayService/TrialsSystem.ApiGatewayService.sln"
COPY . .

WORKDIR TrialsSystem.ApiGatewayService/TrialsSystem.ApiGatewayService.Api
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "TrialsSystem.ApiGatewayService.Api.dll"]