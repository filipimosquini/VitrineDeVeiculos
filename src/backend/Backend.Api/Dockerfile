#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
ARG ENV_ARG=Production
ENV ASPNETCORE_ENVIRONMENT=$ENV_ARG
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /backend
COPY ["backend/Backend.Api/Backend.Api.csproj", "Backend.Api/"]
COPY ["backend/Backend.Application/Backend.Application.csproj", "Backend.Application/"]
COPY ["backend/Backend.Domain/Backend.Domain.csproj", "Backend.Domain/"]
COPY ["backend/Backend.Infra/Backend.Infra.csproj", "Backend.Infra/"]
COPY ["backend/Backend.CrossCutting/Backend.CrossCutting.csproj", "Backend.CrossCutting/"]
COPY ["backend/Backend.Ioc/Backend.Ioc.csproj", "Backend.Ioc/"]

RUN dotnet restore "Backend.Api/Backend.Api.csproj"
COPY . .
WORKDIR "backend/Backend.Api"
RUN dotnet build "Backend.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Backend.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Backend.Api.dll"]