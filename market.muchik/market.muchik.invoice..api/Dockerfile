#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["nh.qhatu.homedelivery.api/nh.qhatu.homedelivery.api.csproj", "nh.qhatu.homedelivery.api/"]
COPY ["nh.qhatu.homedelivery.application/nh.qhatu.homedelivery.application.csproj", "nh.qhatu.homedelivery.application/"]
COPY ["nh.qhatu.homedelivery.domain/nh.qhatu.homedelivery.domain.csproj", "nh.qhatu.homedelivery.domain/"]
COPY ["nh.qhatu.homedelivery.infrastructure/nh.qhatu.homedelivery.infrastructure.csproj", "nh.qhatu.homedelivery.infrastructure/"]
COPY ["nh.qhatu.infrastructure.ioc/nh.qhatu.infrastructure.ioc.csproj", "nh.qhatu.infrastructure.ioc/"]
COPY ["nh.qhatu.domain/nh.qhatu.domain.csproj", "nh.qhatu.domain/"]
COPY ["nh.qhatu.infrastructure.bus/nh.qhatu.infrastructure.bus.csproj", "nh.qhatu.infrastructure.bus/"]
RUN dotnet restore "nh.qhatu.homedelivery.api/nh.qhatu.homedelivery.api.csproj"
COPY . .
WORKDIR "/src/nh.qhatu.homedelivery.api"
RUN dotnet build "nh.qhatu.homedelivery.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "nh.qhatu.homedelivery.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "nh.qhatu.homedelivery.api.dll"]