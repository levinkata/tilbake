#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Tilbake.MVC/Tilbake.MVC.csproj", "Tilbake.MVC/"]
COPY ["Tilbake.Domain/Tilbake.Domain.csproj", "Tilbake.Domain/"]
COPY ["Tilbake.Infrastructure.IoC/Tilbake.Infrastructure.IoC.csproj", "Tilbake.Infrastructure.IoC/"]
COPY ["Tilbake.Infrastructure.Persistence/Tilbake.Infrastructure.Persistence.csproj", "Tilbake.Infrastructure.Persistence/"]
COPY ["Tilbake.Application/Tilbake.Application.csproj", "Tilbake.Application/"]
RUN dotnet restore "Tilbake.MVC/Tilbake.MVC.csproj"
COPY . .
WORKDIR "/src/Tilbake.MVC"
RUN dotnet build "Tilbake.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tilbake.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tilbake.MVC.dll"]