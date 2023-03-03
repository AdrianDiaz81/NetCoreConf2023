#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Avengers.API/Avengers.API.csproj", "Avengers.API/"]
RUN dotnet restore "Avengers.API/Avengers.API.csproj"
COPY . .
WORKDIR "/src/Avengers.API"
RUN dotnet build "Avengers.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Avengers.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Avengers.API.dll"]