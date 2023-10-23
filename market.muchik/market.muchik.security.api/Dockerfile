#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["market.muchik.security.api/market.muchik.security.api.csproj", "market.muchik.security.api/"]
COPY ["market.muchik.infrastructure.ioc/market.muchik.infrastructure.ioc.csproj", "market.muchik.infrastructure.ioc/"]
COPY ["market.muchik.domain/market.muchik.domain.csproj", "market.muchik.domain/"]
COPY ["market.muchik.infrastructure.bus/market.muchik.infrastructure.bus.csproj", "market.muchik.infrastructure.bus/"]
COPY ["market.muchik.security.application/market.muchik.security.application.csproj", "market.muchik.security.application/"]
COPY ["market.muchik.infrasctructure.crosscutting/market.muchik.infrasctructure.crosscutting.csproj", "market.muchik.infrasctructure.crosscutting/"]
COPY ["market.muchik.security.domain/market.muchik.security.domain.csproj", "market.muchik.security.domain/"]
COPY ["market.muchik.security.infrastructure/market.muchik.security.infrastructure.csproj", "market.muchik.security.infrastructure/"]
RUN dotnet restore "market.muchik.security.api/market.muchik.security.api.csproj"
COPY . .
WORKDIR "/src/market.muchik.security.api"
RUN dotnet build "market.muchik.security.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "market.muchik.security.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "market.muchik.security.api.dll"]