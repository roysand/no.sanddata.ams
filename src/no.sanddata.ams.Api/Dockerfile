FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/no.sanddata.ams.Api/no.sanddata.ams.Api.csproj", "src/no.sanddata.ams.Api/"]
RUN dotnet restore "src/no.sanddata.ams.Api/no.sanddata.ams.Api.csproj"
COPY . .
WORKDIR "/src/src/no.sanddata.ams.Api"
RUN dotnet build "./no.sanddata.ams.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./no.sanddata.ams.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "no.sanddata.ams.Api.dll"]
