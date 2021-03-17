#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE $PORT

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["ServerHttpPlatform/ServerHttpPlatform.csproj", "ServerHttpPlatform/"]
COPY ["OuterReadOnlyDatabase/OuterReadOnlyDatabase.csproj", "OuterReadOnlyDatabase/"]
COPY ["DataBaseEntityFramework/DataBaseEntityFramework.csproj", "DataBaseEntityFramework/"]
RUN dotnet restore "ServerHttpPlatform/ServerHttpPlatform.csproj"
COPY . .
WORKDIR "/src/ServerHttpPlatform"
RUN dotnet build "ServerHttpPlatform.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServerHttpPlatform.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServerHttpPlatform.dll"]