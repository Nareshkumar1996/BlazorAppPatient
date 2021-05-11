#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Healthware/Server/Healthware.Server.csproj", "Healthware/Server/"]
COPY ["Healthware/Shared/Healthware.Shared.csproj", "Healthware/Shared/"]
COPY ["Healthware/Client/Healthware.Client.csproj", "Healthware/Client/"]
RUN dotnet restore "Healthware/Server/Healthware.Server.csproj"
COPY . .
WORKDIR "/src/Healthware/Server"
RUN dotnet build "Healthware.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Healthware.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Healthware.Server.dll"]