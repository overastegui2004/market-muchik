#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["market.muchik.pay.api/market.muchik.pay.api.csproj", "market.muchik.pay.api/"]
COPY ["market.muchik.infrastructure.ioc/market.muchik.infrastructure.ioc.csproj", "market.muchik.infrastructure.ioc/"]
COPY ["market.muchik.domain/market.muchik.domain.csproj", "market.muchik.domain/"]
COPY ["market.muchik.infrastructure.bus/market.muchik.infrastructure.bus.csproj", "market.muchik.infrastructure.bus/"]
COPY ["market.muchik.pay.application/market.muchik.payment.application.csproj", "market.muchik.pay.application/"]
COPY ["market.muchik.pay.infrastructure/market.muchik.pay.infrastructure.csproj", "market.muchik.pay.infrastructure/"]
COPY ["market.muchik.pay.domain/market.muchik.pay.domain.csproj", "market.muchik.pay.domain/"]
RUN dotnet restore "market.muchik.pay.api/market.muchik.pay.api.csproj"
COPY . .
WORKDIR "/src/market.muchik.pay.api"
RUN dotnet build "market.muchik.pay.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "market.muchik.pay.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "market.muchik.pay.api.dll"]