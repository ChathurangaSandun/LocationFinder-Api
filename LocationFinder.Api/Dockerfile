FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["LocationFinder.Api/LocationFinder.Api.csproj", "LocationFinder.Api/"]
RUN dotnet restore "LocationFinder.Api/LocationFinder.Api.csproj"
COPY . .
WORKDIR "/src/LocationFinder.Api"
RUN dotnet build "LocationFinder.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LocationFinder.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocationFinder.Api.dll"]