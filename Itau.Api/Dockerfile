#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Itau.Api/Itau.Api.csproj", "Itau.Api/"]
COPY ["Itau.Dados/Itau.Dados.csproj", "Itau.Dados/"]
COPY ["Itau.Dominio/Itau.Dominio.csproj", "Itau.Dominio/"]
COPY ["Itau.TheCat.Dados/Itau.TheCat.Dados.csproj", "Itau.TheCat.Dados/"]
COPY ["Itau.TheCat.Dominio/Itau.TheCat.Dominio.csproj", "Itau.TheCat.Dominio/"]
RUN dotnet restore "Itau.Api/Itau.Api.csproj"
COPY . .
WORKDIR "/src/Itau.Api"
RUN dotnet build "Itau.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Itau.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Itau.Api.dll"]