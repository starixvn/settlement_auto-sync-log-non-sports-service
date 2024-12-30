FROM hub.nexdev.net/base/dotnet/core/sdk:9.0-alpine AS builder
WORKDIR /src

COPY ./Sources/AutoSyncLogNonSports ./AutoSyncLogNonSports
COPY ./Sources/Fanex.AutoSyncLogNonSports.Service/Fanex.AutoSyncLogNonSports.Service.csproj ./Fanex.AutoSyncLogNonSports.Service/Fanex.AutoSyncLogNonSports.Service.csproj

WORKDIR /src/Fanex.AutoSyncLogNonSports.Service
RUN dotnet nuget add source https://nuget.nexdev.net/api/v2
RUN dotnet restore -v n

COPY ./Sources/Fanex.AutoSyncLogNonSports.Service .

RUN dotnet publish -r linux-x64 --self-contained false -c Release -o /app 

FROM hub.nexdev.net/base/dotnet/core/aspnet:9.0-alpine AS base

WORKDIR /app
COPY --from=builder /app .

ENTRYPOINT ["dotnet", "Fanex.AutoSyncLogNonSports.Service.dll"]
