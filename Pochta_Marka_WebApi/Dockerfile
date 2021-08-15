#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Pochta_Marka_WebApi/Pochta_Marka_WebApi.csproj", "Pochta_Marka_WebApi/"]
RUN dotnet restore "Pochta_Marka_WebApi/Pochta_Marka_WebApi.csproj"
COPY . .
WORKDIR "/src/Pochta_Marka_WebApi"
RUN dotnet build "Pochta_Marka_WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pochta_Marka_WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pochta_Marka_WebApi.dll"]