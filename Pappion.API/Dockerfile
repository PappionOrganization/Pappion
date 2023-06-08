#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8001
EXPOSE 8002

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pappion.API/Pappion.API.csproj", "Pappion.API/"]
COPY ["Pappion.Application/Pappion.Application.csproj", "Pappion.Application/"]
COPY ["Pappion.Domain/Pappion.Domain.csproj", "Pappion.Domain/"]
COPY ["Pappion.Infrastructure/Pappion.Infrastructure.csproj", "Pappion.Infrastructure/"]

RUN dotnet restore "Pappion.API/Pappion.API.csproj"
RUN dotnet restore "Pappion.Application/Pappion.Application.csproj"
RUN dotnet restore "Pappion.Domain/Pappion.Domain.csproj"
RUN dotnet restore "Pappion.Infrastructure/Pappion.Infrastructure.csproj"

COPY . .
WORKDIR "/src/Pappion.API"
RUN dotnet build "Pappion.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pappion.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Pappion.API.dll"]
